using System;
using nothinbutdotnetprep.utility.ranges;

namespace nothinbutdotnetprep.utility.filtering
{
    public static class FilteringExtensions
    {
        public static IMatchAnItem<ItemToMatch> equal_to<ItemToMatch, PropertyType>(this IProvideAccessToFiltering<ItemToMatch,PropertyType> extension,PropertyType value )
        {
            return equal_to_any(extension, value);
        }
        public static IMatchAnItem<ItemToMatch> equal_to_any<ItemToMatch, PropertyType>(
            this IProvideAccessToFiltering<ItemToMatch, PropertyType> extension, params PropertyType[] possible_values)
        {
            return create(extension, new IsEqualToAny<PropertyType>(possible_values));
        }

        public static IMatchAnItem<ItemToMatch> greater_than<ItemToMatch>(
            this IProvideAccessToFiltering<ItemToMatch, DateTime> extension,int value)
        {
            return create(extension, new YearOfDateIsGreaterThanYear(value));
        }

        public static IMatchAnItem<ItemToMatch> greater_than<ItemToMatch, PropertyType>(
            this IProvideAccessToFiltering<ItemToMatch, PropertyType> extension, PropertyType value)
            where PropertyType : IComparable<PropertyType>
        {
            return create(extension, new IsGreaterThan<PropertyType>(value));
        }

        public static IMatchAnItem<ItemToMatch> between<ItemToMatch, PropertyType>(
            this IProvideAccessToFiltering<ItemToMatch, PropertyType> extension, PropertyType start, PropertyType end)
            where PropertyType : IComparable<PropertyType>
        {
            return create(extension, new FallsInRange<PropertyType>(new InclusiveRange<PropertyType>(start, end)));
        }

        static IMatchAnItem<ItemToMatch> create<ItemToMatch, PropertyType>(
            this IProvideAccessToFiltering<ItemToMatch, PropertyType> extension, IMatchAnItem<PropertyType> condition)
        {
            return extension.create_criteria(condition);
        }
    }
}