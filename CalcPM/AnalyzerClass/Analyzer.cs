using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzerClass
{

    public class Analaizer
    {
        public static string lastError;

        /// <summary> 
        /// позиція виразу, на якій знайдена синтаксична помилка (у  
        /// випадку відловлення на рівні виконання - не визначається) 
        /// </summary> 
        private static int erposition = 0;
        /// <summary> 
        /// Вхідний вираз 
        /// </summary> 
        public static string expression = "";

        /// <summary>  
        /// Показує, чи є необхідність у виведенні повідомлень про помилки.  
        ///У разі консольного запуску програми це значення - false. 
        /// </summary> 
        public static bool ShowMessage = true;
        /// <summary> 
        /// Перевірка коректності структури в дужках вхідного виразу 
        ///  а також знаходить помилки в кінці рядка 
        /// </summary> 
        /// <returns>true - якщо все нормально, false- якщо є   помилка</returns>
        /// метод біжить по вхідному виразу, символ за символом аналізуючи  його, і рахуючи кількість дужок.У разі виникнення
        /// помилки повертає false, а в erposition записує позицію, на  якій виникла помилка.
        public static bool CheckCurrency()
        {
            int numberOpenBracket = 0;
            int numberClosedBracket = 0;
            int numberSimbols = 0;
            int numberDigits = 0;
            foreach (var ch in expression)
            {
                if (ch == ')')
                    ++numberClosedBracket;
                if (ch == '(')
                    ++numberOpenBracket;
                if (char.IsDigit(ch))
                    ++numberDigits;
                if (char.IsSymbol(ch))
                {
                    if (ch != ')' && ch != '(')
                        ++numberSimbols;
                }
            }
            if (numberOpenBracket != numberClosedBracket)
            {
                if (numberOpenBracket > numberClosedBracket)
                    erposition = expression.LastIndexOf('(');
                else
                    erposition = expression.LastIndexOf(')');
                return false;
            }
            if (numberSimbols * 2 != numberDigits)
                return false;
            //якщо останній символ не є цифрою і не є ) 
            if (char.IsDigit(expression[expression.Length - 1]) == false && expression[expression.Length - 1] != ')')
            {
                erposition = expression.Length - 1;
                return false;
            }

            return true;
        }

        /// <summary> 
        /// Форматує вхідний вираз, виставляючи між операторами  пропуски і видаляючи зайві, а також знаходить нерозпізнані оператори, стежить за кінцем рядка       
        /// </summary> 
        /// <returns>кінцевий рядок або повідомлення про помилку, що починаються з спец. символу &</returns> 
        public static string Format()
        {
            expression = expression.Replace("  ", " ");

            return expression;
        }
        private static int Priority(char oper)
        {
            if (oper == '+' || oper == '-')
                return 1;
            if (oper == '*' || oper == '/')
                return 2;
            return 0;
        }

        /// <summary> 
        /// Формує  масив, в якому розташовуються оператори і символи  представлені в зворотному польському записі(без дужок)
        /// На цьому ж етапі відшукується решта всіх помилок (див. код). По суті - це компіляція.
        /// </summary> 
        /// <returns>массив зворотнього польського запису</returns> 
        public static System.Collections.ArrayList CreateStack()
        {


            return new System.Collections.ArrayList();
        }

        /// <summary> 
        /// Обчислення зворотнього польського запису 
        /// </summary> 
        ///<returns>результат обчислень,або повідомлення про помилку</returns> 
        public static string RunEstimate()
        {
            return "";
        }

        /// <summary> 
        /// Метод, який організовує обчислення. По черзі запускає CheckCorrncy, Format, CreateStack і RunEstimate
        /// </summary> 
        /// <returns></returns> 
        public static string Estimate()
        {
            return "";
        }

    }
}
