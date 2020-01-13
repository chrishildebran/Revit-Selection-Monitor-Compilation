// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitor
// Project:............. Core
// File:................ ApplicationEvents.cs
// Last Code Cleanup:... 01/13/2020 @ 10:55 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
// Development Notes
namespace SelectionMonitorCore.Events
{

	using Autodesk.Revit.DB.Events;
	using Autodesk.Windows;

	using SelectionMonitorCore.Ribbon;
	using SelectionMonitorCore.Utilities;

	internal static class ApplicationEvents
	{

		#region Methods (SC)

		public static void FairApplicationInitialized(object sender, ApplicationInitializedEventArgs e)
		{
			RibbonTab   fairTab    = null;
			RibbonPanel fairPanel  = null;
			RibbonItem  fairButton = null;

			foreach(var tab in ComponentManager.Ribbon.Tabs)
			{
				if(tab.Id == UiTab.RibbonTabName)
				{
					fairTab = tab;

					Messaging.DebugMessage($"Found Tab: {fairTab}");

					foreach(var panel in tab.Panels)
					{
						if(panel.Source.Title == "FairPanel")
						{
							fairPanel = panel;

							Messaging.DebugMessage($"Found Panel: {fairPanel}");

							foreach(var item in panel.Source.Items)
							{
								if(item.Id == "CustomCtrl_%CustomCtrl_%Selection Monitor%FairPanel%FairButtonItem")
								{
									fairButton = item;

									Messaging.DebugMessage($"Found Button: {fairButton}");

									break;
								}
							}
						}
					}

					break;
				}
			}

			if(fairPanel != null && fairButton != null)
			{
				var position = UiUtilities.GetPositionBeforeButton("ID_REVIT_FILE_PRINT");

				UiUtilities.PlaceButtonOnQuickAccess(position, fairButton);

				UiUtilities.RemovePanelFromTab(fairTab, fairPanel);

				UiUtilities.RemoveTabFromRibbon(fairTab);
			}
		}

		#endregion

	}

}