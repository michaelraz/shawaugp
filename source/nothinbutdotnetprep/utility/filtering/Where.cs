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
			 where PropertyType : IComparable<PropertyType>
        {
			return new ComparableCriteriaFactory<ItemToMatch, PropertyType>(accessor,has_a(accessor));
        }
    }

    public class CriteriaFactory<ItemToMatch, PropertyType> : ICreateSpecifications<ItemToMatch, PropertyType>
    {
        Func<ItemToMatch, PropertyType> accessor;

        public CriteriaFactory(Func<ItemToMatch, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public IMatchAnItem<ItemToMatch> equal_to(PropertyType value)
        {
            return create(item => accessor(item).Equals(value));
        }

        public IMatchAnItem<ItemToMatch> equal_to_any(params PropertyType[] possible_values)
        {
            return create(item => new List<PropertyType>(possible_values).Contains(accessor(item)));
        }

        public IMatchAnItem<ItemToMatch> create(Condition<ItemToMatch> condition)
        {
            return new AnonymousMatch<ItemToMatch>(condition);
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