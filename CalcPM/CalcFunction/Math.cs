﻿using System;

namespace CalcFunction
{
    public class Math
    {

        /// <summary>
        /// The function of addition of numbers firstNumber and secondNumber
        /// </summary>
        /// <param name="firstNumber">addition</param>
        /// <param name="secondNumber">addition</param>
        /// <returns>sum</returns>
        public static double Add(long firstNumber, long secondNumber) => firstNumber + secondNumber;

        /// <summary>
        /// The function of subtraction of number firstNumber і secondNumber
        /// </summary>
        /// <param name="firstNumber">decreasing</param>
        /// <param name="secondNumber">negative</param>
        /// <returns>difference</returns>
        public static double Sub(long firstNumber, long secondNumber) => firstNumber-secondNumber;

        /// <summary>
        /// The function of multiplication of number firstNumber і secondNumber
        /// </summary>
        /// <param name="firstNumber">multiplier</param>
        /// <param name="secondNumber">multiplier</param>
        /// <returns>product</returns>
        public static double Mult(long firstNumber, long secondNumber) => firstNumber * secondNumber;

        /// <summary>
        /// The function of finding the particle
        /// </summary>
        /// <param name="firstNumber">divided</param>
        /// <param name="secondNumber">divider</param>
        /// <returns>fraction</returns>
        public static double Div(long firstNumber, long secondNumber) => firstNumber / secondNumber;

        /// <summary>
        /// The function of module division 
        /// </summary>
        /// <param name="firstNumber">divided</param>
        /// <param name="secondNumber">divider</param>
        /// <returns>remainder</returns>
        public static double Mod(long firstNumber, long secondNumber) => firstNumber % secondNumber;

        /// <summary>
        /// unary plus
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static double Abs(int number) => System.Math.Abs(number);

        /// <summary>
        /// unary minus
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static double Iabs(long number) => number*-1;
    }
}
