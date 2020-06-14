namespace DXApplication1
{
    partial class login
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.edtpw = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.edtuser = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnlogin = new DevExpress.XtraEditors.SimpleButton();
            this.retype = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.edtpw.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtuser.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(107, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(198, 22);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Đăng nhập vào hệ thống";
            // 
            // edtpw
            // 
            this.edtpw.EnterMoveNextControl = true;
            this.edtpw.Location = new System.Drawing.Point(131, 97);
            this.edtpw.Name = "edtpw";
            // 
            // 
            // 
            this.edtpw.Properties.UseSystemPasswordChar = true;
            this.edtpw.Size = new System.Drawing.Size(174, 20);
            this.edtpw.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(35, 100);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Mật khẩu:";
            // 
            // edtuser
            // 
            this.edtuser.Location = new System.Drawing.Point(131, 61);
            this.edtuser.Name = "edtuser";
            this.edtuser.Size = new System.Drawing.Size(174, 20);
            this.edtuser.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(35, 64);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(76, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Tên đăng nhập:";
            // 
            // btnlogin
            // 
            this.btnlogin.Location = new System.Drawing.Point(131, 139);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.TabIndex = 3;
            this.btnlogin.Text = "Đăng nhập";
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // retype
            // 
            this.retype.Location = new System.Drawing.Point(230, 139);
            this.retype.Name = "retype";
            this.retype.TabIndex = 4;
            this.retype.Text = "Nhập lại";
            this.retype.Click += new System.EventHandler(this.retype_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 194);
            this.Controls.Add(this.retype);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.edtuser);
            this.Controls.Add(this.edtpw);
            this.Controls.Add(this.labelControl1);
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "login";
            ((System.ComponentModel.ISupportInitialize)(this.edtpw.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtuser.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit edtpw;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit edtuser;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnlogin;
        private DevExpress.XtraEditors.SimpleButton retype;
    }
}