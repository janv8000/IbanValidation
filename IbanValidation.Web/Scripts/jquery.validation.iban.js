$.validator.addMethod("ibancheck", function (value, element) {
    if (this.optional(element)) {
        return "dependency-mismatch";
    }

    return IBAN.isValid(value);
});

$.validator.unobtrusive.adapters.addBool("ibancheck");
