using System.ComponentModel.DataAnnotations;
namespace KnjiznicaApp.Validations
{
    public class ImeNeMozeBitiBroj:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
			try
			{
				var broj = decimal.Parse((string)value);
				return new ValidationResult("Ime ne moze biti broj");
			}
			catch (Exception ex)
			{

				
			}
			return ValidationResult.Success;
        }
    }
}
