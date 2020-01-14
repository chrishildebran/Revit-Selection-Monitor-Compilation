// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitor
// Project:............. Core
// File:................ MonitorOnIdling.cs
// Last Code Cleanup:... 01/14/2020 @ 7:37 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
namespace SelectionMonitorCore.Utilities
{

	using System;
	using System.Collections.Generic;

	using Autodesk.Revit.DB;
	using Autodesk.Revit.UI.Events;

	internal class MonitorOnIdling
	{

		#region Fields

		private List<int> _lastSelIds;

		#endregion

		#region  Events

		public event EventHandler SelectionChanged;

		#endregion

		#region Properties

		public List<ElementId> SelectedElementIds
		{
			get;
			set;
		}

		#endregion

		#region Methods (SC)

		public void OnIdlingEvent(object sender, IdlingEventArgs e)
		{
			ICollection<ElementId> latestSelection = App.UIApp.ActiveUIDocument.Selection.GetElementIds();

			if(latestSelection.Count == 0)
			{
				if(SelectedElementIds != null && SelectedElementIds.Count > 0)

				{
					HandleSelectionChange(latestSelection);
				}
			}
			else
			{
				if(SelectedElementIds == null)
				{
					HandleSelectionChange(latestSelection);
				}
				else
				{
					if(SelectedElementIds.Count != latestSelection.Count)
					{
						HandleSelectionChange(latestSelection);
					}
					else
					{
						if(SelectionHasChanged(latestSelection))
						{
							HandleSelectionChange(latestSelection);
						}
					}
				}
			}
		}


		private void HandleSelectionChange(IEnumerable<ElementId> elementIds)
		{
			SelectedElementIds = new List<ElementId>();
			_lastSelIds        = new List<int>();

			foreach(var elementId in elementIds)
			{
				SelectedElementIds.Add(elementId);
				_lastSelIds.Add(elementId.IntegerValue);
			}

			InvokeSelectionChangedEvent();
		}


		private void InvokeSelectionChangedEvent()
		{
			SelectionChanged?.Invoke(this, new EventArgs());
		}


		private bool SelectionHasChanged(IEnumerable<ElementId> elementIds)
		{
			var i = 0;

			foreach(var elementId in elementIds)
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