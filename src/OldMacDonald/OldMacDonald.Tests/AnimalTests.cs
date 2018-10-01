using Xunit;
using OldMacDonald.Song.Farm;
using OldMacDonald.Song;

namespace OldMacDonald.Tests
{
    public class AnimalTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("       ")]
        public void Animal_CreateAnimal_AnimalWithInvalidNameIsCreated(string name)
        {
            var ex = Assert.Throws<SongException>(() => new Animal(name, "miaou"));
            Assert.Equal("Animal name must be specified.", ex.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("       ")]
        public void Animal_CreateAnimal_AnimalWithInvalidSoundIsCreated(string sound)
        {
            var ex = Assert.Throws<SongException>(() => new Animal("fish", sound));
            Assert.Equal("Animal sound must be specified.", ex.Message);
        }

        [Theory]
        [InlineData("test1", "boo-boo")]
        [InlineData("sample animal", "cock-a-doodle-doo")]
        [InlineData("donkey", "bray...    bray")]
        [InlineData("liger", "<~%^#@#@#@$%#)*@(*&^#%@$>~")]
        public void Animal_CreateAnimal_AnimalWithCorrectNameAndSoundIsCreated(
            string name,
            string sound)
        {
            Animal animal = new Animal(name, sound);
            Assert.Equal(name, animal.Name);
            Assert.Equal(sound, animal.Sound);
        }

        [Fact]
        public void Animal_CreateCow_AnimalWithCorrectNameAndSoundIsCreated()
        {
            Cow cow = new Cow();
            Assert.Equal("cow", cow.Name);
            Assert.Equal("moo", cow.Sound);
        }

        [Fact]
        public void Animal_CreateDuck_AnimalWithCorrectNameAndSoundIsCreated()
        {
            Duck duck = new Duck();
            Assert.Equal("duck", duck.Name);
            Assert.Equal("quack", duck.Sound);
        }

        [Fact]
        public void Animal_CreateHorse_AnimalWithCorrectNameAndSoundIsCreated()
        {
            Horse horse = new Horse();
            Assert.Equal("horse", horse.Name);
            Assert.Equal("neigh", horse.Sound);
        }

        [Fact]
        public void Animal_CreateLamb_AnimalWithCorrectNameAndSoundIsCreated()
        {
            Lamb lamb = new Lamb();
            Assert.Equal("lamb", lamb.Name);
            Assert.Equal("baa", lamb.Sound);
        }

        [Fact]
        public void Animal_CreatePig_AnimalWithCorrectNameAndSoundIsCreated()
        {
            Pig pig = new Pig();
            Assert.Equal("pig", pig.Name);
            Assert.Equal("oink", pig.Sound);
        }
    }
}
