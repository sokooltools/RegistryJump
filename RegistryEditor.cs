﻿using System;
using System.Diagnostics;
using Microsoft.Win32;

namespace DevTools.RegistryJump
{
	public static class RegistryEditor
	{
		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// The place in the registry where the last key accessed is stored and which it defaults to open to.
		/// </summary>
		//----------------------------------------------------------------------------------------------------
		private const string SAVE_LAST_KEY = @"Software\Microsoft\Windows\CurrentVersion\Applets\Regedit\";

		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// Gets or sets the current key.
		/// </summary>
		//----------------------------------------------------------------------------------------------------
		public static string CurrentKey { get; private set; }

		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// Starts the RegEdit executable jumping directly to the specified key.
		/// </summary>
		/// <param name="key">The registry key that should be selected.</param>
		//----------------------------------------------------------------------------------------------------
		public static void OpenRegistryEditor(string key)
		{
			// Quit running instance of RegEdit.
			Process[] process = Process.GetProcessesByName("regedit");
			if (process.Length == 1)
				process[0].Kill();

			// Convert the string into its KeyInfo equivalent.
			KeyInfo keyInfo = KeyInfo.Parse(key);

			// Concatenate the key name to the key root value.
			CurrentKey = $@"{keyInfo.Hkey}\{keyInfo.Name}";

			// Save the current key. 
			using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(SAVE_LAST_KEY, true))
				registryKey?.SetValue("Lastkey", keyInfo.GetFullname());

			// Launch the registry editor.
			StartRegistryEditor();
		}

		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// Starts the RegEdit executable.
		/// </summary>
		//----------------------------------------------------------------------------------------------------
		public static void StartRegistryEditor()
		{
			try
			{
				Process.Start("regedit.exe");
			}
			catch (Exception ex)
			{
				if (ex.HResult != -2147467259) // Operation was cancelled by user.
					throw;
			}
		}
	}
}
