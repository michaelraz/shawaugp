using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public class ComparerBuilder<ItemToSort> : IComparer<ItemToSort>
    {
        IComparer<ItemToSort> initial;

        public ComparerBuilder(IComparer<ItemToSort> initial)
        {
            this.initial = initial;
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            return initial.Compare(x, y);
        }

        public ComparerBuilder<ItemToSort> then_by<PropertyType>(Func<ItemToSort, PropertyType> func) where PropertyType : IComparable<PropertyType>
        {
            return new ComparerBuilder<ItemToSort>(new ChainedComparer<ItemToSort>(initial, new PropertyComparer<ItemToSort, PropertyType>(func,new ComparableComparer<PropertyType>())));
        }
    }
}