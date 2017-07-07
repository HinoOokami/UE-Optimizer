namespace UE_Optimizer
{
	partial class MainForm
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
			this.lblPath = new System.Windows.Forms.Label();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.chkLbFiles = new System.Windows.Forms.CheckedListBox();
			this.btnStart = new System.Windows.Forms.Button();
			this.lblStatus = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.numUdVram = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.numUdVram)).BeginInit();
			this.SuspendLayout();
			// 
			// lblPath
			// 
			this.lblPath.AutoSize = true;
			this.lblPath.Location = new System.Drawing.Point(15, 14);
			this.lblPath.Name = "lblPath";
			this.lblPath.Size = new System.Drawing.Size(43, 14);
			this.lblPath.TabIndex = 0;
			this.lblPath.Text = "lblPath";
			// 
			// btnBrowse
			// 
			this.btnBrowse.Location = new System.Drawing.Point(12, 32);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(78, 25);
			this.btnBrowse.TabIndex = 1;
			this.btnBrowse.Text = "Обзор";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// chkLbFiles
			// 
			this.chkLbFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.chkLbFiles.CheckOnClick = true;
			this.chkLbFiles.FormattingEnabled = true;
			this.chkLbFiles.HorizontalScrollbar = true;
			this.chkLbFiles.Location = new System.Drawing.Point(96, 34);
			this.chkLbFiles.Name = "chkLbFiles";
			this.chkLbFiles.Size = new System.Drawing.Size(676, 225);
			this.chkLbFiles.TabIndex = 2;
			this.chkLbFiles.ThreeDCheckBoxes = true;
			this.chkLbFiles.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLbFiles_ItemCheck);
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(12, 115);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(78, 25);
			this.btnStart.TabIndex = 3;
			this.btnStart.Text = "Применить";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// lblStatus
			// 
			this.lblStatus.AutoSize = true;
			this.lblStatus.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblStatus.ForeColor = System.Drawing.Color.Green;
			this.lblStatus.Location = new System.Drawing.Point(14, 240);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(64, 19);
			this.lblStatus.TabIndex = 4;
			this.lblStatus.Text = "Готово!";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(10, 70);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 14);
			this.label3.TabIndex = 5;
			this.label3.Text = "Обьём VRAM";
			// 
			// numUdVram
			// 
			this.numUdVram.Increment = new decimal(new int[] {
            1024,
            0,
            0,
            0});
			this.numUdVram.Location = new System.Drawing.Point(12, 87);
			this.numUdVram.Maximum = new decimal(new int[] {
            3072,
            0,
            0,
            0});
			this.numUdVram.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
			this.numUdVram.Name = "numUdVram";
			this.numUdVram.ReadOnly = true;
			this.numUdVram.Size = new System.Drawing.Size(77, 22);
			this.numUdVram.TabIndex = 6;
			this.numUdVram.Value = new decimal(new int[] {
            2048,
            0,
            0,
            0});
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 281);
			this.Controls.Add(this.numUdVram);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.chkLbFiles);
			this.Controls.Add(this.btnBrowse);
			this.Controls.Add(this.lblPath);
			this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(800, 320);
			this.Name = "MainForm";
			this.Text = "UE Optimizer";
			((System.ComponentModel.ISupportInitialize)(this.numUdVram)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblPath;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.CheckedListBox chkLbFiles;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown numUdVram;
	}
}

