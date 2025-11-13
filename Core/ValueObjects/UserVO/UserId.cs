namespace Core.ValueObjects.UserVO;

public class UserId : ValueObject
{
    public UserId(int? id)
    {
        userId = id;
    }
    public int? userId{ get; set; }
    
    
}