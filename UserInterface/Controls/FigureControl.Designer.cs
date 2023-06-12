namespace Render3D.UserInterface.Controls
{
    partial class FigureControl
    {
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.pboxImage = new System.Windows.Forms.PictureBox();
            this.lblFigureName = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lblErrorDeleteFigure = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pboxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFigureRadius
            // 
            this.lblFigureRadius.AutoSize = true;
            this.lblFigureRadius.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFigureRadius.Location = new System.Drawing.Point(127, 75);
            this.lblFigureRadius.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFigureRadius.Name = "lblFigureRadius";
            this.lblFigureRadius.Size = new System.Drawing.Size(149, 29);
            this.lblFigureRadius.TabIndex = 1;
            this.lblFigureRadius.Text = "figureRadius";
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(291, 68);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(93, 37);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // pboxImage
            // 
            this.pboxImage.Image = global::UserInterface.Properties.Resources.Sphere;
            this.pboxImage.InitialImage = global::UserInterface.Properties.Resources.Sphere;
            this.pboxImage.Location = new System.Drawing.Point(0, 4);
            this.pboxImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pboxImage.Name = "pboxImage";
            this.pboxImage.Size = new System.Drawing.Size(119, 106);
            this.pboxImage.TabIndex = 4;
            this.pboxImage.TabStop = false;
            // 
            // lblFigureName
            // 
            this.lblFigureName.AutoSize = true;
            this.lblFigureName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFigureName.Location = new System.Drawing.Point(129, 32);
            this.lblFigureName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFigureName.Name = "lblFigureName";
            this.lblFigureName.Size = new System.Drawing.Size(139, 29);
            this.lblFigureName.TabIndex = 5;
            this.lblFigureName.Text = "figureName";
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(291, 30);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(93, 37);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // lblErrorDeleteFigure
            // 
            this.lblErrorDeleteFigure.AutoSize = true;
            this.lblErrorDeleteFigure.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblErrorDeleteFigure.ForeColor = System.Drawing.Color.Red;
            this.lblErrorDeleteFigure.Location = new System.Drawing.Point(118, 0);
            this.lblErrorDeleteFigure.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblErrorDeleteFigure.Name = "lblErrorDeleteFigure";
            this.lblErrorDeleteFigure.Size = new System.Drawing.Size(48, 22);
            this.lblErrorDeleteFigure.TabIndex = 7;
            this.lblErrorDeleteFigure.Text = "error";
            // 
            // FigureControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblErrorDeleteFigure);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lblFigureName);
            this.Controls.Add(this.pboxImage);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblFigureRadius);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FigureControl";
            this.Size = new System.Drawing.Size(388, 129);
            ((System.ComponentModel.ISupportInitialize)(this.pboxImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblFigureRadius;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.PictureBox pboxImage;
        private System.Windows.Forms.Label lblFigureName;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label lblErrorDeleteFigure;
    }
}
