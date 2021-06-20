using System;
using Xunit;
using ServiceLayer;
using System.IO;
using System.Reflection;

namespace NameCounterTest
{
    public class CounterUnitTests
    {
        private CounterService counterService = new CounterService();

        [Fact]
        public void ExtractFileName_WithFileNameThatDoesNotHaveExtention_ThrowsError()
        {
            var falsePathName = "AnyGibberish!";

            Assert.Throws<ArgumentException>(() => counterService.ExtractFileName(falsePathName));
        }
        [Fact]
        public void ExtractFileName_WithCorrectFileName_ReturnsFileNameWithoutExtention()
        {
            var validPathName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"TestDocuments\OneNamePerLine3.txt");

            Assert.Equal("Sample", counterService.ExtractFileName(validPathName));
        }
        [Fact]
        public void GetNumberOfTextAppearance_WithOneFileNamePerLineOn3Lines_Returns3()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"TestDocuments\OneNamePerLine3.txt");

            Assert.Equal(3, counterService.GetNumberOfTextAppearance(path, "OneNamePerLine3"));
        }
        [Fact]
        public void GetNumberOfTextAppearance_With1LineContainingTheNameTwice_Returns2()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"TestDocuments\MultipleNamePerLine4.txt");

            Assert.Equal(2, counterService.GetNumberOfTextAppearance(path, "MultipleNamePerLine4"));
        }

        //file with 2 appearance on empty line between
        //file with empty content
        //file with content but no appearnce of name

    }
}
