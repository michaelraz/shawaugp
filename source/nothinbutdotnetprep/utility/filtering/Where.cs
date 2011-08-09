using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public class Where<ItemToMatch>
    {
        public static FilteringExtensionPoint<ItemToMatch, PropertyType> has_a<PropertyType>(
            Func<ItemToMatch, PropertyType> accessor)
        {
            return new FilteringExtensionPoint<ItemToMatch, PropertyType>(accessor);
        }

    }
}