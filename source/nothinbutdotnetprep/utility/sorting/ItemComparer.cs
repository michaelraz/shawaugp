using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.specs
{
	public class ItemComparer<ItemToCompare, PropertyType> : IComparer<ItemToCompare>
		where PropertyType : IComparable<PropertyType>
    {
		private readonly Func<ItemToCompare, PropertyType> accessor;

		public ItemComparer(Func<ItemToCompare, PropertyType> accessor)
		{
			this.accessor = accessor;
		}

		public int Compare(ItemToCompare x, ItemToCompare y)
        {
			return accessor(x).CompareTo(accessor(y));
        }
    }

	public class NegatingItemComparer<ItemToCompare, PropertyType> : IComparer<ItemToCompare>
		where PropertyType : IComparable<PropertyType>
	{
		private IComparer<ItemToCompare> inner;

		public NegatingItemComparer(Func<ItemToCompare, PropertyType> accessor)
			: this(new ItemComparer<ItemToCompare, PropertyType>(accessor))
		{
		}

		protected NegatingItemComparer(IComparer<ItemToCompare> inner)
		{
			this.inner = inner;
		}

		public int Compare(ItemToCompare x, ItemToCompare y)
		{
			return inner.Compare(y, x);
		}
	}
}