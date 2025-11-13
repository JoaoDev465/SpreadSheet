using Core.ValueObjects.UserVO;

namespace Core.Entities;

public class User
{

    public User(Email email)
    {
        Email = email;

    }

    public User(){}
    
    public int Id{ get; set; }
    public Email Email { get; set; }

    public List<Transactions> TransactionsList { get; set; }
    public void ChangeEmail(Email email)
    {
        Email.UserEmail = email.UserEmail;
        if (email == null)
        {
            throw new Exception("Email Cannot null");
        }
    }
}
