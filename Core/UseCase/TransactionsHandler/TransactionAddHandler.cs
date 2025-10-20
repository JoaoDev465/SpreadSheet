using Core.Contract;
using Core.Entities;
using Core.Interface;
using Core.Response;
using Core.ValueObjects.TransactionsVO;

namespace Core.UseCase.TransactionsHandler;

public class TransactionAddHandler
{
    private readonly ITransactionsRepo _repositorie;

    public TransactionAddHandler(ITransactionsRepo repositorie)
    {
        _repositorie = repositorie;
    }

    public async Task<Responses<Transactions?>> AddAsync(TransactionContract contract)
    {
     
        var transaction = new Transactions(description: new Description(contract.Description),
            transactionValue: new TransactionValue(contract.TransactionValue),
            transactionType: contract.TransactionType);
            
        await  _repositorie.AddAsync(transaction);
       
        return Responses<Transactions?>.Created(transaction);
    }
}