namespace Render3D.UserInterface
{
    partial class CreationMenu
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.flObjectList = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlObjectCreation = new System.Windows.Forms.Panel();
            this.lblShowClientName = new System.Windows.Forms.Label();
            this.btnScene = new System.Windows.Forms.Button();
            this.btnModel = new System.Windows.Forms.Button();
            this.btnMaterial = new System.Windows.Forms.Button();
            this.btnFigure = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.pnlMenuControler = new System.Windows.Forms.Panel();
            this.btnLogs = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.pnlMenuControler.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.flObjectList);
            this.panel3.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(647, 580);
            this.panel3.TabIndex = 1;
            // 
            // flObjectList
            // 
            this.flObjectList.AutoScroll = true;
            this.flObjectList.BackColor = System.Drawing.SystemColors.Control;
            this.flObjectList.Location = new System.Drawing.Point(318, -1);
            this.flObjectList.Margin = new System.Windows.Forms.Padding(0);
            this.flObjectList.Name = "flObjectList";
            this.flObjectList.Size = new System.Drawing.Size(327, 579);
            this.flObjectList.TabIndex = 0;
            // 
            // pnlObjectCreation
            // 
            this.pnlObjectCreation.BackColor = System.Drawing.SystemColors.Control;
            this.pnlObjectCreation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlObjectCreation.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlObjectCreation.Location = new System.Drawing.Point(647, 0);
            this.pnlObjectCreation.Margin = new System.Windows.Forms.Padding(0);
            this.pnlObjectCreation.Name = "pnlObjectCreation";
            this.pnlObjectCreation.Size = new System.Drawing.Size(364, 580);
            this.pnlObjectCreation.TabIndex = 0;
            // 
            // lblShowClientName
            // 
            this.lblShowClientName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblShowClientName.AutoSize = true;
            this.lblShowClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowClientName.Location = new System.Drawing.Point(68, 8);
            this.lblShowClientName.Name = "lblShowClientName";
            this.lblShowClientName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblShowClientName.Size = new System.Drawing.Size(154, 48);
            this.lblShowClientName.TabIndex = 0;
            this.lblShowClientName.Text = "Welcome back \r\nUser!!";
            this.lblShowClientName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnScene
            // 
            this.btnScene.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnScene.BackColor = System.Drawing.Color.Yellow;
            this.btnScene.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btnScene.Location = new System.Drawing.Point(52, 255);
            this.btnScene.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnScene.Name = "btnScene";
            this.btnScene.Size = new System.Drawing.Size(157, 48);
            this.btnScene.TabIndex = 4;
            this.btnScene.Text = "Scenes";
            this.btnScene.UseVisualStyleBackColor = false;
            this.btnScene.Click += new System.EventHandler(this.BtnScene_Click);
            // 
            // btnModel
            // 
            this.btnModel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnModel.BackColor = System.Drawing.Color.Yellow;
            this.btnModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btnModel.Location = new System.Drawing.Point(52, 197);
            this.btnModel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnModel.Name = "btnModel";
            this.btnModel.Size = new System.Drawing.Size(157, 48);
            this.btnModel.TabIndex = 3;
            this.btnModel.Text = "Models";
            this.btnModel.UseVisualStyleBackColor = false;
            this.btnModel.Click += new System.EventHandler(this.BtnModel_Click);
            // 
            // btnMaterial
            // 
            this.btnMaterial.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnMaterial.BackColor = System.Drawing.Color.Yellow;
            this.btnMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btnMaterial.Location = new System.Drawing.Point(52, 139);
            this.btnMaterial.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnMaterial.Name = "btnMaterial";
            this.btnMaterial.Size = new System.Drawing.Size(157, 48);
            this.btnMaterial.TabIndex = 2;
            this.btnMaterial.Text = "Materials";
            this.btnMaterial.UseVisualStyleBackColor = false;
            this.btnMaterial.Click += new System.EventHandler(this.BtnMaterial_Click);
            // 
            // btnFigure
            // 
            this.btnFigure.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnFigure.BackColor = System.Drawing.Color.Yellow;
            this.btnFigure.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFigure.Location = new System.Drawing.Point(52, 81);
            this.btnFigure.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnFigure.Name = "btnFigure";
            this.btnFigure.Size = new System.Drawing.Size(157, 48);
            this.btnFigure.TabIndex = 1;
            this.btnFigure.Text = "Figures";
            this.btnFigure.UseVisualStyleBackColor = false;
            this.btnFigure.Click += new System.EventHandler(this.BtnFigure_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLogOut.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btnLogOut.Location = new System.Drawing.Point(52, 437);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(157, 48);
            this.btnLogOut.TabIndex = 0;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.BtnLogOut_Click);
            // 
            // pnlMenuControler
            // 
            this.pnlMenuControler.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMenuControler.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMenuControler.Controls.Add(this.btnLogs);
            this.pnlMenuControler.Controls.Add(this.lblShowClientName);
            this.pnlMenuControler.Controls.Add(this.btnLogOut);
            this.pnlMenuControler.Controls.Add(this.btnScene);
            this.pnlMenuControler.Controls.Add(this.btnFigure);
            this.pnlMenuControler.Controls.Add(this.btnMaterial);
            this.pnlMenuControler.Controls.Add(this.btnModel);
            this.pnlMenuControler.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenuControler.Location = new System.Drawing.Point(0, 0);
            this.pnlMenuControler.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMenuControler.Name = "pnlMenuControler";
            this.pnlMenuControler.Size = new System.Drawing.Size(319, 580);
            this.pnlMenuControler.TabIndex = 2;
            // 
            // btnLogs
            // 
            this.btnLogs.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLogs.BackColor = System.Drawing.Color.Yellow;
            this.btnLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btnLogs.Location = new System.Drawing.Point(52, 313);
            this.btnLogs.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnLogs.Name = "btnLogs";
            this.btnLogs.Size = new System.Drawing.Size(157, 48);
            this.btnLogs.TabIndex = 5;
            this.btnLogs.Text = "Logs";
            this.btnLogs.UseVisualStyleBackColor = false;
            this.btnLogs.Click += new System.EventHandler(this.BtnLogs_Click);
            // 
            // CreationMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 580);
            this.Controls.Add(this.pnlMenuControler);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnlObjectCreation);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreationMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "au";
            this.Shown += new System.EventHandler(this.VariablesInitialize);
            this.panel3.ResumeLayout(false);
            this.pnlMenuControler.ResumeLayout(false);
            this.pnlMenuControler.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnModel;
        private System.Windows.Forms.Button btnMaterial;
        private System.Windows.Forms.Button btnFigure;
        private System.Windows.Forms.Button btnScene;
        private System.Windows.Forms.Label lblShowClientName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnlObjectCreation;
        private System.Windows.Forms.Panel pnlMenuControler;
        private System.Windows.Forms.FlowLayoutPanel flObjectList;
        private System.Windows.Forms.Button btnLogs;
    }
}