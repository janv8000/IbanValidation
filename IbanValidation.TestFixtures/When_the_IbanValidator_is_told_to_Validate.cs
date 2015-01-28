using NUnit.Framework;

namespace IbanValidation.TestFixtures
{
    public class When_the_IbanValidator_is_told_to_Validate
    {
        [Test]
        public void It_should_return_an_error_when_there_is_no_value_provided()
        {
            // Assert
            const string value = null;
            var validator = new IbanValidator();

            // Act
            var result = validator.Validate(value);

            // Assert
            Assert.That(IbanValidationResult.ValueMissing, Is.EqualTo(result));
        }

        [Test]
        public void It_should_return_an_error_when_there_is_only_whitespace()
        {
            // Assert
            const string value = "   ";
            var validator = new IbanValidator();

            // Act
            var result = validator.Validate(value);

            // Assert
            Assert.That(IbanValidationResult.ValueMissing, Is.EqualTo(result));
        }

        [Test]
        public void It_should_return_an_error_when_the_value_length_is_to_short()
        {
            // Assert
            const string value = "BE1800165492356";
            var validator = new IbanValidator();

            // Act
            var result = validator.Validate(value);

            // Assert
            Assert.That(IbanValidationResult.ValueTooSmall, Is.EqualTo(result));
        }

        [Test]
        public void It_should_return_an_error_when_the_value_length_is_to_big()
        {
            // Assert
            const string value = "BE180016549235656";
            var validator = new IbanValidator();

            // Act
            var result = validator.Validate(value);

            // Assert
            Assert.That(IbanValidationResult.ValueTooBig, Is.EqualTo(result));
        }

        [Test]
        public void It_should_return_an_error_when_the_value_fails_the_module_check()
        {
            // Assert
            const string value = "BE18001654923566";
            var validator = new IbanValidator();

            // Act
            var result = validator.Validate(value);

            // Assert
            Assert.That(IbanValidationResult.ValueFailsModule97Check, Is.EqualTo(result));
        }

        [Test]
        public void It_should_return_an_error_when_an_unkown_country_prefix_used()
        {
            // Assert
            const string value = "XX82WEST12345698765432";
            var validator = new IbanValidator();

            // Act
            var result = validator.Validate(value);

            // Assert
            Assert.That(IbanValidationResult.CountryCodeNotKnown, Is.EqualTo(result));
        }

        [Test]
        public void It_should_return_valid_when_a_valid_value_is_provided()
        {
            // Assert
            const string value = "BE18001654923565";
            var validator = new IbanValidator();

            // Act
            var result = validator.Validate(value);

            // Assert
            Assert.That(IbanValidationResult.IsValid, Is.EqualTo(result));
        }

        [Test]
        public void It_should_return_valid_when_a_valid_foreign_value_is_provided()
        {
            // Assert
            const string value = "GB82WEST12345698765432";
            var validator = new IbanValidator();

            // Act
            var result = validator.Validate(value);

            // Assert
            Assert.That(IbanValidationResult.IsValid, Is.EqualTo(result));
        }
    }
}
