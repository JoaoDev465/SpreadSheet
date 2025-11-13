namespace Core.ValueObjects.UserVO;

public class TransactionId
{
    public TransactionId(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
}