// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitor
// Project:............. Core
// File:................ Image.cs
// Last Code Cleanup:... 01/06/2020 @ 10:50 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
// Development Notes
namespace SelectionMonitorCore.Ribbon
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