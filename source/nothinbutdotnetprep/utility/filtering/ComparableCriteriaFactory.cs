using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public class ComparableCriteriaFactory<ItemToMatch, PropertyType> where PropertyType : IComparable<PropertyType>
    {
        public IMatchAnItem<ItemToMatch> greater_than(PropertyType value)
        {
            throw new NotImplementedException();
        }
    }
}