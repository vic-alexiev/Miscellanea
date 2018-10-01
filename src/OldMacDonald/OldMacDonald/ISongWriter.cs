using OldMacDonald.Farm;
using System.Collections.Generic;

namespace OldMacDonald
{
    public interface ISongWriter
    {
        string Compose(IEnumerable<Animal> animals);
    }
}
