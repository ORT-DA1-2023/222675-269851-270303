namespace UserInterface.Panels
{
    partial class SceneCreation
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
            this.lblNameError = new System.Windows.Forms.Label();
            this.btnChangeName = new System.Windows.Forms.Button();
            this.lblCameraError = new System.Windows.Forms.Label();
            this.btnChangeCamera = new System.Windows.Forms.Button();
            this.btnGoBack = new System.Windows.Forms.Button();
            this.nrFov = new System.Windows.Forms.NumericUpDown();
            this.lblRenderOutDated = new System.Windows.Forms.Label();
            this.lblLastModificationDate = new System.Windows.Forms.Label();
            this.lblLastRenderDate = new System.Windows.Forms.Label();
            this.btnRender = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pBoxRender = new System.Windows.Forms.PictureBox();
            this.txtSceneName = new System.Windows.Forms.TextBox();
            this.txtLookAt = new System.Windows.Forms.TextBox();
            this.txtLookFrom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddModel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cBoxAvailableModels = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRemoveModel = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cBoxPositionedModels = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrFov)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRender)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblNameError);
            this.panel1.Controls.Add(this.btnChangeName);
            this.panel1.Controls.Add(this.lblCameraError);
            this.panel1.Controls.Add(this.btnChangeCamera);
            this.panel1.Controls.Add(this.btnGoBack);
            this.panel1.Controls.Add(this.nrFov);
            this.panel1.Controls.Add(this.lblRenderOutDated);
            this.panel1.Controls.Add(this.lblLastModificationDate);
            this.panel1.Controls.Add(this.lblLastRenderDate);
            this.panel1.Controls.Add(this.btnRender);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.pBoxRender);
            this.panel1.Controls.Add(this.txtSceneName);
            this.panel1.Controls.Add(this.txtLookAt);
            this.panel1.Controls.Add(this.txtLookFrom);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1011, 534);
            this.panel1.TabIndex = 0;
            // 
            // lblNameError
            // 
            this.lblNameError.AutoSize = true;
            this.lblNameError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameError.ForeColor = System.Drawing.Color.Red;
            this.lblNameError.Location = new System.Drawing.Point(258, 93);
            this.lblNameError.Name = "lblNameError";
            this.lblNameError.Size = new System.Drawing.Size(35, 16);
            this.lblNameError.TabIndex = 26;
            this.lblNameError.Text = "error";
            // 
            // btnChangeName
            // 
            this.btnChangeName.Location = new System.Drawing.Point(200, 68);
            this.btnChangeName.Name = "btnChangeName";
            this.btnChangeName.Size = new System.Drawing.Size(57, 23);
            this.btnChangeName.TabIndex = 25;
            this.btnChangeName.Text = "Change name";
            this.btnChangeName.UseVisualStyleBackColor = true;
            this.btnChangeName.Click += new System.EventHandler(this.BtnChangeName_Click);
            // 
            // lblCameraError
            // 
            this.lblCameraError.AutoSize = true;
            this.lblCameraError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCameraError.ForeColor = System.Drawing.Color.Red;
            this.lblCameraError.Location = new System.Drawing.Point(464, 71);
            this.lblCameraError.Name = "lblCameraError";
            this.lblCameraError.Size = new System.Drawing.Size(35, 16);
            this.lblCameraError.TabIndex = 24;
            this.lblCameraError.Text = "error";
            // 
            // btnChangeCamera
            // 
            this.btnChangeCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btnChangeCamera.Location = new System.Drawing.Point(723, 20);
            this.btnChangeCamera.Name = "btnChangeCamera";
            this.btnChangeCamera.Size = new System.Drawing.Size(82, 51);
            this.btnChangeCamera.TabIndex = 23;
            this.btnChangeCamera.Text = "Update settings";
            this.btnChangeCamera.UseVisualStyleBackColor = true;
            this.btnChangeCamera.Click += new System.EventHandler(this.BtnChangeCamera_Click);
            // 
            // btnGoBack
            // 
            this.btnGoBack.Location = new System.Drawing.Point(225, 455);
            this.btnGoBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(88, 36);
            this.btnGoBack.TabIndex = 21;
            this.btnGoBack.Text = "Go back";
            this.btnGoBack.UseVisualStyleBackColor = true;
            this.btnGoBack.Click += new System.EventHandler(this.BtnGoBack_Click);
            // 
            // nrFov
            // 
            this.nrFov.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nrFov.Location = new System.Drawing.Point(656, 33);
            this.nrFov.Maximum = new decimal(new int[] {
            160,
            0,
            0,
            0});
            this.nrFov.Name = "nrFov";
            this.nrFov.Size = new System.Drawing.Size(61, 26);
            this.nrFov.TabIndex = 20;
            this.nrFov.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // lblRenderOutDated
            // 
            this.lblRenderOutDated.AutoSize = true;
            this.lblRenderOutDated.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRenderOutDated.ForeColor = System.Drawing.Color.Red;
            this.lblRenderOutDated.Location = new System.Drawing.Point(414, 374);
            this.lblRenderOutDated.Name = "lblRenderOutDated";
            this.lblRenderOutDated.Size = new System.Drawing.Size(35, 16);
            this.lblRenderOutDated.TabIndex = 19;
            this.lblRenderOutDated.Text = "error";
            // 
            // lblLastModificationDate
            // 
            this.lblLastModificationDate.AutoSize = true;
            this.lblLastModificationDate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblLastModificationDate.Location = new System.Drawing.Point(643, 422);
            this.lblLastModificationDate.Name = "lblLastModificationDate";
            this.lblLastModificationDate.Size = new System.Drawing.Size(10, 13);
            this.lblLastModificationDate.TabIndex = 12;
            this.lblLastModificationDate.Text = "-";
            // 
            // lblLastRenderDate
            // 
            this.lblLastRenderDate.AutoSize = true;
            this.lblLastRenderDate.Location = new System.Drawing.Point(643, 445);
            this.lblLastRenderDate.Name = "lblLastRenderDate";
            this.lblLastRenderDate.Size = new System.Drawing.Size(10, 13);
            this.lblLastRenderDate.TabIndex = 11;
            this.lblLastRenderDate.Text = "-";
            // 
            // btnRender
            // 
            this.btnRender.Location = new System.Drawing.Point(605, 117);
            this.btnRender.Name = "btnRender";
            this.btnRender.Size = new System.Drawing.Size(112, 33);
            this.btnRender.TabIndex = 10;
            this.btnRender.Text = "Render";
            this.btnRender.UseVisualStyleBackColor = true;
            this.btnRender.Click += new System.EventHandler(this.BtnRender_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // pBoxRender
            // 
            this.pBoxRender.Location = new System.Drawing.Point(417, 171);
            this.pBoxRender.Name = "pBoxRender";
            this.pBoxRender.Size = new System.Drawing.Size(300, 200);
            this.pBoxRender.TabIndex = 8;
            this.pBoxRender.TabStop = false;
            // 
            // txtSceneName
            // 
            this.txtSceneName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSceneName.Location = new System.Drawing.Point(200, 36);
            this.txtSceneName.Name = "txtSceneName";
            this.txtSceneName.Size = new System.Drawing.Size(153, 26);
            this.txtSceneName.TabIndex = 7;
            this.txtSceneName.Text = "New_BlankScene_1";
            this.txtSceneName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLookAt
            // 
            this.txtLookAt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLookAt.Location = new System.Drawing.Point(558, 33);
            this.txtLookAt.Name = "txtLookAt";
            this.txtLookAt.Size = new System.Drawing.Size(76, 26);
            this.txtLookAt.TabIndex = 5;
            this.txtLookAt.Text = "(0;2;5)";
            this.txtLookAt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLookFrom
            // 
            this.txtLookFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLookFrom.Location = new System.Drawing.Point(458, 33);
            this.txtLookFrom.Name = "txtLookFrom";
            this.txtLookFrom.Size = new System.Drawing.Size(76, 26);
            this.txtLookFrom.TabIndex = 4;
            this.txtLookFrom.Text = "(0;2;0)";
            this.txtLookFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(665, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fov";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(559, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Look at";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(454, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Look from";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btnAddModel);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtPosition);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cBoxAvailableModels);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(190, 534);
            this.panel2.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "Select a model:";
            // 
            // btnAddModel
            // 
            this.btnAddModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddModel.Location = new System.Drawing.Point(-1, 344);
            this.btnAddModel.Name = "btnAddModel";
            this.btnAddModel.Size = new System.Drawing.Size(190, 44);
            this.btnAddModel.TabIndex = 7;
            this.btnAddModel.Text = "Add";
            this.btnAddModel.UseVisualStyleBackColor = true;
            this.btnAddModel.Click += new System.EventHandler(this.BtnAddModel_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 221);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(168, 24);
            this.label7.TabIndex = 6;
            this.label7.Text = "Select the position:";
            // 
            // txtPosition
            // 
            this.txtPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPosition.Location = new System.Drawing.Point(37, 248);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(95, 26);
            this.txtPosition.TabIndex = 5;
            this.txtPosition.Text = "(0;0;0)";
            this.txtPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 24);
            this.label6.TabIndex = 1;
            this.label6.Text = "Adding a model";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // cBoxAvailableModels
            // 
            this.cBoxAvailableModels.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxAvailableModels.FormattingEnabled = true;
            this.cBoxAvailableModels.Location = new System.Drawing.Point(3, 155);
            this.cBoxAvailableModels.Name = "cBoxAvailableModels";
            this.cBoxAvailableModels.Size = new System.Drawing.Size(182, 32);
            this.cBoxAvailableModels.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.btnRemoveModel);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.cBoxPositionedModels);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(811, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 534);
            this.panel3.TabIndex = 1;
            // 
            // btnRemoveModel
            // 
            this.btnRemoveModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveModel.Location = new System.Drawing.Point(3, 238);
            this.btnRemoveModel.Name = "btnRemoveModel";
            this.btnRemoveModel.Size = new System.Drawing.Size(174, 44);
            this.btnRemoveModel.TabIndex = 8;
            this.btnRemoveModel.Text = "remove model";
            this.btnRemoveModel.UseVisualStyleBackColor = true;
            this.btnRemoveModel.Click += new System.EventHandler(this.BtnRemoveModel_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(165, 24);
            this.label8.TabIndex = 2;
            this.label8.Text = "Positioned models";
            // 
            // cBoxPositionedModels
            // 
            this.cBoxPositionedModels.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.cBoxPositionedModels.FormattingEnabled = true;
            this.cBoxPositionedModels.Location = new System.Drawing.Point(3, 194);
            this.cBoxPositionedModels.Name = "cBoxPositionedModels";
            this.cBoxPositionedModels.Size = new System.Drawing.Size(196, 25);
            this.cBoxPositionedModels.TabIndex = 1;
            this.cBoxPositionedModels.Text = "Click here to see all models";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(196, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 24);
            this.label5.TabIndex = 9;
            this.label5.Text = "Scene title";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(155, 48);
            this.label9.TabIndex = 9;
            this.label9.Text = "Remove a \r\npositioned model";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(527, 445);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Last Render Date:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(521, 422);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Last Modification Date:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label12.Location = new System.Drawing.Point(423, 239);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(294, 40);
            this.label12.TabIndex = 29;
            this.label12.Text = "Rendering...\r\nPlease wait, it may last a few seconds";
            this.label12.Visible = false;
            // 
            // SceneCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 534);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "SceneCreation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SceneCreation";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrFov)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRender)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pBoxRender;
        private System.Windows.Forms.TextBox txtSceneName;
        private System.Windows.Forms.TextBox txtLookAt;
        private System.Windows.Forms.TextBox txtLookFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLastModificationDate;
        private System.Windows.Forms.Label lblLastRenderDate;
        private System.Windows.Forms.Button btnRender;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblRenderOutDated;
        private System.Windows.Forms.NumericUpDown nrFov;
        private System.Windows.Forms.Button btnGoBack;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cBoxAvailableModels;
        private System.Windows.Forms.Button btnAddModel;
        private System.Windows.Forms.Button btnRemoveModel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cBoxPositionedModels;
        private System.Windows.Forms.Button btnChangeCamera;
        private System.Windows.Forms.Label lblCameraError;
        private System.Windows.Forms.Button btnChangeName;
        private System.Windows.Forms.Label lblNameError;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
    }
}