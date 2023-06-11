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
            this.lblRenderingNotification = new System.Windows.Forms.Label();
            this.lblExporting = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cmbBlur = new System.Windows.Forms.CheckBox();
            this.txtAperture = new System.Windows.Forms.TextBox();
            this.lblAperture = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnChangeName = new System.Windows.Forms.Button();
            this.lblCamera = new System.Windows.Forms.Label();
            this.btnChangeCamera = new System.Windows.Forms.Button();
            this.btnGoBack = new System.Windows.Forms.Button();
            this.nrFov = new System.Windows.Forms.NumericUpDown();
            this.lblRenderOutDated = new System.Windows.Forms.Label();
            this.lblLastModificationDate = new System.Windows.Forms.Label();
            this.lblLastRenderDate = new System.Windows.Forms.Label();
            this.btnRender = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSceneName = new System.Windows.Forms.TextBox();
            this.txtLookAt = new System.Windows.Forms.TextBox();
            this.txtLookFrom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pBoxRender = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblAddModel = new System.Windows.Forms.Label();
            this.btnAddModel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cBoxAvailableModels = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblRemoveModel = new System.Windows.Forms.Label();
            this.btnRemoveModel = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cBoxPositionedModels = new System.Windows.Forms.ComboBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrFov)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRender)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.lblRenderingNotification);
            this.panel1.Controls.Add(this.lblExporting);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnSelectPath);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.cmbBlur);
            this.panel1.Controls.Add(this.txtAperture);
            this.panel1.Controls.Add(this.lblAperture);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.btnChangeName);
            this.panel1.Controls.Add(this.lblCamera);
            this.panel1.Controls.Add(this.btnChangeCamera);
            this.panel1.Controls.Add(this.btnGoBack);
            this.panel1.Controls.Add(this.nrFov);
            this.panel1.Controls.Add(this.lblRenderOutDated);
            this.panel1.Controls.Add(this.lblLastModificationDate);
            this.panel1.Controls.Add(this.lblLastRenderDate);
            this.panel1.Controls.Add(this.btnRender);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtSceneName);
            this.panel1.Controls.Add(this.txtLookAt);
            this.panel1.Controls.Add(this.txtLookFrom);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pBoxRender);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1011, 534);
            this.panel1.TabIndex = 0;
            // 
            // lblRenderingNotification
            // 
            this.lblRenderingNotification.AutoSize = true;
            this.lblRenderingNotification.BackColor = System.Drawing.Color.Transparent;
            this.lblRenderingNotification.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblRenderingNotification.ForeColor = System.Drawing.Color.Green;
            this.lblRenderingNotification.Location = new System.Drawing.Point(352, 346);
            this.lblRenderingNotification.Name = "lblRenderingNotification";
            this.lblRenderingNotification.Size = new System.Drawing.Size(235, 26);
            this.lblRenderingNotification.TabIndex = 33;
            this.lblRenderingNotification.Text = "Rendering...\r\nPlease wait, the process may last a few seconds";
            this.lblRenderingNotification.Visible = false;
            // 
            // lblExporting
            // 
            this.lblExporting.AutoSize = true;
            this.lblExporting.Location = new System.Drawing.Point(502, 495);
            this.lblExporting.Name = "lblExporting";
            this.lblExporting.Size = new System.Drawing.Size(132, 26);
            this.lblExporting.TabIndex = 32;
            this.lblExporting.Text = "Rendering and exporting...\r\nPlease wait";
            this.lblExporting.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(687, 423);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 0;
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Location = new System.Drawing.Point(642, 439);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(75, 23);
            this.btnSelectPath.TabIndex = 2;
            this.btnSelectPath.Text = "Select Path";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(640, 468);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 41);
            this.button3.TabIndex = 30;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // cmbBlur
            // 
            this.cmbBlur.AutoSize = true;
            this.cmbBlur.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.cmbBlur.Location = new System.Drawing.Point(425, 64);
            this.cmbBlur.Margin = new System.Windows.Forms.Padding(2);
            this.cmbBlur.Name = "cmbBlur";
            this.cmbBlur.Size = new System.Drawing.Size(52, 21);
            this.cmbBlur.TabIndex = 29;
            this.cmbBlur.Text = "Blur";
            this.cmbBlur.UseVisualStyleBackColor = true;
            this.cmbBlur.CheckedChanged += new System.EventHandler(this.CmbBlur_CheckedChanged);
            // 
            // txtAperture
            // 
            this.txtAperture.Enabled = false;
            this.txtAperture.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAperture.Location = new System.Drawing.Point(425, 33);
            this.txtAperture.Name = "txtAperture";
            this.txtAperture.Size = new System.Drawing.Size(50, 26);
            this.txtAperture.TabIndex = 28;
            this.txtAperture.Text = "1,0";
            this.txtAperture.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblAperture
            // 
            this.lblAperture.AutoSize = true;
            this.lblAperture.Enabled = false;
            this.lblAperture.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAperture.Location = new System.Drawing.Point(413, 10);
            this.lblAperture.Name = "lblAperture";
            this.lblAperture.Size = new System.Drawing.Size(71, 20);
            this.lblAperture.TabIndex = 27;
            this.lblAperture.Text = "Aperture";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Red;
            this.lblName.Location = new System.Drawing.Point(269, 43);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 16);
            this.lblName.TabIndex = 26;
            this.lblName.Text = "error";
            // 
            // btnChangeName
            // 
            this.btnChangeName.Location = new System.Drawing.Point(196, 47);
            this.btnChangeName.Name = "btnChangeName";
            this.btnChangeName.Size = new System.Drawing.Size(57, 23);
            this.btnChangeName.TabIndex = 25;
            this.btnChangeName.Text = "Change";
            this.btnChangeName.UseVisualStyleBackColor = true;
            this.btnChangeName.Click += new System.EventHandler(this.BtnChangeName_Click);
            // 
            // lblCamera
            // 
            this.lblCamera.AutoSize = true;
            this.lblCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCamera.ForeColor = System.Drawing.Color.Red;
            this.lblCamera.Location = new System.Drawing.Point(721, 69);
            this.lblCamera.Name = "lblCamera";
            this.lblCamera.Size = new System.Drawing.Size(35, 16);
            this.lblCamera.TabIndex = 24;
            this.lblCamera.Text = "error";
            // 
            // btnChangeCamera
            // 
            this.btnChangeCamera.Location = new System.Drawing.Point(724, 28);
            this.btnChangeCamera.Name = "btnChangeCamera";
            this.btnChangeCamera.Size = new System.Drawing.Size(91, 37);
            this.btnChangeCamera.TabIndex = 23;
            this.btnChangeCamera.Text = "Change";
            this.btnChangeCamera.UseVisualStyleBackColor = true;
            this.btnChangeCamera.Click += new System.EventHandler(this.BtnChangeCamera_Click);
            // 
            // btnGoBack
            // 
            this.btnGoBack.Location = new System.Drawing.Point(210, 473);
            this.btnGoBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(103, 36);
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
            this.lblRenderOutDated.Location = new System.Drawing.Point(360, 330);
            this.lblRenderOutDated.Name = "lblRenderOutDated";
            this.lblRenderOutDated.Size = new System.Drawing.Size(35, 16);
            this.lblRenderOutDated.TabIndex = 19;
            this.lblRenderOutDated.Text = "error";
            // 
            // lblLastModificationDate
            // 
            this.lblLastModificationDate.AutoSize = true;
            this.lblLastModificationDate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblLastModificationDate.Location = new System.Drawing.Point(222, 87);
            this.lblLastModificationDate.Name = "lblLastModificationDate";
            this.lblLastModificationDate.Size = new System.Drawing.Size(106, 13);
            this.lblLastModificationDate.TabIndex = 12;
            this.lblLastModificationDate.Text = "last modification date";
            // 
            // lblLastRenderDate
            // 
            this.lblLastRenderDate.AutoSize = true;
            this.lblLastRenderDate.Location = new System.Drawing.Point(502, 414);
            this.lblLastRenderDate.Name = "lblLastRenderDate";
            this.lblLastRenderDate.Size = new System.Drawing.Size(85, 13);
            this.lblLastRenderDate.TabIndex = 11;
            this.lblLastRenderDate.Text = "LastRenderDate";
            // 
            // btnRender
            // 
            this.btnRender.Location = new System.Drawing.Point(576, 322);
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
            // txtSceneName
            // 
            this.txtSceneName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSceneName.Location = new System.Drawing.Point(196, 14);
            this.txtSceneName.Name = "txtSceneName";
            this.txtSceneName.Size = new System.Drawing.Size(153, 26);
            this.txtSceneName.TabIndex = 7;
            this.txtSceneName.Text = "New_BlankScene_1";
            this.txtSceneName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLookAt
            // 
            this.txtLookAt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLookAt.Location = new System.Drawing.Point(575, 33);
            this.txtLookAt.Name = "txtLookAt";
            this.txtLookAt.Size = new System.Drawing.Size(76, 26);
            this.txtLookAt.TabIndex = 5;
            this.txtLookAt.Text = "(0;2;5)";
            this.txtLookAt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLookFrom
            // 
            this.txtLookFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLookFrom.Location = new System.Drawing.Point(494, 33);
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
            this.label1.Location = new System.Drawing.Point(652, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fov";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(572, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Look at";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(490, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Look from";
            // 
            // pBoxRender
            // 
            this.pBoxRender.Location = new System.Drawing.Point(357, 116);
            this.pBoxRender.Name = "pBoxRender";
            this.pBoxRender.Size = new System.Drawing.Size(330, 200);
            this.pBoxRender.TabIndex = 8;
            this.pBoxRender.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblAddModel);
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
            // lblAddModel
            // 
            this.lblAddModel.AutoSize = true;
            this.lblAddModel.ForeColor = System.Drawing.Color.Green;
            this.lblAddModel.Location = new System.Drawing.Point(67, 454);
            this.lblAddModel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAddModel.Name = "lblAddModel";
            this.lblAddModel.Size = new System.Drawing.Size(47, 13);
            this.lblAddModel.TabIndex = 8;
            this.lblAddModel.Text = "correctly";
            // 
            // btnAddModel
            // 
            this.btnAddModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddModel.Location = new System.Drawing.Point(-1, 489);
            this.btnAddModel.Name = "btnAddModel";
            this.btnAddModel.Size = new System.Drawing.Size(190, 44);
            this.btnAddModel.TabIndex = 7;
            this.btnAddModel.Text = "Add model";
            this.btnAddModel.UseVisualStyleBackColor = true;
            this.btnAddModel.Click += new System.EventHandler(this.BtnAddModel_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 24);
            this.label7.TabIndex = 6;
            this.label7.Text = "Position:";
            // 
            // txtPosition
            // 
            this.txtPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPosition.Location = new System.Drawing.Point(109, 107);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(76, 26);
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
            this.label6.Size = new System.Drawing.Size(153, 24);
            this.label6.TabIndex = 1;
            this.label6.Text = "Available models";
            // 
            // cBoxAvailableModels
            // 
            this.cBoxAvailableModels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxAvailableModels.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxAvailableModels.FormattingEnabled = true;
            this.cBoxAvailableModels.Location = new System.Drawing.Point(-1, 194);
            this.cBoxAvailableModels.Name = "cBoxAvailableModels";
            this.cBoxAvailableModels.Size = new System.Drawing.Size(190, 32);
            this.cBoxAvailableModels.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblRemoveModel);
            this.panel3.Controls.Add(this.btnRemoveModel);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.cBoxPositionedModels);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(821, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(190, 534);
            this.panel3.TabIndex = 1;
            // 
            // lblRemoveModel
            // 
            this.lblRemoveModel.AutoSize = true;
            this.lblRemoveModel.ForeColor = System.Drawing.Color.Green;
            this.lblRemoveModel.Location = new System.Drawing.Point(95, 454);
            this.lblRemoveModel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRemoveModel.Name = "lblRemoveModel";
            this.lblRemoveModel.Size = new System.Drawing.Size(47, 13);
            this.lblRemoveModel.TabIndex = 9;
            this.lblRemoveModel.Text = "correctly";
            // 
            // btnRemoveModel
            // 
            this.btnRemoveModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveModel.Location = new System.Drawing.Point(-1, 489);
            this.btnRemoveModel.Name = "btnRemoveModel";
            this.btnRemoveModel.Size = new System.Drawing.Size(190, 44);
            this.btnRemoveModel.TabIndex = 8;
            this.btnRemoveModel.Text = "Remove model";
            this.btnRemoveModel.UseVisualStyleBackColor = true;
            this.btnRemoveModel.Click += new System.EventHandler(this.BtnRemoveModel_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(165, 24);
            this.label8.TabIndex = 2;
            this.label8.Text = "Positioned models";
            // 
            // cBoxPositionedModels
            // 
            this.cBoxPositionedModels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxPositionedModels.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxPositionedModels.FormattingEnabled = true;
            this.cBoxPositionedModels.Location = new System.Drawing.Point(-1, 194);
            this.cBoxPositionedModels.Name = "cBoxPositionedModels";
            this.cBoxPositionedModels.Size = new System.Drawing.Size(190, 32);
            this.cBoxPositionedModels.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "PPM",
            "PNG",
            "JPG"});
            this.comboBox1.Location = new System.Drawing.Point(642, 406);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 34;
            // 
            // SceneCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 534);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
        private System.Windows.Forms.Label lblCamera;
        private System.Windows.Forms.Button btnChangeName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAddModel;
        private System.Windows.Forms.Label lblRemoveModel;
        private System.Windows.Forms.Label lblAperture;
        private System.Windows.Forms.CheckBox cmbBlur;
        private System.Windows.Forms.TextBox txtAperture;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnSelectPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblExporting;
        private System.Windows.Forms.Label lblRenderingNotification;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}