// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitor
// Project:............. Core
// File:................ RibbonPushButtons.cs
// Last Code Cleanup:... 01/06/2020 @ 8:43 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
// Development Notes
namespace SelectionMonitorCore.Ribbon
{

	using System.Reflection;

	using Autodesk.Revit.UI;

	using SelectionMonitorCore.Utilities;

	public static class RibbonPushButtons
	{

		#region Fields (SC)

		private static string path = Assembly.GetExecutingAssembly().Location;

		#endregion

		#region Properties (SC)

		private static string ImagePath{get {return"BaseRevitModeless.Ribbon.Images.";}}

		#endregion

		#region Methods (SC)

		public static PushButtonData MonitorOnIdlingCommand(string buttonNameNew)
		{
			var methodName  = CodeLocation.GetMethodName(1);
			var buttonTitle = "Monitor On\nProject Idling";

			return new PushButtonData(buttonNameNew + methodName, buttonTitle, path, "SelectionMonitorCore.Commands.MonitorOnIdlingCommand")
			       {
				       LargeImage = Image.Get(ImagePath + "AceOfSpades_32.png"),
				       Image      = Image.Get(ImagePath + "AceOfSpades_16.png")
			       };
		}


		public static PushButtonData MonitorOnPropertyChangedCommand(string buttonNameNew)
		{
			var methodName  = CodeLocation.GetMethodName(1);
			var buttonTitle = "Monitor On\nProperty Change";

			return new PushButtonData(buttonNameNew + methodName, buttonTitle, path, "SelectionMonitorCore.Commands.MonitorOnPropertyChangeCommand")
			       {
				       LargeImage = Image.Get(ImagePath + "AceOfSpades_32.png"),
				       Image      = Image.Get(ImagePath + "AceOfSpades_16.png")
			       };
		}


		public static PushButtonData PropertySelectionChangedView(string buttonNameNew)
		{
			var methodName  = CodeLocation.GetMethodName(1);
			var buttonTitle = "Property Selection\nChanged View";

			return new PushButtonData(buttonNameNew + methodName, buttonTitle, path, "SelectionMonitorCore.View.PropertySelectionChangedView")
			       {
				       LargeImage = Image.Get(ImagePath + "AceOfSpades_32.png"),
				       Image      = Image.Get(ImagePath + "AceOfSpades_16.png")
			       };
		}


		public static PushButtonData PropertyView(string buttonNameNew)
		{
			var methodName  = CodeLocation.GetMethodName(1);
			var buttonTitle = "Property View";

			return new PushButtonData(buttonNameNew + methodName, buttonTitle, path, "SelectionMonitorCore.View.PropertyView")
			       {
				       LargeImage = Image.Get(ImagePath + "AceOfSpades_32.png"),
				       Image      = Image.Get(ImagePath + "AceOfSpades_16.png")
			       };
		}

		#endregion

	}

}