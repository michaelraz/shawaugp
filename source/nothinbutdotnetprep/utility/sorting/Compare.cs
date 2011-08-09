using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public class Compare<ItemToSort>
    {
        public static ComparerBuilder<ItemToSort> by<PropertyType>(Func<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new ComparerBuilder<ItemToSort>(new ItemComparer<ItemToSort, PropertyType>(accessor));
        }

        public static ComparerBuilder<ItemToSort> by_descending<PropertyType>(Func<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new ComparerBuilder<ItemToSort>(new NegatingComparer<ItemToSort>(by(accessor)));
        }

        public static ComparerBuilder<ItemToSort> by<PropertyType>(Func<ItemToSort, PropertyType> accessor, params PropertyType[] order)
		{
        	IList<PropertyType> list = order;
        	Func<ItemToSort, int> indexAccessor = item => list.IndexOf(accessor(item));

			return new ComparerBuilder<ItemToSort>(new ItemComparer<ItemToSort, int>(indexAccessor));
        }
    }
}