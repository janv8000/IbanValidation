using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace IbanValidation.Web
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class IbanAttribute : ValidationAttribute, IClientModelValidator
    {
        public override bool IsValid(object value)
        {
            if (!(value is string valueAsAString))
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

        public void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            var errorMessage = FormatErrorMessage(context.ModelMetadata.GetDisplayName());
            MergeAttribute(context.Attributes, "data-val-ibancheck", errorMessage);
        }

        private bool MergeAttribute(
            IDictionary<string, string> attributes,
            string key,
            string value)
        {
            if (attributes.ContainsKey(key))
            {
                return false;
            }
            attributes.Add(key, value);
            return true;
        }
    }
}