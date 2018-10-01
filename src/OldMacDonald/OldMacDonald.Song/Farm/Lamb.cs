namespace OldMacDonald.Song.Farm
{
    public class Lamb : Animal
    {
        public Lamb()
            : base(typeof(Lamb).Name.ToLower(), "baa")
        {
        }
    }
}
