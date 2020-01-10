// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitor
// Project:............. Core
// File:................ EventFactory.cs
// Last Code Cleanup:... 01/10/2020 @ 10:41 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
// Development Notes
namespace SelectionMonitorCore.Events
{

	using System;

	using Autodesk.Revit.DB.Events;

	internal static class EventFactory
	{

		#region Methods (SC)

		public static void ShutDown()
		{
			App.UIContApp.ControlledApplication.DocumentOpening -= DocumentEvents.OnOpening;
			App.UIContApp.ControlledApplication.DocumentClosing -= DocumentEvents.OnClosing;
		}


		public static void StartUp()
		{
			App.UIContApp.ControlledApplication.DocumentOpening += new EventHandler<DocumentOpeningEventArgs>(DocumentEvents.OnOpening);
			App.UIContApp.ControlledApplication.DocumentClosing += new EventHandler<DocumentClosingEventArgs>(DocumentEvents.OnClosing);
		}

		#endregion

	}

}