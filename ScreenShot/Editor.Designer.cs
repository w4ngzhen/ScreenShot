namespace ScreenShot
{
    partial class Editor
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._toolBox = new ScreenShot.ToolBox();
            this.SuspendLayout();
            // 
            // _toolBox
            // 
            this._toolBox.Location = new System.Drawing.Point(25, 133);
            this._toolBox.Name = "_toolBox";
            this._toolBox.Size = new System.Drawing.Size(285, 28);
            this._toolBox.TabIndex = 0;
            this._toolBox.TabStop = false;
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 254);
            this.Controls.Add(this._toolBox);
            this.Name = "Editor";
            this.Text = "Editor";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Editor_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private ToolBox _toolBox;
    }
}