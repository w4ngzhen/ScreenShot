using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScreenShot
{
    public partial class FormEdit : Form
    {
        private Image _baseImage;
        public FormEdit()
        {
            InitializeComponent();
        }

        public FormEdit(Image baseImage) : this()
        {
            this._baseImage = baseImage;
            this.pictureBox1.Size = this._baseImage.Size;
            this.pictureBox1.Location = new Point(5, 5);
        }
    }
}
