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
        public void Validator_Create_ValidatorExposesSettings()
        {
            Assert.Equal(_settings.VersesMaxCount, _validator.VersesMaxCount);
            Assert.Equal(_settings.AnimalNameMaxLength, _validator.AnimalNameMaxLength);
            Assert.Equal(_settings.AnimalSoundMaxLength, _validator.AnimalSoundMaxLength);
        }
    }
}
