using System;

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
            return equal_to_any(value);
        }

        public IMatchAnItem<ItemToMatch> equal_to_any(params PropertyType[] possible_values)
        {
            return create(new IsEqualToAny<PropertyType>(possible_values)))
            ;
        }

        public IMatchAnItem<ItemToMatch> create(IMatchAnItem<PropertyType> condition)
        {
            return new PropertyMatch<ItemToMatch, PropertyType>(accessor, condition);
        }

        public IMatchAnItem<ItemToMatch> not_equal_to(PropertyType value)
        {
            return equal_to(value).not();
        }
    }
}