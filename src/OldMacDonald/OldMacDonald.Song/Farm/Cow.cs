namespace OldMacDonald.Song.Farm
{
    public class Cow : Animal
    {
        public Cow()
            : base(typeof(Cow).Name.ToLower(), "moo")
        {
        }
    }
}
