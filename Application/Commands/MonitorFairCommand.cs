// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitor
// Project:............. Core
// File:................ MonitorFairCommand.cs
// Last Code Cleanup:... 01/14/2020 @ 7:37 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
namespace SelectionMonitorCompilationCore.Commands
{

	using Autodesk.Revit.Attributes;
	using Autodesk.Revit.DB;
	using Autodesk.Revit.UI;

	using SelectionMonitorCompilationCore.Utilities;

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