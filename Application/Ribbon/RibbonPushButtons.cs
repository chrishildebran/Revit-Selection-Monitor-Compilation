// /////////////////////////////////////////////////////////////
// Solution:............ Test
// Project:............. BaseRevitModeless
// File:................ RibbonPushButtons.cs
// Last Code Cleanup:... 12/31/2019 @ 3:09 PM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
namespace BaseRevitModeless.Ribbon
{

	using System.Diagnostics;
	using System.Runtime.CompilerServices;
	using System.Text;

	using Autodesk.Revit.UI;

	public static class RibbonPushButtons
	{

		#region Properties (SC)

		private static string ImagePath{get {return"BaseRevitModeless.Ribbon.Images.";}}

		#endregion

		#region Methods (SC)

		public static PushButtonData PropertyView(RibbonPanel ribbonPanel, string tabName, string path)
		{
			var methodName  = GetMethodName(1);
			var buttonName  = ribbonPanel.Name + tabName + methodName;
			var buttonTitle = ChangeToTitleCaseString(methodName, true);

			return new PushButtonData(buttonName, buttonTitle, path, "BaseRevitModeless.View.PropertyView")
			       {
				       LargeImage = Image.Get(ImagePath + "AceOfSpades_32.png"),
				       Image      = Image.Get(ImagePath + "AceOfSpades_16.png")
			       };
		}


		public static PushButtonData SelectionChangedCommand(RibbonPanel ribbonPanel, string tabName, string path)
		{
			var methodName  = GetMethodName(1);
			var buttonName  = ribbonPanel.Name + tabName + methodName;
			var buttonTitle = ChangeToTitleCaseString(methodName, true);

			return new PushButtonData(buttonName, buttonTitle, path, "BaseRevitModeless.Commands.SelectionChangedCommand")
			       {
				       LargeImage = Image.Get(ImagePath + "AceOfSpades_32.png"),
				       Image      = Image.Get(ImagePath + "AceOfSpades_16.png")
			       };
		}


		private static string ChangeToTitleCaseString(string text, bool preserveAcronyms)
		{
			if(string.IsNullOrWhiteSpace(text))
			{
				return string.Empty;
			}

			var newText = new StringBuilder(text.Length * 2);
			newText.Append(text[0]);

			for(var i = 1; i < text.Length; i++)
			{
				var characterCurrent = text[i];

				if(char.IsUpper(characterCurrent) || char.IsNumber(characterCurrent))
				{
					if(text[i - 1] != ' ' && !char.IsUpper(text[i - 1]) /*new-->*/ && !char.IsNumber(text[i - 1]) /*<--new*/ || preserveAcronyms && char.IsUpper(text[i - 1]) && i < text.Length - 1 && !char.IsUpper(text[i + 1]))
					{
						newText.Append(' ');
					}
				}

				newText.Append(characterCurrent);
			}

			return newText.ToString();
		}


		[MethodImpl(MethodImplOptions.NoInlining)]
		private static string GetMethodName(int frameIndex)
		{
			var stackTrace = new StackTrace();
			var frame      = stackTrace.GetFrame(frameIndex);
			var method     = frame.GetMethod();

			return method == null ? "Could Not Get Current Method Name" : method.Name;
		}

		#endregion

	}

}