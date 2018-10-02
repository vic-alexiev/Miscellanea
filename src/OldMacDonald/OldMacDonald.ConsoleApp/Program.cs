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
                .AddSingleton<IValidatorSettings, ValidatorSettings>()
                .AddSingleton<IValidator>(provider =>
                {
                    var settings = provider.GetService<IValidatorSettings>();
                    return new Validator(settings);
                })
                .AddSingleton<IRhymeGenerator>(provider =>
                {
                    var ioService = provider.GetService<IIOService>();
                    var validator = provider.GetService<IValidator>();
                    var songWriter = provider.GetService<ISongWriter>();

                    return new RhymeGenerator(ioService, validator, songWriter);
                })
                .BuildServiceProvider();

            IRhymeGenerator rhymeGenerator = serviceProvider.GetService<IRhymeGenerator>();
            rhymeGenerator.Run();
        }
    }
}
