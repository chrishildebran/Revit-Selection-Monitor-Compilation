// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitor
// Project:............. Core
// File:................ RibbonPushButtons.cs
// Last Code Cleanup:... 01/06/2020 @ 10:02 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
// Development Notes
namespace SelectionMonitorCore.Ribbon
{

	using System.Reflection;

	using Autodesk.Revit.UI;

	using SelectionMonitorCore.Utilities;

	public static class RibbonPushButtons
	{

		#region Properties (SC)

		private static string ImagePath{get {return"SelectionMonitorCore.Ribbon.Images.";}}

		private static string Path{get {return Assembly.GetExecutingAssembly().Location;}}

		#endregion

		#region Methods (SC)

		public static PushButtonData MonitorOnIdlingCommand(string buttonName)
		{
			var methodName  = CodeLocation.GetMethodName(1);
			var buttonTitle = "Monitor On\nProject Idling";

			return new PushButtonData(buttonName + methodName, buttonTitle, Path, "SelectionMonitorCore.Commands.MonitorOnIdlingCommand")
			       {
				       LargeImage = Image.Get(ImagePath + "AceOfSpades_32.png"),
				       Image      = Image.Get(ImagePath + "AceOfSpades_16.png")
			       };
		}


		public static PushButtonData MonitorOnPropertyChangedCommand(string buttonName)
		{
			var methodName  = CodeLocation.GetMethodName(1);
			var buttonTitle = "Monitor On\nProperty Change";

			return new PushButtonData(buttonName + methodName, buttonTitle, Path, "SelectionMonitorCore.Commands.MonitorOnPropertyChangeCommand")
			       {
				       LargeImage = Image.Get(ImagePath + "AceOfSpades_32.png"),
				       Image      = Image.Get(ImagePath + "AceOfSpades_16.png")
			       };
		}

		#endregion

	}

}