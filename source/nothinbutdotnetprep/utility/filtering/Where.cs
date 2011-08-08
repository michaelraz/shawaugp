using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public class Where<ItemToMatch>
    {
        public static Func<ItemToMatch, PropertyType> has_a<PropertyType>(Func<ItemToMatch, PropertyType> accessor)
        {
            return accessor;
        }
    }
}