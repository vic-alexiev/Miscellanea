using System.Collections.Generic;
using OldMacDonald.Song.Farm;

namespace OldMacDonald.Tests
{
    public class AnimalEqualityComparer : IEqualityComparer<Animal>
    {
        public bool Equals(Animal x, Animal y)
        {
            if (x == null && y == null)
            {
                return true;
            }
            else if (x != null && y != null)
            {
                return x.Name == y.Name;
            }
            else
            {
                return false;
            }
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
