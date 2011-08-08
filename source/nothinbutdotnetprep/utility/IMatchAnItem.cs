namespace nothinbutdotnetprep.utility
{
    public interface IMatchAnItem<in ItemToMatch>
    {
        bool matches(ItemToMatch item);
    }
}