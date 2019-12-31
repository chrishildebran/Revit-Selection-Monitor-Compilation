// /////////////////////////////////////////////////////////////
// Solution:............ Kelly Development
// Project:............. BaseRevitModeless
// File:................ IRevitModel.cs
// Last Code Cleanup:... 12/30/2019 @ 10:48 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
namespace BaseRevitModeless.Ideate
{

	using System;
	using System.Collections.Generic;
	using System.Windows.Controls;
	using System.Windows.Media;

	public interface IRevitModel
	{

		#region  Events (SC)

		event EventHandler EnteringEditSession;

		event EventHandler ExitingEditSession;

		event EventHandler FiltersChanged;

		event EventHandler<ModelChangedEventArgs> ModelChanged;

		event EventHandler<ErrorMessageEventArgs> ModelMessageEvent;

		event EventHandler RequestRefresh;

		event EventHandler<SelectionChangedEventArgs> SelectionChanged;

		event EventHandler<EventArgs> SelectionCountChanged;

		event EventHandler<ViewChangedEventArgs> ViewChanged;

		#endregion

		#region Properties (SC)

		string ActiveDocumentName
		{
			get;
		}

		string CurrentProjectName
		{
			get;
		}

		I_Id8Document Document
		{
			get;
		}

		bool EnableSelectionObservation
		{
			get;
			set;
		}

		bool IsFamilyDocument
		{
			get;
		}

		bool IsWorkShared
		{
			get;
		}

		string ModelId
		{
			get;
		}

		string PathName
		{
			get;
		}

		string Title
		{
			get;
		}

		bool ValidDocument
		{
			get;
		}

		#endregion

		#region Methods (SC)

		bool ActivateAlternateView(List<int> idList);

		void ActivateView(int id);

		void ChangeElementsSelection(List<int> idList, bool selected);

		void ClearModelCache();

		bool DeleteElements(List<int> elements, out string errMsg);

		List<int> FilterByRuleBasedFilter(List<int> elements, int filterId);

		List<int> FilterByUnifiedCategory(List<int> elementsIn, int categoryId);

		List<int> FilterSelection(List<int> selection);

		bool GetActiveView(out RevitView_ModelItem view);

		List<int> GetActiveViewElements();

		void GetCategoriesFromElements(List<int> elementsIn, ShowProgressValueCallback showProgressValueCallback, out List<int> elementsToIndex, out List<int> categoryIds, out List<string> categoryNames, out List<int> categoryElementCounts, out bool closeAddin);

		bool GetCategoriesFromRuleBasedFilter(int filterId, out List<int> categoryIds, out List<string> categoryNames);

		List<int> GetCurrentSelectionElements(bool filter = true);

		DependentElements GetDependentElements(List<int> elements, ShowProgressValueCallback showProgressValueCallback);

		List<int> GetDocumentElements();

		ImageSource GetElementImage(int elementId, int imageWidth, int imageHeight);

		void GetExplorerRuleBasedFilters(out List<int> filterIdList, out List<string> filterIdName);

		void GetExplorerRuleBasedModelFilters(out List<int> filterIdList, out List<string> filterIdName);

		void GetExplorerRuleBasedViewFilters(out List<int> filterIdList, out List<string> filterIdName);

		double GetLevelElevation(string levelName);

		bool GetModelItem(int id, out RevitBuilding_ModelItem item);

		void GetRevitRuleBasedFilters(out List<int> filterIdList, out List<string> filterIdName);

		List<int> GetSelectedElements(bool filter = true);

		bool GetViewItem(int id, out RevitView_ModelItem item);

		bool InRevitContext();

		bool IsView(int id);

		void RevitDelete();

		void SendSelectionChangedEvent(Id8ElementChangeSet chgSet);

		void SetElementSelection(List<int> idList);

		void ShutdownDoc();

		void Sync();

		int ViewsSheet(int viewId);

		void WatchRevitProgress(bool starting);

		void Zoom(double factor);

		void ZoomExtents();

		#endregion

	}

}