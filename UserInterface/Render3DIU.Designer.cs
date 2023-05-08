namespace Render3D.UserInterface
{
    partial class Render3DIU
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
            this.pnLayout = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnLayout
            // 
            this.pnLayout.AutoSize = true;
            this.pnLayout.Location = new System.Drawing.Point(0, 0);
            this.pnLayout.Name = "pnLayout";
            this.pnLayout.Size = new System.Drawing.Size(1000, 580);
            this.pnLayout.TabIndex = 0;
            // 
            // Render3DIU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 541);
            this.Controls.Add(this.pnLayout);
            this.IsMdiContainer = true;
            this.Name = "Render3DIU";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Render3D";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnLayout;
    }
}