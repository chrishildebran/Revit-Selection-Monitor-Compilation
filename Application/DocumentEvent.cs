// /////////////////////////////////////////////////////////////
// Solution:............ Test
// Project:............. BaseRevitModeless
// File:................ DocumentEvent.cs
// Last Code Cleanup:... 01/03/2020 @ 2:52 PM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
// Development Notes
namespace BaseRevitModeless
{

	using System;
	using System.Collections.Generic;
	using System.Diagnostics;

	using Autodesk.Revit.DB;
	using Autodesk.Revit.DB.Events;

	using BaseRevitModeless.Utilities;

	public static class DocumentEvent
	{

		#region Fields (SC)

		private static SelectionWatcher _selectionWatcher;

		#endregion

		#region Methods (SC)

		public static void OnClosing(object sender, DocumentClosingEventArgs e)
		{
			Debug.WriteLine($"{CodeLocation.GetClassName(1)} - {CodeLocation.GetMethodName(1)}");

			_selectionWatcher.SelectionChanged -= SelectionChangedEvent;
		}


		public static void OnOpening(object sender, DocumentOpeningEventArgs e)
		{
			Debug.WriteLine($"{CodeLocation.GetClassName(1)} - {CodeLocation.GetMethodName(1)}");

			_selectionWatcher = new SelectionWatcher();

			_selectionWatcher.SelectionChanged += SelectionChangedEvent;
		}


		private static void SelectionChangedEvent(object sender, EventArgs e)
		{
			Debug.WriteLine($"{CodeLocation.GetClassName(1)} - {CodeLocation.GetMethodName(1)}");

			Debug.WriteLine("--------------------------------------------------------------------------");

			var message = string.Empty;

			if(null == _selectionWatcher.SelectedElementIds)
			{
				message = "No selection";

				return;
			}

			List<ElementId> elementIds = new List<ElementId>(_selectionWatcher.SelectedElementIds);

			if(elementIds.Count == 0)
			{
				message = "No selection";
			}
			else if(elementIds.Count >= 1)
			{
				//message = string.Join(", ", elementIds.Select(id => id.IntegerValue));
				message = "Count: " + elementIds.Count;
			}

			Debug.IndentLevel = 1;
			Debug.Print(message);
			Debug.IndentLevel = 0;
			Debug.WriteLine("--------------------------------------------------------------------------");
		}

		#endregion

	}

}