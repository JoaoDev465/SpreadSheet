namespace Core.ValueObjects.CategoryVO;

public class Name : ValueObject
{
    public Name(string value)
    {
        Value = value;
    }
    public string Value { get; set; }
}