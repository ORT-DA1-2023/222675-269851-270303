namespace Render3D.UserInterface.Panels
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFigureName = new System.Windows.Forms.TextBox();
            this.txtFigureRadius = new System.Windows.Forms.TextBox();
            this.btnCreateFigure = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNameNotValid = new System.Windows.Forms.Label();
            this.lblRadiusNotValid = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Create a new figure!!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(85, 166);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(85, 301);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Radius:";
            // 
            // txtFigureName
            // 
            this.txtFigureName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFigureName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFigureName.Location = new System.Drawing.Point(201, 160);
            this.txtFigureName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFigureName.Name = "txtFigureName";
            this.txtFigureName.Size = new System.Drawing.Size(253, 34);
            this.txtFigureName.TabIndex = 3;
            // 
            // txtFigureRadius
            // 
            this.txtFigureRadius.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFigureRadius.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFigureRadius.Location = new System.Drawing.Point(201, 294);
            this.txtFigureRadius.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFigureRadius.Name = "txtFigureRadius";
            this.txtFigureRadius.Size = new System.Drawing.Size(253, 34);
            this.txtFigureRadius.TabIndex = 4;
            // 
            // btnCreateFigure
            // 
            this.btnCreateFigure.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCreateFigure.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateFigure.Location = new System.Drawing.Point(0, 582);
            this.btnCreateFigure.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreateFigure.Name = "btnCreateFigure";
            this.btnCreateFigure.Size = new System.Drawing.Size(507, 96);
            this.btnCreateFigure.TabIndex = 5;
            this.btnCreateFigure.Text = "Create!!!";
            this.btnCreateFigure.UseVisualStyleBackColor = true;
            this.btnCreateFigure.Click += new System.EventHandler(this.btnCreateFigure_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblRadiusNotValid);
            this.panel1.Controls.Add(this.lblNameNotValid);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnCreateFigure);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtFigureRadius);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtFigureName);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(507, 678);
            this.panel1.TabIndex = 6;
            // 
            // lblNameNotValid
            // 
            this.lblNameNotValid.AutoSize = true;
            this.lblNameNotValid.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameNotValid.ForeColor = System.Drawing.Color.Red;
            this.lblNameNotValid.Location = new System.Drawing.Point(93, 216);
            this.lblNameNotValid.Name = "lblNameNotValid";
            this.lblNameNotValid.Size = new System.Drawing.Size(0, 29);
            this.lblNameNotValid.TabIndex = 6;
            // 
            // lblRadiusNotValid
            // 
            this.lblRadiusNotValid.AutoSize = true;
            this.lblRadiusNotValid.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRadiusNotValid.ForeColor = System.Drawing.Color.Red;
            this.lblRadiusNotValid.Location = new System.Drawing.Point(93, 370);
            this.lblRadiusNotValid.Name = "lblRadiusNotValid";
            this.lblRadiusNotValid.Size = new System.Drawing.Size(0, 29);
            this.lblRadiusNotValid.TabIndex = 7;
            // 
            // FigurePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 714);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FigurePanel";
            this.Text = "Figure";
            this.Shown += new System.EventHandler(this.variablesInitialize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFigureName;
        private System.Windows.Forms.TextBox txtFigureRadius;
        private System.Windows.Forms.Button btnCreateFigure;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblRadiusNotValid;
        private System.Windows.Forms.Label lblNameNotValid;
    }
}