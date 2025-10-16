using Core.Contract;
using Core.Entities;
using Core.Interface;
using Core.Response;
using Core.ValueObjects.TransactionsVO;

namespace Core.UseCase;

public class TransactionGetHandler
{
    private readonly ITransactionsRepo _repositorie;

    public TransactionGetHandler(ITransactionsRepo repositorie)
    {
        _repositorie = repositorie;
    }

    public async Task<Responses<Transactions?>> GetTransactionsByIdAsync(TransactionContract contract)
    {
        var id = new TransactionId(contract.Id);
        if(id.Value == null)
            return Responses<Transactions?>.NotFound(null);
        var transaction = await   _repositorie.GetById(new TransactionId(contract.Id));

        return Responses<Transactions?>.Success(transaction);
    }
}