// /////////////////////////////////////////////////////////////
// Solution:............ Base Revit Modeless
// Project:............. Application
// File:................ RibbonTab.cs
// Last Code Cleanup:... 12/27/2019 @ 8:58 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
namespace BaseRevitModeless.Ribbon
{

	using System.Reflection;

	using Autodesk.Revit.UI;

	public static class RibbonTab
	{

		#region Fields (SC)

		private static string _path = Assembly.GetExecutingAssembly().Location;

		private static string _ribbonPanelName = "Modeless";

		private static string _ribbonTabName = "Kelly Dev";

		#endregion

		#region Methods (SC)

		public static void Create(UIControlledApplication uiControlledApplication)
		{
			uiControlledApplication.CreateRibbonTab(_ribbonTabName);

			var ribbonPanel = uiControlledApplication.CreateRibbonPanel(_ribbonTabName, _ribbonPanelName);

			ribbonPanel.AddItem(RibbonPushButtons.PropertyFormButton(ribbonPanel, _ribbonTabName, _path));
		}

		#endregion

	}

}