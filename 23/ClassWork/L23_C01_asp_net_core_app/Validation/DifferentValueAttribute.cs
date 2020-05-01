using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace L23_C01_asp_net_core_app.Validation
{
    public class DifferentValueAttribute : ValidationAttribute
    {
        public string OtherProperty { get; }

        public DifferentValueAttribute(string otherProperty)
        {
            if (otherProperty == null)
            {
                throw new ArgumentNullException("otherProperty");
            }
            OtherProperty = otherProperty;
        }

        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            PropertyInfo otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);
            if(otherPropertyInfo == null)
            {
                return new ValidationResult($"Cannot find the property with name \"{otherPropertyInfo}\"");
            }
            object otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);

            if(value.Equals(otherPropertyValue))
            {
                return new ValidationResult($"{validationContext.MemberName} shouldn't be the same as {otherPropertyInfo}");
            }

            return ValidationResult.Success;
        }
    }
}
