namespace BaseRevitModeless.Ideate
{

	using System.Collections.Generic;

	public abstract class absIRevitModel
	{
		internal abstract string LogPath
		{
			get;
			set;
		}

		internal abstract string LogSource
		{
			get;
			set;
		}

		internal abstract 1 ModelLogger
		{
			get;
		}

		protected absIRevitModel()
		{
		}

		public abstract List<int> absGetDocumentElements();

		public abstract void absShutdownDoc();
	}
}