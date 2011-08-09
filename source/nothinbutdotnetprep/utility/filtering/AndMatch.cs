namespace nothinbutdotnetprep.utility.filtering
{
    public class AndMatch<ItemToMatch> : IMatchAnItem<ItemToMatch>
    {
        IMatchAnItem<ItemToMatch> left_side;
        IMatchAnItem<ItemToMatch> right_side;

        public AndMatch(IMatchAnItem<ItemToMatch> left_side, IMatchAnItem<ItemToMatch> right_side)
        {
            this.left_side = left_side;
            this.right_side = right_side;
        }

        public bool matches(ItemToMatch item)
        {
            return left_side.matches(item) && right_side.matches(item);
        }
    }
}