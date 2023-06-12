namespace UserInterface
{
    partial class LogUI
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
            this.lblRenderTime = new System.Windows.Forms.Label();
            this.lblAverageTimeInSeconds = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMostRenderedUser = new System.Windows.Forms.Label();
            this.DgvLogs = new System.Windows.Forms.DataGridView();
            this.User = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RenderTimeInSeconds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RenderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeWindow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SceneName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberElementsInScene = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GoBackLog = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRenderTime
            // 
            this.lblRenderTime.AutoSize = true;
            this.lblRenderTime.Location = new System.Drawing.Point(717, 102);
            this.lblRenderTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRenderTime.Name = "lblRenderTime";
            this.lblRenderTime.Size = new System.Drawing.Size(195, 16);
            this.lblRenderTime.TabIndex = 0;
            this.lblRenderTime.Text = "Average render time (seconds):";
            // 
            // lblAverageTimeInSeconds
            // 
            this.lblAverageTimeInSeconds.AutoSize = true;
            this.lblAverageTimeInSeconds.Location = new System.Drawing.Point(931, 102);
            this.lblAverageTimeInSeconds.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAverageTimeInSeconds.Name = "lblAverageTimeInSeconds";
            this.lblAverageTimeInSeconds.Size = new System.Drawing.Size(14, 16);
            this.lblAverageTimeInSeconds.TabIndex = 1;
            this.lblAverageTimeInSeconds.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(717, 134);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Average render time (minutes):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(931, 134);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(717, 69);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "User who rendered the most:";
            // 
            // lblMostRenderedUser
            // 
            this.lblMostRenderedUser.AutoSize = true;
            this.lblMostRenderedUser.Location = new System.Drawing.Point(916, 69);
            this.lblMostRenderedUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMostRenderedUser.Name = "lblMostRenderedUser";
            this.lblMostRenderedUser.Size = new System.Drawing.Size(11, 16);
            this.lblMostRenderedUser.TabIndex = 5;
            this.lblMostRenderedUser.Text = "-";
            // 
            // DgvLogs
            // 
            this.DgvLogs.AllowUserToAddRows = false;
            this.DgvLogs.AllowUserToDeleteRows = false;
            this.DgvLogs.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DgvLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvLogs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.User,
            this.RenderTimeInSeconds,
            this.RenderDate,
            this.TimeWindow,
            this.SceneName,
            this.NumberElementsInScene});
            this.DgvLogs.Location = new System.Drawing.Point(117, 230);
            this.DgvLogs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DgvLogs.Name = "DgvLogs";
            this.DgvLogs.ReadOnly = true;
            this.DgvLogs.RowHeadersWidth = 51;
            this.DgvLogs.Size = new System.Drawing.Size(863, 226);
            this.DgvLogs.TabIndex = 6;
            // 
            // User
            // 
            this.User.HeaderText = "User";
            this.User.MinimumWidth = 6;
            this.User.Name = "User";
            this.User.ReadOnly = true;
            this.User.Width = 125;
            // 
            // RenderTimeInSeconds
            // 
            this.RenderTimeInSeconds.HeaderText = "Render time in seconds";
            this.RenderTimeInSeconds.MinimumWidth = 6;
            this.RenderTimeInSeconds.Name = "RenderTimeInSeconds";
            this.RenderTimeInSeconds.ReadOnly = true;
            this.RenderTimeInSeconds.Width = 125;
            // 
            // RenderDate
            // 
            this.RenderDate.HeaderText = "Render Date";
            this.RenderDate.MinimumWidth = 6;
            this.RenderDate.Name = "RenderDate";
            this.RenderDate.ReadOnly = true;
            this.RenderDate.Width = 125;
            // 
            // TimeWindow
            // 
            this.TimeWindow.HeaderText = "Time window with the last render";
            this.TimeWindow.MinimumWidth = 6;
            this.TimeWindow.Name = "TimeWindow";
            this.TimeWindow.ReadOnly = true;
            this.TimeWindow.Width = 125;
            // 
            // SceneName
            // 
            this.SceneName.HeaderText = "Scene name";
            this.SceneName.MinimumWidth = 6;
            this.SceneName.Name = "SceneName";
            this.SceneName.ReadOnly = true;
            this.SceneName.Width = 125;
            // 
            // NumberElementsInScene
            // 
            this.NumberElementsInScene.HeaderText = "Number of elements in scene";
            this.NumberElementsInScene.MinimumWidth = 6;
            this.NumberElementsInScene.Name = "NumberElementsInScene";
            this.NumberElementsInScene.ReadOnly = true;
            this.NumberElementsInScene.Width = 125;
            // 
            // GoBackLog
            // 
            this.GoBackLog.BackColor = System.Drawing.Color.Yellow;
            this.GoBackLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.GoBackLog.Location = new System.Drawing.Point(1025, 542);
            this.GoBackLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GoBackLog.Name = "GoBackLog";
            this.GoBackLog.Size = new System.Drawing.Size(113, 54);
            this.GoBackLog.TabIndex = 7;
            this.GoBackLog.Text = "Back";
            this.GoBackLog.UseVisualStyleBackColor = false;
            this.GoBackLog.Click += new System.EventHandler(this.GoBackLog_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 39);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 29);
            this.label4.TabIndex = 8;
            this.label4.Text = "Log History";
            // 
            // LogUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 666);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.GoBackLog);
            this.Controls.Add(this.DgvLogs);
            this.Controls.Add(this.lblMostRenderedUser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAverageTimeInSeconds);
            this.Controls.Add(this.lblRenderTime);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "LogUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log History";
            ((System.ComponentModel.ISupportInitialize)(this.DgvLogs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRenderTime;
        private System.Windows.Forms.Label lblAverageTimeInSeconds;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMostRenderedUser;
        private System.Windows.Forms.DataGridView DgvLogs;
        private System.Windows.Forms.DataGridViewTextBoxColumn User;
        private System.Windows.Forms.DataGridViewTextBoxColumn RenderTimeInSeconds;
        private System.Windows.Forms.DataGridViewTextBoxColumn RenderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeWindow;
        private System.Windows.Forms.DataGridViewTextBoxColumn SceneName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberElementsInScene;
        private System.Windows.Forms.Button GoBackLog;
        private System.Windows.Forms.Label label4;
    }
}