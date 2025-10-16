namespace Core.ValueObjects.TransactionsVO;

public class TransactionId : ValueObject
{
    public TransactionId(int? value)
    {
        Value = value;
    }
    public int? Value { get; set; }
}