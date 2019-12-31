namespace BaseRevitModeless.Ideate
{

	using System.Collections.Generic;
	using System.Linq;

	public sealed class Id8ElementChangeSet 
	{

		public List<int> Added
		{
			get {return this.;}
			set
			{
				this. = value;
			}
		}

		public List<int> Deleted
		{
			get {return this.;}
			set
			{
				this. = value;
			}
		}

		private bool (List<int> u0002)
		{
			IEnumerable<int> nums = null;

			if(0 == 0)
			{
				nums = this.Added.Union<int>(u0002);
			}

			int num = this.Added.Count<int>();

			do
			{
				if(7 == 0 || 8 == 0)
				{
					continue;
				}

				num = (int) (num == nums.Count<int>());
			}
			while(0 != 0);

			return num;
		}


		private static Id8ElementChangeSet (List<int> u0002, List<int> u0003)
		{
			Id8ElementChangeSet id8ElementChangeSet;

			while(true)
			{
				id8ElementChangeSet = new Id8ElementChangeSet();

				if(5 != 0 && 8 != 0)
				{
					id8ElementChangeSet.Added = new List<int>(u0003.Except<int>(u0002));

					if(3 == 0)
					{
						break;
					}

					if(0 == 0)
					{
						id8ElementChangeSet.Deleted = new List<int>(u0002.Except<int>(u0003));

						break;
					}
				}
			}

			return id8ElementChangeSet;
		}


		private bool (List<int> u0002)
		{
			IEnumerable<int> nums = null;

			if(0 == 0)
			{
				nums = this.Deleted.Union<int>(u0002);
			}

			int num = this.Deleted.Count<int>();

			do
			{
				if(7 == 0 || 8 == 0)
				{
					continue;
				}

				num = (int) (num == nums.Count<int>());
			}
			while(0 != 0);

			return num;
		}


		public Id8ElementChangeSet()
		{
			this.Added   = new List<int>();
			this.Deleted = new List<int>();
		}


		public static Id8ElementChangeSet findChanges(List<int> orgIds, List<int> newIds)
		{
			Id8ElementChangeSet id8ElementChangeSet = null;

			if(orgIds.Count != newIds.Count)
			{
				id8ElementChangeSet = Id8ElementChangeSet.(orgIds, newIds);
			}
			else if(orgIds.Union<int>(newIds).Count<int>() != orgIds.Count)
			{
				id8ElementChangeSet = Id8ElementChangeSet.(orgIds, newIds);
			}

			if(id8ElementChangeSet != null)
			{
				return id8ElementChangeSet;
			}

			return new Id8ElementChangeSet();
		}


		public bool isEmptySet()
		{
			Label0:
			List<int> added = this.Added;
			int       count = added.Count;

			do
			{
				if(count != 0 && 3 != 0)
				{
					if(0 != 0)
					{
						goto Label0;
					}

					count = 0;

					if(count != 0)
					{
						continue;
					}

					return count;
				}
				else
				{
					count = this.Deleted.Count;
				}
			}
			while(0 != 0);

			return count == 0;
		}


		public bool isSame(Id8ElementChangeSet set)
		{
			Id8ElementChangeSet id8ElementChangeSet;
			List<int>           deleted;
			bool                flag;
			Label0:

			while(0 == 0)
			{
				bool flag1 = this.(set.Added);

				do
				{
					if(flag1 || 3 == 0)
					{
						id8ElementChangeSet = set;
						deleted             = id8ElementChangeSet.Deleted;
						flag                = this.(deleted);

						return flag;
					}

					if(0 != 0)
					{
						goto Label0;
					}

					flag1 = false;
				}
				while(flag1);

				return flag1;
			}

			id8ElementChangeSet = set;
			deleted             = id8ElementChangeSet.Deleted;
			flag                = this.(deleted);

			return flag;
		}


		public override string ToString()
		{
			return string.Format("Id8ElementChangeSet: Addes: [{0}] Deletes: [{1}]", this.Added.Count, this.Deleted.Count);
		}



	}

}