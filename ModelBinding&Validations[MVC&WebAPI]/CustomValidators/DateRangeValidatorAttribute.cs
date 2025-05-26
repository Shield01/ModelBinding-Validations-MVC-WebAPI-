using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelBinding_Validations_MVC_WebAPI_.CustomValidators
{
    public class DateRangeValidatorAttribute: ValidationAttribute
    {
        public DateRangeValidatorAttribute() { }

        public DateRangeValidatorAttribute(string otherPropertyname)
        {
            _otherPropertyName = otherPropertyname;
        }

        private string? _otherPropertyName;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null)
            {
                DateTime todate = Convert.ToDateTime(value);

                PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(_otherPropertyName);

                if (otherProperty != null)
                {
                    DateTime fromDate = Convert.ToDateTime(otherProperty.GetValue(validationContext.ObjectInstance));

                    if (fromDate > todate)
                    {
                        return new ValidationResult(ErrorMessage, new string[] { _otherPropertyName, validationContext.MemberName });
                    }
                    else
                    {
                        return ValidationResult.Success;
                    }
                }
                else
                {
                    return null;
                }     
            } else
            {
                return null;
            }
        }
    }
}
