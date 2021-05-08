
namespace QuanLyBanHang
{
    partial class UserControl3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl3));
            this.ptbox = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptbox)).BeginInit();
            this.SuspendLayout();
            // 
            // ptbox
            // 
            this.ptbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbox.Image = ((System.Drawing.Image)(resources.GetObject("ptbox.Image")));
            this.ptbox.Location = new System.Drawing.Point(0, 0);
            this.ptbox.Name = "ptbox";
            this.ptbox.ShadowDecoration.Parent = this.ptbox;
            this.ptbox.Size = new System.Drawing.Size(150, 157);
            this.ptbox.TabIndex = 0;
            this.ptbox.TabStop = false;
            // 
            // UserControl3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ptbox);
            this.Name = "UserControl3";
            this.Size = new System.Drawing.Size(150, 157);
            ((System.ComponentModel.ISupportInitialize)(this.ptbox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox ptbox;
    }
}
