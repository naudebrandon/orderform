namespace Order
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.txtAccessCode = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cobUsername = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtAccessCode
            // 
            this.txtAccessCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccessCode.Location = new System.Drawing.Point(12, 65);
            this.txtAccessCode.Name = "txtAccessCode";
            this.txtAccessCode.Size = new System.Drawing.Size(253, 31);
            this.txtAccessCode.TabIndex = 1;
            this.txtAccessCode.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(38, 110);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(80, 35);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "&Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(137, 110);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 35);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cobUsername
            // 
            this.cobUsername.FormattingEnabled = true;
            this.cobUsername.Items.AddRange(new object[] {
            "Admin",
            "Operator 1",
            "Operator 2"});
            this.cobUsername.Location = new System.Drawing.Point(12, 29);
            this.cobUsername.Name = "cobUsername";
            this.cobUsername.Size = new System.Drawing.Size(250, 21);
            this.cobUsername.TabIndex = 4;
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(274, 157);
            this.Controls.Add(this.cobUsername);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtAccessCode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Access Restriction";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAccessCode;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cobUsername;
    }
}