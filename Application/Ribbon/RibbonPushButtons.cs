// /////////////////////////////////////////////////////////////
// Solution:............ Base Revit Modeless
// Project:............. Application
// File:................ RibbonPushButtons.cs
// Last Code Cleanup:... 12/27/2019 @ 8:01 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
namespace Application.Ribbon
{

	using Autodesk.Revit.UI;

	public static class RibbonPushButtons
	{

		#region Properties (SC)

		private static string ImagePath{get {return"Application.Ribbon.Images.";}}

		#endregion

		#region Methods (SC)

		public static PushButtonData PropertyFormButton(RibbonPanel ribbonPanel, string tabName, string path)
		{
			return new PushButtonData(ribbonPanel + tabName + "3", "Properties", path, " Application.View.PropertyView")
			       {
				       LargeImage = Image.Get(ImagePath + "AceOfSpades_32.png"),
				       Image      = Image.Get(ImagePath + "AceOfSpades_16.png")
			       };
		}

		#endregion

	}

}