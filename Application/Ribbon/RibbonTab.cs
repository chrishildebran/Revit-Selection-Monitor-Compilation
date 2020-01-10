// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitor
// Project:............. Core
// File:................ RibbonTab.cs
// Last Code Cleanup:... 01/10/2020 @ 10:32 AM Using ReSharper ✓
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
			RibbonTabName   = "Selection Monitor";
			Create();
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

		private static void Create()
		{
			App.UIContApp.CreateRibbonTab(RibbonTabName);

			var panel = App.UIContApp.CreateRibbonPanel(RibbonTabName, RibbonPanelName);

			panel.AddItem(RibbonPushButtons.MonitorOnIdlingCommand(RibbonTabName + panel));

			panel.AddItem(RibbonPushButtons.MonitorOnPropertyChangedCommand(RibbonTabName + panel));
		}

		#endregion

	}

}