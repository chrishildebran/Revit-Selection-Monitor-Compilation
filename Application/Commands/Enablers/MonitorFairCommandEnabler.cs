// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitor
// Project:............. Core
// File:................ MonitorFairCommandEnabler.cs
// Last Code Cleanup:... 01/13/2020 @ 11:47 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
// Development Notes
namespace SelectionMonitorCore.Commands.Enablers
{

	using System.Collections.Generic;
	using System.Linq;

	using Autodesk.Revit.DB;
	using Autodesk.Revit.UI;

	using SelectionMonitorCore.Utilities;

	public class MonitorFairCommandEnabler : IExternalCommandAvailability
	{

		#region Fields (SC)

		private static List<ElementId> _elementIds;

		#endregion

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
			_elementIds = App.UIApp.ActiveUIDocument.Selection.GetElementIds().OrderBy(elementId => elementId.IntegerValue).ToList();

			Messaging.DebugMessageString(true, _elementIds, "Fair Availability Class Name Workaround");


			// Assert Button Is Disabled
			return false;
		}

		#endregion

	}

}