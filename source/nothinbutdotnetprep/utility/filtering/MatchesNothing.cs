namespace nothinbutdotnetprep.utility.filtering
{
    public class MatchesNothing<T> : IMatchAnItem<T>
    {
        public bool matches(T item)
        {
            return false;
        }
    }
}