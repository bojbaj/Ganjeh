using System;
using System.ComponentModel.DataAnnotations;

namespace Ganjeh.Api.Filters.Validations
{
    public class NonEmptyGuidAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((value is Guid) && Guid.Empty == (Guid)value)
            {
                var propretyInfo = validationContext.ObjectType.GetProperty(validationContext.MemberName);
                return new ValidationResult($"The {propretyInfo.Name} field is required.");
            }
            return null;
        }
    }
}