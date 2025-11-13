using System.ComponentModel.DataAnnotations;
using Core.ValueObjects.TransactionsVO;

namespace Core.Contract;

public class TransactionContract
{
     
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string? Description { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório")]
    [MoneyValidation(3000.00)]
    public  decimal TransactionValue { get; set; }
    [Required(ErrorMessage = "o tipo de transação é obrigatório")]
    public TransactionType TransactionType { get; set; }
}

public class MoneyValidationAttribute : ValidationAttribute
{
    private readonly double _maxValue;

    public MoneyValidationAttribute(double maxValue)
    {
        _maxValue = maxValue;
        ErrorMessage = $"o valor máximo de transação permitido é de {maxValue}";
    }
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {

        if (value is decimal decimalValue && decimalValue > (decimal) _maxValue)
        {
                return new ValidationResult(ErrorMessage);
            
        }
        return ValidationResult.Success;
    }
}