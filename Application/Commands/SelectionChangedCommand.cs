// /////////////////////////////////////////////////////////////
// Solution:............ Test
// Project:............. BaseRevitModeless
// File:................ SelectionChangedCommand.cs
// Last Code Cleanup:... 01/02/2020 @ 1:05 PM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
// Development Notes
namespace BaseRevitModeless.Commands
{

	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Diagnostics;
	using System.Linq;

	using Autodesk.Revit.Attributes;
	using Autodesk.Revit.DB;
	using Autodesk.Revit.UI;
	using Autodesk.Windows;

	// Development Notes
	// https://www.notion.so/SelectionChangedCommand-cs-90454dbb87a544b1a22ca914d14ae1cd

	[Transaction(TransactionMode.ReadOnly)]
	public class SelectionChangedCommand : IExternalCommand
	{

		#region Fields (SC)

		private static List<ElementId> _elementIds;

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


		private static void GetElementIds()
		{
			Debug.WriteLine("--------------------------------------------------------------------------");

			_elementIds = App.UIApp.ActiveUIDocument.Selection.GetElementIds().OrderBy(elementId => elementId.IntegerValue).ToList();


			var eidCount = 1;

			string elementIdsForMessage;

			if(_elementIds.Count == 0)
			{
				elementIdsForMessage = "<nil>";
			}
			else
			{
				elementIdsForMessage = string.Join(",  ", _elementIds.Select(id => id.IntegerValue + " [" + eidCount++ + "]"));
			}

			var message = $"Selection Changed - Element Id's: {elementIdsForMessage}";

			Debug.IndentLevel = 1;

			Debug.Print(message);

			if(!_subscribed)
			{
				Debug.Print("");
				Debug.IndentLevel = 1;
				Debug.Print($"Why is the \'PanelEvent\' still firing when \'_subscribed\' = {_subscribed}");
			}

			Debug.WriteLine("--------------------------------------------------------------------------");
		}


		private void TabActivatedEvent(object sender, EventArgs e)
		{
			Debug.Assert(sender is RibbonTab, "expected sender to be a ribbon tab");

			Debug.IndentLevel = 1;

			Debug.Print("Tab Activated Event Event Fired");

			GetElementIds();
		}


		private void TabDeactivatedEvent(object sender, EventArgs e)
		{
			Debug.Assert(sender is RibbonTab, "expected sender to be a ribbon tab");

			Debug.IndentLevel = 1;

			Debug.Print("Tab Deactivated Event Event Fired");

			GetElementIds();
		}


		private void TabHostEvent(object sender, EventArgs e)
		{
			Debug.Assert(sender is RibbonTab, "expected sender to be a ribbon tab");

			Debug.IndentLevel = 1;

			Debug.Print("Tab Host Event Fired");

			GetElementIds();
		}


		private void TabInitializingEvent(object sender, EventArgs e)
		{
			Debug.Assert(sender is RibbonTab, "expected sender to be a ribbon tab");

			Debug.IndentLevel = 1;

			Debug.Print("Tab Initializing Event Fired");

			GetElementIds();
		}


		private void TabPropertyChangedEvent(object sender, PropertyChangedEventArgs e)
		{
			Debug.Assert(sender is RibbonTab, "expected sender to be a ribbon tab");

			Debug.IndentLevel = 1;

			Debug.Print("Tab Property Changed Event Fired");

			var comparer1 = e.PropertyName;
			var comparer2 = "Title";

			var areStringsEquals = string.Equals(comparer1, comparer2, StringComparison.CurrentCultureIgnoreCase);

			if(areStringsEquals)
			{
				GetElementIds();
			}
		}


		private void ToggleSubscription()
		{
			foreach(var tab in ComponentManager.Ribbon.Tabs)
			{
				if(tab.Id == "Modify")
				{
					if(_subscribed)
					{
						// TODO - Figure out how to kill the event for real!
						tab.PropertyChanged -= TabPropertyChangedEvent;
						tab.Activated       -= TabActivatedEvent;
						tab.Initializing    -= TabInitializingEvent;
						tab.Deactivated     -= TabDeactivatedEvent;
						tab.HostEvent       -= TabHostEvent;

						_subscribed = false;
					}
					else
					{
						tab.PropertyChanged += TabPropertyChangedEvent;
						tab.Activated       += TabActivatedEvent;
						tab.Initializing    += TabInitializingEvent;
						tab.Deactivated     += TabDeactivatedEvent;
						tab.HostEvent       += TabHostEvent;

						_subscribed = true;
						_subscribedCount++;
					}

					break;
				}
			}
		}

		#endregion

	}

}