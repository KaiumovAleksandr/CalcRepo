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
        [TestMethod]
        public void CreateStack()
        {
            Analaizer.expression = "(234+3)-34";
            var r = Analaizer.CreateStack();
            System.Collections.ArrayList array = new System.Collections.ArrayList();
            array.Add("234");
            array.Add("3");
            array.Add("+");
            array.Add("34");
            array.Add("-");
            Assert.AreEqual(array.Count, r.Count);
        }
        [TestMethod]
        public void RunEstimate()
        {
            Analaizer.expression = "(234+3)-34";            
            var r = Analaizer.RunEstimate((string[])Analaizer.CreateStack().ToArray(typeof(string)));            
            Assert.AreEqual("203",r);
        }
    }
}