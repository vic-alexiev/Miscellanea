using System.Collections.Generic;
using OldMacDonald.Song.Farm;

namespace OldMacDonald.Song
{
    public interface ISongWriter
    {
        string Compose(IEnumerable<Animal> animals);
    }
}
