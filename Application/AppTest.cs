// /////////////////////////////////////////////////////////////
// Solution:............ Test
// Project:............. BaseRevitModeless
// File:................ AppTest.cs
// Last Code Cleanup:... 01/02/2020 @ 11:09 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
namespace BaseRevitModeless
{

	using System;
	using System.Diagnostics;

	using Autodesk.Revit.UI;
	using Autodesk.Revit.UI.Events;

	internal class AppTest : IExternalApplication
	{

		#region Fields (SC)

		private static EventHandler<IdlingEventArgs> _handler;

		private static UIControlledApplication _uiapp;

		#endregion

		#region Properties (SC)

		public static bool Subscribed{get {return null != _handler;}}

		#endregion

		#region Methods (SC)

		public Result OnShutdown(UIControlledApplication a)
		{
			if(Subscribed)
			{
				_uiapp.Idling -= _handler;
			}

			return Result.Succeeded;
		}


		public Result OnStartup(UIControlledApplication a)
		{
			_uiapp = a;

			EventHandler<IdlingEventArgs> eventHandler = new EventHandler<IdlingEventArgs>(PanelEvent);

			ToggleSubscription(eventHandler);

			return Result.Succeeded;
		}


		private static void PanelEvent(object sender, IdlingEventArgs e)
		{
		}


		private static void ToggleSubscription(EventHandler<IdlingEventArgs> handler)
		{
			if(Subscribed)
			{
				Debug.Print("Unsubscribing...");
				_uiapp.Idling -= _handler;
				_handler      =  null;
				Debug.Print("Unsubscribed.");
			}
			else
			{
				Debug.Print("Subscribing...");
				_uiapp.Idling += handler;
				_handler      =  handler;
				Debug.Print("Subscribed.");
			}
		}

		#endregion

	}

}