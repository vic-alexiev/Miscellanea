using System;
using Xunit;
using OldMacDonald.Song;

namespace OldMacDonald.Tests
{
    public class SongExceptionTest
    {
        [Fact]
        public void TestConstructor_NoParameters()
        {
            SongException songEx = new SongException();

            Assert.Equal($"Exception of type '{typeof(SongException).FullName}' was thrown.", songEx.Message);
            Assert.Null(songEx.InnerException);
        }

        [Fact]
        public void TestConstructor_MessageProvided()
        {
            SongException songEx = new SongException("Test");

            Assert.Equal("Test", songEx.Message);
            Assert.Null(songEx.InnerException);
        }

        [Fact]
        public void TestConstructor_MessageAndInnerExceptionProvided()
        {
            Exception innerEx = new InvalidOperationException();
            SongException songEx = new SongException("Test", innerEx);

            Assert.Equal("Test", songEx.Message);
            Assert.Same(innerEx, songEx.InnerException);
        }
    }
}
