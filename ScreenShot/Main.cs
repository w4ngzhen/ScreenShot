using System;
using System.Windows.Forms;

namespace ScreenShot
{
    public partial class Main : Form
    {
        private Captor _captor;

        public Main()
        {
            InitializeComponent();
            this.Init();
        }

        private void Init()
        {
            this.WindowState = FormWindowState.Minimized;
            this._captor = new Captor();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this._captor.ShowDialog();
        }
    }
}
