// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitorCompilation
// Project:............. Core
// File:................ MonitorFairCommand.cs
// Last Code Cleanup:... 01/05/2021 @ 11:45 AM Using ReSharper ✓
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