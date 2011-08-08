using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public static class MatcherExtensions
    {
        public static IMatchAnItem<ItemToMatch> not<ItemToMatch>(this IMatchAnItem<ItemToMatch> to_negate)
                                                                
        {
            return new NegatingMatch<ItemToMatch>(to_negate);
        }

        public static IMatchAnItem<ItemToMatch> or<ItemToMatch>(this IMatchAnItem<ItemToMatch> left_side,
                                                                IMatchAnItem<ItemToMatch> right_side)
        {
            return new OrMatch<ItemToMatch>(left_side, right_side);
        }

        public static IMatchAnItem<ItemToMatch> equal_to<ItemToMatch,PropertyType>(this Func<ItemToMatch,PropertyType> accessor,PropertyType value_to_equal)
        {
            return new AnonymousMatch<ItemToMatch>(item => accessor(item).Equals(value_to_equal));
        }
    }
}