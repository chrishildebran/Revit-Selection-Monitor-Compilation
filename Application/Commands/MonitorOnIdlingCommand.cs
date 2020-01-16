// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitor
// Project:............. Core
// File:................ MonitorOnIdlingCommand.cs
// Last Code Cleanup:... 01/14/2020 @ 7:37 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
namespace SelectionMonitorCompilationCore.Commands
{

	using System;
	using System.Collections.Generic;

	using Autodesk.Revit.Attributes;
	using Autodesk.Revit.DB;
	using Autodesk.Revit.UI;

	using SelectionMonitorCompilationCore.Events;
	using SelectionMonitorCompilationCore.Utilities;

	[Transaction(TransactionMode.ReadOnly)]
	public class MonitorOnIdlingCommand : IExternalCommand
	{

		#region Fields

		private static MonitorOnIdling _monitorOnIdling;

		private static bool _subscribed;

		#endregion

		#region Methods (SC)

		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			if(_subscribed)
			{
				_monitorOnIdling.SelectionChanged -= SelectionChangedEvent;

				App.UIContApp.Idling -= _monitorOnIdling.OnIdlingEvent;

				_subscribed = false;
			}
			else
			{
				if(_monitorOnIdling == null)
				{
					_monitorOnIdling = new MonitorOnIdling();
				}

				_monitorOnIdling.SelectionChanged += SelectionChangedEvent;

				App.UIContApp.Idling += _monitorOnIdling.OnIdlingEvent;

				_subscribed = true;
			}

			Messaging.DebugMessage($"OnIdling Subscription Changed: Subscribed = {_subscribed}");

			return Result.Succeeded;
		}


		private static void SelectionChangedEvent(object sender, EventArgs e)
		{
			if(_monitorOnIdling.SelectedElementIds == null)
			{
				return;
			}

			List<ElementId> elementIds = new List<ElementId>(_monitorOnIdling.SelectedElementIds);

			Messaging.DebugMessage(_subscribed, elementIds, "Ken Goulding's - OnIdling", true);
		}

		#endregion

	}

}