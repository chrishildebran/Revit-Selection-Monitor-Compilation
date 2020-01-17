// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitorCompilation
// Project:............. Core
// File:................ MonitorFairCommand.cs
// Last Code Cleanup:... 01/17/2020 @ 8:16 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
namespace SelectionMonitorCompilationCore.Tools
{

	using Autodesk.Revit.Attributes;
	using Autodesk.Revit.DB;
	using Autodesk.Revit.UI;

	using SelectionMonitorCompilationCore.Shared.Utilities;

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