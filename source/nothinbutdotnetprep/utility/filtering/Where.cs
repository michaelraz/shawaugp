using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public class Where<ItemToMatch>
    {
        public static Something has_a<PropertyType>(Func<ItemToMatch, PropertyType> accessor)
        {
            throw new NotImplementedException();
        }
    }
}