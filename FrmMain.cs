//////////////////////////////////////////////////////////////////////////////
// (c) Copyright 2006-2019  SokoolTools
//
// Description: Main Form
//
// Modification Notes:
// Date		Author        	Notes
// -------- -------------- --------------------------------------------------
// 12/01/06	RSokol			Initial Development
//////////////////////////////////////////////////////////////////////////////

using System;
using System.Drawing;
using System.Windows.Forms;

namespace DevTools.RegistryJump
{
	//--------------------------------------------------------------------------------------------------------
	/// <summary>
	/// 
	/// </summary>
	//--------------------------------------------------------------------------------------------------------
	public partial class FrmMain : Form
	{
		// Set a couple of tooltips.
		private const string TOOLTIP_MSG = "To delete items from the recent list:\n"
				+ "Use the <Alt><Arrow> keys to make the selection then press <Delete>.";

		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// Initializes a new instance of the <see cref="FrmMain"/> class.
		/// </summary>
		//----------------------------------------------------------------------------------------------------
		public FrmMain()
		{
			InitializeComponent();
		}

		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// Gets or sets the current key.
		/// </summary>
		/// <value>The current key.</value>
		//----------------------------------------------------------------------------------------------------
		private string CurrentKey
		{
			get => cboKey.Text;
			set => cboKey.Text = value;
		}

		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// Handles the Load event of the Form control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		//----------------------------------------------------------------------------------------------------
		private void Form_Load(object sender, EventArgs e)
		{
			// Set form location to lower left-bottom of the screen.
			Rectangle screen = Screen.GetWorkingArea(this);
			Location = new Point(4, screen.Height - Height - 4);

			cboKey.MaxDropDownItems = 6;

			// Fill the combobox.
			FillComboBox();

			toolTip1.SetToolTip(label1, TOOLTIP_MSG);
			toolTip1.SetToolTip(label2, TOOLTIP_MSG);
		}

		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// Handles the Click event of the btnOK control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		//----------------------------------------------------------------------------------------------------
		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				// Jump to the value in the registry editor.
				RegistryEditor.OpenRegistryEditor(CurrentKey);

				// Update the recent list.
				History.RecentList.UpdateRecentKeys(RegistryEditor.CurrentKey);

				// Save recent list to file.
				History.SaveRecentListToFile();

				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, @"RegistryJump", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// Handles the Click event of the btnBrowse control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		//----------------------------------------------------------------------------------------------------
		private void btnBrowse_Click(object sender, EventArgs e)
		{
			RegistryEditor.StartRegistryEditor();
			Close();
		}

		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// Handles the KeyDown event of the cboKey control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">
		/// The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.
		/// </param>
		//----------------------------------------------------------------------------------------------------
		private void cboKey_KeyDown(object sender, KeyEventArgs e)
		{
			// Check if the delete key is pressed while the menu is dropped down.
			if (e.KeyCode != Keys.Delete || !cboKey.DroppedDown || string.IsNullOrEmpty(CurrentKey)) return;
			History.RecentList.DeleteRecentKey(CurrentKey);

			History.SaveRecentListToFile();

			cboKey.DroppedDown = false;

			FillComboBox();

			if (History.RecentList.RecentKeys.Count > 0)
			{
				// Continue to show the menu choices as dropped down.
				cboKey.DroppedDown = true;
			}
		}

		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// Handles the CheckedChanged event of the chkSort control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		//----------------------------------------------------------------------------------------------------
		private void chkSort_CheckedChanged(object sender, EventArgs e)
		{
			// Reload the combobox based on the current sort indicator.
			FillComboBox();
		}

		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// Fills the combo box.
		/// </summary>
		//----------------------------------------------------------------------------------------------------
		private void FillComboBox()
		{
			// Load the recent list into memory.
			History.LoadRecentListFromFile();

			// Sort the recent list when so indicated.
			if (chkSort.Checked)
				History.SortRecentList();

			// Fill the combobox with the data by binding it to the datasource.
			cboKey.DataSource = null;
			cboKey.DataSource = History.RecentList.RecentKeys;
			if (History.RecentList.RecentKeys.Count > 0)
			{
				cboKey.Text = History.RecentList.RecentKeys[0];
				cboKey.SelectedIndex = 0;
				cboKey.SelectAll();
			}
			else
			{
				cboKey.DroppedDown = false;
			}
		}
	}
}