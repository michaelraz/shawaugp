using System;
using nothinbutdotnetprep.utility.ranges;

namespace nothinbutdotnetprep.utility.filtering
{
    public class ComparableCriteriaFactory<ItemToMatch, PropertyType> : ICreateSpecifications<ItemToMatch, PropertyType>
        where PropertyType : IComparable<PropertyType>
    {

        public ComparableCriteriaFactory( ICreateSpecifications<ItemToMatch, PropertyType> original)
        {
            this.original = original;
        }

        public IMatchAnItem<ItemToMatch> equal_to(PropertyType value)
        {
            return original.equal_to(value);
        }

        public IMatchAnItem<ItemToMatch> equal_to_any(params PropertyType[] possible_values)
        {
            return original.equal_to_any(possible_values);
        }

        public IMatchAnItem<ItemToMatch> not_equal_to(PropertyType value)
        {
            return original.not_equal_to(value);
        }

        public IMatchAnItem<ItemToMatch> create(IMatchAnItem<PropertyType> condition)
        {
            return original.create(condition);
        }

        ICreateSpecifications<ItemToMatch, PropertyType> original;

        public IMatchAnItem<ItemToMatch> greater_than(PropertyType value)
        {
            return create(new IsGreaterThan<PropertyType>(value));
        }

        public IMatchAnItem<ItemToMatch> between(PropertyType start, PropertyType end)
        {
            return create(new FallsInRange<PropertyType>(new InclusiveRange<PropertyType>(start, end)));
        }
    }
}