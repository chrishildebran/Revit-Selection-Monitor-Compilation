// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitor
// Project:............. Core
// File:................ MonitorOnIdling.cs
// Last Code Cleanup:... 01/06/2020 @ 8:43 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
// Development Notes
namespace SelectionMonitorCore.Events
{

	using System;
	using System.Collections.Generic;
	using System.Diagnostics;

	using Autodesk.Revit.DB;
	using Autodesk.Revit.UI.Events;

	using SelectionMonitorCore.Utilities;

	internal class MonitorOnIdling
	{

		#region Fields (SC)

		private List<int> _lastSelIds;

		#endregion

		#region Constructors (SC)

		public MonitorOnIdling()
		{
			Debug.WriteLine("SelectionWatcher - Constructor");

			App.UIContApp.Idling += OnIdling;
		}

		#endregion

		#region Destructors (SC)

		~MonitorOnIdling()
		{
			Debug.WriteLine("SelectionWatcher - Destructor");

			App.UIContApp.Idling -= OnIdling;
		}

		#endregion

		#region  Events (SC)

		public event EventHandler SelectionChanged;

		#endregion

		#region Properties (SC)

		public List<ElementId> SelectedElementIds
		{
			get;
			set;
		}

		#endregion

		#region Methods (SC)

		private void Call_SelectionChangedEvent()
		{
			Debug.WriteLine($"{CodeLocation.GetClassName(1)} - {CodeLocation.GetMethodName(1)}");

			SelectionChanged?.Invoke(this, new EventArgs());
		}


		private void HandleSelectionChange(IEnumerable<ElementId> selectedElementIds)
		{
			Debug.WriteLine($"{CodeLocation.GetClassName(1)} - {CodeLocation.GetMethodName(1)}");

			SelectedElementIds = new List<ElementId>();
			_lastSelIds        = new List<int>();

			foreach(var elementId in selectedElementIds)
			{
				SelectedElementIds.Add(elementId);
				_lastSelIds.Add(elementId.IntegerValue);
			}

			Call_SelectionChangedEvent();
		}


		private void OnIdling(object sender, IdlingEventArgs e)
		{
			ICollection<ElementId> selected = App.UIApp.ActiveUIDocument.Selection.GetElementIds();

			if(selected.Count == 0)
			{
				if(SelectedElementIds != null && SelectedElementIds.Count > 0)

				{
					HandleSelectionChange(selected);
				}
			}
			else
			{
				if(SelectedElementIds == null)
				{
					HandleSelectionChange(selected);
				}
				else
				{
					if(SelectedElementIds.Count != selected.Count)
					{
						HandleSelectionChange(selected);
					}
					else
					{
						if(SelectionHasChanged(selected))
						{
							HandleSelectionChange(selected);
						}
					}
				}
			}
		}


		private bool SelectionHasChanged(IEnumerable<ElementId> selectedElementIds)
		{
			var i = 0;

			foreach(var elementId in selectedElementIds)
			{
				if(_lastSelIds[i] != elementId.IntegerValue)
				{
					return true;
				}

				++i;
			}

			return false;
		}

		#endregion

	}

}