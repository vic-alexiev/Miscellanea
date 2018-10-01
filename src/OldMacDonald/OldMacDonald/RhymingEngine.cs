using OldMacDonald.Song;

namespace OldMacDonald
{
    internal class RhymingEngine
    {
        private static void Main(string[] args)
        {
            IIOManager ioManager = new ConsoleManager();
            ISongWriter songWriter = new SongWriter();
            IRhymeGenerator rhymeGenerator = new RhymeGenerator(ioManager, songWriter);
            rhymeGenerator.Run();
        }
    }
}
