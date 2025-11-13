using Core.Contract;
using Core.Entities;
using Core.Interface;
using Core.Response;

namespace Core.UseCase.USerHandler;

public class GetUserHandler
{
    private readonly IUserRepo _repo;

    public GetUserHandler(IUserRepo repo)
    {
        _repo = repo;
    }

    public async Task<Responses<User?>> GetUserHandlerAsync(ProfileContract contract)
    {
        var id = contract.Id;

        if (id == null)
        {
            return Responses<User?>.NotFound(null);
        }

        var user =  await _repo.GetById(id);
        
        return Responses<User?>.Success(user);
    }
}