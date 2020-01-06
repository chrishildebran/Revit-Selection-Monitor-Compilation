// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitor
// Project:............. Core
// File:................ EventFactory.cs
// Last Code Cleanup:... 01/06/2020 @ 8:43 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
// Development Notes
namespace SelectionMonitorCore.Events
{

	using System;
	using System.Diagnostics;

	using Autodesk.Revit.DB.Events;

	using SelectionMonitorCore.Utilities;

	internal static class EventFactory
	{

		#region Methods (SC)

		public static void ShutDown()
		{
			Debug.WriteLine($"{CodeLocation.GetClassName(1)} - {CodeLocation.GetMethodName(1)}");

			App.UIContApp.ControlledApplication.DocumentOpening -= DocumentEvents.OnOpening;
			App.UIContApp.ControlledApplication.DocumentClosing -= DocumentEvents.OnClosing;
		}


		public static void StartUp()
		{
			Debug.WriteLine($"{CodeLocation.GetClassName(1)} - {CodeLocation.GetMethodName(1)}");
			App.UIContApp.ControlledApplication.DocumentOpening += new EventHandler<DocumentOpeningEventArgs>(DocumentEvents.OnOpening);
			App.UIContApp.ControlledApplication.DocumentClosing += new EventHandler<DocumentClosingEventArgs>(DocumentEvents.OnClosing);
		}

		#endregion

	}

}