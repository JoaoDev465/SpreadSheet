using Core.ValueObjects.TransactionsVO;

namespace Core.Entities;

public class Transactions
{
    public Transactions(
        TransactionId id,
        Description description,
        Amount amount,
        TransactionValue transactionValue,
        TransactionType transactionType,
        SystemDate systemDate,
        CreatedAt createdAt,
        CategoryId categoryId)
    {
        Id = id;
        Description = description;
        Amount = amount;
        TransactionType = transactionType;
        TransactionValue = transactionValue;
        SystemDate = systemDate;
        CreatedAt = createdAt;
        CategoryId = categoryId;
    }
    
    public Transactions(
        Description? description,
        TransactionValue transactionValue,
        TransactionType transactionType)
    {
        Description = description;
        Amount = new Amount();
        TransactionValue = transactionValue;
        TransactionType = transactionType;
        SystemDate = new SystemDate(DateTime.UtcNow);
        CreatedAt = new CreatedAt(DateTime.UtcNow);
        CategoryId = new CategoryId(Category.Id.Value);
    }
    
    private Transactions (){}
    
    public TransactionId? Id { get; set; }
    public Description? Description { get; set; }
    public Amount Amount { get; }
    public  TransactionValue TransactionValue { get; set; }
    public TransactionType TransactionType { get; set; }
    public SystemDate SystemDate { get; private set; }
    public CreatedAt CreatedAt { get; set; }
    public CategoryId CategoryId { get; set; }
    public Category? Category { get; set; }

    public bool IsExpensive() => TransactionType == TransactionType.Expense;
    public bool IsIncome() => TransactionType == TransactionType.Income;

    public void TransactionLimit(decimal maxvalue)
    {
        if (Amount.Value > 3000)
            throw new Exception("the value exceed limit");

    }

    public void ApplyTransaction(TransactionValue value)
    {
        if (TransactionValue.Value + Amount.Value > 3000)
            throw new Exception("Invalid Operation");
        TransactionValue = new TransactionValue(TransactionValue.Value + Amount.Value);
    }
    
}