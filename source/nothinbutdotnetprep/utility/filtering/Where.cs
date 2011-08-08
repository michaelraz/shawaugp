using System;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.utility.filtering
{
    public class Where<ItemToMatch>
    {
        public static Filter<ItemToMatch, PropertyType> has_a<PropertyType>(Func<ItemToMatch, PropertyType> accessor)
        {
            return new Filter<ItemToMatch, PropertyType>(accessor);
        }
    }

    public class Filter<ItemToMatch, PropertyType>
    {
        private readonly Func<ItemToMatch, PropertyType> accessor;

        public Filter(Func<ItemToMatch, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public Condition<Movie> equal_to(ProductionStudio studio)
        {
            return accessor(studio).Equals();
        }
    }
}