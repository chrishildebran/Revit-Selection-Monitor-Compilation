// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitor
// Project:............. Core
// File:................ RibbonTab.cs
// Last Code Cleanup:... 01/06/2020 @ 10:50 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
// Development Notes
namespace SelectionMonitorCore.Ribbon
{

	public class RibbonTab
	{

		#region Constructors (SC)

		public RibbonTab()
		{
			RibbonPanelName = "Monitor";
			RibbonTabName   = "Kelly Monitor";
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


			// Panels
			var ribbonPanelMonitor = App.UIContApp.CreateRibbonPanel(RibbonTabName, RibbonPanelName);


			// Buttons
			ribbonPanelMonitor.AddItem(RibbonPushButtons.MonitorOnIdlingCommand(RibbonTabName + ribbonPanelMonitor));

			ribbonPanelMonitor.AddItem(RibbonPushButtons.MonitorOnPropertyChangedCommand(RibbonTabName + ribbonPanelMonitor));
		}

		#endregion

	}

}