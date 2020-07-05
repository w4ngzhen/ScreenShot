using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScreenShot
{
    public partial class ToolBox : UserControl
    {
        public ToolBox()
        {
            InitializeComponent();
        }

        public event EventHandler<ToolChosenEventArgs> ToolChosen; 

        private void BtnOk_Click(object sender, EventArgs e)
        {
            OnToolChosen(new ToolChosenEventArgs(){ToolItem = ToolItem.Ok});
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            OnToolChosen(new ToolChosenEventArgs() { ToolItem = ToolItem.Cancel });
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            OnToolChosen(new ToolChosenEventArgs() { ToolItem = ToolItem.Save });
        }

        private void BtnRect_Click(object sender, EventArgs e)
        {
            OnToolChosen(new ToolChosenEventArgs() { ToolItem = ToolItem.Rect });
        }

        private void BtnEllipse_Click(object sender, EventArgs e)
        {
            OnToolChosen(new ToolChosenEventArgs() { ToolItem = ToolItem.Ellipse });
        }

        private void BtnArrow_Click(object sender, EventArgs e)
        {
            OnToolChosen(new ToolChosenEventArgs() { ToolItem = ToolItem.Arrow });
        }

        private void BtnPen_Click(object sender, EventArgs e)
        {
            OnToolChosen(new ToolChosenEventArgs() { ToolItem = ToolItem.Pen });
        }

        private void BtnText_Click(object sender, EventArgs e)
        {
            OnToolChosen(new ToolChosenEventArgs() { ToolItem = ToolItem.Text });
        }

        private void BtnMosaic_Click(object sender, EventArgs e)
        {
            OnToolChosen(new ToolChosenEventArgs() { ToolItem = ToolItem.Mosaic });
        }

        protected virtual void OnToolChosen(ToolChosenEventArgs e)
        {
            ToolChosen?.Invoke(this, e);
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            OnToolChosen(new ToolChosenEventArgs() { ToolItem = ToolItem.Undo });
        }
    }

    public enum ToolItem
    {
        Ok, Cancel, Save, Rect, Ellipse, Arrow, Pen, Text, Mosaic, Undo
    }

    public class ToolChosenEventArgs : EventArgs
    {
        public ToolItem ToolItem { get; set; }
    }
}
