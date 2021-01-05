// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitorCompilation
// Project:............. Core
// File:................ Messaging.cs
// Last Code Cleanup:... 01/05/2021 @ 11:52 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
namespace SelectionMonitorCompilationCore.Shared.Utilities
{

	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.IO;
	using System.Linq;
	using System.Text;

	using Autodesk.Revit.DB;

	public class Messaging
	{

		#region Methods (SC)

		public static void AppendToFile(string filePath, StringBuilder stringBuilder)
		{
			try
			{
				using(var sw = File.AppendText(filePath))
				{
					sw.WriteLine(stringBuilder.ToString());
				}
			}
			catch(Exception e)
			{
				//var emailer = new Emailer();

				//emailer.SendToDeveloper(e, 2);
			}
		}


		public static void DebugMessage(string message)
		{
			Debug.WriteLine("--------------------------------------------------------------------------");

			Debug.Print(message);

			Debug.WriteLine("--------------------------------------------------------------------------");
		}


		public static void DebugMessage(bool subscribed, List<ElementId> elementIds, string sender, bool showElementIds)
		{
			var sb = new StringBuilder();
			var sw = new Stopwatch();

			sw.Start();

			var eidCount = 1;

			var elementIdsForMessage = string.Empty;

			if(elementIds.Count == 0)
			{
				elementIdsForMessage = "<nil>";
			}
			else if(elementIds.Count >= 1)
			{
				elementIdsForMessage = showElementIds ? string.Join(", ", elementIds.Select(id => id.IntegerValue + " [" + eidCount++ + "]")) : "<hidden>";
			}

			sb.AppendLine($"Selection Monitor - {sender}\n");
			sb.AppendLine($"Element Id's: {elementIdsForMessage}");
			sb.AppendLine($"Count: {elementIds.Count}");

			if(!subscribed)
			{
				sb.AppendLine("");
				sb.AppendLine("Why is the Event still firing? Subscribed = False");
			}

			sw.Stop();
			sb.AppendLine("Elapsed Time: " + sw.Elapsed.TotalMilliseconds);

			DebugMessage(sb.ToString());

			var filePath = "C:\\Users\\CHildebran\\Downloads\\Logs\\Selection Monitor Events.log";

			AppendToFile(filePath, sb);
		}

		#endregion

	}

}