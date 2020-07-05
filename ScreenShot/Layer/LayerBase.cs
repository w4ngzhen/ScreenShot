using System.Drawing;
using System.Windows.Forms;

namespace ScreenShot.Layer
{
    public abstract class LayerBase
    {
        public Point InitCursor { get; set; }

        public Point CurrentCursor { get; set; }

        public Size Size { get; }

        protected LayerBase(Size size)
        {
            this.Size = size;
        }

        public virtual void OnPaint(Graphics g)
        {
            return;
        }

        public virtual void Invalidate(Control control)
        {
            control.Invalidate();
        }
    }
}