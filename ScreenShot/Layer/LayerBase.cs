using System.Drawing;
using System.Windows.Forms;

namespace ScreenShot.Layer
{
    public abstract class LayerBase
    {
        protected readonly Control Ctrl;

        protected Size Size => this.Ctrl.Size;

        protected LayerBase(Control ctrl)
        {
            Ctrl = ctrl;
        }

        public virtual void OnPaint(Point cursor, Graphics g)
        {
            return;
        }

        public virtual void Invalidate(Point cursor)
        {
            this.Ctrl.Invalidate();
        }
    }
}