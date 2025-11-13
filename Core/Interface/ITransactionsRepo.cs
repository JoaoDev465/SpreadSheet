using System.Transactions;
using Core.Entities;
using Core.Response;
using Core.ValueObjects.TransactionsVO;
using Id = Core.ValueObjects.CategoryVO.Id;

namespace Core.Interface;

public interface ITransactionsRepo
{
    public Task AddAsync(Transactions transactions);
    public Task<Transactions?> GetById(int id);
    public Task PutAsync(int id,Transactions transactions);
    public Task<PagedResponse<List<Transactions?>>> GetAll(int id);
}