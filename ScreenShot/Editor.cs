using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScreenShot.Layer.Edit;
using ScreenShot.Layer.Edit.Impl;

namespace ScreenShot
{
    public partial class Editor : Form
    {

        /// <summary>
        /// Close event
        /// </summary>
        public event EventHandler<EditorCloseEventArgs> EditorClose;

        private readonly Image _srcImage;

        private readonly Rectangle _capture;

        private DefaultEditLayer _defaultEditLayer;

        private readonly List<EditLayer> _editLayers;

        private Editor()
        {
            InitializeComponent();
        }
        public Editor(Image srcImage, Rectangle capture) : this()
        {
            this._toolBox.ToolChosen += ToolChosen;
            this._srcImage = srcImage;
            this._capture = capture;
            this._editLayers = new List<EditLayer>();
            this.Init();
        }

        private void Init()
        {
            SetStyle(
                ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.UserPaint, true);
            //            this.TopMost = true; // 置为顶层
            this.ShowInTaskbar = true; // 显示在任务栏
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackgroundImage = this._srcImage;
            this._toolBox.Location = new Point(
                this._capture.X + (this._capture.Width - this._toolBox.Width), 
                this._capture.Y + this._capture.Height + 5);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this._defaultEditLayer = new DefaultEditLayer(this.Size, this._capture);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this._editLayers.ForEach(historyLayer => historyLayer.Editing = false);
            this._editLayers.Add(new RectEditLayer(this.Size)
            {
                InitCursor = e.Location
            });
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            EditLayer editingLayer = this._editLayers.Find(one => one.Editing);
            if (editingLayer != null)
            {
                editingLayer.CurrentCursor = e.Location;
            }
            this.InvalidateLayers();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this._editLayers.ForEach(historyLayer => historyLayer.Editing = false);
        }

        private void InvalidateLayers()
        {
            this._editLayers.ForEach(layer => layer.Invalidate(this));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this._defaultEditLayer.OnPaint(e.Graphics);
            this._editLayers.ForEach(editLayer =>
            {
                editLayer.OnPaint(e.Graphics);
            });
        }
        protected virtual void OnEditorClose(EditorCloseEventArgs e)
        {
            EditorClose?.Invoke(this, e);
        }

        private void ToolChosen(object sender, ToolChosenEventArgs e)
        {
            if (e.ToolItem == ToolItem.Cancel)
            {
                OnClose();
            }

            if (e.ToolItem == ToolItem.Undo)
            {
                if (this._editLayers.Count != 0)
                {
                    this._editLayers.RemoveAt(this._editLayers.Count - 1);
                    this.InvalidateLayers();
                }
            }
        }

        private void Editor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.OnClose();
            }
        }

        private void OnClose()
        {
            OnEditorClose(new EditorCloseEventArgs());
            this.Close();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ImageAcquiredEventArgs : EventArgs
    {
        public byte[] ImageData { get; }

        public ImageAcquiredEventArgs(byte[] imageData)
        {
            ImageData = imageData;
        }
    }

    public class EditorCloseEventArgs : EventArgs
    {
    }
}
