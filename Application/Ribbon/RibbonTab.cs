// /////////////////////////////////////////////////////////////
// Solution:............ Test
// Project:............. BaseRevitModeless
// File:................ RibbonTab.cs
// Last Code Cleanup:... 01/03/2020 @ 2:51 PM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
// Development Notes
namespace BaseRevitModeless.Ribbon
{

	using System.Reflection;

	public class RibbonTab
	{

		#region Fields (SC)

		private static string _path = Assembly.GetExecutingAssembly().Location;

		#endregion

		#region Constructors (SC)

		public RibbonTab()
		{
			RibbonTabName   = "Kelly Dev";
			RibbonPanelName = "Modeless";
		}

		#endregion

		#region Properties (SC)

		private static string RibbonPanelName
		{
			get;
			set;
		}

		private static string RibbonTabName
		{
			get;
			set;
		}

		#endregion

		#region Methods (SC)

		public void Create()
		{
			// Tab
			App.UIContApp.CreateRibbonTab(RibbonTabName);


			// Panel
			var ribbonPanel = App.UIContApp.CreateRibbonPanel(RibbonTabName, RibbonPanelName);


			// Buttons
			ribbonPanel.AddItem(RibbonPushButtons.SelectionChangedCommand(ribbonPanel, RibbonTabName, _path));
			ribbonPanel.AddItem(RibbonPushButtons.PropertyView(ribbonPanel, RibbonTabName, _path));
			ribbonPanel.AddItem(RibbonPushButtons.PropertySelectionChangedView(ribbonPanel, RibbonTabName, _path));
		}

		#endregion

	}

}