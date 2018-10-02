namespace OldMacDonald.Song.Farm
{
    public class Animal
    {
        public Animal(string name, string sound)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new SongException($"Animal {nameof(name)} must be specified.");
            }

            if (string.IsNullOrWhiteSpace(sound))
            {
                throw new SongException($"Animal {nameof(sound)} must be specified.");
            }

            Name = name;
            Sound = sound;
        }

        public string Name { get; }

        public string Sound { get; }
    }
}
