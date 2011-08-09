using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public class ComparableCriteriaFactory<ItemToMatch, PropertyType> where PropertyType : IComparable<PropertyType>
    {
        Func<ItemToMatch, PropertyType> accessor;

		public ComparableCriteriaFactory(Func<ItemToMatch, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public IMatchAnItem<ItemToMatch> greater_than(PropertyType value)
        {
            return new AnonymousMatch<ItemToMatch>(item => accessor(item).CompareTo(value) > 0);
        }
    }
}