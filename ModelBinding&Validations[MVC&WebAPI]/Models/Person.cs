using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ModelBinding_Validations_MVC_WebAPI_.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace ModelBinding_Validations_MVC_WebAPI_.Models
{
    //This class demonstrates Model validation
    public class Person: IValidatableObject
    {
        [Required(ErrorMessage ="{0} is not provided")]
        [Display(Name = "Person name")]
        [StringLength(40,MinimumLength = 3, ErrorMessage ="{0} should be between {2} and {1} characters long")]
        [RegularExpression("^[A-Za-z .]*$", ErrorMessage = "{0} should contain only alphabet space, and dot")]
        public string? PersonName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "{0} should be a proper email address")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "{0} should be a valid phone number")]
        [ValidateNever]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "{0} must be provided")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "{0} must be provided")]
        [Compare("Password", ErrorMessage = "{0} and {1} must match")]
        [Display(Name = "Re-entered password")]
        public string? ConfirmPassword { get; set; }

        [Range(0, 999.99, ErrorMessage = "{0} should be between ${1} and ${2}")]
        public double? Price { get; set; }

        //Demonstrating the use of BindNever
        [BindNever]
        public int? Age { get; set; }


        // Demonstrating the use of Custom validation class
        [MinimumYearValidator(2005, ErrorMessage = "Date of birth should not be earlier than January 1st {0}")]
        public DateTime? DateOfBirth { get; set; }

        public DateTime FromDate { get; set; }

        [DateRangeValidator("FromDate", ErrorMessage = "From date should be older or equal to to date")]
        public DateTime ToDate { get; set; }

        public List<string>? Tags { get; set; } = new List<string>();

        public override string ToString()
        {
            return $"Person object - " +
                $"Person name: {PersonName}, " +
                $"Email: {Email}, " +
                $"Phone: {Phone}, " +
                $"Password: {Password}," +
                $" Confirm Password {ConfirmPassword}, " +
                $"Price: {Price}";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateOfBirth.HasValue == false && Age.HasValue == false)
            {
                yield return new ValidationResult("Either of Date of birth or Age must be supplied", new[] { nameof(Age) });
            }
        }
    }
}
