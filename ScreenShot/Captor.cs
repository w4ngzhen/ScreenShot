﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScreenShot.Layer;
using ScreenShot.Layer.Base;
using ScreenShot.Util;

namespace ScreenShot
{
    public sealed partial class Captor : Form
    {
        private readonly Image _baseImage;

        private Point _cursorLocation = Point.Empty;

        private bool _isExploring = false;
        private readonly ExploreLayer _exploreLayer;

        private bool _isCapturing = false;
        private readonly CaptureLayer _captureLayer;

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
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this._baseImage = ImageUtil.GetScreenImage();
            this.BackgroundImage = this._baseImage;
            // Build Layers
            this._captureLayer = new CaptureLayer(this);
            this._exploreLayer = new LineExploreLayer(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this._isExploring = true;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this._isCapturing = true;
            this._isExploring = false;
            this._captureLayer.Start = e.Location;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Rectangle capture = this._captureLayer.Capture;
            if (capture.Width > 0 && capture.Height > 0)
            {
                this._isCapturing = false;
                this._isExploring = false;
                this.Hide();
                using (FormEdit formEdit = new FormEdit(ImageUtil.GetTargetImage(this._baseImage, capture)))
                {
                    formEdit.ShowDialog();
                    this.Close();
                }
            }

            this._isExploring = true;
            this._isCapturing = false;
        }


        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            this._cursorLocation = e.Location;
            this.InvalidateLayers();
        }

        private void InvalidateLayers()
        {
            if (this._isExploring)
            {
                this._exploreLayer.Invalidate(this._cursorLocation);
            }

            if (this._isCapturing)
            {
                this._captureLayer.Invalidate(this._cursorLocation);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (this._isExploring)
            {
                this._exploreLayer?.OnPaint(this._cursorLocation, e.Graphics);
            }

            if (this._isCapturing)
            {
                this._captureLayer?.OnPaint(this._cursorLocation, e.Graphics);
            }
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ImageAcquiredEventArgs
    {
        public byte[] ImageData { get; }

        public ImageAcquiredEventArgs(byte[] imageData)
        {
            ImageData = imageData;
        }
    }
}