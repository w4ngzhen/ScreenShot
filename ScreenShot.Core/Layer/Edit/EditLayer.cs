using System.Drawing;

namespace ScreenShot.Core.Layer.Edit
{
    public abstract class EditLayer : LayerBase
    {
        public bool Editing { get; set; }

        protected abstract Rectangle Body { get; }

        protected EditLayer(Size size) : base(size)
        {
            this.Editing = true;
        }

        public override void OnPaint(Graphics g)
        {
            if (this.Editing)
            {
                this.OnEditingPaint(g);
            }
            else
            {
                this.OnHistoryPaint(g);
            }
        }

        public virtual void OnEditingPaint(Graphics g)
        {

        }

        public virtual void OnHistoryPaint(Graphics g)
        {

        }
    }
}