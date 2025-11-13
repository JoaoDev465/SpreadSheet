using Core.Contract;
using Core.Entities;
using Core.Interface;
using Core.Response;
using Core.ValueObjects.UserVO;

namespace Core.UseCase.USerHandler;

public class AddUserHandler
{
    private readonly IUserRepo _repo;

    public AddUserHandler(IUserRepo repo)
    {
        _repo = repo;
    }
    public async  Task<Responses<User?>> AddUsersHandlerAsync(ProfileContract contract)
    {
        var user = new User(new Email(contract.Email));
          await  _repo.AddAsync(user);
        
        return Responses<User?>.Created(user);
    }
}