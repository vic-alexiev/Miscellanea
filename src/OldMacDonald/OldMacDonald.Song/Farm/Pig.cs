namespace OldMacDonald.Song.Farm
{
    public class Pig : Animal
    {
        public Pig()
            : base(typeof(Pig).Name.ToLower(), "oink")
        {
        }
    }
}
