namespace nothinbutdotnetprep.utility.filtering
{
    public interface IMatchAnItem<in ItemToMatch>
    {
        bool matches(ItemToMatch item);
    }
}