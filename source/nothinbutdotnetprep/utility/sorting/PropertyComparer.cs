using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
	public class PropertyComparer<ItemToCompare, PropertyType> : IComparer<ItemToCompare>
    {
		Func<ItemToCompare, PropertyType> accessor;
	    IComparer<PropertyType> real_comparer;

		public PropertyComparer(Func<ItemToCompare, PropertyType> accessor, IComparer<PropertyType> real_comparer)
		{
		    this.accessor = accessor;
		    this.real_comparer = real_comparer;
		}

	    public int Compare(ItemToCompare x, ItemToCompare y)
        {
	        return real_comparer.Compare(accessor(x), accessor(y));
        }
    }
}