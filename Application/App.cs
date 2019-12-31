// /////////////////////////////////////////////////////////////
// Solution:............ Test
// Project:............. BaseRevitModeless
// File:................ App.cs
// Last Code Cleanup:... 12/31/2019 @ 3:09 PM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
namespace BaseRevitModeless
{

	using System.Reflection;

	using Autodesk.Revit.Attributes;
	using Autodesk.Revit.UI;

	using BaseRevitModeless.Ribbon;

	[Transaction(TransactionMode.Manual)]
	public class App : IExternalApplication
	{

		#region Fields (SC)

		public static UIApplication Uiapp;

		#endregion

		#region Methods (SC)

		public Result OnShutdown(UIControlledApplication a)
		{
			return Result.Succeeded;
		}


		public Result OnStartup(UIControlledApplication uiControlledApplication)
		{
			RibbonTab.Create(uiControlledApplication);

			Uiapp = GetUiApplication(uiControlledApplication);


			//if(!References.LoadTelerikReferences(typeof(App).Assembly))
			//{
			//	TaskDialog.Show("Reference Load Error", "One or more references the Kelly Tools For Revit Addin depends upon did not load during Revit startup.");
			//}

			return Result.Succeeded;
		}


		private static UIApplication GetUiApplication(UIControlledApplication uiControlledApplication)
		{
			var versionNumber = uiControlledApplication.ControlledApplication.VersionNumber;
			var fieldName     = string.Empty;

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

			var fieldInfo = uiControlledApplication.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);

			return(UIApplication) fieldInfo?.GetValue(uiControlledApplication);
		}

		#endregion

	}

}