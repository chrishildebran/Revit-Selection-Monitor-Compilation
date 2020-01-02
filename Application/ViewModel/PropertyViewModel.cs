// /////////////////////////////////////////////////////////////
// Solution:............ Test
// Project:............. BaseRevitModeless
// File:................ PropertyViewModel.cs
// Last Code Cleanup:... 01/02/2020 @ 11:09 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
namespace BaseRevitModeless.ViewModel
{

	using System;
	using System.Collections.ObjectModel;
	using System.Collections.Specialized;
	using System.Linq;
	using System.Windows;
	using System.Windows.Input;

	using Autodesk.Revit.DB;
	using Autodesk.Revit.UI;

	using BaseRevitModeless.ExternalEvents;
	using BaseRevitModeless.Model;

	using Telerik.Windows.Controls;
	using Telerik.Windows.Controls.Data.PropertyGrid;

	using Application = Autodesk.Revit.ApplicationServices.Application;
	using Binding = System.Windows.Data.Binding;

	public class PropertyViewModel : ViewModelBase
	{

		#region Fields (SC)

		private ExternalEvent _externalEvent;

		private ObservableCollection<PropertyDefinition> _propertyDefinitions;

		private PropertyExternalEvent _propertyExternalEvent;

		private PropertyModel _propertyModel;

		private ObservableCollection<PropertyModel> _propertyModels;

		private Application _rvtApp;

		private ExternalCommandData _rvtCommandData;

		private Document _rvtDoc;

		private UIApplication _rvtUiApp;

		private UIDocument _rvtUiDoc;

		private ObservableCollection<SettingModel> _settingModels;

		#endregion

		#region Constructors (SC)

		public PropertyViewModel()
		{
		}


		public PropertyViewModel(ExternalCommandData rvtCommandData)
		{
			{
				_rvtCommandData = rvtCommandData;
				_rvtApp         = rvtCommandData.Application.Application;
				_rvtDoc         = rvtCommandData.Application.ActiveUIDocument.Document;
				_rvtUiApp       = rvtCommandData.Application;
				_rvtUiDoc       = rvtCommandData.Application.ActiveUIDocument;
			}

			DelegateCommandAddSetting         = new DelegateCommand(AddSetting);
			DelegateCommandUpdateRevitCommand = new DelegateCommand(UpdateRevit);

			element     = _rvtDoc.GetElement(_rvtUiDoc.Selection.GetElementIds().First());
			elementType = _rvtDoc.GetElement(element.GetTypeId()) as ElementType;

			_propertyExternalEvent = new PropertyExternalEvent
			                         {
				                         ElementType = elementType,
				                         Element     = element
			                         };

			_externalEvent = ExternalEvent.Create(_propertyExternalEvent);
		}

		#endregion

		#region Properties (SC)

		public ICommand DelegateCommandAddSetting
		{
			get;
			set;
		}

		public ICommand DelegateCommandUpdateRevitCommand
		{
			get;
			set;
		}

		public Element element
		{
			get;
		}

		public ElementType elementType
		{
			get;
			set;
		}

		public PropertyModel PropertyModel
		{
			get
			{
				if(_propertyModel == null)
				{
					_propertyModel = new PropertyModel
					                 {
						                 Comments     = element.LookupParameter("Comments")          != null ? element.GetParameters("Comments")[0].AsString() : "",
						                 Model        = elementType.LookupParameter("Model")         != null ? elementType.GetParameters("Model")[0].AsString() : "",
						                 Manufacturer = elementType.LookupParameter("Manufacturer")  != null ? elementType.GetParameters("Manufacturer")[0].AsString() : "",
						                 TypeComments = elementType.LookupParameter("Type Comments") != null ? elementType.GetParameters("Type Comments")[0].AsString() : "",
						                 Description  = elementType.LookupParameter("Description")   != null ? elementType.GetParameters("Description")[0].AsString() : ""
					                 };
				}

				return _propertyModel;
			}
		}

		public ObservableCollection<PropertyModel> PropertyModels
		{
			get
			{
				if(_propertyModels == null)
				{
					_propertyModels = new ObservableCollection<PropertyModel>();

					_propertyModels.CollectionChanged += PropertyModels_CollectionChanged;

					_propertyModels.Add(new PropertyModel
					                    {
						                    Comments     = _propertyModel.Comments,
						                    Model        = _propertyModel.Model,
						                    Manufacturer = _propertyModel.Manufacturer,
						                    TypeComments = _propertyModel.TypeComments,
						                    Description  = _propertyModel.Description
					                    });
				}

				return _propertyModels;
			}
		}
		public ObservableCollection<SettingModel> SettingModels
		{
			get
			{
				if(_settingModels == null)
				{
					_settingModels = new ObservableCollection<SettingModel>();

					_settingModels.CollectionChanged += SettingModelsCollectionChanged;

					_settingModels.Add(new SettingModel
					                   {
						                   Key   = "setting1",
						                   Value = "value1"
					                   });

					_settingModels.Add(new SettingModel
					                   {
						                   Key   = "setting2",
						                   Value = "value2"
					                   });

					_settingModels.Add(new SettingModel
					                   {
						                   Key   = "setting3",
						                   Value = "value3"
					                   });

					_settingModels.Add(new SettingModel
					                   {
						                   Key   = "setting4",
						                   Value = "value4"
					                   });
				}

				return _settingModels;
			}
		}

		private ObservableCollection<PropertyDefinition> PropertyDefinitions
		{
			get
			{
				if(_propertyDefinitions == null)
				{
					_propertyDefinitions = new ObservableCollection<PropertyDefinition>();
				}

				return _propertyDefinitions;
			}
		}

		#endregion

		#region Methods (SC)

		private void AddSetting(object obj)
		{
			SettingModels.Add(new SettingModel
			                  {
				                  Key   = "setting" + (SettingModels.Count + 1),
				                  Value = "value"   + (SettingModels.Count + 1)
			                  });
		}


		private void PropertyModels_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if(e.NewItems != null)
			{
				foreach(PropertyModel item in e.NewItems)
				{
					PropertyDefinitions.Add(new PropertyDefinition
					                        {
						                        DisplayName = item.Comments,
						                        Binding = new Binding("Value")
						                                  {
							                                  Source = item
						                                  }
					                        });
				}
			}
		}


		private void SettingModelsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if(e.NewItems != null)
			{
				foreach(SettingModel item in e.NewItems)
				{
					PropertyDefinitions.Add(new PropertyDefinition
					                        {
						                        DisplayName = item.Key,
						                        Binding = new Binding("Value")
						                                  {
							                                  Source = item
						                                  }
					                        });
				}
			}
		}


		private void UpdateRevit(object obj)
		{
			try
			{
				_propertyExternalEvent.PropertyModel = _propertyModel;
				_externalEvent.Raise();
			}

			#region catch and finally

			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			#endregion
		}

		#endregion

	}

}