using Microsoft.Extensions.DependencyInjection;
using OldMacDonald.Song;

namespace OldMacDonald.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IIOService, ConsoleService>()
                .AddSingleton<ISongWriter, SongWriter>()
                .AddSingleton<IRhymeGenerator>(provider =>
                {
                    var ioService = provider.GetService<IIOService>();
                    var songWriter = provider.GetService<ISongWriter>();
                    return new RhymeGenerator(ioService, songWriter);
                })
                .BuildServiceProvider();

            IRhymeGenerator rhymeGenerator = serviceProvider.GetService<IRhymeGenerator>();
            rhymeGenerator.Run();
        }
    }
}
