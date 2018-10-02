using System;
using OldMacDonald.Song;
using OldMacDonald.Song.Farm;

namespace OldMacDonald.ConsoleApp
{
    public class RhymeGenerator : IRhymeGenerator
    {
        private IIOService _ioService;
        private ISongWriter _songWriter;
        private IValidator _validator;

        public RhymeGenerator(
            IIOService ioService,
            ISongWriter songWriter,
            IValidator validator)
        {
            _ioService = ioService;
            _songWriter = songWriter;
            _validator = validator;
        }

        public void Run()
        {
            _ioService.WriteLine(
                "\t\tOLD MACDONALD HAD A FARM{0}{0}" +
                "Commands:{0}" +
                " - To see the nursery rhyme lyrics, type \"old\".{0}" +
                " - To write new verses with animals of your choosing, type \"new\".{0}" +
                " - To exit the program, type \"exit\".{0}",
                Environment.NewLine);
            try
            {
                while (true)
                {
                    _ioService.Write("Command: ");
                    string command = _ioService.ReadLine();

                    switch (command)
                    {
                        case Commands.Old:
                            {
                                _ioService.WriteLine(GetOldSongLyrics());
                                break;
                            }
                        case Commands.New:
                            {
                                _ioService.WriteLine(MakeNewVerses());
                                break;
                            }
                        case Commands.Exit:
                            {
                                return;
                            }
                        default:
                            break;
                    }
                }
            }
            catch (SongException se)
            {
                _ioService.WriteLine($"Rhyme generation failure: {se.Message}");
            }
            catch (Exception e)
            {
                _ioService.WriteLine(e.Message);
            }
        }

        private string GetOldSongLyrics()
        {
            Animal[] animals = new Animal[]
            {
                new Cow(),
                new Pig(),
                new Duck(),
                new Horse(),
                new Lamb()
            };

            return _songWriter.Compose(animals);
        }

        private string MakeNewVerses()
        {
            string inputCount;
            do
            {
                _ioService.Write($"Count (max value: {_validator.VersesMaxCount}): ");
                inputCount = _ioService.ReadLine();
            } while (!_validator.ValidateVersesCount(inputCount));

            string name;
            string sound;
            int count = int.Parse(inputCount);
            Animal[] animals = new Animal[count];

            for (int i = 0; i < count; i++)
            {
                do
                {
                    _ioService.Write($"Animal {i + 1} (max length: {_validator.AnimalNameMaxLength}): ");
                    name = _ioService.ReadLine();
                } while (!_validator.ValidateAnimalName(name));

                do
                {
                    _ioService.Write($"Animal {i + 1} sound (max length: {_validator.AnimalSoundMaxLength}): ");
                    sound = _ioService.ReadLine();
                } while (!_validator.ValidateAnimalSound(sound));

                animals[i] = new Animal(name, sound);
            }

            return _songWriter.Compose(animals);
        }
    }
}
