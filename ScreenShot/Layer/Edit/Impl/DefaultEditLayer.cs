using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenShot.Layer.Edit.Impl
{
    public class DefaultEditLayer : EditLayer
    {
        protected override Rectangle Body => throw new NotImplementedException();

        private readonly Rectangle _capture;

        public DefaultEditLayer(Size size, Rectangle capture) : base(size)
        {
            this._capture = capture;
        }


        public override void OnPaint(Graphics g)
        {
            Size leftSize = new Size(this._capture.X, this.Size.Height);
            Size rightSize = new Size(this.Size.Width - this._capture.Width - leftSize.Width, this.Size.Height);
            Size upSize = new Size(this._capture.Width, this._capture.Y);
            Size downSize = new Size(this._capture.Width, this.Size.Height - this._capture.Height - this._capture.Y);

            Rectangle left = new Rectangle(Point.Empty, leftSize);
            Rectangle right = new Rectangle(new Point(this._capture.X + this._capture.Width, 0), rightSize);
            Rectangle up = new Rectangle(new Point(this._capture.X, 0), upSize);
            Rectangle down = new Rectangle(new Point(this._capture.X, this._capture.Y + this._capture.Height), downSize);

            SolidBrush brush = new SolidBrush(Color.FromArgb(88, Color.Gray));
            g.FillRectangle(brush, left);
            g.FillRectangle(brush, right);
            g.FillRectangle(brush, up);
            g.FillRectangle(brush, down);
        }

    }
}