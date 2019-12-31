// /////////////////////////////////////////////////////////////
// Solution:............ Kelly Development
// Project:............. BaseRevitModeless
// File:................ SelectionObserver.cs
// Last Code Cleanup:... 12/30/2019 @ 11:21 AM Using ReSharper ✓
// /////////////////////////////////////////////////////////////
namespace BaseRevitModeless.Ideate
{

	using System;
	using System.Collections.Generic;
	using System.Threading;

	public sealed class SelectionObserver : IDisposable
	{

		#region Fields (SC)

		private absIRevitModel _abstractInterface1;

		private bool _boolField1; // converting - private bool ;

		private IRevitModel _interface1;

		private List<int> _listOfIntsField = new List<int>();

		private object _objectField1 = new object();

		private object _objectField2 = new object(); // converting - private object  = new object ();

		private object _objectField3 = new object();

		private SelectionChanged _selectionChangedField;

		private string _stringField1; // converting -  private string ;

		#endregion

		#region Constructors (SC)

		public SelectionObserver(IRevitModel model, absIRevitModel logger)
		{
			_interface1         = model;
			_abstractInterface1 = logger;
			LastSet             = new List<int>();
			CurrentSelectionSet = this..GetCurrentSelectionElements(true);
			_stringField1       = string.Format("[{0}]:[{1}]", GetHashCode(), GetType().FullName);
		}

		#endregion

		#region Delegates (SC)

		public delegate void SelectionChanged(Id8ElementChangeSet chgSet);

		#endregion

		#region  Events (SC)

		public event SelectionChanged ChangeEvent
		{
			add
			{
				SelectionChanged selectionChanged  = null;
				SelectionChanged selectionChanged1 = null;

				if(0 != 0)
				{
					goto Label0;
				}

				if(0 == 0)
				{
					selectionChanged = _selectionChangedField;
				}

				Label2:

				if(7 == 0)
				{
					goto Label1;
				}

				var _selectionChanged2 = selectionChanged;

				if(6 != 0)
				{
					selectionChanged1 = _selectionChanged2;
				}

				Label3:
				var selectionChanged3 = selectionChanged1;
				var selectionChanged4 = (SelectionChanged) Delegate.Combine(selectionChanged3, value);
				selectionChanged = Interlocked.CompareExchange<SelectionChanged>(ref this., selectionChanged4, selectionChanged1);
				Label1:

				if(selectionChanged != (object) selectionChanged1)
				{
					goto Label2;
				}

				Label0:

				if(0 == 0)
				{
				}
				else
				{
					goto Label3;
				}
			}
			remove
			{
				SelectionChanged selectionChanged  = null;
				SelectionChanged selectionChanged1 = null;

				if(0 != 0)
				{
					goto Label0;
				}

				if(0 == 0)
				{
					selectionChanged = _selectionChangedField;
				}

				Label2:

				if(7 == 0)
				{
					goto Label1;
				}

				var selectionChanged2 = selectionChanged;

				if(6 != 0)
				{
					selectionChanged1 = selectionChanged2;
				}

				Label3:
				var selectionChanged3 = selectionChanged1;
				var selectionChanged4 = (SelectionChanged) Delegate.Remove(selectionChanged3, value);
				selectionChanged = Interlocked.CompareExchange<SelectionChanged>(ref this., selectionChanged4, selectionChanged1);
				Label1:

				if(selectionChanged != (object) selectionChanged1)
				{
					goto Label2;
				}

				Label0:

				if(0 == 0)
				{
				}
				else
				{
					goto Label3;
				}
			}
		}

		#endregion

		#region Properties (SC)

		public List<int> CurrentSelectionSet
		{
			get
			{
				List<int> nums;
				object    obj  = null;
				var       flag = false;

				try
				{
					var obj1 = _objectField1;
					obj = obj1;
					Monitor.Enter(obj1, ref flag);
					nums = _listOfIntsField;
				}
				finally
				{
					while(0 != 0 || flag)
					{
						if(0 != 0)
						{
							continue;
						}

						Monitor.Exit(obj);

						break;
					}
				}

				return nums;
			}
			private set
			{
				object obj = null;

				do
				{
					if(2 == 0)
					{
						continue;
					}

					var flag = false;

					try
					{
						if(0 == 0 && 0 == 0)
						{
							var obj1 = _objectField1;

							if(4 != 0)
							{
								obj = obj1;
							}

							Monitor.Enter(obj1, ref flag);
						}

						_objectField1 = value;
					}
					finally
					{
						if(flag)
						{
							Monitor.Exit(obj);
						}
					}
				}
				while(0 != 0);
			}
		}

