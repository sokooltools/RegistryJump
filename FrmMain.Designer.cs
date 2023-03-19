//////////////////////////////////////////////////////////////////////////////
// (c) Copyright 2006-2007  SokoolTools
//
// Description: Main Form
//
// Modification Notes:
// Date		Author        	Notes
// -------- -------------- --------------------------------------------------
// 12/01/06	RSokol			Initial Development
//////////////////////////////////////////////////////////////////////////////
namespace DevTools.RegistryJump
{
	partial class FrmMain
	{
		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// Required designer variable.
		/// </summary>
		//----------------------------------------------------------------------------------------------------
		private System.ComponentModel.IContainer components = null;

		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		//----------------------------------------------------------------------------------------------------
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		//.............................................................................................................

		#region Windows Form Designer generated code

		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		//----------------------------------------------------------------------------------------------------
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.cboKey = new System.Windows.Forms.ComboBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.chkSort = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(9, 11);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(32, 40);
			this.pictureBox1.TabIndex = 13;
			this.pictureBox1.TabStop = false;
			// 
			// btnBrowse
			// 
			this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBrowse.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnBrowse.Location = new System.Drawing.Point(392, 98);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(80, 23);
			this.btnBrowse.TabIndex = 12;
			this.btnBrowse.Text = "Browse...";
			this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(304, 98);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 23);
			this.btnCancel.TabIndex = 11;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
																	   | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label2.Location = new System.Drawing.Point(49, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(428, 38);
			this.label2.TabIndex = 10;
			this.label2.Text = "Enter the name of a registry key or select it from the recent list, and RegistryJ" +
							   "ump will open it for you.";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOK.Location = new System.Drawing.Point(216, 98);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(80, 23);
			this.btnOK.TabIndex = 9;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
			// 
			// label1
			// 
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label1.Location = new System.Drawing.Point(9, 63);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 21);
			this.label1.TabIndex = 8;
			this.label1.Text = "Open:";
			// 
			// cboKey
			// 
			this.cboKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
																	   | System.Windows.Forms.AnchorStyles.Right)));
			this.cboKey.Location = new System.Drawing.Point(49, 61);
			this.cboKey.Name = "cboKey";
			this.cboKey.Size = new System.Drawing.Size(423, 21);
			this.cboKey.TabIndex = 7;
			this.cboKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CboKey_KeyDown);
			// 
			// chkSort
			// 
			this.chkSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkSort.AutoSize = true;
			this.chkSort.Location = new System.Drawing.Point(49, 98);
			this.chkSort.Name = "chkSort";
			this.chkSort.Size = new System.Drawing.Size(121, 17);
			this.chkSort.TabIndex = 14;
			this.chkSort.Text = "Sort the Recent List";
			this.chkSort.UseVisualStyleBackColor = true;
			this.chkSort.CheckedChanged += new System.EventHandler(this.ChkSort_CheckedChanged);
			// 
			// frmMain
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(491, 134);
			this.Controls.Add(this.chkSort);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.btnBrowse);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cboKey);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(333, 158);
			this.Name = "FrmMain";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "RegistryJump";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.Form_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.CheckBox chkSort;
		private System.Windows.Forms.ComboBox cboKey;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ToolTip toolTip1;
	}
}