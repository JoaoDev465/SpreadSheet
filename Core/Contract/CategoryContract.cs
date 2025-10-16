using Type = Core.ValueObjects.CategoryVO.Type;

namespace Core.Contract;

public class CategoryContract : DTO
{
    public int Id { get; set; }
    public string? Name { get; set; } = String.Empty;
    public Type Type { get; set; }
}