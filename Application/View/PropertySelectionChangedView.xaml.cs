// /////////////////////////////////////////////////////////////
// Solution:............ Test
// Project:............. BaseRevitModeless
// File:................ PropertySelectionChangedView.xaml.cs
// Last Code Cleanup:... 01/02/2020 @ 11:09 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
namespace BaseRevitModeless.View
{

	using System.Windows;

	using Autodesk.Revit.Attributes;
	using Autodesk.Revit.DB;
	using Autodesk.Revit.UI;

	using BaseRevitModeless.ViewModel;

	using Application = Autodesk.Revit.ApplicationServices.Application;

	[Transaction(TransactionMode.Manual)]
	public partial class PropertySelectionChangedView : IExternalCommand
	{

		#region Fields (SC)

		private Application _rvtApp;

		private ExternalCommandData _rvtCommandData;

		private Document _rvtDoc;

		private UIApplication _rvtUiApp;

		private UIDocument _rvtUiDoc;

		#endregion

		#region Constructors (SC)

		public PropertySelectionChangedView()
		{
			InitializeComponent();
		}

		#endregion

		#region Methods (SC)

		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elems)
		{
			{
				_rvtCommandData = commandData;
				_rvtApp         = commandData.Application.Application;
				_rvtDoc         = commandData.Application.ActiveUIDocument.Document;
				_rvtUiApp       = commandData.Application;
				_rvtUiDoc       = commandData.Application.ActiveUIDocument;
			}


			//if(_rvtUiDoc.Selection.GetElementIds().Count != 1)
			//{
			//	TaskDialog.Show("Me", "Please select one entity");

			//	return Result.Cancelled;
			//}

			DataContext = new PropertySelectionChangedViewModel(_rvtCommandData);

			Show();

			return Result.Succeeded;
		}


		private void Close_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		#endregion

	}

}