using Core.Contract;
using Core.Entities;
using Core.Interface;
using Core.Response;
using Core.ValueObjects.TransactionsVO;
using Microsoft.AspNetCore.Http;

namespace Core.UseCase.TransactionsHandler;

public class TransactionAddHandler
{
    private readonly ITransactionsRepo _repositorie;
    private readonly IHttpContextAccessor _accessor;

    public TransactionAddHandler(ITransactionsRepo repositorie, IHttpContextAccessor accessor)
    {
        _repositorie = repositorie;
        _accessor = accessor;
    }

    public async Task<Responses<Transactions?>> AddAsync(TransactionContract contract)
    {
        var principalId = _accessor?.HttpContext?.Request?.Headers?["userId"].ToString();
        var transaction = new Transactions(description: new Description(contract.Description),
            transactionValue: new TransactionValue(contract.TransactionValue),
            transactionType: contract.TransactionType,
            userId: int.Parse(principalId) ,
             new CategoryId(contract.CategoryId));
            
        await  _repositorie.AddAsync(transaction);
       
        return Responses<Transactions?>.Created(transaction);
    }
}