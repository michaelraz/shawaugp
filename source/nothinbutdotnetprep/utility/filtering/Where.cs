using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.filtering
{
    public class Where<ItemToMatch>
    {
        public static CriteriaFactory<ItemToMatch, PropertyType> has_a<PropertyType>(
            Func<ItemToMatch, PropertyType> accessor)
        {
            return new CriteriaFactory<ItemToMatch, PropertyType>(accessor);
        }
    }

    public class CriteriaFactory<ItemToMatch, PropertyType>
    {
        Func<ItemToMatch, PropertyType> accessor;
        private bool negate = false;

        public CriteriaFactory(Func<ItemToMatch, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public IMatchAnItem<ItemToMatch> equal_to(PropertyType value)
        {
            return apply_negate(new AnonymousMatch<ItemToMatch>(item => accessor(item).Equals(value)));
        }

        public IMatchAnItem<ItemToMatch> equal_to_any(params PropertyType[] possible_values)
        {
            return apply_negate(new AnonymousMatch<ItemToMatch>(item => new List<PropertyType>(possible_values).Contains(accessor(item))));
        }

        public CriteriaFactory<ItemToMatch, PropertyType> not()
        {
            this.negate= true;
            return this;
        }

        private IMatchAnItem<ItemToMatch> apply_negate(IMatchAnItem<ItemToMatch> criteria)
        {
            if (this.negate)
                return new NegatingMatch<ItemToMatch>(criteria);
            else
                return criteria;
        }

        public IMatchAnItem<ItemToMatch> not_equal_to(PropertyType value)
        {
            return new NegatingMatch<ItemToMatch>(equal_to(value));
        }
    }

    public class MatchesNothing<T> : IMatchAnItem<T>
    {
        public bool matches(T item)
        {
            return false;
        }
    }
}