// /////////////////////////////////////////////////////////////
// Solution:............ Base Revit Modeless
// Project:............. Application
// File:................ App.cs
// Last Code Cleanup:... 12/27/2019 @ 8:01 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
namespace Application
{

	using Application.Ribbon;
	using Application.Utilities;

	using Autodesk.Revit.Attributes;
	using Autodesk.Revit.UI;

	[Transaction(TransactionMode.Manual)]
	public class App : IExternalApplication
	{

		#region Methods (SC)

		public Result OnShutdown(UIControlledApplication a)
		{
			return Result.Succeeded;
		}


		public Result OnStartup(UIControlledApplication uiControlledApplication)
		{
			RibbonTab.Create(uiControlledApplication);

			if(!References.LoadTelerikReferences(typeof(App).Assembly))
			{
				TaskDialog.Show("Reference Load Error", "One or more references the Kelly Tools For Revit Addin depends upon did not load during Revit startup.");
			}

			return Result.Succeeded;
		}

		#endregion

	}

}