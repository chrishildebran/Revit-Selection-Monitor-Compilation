// /////////////////////////////////////////////////////////////
// Solution:............ Kelly Development
// Project:............. BaseRevitModeless
// File:................ SelectionChangedCommand.cs
// Last Code Cleanup:... 12/27/2019 @ 2:46 PM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
namespace BaseRevitModeless.Commands
{

	// https://thebuildingcoder.typepad.com/blog/2015/03/element-selection-changed-event.html
	// https://github.com/jeremytammik/the_building_coder_samples/blob/master/BuildingCoder/BuildingCoder/CmdSelectionChanged.cs
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Diagnostics;
	using System.Linq;

	using Autodesk.Revit.ApplicationServices;
	using Autodesk.Revit.Attributes;
	using Autodesk.Revit.DB;
	using Autodesk.Revit.UI;
	using Autodesk.Windows;

	//using System.Windows.Controls.Ribbon;

	[Transaction(TransactionMode.ReadOnly)]
	internal class SelectionChangedCommand : IExternalCommand
	{

		#region Fields (SC)

		private Application _rvtApp;

		private ExternalCommandData _rvtCommandData;

		private static Document _rvtDoc;

		private UIApplication _rvtUiApp;

		private UIDocument _rvtUiDoc;

		private static bool _subscribed;

		#endregion

		#region Methods (SC)

		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			{
				_rvtCommandData = commandData;
				_rvtApp         = commandData.Application.Application;
				_rvtDoc         = commandData.Application.ActiveUIDocument.Document;
				_rvtUiApp       = commandData.Application;
				_rvtUiDoc       = commandData.Application.ActiveUIDocument;
			}

			foreach(var tab in ComponentManager.Ribbon.Tabs)
			{
				if(tab.Id == "Modify")
				{
					if(_subscribed)
					{
						tab.PropertyChanged -= PanelEvent;
						_subscribed         =  false;
					}
					else
					{
						//tab.PropertyChanged -= PanelEvent; // Added based on reading https://forums.xamarin.com/discussion/112676/eventhandler-not-being-removed-despite-being-unsubscribed
						tab.PropertyChanged += PanelEvent;
						_subscribed         =  true;
					}

					break;
				}
			}

			Debug.Print("CmdSelectionChanged: _subscribed = {0}", _subscribed);

			return Result.Succeeded;
		}


		private static List<Element> GetElementInstancesFromProjectWhereTypeIdExistsOrdered(Document rvtDoc, List<ElementId> elementIds)
		{
			var collector = new FilteredElementCollector(rvtDoc, elementIds).WhereElementIsNotElementType();

			return collector.Where(e => e.GetTypeId() != ElementId.InvalidElementId).OrderBy(e => e.Name).ToList();
		}


		private void PanelEvent(object sender, PropertyChangedEventArgs e)
		{
			Debug.WriteLine("--------------------------------------------------------------------------");

			Debug.Print("Sender: " + sender);

			Debug.Assert(sender is RibbonTab, "expected sender to be a ribbon tab");

			if(e.PropertyName == "Title")
			{
				List<ElementId> eOrdered = _rvtUiApp.ActiveUIDocument.Selection.GetElementIds().OrderBy(elementId => elementId.IntegerValue).ToList();


				// Get instances
				List<Element> iOrdered = null;

				if(eOrdered.Count > 0)
				{
					iOrdered = GetElementInstancesFromProjectWhereTypeIdExistsOrdered(_rvtDoc, eOrdered);
				}
				else
				{
					return;
				}

				var n = eOrdered.Count;

				var eidCount = 1;
				var iidCount = 1;

				string s1;
				string s2;

				if(0 == n)
				{
					s1 = "<nil>";
					s2 = "<nil>";
				}
				else
				{
					s1 = string.Join(",  ", eOrdered.Select(id => id.IntegerValue + " [" + eidCount++ + "]"));
					s2 = string.Join(",  ", iOrdered.Select(element => element.Id + " [" + iidCount++ + "]"));
				}

				Debug.WriteLine("");
				Debug.Print("CmdSelectionChanged:  Element Id\'s: " + s1);
				Debug.Print("CmdSelectionChanged: Instance Id\'s: " + s2);

				if(!_subscribed)
				{
					Debug.Print("Why is the \'PanelEvent\' still being called when \'_subscribed\' = {0}", _subscribed);
				}
			}
		}

		#endregion

	}

}