// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitorCompilation
// Project:............. Core
// File:................ MonitorOnPropertyChangeCommand.cs
// Last Code Cleanup:... 01/17/2020 @ 8:16 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
namespace SelectionMonitorCompilationCore.Tools
{

	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Linq;

	using Autodesk.Revit.Attributes;
	using Autodesk.Revit.DB;
	using Autodesk.Revit.UI;
	using Autodesk.Windows;

	using SelectionMonitorCompilationCore.Shared.Utilities;

	[Transaction(TransactionMode.ReadOnly)]
	public class MonitorOnPropertyChangeCommand : IExternalCommand
	{

		#region Fields

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
				Messaging.DebugMessage("Expected Sender To Be A Ribbon Tab");

				return;
			}

			if(!string.Equals(e.PropertyName, "Title", StringComparison.CurrentCultureIgnoreCase))
			{
				return;
			}

			List<ElementId> elementIds = App.UIApp.ActiveUIDocument.Selection.GetElementIds().OrderBy(elementId => elementId.IntegerValue).ToList();

			Messaging.DebugMessage(_subscribed, elementIds, "Vilo's - OnPropertyChanged", true);
		}

		#endregion

	}

}