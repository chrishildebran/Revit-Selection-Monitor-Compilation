// /////////////////////////////////////////////////////////////
// Solution:............ SelectionMonitor
// Project:............. Core
// File:................ Messaging.cs
// Last Code Cleanup:... 01/10/2020 @ 1:22 PM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
// Development Notes
namespace SelectionMonitorCore.Utilities
{

	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Text;

	using Autodesk.Revit.DB;
	using Autodesk.Revit.UI;

	public class Messaging
	{

		#region Methods (SC)

		public static void DebugMessage(string message)
		{
			Debug.WriteLine("--------------------------------------------------------------------------");

			Debug.Print(message);

			Debug.WriteLine("--------------------------------------------------------------------------");
		}


		public static void DebugMessageString(bool subscribed, List<ElementId> elementIds, string sender)
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
				elementIdsForMessage = "<hidden>";


				//elementIdsForMessage = string.Join(", ", elementIds.Select(id => id.IntegerValue + " [" + eidCount++ + "]"));
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
		}


		public static void TypeError()
		{
			var sb1 = new StringBuilder();
			sb1.AppendLine("????????????????????????????????????????");
			sb1.AppendLine("?? Expected Sender To Be A Ribbon Tab ??");
			sb1.AppendLine("????????????????????????????????????????");

			TaskDialog.Show("Error", sb1.ToString());
		}

		#endregion

	}

}