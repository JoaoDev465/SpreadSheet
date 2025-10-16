using Core.Entities;
using Core.ValueObjects.CategoryVO;
using Core.ValueObjects.TransactionsVO;
using Id = Core.ValueObjects.CategoryVO.Id;
using Type = Core.ValueObjects.CategoryVO.Type;

namespace test.TestEntity;

public class TestTransactionAndCategory
{
    [Fact]
    public void TestCategoryWhenConstructorIsGood()
    {
        var id = new CategoryId(1);
        var type = Type.Income;
        var name = new Name("food");

        var category = new Category(id, name);
        
        Assert.Equal(id.Value, category.Id.Value);
        Assert.Equal(name.Value, category.Name.Value);
    }
    
    [Fact]
    public void TestTransactionWhenConstrcutorIsGood()
    {
        var id = new Core.ValueObjects.TransactionsVO.TransactionId(1);
        var description = new Description("i cell a telephone");
        var amount = new Amount(0);
        var transactiontype = TransactionType.Income;
        var transactionValue = new TransactionValue(1000);
        var systemDate = new SystemDate(DateTime.Now);
        var createat = new CreatedAt(DateTime.Now);
        var categoryid = new CategoryId(1);

        var trabsaction = new Transactions(id,
            description,
            amount,
            transactionValue,
            transactiontype,
            systemDate,
            createat,
            categoryid);
        
        Assert.Equal(id.Value, trabsaction.Id.Value);
        Assert.Equal(transactiontype, trabsaction.TransactionType);
        Assert.Equal(transactionValue.Value, trabsaction.TransactionValue.Value);
        Assert.Equal(description.Value, trabsaction.Description.Value);
        Assert.Equal(createat.Value, trabsaction.CreatedAt.Value);
    }
}