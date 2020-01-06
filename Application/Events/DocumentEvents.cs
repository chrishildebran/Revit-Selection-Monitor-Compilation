// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitor
// Project:............. Core
// File:................ DocumentEvents.cs
// Last Code Cleanup:... 01/06/2020 @ 8:43 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
// Development Notes
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