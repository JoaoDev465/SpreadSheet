namespace Core.ValueObjects.UserVO;

public class Email : ValueObject
{
    public Email(string email)
    {
        UserEmail = email;
    }
    public string UserEmail { get; set; }
}