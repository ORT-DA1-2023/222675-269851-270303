﻿namespace Render3D.UserInterface.Panels
{
    partial class FigurePanel
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
            this.txtFigureName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFigureRadius = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCreateFigure = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblExceptionError = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCorrectlyAdded = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFigureName
            // 
            this.txtFigureName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFigureName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFigureName.Location = new System.Drawing.Point(151, 130);
            this.txtFigureName.Name = "txtFigureName";
            this.txtFigureName.Size = new System.Drawing.Size(191, 29);
            this.txtFigureName.TabIndex = 3;
            this.txtFigureName.TextChanged += new System.EventHandler(this.txtFigureName_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(64, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Radius:";
            // 
            // txtFigureRadius
            // 
            this.txtFigureRadius.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFigureRadius.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFigureRadius.Location = new System.Drawing.Point(151, 239);
            this.txtFigureRadius.Name = "txtFigureRadius";
            this.txtFigureRadius.Size = new System.Drawing.Size(191, 29);
            this.txtFigureRadius.TabIndex = 4;
            this.txtFigureRadius.TextChanged += new System.EventHandler(this.txtFigureRadius_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(64, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name:";
            // 
            // btnCreateFigure
            // 
            this.btnCreateFigure.BackColor = System.Drawing.Color.Yellow;
            this.btnCreateFigure.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCreateFigure.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateFigure.Location = new System.Drawing.Point(0, 473);
            this.btnCreateFigure.Name = "btnCreateFigure";
            this.btnCreateFigure.Size = new System.Drawing.Size(380, 78);
            this.btnCreateFigure.TabIndex = 5;
            this.btnCreateFigure.Text = "Create";
            this.btnCreateFigure.UseVisualStyleBackColor = false;
            this.btnCreateFigure.Click += new System.EventHandler(this.BtnCreateFigure_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Create a new figure";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblExceptionError
            // 
            this.lblExceptionError.AutoSize = true;
            this.lblExceptionError.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.75F);
            this.lblExceptionError.ForeColor = System.Drawing.Color.DarkRed;
            this.lblExceptionError.Location = new System.Drawing.Point(65, 337);
            this.lblExceptionError.Name = "lblExceptionError";
            this.lblExceptionError.Size = new System.Drawing.Size(42, 20);
            this.lblExceptionError.TabIndex = 18;
            this.lblExceptionError.Text = "error";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblCorrectlyAdded);
            this.panel1.Controls.Add(this.lblExceptionError);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnCreateFigure);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtFigureRadius);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtFigureName);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 551);
            this.panel1.TabIndex = 6;
            // 
            // lblCorrectlyAdded
            // 
            this.lblCorrectlyAdded.AutoSize = true;
            this.lblCorrectlyAdded.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblCorrectlyAdded.ForeColor = System.Drawing.Color.Green;
            this.lblCorrectlyAdded.Location = new System.Drawing.Point(68, 357);
            this.lblCorrectlyAdded.Name = "lblCorrectlyAdded";
            this.lblCorrectlyAdded.Size = new System.Drawing.Size(112, 18);
            this.lblCorrectlyAdded.TabIndex = 19;
            this.lblCorrectlyAdded.Text = "Correctly added";
            this.lblCorrectlyAdded.Visible = false;
            // 
            // FigurePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 580);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FigurePanel";
            this.Text = "Figure";
            this.Shown += new System.EventHandler(this.VariablesInitialize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtFigureName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFigureRadius;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCreateFigure;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblExceptionError;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCorrectlyAdded;
    }
}