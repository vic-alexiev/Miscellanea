﻿using System;
using System.Text.RegularExpressions;
using OldMacDonald.Song;
using OldMacDonald.Song.Farm;

namespace OldMacDonald.ConsoleApp
{
    public class RhymeGenerator : IRhymeGenerator
    {
        private IIOService _ioService;
        private ISongWriter _songWriter;

        public RhymeGenerator(IIOService ioService, ISongWriter songWriter)
        {
            _ioService = ioService;
            _songWriter = songWriter;
        }

        public void Run()
        {
            _ioService.WriteLine(
                "\t\tOLD MACDONALD HAD A FARM{0}{0}" +
                "Commands:{0}" +
                " - To see the nursery rhyme lyrics, type \"old\".{0}" +
                " - To write new verses with animals of your choice, type \"new\".{0}" +
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
                        case "old":
                            {
                                _ioService.WriteLine(GetOldSongLyrics());
                                break;
                            }
                        case "new":
                            {
                                _ioService.WriteLine(MakeNewVerses(6, 30));
                                break;
                            }
                        case "exit":
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

        private string MakeNewVerses(int maxCount, int inputMaxLength)
        {
            bool versesCountValid;
            int versesCount;
            do
            {
                _ioService.Write($"Count (max value: {maxCount}): ");
                string count = _ioService.ReadLine();
                versesCountValid = int.TryParse(count, out versesCount);
            } while (!versesCountValid || versesCount <= 0 || versesCount > maxCount);

            bool animalNameValid;
            bool animalSoundValid;
            string animalName;
            string animalSound;
            string limitations = $"max length: {inputMaxLength}, allowed chars: English letters, hyphen";
            string pattern = @"^([a-zA-Z]+-)*[a-zA-Z]+$";

            Animal[] animals = new Animal[versesCount];

            for (int i = 0; i < versesCount; i++)
            {
                do
                {
                    _ioService.Write($"Animal {i + 1} ({limitations}): ");
                    animalName = _ioService.ReadLine();
                    animalNameValid = Regex.IsMatch(animalName, pattern);
                } while (!animalNameValid || animalName.Length > inputMaxLength);

                do
                {
                    _ioService.Write($"Animal {i + 1} sound ({limitations}): ");
                    animalSound = _ioService.ReadLine();
                    animalSoundValid = Regex.IsMatch(animalSound, pattern);
                } while (!animalSoundValid || animalSound.Length > inputMaxLength);

                animals[i] = new Animal(animalName, animalSound);
            }

            return _songWriter.Compose(animals);
        }
    }
}
