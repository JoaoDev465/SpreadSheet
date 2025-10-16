namespace Core.ValueObjects.TransactionsVO;

public class CreatedAt : ValueObject
{
    public CreatedAt(DateTime value)
    {
        Value = value;
    }
    public DateTime Value { get; set; }
}