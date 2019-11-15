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
        [InlineData(12, 52)]//можна винести ініціалізацію даних
        [InlineData(32, 62)]//test case
        public void AddTestTheory(long firstNumber, long secondNumber)
        {
            //act
            var res = Math.Add(firstNumber, secondNumber);
            //assert
            Assert.Equal(firstNumber + secondNumber, res);
        }

        [Theory]
        [InlineData(0, 2)]
        [InlineData(10, 15)]
        [InlineData(2, -2)]
        public void SubTestTheory(long firstNumber, long secondNumber)
        {
            //act
            var res = Math.Sub(firstNumber, secondNumber);
            //assert
            Assert.Equal(firstNumber - secondNumber, res);
        }

        [Theory]
        [InlineData(5, 0)]
        [InlineData(0, 5)]
        [InlineData(10, 2)]
        [InlineData(-5, 2)]
        [InlineData(-5, -5)]
        public void MultTestTheory(long firstNumber, long secondNumber)
        {
            //act
            var res = Math.Mult(firstNumber, secondNumber);
            //assert
            Assert.Equal(firstNumber * secondNumber, res);
        }

        [Theory]
        [InlineData(5, 2)]
        public void DivTestTheory(long firstNumber, long secondNumber)
        {
            //act
            var res = Math.Div(firstNumber, secondNumber);
            //assert
            Assert.Equal(firstNumber / secondNumber, res);
        }

        [Theory]
        [InlineData(5, 0)]
        public void DivTestTheorybyZero(long firstNumber, long secondNumber)
        {
            Assert.Throws<DivideByZeroException>(() =>
            {
                Math.Div(firstNumber, secondNumber);
            });
        }

        [Theory]
        [InlineData(5, 2)]
        public void ModTestTheory(long firstNumber, long secondNumber)
        {
            //act
            var res = Math.Mod(firstNumber, secondNumber);
            //assert
            Assert.Equal(firstNumber % secondNumber, res);
        }

        [Theory]
        [InlineData(-5)]
        public void AbsTestTheory(int Number)
        {
            //act
            var res = Math.Abs(Number);
            //assert
            Assert.Equal(System.Math.Abs(Number), res);
        }

        [Theory]
        [InlineData(5)]
        public void IAbsTestTheory(long Number)
        {
            //act
            var res = Math.Iabs(Number);
            //assert
            Assert.Equal(Number * -1, res);
        }
    }
}