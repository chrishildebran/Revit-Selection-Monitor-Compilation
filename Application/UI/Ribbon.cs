// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitor
// Project:............. Core
// File:................ Ribbon.cs
// Last Code Cleanup:... 01/14/2020 @ 7:37 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
namespace SelectionMonitorCore.UI
{

	using System.Reflection;

	using Autodesk.Revit.UI;

	public class Ribbon
	{

		#region Constructors

		public Ribbon(string tabName, string panelName)
		{
			RibbonPanelName = panelName;
			RibbonTabName   = tabName;
			Create();
		}

		#endregion

		#region Properties

		public static string RibbonPanelName
		{
			get;
			private set;
		}

		public static string RibbonTabName
		{
			get;
			private set;
		}

		private static string ImagePath{get {return"SelectionMonitorCore.UI.Images.";}}

		private static string Path{get {return Assembly.GetExecutingAssembly().Location;}}

		#endregion

		#region Methods (SC)

		private static void Create()
		{
			// Tab
			App.UIContApp.CreateRibbonTab(RibbonTabName);


			// On Idling Selection Monitor
			var panelOnIdlingMonitor = App.UIContApp.CreateRibbonPanel(RibbonTabName, "OnIdling");
			panelOnIdlingMonitor.AddItem(OnIdlingCommand(RibbonPanelName + panelOnIdlingMonitor));


			// On Property Change Selection Monitor
			var panelOnPropertyChange = App.UIContApp.CreateRibbonPanel(RibbonTabName, "OnPropertyChange");
			panelOnPropertyChange.AddItem(OnPropertyChangedCommand(RibbonPanelName + panelOnPropertyChange));


			// Fair Selection Monitor
			var panelFairFiftyNine = App.UIContApp.CreateRibbonPanel(RibbonTabName, "FairPanel");
			panelFairFiftyNine.AddItem(FairFiftyNineCommand());
		}


		private static PushButtonData FairFiftyNineCommand()
		{
			var buttonName      = "FairButtonItem";
			var fairButtonTitle = "Fair Method";

			return new PushButtonData(buttonName, fairButtonTitle, Path, "SelectionMonitorCore.Commands.MonitorFairCommand")
			       {
				       //LargeImage            = Utilities.GetBitmapFrame(ImagePath + "startstop_32.png"),
				       //Image                 = Utilities.GetBitmapFrame(ImagePath + "startstop_16.png"),
				       AvailabilityClassName = "SelectionMonitorCore.Commands.Enablers.MonitorFairCommandEnabler"
			       };
		}


		private static PushButtonData OnIdlingCommand(string ribbonAndPanelName)
		{
			var buttonName  = "OnIdlingCommand";
			var buttonTitle = "Start/Stop";

			return new PushButtonData(ribbonAndPanelName + buttonName, buttonTitle, Path, "SelectionMonitorCore.Commands.MonitorOnIdlingCommand")
			       {
				       LargeImage = Utilities.GetBitmapFrame(ImagePath + "startstop_32.png"),
				       Image      = Utilities.GetBitmapFrame(ImagePath + "startstop_16.png")
			       };
		}


		private static PushButtonData OnPropertyChangedCommand(string ribbonAndPanelName)
		{
			var buttonName  = "OnPropertyChangedCommand";
			var buttonTitle = "Start/Stop";

			return new PushButtonData(ribbonAndPanelName + buttonName, buttonTitle, Path, "SelectionMonitorCore.Commands.MonitorOnPropertyChangeCommand")
			       {
				       LargeImage = Utilities.GetBitmapFrame(ImagePath + "startstop_32.png"),
				       Image      = Utilities.GetBitmapFrame(ImagePath + "startstop_16.png")
			       };
		}

		#endregion

	}

}