// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitor
// Project:............. Core
// File:................ Utilities.cs
// Last Code Cleanup:... 01/14/2020 @ 7:37 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
namespace SelectionMonitorCompilationCore.UI
{

	using System.Reflection;
	using System.Windows.Media.Imaging;

	using Autodesk.Windows;

	internal static class Utilities
	{

		#region Methods (SC)

		public static BitmapSource GetBitmapFrame(string name)
		{
			try
			{
				var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name);

				return BitmapFrame.Create(stream);
			}
			catch
			{
				return null;
			}
		}


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