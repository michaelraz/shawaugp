using System;

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
			IMatchAnItem<ItemToMatch> matcher = new AnonymousMatch<ItemToMatch>(item => false);
			if (possible_values == null)
				return matcher;
        	
			foreach (var value in possible_values)
        		matcher = matcher.or(equal_to(value));

        	return matcher;
        }
    }
}