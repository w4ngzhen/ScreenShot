﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenShot.Layer.Base
{
    public class CaptureLayer : LayerBase
    {
        private Rectangle _capture;

        public Rectangle Capture => _capture;

        private readonly CaptureConfig _captureConfig;

        public CaptureLayer(Size size) : base(size)
        {
            this._captureConfig = new CaptureConfig();
        }

        public override void OnPaint(Graphics g)
        {
            Point start = this.InitCursor;
            int width = Math.Abs(start.X - this.CurrentCursor.X);
            int height = Math.Abs(start.Y - this.CurrentCursor.Y);
            this._capture = new Rectangle(start.X, start.Y, width, height);
            g.DrawRectangle(this._captureConfig.RedPen, this._capture);
            this.PaintInfo(g);
        }

        private void PaintInfo(Graphics g)
        {
            string info = this._capture.Width + " x "+ this._capture.Height;
            // 计算指定字体下字符串的高度和宽度（包含padding）
            SizeF sizeF = g.MeasureString(info, this._captureConfig.InfoFont);
            Point infoStart = new Point(this.CurrentCursor.X + 10, this.CurrentCursor.Y - (int) sizeF.Height);
            RectangleF infoRect = new RectangleF(infoStart, sizeF);
            // 绘制背景
            g.FillRectangle(this._captureConfig.YellowBrush, infoRect);
            // 绘制文字
            g.DrawString(info, 
                this._captureConfig.InfoFont, 
                this._captureConfig.BlackBrush, 
                infoRect);
        }
    }

    public class CaptureConfig
    {
        public Pen RedPen { get; private set; }

        public Pen BlackPen { get; private set; }

        public SolidBrush BlackBrush { get; private set; }

        public Brush YellowBrush { get; private set; }

        public Font InfoFont { get; set; }

        public CaptureConfig()
        {
            this.Init();
        }

        public void Init()
        {
            this.RedPen = new Pen(Color.Red);
            this.BlackPen = new Pen(Color.Black);
            this.BlackBrush = new SolidBrush(Color.Black);
            this.YellowBrush = new SolidBrush(Color.LightYellow);
            this.InfoFont = new Font("Microsoft YaHei", 8F, FontStyle.Regular);
        }
    }
}