﻿namespace Render3D.UserInterface.Panels
{
    partial class MaterialPanel
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
            this.btnCreateFigure = new System.Windows.Forms.Button();
            this.txtMaterialName = new System.Windows.Forms.TextBox();
            this.lblRed = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblGreen = new System.Windows.Forms.Label();
            this.lblBlue = new System.Windows.Forms.Label();
            this.nrRedColor = new System.Windows.Forms.NumericUpDown();
            this.nrGreenColor = new System.Windows.Forms.NumericUpDown();
            this.nrBlueColor = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBlur = new System.Windows.Forms.TextBox();
            this.lblBlur = new System.Windows.Forms.Label();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.lblExceptionError = new System.Windows.Forms.Label();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nrRedColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrGreenColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrBlueColor)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreateFigure
            // 
            this.btnCreateFigure.BackColor = System.Drawing.Color.Yellow;
            this.btnCreateFigure.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCreateFigure.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateFigure.Location = new System.Drawing.Point(0, 473);
            this.btnCreateFigure.Name = "btnCreateFigure";
            this.btnCreateFigure.Size = new System.Drawing.Size(379, 78);
            this.btnCreateFigure.TabIndex = 13;
            this.btnCreateFigure.Text = "Create";
            this.btnCreateFigure.UseVisualStyleBackColor = false;
            this.btnCreateFigure.Click += new System.EventHandler(this.BtnCreateMaterial_Click);
            // 
            // txtMaterialName
            // 
            this.txtMaterialName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaterialName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterialName.Location = new System.Drawing.Point(125, 158);
            this.txtMaterialName.Name = "txtMaterialName";
            this.txtMaterialName.Size = new System.Drawing.Size(200, 29);
            this.txtMaterialName.TabIndex = 9;
            this.txtMaterialName.TextChanged += new System.EventHandler(this.txtMaterialName_TextChanged);
            // 
            // lblRed
            // 
            this.lblRed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRed.AutoSize = true;
            this.lblRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRed.Location = new System.Drawing.Point(38, 216);
            this.lblRed.Name = "lblRed";
            this.lblRed.Size = new System.Drawing.Size(50, 24);
            this.lblRed.TabIndex = 8;
            this.lblRed.Text = "Red:";
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(38, 162);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(66, 24);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Name:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Create a new material";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGreen
            // 
            this.lblGreen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGreen.AutoSize = true;
            this.lblGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGreen.Location = new System.Drawing.Point(38, 266);
            this.lblGreen.Name = "lblGreen";
            this.lblGreen.Size = new System.Drawing.Size(68, 24);
            this.lblGreen.TabIndex = 12;
            this.lblGreen.Text = "Green:";
            // 
            // lblBlue
            // 
            this.lblBlue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBlue.AutoSize = true;
            this.lblBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlue.Location = new System.Drawing.Point(38, 313);
            this.lblBlue.Name = "lblBlue";
            this.lblBlue.Size = new System.Drawing.Size(53, 24);
            this.lblBlue.TabIndex = 13;
            this.lblBlue.Text = "Blue:";
            // 
            // nrRedColor
            // 
            this.nrRedColor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nrRedColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nrRedColor.Location = new System.Drawing.Point(125, 212);
            this.nrRedColor.Margin = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.nrRedColor.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nrRedColor.Name = "nrRedColor";
            this.nrRedColor.Size = new System.Drawing.Size(199, 29);
            this.nrRedColor.TabIndex = 10;
            this.nrRedColor.ValueChanged += new System.EventHandler(this.nrRedColor_ValueChanged);
            // 
            // nrGreenColor
            // 
            this.nrGreenColor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nrGreenColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nrGreenColor.Location = new System.Drawing.Point(125, 261);
            this.nrGreenColor.Margin = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.nrGreenColor.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nrGreenColor.Name = "nrGreenColor";
            this.nrGreenColor.Size = new System.Drawing.Size(199, 29);
            this.nrGreenColor.TabIndex = 11;
            this.nrGreenColor.ValueChanged += new System.EventHandler(this.nrGreenColor_ValueChanged);
            // 
            // nrBlueColor
            // 
            this.nrBlueColor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nrBlueColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nrBlueColor.Location = new System.Drawing.Point(125, 313);
            this.nrBlueColor.Margin = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.nrBlueColor.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nrBlueColor.Name = "nrBlueColor";
            this.nrBlueColor.Size = new System.Drawing.Size(199, 29);
            this.nrBlueColor.TabIndex = 12;
            this.nrBlueColor.ValueChanged += new System.EventHandler(this.nrBlueColor_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtBlur);
            this.panel1.Controls.Add(this.lblBlur);
            this.panel1.Controls.Add(this.lblMaterial);
            this.panel1.Controls.Add(this.lblExceptionError);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.nrBlueColor);
            this.panel1.Controls.Add(this.btnCreateFigure);
            this.panel1.Controls.Add(this.nrGreenColor);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.nrRedColor);
            this.panel1.Controls.Add(this.lblRed);
            this.panel1.Controls.Add(this.lblBlue);
            this.panel1.Controls.Add(this.txtMaterialName);
            this.panel1.Controls.Add(this.lblGreen);
            this.panel1.Controls.Add(this.cmbMaterial);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(379, 551);
            this.panel1.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(125, 429);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Successfully added";
            this.label2.Visible = false;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtBlur
            // 
            this.txtBlur.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBlur.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBlur.Location = new System.Drawing.Point(125, 368);
            this.txtBlur.Name = "txtBlur";
            this.txtBlur.Size = new System.Drawing.Size(48, 29);
            this.txtBlur.TabIndex = 22;
            this.txtBlur.Text = "0,0";
            this.txtBlur.TextChanged += new System.EventHandler(this.txtBlur_TextChanged);
            // 
            // lblBlur
            // 
            this.lblBlur.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBlur.AutoSize = true;
            this.lblBlur.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlur.Location = new System.Drawing.Point(38, 370);
            this.lblBlur.Name = "lblBlur";
            this.lblBlur.Size = new System.Drawing.Size(48, 24);
            this.lblBlur.TabIndex = 21;
            this.lblBlur.Text = "Blur:";
            // 
            // lblMaterial
            // 
            this.lblMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterial.Location = new System.Drawing.Point(38, 109);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(80, 24);
            this.lblMaterial.TabIndex = 20;
            this.lblMaterial.Text = "Material:";
            // 
            // lblExceptionError
            // 
            this.lblExceptionError.AutoSize = true;
            this.lblExceptionError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExceptionError.ForeColor = System.Drawing.Color.Red;
            this.lblExceptionError.Location = new System.Drawing.Point(42, 429);
            this.lblExceptionError.Name = "lblExceptionError";
            this.lblExceptionError.Size = new System.Drawing.Size(35, 16);
            this.lblExceptionError.TabIndex = 18;
            this.lblExceptionError.Text = "error";
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaterial.FormattingEnabled = true;
            this.cmbMaterial.Items.AddRange(new object[] {
            "Lambertian",
            "Metallic"});
            this.cmbMaterial.Location = new System.Drawing.Point(125, 113);
            this.cmbMaterial.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(118, 21);
            this.cmbMaterial.TabIndex = 19;
            this.cmbMaterial.SelectedIndexChanged += new System.EventHandler(this.cmbMaterial_SelectedIndexChanged);
            // 
            // MaterialPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 580);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MaterialPanel";
            this.Text = "Material";
            this.Shown += new System.EventHandler(this.VariablesInitialize);
            ((System.ComponentModel.ISupportInitialize)(this.nrRedColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrGreenColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrBlueColor)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateFigure;
        private System.Windows.Forms.TextBox txtMaterialName;
        private System.Windows.Forms.Label lblRed;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblGreen;
        private System.Windows.Forms.Label lblBlue;
        private System.Windows.Forms.NumericUpDown nrRedColor;
        private System.Windows.Forms.NumericUpDown nrGreenColor;
        private System.Windows.Forms.NumericUpDown nrBlueColor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblExceptionError;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.TextBox txtBlur;
        private System.Windows.Forms.Label lblBlur;
        private System.Windows.Forms.Label label2;
    }
}