using System.ComponentModel.DataAnnotations;

namespace ModelBinding_Validations_MVC_WebAPI_.CustomValidators
{
    public class MinimumYearValidatorAttribute: ValidationAttribute
    {
        public MinimumYearValidatorAttribute() { }

        public MinimumYearValidatorAttribute(int minimumYear)
        {
            _minimumYear = minimumYear;
        }

        private int _minimumYear;

        public string DefaultErrorMessage { get; set; } = "Year should not be less than {0}";
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;

                if (date.Year < _minimumYear)
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, _minimumYear));
                } else
                {
                    return ValidationResult.Success;
                }
            } else
            {
                return null;
            }
        }   
    }
}
