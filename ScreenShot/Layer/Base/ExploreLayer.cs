using System.Drawing;
using System.Windows.Forms;

namespace ScreenShot.Layer.Base
{
    public abstract class ExploreLayer : LayerBase
    {
        protected ExploreLayer(Size size) : base(size)
        {
        }
    }

    public class MaskExploreLayer : ExploreLayer
    {
        public MaskExploreLayer(Size size) : base(size)
        {
        }
        public override void OnPaint(Graphics g)
        {
            SolidBrush brush = new SolidBrush(Color.FromArgb(88, Color.Gray));
            g.FillRectangle(brush, new Rectangle(0, 0, this.Size.Width, this.Size.Height));
        }
    }

    public class LineExploreLayer : ExploreLayer
    {
        public LineExploreLayer(Size size) : base(size)
        {
        }

        public override void OnPaint(Graphics g)
        {
            Pen pen = new Pen(new SolidBrush(Color.DeepSkyBlue));
            g.DrawLine(pen, new Point(this.CurrentCursor.X, 0), new Point(this.CurrentCursor.X, this.Size.Height));
            g.DrawLine(pen, new Point(0, this.CurrentCursor.Y), new Point(this.Size.Width, this.CurrentCursor.Y));
        }

        public override void Invalidate(Control control)
        {
            base.Invalidate(control);
//            const int areaWidth = 1000;
//            const int offset = areaWidth / 2;
//            Rectangle verticalRect = new Rectangle(new Point(cursor.X, 0), new Size(areaWidth, this.Size.Height));
//            verticalRect.Offset(-offset, 0);
//            Rectangle horizontalRect = new Rectangle(new Point(0, cursor.Y), new Size(this.Size.Width, areaWidth));
//            horizontalRect.Offset(0, -offset);
//            this.Ctrl.Invalidate(verticalRect);
//            this.Ctrl.Invalidate(horizontalRect);
        }
    }
}