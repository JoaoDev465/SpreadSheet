using Core.Entities;
using Core.Interface;
using Data.DB;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class UserRepo : IUserRepo
{
    private readonly Context _context;

    public UserRepo(Context context)
    {
        _context = context;
    }
    public async  Task AddAsync(User user)
    {
        try
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async  Task<User?> GetById(int id)
    {
        try
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id== id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public  async Task PutAsync(int id, User user)
    {
        try
        {
          await  _context.Users.FirstOrDefaultAsync(x => x.Id == id);
          _context.Users.Update(user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}