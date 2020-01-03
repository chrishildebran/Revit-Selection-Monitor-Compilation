// /////////////////////////////////////////////////////////////
// Solution:............ Test
// Project:............. BaseRevitModeless
// File:................ Exporters.cs
// Last Code Cleanup:... 01/03/2020 @ 7:30 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
// Development Notes
namespace BaseRevitModeless.Utilities
{

	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.IO;
	using System.Linq;
	using System.Reflection;
	using System.Text;
	using System.Text.RegularExpressions;

	using Autodesk.Revit.DB;
	using Autodesk.Windows;

	public class Exporters
	{

		#region Methods (SC)

		public static void TabEventDataExport(Document _rvtDoc, RibbonTab tab)
		{
			var timeStamp = DateTime.Now.ToString("yyyyMMdd HHmmss");

			var sbEvents = new StringBuilder().AppendLine("EventName, PropertyName, PropertyType, PropertyCanWrite");

			foreach(var eventInfo in GetEvents(tab))
			{
				foreach(var property in GetProperties(eventInfo))
				{
					var propertyName     = property.Name;
					var propertyType     = property.PropertyType;
					var propertyCanWrite = property.CanWrite;

					sbEvents.AppendLine($"{eventInfo.Name}, {propertyName}, {propertyType},{propertyCanWrite}");
				}
			}

			WriteDevelopmentListToTextFile(_rvtDoc, sbEvents, $"Events Of Tab-{tab.Id}_{timeStamp}");
		}


		public static void TabMemberDataExport(Document _rvtDoc, RibbonTab tab)
		{
			var timeStamp = DateTime.Now.ToString("yyyyMMdd HHmmss");

			var sbMembers = new StringBuilder().AppendLine("MemberType, MemberName");

			foreach(var memberInfo in GetMemberInfo(tab))
			{
				var name = memberInfo.Name;
				var type = memberInfo.MemberType;

				sbMembers.AppendLine($"{type}, {name}");
			}

			WriteDevelopmentListToTextFile(_rvtDoc, sbMembers, $"Members Of Tab-{tab.Id}_{timeStamp}");
		}


		public static void TabPropertyDataExport(Document _rvtDoc, RibbonTab tab)
		{
			var timeStamp = DateTime.Now.ToString("yyyyMMdd HHmmss");

			var sbProperties = new StringBuilder().AppendLine("PropertyName, PropertyValue");

			foreach(var propertyInfo in GetProperties(tab))
			{
				var name  = propertyInfo.Name;
				var value = propertyInfo.GetValue(tab, null);

				sbProperties.AppendLine($"{name}, {value}");
			}

			WriteDevelopmentListToTextFile(_rvtDoc, sbProperties, $"Properties Of Tab-{tab.Id}_{timeStamp}");
		}


		private static string Clean(string str)
		{
			var sb = new StringBuilder();

			foreach(var c in str)
			{
				if(c >= '0' && c <= '9' || c >= 'A' && c <= 'Z' || c >= 'a' && c <= 'z' || c == ' ' || c == '-' || c == '_')
				{
					sb.Append(c);
				}
			}

			var cleanString = Regex.Replace(sb.ToString(), @"\s+", " ");

			return cleanString;
		}


		private static string DirectoryExportDefault(Document revitDoc)
		{
			var projectNumber = HasValue(revitDoc.ProjectInformation.Number) ? Clean(revitDoc.ProjectInformation.Number) : "No Project Number";

			var projectName = HasValue(revitDoc.ProjectInformation.Name) ? Clean(revitDoc.ProjectInformation.Name) : "No Project Name";

			var directory = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Revit Exports - TEMPORARY\\{projectNumber} - {projectName}\\";

			Path(directory, false, false);

			return directory;
		}


		private static IEnumerable<EventInfo> GetEvents(object obj)
		{
			const BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

			EventInfo[] eventInfos = obj.GetType().GetEvents(bindingFlags);

			return eventInfos.OrderBy(x => x.Name);
		}


		private static IEnumerable<MemberInfo> GetMemberInfo(object obj)
		{
			MemberInfo[] memberInfos = obj.GetType().GetMembers();

			return memberInfos.OrderBy(x => x.Name);
		}


		private static IEnumerable<PropertyInfo> GetProperties(object obj)
		{
			PropertyInfo[] propertyInfos = obj.GetType().GetProperties();

			return propertyInfos.OrderBy(x => x.Name);
		}


		private static bool HasValue(string value)
		{
			if(value == null)
			{
				return false;
			}

			if(value == string.Empty)
			{
				return false;
			}

			if(value.Trim().Length == 0)
			{
				return false;
			}

			if(string.IsNullOrEmpty(value))
			{
				return false;
			}

			if(string.IsNullOrWhiteSpace(value))
			{
				return false;
			}

			return true;
		}


		private static void Path(string path, bool deleteContents, bool openForUser)
		{
			if(Directory.Exists(path))
			{
				if(deleteContents)
				{
					Array.ForEach(Directory.GetFiles(path), File.Delete);
				}
			}
			else
			{
				Directory.CreateDirectory(path);
			}

			if(openForUser)
			{
				Process.Start(path);
			}
		}


		private static void WriteDevelopmentListToTextFile(Document revitDoc, StringBuilder sb, string filename)
		{
			var filePath = DirectoryExportDefault(revitDoc);

			var fileExtension = ".csv";

			var filePathAndName = filePath + filename + fileExtension;

			using(var writer = new StreamWriter(filePathAndName, false))
			{
				writer.Write(sb);
			}

			Process.Start(filePath);
		}

		#endregion

	}

}