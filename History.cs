using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DevTools.RegistryJump
{
	public static class History
	{
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Gets or sets the recent list.
		/// </summary>
		//------------------------------------------------------------------------------------------------------------------------
		public static RecentList RecentList { get; private set; }

		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Loads the recent list.
		/// </summary>
		//------------------------------------------------------------------------------------------------------------------------
		public static void LoadRecentListFromFile()
		{
			string recentListFile = Path.Combine(Path.GetDirectoryName(Application.UserAppDataPath) ?? "", "RegistryJump.recent");
			if (File.Exists(recentListFile))
			{
				try
				{
					var xml = new XmlSerializer(typeof(RecentList));
					FileStream fs = File.Open(recentListFile, FileMode.Open);
					RecentList = (RecentList)xml.Deserialize(fs);
					fs.Close();
					return;
				}
				catch (Exception ex)
				{
					MessageBox.Show($@"Could not load the recent list because:'{ex.Message}'.", @"RegistryJump", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			RecentList = new RecentList();
		}

		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Saves the recent list to a file.
		/// </summary>
		//------------------------------------------------------------------------------------------------------------------------
		public static void SaveRecentListToFile()
		{
			try
			{
				string recentListFilename = Path.Combine(Path.GetDirectoryName(Application.UserAppDataPath) ?? "", "RegistryJump.recent");
				FileStream fs = File.Open(recentListFilename, FileMode.Create, FileAccess.Write, FileShare.Read);
				var xml = new XmlSerializer(typeof(RecentList));
				xml.Serialize(fs, RecentList);
				fs.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show($@"Could not load the recent list because:'{ex.Message}'.", @"RegistryJump", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Sorts the recent list.
		/// </summary>
		//------------------------------------------------------------------------------------------------------------------------
		public static void SortRecentList()
		{
			RecentList.Sort(true);
		}
	}
}
