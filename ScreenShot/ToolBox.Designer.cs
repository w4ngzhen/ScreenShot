namespace ScreenShot
{
    partial class ToolBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolBox));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtnOk = new System.Windows.Forms.ToolStripButton();
            this.BtnCancel = new System.Windows.Forms.ToolStripButton();
            this.BtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnMosaic = new System.Windows.Forms.ToolStripButton();
            this.BtnText = new System.Windows.Forms.ToolStripButton();
            this.BtnPen = new System.Windows.Forms.ToolStripButton();
            this.BtnArrow = new System.Windows.Forms.ToolStripButton();
            this.BtnEllipse = new System.Windows.Forms.ToolStripButton();
            this.BtnRect = new System.Windows.Forms.ToolStripButton();
            this.BtnUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnOk,
            this.BtnCancel,
            this.BtnSave,
            this.toolStripSeparator1,
            this.BtnUndo,
            this.BtnMosaic,
            this.BtnText,
            this.BtnPen,
            this.BtnArrow,
            this.BtnEllipse,
            this.BtnRect});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(337, 28);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BtnOk
            // 
            this.BtnOk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnOk.Image = ((System.Drawing.Image)(resources.GetObject("BtnOk.Image")));
            this.BtnOk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnOk.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(23, 25);
            this.BtnOk.Text = "toolStripButton1";
            this.BtnOk.ToolTipText = "确定";
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnCancel.Image = ((System.Drawing.Image)(resources.GetObject("BtnCancel.Image")));
            this.BtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(23, 25);
            this.BtnCancel.Text = "toolStripButton2";
            this.BtnCancel.ToolTipText = "取消";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnSave.Image = ((System.Drawing.Image)(resources.GetObject("BtnSave.Image")));
            this.BtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSave.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(23, 25);
            this.BtnSave.Text = "toolStripButton3";
            this.BtnSave.ToolTipText = "保存";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // BtnMosaic
            // 
            this.BtnMosaic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnMosaic.Image = ((System.Drawing.Image)(resources.GetObject("BtnMosaic.Image")));
            this.BtnMosaic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnMosaic.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.BtnMosaic.Name = "BtnMosaic";
            this.BtnMosaic.Size = new System.Drawing.Size(23, 25);
            this.BtnMosaic.Text = "toolStripButton4";
            this.BtnMosaic.ToolTipText = "马赛克";
            this.BtnMosaic.Click += new System.EventHandler(this.BtnMosaic_Click);
            // 
            // BtnText
            // 
            this.BtnText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnText.Image = ((System.Drawing.Image)(resources.GetObject("BtnText.Image")));
            this.BtnText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnText.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.BtnText.Name = "BtnText";
            this.BtnText.Size = new System.Drawing.Size(23, 25);
            this.BtnText.Text = "马赛克";
            this.BtnText.ToolTipText = "文字";
            this.BtnText.Click += new System.EventHandler(this.BtnText_Click);
            // 
            // BtnPen
            // 
            this.BtnPen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnPen.Image = ((System.Drawing.Image)(resources.GetObject("BtnPen.Image")));
            this.BtnPen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnPen.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.BtnPen.Name = "BtnPen";
            this.BtnPen.Size = new System.Drawing.Size(23, 25);
            this.BtnPen.Text = "toolStripButton6";
            this.BtnPen.ToolTipText = "画笔";
            this.BtnPen.Click += new System.EventHandler(this.BtnPen_Click);
            // 
            // BtnArrow
            // 
            this.BtnArrow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnArrow.Image = ((System.Drawing.Image)(resources.GetObject("BtnArrow.Image")));
            this.BtnArrow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnArrow.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.BtnArrow.Name = "BtnArrow";
            this.BtnArrow.Size = new System.Drawing.Size(23, 25);
            this.BtnArrow.Text = "toolStripButton7";
            this.BtnArrow.ToolTipText = "箭头";
            this.BtnArrow.Click += new System.EventHandler(this.BtnArrow_Click);
            // 
            // BtnEllipse
            // 
            this.BtnEllipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnEllipse.Image = ((System.Drawing.Image)(resources.GetObject("BtnEllipse.Image")));
            this.BtnEllipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnEllipse.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.BtnEllipse.Name = "BtnEllipse";
            this.BtnEllipse.Size = new System.Drawing.Size(23, 25);
            this.BtnEllipse.Text = "toolStripButton8";
            this.BtnEllipse.ToolTipText = "椭圆";
            this.BtnEllipse.Click += new System.EventHandler(this.BtnEllipse_Click);
            // 
            // BtnRect
            // 
            this.BtnRect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnRect.Image = ((System.Drawing.Image)(resources.GetObject("BtnRect.Image")));
            this.BtnRect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnRect.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.BtnRect.Name = "BtnRect";
            this.BtnRect.Size = new System.Drawing.Size(23, 25);
            this.BtnRect.Text = "toolStripButton9";
            this.BtnRect.ToolTipText = "方框";
            this.BtnRect.Click += new System.EventHandler(this.BtnRect_Click);
            // 
            // BtnUndo
            // 
            this.BtnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnUndo.Image = ((System.Drawing.Image)(resources.GetObject("BtnUndo.Image")));
            this.BtnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnUndo.Name = "BtnUndo";
            this.BtnUndo.Size = new System.Drawing.Size(23, 25);
            this.BtnUndo.Text = "toolStripButton2";
            this.BtnUndo.ToolTipText = "撤销";
            this.BtnUndo.Click += new System.EventHandler(this.BtnUndo_Click);
            // 
            // ToolBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip1);
            this.Name = "ToolBox";
            this.Size = new System.Drawing.Size(337, 28);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BtnOk;
        private System.Windows.Forms.ToolStripButton BtnCancel;
        private System.Windows.Forms.ToolStripButton BtnSave;
        private System.Windows.Forms.ToolStripButton BtnMosaic;
        private System.Windows.Forms.ToolStripButton BtnText;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BtnPen;
        private System.Windows.Forms.ToolStripButton BtnArrow;
        private System.Windows.Forms.ToolStripButton BtnEllipse;
        private System.Windows.Forms.ToolStripButton BtnRect;
        private System.Windows.Forms.ToolStripButton BtnUndo;
    }
}
