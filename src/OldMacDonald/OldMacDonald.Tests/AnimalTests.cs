using OldMacDonald.Farm;
using Xunit;

namespace OldMacDonald.Tests
{
    public class AnimalTests
    {
        [Fact]
        public void Animal_CreateCow_AnimalWithCorrectNameAndSoundIsCreated()
        {
            Cow cow = new Cow();
            Assert.Equal("cow", cow.Name);
            Assert.Equal("moo", cow.Sound);
        }
    }
}
