using System;
using System.Drawing;

namespace ScreenShot.Core.Layer.Edit.Impl
{
    public class RectEditLayer : EditLayer
    {
        private Rectangle _capture;

        public Rectangle Capture => _capture;

        public RectEditLayer(Size size) : base(size)
        {
        }

        protected override Rectangle Body { get; }

        public override void OnEditingPaint(Graphics g)
        {
            Point start = this.InitLocation;
            int width = Math.Abs(start.X - this.CurrentLocation.X);
            int height = Math.Abs(start.Y - this.CurrentLocation.Y);
            this._capture = new Rectangle(start.X, start.Y, width, height);
            g.DrawRectangle(new Pen(Color.Red), this.Capture);
        }

        public override void OnHistoryPaint(Graphics g)
        {
            g.DrawRectangle(new Pen(Color.Red), this.Capture);
        }
    }
}