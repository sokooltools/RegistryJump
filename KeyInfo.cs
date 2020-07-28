//////////////////////////////////////////////////////////////////////////////
// (c) Copyright 2006-2007  SokoolTools
//
// Description: KeyInfo Class
//
// Modification Notes:
// Date		Author        	Notes
// -------- -------------- --------------------------------------------------
// 12/01/06	RSokol			Initial Development
//////////////////////////////////////////////////////////////////////////////

using System;
using Microsoft.Win32;

namespace DevTools.RegistryJump
{
	//--------------------------------------------------------------------------------------------------------
	/// <summary>
	/// Contains detailed information about an registry key
	/// </summary>
	//--------------------------------------------------------------------------------------------------------
	public class KeyInfo
	{
		private const string HKCR = "HKCR";
		private const string HKCU = "HKCU";
		private const string HKLM = "HKLM";
		private const string HKU = "HKU";
		private const string HKCC = "HKCC";

		private const string HKEY_CLASSES_ROOT = "HKEY_CLASSES_ROOT";
		private const string HKEY_CURRENT_USER = "HKEY_CURRENT_USER";
		private const string HKEY_LOCAL_MACHINE = "HKEY_LOCAL_MACHINE";
		private const string HKEY_USERS = "HKEY_USERS";
		private const string HKEY_CURRENT_CONFIG = "HKEY_CURRENT_CONFIG";

		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// Short description of registry key. For example: "HKLM"
		/// </summary>
		//----------------------------------------------------------------------------------------------------
		private string _hk;

		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// Full descriptions of registry key. For example: "HKEY_LOCAL_MACHINE"
		/// </summary>
		//----------------------------------------------------------------------------------------------------
		public readonly string Hkey;

		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// The pure name of the Key. For example: "Software\Microsoft"
		/// </summary>
		//----------------------------------------------------------------------------------------------------
		public string Name;

		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// The Registry key class. For example: Registry.LocalMachine
		/// </summary>
		//----------------------------------------------------------------------------------------------------
		private readonly RegistryKey _key;

		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// Gets the fullname.
		/// </summary>
		/// <returns></returns>
		//----------------------------------------------------------------------------------------------------
		public string GetFullname()
		{
			string fullname = $@"Computer\{Hkey}";
			if (Name.Length > 0)
				fullname += $@"\{Name}";
			return fullname;
		}

		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// Initializes a new instance of the <see cref="KeyInfo"/> class.
		/// </summary>
		/// <param name="hk">The hk.</param>
		/// <param name="hkey">The hkey.</param>
		/// <param name="name">The name.</param>
		/// <param name="key">The key.</param>
		//----------------------------------------------------------------------------------------------------
		private KeyInfo(string hk, string hkey, string name, RegistryKey key)
		{
			_hk = hk;
			Hkey = hkey;
			Name = name;
			_key = key;
		}

		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="desc">The desc.</param>
		/// <returns></returns>
		//----------------------------------------------------------------------------------------------------
		private static string GetName(string key, string desc)
		{
			return key.Length > desc.Length + 1 ? key.Substring(desc.Length + 1) : "";
		}

		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// Converts the string representation of a registry key to its KeyInfo equivalent.
		/// </summary>
		/// <param name="key">A string containing a registry key to convert.</param>
		/// <returns>A KeyInfo equivalent to the registry key contained in key.</returns>
		//----------------------------------------------------------------------------------------------------
		public static KeyInfo Parse(string key)
		{
			string name;

			// Remove spaces, square-brackets, and double-quotes from the beginning and the end of the key.
			char[] removeChars = { ' ', '[', ']', '"', '\\' };
			key = key.Trim(removeChars);

			// Remove whitespace surrounding the back slashes in the key.
			key = System.Text.RegularExpressions.Regex.Replace(key, @"[\s]*\\[\s]*", @"\");

			// Get an uppercase version of the key to use for comparison purposes.
			string ukey = key.ToUpper();

			KeyInfo ki;
			if (ukey.StartsWith(HKCR))
			{
				name = GetName(key, HKCR);
				ki = new KeyInfo(HKCR, HKEY_CLASSES_ROOT, name, Registry.ClassesRoot);
			}
			else if (ukey.StartsWith(HKCU))
			{
				name = GetName(key, HKCU);
				ki = new KeyInfo(HKCU, HKEY_CURRENT_USER, name, Registry.CurrentUser);
			}
			else if (ukey.StartsWith(HKLM))
			{
				name = GetName(key, HKLM);
				ki = new KeyInfo(HKLM, HKEY_LOCAL_MACHINE, name, Registry.LocalMachine);
			}
			else if (ukey.StartsWith(HKU))
			{
				name = GetName(key, HKU);
				ki = new KeyInfo(HKU, HKEY_USERS, name, Registry.Users);
			}
			else if (ukey.StartsWith(HKCC))
			{
				name = GetName(key, HKCC);
				ki = new KeyInfo(HKCC, HKEY_CURRENT_CONFIG, name, Registry.CurrentConfig);
			}
			else if (ukey.StartsWith(HKEY_CLASSES_ROOT))
			{
				name = GetName(key, HKEY_CLASSES_ROOT);
				ki = new KeyInfo(HKCR, HKEY_CLASSES_ROOT, name, Registry.ClassesRoot);
			}
			else if (ukey.StartsWith(HKEY_LOCAL_MACHINE))
			{
				name = GetName(key, HKEY_LOCAL_MACHINE);
				ki = new KeyInfo(HKLM, HKEY_LOCAL_MACHINE, name, Registry.LocalMachine);
			}
			else if (ukey.StartsWith(HKEY_CURRENT_USER))
			{
				name = GetName(key, HKEY_CURRENT_USER);
				ki = new KeyInfo(HKCU, HKEY_CURRENT_USER, name, Registry.CurrentUser);
			}
			else if (ukey.StartsWith(HKEY_USERS))
			{
				name = GetName(key, HKEY_USERS);
				ki = new KeyInfo(HKU, HKEY_USERS, name, Registry.Users);
			}
			else if (ukey.StartsWith(HKEY_CURRENT_CONFIG))
			{
				name = GetName(key, HKEY_CURRENT_CONFIG);
				ki = new KeyInfo(HKCC, HKEY_CURRENT_CONFIG, name, Registry.CurrentConfig);
			}
			else
			{
				throw new Exception("That is not a valid registry key!");
			}

			string subName = ki.Name;

			while (true)
			{
				RegistryKey subKey = ki._key.OpenSubKey(subName);
				if (subKey != null)
					break;

				int tokenLength = subName.LastIndexOf(@"\", StringComparison.Ordinal);
				if (tokenLength == -1)
				{
					subName = String.Empty;
					break;
				}
				subName = subName.Substring(0, tokenLength);
			}

			ki.Name = subName;

			ki._key.Close();

			return ki;
		}
	}
}