using System;
using Xunit;
using Math = CalcFunction.Math;

namespace CalcTests
{

    public class MathTest
    {
        [Fact]
        public void AddTest()
        {
            //arrange
            var firstNumber = 12;
            var secondNumber = 52;
            //act
            var res = Math.Add(firstNumber, secondNumber);
            //assert
            Assert.Equal(firstNumber+secondNumber,res);
        }
    }
}
