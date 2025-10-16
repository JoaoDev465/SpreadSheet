namespace Core.ValueObjects.TransactionsVO;

public class CategoryId : ValueObject
{
    public CategoryId(int value)
    {
        Value = value;
    }
    public int  Value { get; set; }
}