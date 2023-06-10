namespace Render3D.UserInterface
{
    partial class SignIn
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblExceptionError = new System.Windows.Forms.Label();
            this.btnGoBack = new System.Windows.Forms.Button();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.lblPasswordsDontMatch = new System.Windows.Forms.Label();
            this.lblWrongPasswordMessage = new System.Windows.Forms.Label();
            this.lblWrongUsernameMessage = new System.Windows.Forms.Label();
            this.txtClientRepeatedPassword = new System.Windows.Forms.TextBox();
            this.lblClientRepeatedPassword = new System.Windows.Forms.Label();
            this.txtClientPassword = new System.Windows.Forms.TextBox();
            this.lblClientPassword = new System.Windows.Forms.Label();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.lblClientName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.lblExceptionError);
            this.panel1.Controls.Add(this.btnGoBack);
            this.panel1.Controls.Add(this.btnSignIn);
            this.panel1.Controls.Add(this.lblPasswordsDontMatch);
            this.panel1.Controls.Add(this.lblWrongPasswordMessage);
            this.panel1.Controls.Add(this.lblWrongUsernameMessage);
            this.panel1.Controls.Add(this.txtClientRepeatedPassword);
            this.panel1.Controls.Add(this.lblClientRepeatedPassword);
            this.panel1.Controls.Add(this.txtClientPassword);
            this.panel1.Controls.Add(this.lblClientPassword);
            this.panel1.Controls.Add(this.txtClientName);
            this.panel1.Controls.Add(this.lblClientName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 580);
            this.panel1.TabIndex = 0;
            // 
            // lblExceptionError
            // 
            this.lblExceptionError.AutoSize = true;
            this.lblExceptionError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExceptionError.ForeColor = System.Drawing.Color.Red;
            this.lblExceptionError.Location = new System.Drawing.Point(374, 452);
            this.lblExceptionError.Name = "lblExceptionError";
            this.lblExceptionError.Size = new System.Drawing.Size(35, 16);
            this.lblExceptionError.TabIndex = 17;
            this.lblExceptionError.Text = "error";
            // 
            // btnGoBack
            // 
            this.btnGoBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoBack.Location = new System.Drawing.Point(32, 472);
            this.btnGoBack.Margin = new System.Windows.Forms.Padding(60);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(102, 39);
            this.btnGoBack.TabIndex = 16;
            this.btnGoBack.Text = "Go back";
            this.btnGoBack.UseVisualStyleBackColor = true;
            this.btnGoBack.Click += new System.EventHandler(this.BtnGoBack_Click);
            // 
            // btnSignIn
            // 
            this.btnSignIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignIn.Location = new System.Drawing.Point(377, 391);
            this.btnSignIn.Margin = new System.Windows.Forms.Padding(0);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(102, 39);
            this.btnSignIn.TabIndex = 15;
            this.btnSignIn.Text = "Sign In";
            this.btnSignIn.UseVisualStyleBackColor = true;
            this.btnSignIn.Click += new System.EventHandler(this.BtnSignIn_Click);
            // 
            // lblPasswordsDontMatch
            // 
            this.lblPasswordsDontMatch.AutoSize = true;
            this.lblPasswordsDontMatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordsDontMatch.ForeColor = System.Drawing.Color.Red;
            this.lblPasswordsDontMatch.Location = new System.Drawing.Point(374, 352);
            this.lblPasswordsDontMatch.Name = "lblPasswordsDontMatch";
            this.lblPasswordsDontMatch.Size = new System.Drawing.Size(35, 16);
            this.lblPasswordsDontMatch.TabIndex = 14;
            this.lblPasswordsDontMatch.Text = "error";
            // 
            // lblWrongPasswordMessage
            // 
            this.lblWrongPasswordMessage.AutoSize = true;
            this.lblWrongPasswordMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWrongPasswordMessage.ForeColor = System.Drawing.Color.Red;
            this.lblWrongPasswordMessage.Location = new System.Drawing.Point(374, 253);
            this.lblWrongPasswordMessage.Name = "lblWrongPasswordMessage";
            this.lblWrongPasswordMessage.Size = new System.Drawing.Size(35, 16);
            this.lblWrongPasswordMessage.TabIndex = 13;
            this.lblWrongPasswordMessage.Text = "error";
            // 
            // lblWrongUsernameMessage
            // 
            this.lblWrongUsernameMessage.AutoSize = true;
            this.lblWrongUsernameMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWrongUsernameMessage.ForeColor = System.Drawing.Color.Red;
            this.lblWrongUsernameMessage.Location = new System.Drawing.Point(374, 152);
            this.lblWrongUsernameMessage.Name = "lblWrongUsernameMessage";
            this.lblWrongUsernameMessage.Size = new System.Drawing.Size(35, 16);
            this.lblWrongUsernameMessage.TabIndex = 12;
            this.lblWrongUsernameMessage.Text = "error";
            // 
            // txtClientRepeatedPassword
            // 
            this.txtClientRepeatedPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientRepeatedPassword.Location = new System.Drawing.Point(377, 310);
            this.txtClientRepeatedPassword.Margin = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.txtClientRepeatedPassword.Multiline = true;
            this.txtClientRepeatedPassword.Name = "txtClientRepeatedPassword";
            this.txtClientRepeatedPassword.PasswordChar = '*';
            this.txtClientRepeatedPassword.Size = new System.Drawing.Size(205, 32);
            this.txtClientRepeatedPassword.TabIndex = 11;
            this.txtClientRepeatedPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RepeatedPasswordKeyUpCheck);
            // 
            // lblClientRepeatedPassword
            // 
            this.lblClientRepeatedPassword.AutoSize = true;
            this.lblClientRepeatedPassword.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblClientRepeatedPassword.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientRepeatedPassword.Location = new System.Drawing.Point(373, 286);
            this.lblClientRepeatedPassword.Margin = new System.Windows.Forms.Padding(10, 1, 10, 2);
            this.lblClientRepeatedPassword.Name = "lblClientRepeatedPassword";
            this.lblClientRepeatedPassword.Size = new System.Drawing.Size(170, 22);
            this.lblClientRepeatedPassword.TabIndex = 10;
            this.lblClientRepeatedPassword.Text = "Repeat password";
            // 
            // txtClientPassword
            // 
            this.txtClientPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientPassword.Location = new System.Drawing.Point(377, 211);
            this.txtClientPassword.Margin = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.txtClientPassword.Multiline = true;
            this.txtClientPassword.Name = "txtClientPassword";
            this.txtClientPassword.PasswordChar = '*';
            this.txtClientPassword.Size = new System.Drawing.Size(205, 32);
            this.txtClientPassword.TabIndex = 9;
            this.txtClientPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ClientPasswordKeyUpCheck);
            // 
            // lblClientPassword
            // 
            this.lblClientPassword.AutoSize = true;
            this.lblClientPassword.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblClientPassword.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientPassword.Location = new System.Drawing.Point(373, 187);
            this.lblClientPassword.Margin = new System.Windows.Forms.Padding(10, 1, 10, 2);
            this.lblClientPassword.Name = "lblClientPassword";
            this.lblClientPassword.Size = new System.Drawing.Size(100, 22);
            this.lblClientPassword.TabIndex = 8;
            this.lblClientPassword.Text = "Password";
            // 
            // txtClientName
            // 
            this.txtClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientName.Location = new System.Drawing.Point(377, 109);
            this.txtClientName.Margin = new System.Windows.Forms.Padding(100, 0, 10, 0);
            this.txtClientName.Multiline = true;
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(205, 32);
            this.txtClientName.TabIndex = 7;
            this.txtClientName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UsernameKeyUpCheck);
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblClientName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientName.Location = new System.Drawing.Point(373, 85);
            this.lblClientName.Margin = new System.Windows.Forms.Padding(10, 10, 10, 2);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(103, 22);
            this.lblClientName.TabIndex = 6;
            this.lblClientName.Text = "Username\r\n";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(371, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(400);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sign in";
            // 
            // SignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(1000, 580);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SignIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Go back";
            this.Shown += new System.EventHandler(this.VariableInitialize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClientPassword;
        private System.Windows.Forms.Label lblClientPassword;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.Label lblClientName;
        private System.Windows.Forms.TextBox txtClientRepeatedPassword;
        private System.Windows.Forms.Label lblClientRepeatedPassword;
        private System.Windows.Forms.Label lblWrongUsernameMessage;
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.Label lblPasswordsDontMatch;
        private System.Windows.Forms.Label lblWrongPasswordMessage;
        private System.Windows.Forms.Button btnGoBack;
        private System.Windows.Forms.Label lblExceptionError;
    }
}