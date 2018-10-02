using System.Collections.Generic;
using OldMacDonald.Song.Farm;

namespace OldMacDonald.Tests
{
    public class AnimalEqualityComparer : IEqualityComparer<Animal>
    {
        public bool Equals(Animal x, Animal y)
        {
            if (x == null)
            {
                return y == null;
            }
            return x.Name == y.Name;
        }

        public int GetHashCode(Animal obj)
        {
            if (obj == null)
            {
                return 0;
            }
            return obj.Name.GetHashCode();
        }
    }
}
