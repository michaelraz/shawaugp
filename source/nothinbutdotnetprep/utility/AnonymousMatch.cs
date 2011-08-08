namespace nothinbutdotnetprep.utility
{
    public class AnonymousMatch<ItemToMatch> : IMatchAnItem<ItemToMatch>
    {
        Condition<ItemToMatch> condition;

        public AnonymousMatch(Condition<ItemToMatch> condition)
        {
            this.condition = condition;
        }

        public bool matches(ItemToMatch movie)
        {
            return condition(movie);
        }
    }
}