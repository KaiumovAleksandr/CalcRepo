using System;
using System.Collections.Generic;
using System.Text;

namespace CalcFunction
{
    public class Math
    {
        ///Використовується також глобальна змінна:
        /// <summary>
        /// Останнє повідомлення про помилку.
        /// Поле і властивість для нього
        /// </summary>
        private static string _lastError = String.Empty;
        public static string lastError;


        /// <summary>
        /// The function of addition of numbers firstNumber and secondNumber
        /// </summary>
        /// <param name="firstNumber">addition</param>
        /// <param name="secondNumber">addition</param>
        /// <returns>sum</returns>
        public static int Add(long firstNumber, long secondNumber)
        {
            return (int) (firstNumber + secondNumber);
        }

        /// <summary>
        /// The function of subtraction of number firstNumber і secondNumber
        /// </summary>
        /// <param name="firstNumber">decreasing</param>
        /// <param name="secondNumber">negative</param>
        /// <returns>difference</returns>
        public static int Sub(long firstNumber, long secondNumber)
        {
            return 0;
        }

        /// <summary>
        /// The function of multiplication of number firstNumber і secondNumber
        /// </summary>
        /// <param name="firstNumber">multiplier</param>
        /// <param name="secondNumber">multiplier</param>
        /// <returns>product</returns>
        public static int Mult(long firstNumber, long secondNumber)
        {
            return (int) (firstNumber * secondNumber);
        }

        /// <summary>
        /// The function of finding the particle
        /// </summary>
        /// <param name="firstNumber">divided</param>
        /// <param name="secondNumber">divider</param>
        /// <returns>fraction</returns>
        public static int Div(long firstNumber, long secondNumber)
        {
            return (int) (firstNumber / secondNumber);
        }

        /// <summary>
        /// The function of module division 
        /// </summary>
        /// <param name="firstNumber">divided</param>
        /// <param name="secondNumber">divider</param>
        /// <returns>remainder</returns>
        public static int Mod(long firstNumber, long secondNumber)
        {
            return (int) (firstNumber % secondNumber);
        }

        /// <summary>
        /// unary plus
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int Abs(long number)
        {
            return (int) ++number;
        }

        /// <summary>
        /// unary minus
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int Iabs(long number)
        {
            return (int) --number;
        }
    }
}
