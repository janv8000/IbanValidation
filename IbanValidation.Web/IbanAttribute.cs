using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace IbanValidation.Web
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class IbanAttribute : ValidationAttribute, IClientValidatable
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            var valueAsAString = value as string;
            if (valueAsAString == null)
            {
                return true;
            }

            var validator = new IbanValidator();

            var ibanWithoutWhitespace = Regex.Replace(valueAsAString, @"\s+", "");

            var ibanValidationResult = validator.Validate(ibanWithoutWhitespace);

            if (ibanValidationResult == IbanValidationResult.IsValid)
            {
                return true;
            }

            return false;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRule { ErrorMessage = FormatErrorMessage(metadata.DisplayName), ValidationType = "ibancheck" };
        }
    }
}