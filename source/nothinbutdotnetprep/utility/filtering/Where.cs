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

        public static ComparableCriteriaFactory<ItemToMatch, PropertyType> has_an<PropertyType>(
            Func<ItemToMatch, PropertyType> accessor)
        {
            return new CriteriaFactory<ItemToMatch, PropertyType>(accessor);
        }
    }

    public class CriteriaFactory<ItemToMatch, PropertyType> 
    {
        Func<ItemToMatch, PropertyType> accessor;

        public CriteriaFactory(Func<ItemToMatch, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public IMatchAnItem<ItemToMatch> equal_to(PropertyType value)
        {
            return new AnonymousMatch<ItemToMatch>(item => accessor(item).Equals(value));
        }

        public IMatchAnItem<ItemToMatch> equal_to_any(params PropertyType[] possible_values)
        {
            return
                new AnonymousMatch<ItemToMatch>(item => new List<PropertyType>(possible_values).Contains(accessor(item)));
        }

        public IMatchAnItem<ItemToMatch> not_equal_to(PropertyType value)
        {
            return equal_to(value).not();
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