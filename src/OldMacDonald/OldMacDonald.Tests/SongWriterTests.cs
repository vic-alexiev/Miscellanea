using System.Collections.Generic;
using Xunit;
using OldMacDonald.Song;
using OldMacDonald.Song.Farm;

namespace OldMacDonald.Tests
{
    public class SongWriterTests
    {
        [Fact]
        public void Compose_AnimalsNull_EmptyStringIsReturned()
        {
            ISongWriter songWriter = new SongWriter();

            string lyrics = songWriter.Compose(null);

            Assert.Equal(string.Empty, lyrics);
        }

        [Fact]
        public void Compose_AnimalsEmpty_EmptyStringIsReturned()
        {
            ISongWriter songWriter = new SongWriter();

            string lyrics = songWriter.Compose(new List<Animal>());

            Assert.Equal(string.Empty, lyrics);
        }

        [Fact]
        public void Compose_AnimalsContainsNull_ThrowsException()
        {
            ISongWriter songWriter = new SongWriter();

            var ex = Assert.Throws<SongException>(() => songWriter.Compose(new Animal[]
            {
                new Cow(),
                null,
                new Duck()
            }));

            Assert.Equal("Uninitialized animal object found.", ex.Message);
        }

        [Fact]
        public void Compose_2Animals_2ValidVersesAreReturned()
        {
            ISongWriter songWriter = new SongWriter();

            string lyrics = songWriter.Compose(new Animal[]
            {
                new Horse(),
                new Pig()
            });

            string expectedLyrics = @"
Old MacDonald had a farm, E - I - E - I - O,
And on his farm he had a horse, E - I - E - I - O.
With a neigh neigh here and a neigh neigh there,
Here a neigh, there a neigh, ev'rywhere a neigh neigh.
Old MacDonald had a farm, E - I - E - I - O.

Old MacDonald had a farm, E - I - E - I - O,
And on his farm he had a pig, E - I - E - I - O.
With an oink oink here and an oink oink there,
Here an oink, there an oink, ev'rywhere an oink oink.
Old MacDonald had a farm, E - I - E - I - O.
";
            Assert.Equal(expectedLyrics, lyrics);
        }

        [Fact]
        public void Compose_3Animals_3ValidVersesAreReturned()
        {
            ISongWriter songWriter = new SongWriter();

            string lyrics = songWriter.Compose(new Animal[]
            {
                new Lamb(),
                new Animal("donkey", "bray"),
                new Pig()
            });

            string expectedLyrics = @"
Old MacDonald had a farm, E - I - E - I - O,
And on his farm he had a lamb, E - I - E - I - O.
With a baa baa here and a baa baa there,
Here a baa, there a baa, ev'rywhere a baa baa.
Old MacDonald had a farm, E - I - E - I - O.

Old MacDonald had a farm, E - I - E - I - O,
And on his farm he had a donkey, E - I - E - I - O.
With a bray bray here and a bray bray there,
Here a bray, there a bray, ev'rywhere a bray bray.
Old MacDonald had a farm, E - I - E - I - O.

Old MacDonald had a farm, E - I - E - I - O,
And on his farm he had a pig, E - I - E - I - O.
With an oink oink here and an oink oink there,
Here an oink, there an oink, ev'rywhere an oink oink.
Old MacDonald had a farm, E - I - E - I - O.
";
            Assert.Equal(expectedLyrics, lyrics);
        }
    }
}
