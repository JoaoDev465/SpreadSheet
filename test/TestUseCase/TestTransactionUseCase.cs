using Core.Contract;
using Core.UseCase;
using Core.UseCase.TransactionsHandler;
using Core.ValueObjects.TransactionsVO;
using Data.DB;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace test.TestUseCase;

public class TestTransactionUseCase
{
    [Fact]
    public async Task TesteTransactionsUseCaseWhenIsGoodResult()
    {
        var options = new DbContextOptionsBuilder<Context>().UseInMemoryDatabase("N").Options;
        var context = new Context(options);
        
        var repo = new TransactionRepo(context);
        var transactionAddHandler = new TransactionAddHandler(repo);

        var contract = new TransactionContract
        {
            Id = 1,
            Description = "comprei uma casa ",
            TransactionType = TransactionType.Expense,
            TransactionValue = 20000
        };

        var result = transactionAddHandler.AddAsync(contract);

        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
    }
}