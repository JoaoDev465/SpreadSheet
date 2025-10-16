using Core.Contract;
using Core.Entities;
using Core.Interface;
using Core.Response;
using Core.ValueObjects.TransactionsVO;

namespace Core.UseCase;

public class TransactionPutHandler
{
    private readonly ITransactionsRepo _repositorie;

    public TransactionPutHandler(ITransactionsRepo repositorie)
    {
        _repositorie = repositorie;
    }

    public async Task<Responses<Transactions?>> PutTransactionsync(TransactionContract contract)
    {

        var id = await  _repositorie.GetById(new TransactionId(contract.Id));

        if (id == null)
        {
            return Responses<Transactions?>.NotFound(null);
        }

        var transaction = new Transactions(description: new Description(contract.Description),
            transactionValue: new TransactionValue(contract.TransactionValue),
            transactionType: contract.TransactionType);

        await _repositorie.PutAsync(transaction);
        
        return Responses<Transactions?>.Success(transaction);
    }
}