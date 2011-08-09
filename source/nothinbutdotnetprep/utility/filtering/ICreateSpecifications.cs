namespace nothinbutdotnetprep.utility.filtering
{
    public interface ICreateSpecifications<ItemToMatch, PropertyType>
    {
        IMatchAnItem<ItemToMatch> equal_to(PropertyType value);
        IMatchAnItem<ItemToMatch> equal_to_any(params PropertyType[] possible_values);
        IMatchAnItem<ItemToMatch> not_equal_to(PropertyType value);
        IMatchAnItem<ItemToMatch> create(Condition<ItemToMatch> condition);
    }
}