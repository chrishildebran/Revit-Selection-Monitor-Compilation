// /////////////////////////////////////////////////////////////
// Solution:............ Test
// Project:............. BaseRevitModeless
// File:................ App.cs
// Last Code Cleanup:... 01/02/2020 @ 11:09 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
namespace BaseRevitModeless
{

	using System.Reflection;

	using Autodesk.Revit.Attributes;
	using Autodesk.Revit.UI;

	using BaseRevitModeless.Ribbon;
	using BaseRevitModeless.Utilities;

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
			return Result.Succeeded;
		}


		public Result OnStartup(UIControlledApplication uiContApp)
		{
			UIContApp = uiContApp;
			UIApp     = GetUiApplication();

			var ribbon = new RibbonTab();
			ribbon.Create(uiContApp);

			if(!References.LoadTelerikReferences(typeof(App).Assembly))
			{
				TaskDialog.Show("Reference Load Error", "One or more references the Kelly Tools For Revit Addin depends upon did not load during Revit startup.");
			}

			return Result.Succeeded;
		}


		private static UIApplication GetUiApplication()
		{
			var uiContApp = UIContApp;

			var versionNumber = uiContApp.ControlledApplication.VersionNumber;

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

			var fieldInfo = uiContApp.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);

			var uiApplication = (UIApplication) fieldInfo?.GetValue(uiContApp);

			return uiApplication;
		}

		#endregion

	}

}