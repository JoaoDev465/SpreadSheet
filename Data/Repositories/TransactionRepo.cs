using System.Linq.Expressions;
using System.Transactions;
using Core.Entities;
using Core.Interface;
using Core.Response;
using Core.UseCase.TransactionsHandler;
using Core.ValueObjects.TransactionsVO;
using Core.ValueObjects.UserVO;
using Data.DB;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class TransactionRepo: ITransactionsRepo
{
    private readonly Context _context;

    public TransactionRepo(Context context)
    {
        _context = context;
    }
    public async  Task AddAsync(Transactions transactions)
    {
       await  _context.Transactions.AddAsync(transactions);
       await   _context.SaveChangesAsync();
    }
    

    public async Task<Transactions?> GetById(int  id)
    {
       return  await _context.Transactions.AsNoTracking()
           .Include(x=>x.User)
           .Where(x=>x.UserId == id )
            .FirstOrDefaultAsync();
    }

    public async Task PutAsync(int id,Transactions transaction)
    {
        await _context.Transactions
            .FirstAsync(x => x.Id == id);

        _context.Update(transaction);
        await _context.SaveChangesAsync();
    }

    public async Task<PagedResponse<List<Transactions?>>> GetAll(int id)
    {
        
        try
        {
            var query = 
                _context
                .Transactions
                .AsNoTracking()
                .Include(x=>x.User)
                .Where(x=>x.UserId ==  id )
                .OrderBy(x => x.TransactionType);

            var transactions = await query
                    .Skip((Core.Configs.Configuration.CurrentPage - 1) * Core.Configs.Configuration.PageSize )
                    .Take(Core.Configs.Configuration.PageSize)
                    .ToListAsync();

            var count = await _context.Transactions.CountAsync();

            return new PagedResponse<List<Transactions?>>
            (
                transactions,
                count,
                Core.Configs.Configuration.CurrentPage,
                Core.Configs.Configuration.PageSize
            );


        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}