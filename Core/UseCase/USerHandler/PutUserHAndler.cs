using Core.Contract;
using Core.Entities;
using Core.Interface;
using Core.Response;
using Core.ValueObjects.UserVO;

namespace Core.UseCase.USerHandler;

public class PutUserHAndler
{
    private readonly IUserRepo _repo;

    public PutUserHAndler(IUserRepo repo)
    {
        _repo = repo;
    }

    public async Task<Responses<User?>> PutUserHandlerAsync(ProfileContract contract)
    {
        var id = contract.Id;

        if (id == null)
        {
            return Responses<User?>.NotFound(null);
        }

        var user = new User(new Email(contract.Email));

        await _repo.PutAsync(id, user);
        
        return Responses<User?>.Success(user);
    }
}