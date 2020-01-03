// /////////////////////////////////////////////////////////////
// Solution:............ Test
// Project:............. BaseRevitModeless
// File:................ EventFactory.cs
// Last Code Cleanup:... 01/03/2020 @ 2:52 PM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
// Development Notes
namespace BaseRevitModeless
{

	using System;
	using System.Diagnostics;

	using Autodesk.Revit.DB.Events;

	using BaseRevitModeless.Utilities;

	internal static class EventFactory
	{

		#region Methods (SC)

		public static void ShutDown()
		{
			Debug.WriteLine($"{CodeLocation.GetClassName(1)} - {CodeLocation.GetMethodName(1)}");

			App.UIContApp.ControlledApplication.DocumentOpening -= DocumentEvent.OnOpening;
			App.UIContApp.ControlledApplication.DocumentClosing -= DocumentEvent.OnClosing;
		}


		public static void StartUp()
		{
			Debug.WriteLine($"{CodeLocation.GetClassName(1)} - {CodeLocation.GetMethodName(1)}");
			App.UIContApp.ControlledApplication.DocumentOpening += new EventHandler<DocumentOpeningEventArgs>(DocumentEvent.OnOpening);
			App.UIContApp.ControlledApplication.DocumentClosing += new EventHandler<DocumentClosingEventArgs>(DocumentEvent.OnClosing);
		}

		#endregion

	}

}