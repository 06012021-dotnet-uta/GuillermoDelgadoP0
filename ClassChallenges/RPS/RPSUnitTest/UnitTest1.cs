using System;
using Xunit;
using RockPaperScissors;

namespace RPSUnitTest
{
    public class UnitTest1
    {
        // [Fact]
        // public void Test1()
        // {
        //     //Arrange
        //     int x = 2;
        //     int y = 3;

        //     //Act
        //     int z = 2 + 3;

        //     //Assert
        //     Assert.Equal(5, z);
        // }

        [Fact]
        public void PlayAgainTest()
        {
       
            //Arrange
            Game game = new RockPaperScissors.Game();

            //Act
            string x = game.Welcome();
            
            //Assert
            // Assert.Equal(1, x);
            // Assert.Equal(2,x);
            Assert.Equal("Guille",x);
        }

//Theory help with multyple values
        [Theory]
        [InlineData(1,2)]
        [InlineData(3,2)]
        [InlineData(2,2)]
        public void TestingMultipleValues(){
              //Arrange
            
            //Act
           
            //Assert
        }
    }
}
