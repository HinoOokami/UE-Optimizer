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
            this.lblVRAM = new System.Windows.Forms.Label();
            this.numUdVram = new System.Windows.Forms.NumericUpDown();
            this.chkbxHT = new System.Windows.Forms.CheckBox();
            this.grpbxThreadingStrategy = new System.Windows.Forms.GroupBox();
            this.rdbtnMaxHalf = new System.Windows.Forms.RadioButton();
            this.rdbtnMaxMinus2 = new System.Windows.Forms.RadioButton();
            this.rdbtnMax = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.numUdVram)).BeginInit();
            this.grpbxThreadingStrategy.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(15, 14);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(0, 14);
            this.lblPath.TabIndex = 0;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(12, 32);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(78, 25);
            this.btnBrowse.TabIndex = 1;
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
            this.chkLbFiles.Size = new System.Drawing.Size(676, 259);
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
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStatus.ForeColor = System.Drawing.Color.Green;
            this.lblStatus.Location = new System.Drawing.Point(14, 300);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 19);
            this.lblStatus.TabIndex = 4;
            // 
            // lblVRAM
            // 
            this.lblVRAM.AutoSize = true;
            this.lblVRAM.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblVRAM.Location = new System.Drawing.Point(10, 70);
            this.lblVRAM.Name = "lblVRAM";
            this.lblVRAM.Size = new System.Drawing.Size(0, 14);
            this.lblVRAM.TabIndex = 5;
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
            // chkbxHT
            // 
            this.chkbxHT.AutoSize = true;
            this.chkbxHT.Location = new System.Drawing.Point(96, 300);
            this.chkbxHT.Name = "chkbxHT";
            this.chkbxHT.Size = new System.Drawing.Size(85, 18);
            this.chkbxHT.TabIndex = 7;
            this.chkbxHT.Text = "checkBox1";
            this.chkbxHT.UseVisualStyleBackColor = true;
            this.chkbxHT.CheckedChanged += new System.EventHandler(this.chkbxHT_CheckedChanged);
            // 
            // grpbxThreadingStrategy
            // 
            this.grpbxThreadingStrategy.Controls.Add(this.rdbtnMaxHalf);
            this.grpbxThreadingStrategy.Controls.Add(this.rdbtnMaxMinus2);
            this.grpbxThreadingStrategy.Controls.Add(this.rdbtnMax);
            this.grpbxThreadingStrategy.Location = new System.Drawing.Point(352, 300);
            this.grpbxThreadingStrategy.Name = "grpbxThreadingStrategy";
            this.grpbxThreadingStrategy.Size = new System.Drawing.Size(420, 48);
            this.grpbxThreadingStrategy.TabIndex = 8;
            this.grpbxThreadingStrategy.TabStop = false;
            this.grpbxThreadingStrategy.Text = "ThreadedShaderCompileThreshold : NumUnusedShaderCompilingThreads";
            // 
            // rdbtnMaxHalf
            // 
            this.rdbtnMaxHalf.AutoSize = true;
            this.rdbtnMaxHalf.Location = new System.Drawing.Point(310, 21);
            this.rdbtnMaxHalf.Name = "rdbtnMaxHalf";
            this.rdbtnMaxHalf.Size = new System.Drawing.Size(103, 18);
            this.rdbtnMaxHalf.TabIndex = 2;
            this.rdbtnMaxHalf.Tag = "";
            this.rdbtnMaxHalf.Text = "Max/2 : Max/2";
            this.rdbtnMaxHalf.UseVisualStyleBackColor = true;
            // 
            // rdbtnMaxMinus2
            // 
            this.rdbtnMaxMinus2.AutoSize = true;
            this.rdbtnMaxMinus2.Location = new System.Drawing.Point(145, 21);
            this.rdbtnMaxMinus2.Name = "rdbtnMaxMinus2";
            this.rdbtnMaxMinus2.Size = new System.Drawing.Size(76, 18);
            this.rdbtnMaxMinus2.TabIndex = 1;
            this.rdbtnMaxMinus2.Tag = "2";
            this.rdbtnMaxMinus2.Text = "Max-2 : 2";
            this.rdbtnMaxMinus2.UseVisualStyleBackColor = true;
            // 
            // rdbtnMax
            // 
            this.rdbtnMax.AutoSize = true;
            this.rdbtnMax.Location = new System.Drawing.Point(6, 21);
            this.rdbtnMax.Name = "rdbtnMax";
            this.rdbtnMax.Size = new System.Drawing.Size(65, 18);
            this.rdbtnMax.TabIndex = 0;
            this.rdbtnMax.Tag = "0";
            this.rdbtnMax.Text = "Max : 0";
            this.rdbtnMax.UseVisualStyleBackColor = true;
            this.rdbtnMax.CheckedChanged += new System.EventHandler(this.rdbtnThreading_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(784, 359);
            this.Controls.Add(this.grpbxThreadingStrategy);
            this.Controls.Add(this.chkbxHT);
            this.Controls.Add(this.numUdVram);
            this.Controls.Add(this.lblVRAM);
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
            this.grpbxThreadingStrategy.ResumeLayout(false);
            this.grpbxThreadingStrategy.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblPath;
	    internal System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.CheckedListBox chkLbFiles;
	    internal System.Windows.Forms.Button btnStart;
	    internal System.Windows.Forms.Label lblStatus;
	    internal System.Windows.Forms.Label lblVRAM;
		private System.Windows.Forms.NumericUpDown numUdVram;
        private System.Windows.Forms.CheckBox chkbxHT;
        private System.Windows.Forms.GroupBox grpbxThreadingStrategy;
        private System.Windows.Forms.RadioButton rdbtnMaxHalf;
        private System.Windows.Forms.RadioButton rdbtnMaxMinus2;
        private System.Windows.Forms.RadioButton rdbtnMax;
    }
}

