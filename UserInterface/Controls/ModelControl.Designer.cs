namespace UserInterface.Controls
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
            this.txtModelName = new System.Windows.Forms.TextBox();
            this.lblModelFigure = new System.Windows.Forms.Label();
            this.lblModelMaterial = new System.Windows.Forms.Label();
            this.pBoxPreview = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDeleteModel
            // 
            this.btnDeleteModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteModel.Location = new System.Drawing.Point(267, 64);
            this.btnDeleteModel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteModel.Name = "btnDeleteModel";
            this.btnDeleteModel.Size = new System.Drawing.Size(100, 30);
            this.btnDeleteModel.TabIndex = 8;
            this.btnDeleteModel.Text = "Delete";
            this.btnDeleteModel.UseVisualStyleBackColor = true;
            this.btnDeleteModel.Click += new System.EventHandler(this.btnDeleteModel_Click);
            // 
            // btnEditModelName
            // 
            this.btnEditModelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditModelName.Location = new System.Drawing.Point(267, 27);
            this.btnEditModelName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditModelName.Name = "btnEditModelName";
            this.btnEditModelName.Size = new System.Drawing.Size(100, 30);
            this.btnEditModelName.TabIndex = 7;
            this.btnEditModelName.Text = "Edit";
            this.btnEditModelName.UseVisualStyleBackColor = true;
            this.btnEditModelName.Click += new System.EventHandler(this.btnEditModelName_Click);
            // 
            // txtModelName
            // 
            this.txtModelName.BackColor = System.Drawing.SystemColors.Control;
            this.txtModelName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtModelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelName.Location = new System.Drawing.Point(140, 30);
            this.txtModelName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtModelName.Name = "txtModelName";
            this.txtModelName.ReadOnly = true;
            this.txtModelName.Size = new System.Drawing.Size(120, 23);
            this.txtModelName.TabIndex = 6;
            this.txtModelName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ClientPressEnter);
            this.txtModelName.Leave += new System.EventHandler(this.ClientLeaves);
            // 
            // lblModelFigure
            // 
            this.lblModelFigure.AutoSize = true;
            this.lblModelFigure.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelFigure.Location = new System.Drawing.Point(159, 64);
            this.lblModelFigure.Name = "lblModelFigure";
            this.lblModelFigure.Size = new System.Drawing.Size(83, 29);
            this.lblModelFigure.TabIndex = 9;
            this.lblModelFigure.Text = "Figure";
            // 
            // lblModelMaterial
            // 
            this.lblModelMaterial.AutoSize = true;
            this.lblModelMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelMaterial.Location = new System.Drawing.Point(159, 94);
            this.lblModelMaterial.Name = "lblModelMaterial";
            this.lblModelMaterial.Size = new System.Drawing.Size(99, 29);
            this.lblModelMaterial.TabIndex = 10;
            this.lblModelMaterial.Text = "material";
            // 
            // pBoxPreview
            // 
            this.pBoxPreview.Image = global::UserInterface.Properties.Resources.LoginIcon;
            this.pBoxPreview.Location = new System.Drawing.Point(4, 27);
            this.pBoxPreview.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pBoxPreview.Name = "pBoxPreview";
            this.pBoxPreview.Size = new System.Drawing.Size(129, 90);
            this.pBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxPreview.TabIndex = 11;
            this.pBoxPreview.TabStop = false;
            // 
            // ModelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pBoxPreview);
            this.Controls.Add(this.lblModelMaterial);
            this.Controls.Add(this.lblModelFigure);
            this.Controls.Add(this.btnDeleteModel);
            this.Controls.Add(this.btnEditModelName);
            this.Controls.Add(this.txtModelName);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ModelControl";
            this.Size = new System.Drawing.Size(388, 145);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeleteModel;
        private System.Windows.Forms.Button btnEditModelName;
        private System.Windows.Forms.TextBox txtModelName;
        private System.Windows.Forms.Label lblModelFigure;
        private System.Windows.Forms.Label lblModelMaterial;
        private System.Windows.Forms.PictureBox pBoxPreview;
    }
}
