namespace Render3D.UserInterface.Panels
{
    partial class ModelPanel
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
            this.label6 = new System.Windows.Forms.Label();
            this.lstMaterial = new System.Windows.Forms.ComboBox();
            this.lstFigure = new System.Windows.Forms.ComboBox();
            this.lblExceptionError = new System.Windows.Forms.Label();
            this.lblModelName = new System.Windows.Forms.Label();
            this.txtModelName = new System.Windows.Forms.TextBox();
            this.checkGeneratePreview = new System.Windows.Forms.CheckBox();
            this.btnCreateFigure = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lstMaterial);
            this.panel1.Controls.Add(this.lstFigure);
            this.panel1.Controls.Add(this.lblExceptionError);
            this.panel1.Controls.Add(this.lblModelName);
            this.panel1.Controls.Add(this.txtModelName);
            this.panel1.Controls.Add(this.checkGeneratePreview);
            this.panel1.Controls.Add(this.btnCreateFigure);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 551);
            this.panel1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Green;
            this.label6.Location = new System.Drawing.Point(182, 399);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Successfully added";
            this.label6.Visible = false;
            // 
            // lstMaterial
            // 
            this.lstMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMaterial.FormattingEnabled = true;
            this.lstMaterial.Location = new System.Drawing.Point(81, 298);
            this.lstMaterial.Name = "lstMaterial";
            this.lstMaterial.Size = new System.Drawing.Size(212, 32);
            this.lstMaterial.TabIndex = 20;
            // 
            // lstFigure
            // 
            this.lstFigure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstFigure.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFigure.FormattingEnabled = true;
            this.lstFigure.Location = new System.Drawing.Point(81, 177);
            this.lstFigure.Name = "lstFigure";
            this.lstFigure.Size = new System.Drawing.Size(212, 32);
            this.lstFigure.TabIndex = 19;
            // 
            // lblExceptionError
            // 
            this.lblExceptionError.AutoSize = true;
            this.lblExceptionError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExceptionError.ForeColor = System.Drawing.Color.Red;
            this.lblExceptionError.Location = new System.Drawing.Point(78, 396);
            this.lblExceptionError.Name = "lblExceptionError";
            this.lblExceptionError.Size = new System.Drawing.Size(35, 16);
            this.lblExceptionError.TabIndex = 18;
            this.lblExceptionError.Text = "error";
            // 
            // lblModelName
            // 
            this.lblModelName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblModelName.AutoSize = true;
            this.lblModelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelName.Location = new System.Drawing.Point(77, 83);
            this.lblModelName.Name = "lblModelName";
            this.lblModelName.Size = new System.Drawing.Size(66, 24);
            this.lblModelName.TabIndex = 10;
            this.lblModelName.Text = "Name:";
            // 
            // txtModelName
            // 
            this.txtModelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelName.Location = new System.Drawing.Point(81, 109);
            this.txtModelName.Margin = new System.Windows.Forms.Padding(2);
            this.txtModelName.Name = "txtModelName";
            this.txtModelName.Size = new System.Drawing.Size(212, 28);
            this.txtModelName.TabIndex = 9;
            // 
            // checkGeneratePreview
            // 
            this.checkGeneratePreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkGeneratePreview.AutoSize = true;
            this.checkGeneratePreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkGeneratePreview.Location = new System.Drawing.Point(81, 418);
            this.checkGeneratePreview.Name = "checkGeneratePreview";
            this.checkGeneratePreview.Size = new System.Drawing.Size(178, 28);
            this.checkGeneratePreview.TabIndex = 7;
            this.checkGeneratePreview.Text = "Generate preview";
            this.checkGeneratePreview.UseMnemonic = false;
            this.checkGeneratePreview.UseVisualStyleBackColor = true;
            // 
            // btnCreateFigure
            // 
            this.btnCreateFigure.BackColor = System.Drawing.Color.Yellow;
            this.btnCreateFigure.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCreateFigure.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateFigure.Location = new System.Drawing.Point(0, 473);
            this.btnCreateFigure.Margin = new System.Windows.Forms.Padding(0);
            this.btnCreateFigure.Name = "btnCreateFigure";
            this.btnCreateFigure.Size = new System.Drawing.Size(380, 78);
            this.btnCreateFigure.TabIndex = 8;
            this.btnCreateFigure.Text = "Create";
            this.btnCreateFigure.UseVisualStyleBackColor = false;
            this.btnCreateFigure.Click += new System.EventHandler(this.BtnCreateModel_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic);
            this.label5.Location = new System.Drawing.Point(81, 333);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(217, 34);
            this.label5.TabIndex = 6;
            this.label5.Text = "Tip: if the list is empty you should\r\n start by creating a material";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(77, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 32);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tip: if the list is empty you should\r\n start by creating a figure";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(77, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Chose a material";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(77, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Chose a figure";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Create a new model";
            // 
            // ModelPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(380, 551);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ModelPanel";
            this.Text = "Models";
            this.Shown += new System.EventHandler(this.VariableInitialize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkGeneratePreview;
        private System.Windows.Forms.Button btnCreateFigure;
        private System.Windows.Forms.Label lblModelName;
        private System.Windows.Forms.TextBox txtModelName;
        private System.Windows.Forms.Label lblExceptionError;
        private System.Windows.Forms.ComboBox lstFigure;
        private System.Windows.Forms.ComboBox lstMaterial;
        private System.Windows.Forms.Label label6;
    }
}