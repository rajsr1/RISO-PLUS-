namespace RISO
{
    partial class Login
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
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.lblerrorpass = new System.Windows.Forms.Label();
            this.lblerroruname = new System.Windows.Forms.Label();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.txtuname = new System.Windows.Forms.TextBox();
            this.btnlogin = new System.Windows.Forms.Label();
            this.lblpass = new System.Windows.Forms.Label();
            this.lbluname = new System.Windows.Forms.Label();
            this.lblhead = new System.Windows.Forms.Label();
            this.pnlLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLogin
            // 
            this.pnlLogin.BackgroundImage = global::RISO.Properties.Resources.Login;
            this.pnlLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlLogin.Controls.Add(this.lblerrorpass);
            this.pnlLogin.Controls.Add(this.lblerroruname);
            this.pnlLogin.Controls.Add(this.txtpass);
            this.pnlLogin.Controls.Add(this.txtuname);
            this.pnlLogin.Controls.Add(this.btnlogin);
            this.pnlLogin.Controls.Add(this.lblpass);
            this.pnlLogin.Controls.Add(this.lbluname);
            this.pnlLogin.Controls.Add(this.lblhead);
            this.pnlLogin.Location = new System.Drawing.Point(0, 1);
            this.pnlLogin.Margin = new System.Windows.Forms.Padding(4);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(1073, 560);
            this.pnlLogin.TabIndex = 0;
            this.pnlLogin.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlLogin_Paint);
            // 
            // lblerrorpass
            // 
            this.lblerrorpass.AutoSize = true;
            this.lblerrorpass.ForeColor = System.Drawing.Color.Red;
            this.lblerrorpass.Location = new System.Drawing.Point(288, 252);
            this.lblerrorpass.Name = "lblerrorpass";
            this.lblerrorpass.Size = new System.Drawing.Size(116, 16);
            this.lblerrorpass.TabIndex = 17;
            this.lblerrorpass.Text = "please enter Pass";
            this.lblerrorpass.Visible = false;
            // 
            // lblerroruname
            // 
            this.lblerroruname.AutoSize = true;
            this.lblerroruname.BackColor = System.Drawing.SystemColors.Control;
            this.lblerroruname.ForeColor = System.Drawing.Color.Red;
            this.lblerroruname.Location = new System.Drawing.Point(288, 191);
            this.lblerroruname.Name = "lblerroruname";
            this.lblerroruname.Size = new System.Drawing.Size(129, 16);
            this.lblerroruname.TabIndex = 16;
            this.lblerroruname.Text = "please enter Uname";
            this.lblerroruname.Visible = false;
            // 
            // txtpass
            // 
            this.txtpass.Location = new System.Drawing.Point(279, 225);
            this.txtpass.Name = "txtpass";
            this.txtpass.PasswordChar = '*';
            this.txtpass.Size = new System.Drawing.Size(359, 22);
            this.txtpass.TabIndex = 15;
            // 
            // txtuname
            // 
            this.txtuname.Location = new System.Drawing.Point(279, 164);
            this.txtuname.Name = "txtuname";
            this.txtuname.Size = new System.Drawing.Size(320, 22);
            this.txtuname.TabIndex = 14;
            // 
            // btnlogin
            // 
            this.btnlogin.AutoSize = true;
            this.btnlogin.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnlogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogin.Location = new System.Drawing.Point(525, 271);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(104, 36);
            this.btnlogin.TabIndex = 13;
            this.btnlogin.Text = "Log in";
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // lblpass
            // 
            this.lblpass.AutoSize = true;
            this.lblpass.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblpass.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpass.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblpass.Location = new System.Drawing.Point(171, 227);
            this.lblpass.Name = "lblpass";
            this.lblpass.Size = new System.Drawing.Size(94, 21);
            this.lblpass.TabIndex = 11;
            this.lblpass.Text = "Password:";
            // 
            // lbluname
            // 
            this.lbluname.AutoSize = true;
            this.lbluname.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbluname.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbluname.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbluname.Location = new System.Drawing.Point(179, 166);
            this.lbluname.Name = "lbluname";
            this.lbluname.Size = new System.Drawing.Size(87, 21);
            this.lbluname.TabIndex = 10;
            this.lbluname.Text = "Usernme:";
            // 
            // lblhead
            // 
            this.lblhead.AutoSize = true;
            this.lblhead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblhead.Font = new System.Drawing.Font("Arial Black", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblhead.Location = new System.Drawing.Point(255, 24);
            this.lblhead.Name = "lblhead";
            this.lblhead.Size = new System.Drawing.Size(580, 113);
            this.lblhead.TabIndex = 9;
            this.lblhead.Text = "RISO PLUS+";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.pnlLogin);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Label lblerrorpass;
        private System.Windows.Forms.Label lblerroruname;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.TextBox txtuname;
        private System.Windows.Forms.Label btnlogin;
        private System.Windows.Forms.Label lblpass;
        private System.Windows.Forms.Label lbluname;
        private System.Windows.Forms.Label lblhead;
    }
}