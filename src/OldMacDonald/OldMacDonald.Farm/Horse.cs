namespace OldMacDonald.Farm
{
    public class Horse : Animal
    {
        public Horse()
            : base(typeof(Horse).Name.ToLower(), "neigh")
        {
        }
    }
}
