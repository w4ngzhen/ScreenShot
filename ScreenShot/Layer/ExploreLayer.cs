using System.Drawing;
using System.Windows.Forms;

namespace ScreenShot.Layer
{
    public abstract class ExploreLayer : LayerBase
    {
        protected ExploreLayer(Control ctrl) : base(ctrl) { }
    }

    public class MaskExploreLayer : ExploreLayer
    {
        public MaskExploreLayer(Control ctrl) : base(ctrl) { }

        public override void OnPaint(Point cursor, Graphics g)
        {
            SolidBrush brush = new SolidBrush(Color.FromArgb(88, Color.Gray));
            g.FillRectangle(brush, new Rectangle(0, 0, this.Size.Width, this.Size.Height));
        }

        public override void Invalidate(Point cursor)
        {
            this.Ctrl.Invalidate();
        }
    }

    public class LineExploreLayer : ExploreLayer
    {
        public LineExploreLayer(Control ctrl) : base(ctrl)
        {
        }

        public override void OnPaint(Point cursor, Graphics g)
        {
            Pen pen = new Pen(new SolidBrush(Color.DeepSkyBlue));
            g.DrawLine(pen, new Point(cursor.X, 0), new Point(cursor.X, this.Size.Height));
            g.DrawLine(pen, new Point(0, cursor.Y), new Point(this.Size.Width, cursor.Y));
        }

        public override void Invalidate(Point cursor)
        {
            this.Ctrl.Invalidate();
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