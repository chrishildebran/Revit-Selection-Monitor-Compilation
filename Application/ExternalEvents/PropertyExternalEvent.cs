// /////////////////////////////////////////////////////////////
// Solution:............ Kelly Development
// Project:............. BaseRevitModeless
// File:................ PropertyExternalEvent.cs
// Last Code Cleanup:... 12/27/2019 @ 12:12 PM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
namespace BaseRevitModeless.ExternalEvents
{

	using Autodesk.Revit.DB;
	using Autodesk.Revit.UI;

	using BaseRevitModeless.Model;

	public class PropertyExternalEvent : IExternalEventHandler
	{

		#region Properties (SC)

		public Element Element
		{
			get;
			set;
		}

		public ElementType ElementType
		{
			get;
			set;
		}

		public PropertyModel PropertyModel
		{
			get;
			set;
		}

		#endregion

		#region Methods (SC)

		public void Execute(UIApplication uiapp)
		{
			var doc = uiapp.ActiveUIDocument.Document;

			using(var t = new Transaction(doc, "Parameter Updates"))
			{
				t.Start();

				if(Element.LookupParameter("Comments") != null)
				{
					Element.GetParameters("Comments")[0].Set(PropertyModel.Comments);
				}

				if(ElementType.LookupParameter("Model") != null)
				{
					ElementType.GetParameters("Model")[0].Set(PropertyModel.Model);
				}

				if(ElementType.LookupParameter("Manufacturer") != null)
				{
					ElementType.GetParameters("Manufacturer")[0].Set(PropertyModel.Manufacturer);
				}

				if(ElementType.LookupParameter("Type Comments") != null)
				{
					ElementType.GetParameters("Type Comments")[0].Set(PropertyModel.TypeComments);
				}

				if(ElementType.LookupParameter("Description") != null)
				{
					ElementType.GetParameters("Description")[0].Set(PropertyModel.Description);
				}

				t.Commit();
			}
		}


		public string GetName()
		{
			return"Property External Event";
		}

		#endregion

	}

}