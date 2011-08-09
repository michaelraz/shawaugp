using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
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
}