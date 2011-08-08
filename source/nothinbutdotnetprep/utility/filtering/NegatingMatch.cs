namespace nothinbutdotnetprep.utility.filtering
{
    public class NegatingMatch<ItemToNotMatch> : IMatchAnItem<ItemToNotMatch>
    {
        IMatchAnItem<ItemToNotMatch> to_negate;

        public NegatingMatch(IMatchAnItem<ItemToNotMatch> to_negate)
        {
            this.to_negate = to_negate;
        }

        public bool matches(ItemToNotMatch item)
        {
            return ! to_negate.matches(item);
        }
    }
}