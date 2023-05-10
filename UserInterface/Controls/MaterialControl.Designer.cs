namespace Render3D.UserInterface.Controls
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
            this.btnDeleteMaterial = new System.Windows.Forms.Button();
            this.pBoxMaterial = new System.Windows.Forms.PictureBox();
            this.lblMaterialName = new System.Windows.Forms.Label();
            this.btnEditName = new System.Windows.Forms.Button();
            this.lblErrorDeleteMaterial = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxMaterial)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRedColor
            // 
            this.lblRedColor.AutoSize = true;
            this.lblRedColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRedColor.ForeColor = System.Drawing.Color.Red;
            this.lblRedColor.Location = new System.Drawing.Point(40, 86);
            this.lblRedColor.Margin = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.lblRedColor.Name = "lblRedColor";
            this.lblRedColor.Size = new System.Drawing.Size(53, 25);
            this.lblRedColor.TabIndex = 0;
            this.lblRedColor.Text = "Red:";
            // 
            // lblGreenColor
            // 
            this.lblGreenColor.AutoSize = true;
            this.lblGreenColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGreenColor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblGreenColor.Location = new System.Drawing.Point(144, 86);
            this.lblGreenColor.Margin = new System.Windows.Forms.Padding(40, 0, 3, 0);
            this.lblGreenColor.Name = "lblGreenColor";
            this.lblGreenColor.Size = new System.Drawing.Size(72, 25);
            this.lblGreenColor.TabIndex = 1;
            this.lblGreenColor.Text = "Green:";
            // 
            // lblBlueColor
            // 
            this.lblBlueColor.AutoSize = true;
            this.lblBlueColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlueColor.ForeColor = System.Drawing.Color.Blue;
            this.lblBlueColor.Location = new System.Drawing.Point(267, 86);
            this.lblBlueColor.Margin = new System.Windows.Forms.Padding(40, 0, 3, 0);
            this.lblBlueColor.Name = "lblBlueColor";
            this.lblBlueColor.Size = new System.Drawing.Size(57, 25);
            this.lblBlueColor.TabIndex = 2;
            this.lblBlueColor.Text = "Blue:";
            // 
            // btnDeleteMaterial
            // 
            this.btnDeleteMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteMaterial.Location = new System.Drawing.Point(272, 54);
            this.btnDeleteMaterial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteMaterial.Name = "btnDeleteMaterial";
            this.btnDeleteMaterial.Size = new System.Drawing.Size(100, 30);
            this.btnDeleteMaterial.TabIndex = 5;
            this.btnDeleteMaterial.Text = "Delete";
            this.btnDeleteMaterial.UseVisualStyleBackColor = true;
            this.btnDeleteMaterial.Click += new System.EventHandler(this.BtnDeleteMaterial_Click);
            // 
            // pBoxMaterial
            // 
            this.pBoxMaterial.Location = new System.Drawing.Point(23, 17);
            this.pBoxMaterial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pBoxMaterial.Name = "pBoxMaterial";
            this.pBoxMaterial.Size = new System.Drawing.Size(75, 65);
            this.pBoxMaterial.TabIndex = 6;
            this.pBoxMaterial.TabStop = false;
            // 
            // lblMaterialName
            // 
            this.lblMaterialName.AutoSize = true;
            this.lblMaterialName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterialName.Location = new System.Drawing.Point(144, 34);
            this.lblMaterialName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaterialName.Name = "lblMaterialName";
            this.lblMaterialName.Size = new System.Drawing.Size(79, 29);
            this.lblMaterialName.TabIndex = 7;
            this.lblMaterialName.Text = "label1";
            // 
            // btnEditName
            // 
            this.btnEditName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditName.Location = new System.Drawing.Point(272, 20);
            this.btnEditName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditName.Name = "btnEditName";
            this.btnEditName.Size = new System.Drawing.Size(100, 30);
            this.btnEditName.TabIndex = 8;
            this.btnEditName.Text = "Edit";
            this.btnEditName.UseVisualStyleBackColor = true;
            this.btnEditName.Click += new System.EventHandler(this.BtnEditName_Click);
            // 
            // lblErrorDeleteMaterial
            // 
            this.lblErrorDeleteMaterial.AutoSize = true;
            this.lblErrorDeleteMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorDeleteMaterial.ForeColor = System.Drawing.Color.Red;
            this.lblErrorDeleteMaterial.Location = new System.Drawing.Point(153, 0);
            this.lblErrorDeleteMaterial.Margin = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.lblErrorDeleteMaterial.Name = "lblErrorDeleteMaterial";
            this.lblErrorDeleteMaterial.Size = new System.Drawing.Size(52, 25);
            this.lblErrorDeleteMaterial.TabIndex = 9;
            this.lblErrorDeleteMaterial.Text = "error";
            // 
            // MaterialControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblErrorDeleteMaterial);
            this.Controls.Add(this.btnEditName);
            this.Controls.Add(this.lblMaterialName);
            this.Controls.Add(this.pBoxMaterial);
            this.Controls.Add(this.btnDeleteMaterial);
            this.Controls.Add(this.lblBlueColor);
            this.Controls.Add(this.lblGreenColor);
            this.Controls.Add(this.lblRedColor);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MaterialControl";
            this.Size = new System.Drawing.Size(388, 129);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxMaterial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRedColor;
        private System.Windows.Forms.Label lblGreenColor;
        private System.Windows.Forms.Label lblBlueColor;
        private System.Windows.Forms.Button btnDeleteMaterial;
        private System.Windows.Forms.PictureBox pBoxMaterial;
        private System.Windows.Forms.Label lblMaterialName;
        private System.Windows.Forms.Button btnEditName;
        private System.Windows.Forms.Label lblErrorDeleteMaterial;
    }
}
