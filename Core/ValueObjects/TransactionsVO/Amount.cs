namespace Core.ValueObjects.TransactionsVO;

public class Amount : ValueObject
{
    public Amount(decimal value = 0)
    {
        Value = value;
    }

    public decimal  Value { get; set; }
}