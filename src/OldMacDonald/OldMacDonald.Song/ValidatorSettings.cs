using System;
using System.Collections.Generic;
using System.Text;

namespace OldMacDonald.Song
{
    public class ValidatorSettings : IValidatorSettings
    {
        public int VersesMaxCount => 10;

        public int AnimalNameMaxLength => 30;

        public string AnimalNamePattern => @"^([a-zA-Z]+-)*[a-zA-Z]+$";

        public int AnimalSoundMaxLength => 30;

        public string AnimalSoundPattern => @"^([a-zA-Z]+-)*[a-zA-Z]+$";
    }
}
