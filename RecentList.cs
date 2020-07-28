//////////////////////////////////////////////////////////////////////////////
// (c) Copyright 2006-2020  SokoolTools
//
// Description: RecentList Class
//
// Modification Notes:
// Date		Author        	Notes
// -------- -------------- --------------------------------------------------
// 12/01/06	RSokol			Initial Development
//////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
			RecentKeys = new List<string>();
		}

		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		//----------------------------------------------------------------------------------------------------
		public List<string> RecentKeys { get; private set; }

		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		/// <param name="currentKey"></param>
		//----------------------------------------------------------------------------------------------------
		public void UpdateRecentKeys(string currentKey)
		{
			if (String.IsNullOrEmpty(currentKey))
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
			if (!String.IsNullOrEmpty(currentKey) && RecentKeys.Contains(currentKey))
				RecentKeys.Remove(currentKey);
		}

		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sortOrder"></param>
		//----------------------------------------------------------------------------------------------------
		public void Sort(SortOrder sortOrder = SortOrder.Ascending)
		{
			RecentKeys = sortOrder == SortOrder.Ascending
				? RecentKeys.OrderBy(m => m.ToLowerInvariant()).ToList()
				: RecentKeys.OrderByDescending(m => m.ToLowerInvariant()).ToList();
		}
	}
}