using Core.ValueObjects.CategoryVO;
using Core.ValueObjects.TransactionsVO;
using Id = Core.ValueObjects.CategoryVO.Id;
using Type = Core.ValueObjects.CategoryVO.Type;

namespace Core.Entities;

public class Category
{
    public CategoryId Id { get; set; }
    public Name Name { get; private set; }
    public Transactions Transaction { get; set; }
    
    private Category(){}

    public Category(
        CategoryId id,
        Name name)
    {
        Id = id;
        Name = name;
    }

    public Category(
        Name name,
        Type type)
    {
        Name = name;
    }

    public void ChangeName(Name name)
    {
        Name.Value = name.Value ?? throw new NullReferenceException(nameof(name));
    }
    
}