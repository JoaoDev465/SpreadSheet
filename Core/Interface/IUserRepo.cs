using Core.Entities;

namespace Core.Interface;

public interface IUserRepo
{
    public Task AddAsync(User user);
    public Task<User?> GetById(int id);
    public Task PutAsync(int id, User  user);
}