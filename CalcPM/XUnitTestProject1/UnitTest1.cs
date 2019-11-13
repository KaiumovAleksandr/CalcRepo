using System;
using Xunit;
using Math = CalcFunction.Math;

namespace CalcTests
{

    public class MathTest
    {
        [Fact]
        //[Fact(Skip = "Ignored this test")]// можна передати в параметри маркер типу ігнор і вказати опис
        public void AddTest()
        {
            //arrange
            var firstNumber = 12;
            var secondNumber = 52;//ініціалізація роботи
            //act
            var res = Math.Add(firstNumber, secondNumber);// сама дія
            //assert
            Assert.Equal(firstNumber + secondNumber, res);// перевірка результату

        }
        [Theory]
        [InlineData(12,52)]//можна винести ініціалізацію даних
        [InlineData(32,62)]//test case
        public void AddTestTheory(int firstNumber, int secondNumber)
        {
            //act
            var res = Math.Add(firstNumber, secondNumber);
            //assert
            Assert.Equal(firstNumber + secondNumber, res);
        }
    }
}