using System.Drawing;
using System.Windows.Forms;

namespace ScreenShot.Core.Layer
{
    public abstract class LayerBase
    {
        public Point InitLocation { get; set; }

        public Point CurrentLocation { get; set; }

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