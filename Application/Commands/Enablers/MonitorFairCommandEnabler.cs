// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitor
// Project:............. Core
// File:................ MonitorFairCommandEnabler.cs
// Last Code Cleanup:... 01/13/2020 @ 10:55 AM Using ReSharper ✓
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

			if(uidoc == null)
			{
				return false;
			}

			List<ElementId> sel = App.UIApp.ActiveUIDocument.Selection.GetElementIds().OrderBy(elementId => elementId.IntegerValue).ToList();


			// Raise the SelectionChangedEvent

			_elementIds = new List<ElementId>(sel);

			Messaging.DebugMessageString(true, _elementIds, "Fair Availability Class Name Workaround");

			return false; // disable button
		}

		#endregion

	}

}