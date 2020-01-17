// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitorCompilation
// Project:............. Core
// File:................ EventFactory.cs
// Last Code Cleanup:... 01/17/2020 @ 8:16 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
namespace SelectionMonitorCompilationCore.Shared.Events
{

	using System;

	using Autodesk.Revit.DB.Events;

	internal static class EventFactory
	{

		#region Methods (SC)

		public static void ShutDown()
		{
			App.UIContApp.ControlledApplication.ApplicationInitialized -= ApplicationEvents.FairApplicationInitialized;
			App.UIContApp.ControlledApplication.DocumentOpening        -= DocumentEvents.OnOpening;
			App.UIContApp.ControlledApplication.DocumentClosing        -= DocumentEvents.OnClosing;
		}


		public static void StartUp()
		{
			App.UIContApp.ControlledApplication.ApplicationInitialized += new EventHandler<ApplicationInitializedEventArgs>(ApplicationEvents.FairApplicationInitialized);
			App.UIContApp.ControlledApplication.DocumentOpening        += new EventHandler<DocumentOpeningEventArgs>(DocumentEvents.OnOpening);
			App.UIContApp.ControlledApplication.DocumentClosing        += new EventHandler<DocumentClosingEventArgs>(DocumentEvents.OnClosing);
		}

		#endregion

	}

}