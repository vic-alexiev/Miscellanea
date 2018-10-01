namespace OldMacDonald.Farm
{
    public class Lamb : Animal
    {
        public Lamb()
            : base(typeof(Lamb).Name.ToLower(), "baa")
        {
        }
    }
}
