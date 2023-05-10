namespace Render3D.UserInterface.Controls
{ 
    partial class SceneControl
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
            this.lblSceneName = new System.Windows.Forms.Label();
            this.lblSceneModificationDate = new System.Windows.Forms.Label();
            this.pBoxPreview = new System.Windows.Forms.PictureBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSceneName
            // 
            this.lblSceneName.AutoSize = true;
            this.lblSceneName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSceneName.Location = new System.Drawing.Point(148, 18);
            this.lblSceneName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSceneName.Name = "lblSceneName";
            this.lblSceneName.Size = new System.Drawing.Size(73, 29);
            this.lblSceneName.TabIndex = 0;
            this.lblSceneName.Text = "name";
            // 
            // lblSceneModificationDate
            // 
            this.lblSceneModificationDate.AutoSize = true;
            this.lblSceneModificationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSceneModificationDate.Location = new System.Drawing.Point(148, 73);
            this.lblSceneModificationDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSceneModificationDate.Name = "lblSceneModificationDate";
            this.lblSceneModificationDate.Size = new System.Drawing.Size(50, 25);
            this.lblSceneModificationDate.TabIndex = 1;
            this.lblSceneModificationDate.Text = "date";
            // 
            // pBoxPreview
            // 
            this.pBoxPreview.Image = global::UserInterface.Properties.Resources.SceneWithoutPreview;
            this.pBoxPreview.Location = new System.Drawing.Point(4, 18);
            this.pBoxPreview.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pBoxPreview.Name = "pBoxPreview";
            this.pBoxPreview.Size = new System.Drawing.Size(136, 92);
            this.pBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxPreview.TabIndex = 3;
            this.pBoxPreview.TabStop = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(312, 21);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(76, 37);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(312, 66);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(76, 37);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // SceneControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.pBoxPreview);
            this.Controls.Add(this.lblSceneModificationDate);
            this.Controls.Add(this.lblSceneName);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SceneControl";
            this.Size = new System.Drawing.Size(388, 129);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSceneName;
        private System.Windows.Forms.Label lblSceneModificationDate;
        private System.Windows.Forms.PictureBox pBoxPreview;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
    }
}
