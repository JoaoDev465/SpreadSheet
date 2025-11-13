using System.ComponentModel.DataAnnotations;

namespace Core.Contract;

public class ProfileContract
{
    public int Id { get; set; }
    [Required]
    [EmailAddress]
    [EmailValidation]
    public string Email { get; set; }
    
    public class EmailValidation :ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string email = value as string;

            if (string.IsNullOrWhiteSpace(email))
            {
                return new ValidationResult("O campo Email não pod eser Nulo");
            }

            if (!email.EndsWith("@gmail.com"))
            {
                return new ValidationResult("O campo precisa pertencer ao dominio '@gmail.com'");
            }
            
            return ValidationResult.Success;
        }
    }
    
}


  