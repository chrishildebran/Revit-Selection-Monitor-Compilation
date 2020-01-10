// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitor
// Project:............. Core
// File:................ MonitorOnPropertyChangeCommand.cs
// Last Code Cleanup:... 01/10/2020 @ 1:00 PM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
// Development Notes
namespace SelectionMonitorCore.Commands
{

	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Linq;

	using Autodesk.Revit.Attributes;
	using Autodesk.Revit.DB;
	using Autodesk.Revit.UI;
	using Autodesk.Windows;

	using SelectionMonitorCore.Utilities;

	// Development Notes
	// https://www.notion.so/SelectionChangedCommand-cs-90454dbb87a544b1a22ca914d14ae1cd

	[Transaction(TransactionMode.ReadOnly)]
	public class MonitorOnPropertyChangeCommand : IExternalCommand
	{

		#region Fields (SC)

		private static List<ElementId> _elementIds;

		private static bool _subscribed;

		#endregion

		#region Methods (SC)

		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			foreach(var tab in ComponentManager.Ribbon.Tabs)
			{
				if(tab.Id == "Modify")
				{
					if(_subscribed)
					{
						// TODO - Figure out how to kill the event for real!
						tab.PropertyChanged -= TabPropertyChangedEvent;

						_subscribed = false;
					}
					else
					{
						tab.PropertyChanged += TabPropertyChangedEvent;

						_subscribed = true;
					}

					break;
				}
			}

			Messaging.DebugMessage($"OnPropertyChanged Subscription Changed: Subscribed = {_subscribed}");

			return Result.Succeeded;
		}


		private static void TabPropertyChangedEvent(object sender, PropertyChangedEventArgs e)
		{
			if(!(sender is RibbonTab))
			{
				Messaging.TypeError();

				return;
			}

			if(!string.Equals(e.PropertyName, "Title", StringComparison.CurrentCultureIgnoreCase))
			{
				return;
			}


			// Start
			_elementIds = App.UIApp.ActiveUIDocument.Selection.GetElementIds().OrderBy(elementId => elementId.IntegerValue).ToList();

			Messaging.DebugMessageString(_subscribed, _elementIds, "OnPropertyChanged");
		}

		#endregion

	}

}