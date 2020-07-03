using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenShot.Layer.Base
{
    public class CaptureLayer : LayerBase
    {
        private Rectangle _capture;

        public Rectangle Capture => _capture;

        public Point Start
        {
            get => Capture.Location;
            set
            {
                this._capture.Location = value;
                this._capture.Size = Size.Empty;
            }
        }

        private readonly CaptureConfig _captureConfig;

        public CaptureLayer(Control ctrl) : base(ctrl)
        {
            this._captureConfig = new CaptureConfig();
        }

        public override void OnPaint(Point cursor, Graphics g)
        {
            Point start = this.Capture.Location;
            int width = Math.Abs(start.X - cursor.X);
            int height = Math.Abs(start.Y - cursor.Y);
            this._capture = new Rectangle(start.X, start.Y, width, height);
            g.DrawRectangle(this._captureConfig.RedPen, this._capture);
            this.PaintInfo(cursor, this._capture.Size, g);
        }

        private void PaintInfo(Point cursor, Size captureSize, Graphics g)
        {
            string info = captureSize.Width + " x "+ captureSize.Height;
            // 计算指定字体下字符串的高度和宽度（包含padding）
            SizeF sizeF = g.MeasureString(info, this._captureConfig.InfoFont);
            Point infoStart = new Point(cursor.X + 10, cursor.Y - (int) sizeF.Height);
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