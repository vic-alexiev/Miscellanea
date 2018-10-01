using OldMacDonald.Song.Farm;
using System.Collections.Generic;

namespace OldMacDonald.Song
{
    public interface ISongWriter
    {
        string Compose(IEnumerable<Animal> animals);
    }
}
