// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitor
// Project:............. Core
// File:................ MonitorFairCommand.cs
// Last Code Cleanup:... 01/13/2020 @ 10:55 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
// Development Notes
namespace SelectionMonitorCore.Commands
{

	using Autodesk.Revit.Attributes;
	using Autodesk.Revit.DB;
	using Autodesk.Revit.UI;

	using SelectionMonitorCore.Utilities;

	[Transaction(TransactionMode.Manual)]
	public class MonitorFairCommand : IExternalCommand
	{

		#region Methods (SC)

		public Result Execute(ExternalCommandData revit, ref string message, ElementSet elements)
		{
			Messaging.DebugMessage("FairDummyCommand.Execute");

			return Result.Succeeded;
		}

		#endregion

	}

}