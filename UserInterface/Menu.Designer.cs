namespace Render3D.UserInterface
{
    partial class Menu
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pnlObjectCreation = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnScene = new System.Windows.Forms.Button();
            this.btnModel = new System.Windows.Forms.Button();
            this.btnMaterial = new System.Windows.Forms.Button();
            this.btnFigure = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.lblShowClientName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(-3, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(805, 455);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.pnlObjectCreation);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(200, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(605, 455);
            this.panel3.TabIndex = 1;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(268, 453);
            this.panel5.TabIndex = 1;
            // 
            // pnlObjectCreation
            // 
            this.pnlObjectCreation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlObjectCreation.Location = new System.Drawing.Point(268, 0);
            this.pnlObjectCreation.Margin = new System.Windows.Forms.Padding(0);
            this.pnlObjectCreation.Name = "pnlObjectCreation";
            this.pnlObjectCreation.Size = new System.Drawing.Size(336, 454);
            this.pnlObjectCreation.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblShowClientName);
            this.panel2.Controls.Add(this.btnScene);
            this.panel2.Controls.Add(this.btnModel);
            this.panel2.Controls.Add(this.btnMaterial);
            this.panel2.Controls.Add(this.btnFigure);
            this.panel2.Controls.Add(this.btnLogOut);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 455);
            this.panel2.TabIndex = 1;
            // 
            // btnScene
            // 
            this.btnScene.Location = new System.Drawing.Point(14, 264);
            this.btnScene.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnScene.Name = "btnScene";
            this.btnScene.Size = new System.Drawing.Size(157, 48);
            this.btnScene.TabIndex = 4;
            this.btnScene.Text = "Scenes!";
            this.btnScene.UseVisualStyleBackColor = true;
            // 
            // btnModel
            // 
            this.btnModel.Location = new System.Drawing.Point(14, 206);
            this.btnModel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnModel.Name = "btnModel";
            this.btnModel.Size = new System.Drawing.Size(157, 48);
            this.btnModel.TabIndex = 3;
            this.btnModel.Text = "Models!";
            this.btnModel.UseVisualStyleBackColor = true;
            this.btnModel.Click += new System.EventHandler(this.btnModel_Click);
            // 
            // btnMaterial
            // 
            this.btnMaterial.Location = new System.Drawing.Point(14, 148);
            this.btnMaterial.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnMaterial.Name = "btnMaterial";
            this.btnMaterial.Size = new System.Drawing.Size(157, 48);
            this.btnMaterial.TabIndex = 2;
            this.btnMaterial.Text = "Materials!";
            this.btnMaterial.UseVisualStyleBackColor = true;
            this.btnMaterial.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnFigure
            // 
            this.btnFigure.Location = new System.Drawing.Point(14, 90);
            this.btnFigure.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnFigure.Name = "btnFigure";
            this.btnFigure.Size = new System.Drawing.Size(157, 48);
            this.btnFigure.TabIndex = 1;
            this.btnFigure.Text = "Figures!";
            this.btnFigure.UseVisualStyleBackColor = true;
            this.btnFigure.Click += new System.EventHandler(this.btnFigure_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(14, 393);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(157, 48);
            this.btnLogOut.TabIndex = 0;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // lblShowClientName
            // 
            this.lblShowClientName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShowClientName.AutoSize = true;
            this.lblShowClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowClientName.Location = new System.Drawing.Point(30, 8);
            this.lblShowClientName.Name = "lblShowClientName";
            this.lblShowClientName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblShowClientName.Size = new System.Drawing.Size(141, 48);
            this.lblShowClientName.TabIndex = 0;
            this.lblShowClientName.Text = "Welcome back \r\nUser!!";
            this.lblShowClientName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 454);
            this.Controls.Add(this.panel1);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.UserMenu_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnModel;
        private System.Windows.Forms.Button btnMaterial;
        private System.Windows.Forms.Button btnFigure;
        private System.Windows.Forms.Button btnScene;
        private System.Windows.Forms.Panel pnlObjectCreation;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblShowClientName;
    }
}