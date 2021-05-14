
namespace QuanLyBanHang
{
    partial class UserControl1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl1));
            this.numericSL = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.lbSP = new System.Windows.Forms.Label();
            this.btnRemove = new Guna.UI2.WinForms.Guna2Button();
            this.lbPrice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericSL)).BeginInit();
            this.SuspendLayout();
            // 
            // numericSL
            // 
            this.numericSL.BackColor = System.Drawing.Color.Transparent;
            this.numericSL.BorderRadius = 5;
            this.numericSL.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numericSL.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.numericSL.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.numericSL.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.numericSL.DisabledState.Parent = this.numericSL;
            this.numericSL.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.numericSL.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.numericSL.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.numericSL.FocusedState.Parent = this.numericSL;
            this.numericSL.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericSL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericSL.Location = new System.Drawing.Point(317, 12);
            this.numericSL.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numericSL.Name = "numericSL";
            this.numericSL.ShadowDecoration.Parent = this.numericSL;
            this.numericSL.Size = new System.Drawing.Size(121, 41);
            this.numericSL.TabIndex = 2;
            this.numericSL.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(128)))), ((int)(((byte)(69)))));
            // 
            // lbSP
            // 
            this.lbSP.AutoSize = true;
            this.lbSP.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSP.Location = new System.Drawing.Point(90, 8);
            this.lbSP.Name = "lbSP";
            this.lbSP.Size = new System.Drawing.Size(119, 23);
            this.lbSP.TabIndex = 1;
            this.lbSP.Text = "Tên sản phẩm";
            // 
            // btnRemove
            // 
            this.btnRemove.CheckedState.Parent = this.btnRemove;
            this.btnRemove.CustomImages.Parent = this.btnRemove;
            this.btnRemove.FillColor = System.Drawing.Color.Transparent;
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRemove.ForeColor = System.Drawing.Color.White;
            this.btnRemove.HoverState.Parent = this.btnRemove;
            this.btnRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnRemove.Image")));
            this.btnRemove.Location = new System.Drawing.Point(6, 8);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.ShadowDecoration.Parent = this.btnRemove;
            this.btnRemove.Size = new System.Drawing.Size(69, 46);
            this.btnRemove.TabIndex = 0;
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrice.Location = new System.Drawing.Point(90, 31);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(71, 23);
            this.lbPrice.TabIndex = 3;
            this.lbPrice.Text = "Giá bán";
            this.lbPrice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbPrice);
            this.Controls.Add(this.numericSL);
            this.Controls.Add(this.lbSP);
            this.Controls.Add(this.btnRemove);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(445, 70);
            ((System.ComponentModel.ISupportInitialize)(this.numericSL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2NumericUpDown numericSL;
        private System.Windows.Forms.Label lbSP;
        private Guna.UI2.WinForms.Guna2Button btnRemove;
        private System.Windows.Forms.Label lbPrice;
    }
}
