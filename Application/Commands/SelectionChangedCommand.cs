// /////////////////////////////////////////////////////////////
// Solution:............ Kelly Development
// Project:............. BaseRevitModeless
// File:................ SelectionChangedCommand.cs
// Last Code Cleanup:... 12/31/2019 @ 12:59 PM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
namespace BaseRevitModeless.Commands
{

	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Diagnostics;
	using System.Linq;

	using Autodesk.Revit.ApplicationServices;
	using Autodesk.Revit.Attributes;
	using Autodesk.Revit.DB;
	using Autodesk.Revit.UI;
	using Autodesk.Windows;

	// https://thebuildingcoder.typepad.com/blog/2015/03/element-selection-changed-event.html
	// https://github.com/jeremytammik/the_building_coder_samples/blob/master/BuildingCoder/BuildingCoder/CmdSelectionChanged.cs

	// What ive tried
	// 1) Get UIApplication only once. Suggested by Jeremy here: http://disq.us/p/26ct2oj
	// 2) Does disposing of a selection help any? "App.Uiapp.ActiveUIDocument.Selection.Dispose();" No.
	// 3) Does unloading and reloading a panel on the tab jog things? "	tab.Panels.Remove(new  Autodesk.Windows.RibbonPanel());" No
	// 4) Can i fiddle with the Tab Title?
	// 5) What property change triggers the event. Property of what?

	[Transaction(TransactionMode.ReadOnly)]
	public class SelectionChangedCommand : IExternalCommand
	{

		#region Fields (SC)

		private static ExternalCommandData _commandData;

		private Application _rvtApp;

		private static Document _rvtDoc;

		private UIApplication _rvtUiApp;

		private UIDocument _rvtUiDoc;

		private static bool _subscribed;

		#endregion

		#region Methods (SC)

		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			if(_rvtUiApp is null) // #1
			{
				_rvtUiApp = App.Uiapp; // #1
			}

			_commandData = commandData;
			_rvtApp      = commandData.Application.Application;
			_rvtDoc      = commandData.Application.ActiveUIDocument.Document;
			_rvtUiDoc    = commandData.Application.ActiveUIDocument;

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
						tab.PropertyChanged += PanelEvent;
						_subscribed         =  true;
					}

					//Utility.TabPropertyDataExport(_rvtDoc, tab);
					//Utility.TabEventDataExport(_rvtDoc, tab);
					//Utility.TabMemberDataExport(_rvtDoc, tab);

					break;
				}
			}

			Debug.WriteLine("--------------------------------------------------------------------------");
			Debug.IndentLevel = 1;
			Debug.Print($"CmdSelectionChanged - _subscribed = {_subscribed}");
			Debug.IndentLevel = 0;
			Debug.WriteLine("--------------------------------------------------------------------------");

			return Result.Succeeded;
		}


		private void PanelEvent(object sender, PropertyChangedEventArgs e)
		{
			Debug.Assert(sender is RibbonTab, "expected sender to be a ribbon tab");

			var tab = (RibbonTab) sender;


			var areStringsEquals = string.Equals(e.PropertyName, "Title", StringComparison.CurrentCultureIgnoreCase);

			if(areStringsEquals)
			{
				Debug.WriteLine("--------------------------------------------------------------------------");

				List<ElementId> elementIds = _rvtUiApp.ActiveUIDocument.Selection.GetElementIds().OrderBy(elementId => elementId.IntegerValue).ToList(); // #1

				var elementIdsCount = elementIds.Count;

				var eidCount = 1;

				string elementIdsForMessage;

				if(elementIdsCount == 0)
				{
					elementIdsForMessage = "<nil>";
				}
				else
				{
					elementIdsForMessage = string.Join(",  ", elementIds.Select(id => id.IntegerValue + " [" + eidCount++ + "]"));
				}

				var message = $"Selection Changed - Element Id's: {elementIdsForMessage}";

				Debug.IndentLevel = 1;
				Debug.Print(message);
				Debug.IndentLevel = 0;

				if(!_subscribed)
				{
					Debug.Print("");
					Debug.Print($"Why is the \'PanelEvent\' still firing when \'_subscribed\' = {_subscribed}");
					Debug.Print(App.Uiapp.ToString()); //
				}

				Debug.WriteLine("--------------------------------------------------------------------------");
			}


			//else
			//{
			//	Debug.Print($"Event Property Name: {e.PropertyName}");
			//}
		}

		#endregion

	}

}