using System;
using System.Collections.Generic;
using nothinbutdotnetprep.collections;
using nothinbutdotnetprep.specs;

namespace nothinbutdotnetprep.utility.sorting
{
    public class Compare<ItemToMatch>
	{
		public static IComparer<ItemToMatch> by_ascending<PropertyType>(Func<ItemToMatch, PropertyType> accessor)
			where PropertyType : IComparable<PropertyType>
		{
			return new ItemComparer<ItemToMatch, PropertyType>(accessor);
		}

		public static IComparer<ItemToMatch> by_descending<PropertyType>(Func<ItemToMatch, PropertyType> accessor)
			where PropertyType : IComparable<PropertyType>
		{
			return new NegatingItemComparer<ItemToMatch, PropertyType>(accessor);
		}
    }
}