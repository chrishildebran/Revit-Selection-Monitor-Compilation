// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitor
// Project:............. Core
// File:................ CodeLocation.cs
// Last Code Cleanup:... 01/06/2020 @ 10:50 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
// Development Notes
namespace SelectionMonitorCore.Utilities
{

	using System.Diagnostics;

	internal static class CodeLocation
	{

		#region Methods (SC)

		public static string GetAssemblyName(int frameIndex)
		{
			var stackTrace = new StackTrace();
			var frame      = stackTrace.GetFrame(frameIndex);
			var assembly   = frame.GetMethod().DeclaringType.Assembly;

			return assembly == null ? "Could Not Get Current Assembly Name" : assembly.GetName().Name;
		}


		public static string GetClassName(int frameIndex)
		{
			var stackTrace    = new StackTrace();
			var frame         = stackTrace.GetFrame(frameIndex);
			var declaringType = frame.GetMethod().DeclaringType;

			return declaringType == null ? "Could Not Get Current Class Name" : declaringType.Name;
		}


		public static string GetMethodName(int frameIndex)
		{
			var stackTrace = new StackTrace();
			var frame      = stackTrace.GetFrame(frameIndex);
			var method     = frame.GetMethod();

			return method == null ? "Could Not Get Current Method Name" : method.Name;
		}

		#endregion

	}

}