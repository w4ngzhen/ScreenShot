using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenShot.Layer.Impl
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

        public CaptureLayer(Control ctrl) : base(ctrl) { }

        public override void OnPaint(Point cursor, Graphics g)
        {
            Point start = this.Capture.Location;
            int width = Math.Abs(start.X - cursor.X);
            int height = Math.Abs(start.Y - cursor.Y);
            this._capture = new Rectangle(start.X, start.Y, width, height);
            Pen pen = new Pen(Color.Red);
            g.DrawRectangle(pen, this._capture);
        }
    }
}