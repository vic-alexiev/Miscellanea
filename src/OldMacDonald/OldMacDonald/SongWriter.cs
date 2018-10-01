using System;
using System.Collections.Generic;
using System.Text;
using OldMacDonald.Farm;

namespace OldMacDonald
{
    public class SongWriter : ISongWriter
    {
        public string Compose(IEnumerable<Animal> animals)
        {
            StringBuilder songBuilder = new StringBuilder();
            string verse =
                "{0}Old MacDonald had a farm, E - I - E - I - O,{0}" +
                "And on his farm he had {1}, E - I - E - I - O.{0}" +
                "With {2} {3} here and {2} {3} there,{0}" +
                "Here {2}, there {2}, ev'rywhere {2} {3}.{0}" +
                "Old MacDonald had a farm, E - I - E - I - O.{0}";

            foreach (Animal animal in animals)
            {
                songBuilder.AppendFormat(
                    verse,
                    Environment.NewLine,
                    PrependArticle(animal.Name),
                    PrependArticle(animal.Sound),
                    animal.Sound);
            }

            return songBuilder.ToString();
        }

        private bool StartsWithVowel(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }
            return "aeioAEIO".Contains(value[0]);
        }

        private string PrependArticle(string noun)
        {
            if (StartsWithVowel(noun))
            {
                return $"an {noun}";
            }
            return $"a {noun}";
        }
    }
}
