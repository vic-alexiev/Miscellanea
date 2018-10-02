using System.IO;
using System.Text;
using Xunit;
using OldMacDonald.ConsoleApp;
using OldMacDonald.Song;

namespace OldMacDonald.Tests
{
    public class RhymeGeneratorTests
    {
        private IRhymeGenerator _rhymeGenerator;

        [Fact]
        public void RhymeGenerator_CommandOld_OutputNurseryRhymeLyrics()
        {
            string inputFilePath = "../../../Resources/SampleInput_Old.in";
            string outputFilePath = "../../../Resources/SampleOutput_Old.out";
            string expectedOutputFilePath = "../../../Resources/ExpectedOutput_Old.out";

            InitializeAndRunRhymeGenerator(inputFilePath, outputFilePath);

            string actualOutput = File.ReadAllText(outputFilePath, Encoding.ASCII);
            string expectedOutput = File.ReadAllText(expectedOutputFilePath, Encoding.ASCII);

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void RhymeGenerator_CommandNew_Output3NewVerses()
        {
            string inputFilePath = "../../../Resources/SampleInput_New.in";
            string outputFilePath = "../../../Resources/SampleOutput_New.out";
            string expectedOutputFilePath = "../../../Resources/ExpectedOutput_New.out";

            InitializeAndRunRhymeGenerator(inputFilePath, outputFilePath);

            string actualOutput = File.ReadAllText(outputFilePath, Encoding.ASCII);
            string expectedOutput = File.ReadAllText(expectedOutputFilePath, Encoding.ASCII);

            Assert.Equal(expectedOutput, actualOutput);
        }

        private void InitializeAndRunRhymeGenerator(
            string inputFilePath,
            string outputFilePath)
        {
            IIOService ioService = new ConsoleService();
            ISongWriter songWriter = new SongWriter();
            IValidator validator = new Validator(new ValidatorSettings());
            _rhymeGenerator = new RhymeGenerator(ioService, songWriter, validator);

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
