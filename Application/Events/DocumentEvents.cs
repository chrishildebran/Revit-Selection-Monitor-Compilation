// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitor
// Project:............. Core
// File:................ DocumentEvents.cs
// Last Code Cleanup:... 01/14/2020 @ 7:37 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
namespace SelectionMonitorCore.Events
{

	using Autodesk.Revit.DB.Events;

	public static class DocumentEvents
	{

		#region Methods (SC)

		public static void OnClosing(object sender, DocumentClosingEventArgs e)
		{
		}


		public static void OnOpening(object sender, DocumentOpeningEventArgs e)
		{
		}

		#endregion

	}

}