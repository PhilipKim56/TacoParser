using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("33.524131,-86.724876,Taco Bell Birmingham...", -86.724876)]
        [InlineData("34.271508,-84.798907,Taco Bell Cartersville..", -84.798907)]
        [InlineData("32.472496,-84.987592,Taco Bell Columbus...", -84.987592)]    
            
        //Add additional inline data. Refer to your CSV file.
        public void ShouldParseLongitude(string line, double expected)
        {
            // TODO: Complete the test with Arrange, Act, Assert steps below.
            //       Note: "line" string represents input data we will Parse 
            //       to extract the Longitude.  
            //       Each "line" from your .csv file
            //       represents a TacoBell location

            //Arrange
            TacoParser parser = new TacoParser();

            //Act
            double actual = (parser.Parse(line)).Location.Longitude;

            //Assert
            Assert.Equal(expected, actual);

        }


        //TODO: Create a test called ShouldParseLatitude

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("33.524131,-86.724876,Taco Bell Birmingham...", 33.524131)]
        [InlineData("34.271508,-84.798907,Taco Bell Cartersville..", 34.271508)]
        [InlineData("32.472496,-84.987592,Taco Bell Columbus...", 32.472496)]
        public void ShouldParseLatitude(string line, double expected)
        {
            //Arrange
            TacoParser parser = new TacoParser();

            //Act
            double actual = (parser.Parse(line)).Location.Latitude;

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
