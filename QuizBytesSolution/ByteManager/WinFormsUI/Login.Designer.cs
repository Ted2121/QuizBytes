namespace ByteManager.WinFormsUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.LoginIconPictureBox = new System.Windows.Forms.PictureBox();
            this.LoginText = new System.Windows.Forms.Label();
            this.usernameOrangePanel = new System.Windows.Forms.Panel();
            this.passwordOrangePanel = new System.Windows.Forms.Panel();
            this.LoginButton = new System.Windows.Forms.Button();
            this.passwordPictureBox = new System.Windows.Forms.PictureBox();
            this.usernamePictureBox = new System.Windows.Forms.PictureBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.exitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LoginIconPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usernamePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // LoginIconPictureBox
            // 
            this.LoginIconPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LoginIconPictureBox.Image = global::ByteManager.Properties.Resources.Logo_Bytecoin_png___Copy;
            this.LoginIconPictureBox.Location = new System.Drawing.Point(41, 0);
            this.LoginIconPictureBox.Name = "LoginIconPictureBox";
            this.LoginIconPictureBox.Size = new System.Drawing.Size(228, 230);
            this.LoginIconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LoginIconPictureBox.TabIndex = 0;
            this.LoginIconPictureBox.TabStop = false;
            // 
            // LoginText
            // 
            this.LoginText.AutoSize = true;
            this.LoginText.Font = new System.Drawing.Font("Arial Black", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LoginText.Location = new System.Drawing.Point(114, 233);
            this.LoginText.Name = "LoginText";
            this.LoginText.Size = new System.Drawing.Size(104, 41);
            this.LoginText.TabIndex = 1;
            this.LoginText.Text = "Login";
            // 
            // usernameOrangePanel
            // 
            this.usernameOrangePanel.BackColor = System.Drawing.Color.DarkOrange;
            this.usernameOrangePanel.Location = new System.Drawing.Point(42, 289);
            this.usernameOrangePanel.Margin = new System.Windows.Forms.Padding(0);
            this.usernameOrangePanel.Name = "usernameOrangePanel";
            this.usernameOrangePanel.Size = new System.Drawing.Size(243, 5);
            this.usernameOrangePanel.TabIndex = 2;
            // 
            // passwordOrangePanel
            // 
            this.passwordOrangePanel.BackColor = System.Drawing.Color.DarkOrange;
            this.passwordOrangePanel.Location = new System.Drawing.Point(42, 337);
            this.passwordOrangePanel.Margin = new System.Windows.Forms.Padding(0);
            this.passwordOrangePanel.Name = "passwordOrangePanel";
            this.passwordOrangePanel.Size = new System.Drawing.Size(243, 5);
            this.passwordOrangePanel.TabIndex = 3;
            // 
            // LoginButton
            // 
            this.LoginButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LoginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.LoginButton.ForeColor = System.Drawing.Color.DarkOrange;
            this.LoginButton.Location = new System.Drawing.Point(13, 368);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(99, 46);
            this.LoginButton.TabIndex = 4;
            this.LoginButton.Text = "Login";
            this.LoginButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // passwordPictureBox
            // 
            this.passwordPictureBox.Image = global::ByteManager.Properties.Resources.passwordIcon;
            this.passwordPictureBox.Location = new System.Drawing.Point(13, 313);
            this.passwordPictureBox.Name = "passwordPictureBox";
            this.passwordPictureBox.Size = new System.Drawing.Size(26, 29);
            this.passwordPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.passwordPictureBox.TabIndex = 5;
            this.passwordPictureBox.TabStop = false;
            // 
            // usernamePictureBox
            // 
            this.usernamePictureBox.Image = global::ByteManager.Properties.Resources.login_head;
            this.usernamePictureBox.Location = new System.Drawing.Point(13, 265);
            this.usernamePictureBox.Name = "usernamePictureBox";
            this.usernamePictureBox.Size = new System.Drawing.Size(26, 29);
            this.usernamePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.usernamePictureBox.TabIndex = 6;
            this.usernamePictureBox.TabStop = false;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usernameTextBox.Location = new System.Drawing.Point(42, 266);
            this.usernameTextBox.Multiline = true;
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(243, 17);
            this.usernameTextBox.TabIndex = 7;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordTextBox.Location = new System.Drawing.Point(42, 313);
            this.passwordTextBox.Multiline = true;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(243, 17);
            this.passwordTextBox.TabIndex = 8;
            // 
            // exitButton
            // 
            this.exitButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.exitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.exitButton.ForeColor = System.Drawing.Color.DarkOrange;
            this.exitButton.Location = new System.Drawing.Point(186, 368);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(99, 46);
            this.exitButton.TabIndex = 9;
            this.exitButton.Text = "Exit";
            this.exitButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(310, 440);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.usernamePictureBox);
            this.Controls.Add(this.passwordPictureBox);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.passwordOrangePanel);
            this.Controls.Add(this.usernameOrangePanel);
            this.Controls.Add(this.LoginText);
            this.Controls.Add(this.LoginIconPictureBox);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LoginIconPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usernamePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox LoginIconPictureBox;
        private Label LoginText;
        private Panel usernameOrangePanel;
        private Panel passwordOrangePanel;
        private Button LoginButton;
        private PictureBox passwordPictureBox;
        private PictureBox usernamePictureBox;
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Button exitButton;
    }
}