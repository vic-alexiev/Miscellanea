using OldMacDonald.Song;
using Xunit;

namespace OldMacDonald.Tests
{
    public class ValidatorTests
    {
        private IValidatorSettings _settings;
        private IValidator _validator;

        public ValidatorTests()
        {
            _settings = new ValidatorSettings();
            _validator = new Validator(_settings);
        }

        [Fact]
        public void Validator_Create_ValidatorExposesSettingsProperties()
        {
            Assert.Equal(_settings.VersesMaxCount, _validator.VersesMaxCount);
            Assert.Equal(_settings.AnimalNameMaxLength, _validator.AnimalNameMaxLength);
            Assert.Equal(_settings.AnimalSoundMaxLength, _validator.AnimalSoundMaxLength);
        }

        [Theory]
        [InlineData("1")]
        [InlineData("7")]
        [InlineData("10")]
        public void Validator_ValidateVersesCount_ValidationSuccessful(string value)
        {
            Assert.True(_validator.ValidateVersesCount(value));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("seven")]
        [InlineData("-5")]
        [InlineData("0")]
        [InlineData("11")]
        [InlineData("100")]
        public void Validator_ValidateVersesCount_ValidationFails(string value)
        {
            Assert.False(_validator.ValidateVersesCount(value));
        }

        [Theory]
        [InlineData("x")]
        [InlineData("m-m")]
        [InlineData("TesT")]
        [InlineData("cooow")]
        [InlineData("tiggeerrr")]
        [InlineData("asfa-asdf-erwter-xcbcvxb-rer")]
        [InlineData("kTn")]
        [InlineData("bow-woow-wooooooooooooooooooow")]
        [InlineData("o-o-o-o-o-o-o-o-o-o-o-o-o-o-o")]
        public void Validator_ValidateAnimalName_ValidationSuccessful(string value)
        {
            Assert.True(_validator.ValidateAnimalName(value));
        }

        [Theory]
        [InlineData("-x")]
        [InlineData("m-m-")]
        [InlineData("TesT1")]
        [InlineData("co--oow")]
        [InlineData("tiggeerrr--")]
        [InlineData("asfa-asdf-erwter-xcbcvxb-rer-teryet")]
        [InlineData("kT'n")]
        [InlineData("bow-woow-w0000w")]
        [InlineData("#%&*(^()@%#^&")]
        public void Validator_ValidateAnimalName_ValidationFails(string value)
        {
            Assert.False(_validator.ValidateAnimalName(value));
        }

        [Theory]
        [InlineData("x")]
        [InlineData("m-m")]
        [InlineData("TesT")]
        [InlineData("mOOOOoOo")]
        [InlineData("roarrr")]
        [InlineData("cock-a-doodle-doo")]
        [InlineData("miaou-miaou-miaou")]
        [InlineData("bow-woow-wooooooooooooooooooow")]
        [InlineData("o-o-o-o-o-o-o-o-o-o-o-o-o-o-o")]
        public void Validator_ValidateAnimalSound_ValidationSuccessful(string value)
        {
            Assert.True(_validator.ValidateAnimalSound(value));
        }

        [Theory]
        [InlineData("-x")]
        [InlineData("m-m-")]
        [InlineData("TesT1")]
        [InlineData("0mOOOOoOo")]
        [InlineData("roarrr--")]
        [InlineData("--cock-a-doodle-doo")]
        [InlineData("miaou-miaou-miaou-miaou-miaou-miaou")]
        [InlineData("bow-woow-woooooooooooooooooooow")]
        [InlineData(")#%*(&#%&#$*^(")]
        public void Validator_ValidateAnimalSound_ValidationFails(string value)
        {
            Assert.False(_validator.ValidateAnimalSound(value));
        }
    }
}
