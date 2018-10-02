namespace OldMacDonald.Song
{
    public interface IValidatorSettings
    {
        int VersesMaxCount { get; }

        int AnimalNameMaxLength { get; }

        string AnimalNamePattern { get; }

        int AnimalSoundMaxLength { get; }

        string AnimalSoundPattern { get; }
    }
}
