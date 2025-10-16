using System.Transactions;
using Core.Entities;
using Core.Interface;
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

    public async Task<List<Transactions?>> GetAll()
    {
        return await _context.Transactions.AsNoTracking().ToListAsync();
    }
}