namespace Core.ValueObjects.TransactionsVO;

public class SystemDate : ValueObject
{
    public SystemDate(DateTime value)
    {
        Value = value;
    }
    public DateTime Value { get; set; }
}