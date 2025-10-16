namespace Core.ValueObjects.TransactionsVO;

public class TransactionValue: ValueObject
{
    public TransactionValue(decimal value)
    {
        Value = value;
    }
    public decimal Value { get; set; }
}