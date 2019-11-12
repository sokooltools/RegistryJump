using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace DevTools.RegistryJump
{
	internal static class Chrome
	{
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Runs this instance.
		/// </summary>
		/// <returns></returns>
		//------------------------------------------------------------------------------------------------------------------------
		public static int Run()
		{
			try
			{
				// Get the request message.
				string json = OpenStandardStreamIn();

				var msgObj = JsonConvert.DeserializeObject<MessageObject>(json);

				string currentKey = msgObj.Text;

				//// Load the recent list from the recent file.
				//History.LoadRecentListFromFile();

				// Run Registry Editor in the background.
				RegistryEditor.OpenRegistryEditor(currentKey);

				//// Add the current key value to the recent list.
				//History.RecentList.UpdateRecentKeys(currentKey);

				//// Save the recent list back to the file
				//History.SaveRecentListToFile();

				return 0;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, @"RegistryJump Exception");
				return 1;
			}
		}

		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Opens the standard input stream.
		/// </summary>
		/// <returns></returns>
		//------------------------------------------------------------------------------------------------------------------------
		private static string OpenStandardStreamIn()
		{
			using (Stream stdin = Console.OpenStandardInput())
			{
				var buff = new byte[4];
				// Read first 4 bytes for length information
				stdin.Read(buff, 0, 4);
				int len = BitConverter.ToInt32(buff, 0);
				string json = string.Empty;
				for (int i = 0; i < len; i++)
					json += (char)stdin.ReadByte();
				return json;
			}
		}

		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Opens the standard output stream.
		/// </summary>
		/// <param name="json">The json message.</param>
		//------------------------------------------------------------------------------------------------------------------------
		private static void OpenStandardStreamOut(string json)
		{
			using (Stream stdout = Console.OpenStandardOutput())
			{
				byte[] buff = Encoding.UTF8.GetBytes(json);
				// Write first 4 bytes for length information
				stdout.Write(BitConverter.GetBytes(buff.Length), 0, 4);
				// Write the message,
				stdout.Write(buff, 0, buff.Length);
				stdout.Flush();
			}
		}

		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// The object containing the message sent to and from the Chrome extension.
		/// </summary>
		//------------------------------------------------------------------------------------------------------------------------
		private class MessageObject
		{
			//--------------------------------------------------------------------------------------------------------------------
			/// <summary>
			/// The Registry Hive.
			/// </summary>
			//--------------------------------------------------------------------------------------------------------------------
			[JsonProperty(PropertyName = "text")]
			public readonly string Text;

			//--------------------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Initializes a new instance of the <see cref="MessageObject" /> class.
			/// </summary>
			/// <param name="text">The registry hive.</param>
			//--------------------------------------------------------------------------------------------------------------------
			public MessageObject(string text)
			{
				Text = text;
			}
		}
	}
}