		public bool ReportingEnabled
		{
			get
			{
				bool   flag;
				object obj   = null;
				var    flag1 = false;

				try
				{
					var obj1 = _objectField3;
					obj = obj1;
					Monitor.Enter(obj1, ref flag1);
					flag = _boolField1;
				}
				finally
				{
					while(0 != 0 || flag1)
					{
						if(0 != 0)
						{
							continue;
						}

						Monitor.Exit(obj);

						break;
					}
				}

				return flag;
			}
			set
			{
				object obj = null;

				do
				{
					if(2 == 0)
					{
						continue;
					}

					var flag = false;

					try
					{
						if(0 == 0 && 0 == 0)
						{
							var obj1 = _objectField3;

							if(4 != 0)
							{
								obj = obj1;
							}

							Monitor.Enter(obj1, ref flag);
						}

						_boolField1 = value;
					}
					finally
					{
						if(flag)
						{
							Monitor.Exit(obj);
						}
					}
				}
				while(0 != 0);
			}
		}

		private List<int> LastSet
		{
			get
			{
				List<int> nums;
				object    obj  = null;
				var       flag = false;

				try
				{
					var obj1 = _objectField2;
					obj = obj1;
					Monitor.Enter(obj1, ref flag);
					nums = _listOfIntsField;
				}
				finally
				{
					while(0 != 0 || flag)
					{
						if(0 != 0)
						{
							continue;
						}

						Monitor.Exit(obj);

						break;
					}
				}

				return nums;
			}
			set
			{
				object obj = null;

				do
				{
					if(2 == 0)
					{
						continue;
					}

					var flag = false;

					try
					{
						if(0 == 0 && 0 == 0)
						{
							var obj1 = _objectField2;

							if(4 != 0)
							{
								obj = obj1;
							}

							Monitor.Enter(obj1, ref flag);
						}

						_objectField2 = value;
					}
					finally
					{
						if(flag)
						{
							Monitor.Exit(obj);
						}
					}
				}
				while(0 != 0);
			}
		}

		#endregion

		#region Methods (SC)

		public void Dispose()
		{
			_interface1 = null;
		}


		public void MonitorSelection()
		{
			try
			{
				if(this. != null)

				{
					if(_interface1.ValidDocument)
					{
						CurrentSelectionSet = _interface1.GetCurrentSelectionElements(false);

						if(CurrentSelectionSet != null)
						{
							var id8ElementChangeSet = Id8ElementChangeSet.findChanges(LastSet, CurrentSelectionSet);

							if(!id8ElementChangeSet.isEmptySet())
							{
								var flag = false;

								try
								{
									try
									{
										int count = id8ElementChangeSet.Added.Count;

										if(count != 0)
										{
											id8ElementChangeSet.Added = _interface1.FilterSelection(id8ElementChangeSet.Added);

											if(count != id8ElementChangeSet.Added.Count)
											{
												CurrentSelectionSet = _interface1.FilterSelection(CurrentSelectionSet);
											}
										}

										int num = id8ElementChangeSet.Deleted.Count;

										if(num != 0)
										{
											id8ElementChangeSet.Deleted = _interface1.FilterSelection(id8ElementChangeSet.Deleted);

											if(num != id8ElementChangeSet.Deleted.Count)
											{
												CurrentSelectionSet = _interface1.FilterSelection(CurrentSelectionSet);
											}
										}

										if(!id8ElementChangeSet.isEmptySet() && this. != null && this. != null && ReportingEnabled)

										{
											this.(id8ElementChangeSet);
											flag = true;
										}
									}
									catch(Exception exception1)
									{
										var exception = exception1;


										//  this..ModelLogger.(exception, string.Concat(this.GetType().Name, " MonitorSelection"), "Caught Exception Monitor Revit Seleection.", "");
									}
								}
								finally
								{
									if(flag)
									{
										LastSet = CurrentSelectionSet;
									}
								}
							}
						}
					}
				}
			}
			catch(Exception exception3)
			{
				// Exception exception2 = exception3;
				// string str = string.Format("-DEBUG- MonitorSelection(1) Caught Excpetion: [{0}] objId: [{1}] Observing Model: [{2}]", exception2.Message, this., (this. != null ? this..PathName: "Null Model"));
				//this..ModelLogger.(exception2, string.Concat(this.GetType().Name, " MonitorSelection"), str, "");
				//this..ModelLogger.(exception2, string.Concat(this.GetType().Name, " MonitorSelection"), "Exception Caught in MonitorSelection()", "");
			}
		}


		public void Reset()
		{
			LastSet             = new List<int>();
			CurrentSelectionSet = new List<int>();
		}


		private List<int>

		#endregion

		;

	}

}