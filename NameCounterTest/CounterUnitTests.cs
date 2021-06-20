using System;
using Xunit;
using NameCounter;
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
            var validPathName = @"C:\Users\User\Desktop\Sample.txt";

            Assert.Equal("Sample", counterService.ExtractFileName(validPathName));
        }
        [Fact]
        public void GetNumberOfTextAppearance_WithCorrectFileName_ReturnsFileNameWithoutExtention()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"TestDocuments\OneNamePerLine3.txt");

            Assert.Equal("OneNamePerLine3", counterService.ExtractFileName(path));
        }
        
        //file with 3 appearance on 3 lines
        //file with 2 appearance on a single line
        //file with 2 appearance on empty line between
        //file with empty content
        //file with content but no appearnce of name

    }
}
