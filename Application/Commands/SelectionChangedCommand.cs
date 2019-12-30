// /////////////////////////////////////////////////////////////
// Solution:............ Kelly Development
// Project:............. BaseRevitModeless
// File:................ SelectionChangedCommand.cs
// Last Code Cleanup:... 12/30/2019 @ 8:50 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
namespace BaseRevitModeless.Commands
{

	// https://thebuildingcoder.typepad.com/blog/2015/03/element-selection-changed-event.html
	// https://github.com/jeremytammik/the_building_coder_samples/blob/master/BuildingCoder/BuildingCoder/CmdSelectionChanged.cs
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Diagnostics;
	using System.Linq;
	using System.Reflection;

	using Autodesk.Revit.Attributes;
	using Autodesk.Revit.DB;
	using Autodesk.Revit.UI;
	using Autodesk.Windows;

	//using System.Windows.Controls.Ribbon;

	[Transaction(TransactionMode.ReadOnly)]
	internal class SelectionChangedCommand : IExternalCommand
	{

		#region Fields (SC)

		private UIApplication _rvtUiApp;

		private static bool _subscribed;

		#endregion

		#region Methods (SC)

		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			// Iterate through Ribbon Tabs
			foreach(var tab in ComponentManager.Ribbon.Tabs)
			{
				// Look for Tab named "Modify"
				if(tab.Id == "Modify")
				{
					if(_subscribed)
					{
						tab.PropertyChanged -= PanelEvent;
						_subscribed         =  false;

						NewMethod(_subscribed);
					}
					else
					{
						tab.PropertyChanged += PanelEvent;
						_subscribed         =  true;

						NewMethod(_subscribed);
					}

					break;
				}
			}

			Debug.Print($"CmdSelectionChanged: _subscribed = {_subscribed}");

			return Result.Succeeded;
		}


		private static void NewMethod(bool subscribed)
		{
			var bindingFlags = BindingFlags.Instance | BindingFlags.Public;

			var typeEvent = typeof(UIApplication);

			EventInfo[] eventsBindingFlags = typeEvent.GetEvents();

			Debug.WriteLine("\nThe events on the UIApplication class with the specified BindingFlags are : ");

			Debug.WriteLine("--------------------------------------------------------------------------");
			Debug.WriteLine($"Subscribed: {subscribed}");

			for(var index = 0; index < eventsBindingFlags.Length; index++)
			{
				Debug.WriteLine(eventsBindingFlags[index].ToString());
			}

			Debug.WriteLine("--------------------------------------------------------------------------");
		}


		private void PanelEvent(object sender, PropertyChangedEventArgs e)
		{
			Debug.Assert(sender is RibbonTab, "expected sender to be a ribbon tab");

			var propertyName = e.PropertyName;

			if(propertyName == "Title")
			{
				Debug.WriteLine("--------------------------------------------------------------------------");


				// Get UIApplication only once. Suggested by Jeremy here: http://disq.us/p/26ct2oj
				List<ElementId> eOrdered = App.Uiapp.ActiveUIDocument.Selection.GetElementIds().OrderBy(elementId => elementId.IntegerValue).ToList();

				var n = eOrdered.Count;

				var eidCount = 1;

				string s;

				if(0 == n)
				{
					s = "<nil>";
				}
				else
				{
					s = string.Join(",  ", eOrdered.Select(id => id.IntegerValue + " [" + eidCount++ + "]"));
				}

				var message = $"CmdSelectionChanged:  Element Id's: {s}";

				Debug.Indent();
				Debug.Print(message);
				Debug.IndentLevel = 0;
				Debug.WriteLine("--------------------------------------------------------------------------");

				if(!_subscribed)
				{
					Debug.Print($"Why is the \'PanelEvent\' still being called when \'_subscribed\' = {_subscribed}");
				}
			}
			else
			{
				Debug.Print($"Event Property Name: {e.PropertyName}");
			}
		}

		#endregion

	}

}