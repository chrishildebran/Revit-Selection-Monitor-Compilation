// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitorCompilation
// Project:............. Core
// File:................ Ribbon.cs
// Last Code Cleanup:... 01/17/2020 @ 8:02 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
namespace SelectionMonitorCompilationCore.UI
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

		private static string AssemblyPath{get {return Assembly.GetExecutingAssembly().Location;}}

		private static string ImagePath{get {return"SelectionMonitorCompilationCore.UI.Icons.";}}

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
			var buttonName  = "FairButtonItem";
			var buttonTitle = "Fair Method";

			return new PushButtonData(buttonName, buttonTitle, AssemblyPath, "SelectionMonitorCompilationCore.Commands.MonitorFairCommand")
			       {
				       LargeImage            = RibbonUtilities.GetBitmapFrame(ImagePath + "startstop_32.png"),
				       Image                 = RibbonUtilities.GetBitmapFrame(ImagePath + "startstop_16.png"),
				       AvailabilityClassName = "SelectionMonitorCompilationCore.Commands.Enablers.MonitorFairCommandEnabler"
			       };
		}


		private static PushButtonData OnIdlingCommand(string ribbonAndPanelName)
		{
			var buttonName  = "OnIdlingCommand";
			var buttonTitle = "Start/Stop";

			return new PushButtonData(ribbonAndPanelName + buttonName, buttonTitle, AssemblyPath, "SelectionMonitorCompilationCore.Commands.MonitorOnIdlingCommand")
			       {
				       LargeImage = RibbonUtilities.GetBitmapFrame(ImagePath + "startstop_32.png"),
				       Image      = RibbonUtilities.GetBitmapFrame(ImagePath + "startstop_16.png")
			       };
		}


		private static PushButtonData OnPropertyChangedCommand(string ribbonAndPanelName)
		{
			var buttonName  = "OnPropertyChangedCommand";
			var buttonTitle = "Start/Stop";

			return new PushButtonData(ribbonAndPanelName + buttonName, buttonTitle, AssemblyPath, "SelectionMonitorCompilationCore.Commands.MonitorOnPropertyChangeCommand")
			       {
				       LargeImage = RibbonUtilities.GetBitmapFrame(ImagePath + "startstop_32.png"),
				       Image      = RibbonUtilities.GetBitmapFrame(ImagePath + "startstop_16.png")
			       };
		}

		#endregion

	}

}