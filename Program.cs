//////////////////////////////////////////////////////////////////////////////
// (c) Copyright 2006-2019  SokoolTools
//
// Description: Main Program
//
// Modification Notes:
// Date		Author        	Notesx
// -------- -------------- --------------------------------------------------
// 12/01/06	RSokol			Initial Development
//////////////////////////////////////////////////////////////////////////////

using System;
using System.Windows.Forms;

namespace DevTools.RegistryJump
{
	//----------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// 
	/// </summary>
	//----------------------------------------------------------------------------------------------------------------------------
	internal static class Program
	{
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Mains the specified args.
		/// </summary>
		/// <param name="args">The args.</param>
		//------------------------------------------------------------------------------------------------------------------------
		[STAThread]
		public static void Main(string[] args)
		{
			try
			{
				if (args.Length == 0)
				{
					// Run application's GUI main form
					Application.Run(new FrmMain());
				}
				else
				{
					// In certain cases when the key contains spaces it may be received as multiple 
					// input arguments so just join them back together and hope for the best.
					string currentKey = String.Join(" ", args);
					if (currentKey.StartsWith("chrome-extension:"))
						Chrome.Run();
					else
					{
						// Load the recent list from the recent file.
						History.LoadRecentListFromFile();

						// Run Registry Editor in the background.
						RegistryEditor.OpenRegistryEditor(currentKey);

						// Add the current key value to the recent list.
						History.RecentList.UpdateRecentKeys(RegistryEditor.CurrentKey);

						// Save the recent list back to the file
						History.SaveRecentListToFile();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, @"RegistryJump", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			Application.Exit();
		}
	}
}