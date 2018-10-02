using System;
using System.Collections.Generic;
using System.Text;

namespace OldMacDonald.Song
{
    public interface IValidator
    {
        int VersesMaxCount { get; }

        int AnimalNameMaxLength { get; }

        int AnimalSoundMaxLength { get; }

        bool ValidateVersesCount(string value);

        bool ValidateAnimalName(string value);

        bool ValidateAnimalSound(string value);
    }
}
