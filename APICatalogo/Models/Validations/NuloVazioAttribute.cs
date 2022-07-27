using System.ComponentModel.DataAnnotations;

namespace APICatalogo.Models.Validations
{
    public class NuloVazioAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return new ValidationResult("Esse campo precisa ser preenchido");

            return ValidationResult.Success;
        }
    }
}
