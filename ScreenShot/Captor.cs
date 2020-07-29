using System;
using System.Drawing;
using System.Windows.Forms;
using ScreenShot.Core.Layer.Base;
using ScreenShot.Core.Util;

namespace ScreenShot
{
    public sealed partial class Captor : Form
    {
        private Image _baseImage;

        private bool _isExploring = false;
        private ExploreLayer _exploreLayer;

        private bool _isCapturing = false;
        private CaptureLayer _captureLayer;

        public Captor()
        {
            InitializeComponent();
            // 防止页面闪烁
            SetStyle(
                ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.UserPaint, true);
//            this.TopMost = true; // 置为顶层
            this.ShowInTaskbar = true; // 显示在任务栏
            // 不要使用最大化，否则导致多屏幕下，无法设置CaptorForm的Size和Location
            // this.WindowState = FormWindowState.Maximized; 
            this.Init();
        }

        private void Init()
        {
            this._baseImage = ImageUtil.GetScreenImage(out Rectangle virtualScreen);
            this.BackgroundImage = this._baseImage;
            this.Size = virtualScreen.Size;
            this.Location = virtualScreen.Location;
            // Init Status
            this._isExploring = true;
            this._isCapturing = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Build Layers
            this._captureLayer = new CaptureLayer(this.Size);
            this._exploreLayer = new LineExploreLayer(this.Size);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this._isCapturing = true;
            this._isExploring = false;
            this._captureLayer.InitLocation = e.Location;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Rectangle capture = this._captureLayer.Capture;
            if (capture.Width > 0 && capture.Height > 0)
            {
                using (Editor editor = new Editor(this._baseImage, capture))
                {
                    editor.EditorClose += (sender, args) =>
                    {
                        this._isExploring = true;
                        this._isCapturing = false;
                    };
                    editor.ShowDialog();
                }
            }
            this._isExploring = true;
            this._isCapturing = false;
        }


        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Point current = e.Location;
            this._exploreLayer.CurrentLocation = current;
            this._captureLayer.CurrentLocation = current;
            this.InvalidateLayers();
        }

        private void InvalidateLayers()
        {
            if (this._isExploring)
            {
                this._exploreLayer.Invalidate(this);
            }

            if (this._isCapturing)
            {
                this._captureLayer.Invalidate(this);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (this._isExploring)
            {
                this._exploreLayer?.OnPaint(e.Graphics);
            }

            if (this._isCapturing)
            {
                this._captureLayer?.OnPaint(e.Graphics);
            }
        }

        private void Captor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}