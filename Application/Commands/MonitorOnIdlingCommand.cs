// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitor
// Project:............. Core
// File:................ MonitorOnIdlingCommand.cs
// Last Code Cleanup:... 01/10/2020 @ 1:22 PM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
// Development Notes
namespace SelectionMonitorCore.Commands
{

	using System;
	using System.Collections.Generic;

	using Autodesk.Revit.Attributes;
	using Autodesk.Revit.DB;
	using Autodesk.Revit.UI;

	using SelectionMonitorCore.Events;
	using SelectionMonitorCore.Utilities;

	// Development Notes
	// 

	[Transaction(TransactionMode.ReadOnly)]
	public class MonitorOnIdlingCommand : IExternalCommand
	{

		#region Fields (SC)

		private static List<ElementId> _elementIds;

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


			// Start
			_elementIds = new List<ElementId>(_monitorOnIdling.SelectedElementIds);

			Messaging.DebugMessageString(_subscribed, _elementIds, "OnIdling");
		}

		#endregion

	}

}