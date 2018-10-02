using System.IO;
using System.Text;
using Xunit;
using OldMacDonald.ConsoleApp;
using OldMacDonald.Song;

namespace OldMacDonald.Tests
{
    public class RhymeGeneratorTests
    {
        [Fact]
        public void Run_CommandOld_OutputNurseryRhymeLyrics()
        {
            string inputFilePath = "../../../Resources/SampleInput_Old.in";
            string outputFilePath = "../../../Resources/SampleOutput.out";
            string expectedOutputFilePath = "../../../Resources/ExpectedOutput_Old.out";

            InitializeAndRunRhymeGenerator(inputFilePath, outputFilePath);

            string actualOutput = File.ReadAllText(outputFilePath, Encoding.ASCII);
            string expectedOutput = File.ReadAllText(expectedOutputFilePath, Encoding.ASCII);

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void Run_CommandNew_Output3NewVerses()
        {
            string inputFilePath = "../../../Resources/SampleInput_New.in";
            string outputFilePath = "../../../Resources/SampleOutput.out";
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
            IValidator validator = new Validator(new ValidatorSettings());
            ISongWriter songWriter = new SongWriter();
            IRhymeGenerator rhymeGenerator = new RhymeGenerator(ioService, validator, songWriter);

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    ioService.SetIn(reader);
                    ioService.SetOut(writer);
                    rhymeGenerator.Run();
                }
            }
        }
    }
}
