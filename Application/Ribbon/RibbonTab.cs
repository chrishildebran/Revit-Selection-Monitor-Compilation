// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitor
// Project:............. Core
// File:................ RibbonTab.cs
// Last Code Cleanup:... 01/06/2020 @ 8:43 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
// Development Notes
namespace SelectionMonitorCore.Ribbon
{

	public class RibbonTab
	{

		#region Constructors (SC)

		public RibbonTab()
		{
			RibbonPanelMonitorName = "Modeless Views";
			RibbonPanelViewName    = "Monitor";
			RibbonTabName          = "Kelly Dev";
		}

		#endregion

		#region Properties (SC)

		private static string RibbonPanelMonitorName
		{
			get;
			set;
		}

		private static string RibbonPanelViewName
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
			var ribbonPanelMonitor = App.UIContApp.CreateRibbonPanel(RibbonTabName, RibbonPanelMonitorName);
			var ribbonPanelViews   = App.UIContApp.CreateRibbonPanel(RibbonTabName, RibbonPanelViewName);


			// Buttons
			ribbonPanelMonitor.AddItem(RibbonPushButtons.MonitorOnIdlingCommand(RibbonTabName + ribbonPanelMonitor));

			ribbonPanelMonitor.AddItem(RibbonPushButtons.MonitorOnPropertyChangedCommand(RibbonTabName + ribbonPanelMonitor));

			ribbonPanelViews.AddItem(RibbonPushButtons.PropertyView(RibbonPanelViewName + ribbonPanelViews));

			ribbonPanelViews.AddItem(RibbonPushButtons.PropertySelectionChangedView(RibbonPanelViewName + ribbonPanelViews));
		}

		#endregion

	}

}