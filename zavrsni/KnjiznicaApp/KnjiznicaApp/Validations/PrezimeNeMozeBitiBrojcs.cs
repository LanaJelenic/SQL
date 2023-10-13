using System.ComponentModel.DataAnnotations;

namespace KnjiznicaApp.Validations
{
    public class PrezimeNeMozeBitiBrojcs:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
			try
			{
				var broj = decimal.Parse((string)value);
				return new ValidationResult("Prezime ne moze biti broj");
			}
			catch (Exception e)
			{

				
			}
			return ValidationResult.Success;
        }
    }
}
