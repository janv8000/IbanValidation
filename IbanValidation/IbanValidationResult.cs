namespace IbanValidation
{
    public enum IbanValidationResult
    {
        IsValid,
        ValueMissing,
        ValueTooSmall,
        ValueTooBig,
        ValueFailsModule97Check,
        CountryCodeNotKnown
    }
}