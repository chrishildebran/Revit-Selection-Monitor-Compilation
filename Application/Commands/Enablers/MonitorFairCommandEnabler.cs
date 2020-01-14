// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitor
// Project:............. Core
// File:................ MonitorFairCommandEnabler.cs
// Last Code Cleanup:... 01/14/2020 @ 7:37 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
namespace SelectionMonitorCore.Commands.Enablers
{

	using System.Collections.Generic;
	using System.Linq;

	using Autodesk.Revit.DB;
	using Autodesk.Revit.UI;

	using SelectionMonitorCore.Utilities;

	public class MonitorFairCommandEnabler : IExternalCommandAvailability
	{

		#region Methods (SC)

		public bool IsCommandAvailable(UIApplication uiApp, CategorySet catSet)
		{
			var uidoc = uiApp.ActiveUIDocument;


			// If no Document...
			if(uidoc == null)
			{
				// Assert Button Is Disabled
				return false;
			}


			// Raise the SelectionChangedEvent
			List<ElementId> elementIds = App.UIApp.ActiveUIDocument.Selection.GetElementIds().OrderBy(elementId => elementId.IntegerValue).ToList();

			Messaging.DebugMessage(true, elementIds, "Fair59 - Availability Class Name Workaround", true);


			// Assert Button Is Disabled
			return false;
		}

		#endregion

	}

}