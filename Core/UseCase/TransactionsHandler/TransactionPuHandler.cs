using Core.Contract;
using Core.Entities;
using Core.Interface;
using Core.Response;
using Core.ValueObjects.TransactionsVO;
using Microsoft.AspNetCore.Http;

namespace Core.UseCase.TransactionsHandler;

public class TransactionPutHandler
{
    private readonly ITransactionsRepo _repositorie;
    private readonly IHttpContextAccessor _accessor;

    public TransactionPutHandler(ITransactionsRepo repositorie,IHttpContextAccessor accessor)
    {
        _repositorie = repositorie;
        _accessor = accessor;
    }

    public async Task<Responses<Transactions?>> PutTransactionsync(TransactionContract contract)
    {
        var id = contract.Id;

        if (id == null)
        {
            return Responses<Transactions?>.NotFound(null);
        }

        var principalId = _accessor?.HttpContext?.Request?.Headers?["userId"].ToString();
        var transaction = new Transactions(description: new Description(contract.Description),
            transactionValue: new TransactionValue(contract.TransactionValue),
            transactionType: contract.TransactionType,
            userId: int.Parse(principalId),
            new CategoryId(contract.Id));

        await _repositorie.PutAsync(id,transaction);
        
        return Responses<Transactions?>.Success(transaction);
    }
}