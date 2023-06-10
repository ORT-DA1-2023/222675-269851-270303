namespace Render3D.UserInterface.Panels
{
    partial class ScenePanel
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnCreateScene = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 300);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(316, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "You should already have at least one model";
            // 
            // btnCreateScene
            // 
            this.btnCreateScene.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCreateScene.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateScene.Location = new System.Drawing.Point(31, 189);
            this.btnCreateScene.Name = "btnCreateScene";
            this.btnCreateScene.Size = new System.Drawing.Size(324, 98);
            this.btnCreateScene.TabIndex = 3;
            this.btnCreateScene.Text = "Click here to create a new scene";
            this.btnCreateScene.UseVisualStyleBackColor = false;
            this.btnCreateScene.Click += new System.EventHandler(this.BtnCreateScene_Click);
            // 
            // ScenePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 580);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCreateScene);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScenePanel";
            this.Text = "ScenePanel";
            this.Shown += new System.EventHandler(this.VariableInitialize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCreateScene;
    }
}