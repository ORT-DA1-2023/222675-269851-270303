namespace UserInterface.Controls
{
    partial class FigureControl
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
            this.lblFigureRadius = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.pboxImage = new System.Windows.Forms.PictureBox();
            this.txtFigureName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pboxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFigureRadius
            // 
            this.lblFigureRadius.AutoSize = true;
            this.lblFigureRadius.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFigureRadius.Location = new System.Drawing.Point(95, 61);
            this.lblFigureRadius.Name = "lblFigureRadius";
            this.lblFigureRadius.Size = new System.Drawing.Size(115, 24);
            this.lblFigureRadius.TabIndex = 1;
            this.lblFigureRadius.Text = "figureRadius";
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(209, 18);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(70, 30);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(209, 55);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(70, 30);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // pboxImage
            // 
            this.pboxImage.Image = global::UserInterface.Properties.Resources.Sphere;
            this.pboxImage.InitialImage = global::UserInterface.Properties.Resources.Sphere;
            this.pboxImage.Location = new System.Drawing.Point(0, 3);
            this.pboxImage.Name = "pboxImage";
            this.pboxImage.Size = new System.Drawing.Size(89, 86);
            this.pboxImage.TabIndex = 4;
            this.pboxImage.TabStop = false;
            // 
            // txtFigureName
            // 
            this.txtFigureName.AcceptsReturn = true;
            this.txtFigureName.BackColor = System.Drawing.SystemColors.Control;
            this.txtFigureName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFigureName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFigureName.Location = new System.Drawing.Point(95, 26);
            this.txtFigureName.Name = "txtFigureName";
            this.txtFigureName.ReadOnly = true;
            this.txtFigureName.Size = new System.Drawing.Size(108, 22);
            this.txtFigureName.TabIndex = 5;
            this.txtFigureName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ClientPressEnter);
            this.txtFigureName.Leave += new System.EventHandler(this.ClientLeaves);
            // 
            // FigureControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtFigureName);
            this.Controls.Add(this.pboxImage);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lblFigureRadius);
            this.Name = "FigureControl";
            this.Size = new System.Drawing.Size(291, 105);
            ((System.ComponentModel.ISupportInitialize)(this.pboxImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblFigureRadius;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.PictureBox pboxImage;
        private System.Windows.Forms.TextBox txtFigureName;
    }
}
