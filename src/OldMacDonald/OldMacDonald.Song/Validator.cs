using System.Text.RegularExpressions;

namespace OldMacDonald.Song
{
    public class Validator : IValidator
    {
        private IValidatorSettings _settings;

        public Validator(IValidatorSettings settings)
        {
            _settings = settings;
        }

        public int VersesMaxCount => _settings.VersesMaxCount;

        public int AnimalNameMaxLength => _settings.AnimalNameMaxLength;

        public int AnimalSoundMaxLength => _settings.AnimalSoundMaxLength;

        public bool ValidateVersesCount(string value)
        {
            bool validInt = int.TryParse(value, out int count);
            if (validInt)
            {
                return count > 0 && count <= _settings.VersesMaxCount;
            }
            return false;
        }

        public bool ValidateAnimalName(string value)
        {
            bool isMatch = Regex.IsMatch(value, _settings.AnimalNamePattern);
            if (isMatch)
            {
                return value.Length <= _settings.AnimalNameMaxLength;
            }
            return false;
        }

        public bool ValidateAnimalSound(string value)
        {
            bool isMatch = Regex.IsMatch(value, _settings.AnimalSoundPattern);
            if (isMatch)
            {
                return value.Length <= _settings.AnimalSoundMaxLength;
            }
            return false;
        }
    }
}
