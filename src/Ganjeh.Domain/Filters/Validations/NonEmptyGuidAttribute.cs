using System;
using System.ComponentModel.DataAnnotations;

namespace Ganjeh.Domain.Filters.Validations
{
    public class NonEmptyGuidAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propretyInfo = validationContext.ObjectType.GetProperty(validationContext.MemberName);
            if (value is not Guid)
            {
                return new ValidationResult($"The {propretyInfo.Name} field format is invalid.");
            }
            if (Guid.Empty == (Guid)value)
            {
                return new ValidationResult($"The {propretyInfo.Name} field is required.");
            }
            return null;
        }
    }
}