using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public class NegatingComparer<ItemToCompare> : IComparer<ItemToCompare>
    {
        IComparer<ItemToCompare> inner;

        public NegatingComparer(IComparer<ItemToCompare> inner)
        {
            this.inner = inner;
        }

        public int Compare(ItemToCompare x, ItemToCompare y)
        {
            return -inner.Compare(x, y);
        }
    }
}