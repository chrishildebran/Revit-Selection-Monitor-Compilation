// /////////////////////////////////////////////////////////////
// Solution:............ Base Revit Modeless
// Project:............. Application
// File:................ RibbonTab.cs
// Last Code Cleanup:... 12/27/2019 @ 8:01 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
namespace Application.Ribbon
{

	using System.Reflection;

	using Autodesk.Revit.UI;

	public static class RibbonTab
	{

		#region Fields (SC)

		private static string _path = Assembly.GetExecutingAssembly().Location;

		private static string _ribbonPanelName = "Development";

		private static string _ribbonTabName = "Sheasta";

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