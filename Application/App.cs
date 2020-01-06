// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitor
// Project:............. Core
// File:................ App.cs
// Last Code Cleanup:... 01/06/2020 @ 8:43 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
// Development Notes
namespace SelectionMonitorCore
{

	using System.Diagnostics;
	using System.Reflection;

	using Autodesk.Revit.Attributes;
	using Autodesk.Revit.UI;

	using SelectionMonitorCore.Events;
	using SelectionMonitorCore.Ribbon;
	using SelectionMonitorCore.Utilities;

	[Transaction(TransactionMode.Manual)]
	internal class App : IExternalApplication
	{

		#region Fields (SC)

		public static UIApplication UIApp;

		public static UIControlledApplication UIContApp;

		#endregion

		#region Methods (SC)

		public Result OnShutdown(UIControlledApplication uiContApp)
		{
			Debug.WriteLine($"{CodeLocation.GetClassName(1)} - {CodeLocation.GetMethodName(1)}");

			EventFactory.ShutDown();

			return Result.Succeeded;
		}


		public Result OnStartup(UIControlledApplication uiContApp)
		{
			Debug.WriteLine($"{CodeLocation.GetClassName(1)} - {CodeLocation.GetMethodName(1)}");

			UIContApp = uiContApp;
			UIApp     = GetUiApplication();

			EventFactory.StartUp();

			var ribbon = new RibbonTab();
			ribbon.Create();

			if(!References.LoadTelerikReferences(typeof(App).Assembly))
			{
				TaskDialog.Show("Reference Load Error", "One or more references the Kelly Tools For Revit Addin depends upon did not load during Revit startup.");
			}

			return Result.Succeeded;
		}


		private static UIApplication GetUiApplication()
		{
			Debug.WriteLine($"{CodeLocation.GetClassName(1)} - {CodeLocation.GetMethodName(1)}");

			var versionNumber = UIContApp.ControlledApplication.VersionNumber;

			var fieldName = string.Empty;

			switch(versionNumber)
			{
				case"2017" :

					fieldName = "m_uiapplication";

					break;

				case"2018" :

					fieldName = "m_uiapplication";

					break;

				case"2019" :

					fieldName = "m_uiapplication";

					break;

				case"2020" :

					fieldName = "m_uiapplication";

					break;
			}

			var fieldInfo = UIContApp.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);

			var uiApplication = (UIApplication) fieldInfo?.GetValue(UIContApp);

			return uiApplication;
		}

		#endregion

	}

}