﻿namespace UserInterface.Controls
{
    partial class MaterialControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblRedColor = new System.Windows.Forms.Label();
            this.lblGreenColor = new System.Windows.Forms.Label();
            this.lblBlueColor = new System.Windows.Forms.Label();
            this.txtMaterialName = new System.Windows.Forms.TextBox();
            this.btnEditMaterialName = new System.Windows.Forms.Button();
            this.btnDeleteMaterial = new System.Windows.Forms.Button();
            this.pBoxMaterial = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxMaterial)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRedColor
            // 
            this.lblRedColor.AutoSize = true;
            this.lblRedColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRedColor.ForeColor = System.Drawing.Color.Red;
            this.lblRedColor.Location = new System.Drawing.Point(30, 70);
            this.lblRedColor.Margin = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.lblRedColor.Name = "lblRedColor";
            this.lblRedColor.Size = new System.Drawing.Size(43, 20);
            this.lblRedColor.TabIndex = 0;
            this.lblRedColor.Text = "Red:";
            // 
            // lblGreenColor
            // 
            this.lblGreenColor.AutoSize = true;
            this.lblGreenColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGreenColor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblGreenColor.Location = new System.Drawing.Point(108, 70);
            this.lblGreenColor.Margin = new System.Windows.Forms.Padding(30, 0, 2, 0);
            this.lblGreenColor.Name = "lblGreenColor";
            this.lblGreenColor.Size = new System.Drawing.Size(58, 20);
            this.lblGreenColor.TabIndex = 1;
            this.lblGreenColor.Text = "Green:";
            // 
            // lblBlueColor
            // 
            this.lblBlueColor.AutoSize = true;
            this.lblBlueColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlueColor.ForeColor = System.Drawing.Color.Blue;
            this.lblBlueColor.Location = new System.Drawing.Point(188, 70);
            this.lblBlueColor.Margin = new System.Windows.Forms.Padding(30, 0, 2, 0);
            this.lblBlueColor.Name = "lblBlueColor";
            this.lblBlueColor.Size = new System.Drawing.Size(45, 20);
            this.lblBlueColor.TabIndex = 2;
            this.lblBlueColor.Text = "Blue:";
            // 
            // txtMaterialName
            // 
            this.txtMaterialName.BackColor = System.Drawing.SystemColors.Control;
            this.txtMaterialName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMaterialName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterialName.Location = new System.Drawing.Point(97, 16);
            this.txtMaterialName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMaterialName.Name = "txtMaterialName";
            this.txtMaterialName.ReadOnly = true;
            this.txtMaterialName.Size = new System.Drawing.Size(103, 19);
            this.txtMaterialName.TabIndex = 3;
            this.txtMaterialName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.clientPressEnter);
            this.txtMaterialName.Leave += new System.EventHandler(this.ClientLeaves);
            // 
            // btnEditMaterialName
            // 
            this.btnEditMaterialName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditMaterialName.Location = new System.Drawing.Point(204, 11);
            this.btnEditMaterialName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEditMaterialName.Name = "btnEditMaterialName";
            this.btnEditMaterialName.Size = new System.Drawing.Size(75, 24);
            this.btnEditMaterialName.TabIndex = 4;
            this.btnEditMaterialName.Text = "Edit";
            this.btnEditMaterialName.UseVisualStyleBackColor = true;
            this.btnEditMaterialName.Click += new System.EventHandler(this.btnEditMaterialName_Click);
            // 
            // btnDeleteMaterial
            // 
            this.btnDeleteMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteMaterial.Location = new System.Drawing.Point(204, 41);
            this.btnDeleteMaterial.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDeleteMaterial.Name = "btnDeleteMaterial";
            this.btnDeleteMaterial.Size = new System.Drawing.Size(75, 24);
            this.btnDeleteMaterial.TabIndex = 5;
            this.btnDeleteMaterial.Text = "Delete";
            this.btnDeleteMaterial.UseVisualStyleBackColor = true;
            this.btnDeleteMaterial.Click += new System.EventHandler(this.BtnDeleteMaterial_Click);
            // 
            // pBoxMaterial
            // 
            this.pBoxMaterial.Location = new System.Drawing.Point(17, 14);
            this.pBoxMaterial.Name = "pBoxMaterial";
            this.pBoxMaterial.Size = new System.Drawing.Size(56, 53);
            this.pBoxMaterial.TabIndex = 6;
            this.pBoxMaterial.TabStop = false;
            // 
            // MaterialControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pBoxMaterial);
            this.Controls.Add(this.btnDeleteMaterial);
            this.Controls.Add(this.btnEditMaterialName);
            this.Controls.Add(this.txtMaterialName);
            this.Controls.Add(this.lblBlueColor);
            this.Controls.Add(this.lblGreenColor);
            this.Controls.Add(this.lblRedColor);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MaterialControl";
            this.Size = new System.Drawing.Size(291, 105);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxMaterial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRedColor;
        private System.Windows.Forms.Label lblGreenColor;
        private System.Windows.Forms.Label lblBlueColor;
        private System.Windows.Forms.TextBox txtMaterialName;
        private System.Windows.Forms.Button btnEditMaterialName;
        private System.Windows.Forms.Button btnDeleteMaterial;
        private System.Windows.Forms.PictureBox pBoxMaterial;
    }
}
