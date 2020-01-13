// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitor
// Project:............. Core
// File:................ UiTab.cs
// Last Code Cleanup:... 01/13/2020 @ 10:55 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
// Development Notes
namespace SelectionMonitorCore.Ribbon
{

	public class UiTab
	{

		#region Constructors (SC)

		public UiTab(string tabName, string panelName)
		{
			RibbonPanelName = panelName;
			RibbonTabName   = tabName;
			Create();
		}

		#endregion

		#region Properties (SC)

		public static string RibbonPanelName
		{
			get;
			private set;
		}

		public static string RibbonTabName
		{
			get;
			private set;
		}

		#endregion

		#region Methods (SC)

		private static void Create()
		{
			// Tab
			App.UIContApp.CreateRibbonTab(RibbonTabName);

			//// Panels and Buttons
			// On Idling Selection Monitor
			var panelOnIdlingMonitor = App.UIContApp.CreateRibbonPanel(RibbonTabName, "OnIdling");
			panelOnIdlingMonitor.AddItem(UiPushButtons.MonitorOnIdlingCommand(RibbonPanelName + panelOnIdlingMonitor));


			// On Property Change Selection Monitor
			var panelOnPropertyChange = App.UIContApp.CreateRibbonPanel(RibbonTabName, "OnPropertyChange");
			panelOnPropertyChange.AddItem(UiPushButtons.MonitorOnPropertyChangedCommand(RibbonPanelName + panelOnPropertyChange));


			// Fair Selection Monitor
			var fairPanel = App.UIContApp.CreateRibbonPanel(RibbonTabName, "FairPanel");
			fairPanel.AddItem(UiPushButtons.MonitorFairButtonCommand());
		}

		#endregion

	}

}