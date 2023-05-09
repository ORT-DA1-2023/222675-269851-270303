namespace Render3D.UserInterface.Controls
{
    partial class ModelControl
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
            this.btnDeleteModel = new System.Windows.Forms.Button();
            this.btnEditModelName = new System.Windows.Forms.Button();
            this.lblModelFigure = new System.Windows.Forms.Label();
            this.lblModelMaterial = new System.Windows.Forms.Label();
            this.pBoxPreview = new System.Windows.Forms.PictureBox();
            this.lblModelName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDeleteModel
            // 
            this.btnDeleteModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteModel.Location = new System.Drawing.Point(200, 52);
            this.btnDeleteModel.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteModel.Name = "btnDeleteModel";
            this.btnDeleteModel.Size = new System.Drawing.Size(75, 24);
            this.btnDeleteModel.TabIndex = 8;
            this.btnDeleteModel.Text = "Delete";
            this.btnDeleteModel.UseVisualStyleBackColor = true;
            this.btnDeleteModel.Click += new System.EventHandler(this.BtnDeleteModel_Click);
            // 
            // btnEditModelName
            // 
            this.btnEditModelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditModelName.Location = new System.Drawing.Point(200, 22);
            this.btnEditModelName.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditModelName.Name = "btnEditModelName";
            this.btnEditModelName.Size = new System.Drawing.Size(75, 24);
            this.btnEditModelName.TabIndex = 7;
            this.btnEditModelName.Text = "Edit";
            this.btnEditModelName.UseVisualStyleBackColor = true;
            this.btnEditModelName.Click += new System.EventHandler(this.BtnEditModelName_Click);
            // 
            // lblModelFigure
            // 
            this.lblModelFigure.AutoSize = true;
            this.lblModelFigure.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelFigure.Location = new System.Drawing.Point(119, 52);
            this.lblModelFigure.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblModelFigure.Name = "lblModelFigure";
            this.lblModelFigure.Size = new System.Drawing.Size(65, 24);
            this.lblModelFigure.TabIndex = 9;
            this.lblModelFigure.Text = "Figure";
            // 
            // lblModelMaterial
            // 
            this.lblModelMaterial.AutoSize = true;
            this.lblModelMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelMaterial.Location = new System.Drawing.Point(119, 76);
            this.lblModelMaterial.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblModelMaterial.Name = "lblModelMaterial";
            this.lblModelMaterial.Size = new System.Drawing.Size(75, 24);
            this.lblModelMaterial.TabIndex = 10;
            this.lblModelMaterial.Text = "material";
            // 
            // pBoxPreview
            // 
            this.pBoxPreview.Image = global::UserInterface.Properties.Resources.Sphere;
            this.pBoxPreview.Location = new System.Drawing.Point(0, 33);
            this.pBoxPreview.Name = "pBoxPreview";
            this.pBoxPreview.Size = new System.Drawing.Size(100, 67);
            this.pBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxPreview.TabIndex = 11;
            this.pBoxPreview.TabStop = false;
            // 
            // lblModelName
            // 
            this.lblModelName.AutoSize = true;
            this.lblModelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelName.Location = new System.Drawing.Point(119, 22);
            this.lblModelName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblModelName.Name = "lblModelName";
            this.lblModelName.Size = new System.Drawing.Size(61, 24);
            this.lblModelName.TabIndex = 12;
            this.lblModelName.Text = "Name";
            // 
            // ModelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblModelName);
            this.Controls.Add(this.pBoxPreview);
            this.Controls.Add(this.lblModelMaterial);
            this.Controls.Add(this.lblModelFigure);
            this.Controls.Add(this.btnDeleteModel);
            this.Controls.Add(this.btnEditModelName);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ModelControl";
            this.Size = new System.Drawing.Size(291, 118);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeleteModel;
        private System.Windows.Forms.Button btnEditModelName;
        private System.Windows.Forms.Label lblModelFigure;
        private System.Windows.Forms.Label lblModelMaterial;
        private System.Windows.Forms.PictureBox pBoxPreview;
        private System.Windows.Forms.Label lblModelName;
    }
}
