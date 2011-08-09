using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.filtering
{
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
}