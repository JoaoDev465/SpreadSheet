namespace Core.ValueObjects.CategoryVO;

public class Id : ValueObject
{
    public Id(int? value)
    {
        Value = value;
    }
    public int? Value { get; set; }
}