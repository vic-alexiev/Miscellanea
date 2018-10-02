using System.Collections.Generic;
using System.IO;
using System.Linq;
using Moq;
using Xunit;
using OldMacDonald.ConsoleApp;
using OldMacDonald.Song;
using OldMacDonald.Song.Farm;

namespace OldMacDonald.Tests
{
    public class RhymeGeneratorMockTests
    {
        private IRhymeGenerator _rhymeGenerator;
        private Mock<IValidator> _validatorMock;
        private Mock<ISongWriter> _songWriterMock;

        [Fact]
        public void RhymeGenerator_CommandOld_ComposeSongWithPredefinedAnimals()
        {
            string inputFilePath = "../../../Resources/SampleInput_Old.in";
            string outputFilePath = "../../../Resources/SampleOutput.out";

            InitializeAndRunRhymeGenerator(inputFilePath, outputFilePath);

            _validatorMock.Verify(
                v => v.ValidateVersesCount(It.IsAny<string>()),
                Times.Never);
            _validatorMock.Verify(
                v => v.ValidateAnimalName(It.IsAny<string>()),
                Times.Never);
            _validatorMock.Verify(
                v => v.ValidateAnimalSound(It.IsAny<string>()),
                Times.Never);

            List<Animal> animals = new List<Animal>
            {
                new Pig(),
                new Cow(),
                new Lamb(),
                new Horse(),
                new Duck()
            };

            _songWriterMock.Verify(
                w => w.Compose(
                    It.Is<IEnumerable<Animal>>(
                        items => new HashSet<Animal>(items, new AnimalEqualityComparer())
                        .SetEquals(animals))),
                Times.Once);
        }

        [Fact]
        public void RhymeGenerator_CommandNew_ComposeSongWith3NewAnimals()
        {
            string inputFilePath = "../../../Resources/SampleInput_New.in";
            string outputFilePath = "../../../Resources/SampleOutput.out";

            InitializeAndRunRhymeGenerator(inputFilePath, outputFilePath);

            string[] names = new string[] { "owl", "lion", "donkey" };
            string[] sounds = new string[] { "screech", "roar", "bray" };

            _validatorMock.Verify(
                v => v.ValidateVersesCount(It.IsAny<string>()),
                Times.Once);
            _validatorMock.Verify(
                v => v.ValidateVersesCount(It.Is<string>(c => c == "3")),
                Times.Once);
            _validatorMock.Verify(
                v => v.ValidateAnimalName(It.IsAny<string>()),
                Times.Exactly(3));
            _validatorMock.Verify(
                v => v.ValidateAnimalName(It.Is<string>(n => names.Contains(n))),
                Times.Exactly(3));
            _validatorMock.Verify(
                v => v.ValidateAnimalSound(It.IsAny<string>()),
                Times.Exactly(3));
            _validatorMock.Verify(
                v => v.ValidateAnimalSound(It.Is<string>(s => sounds.Contains(s))),
                Times.Exactly(3));

            List<Animal> animals = new List<Animal>
            {
                new Animal("owl", "screech"),
                new Animal("lion", "roar"),
                new Animal("donkey", "bray")
            };

            _songWriterMock.Verify(
                w => w.Compose(
                    It.Is<IEnumerable<Animal>>(
                        items => new HashSet<Animal>(items, new AnimalEqualityComparer())
                        .SetEquals(animals))),
                Times.Once);
        }

        private void InitializeAndRunRhymeGenerator(
        string inputFilePath,
        string outputFilePath)
        {
            IIOService ioService = new ConsoleService();
            _validatorMock = new Mock<IValidator>();

            _validatorMock
                .Setup(v => v.ValidateVersesCount(It.IsAny<string>()))
                .Returns(true);

            _validatorMock
                .Setup(v => v.ValidateAnimalName(It.IsAny<string>()))
                .Returns(true);

            _validatorMock
                .Setup(v => v.ValidateAnimalSound(It.IsAny<string>()))
                .Returns(true);

            _songWriterMock = new Mock<ISongWriter>();

            _songWriterMock
                .Setup(v => v.Compose(It.IsAny<IEnumerable<Animal>>()))
                .Returns("song goes here");

            _rhymeGenerator = new RhymeGenerator(
                ioService,
                _validatorMock.Object,
                _songWriterMock.Object);

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    ioService.SetIn(reader);
                    ioService.SetOut(writer);
                    _rhymeGenerator.Run();
                }
            }
        }
    }
}
