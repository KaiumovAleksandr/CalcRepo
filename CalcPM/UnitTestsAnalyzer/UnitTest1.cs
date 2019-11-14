using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnalyzerClass;
namespace UnitTestsAnalyzer
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void isIncorrectNumberBracket()
        {
            Analaizer.expression = "((1+2)";
            //mock.Setup(f => f.expression).Returns("((1+2)");
            // Analaizer s = new Analaizer(mock.Object);
            bool r = Analaizer.CheckCurrency();
            Assert.AreEqual(false, r);
        }

        [TestMethod]
        public void isIncorrectNumberSimbols()
        {

            Analaizer.expression = "(1++2)";
           
            bool r = Analaizer.CheckCurrency();
            Assert.AreEqual(false, r);
        }

        [TestMethod]
        public void isIncorrectLastSimbols1()
        {
            Analaizer.expression="(1+2)+";         
            bool r = Analaizer.CheckCurrency();
            Assert.AreEqual(false, r);
        }
        [TestMethod]
        public void isIncorrectLastSimbols2()
        {
            Analaizer.expression="(1+2)(";          
            bool r = Analaizer.CheckCurrency();
            Assert.AreEqual(false, r);
        }
        [TestMethod]
        public void isCorrectExpression()
        {
            Analaizer.expression="(1+2)";          
            bool r = Analaizer.CheckCurrency();
            Assert.AreEqual(true, r);
        }

        [TestMethod]
        public void IsFormatedSpaces()
        {
            Analaizer.expression="1  +  2+2";           
            string r = Analaizer.Format();
            Assert.AreEqual("1 + 2+2", r);
        }
    }
}
