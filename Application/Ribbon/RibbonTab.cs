// /////////////////////////////////////////////////////////////
// Solution:............ Test
// Project:............. BaseRevitModeless
// File:................ RibbonTab.cs
// Last Code Cleanup:... 12/31/2019 @ 3:09 PM Using ReSharper ✓
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
			// Tab
			uiControlledApplication.CreateRibbonTab(_ribbonTabName);


			// Panel
			var ribbonPanel = uiControlledApplication.CreateRibbonPanel(_ribbonTabName, _ribbonPanelName);


			// Buttons
			ribbonPanel.AddItem(RibbonPushButtons.SelectionChangedCommand(ribbonPanel, _ribbonTabName, _path));


			//ribbonPanel.AddItem(RibbonPushButtons.PropertyView(ribbonPanel, _ribbonTabName, _path));
		}

		#endregion

	}

}