// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitor
// Project:............. Core
// File:................ UiPushButtons.cs
// Last Code Cleanup:... 01/13/2020 @ 10:55 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
// Development Notes
namespace SelectionMonitorCore.Ribbon
{

	using System.Reflection;

	using Autodesk.Revit.UI;

	public static class UiPushButtons
	{

		#region Properties (SC)

		private static string ImagePath{get {return"SelectionMonitorCore.Ribbon.Images.";}}

		private static string Path{get {return Assembly.GetExecutingAssembly().Location;}}

		#endregion

		#region Methods (SC)

		public static PushButtonData MonitorFairButtonCommand()
		{
			var fairButtonItemName = "FairButtonItem";
			var fairButtonTitle    = "Fair Method";

			return new PushButtonData(fairButtonItemName, fairButtonTitle, Path, "SelectionMonitorCore.Commands.MonitorFairCommand")
			       {
				       LargeImage            = Image.Get(ImagePath + "AceOfSpades_32.png"),
				       Image                 = Image.Get(ImagePath + "AceOfSpades_16.png"),
				       AvailabilityClassName = "SelectionMonitorCore.Commands.Enablers.MonitorFairCommandEnabler"
			       };
		}


		public static PushButtonData MonitorOnIdlingCommand(string ribbonAndPanelName)
		{
			var methodName  = "MonitorOnIdlingCommand";
			var buttonTitle = "On\nProject Idling";

			return new PushButtonData(ribbonAndPanelName + methodName, buttonTitle, Path, "SelectionMonitorCore.Commands.MonitorOnIdlingCommand")
			       {
				       LargeImage = Image.Get(ImagePath + "AceOfSpades_32.png"),
				       Image      = Image.Get(ImagePath + "AceOfSpades_16.png")
			       };
		}


		public static PushButtonData MonitorOnPropertyChangedCommand(string ribbonAndPanelName)
		{
			var methodName  = "MonitorOnPropertyChangedCommand";
			var buttonTitle = "On\nProperty Change";

			return new PushButtonData(ribbonAndPanelName + methodName, buttonTitle, Path, "SelectionMonitorCore.Commands.MonitorOnPropertyChangeCommand")
			       {
				       LargeImage = Image.Get(ImagePath + "AceOfSpades_32.png"),
				       Image      = Image.Get(ImagePath + "AceOfSpades_16.png")
			       };
		}

		#endregion

	}

}