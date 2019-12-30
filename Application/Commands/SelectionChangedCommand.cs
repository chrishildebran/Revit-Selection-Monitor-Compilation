// /////////////////////////////////////////////////////////////
// Solution:............ Kelly Development
// Project:............. BaseRevitModeless
// File:................ SelectionChangedCommand.cs
// Last Code Cleanup:... 12/30/2019 @ 1:57 PM Using ReSharper ✓
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

	// What ive tried: 
	// Does disposing of a selection help any? "App.Uiapp.ActiveUIDocument.Selection.Dispose();" No.
	// Does unloading and reloading a panel on the tab jog things? "	tab.Panels.Remove(new  Autodesk.Windows.RibbonPanel());" No

	[Transaction(TransactionMode.ReadOnly)]
	public class SelectionChangedCommand : IExternalCommand
	{

		#region Fields (SC)

		private Application _rvtApp;

		private ExternalCommandData _rvtCommandData;

		private Document _rvtDoc;

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
					}
					else
					{
						tab.PropertyChanged += PanelEvent;
						_subscribed         =  true;
					}

					break;
				}
			}

			Debug.Print($"CmdSelectionChanged - _subscribed = {_subscribed}");

			return Result.Succeeded;
		}


		private void PanelEvent(object sender, PropertyChangedEventArgs e)
		{
			Debug.Assert(sender is RibbonTab, "expected sender to be a ribbon tab");

			var tab = (RibbonTab) sender;

			var ePropertyName = e.PropertyName;

			var areStringsEquals = string.Equals(ePropertyName, "Title", StringComparison.CurrentCultureIgnoreCase);

			if(areStringsEquals)
			{
				Debug.WriteLine("--------------------------------------------------------------------------");


				// Get UIApplication only once. Suggested by Jeremy here: http://disq.us/p/26ct2oj
				List<ElementId> elementIds = App.Uiapp.ActiveUIDocument.Selection.GetElementIds().OrderBy(elementId => elementId.IntegerValue).ToList();

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

				Debug.IndentLevel = 2;
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