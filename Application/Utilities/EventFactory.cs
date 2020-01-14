// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitor
// Project:............. Core
// File:................ EventFactory.cs
// Last Code Cleanup:... 01/14/2020 @ 7:39 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
namespace SelectionMonitorCore.Utilities
{

	using System;

	using Autodesk.Revit.DB.Events;

	internal static class EventFactory
	{

		#region Methods (SC)

		public static void ShutDown()
		{
			App.UIContApp.ControlledApplication.ApplicationInitialized -= ApplicationEvents.FairApplicationInitialized;
		}


		public static void StartUp()
		{
			App.UIContApp.ControlledApplication.ApplicationInitialized += new EventHandler<ApplicationInitializedEventArgs>(ApplicationEvents.FairApplicationInitialized);
		}

		#endregion

	}

}