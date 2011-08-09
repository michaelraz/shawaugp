using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public interface IProvideAccessToFiltering<ItemToMatch, PropertyType>
    {
        IMatchAnItem<ItemToMatch> create_criteria(IMatchAnItem<PropertyType> criteria);
    }

    public class FilteringExtensionPoint<ItemToMatch,PropertyType> : IProvideAccessToFiltering<ItemToMatch, PropertyType>
    {
        Func<ItemToMatch, PropertyType> accessor;

        public FilteringExtensionPoint(Func<ItemToMatch, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public IProvideAccessToFiltering<ItemToMatch,PropertyType>  not
        {
            get { return new NegatingExtensionPoint<ItemToMatch,PropertyType>(this); }
        }

        public IMatchAnItem<ItemToMatch> create_criteria(IMatchAnItem<PropertyType> criteria)
        {
            return new PropertyMatch<ItemToMatch, PropertyType>(accessor, criteria);
        }
    }

    public class NegatingExtensionPoint<ItemToMatch,PropertyType>:IProvideAccessToFiltering<ItemToMatch,PropertyType>
    {
        IProvideAccessToFiltering<ItemToMatch, PropertyType> original;

        public NegatingExtensionPoint(IProvideAccessToFiltering<ItemToMatch, PropertyType> original)
        {
            this.original = original;
        }

        public IMatchAnItem<ItemToMatch> create_criteria(IMatchAnItem<PropertyType> criteria)
        {
            return new NegatingMatch<ItemToMatch>(original.create_criteria(criteria));
        }
    }
}