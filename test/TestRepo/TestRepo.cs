using System.Transactions;
using Core.Entities;
using Core.ValueObjects.CategoryVO;
using Core.ValueObjects.TransactionsVO;
using Data.DB;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace test.TestRepo;

public class TestRepo
{
    [Fact]
    public async Task TestRepoWhenISGood()
    {
        var options = new DbContextOptionsBuilder<Context>().UseInMemoryDatabase("N").Options;
        var context = new Context(options);

        var category = new Category(new CategoryId(1), new Name("viagem"));

        var trabsaction = new Transactions(
            1,
            new Description("I cell my phone"),
            new Amount(0),
            new TransactionValue(100),
            TransactionType.Expense,
            new SystemDate(DateTime.Now),
            new CreatedAt(DateTime.Now),
           category.Id);

        var repo = new TransactionRepo(context); 
        await  repo.AddAsync(trabsaction);

        var categoryrepo = new CategoryRepo(context);

       await  categoryrepo.AddAsync(category);
        

        var add = await context.Transactions.FirstAsync(x=>x.Id == trabsaction.Id);
        var addcategory = await context.Categories.FirstAsync(x => x.Id.Value == category.Id.Value);
        
        Assert.NotNull(add);
        Assert.NotNull(addcategory);
    }

}