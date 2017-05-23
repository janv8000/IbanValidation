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

        [TestCase("Albania", "AL47212110090000000235698741")]
        [TestCase("Algeria", "DZ4000400174401001050486")]
        [TestCase("Andorra", "AD1200012030200359100100")]
        [TestCase("Angola", "AO06000600000100037131174")]
        [TestCase("Austria SEPA", "AT611904300234573201")]
        [TestCase("Azerbaijan", "AZ21NABZ00000000137010001944")]
        [TestCase("Bahrain", "BH29BMAG1299123456BH00")]
        [TestCase("Belarus", "BY86AKBB10100000002966000000")]
        [TestCase("Belgium SEPA", "BE68539007547034")]
        [TestCase("Benin", "BJ11B00610100400271101192591")]
        [TestCase("Bosnia and Herzegovina", "BA391290079401028494")]
        [TestCase("Brazil", "BR9700360305000010009795493P1")]
        [TestCase("Bulgaria SEPA", "BG80BNBG96611020345678")]
        [TestCase("Burkina Faso", "BF1030134020015400945000643")]
        [TestCase("Burundi", "BI43201011067444")]
        [TestCase("Cameroon", "CM2110003001000500000605306")]
        [TestCase("Cape Verde", "CV64000300004547069110176")]
        [TestCase("Costa Rica", "CR05015202001026284066")]
        [TestCase("Croatia SEPA", "HR1210010051863000160")]
        [TestCase("Cyprus SEPA", "CY17002001280000001200527600")]
        [TestCase("Czech Republic SEPA", "CZ6508000000192000145399")]
        [TestCase("Denmark SEPA", "DK5000400440116243")]
        [TestCase("Dominican Republic", "DO28BAGR00000001212453611324")]
        [TestCase("El Salvador", "SV43ACAT00000000000000123123")]
        [TestCase("East Timor", "TL380080012345678910157")]
        [TestCase("Estonia SEPA", "EE382200221020145685")]
        [TestCase("Faroe Islands", "FO1464600009692713")]
        [TestCase("Finland SEPA", "FI2112345600000785")]
        [TestCase("France SEPA", "FR1420041010050500013M02606")]
        [TestCase("Georgia", "GE29NB0000000101904917")]
        [TestCase("Germany SEPA", "DE89370400440532013000")]
        [TestCase("Gibraltar SEPA", "GI75NWBK000000007099453")]
        [TestCase("Greece SEPA", "GR1601101250000000012300695")]
        [TestCase("Greenland", "GL8964710001000206")]
        [TestCase("Guatemala", "GT82TRAJ01020000001210029690")]
        [TestCase("Hungary SEPA", "HU42117730161111101800000000")]
        [TestCase("Iceland SEPA", "IS140159260076545510730339")]
        [TestCase("Iran", "IR580540105180021273113007")]
        [TestCase("Iraq", "IQ20CBIQ861800101010500")]
        [TestCase("Ireland SEPA", "IE29AIBK93115212345678")]
        [TestCase("Israel", "IL620108000000099999999")]
        [TestCase("Italy SEPA", "IT60X0542811101000000123456")]
        [TestCase("Ivory Coast", "CI05A00060174100178530011852")]
        [TestCase("Jordan", "JO94CBJO0010000000000131000302")]
        [TestCase("Kazakhstan", "KZ176010251000042993")]
        [TestCase("Kuwait", "KW74NBOK0000000000001000372151")]
        [TestCase("Latvia SEPA", "LV80BANK0000435195001")]
        [TestCase("Lebanon", "LB30099900000001001925579115")]
        [TestCase("Liechtenstein SEPA", "LI21088100002324013AA")]
        [TestCase("Lithuania SEPA", "LT121000011101001000")]
        [TestCase("Luxembourg SEPA", "LU280019400644750000")]
        [TestCase("Macedonia", "MK07300000000042425")]
        [TestCase("Madagascar", "MG4600005030010101914016056")]
        [TestCase("Mali", "ML03D00890170001002120000447")]
        [TestCase("Malta SEPA", "MT84MALT011000012345MTLCAST001S")]
        [TestCase("Mauritania", "MR1300012000010000002037372")]
        [TestCase("Mauritius", "MU17BOMM0101101030300200000MUR")]
        [TestCase("Moldova", "MD24AG000225100013104168")]
        [TestCase("Monaco SEPA", "MC5813488000010051108001292")]
        [TestCase("Montenegro", "ME25505000012345678951")]
        [TestCase("Mozambique", "MZ59000100000011834194157")]
        [TestCase("Netherlands SEPA", "NL91ABNA0417164300")]
        [TestCase("Norway SEPA", "NO9386011117947")]
        [TestCase("Pakistan", "PK24SCBL0000001171495101")]
        [TestCase("Palestine", "PS92PALS000000000400123456702")]
        [TestCase("Poland SEPA", "PL27114020040000300201355387")]
        [TestCase("Portugal SEPA", "PT50000201231234567890154")]
        [TestCase("Qatar", "QA58DOHB00001234567890ABCDEFG")]
        [TestCase("Republic of Kosovo", "XK051212012345678906")]
        [TestCase("Romania SEPA", "RO49AAAA1B31007593840000")]
        [TestCase("Saint Lucia", "LC14BOSL123456789012345678901234")]
        [TestCase("San Marino SEPA", "SM86U0322509800000000270100")]
        [TestCase("Sao Tome and Principe", "ST23000200000289355710148")]
        [TestCase("Saudi Arabia", "SA0380000000608010167519")]
        [TestCase("Senegal", "SN12K00100152000025690007542")]
        [TestCase("Serbia", "RS35260005601001611379")]
        [TestCase("Seychelles", "SC52BAHL01031234567890123456USD")]
        [TestCase("Slovakia SEPA", "SK3112000000198742637541")]
        [TestCase("Slovenia SEPA", "SI56191000000123438")]
        [TestCase("Spain SEPA", "ES9121000418450200051332")]
        [TestCase("Sweden SEPA", "SE3550000000054910000003")]
        [TestCase("Switzerland SEPA", "CH9300762011623852957")]
        [TestCase("Timor-Leste", "TL380080012345678910157")]
        [TestCase("Tunisia", "TN5914207207100707129648")]
        [TestCase("Turkey", "TR330006100519786457841326")]
        [TestCase("Ukraine", "UA903052992990004149123456789")]
        [TestCase("United Arab Emirates", "AE260211000000230064016")]
        [TestCase("United Kingdom SEPA", "GB29NWBK60161331926819")]
        [TestCase("Virgin Islands, British", "VG96VPVG0000012345678901")]
        public void Iban_Should_Be_Valid_With_Spaces(string country, string iban)
        {
            // Assert
            var validator = new IbanValidator();

            // Act
            var result = validator.Validate(iban);

            // Assert
            Assert.That(IbanValidationResult.IsValid, Is.EqualTo(result));
        }
    }
}
