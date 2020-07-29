using System;
using System.Drawing;
using System.Windows.Forms;
using ScreenShot.Core.Event;
using ScreenShot.Core.Layer.Base;
using ScreenShot.Core.Layer.Edit.Impl;
using ScreenShot.Core.Util;

namespace ScreenShot.Mini
{
    public sealed partial class MiniCaptor : Form
    {

        public event EventHandler<ImageDataAcquiredEventArgs> ImageDataAcquired;

        private Image _baseImage;

        private bool _isExploring = false;
        private ExploreLayer _exploreLayer;

        private bool _isCapturing = false;
        private CaptureLayer _captureLayer;

        private bool _isCaptured = false;
        private DefaultEditLayer _defaultEditLayer;

        public MiniCaptor()
        {
            InitializeComponent();
            // 防止页面闪烁
            SetStyle(
                ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.UserPaint, true);
            // this.TopMost = true; // 置为顶层
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
            this._isCaptured = false;
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
            this._isExploring = false;
            this._isCapturing = true;
            this._isCaptured = false;
            this._captureLayer.InitLocation = e.Location;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Rectangle capture = this._captureLayer.Capture;
            if (capture.Width > 0 && capture.Height > 0)
            {
                this._isExploring = false;
                this._isCapturing = false;
                this._isCaptured = true;
                this._defaultEditLayer = new DefaultEditLayer(this.Size, capture);
            }
            else
            {
                this._isExploring = true;
                this._isCapturing = false;
                this._isCaptured = false;
            }
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
                this._exploreLayer?.Invalidate(this);
            }

            if (this._isCapturing)
            {
                this._captureLayer?.Invalidate(this);
            }

            if (this._isCaptured)
            {
                this._defaultEditLayer?.Invalidate(this);
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

            if (this._isCaptured)
            {
                this._defaultEditLayer?.OnPaint(e.Graphics);
            }
        }
        private void MiniCaptor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape && e.KeyCode != Keys.Space)
            {
                return;
            }

            if (e.KeyCode == Keys.Escape)
            {
                if (this._isCapturing || this._isCaptured)
                {
                    this._isCapturing = this._isCaptured = false;
                    this._defaultEditLayer = null;
                    this._isExploring = true;
                    this.Invalidate();
                    return;
                }

                if (this._isExploring)
                {
                    this.Close();
                }
            }
            else
            {
                if (!this._isCaptured)
                {
                    return;
                }
                this._isCaptured = this._isCapturing = false;
                this._isExploring = true;
                byte[] imageData =
                    ImageUtil.GetTargetImageToBytes(this._baseImage, this._captureLayer.Capture);
                OnImageDataAcquired(new ImageDataAcquiredEventArgs(imageData));
            }
        }

        private void OnImageDataAcquired(ImageDataAcquiredEventArgs e)
        {
            ImageDataAcquired?.Invoke(this, e);
        }
    }
}