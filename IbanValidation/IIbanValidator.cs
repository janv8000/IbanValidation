namespace IbanValidation
{
    public interface IIbanValidator
    {
        IbanValidationResult Validate(string value);
    }
}