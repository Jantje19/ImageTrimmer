namespace ImageTrimmer
{
				partial class formMain
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
			this.btnStart = new System.Windows.Forms.Button();
			this.ofdImageSelector = new System.Windows.Forms.OpenFileDialog();
			this.btnCancel = new System.Windows.Forms.Button();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.lblProgress = new System.Windows.Forms.Label();
			this.gbBackground = new System.Windows.Forms.GroupBox();
			this.rbBgBlack = new System.Windows.Forms.RadioButton();
			this.rbBgWhite = new System.Windows.Forms.RadioButton();
			this.pbMain = new System.Windows.Forms.PictureBox();
			this.panelImageContainer = new System.Windows.Forms.Panel();
			this.gbBackground.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
			this.panelImageContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnStart
			// 
			this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStart.Location = new System.Drawing.Point(12, 280);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(189, 23);
			this.btnStart.TabIndex = 1;
			this.btnStart.Text = "Do the stuff!";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Enabled = false;
			this.btnCancel.Location = new System.Drawing.Point(207, 280);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(64, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// progressBar
			// 
			this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar.Location = new System.Drawing.Point(12, 309);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(219, 23);
			this.progressBar.Step = 1;
			this.progressBar.TabIndex = 3;
			// 
			// lblProgress
			// 
			this.lblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblProgress.AutoSize = true;
			this.lblProgress.Location = new System.Drawing.Point(237, 314);
			this.lblProgress.Name = "lblProgress";
			this.lblProgress.Size = new System.Drawing.Size(21, 13);
			this.lblProgress.TabIndex = 4;
			this.lblProgress.Text = "0%";
			// 
			// gbBackground
			// 
			this.gbBackground.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbBackground.Controls.Add(this.rbBgBlack);
			this.gbBackground.Controls.Add(this.rbBgWhite);
			this.gbBackground.Location = new System.Drawing.Point(12, 230);
			this.gbBackground.Name = "gbBackground";
			this.gbBackground.Size = new System.Drawing.Size(258, 44);
			this.gbBackground.TabIndex = 5;
			this.gbBackground.TabStop = false;
			this.gbBackground.Text = "Background color";
			// 
			// rbBgBlack
			// 
			this.rbBgBlack.AutoSize = true;
			this.rbBgBlack.Location = new System.Drawing.Point(66, 19);
			this.rbBgBlack.Name = "rbBgBlack";
			this.rbBgBlack.Size = new System.Drawing.Size(52, 17);
			this.rbBgBlack.TabIndex = 1;
			this.rbBgBlack.TabStop = true;
			this.rbBgBlack.Text = "Black";
			this.rbBgBlack.UseVisualStyleBackColor = true;
			// 
			// rbBgWhite
			// 
			this.rbBgWhite.AutoSize = true;
			this.rbBgWhite.Checked = true;
			this.rbBgWhite.Location = new System.Drawing.Point(6, 19);
			this.rbBgWhite.Name = "rbBgWhite";
			this.rbBgWhite.Size = new System.Drawing.Size(53, 17);
			this.rbBgWhite.TabIndex = 0;
			this.rbBgWhite.TabStop = true;
			this.rbBgWhite.Text = "White";
			this.rbBgWhite.UseVisualStyleBackColor = true;
			// 
			// pbMain
			// 
			this.pbMain.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.pbMain.Location = new System.Drawing.Point(0, 0);
			this.pbMain.Name = "pbMain";
			this.pbMain.Size = new System.Drawing.Size(258, 211);
			this.pbMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbMain.TabIndex = 0;
			this.pbMain.TabStop = false;
			// 
			// panelImageContainer
			// 
			this.panelImageContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelImageContainer.AutoScroll = true;
			this.panelImageContainer.Controls.Add(this.pbMain);
			this.panelImageContainer.Location = new System.Drawing.Point(12, 12);
			this.panelImageContainer.Name = "panelImageContainer";
			this.panelImageContainer.Size = new System.Drawing.Size(258, 211);
			this.panelImageContainer.TabIndex = 6;
			// 
			// formMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(283, 340);
			this.Controls.Add(this.panelImageContainer);
			this.Controls.Add(this.gbBackground);
			this.Controls.Add(this.lblProgress);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnStart);
			this.Name = "formMain";
			this.Text = "Image Trimmer";
			this.gbBackground.ResumeLayout(false);
			this.gbBackground.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
			this.panelImageContainer.ResumeLayout(false);
			this.panelImageContainer.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

								}

								#endregion
								private System.Windows.Forms.Button btnStart;
								private System.Windows.Forms.OpenFileDialog ofdImageSelector;
								private System.Windows.Forms.Button btnCancel;
								private System.Windows.Forms.ProgressBar progressBar;
								private System.Windows.Forms.Label lblProgress;
								private System.Windows.Forms.GroupBox gbBackground;
								private System.Windows.Forms.RadioButton rbBgWhite;
								private System.Windows.Forms.RadioButton rbBgBlack;
		private System.Windows.Forms.PictureBox pbMain;
		private System.Windows.Forms.Panel panelImageContainer;
	}
}

