namespace nothinbutdotnetprep.utility
{
    public class OrMatch<ItemToMatch> : IMatchAnItem<ItemToMatch>
    {
        IMatchAnItem<ItemToMatch> left_side;
        IMatchAnItem<ItemToMatch> right_side;

        public OrMatch(IMatchAnItem<ItemToMatch> left_side, IMatchAnItem<ItemToMatch> right_side)
        {
            this.left_side = left_side;
            this.right_side = right_side;
        }

        public bool matches(ItemToMatch item)
        {
            return left_side.matches(item) || right_side.matches(item);
        }
    }
}