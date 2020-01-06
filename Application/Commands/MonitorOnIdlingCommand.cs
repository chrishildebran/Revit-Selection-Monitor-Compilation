// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitor
// Project:............. Core
// File:................ MonitorOnIdlingCommand.cs
// Last Code Cleanup:... 01/06/2020 @ 10:50 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
// Development Notes
namespace SelectionMonitorCore.Commands
{

	using System;
	using System.Collections.Generic;
	using System.Diagnostics;

	using Autodesk.Revit.Attributes;
	using Autodesk.Revit.DB;
	using Autodesk.Revit.UI;

	using SelectionMonitorCore.Events;

	// Development Notes
	// 

	[Transaction(TransactionMode.ReadOnly)]
	public class MonitorOnIdlingCommand : IExternalCommand
	{

		#region Fields (SC)

		private static List<ElementId> _elementIds;

		private static MonitorOnIdling _monitorOnIdling;

		private static bool _subscribed;

		private static int _subscribedCount;

		#endregion

		#region Methods (SC)

		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			ToggleSubscription();

			Debug.WriteLine("--------------------------------------------------------------------------");
			Debug.IndentLevel = 1;

			Debug.Print($"CmdSelectionChanged - _subscribed = {_subscribed}, _subscribedCount = {_subscribedCount}");

			Debug.IndentLevel = 0;
			Debug.WriteLine("--------------------------------------------------------------------------");

			return Result.Succeeded;
		}


		public static void ToggleSubscription()
		{
			if(_subscribed)
			{
				_monitorOnIdling.SelectionChanged -= SelectionChangedEvent;

				_subscribed = false;
			}
			else
			{
				if(_monitorOnIdling == null)
				{
					_monitorOnIdling = new MonitorOnIdling();
				}

				_monitorOnIdling.SelectionChanged += SelectionChangedEvent;

				_subscribed = true;
				_subscribedCount++;
			}
		}


		private static void SelectionChangedEvent(object sender, EventArgs e)
		{
			Debug.WriteLine("--------------------------------------------------------------------------");

			var message = string.Empty;

			if(_monitorOnIdling.SelectedElementIds == null)
			{
				message = "No selection";

				return;
			}

			_elementIds = new List<ElementId>(_monitorOnIdling.SelectedElementIds);

			if(_elementIds.Count == 0)
			{
				message = "No selection";
			}
			else if(_elementIds.Count >= 1)
			{
				//message = string.Join(", ", _elementIds.Select(id => id.IntegerValue));
				message = "Count: " + _elementIds.Count;
			}

			Debug.IndentLevel = 1;
			Debug.Print(message);
			Debug.IndentLevel = 0;
			Debug.WriteLine("--------------------------------------------------------------------------");
		}

		#endregion

	}

}