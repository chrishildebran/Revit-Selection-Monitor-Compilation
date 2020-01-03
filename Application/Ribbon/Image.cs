// /////////////////////////////////////////////////////////////
// Solution:............ Test
// Project:............. BaseRevitModeless
// File:................ Image.cs
// Last Code Cleanup:... 01/03/2020 @ 7:30 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
// Development Notes
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