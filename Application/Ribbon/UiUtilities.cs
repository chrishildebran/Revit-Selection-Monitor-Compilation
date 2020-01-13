// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitor
// Project:............. Core
// File:................ UiUtilities.cs
// Last Code Cleanup:... 01/13/2020 @ 10:55 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
// Development Notes
namespace SelectionMonitorCore.Ribbon
{

	using Autodesk.Windows;

	internal static class UiUtilities
	{

		#region Methods (SC)

		public static int GetPositionBeforeButton(string s)
		{
			var position = 0;

			foreach(var item in ComponentManager.QuickAccessToolBar.Items)
			{
				if(string.IsNullOrWhiteSpace(item.Id))
				{
					continue;
				}

				position++;

				if(item.Id == s)
				{
					break;
				}
			}

			return position;
		}


		public static void PlaceButtonOnQuickAccess(int position, RibbonItem ribbonItem)
		{
			if(position < ComponentManager.QuickAccessToolBar.Items.Count)
			{
				ComponentManager.QuickAccessToolBar.InsertStandardItem(position, ribbonItem);
			}
			else
			{
				ComponentManager.QuickAccessToolBar.AddStandardItem(ribbonItem);
			}
		}


		public static void RemovePanelFromTab(RibbonTab ribbonTab, RibbonPanel ribbonPanel)
		{
			ribbonTab.Panels.Remove(ribbonPanel);
		}


		public static void RemoveTabFromRibbon(RibbonTab ribbonTab)
		{
			if(ribbonTab.Panels.Count != 0)
			{
				return;
			}

			ribbonTab.IsVisible = false;
		}

		#endregion

	}

}