using System.Linq.Expressions;
using System.Transactions;
using Core.Entities;
using Core.Interface;
using Core.Response;
using Core.UseCase.TransactionsHandler;
using Core.ValueObjects.TransactionsVO;
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
    

    public async Task<Transactions?> GetById(TransactionId  id)
    {
        return await _context.Transactions.AsNoTracking()
            .FirstOrDefaultAsync(x=>x.Id.Value == id.Value);
    }

    public async Task PutAsync(Transactions transaction)
    {
        await _context.Transactions
            .FirstOrDefaultAsync(x => x.Id.Value == transaction.Id.Value);

        _context.Update(transaction);
        await _context.SaveChangesAsync();
    }

    public async Task<PagedResponse<List<Transactions?>>> GetAll(TransactionId id)
    {
        try
        {
            var query = 
                _context
                .Transactions
                .AsNoTracking()
                .Where(x => x.Id.Value == id.Value)
                .OrderBy(x => x.TransactionType);

            var Transactions = await
                    _context
                    .Transactions
                    .Skip((Core.Configs.Configuration.CurrentPage - 1) * Core.Configs.Configuration.PageSize )
                    .Take(Core.Configs.Configuration.PageSize)
                    .ToListAsync();

            var count = await _context.Transactions.CountAsync();

            return new PagedResponse<List<Transactions?>>
            (
                Transactions,
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