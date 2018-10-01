namespace OldMacDonald.Farm
{
    public class Duck : Animal
    {
        public Duck()
            : base(typeof(Duck).Name.ToLower(), "quack")
        {
        }
    }
}
