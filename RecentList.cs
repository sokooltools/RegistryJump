//////////////////////////////////////////////////////////////////////////////
// (c) Copyright 2006-2007  SokoolTools
//
// Description: RecentList Class
//
// Modification Notes:
// Date		Author        	Notes
// -------- -------------- --------------------------------------------------
// 12/01/06	RSokol			Initial Development
//////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Specialized;

namespace DevTools.RegistryJump
{
	public class RecentList
	{
		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		//----------------------------------------------------------------------------------------------------
		public RecentList()
		{
			RecentKeys = new StringCollection();
		}

		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		//----------------------------------------------------------------------------------------------------
		public StringCollection RecentKeys { get; }

		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		/// <param name="currentKey"></param>
		//----------------------------------------------------------------------------------------------------
		public void UpdateRecentKeys(string currentKey)
		{
			if (string.IsNullOrEmpty(currentKey))
				return;
			// Make sure the key is deleted if it already exists
			DeleteRecentKey(currentKey);
			// Recent key is always inserted at the top.
			RecentKeys.Insert(0, currentKey);
			// Limit the number of items in the combobox by removing the last item.
			if (RecentKeys.Count > 20)
				RecentKeys.RemoveAt(RecentKeys.Count - 1);
		}

		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// Delete a key from the list.
		/// </summary>
		/// <param name="currentKey"></param>
		//----------------------------------------------------------------------------------------------------
		public void DeleteRecentKey(string currentKey)
		{
			if (!string.IsNullOrEmpty(currentKey) && RecentKeys.Contains(currentKey))
				RecentKeys.Remove(currentKey);
		}

		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		/// <param name="ascending"></param>
		//----------------------------------------------------------------------------------------------------
		public void Sort(bool ascending)
		{
			// Make an array out of the collection so it can be sorted.
			var aList = new ArrayList(RecentKeys.Count);

			foreach (string s in RecentKeys)
				aList.Add(s);

			aList.Sort();

			// Rebuild the collection from the array.
			RecentKeys.Clear();
			foreach (string s in aList)
				RecentKeys.Add(s);
		}
	}
}