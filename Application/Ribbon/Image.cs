// /////////////////////////////////////////////////////////////
// Solution:............ Kelly Development
// Project:............. BaseRevitModeless
// File:................ Image.cs
// Last Code Cleanup:... 12/27/2019 @ 12:12 PM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
namespace BaseRevitModeless.Ribbon
{

	using System.Reflection;
	using System.Windows.Media.Imaging;

	public static class Image
	{

		#region Methods (SC)

		public static BitmapSource Get(string name)
		{
			try
			{
				var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name);

				return BitmapFrame.Create(stream);
			}
			catch
			{
				return null;
			}
		}

		#endregion

	}

}