namespace Core.ValueObjects.TransactionsVO;

public class Description : ValueObject
{
    public Description(string? value)
    {
        Value = value;
    }
    public string? Value { get; set; }
}