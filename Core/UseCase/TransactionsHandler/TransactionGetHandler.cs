using Core.Contract;
using Core.Entities;
using Core.Interface;
using Core.Response;
using Core.ValueObjects.TransactionsVO;

namespace Core.UseCase.TransactionsHandler;

public class TransactionGetHandler
{
    private readonly ITransactionsRepo _repositorie;

    public TransactionGetHandler(ITransactionsRepo repositorie)
    {
        _repositorie = repositorie;
    }

    public async Task<Responses<Transactions?>> GetTransactionsByIdAsync(TransactionContract contract)
    {
        
        var id = contract.Id;
        if(id == null)
            return Responses<Transactions?>.NotFound(null);
        var transaction = await   _repositorie.GetById(contract.Id);

        return Responses<Transactions?>.Success(transaction);
    }

    public async Task<Responses<List<Transactions?>>> GetAllTransactions(ProfileContract contract)
    {
        var id = contract.Id;

        if (id == null)
        {
            return (PagedResponse<List<Transactions?>>)Responses<List<Transactions?>>.NotFound(null);
        }

        var transactions = await _repositorie.GetAll(id);

        return PagedResponse<List<Transactions?>>.Success(transactions.Data);
    }
}