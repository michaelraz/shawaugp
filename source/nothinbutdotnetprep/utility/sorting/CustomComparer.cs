using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
	public class CustomComparer<ItemType, PropertyType> : IComparer<ItemType>
    {
		private readonly Func<ItemType, PropertyType> accessor;
		private readonly IList<PropertyType> order;

		public CustomComparer(Func<ItemType, PropertyType> accessor, IList<PropertyType> order)
		{
			this.accessor = accessor;
			this.order = order;
		}

		public int Compare(ItemType x, ItemType y)
		{
			return index_of(x).CompareTo(index_of(y));
        }

		private int index_of(ItemType item)
		{
			return order.IndexOf(accessor(item));
		}
    }
}