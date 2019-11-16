using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalcFunction;
namespace AnalyzerClass
{

    public class Analaizer
    {
        
        private static List<string> standart_operators =
            new List<string>(new string[] { "(", ")", "+", "-", "*", "/", "%" });
        private static List<string> operators = new List<string>(standart_operators);
       

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
           
            foreach (var ch in expression)
            {
                if (ch == ')')
                    ++numberClosedBracket;
                if (ch == '(')
                    ++numberOpenBracket;
                
            }
            if (numberOpenBracket != numberClosedBracket)
            {
                if (numberOpenBracket > numberClosedBracket)
                    erposition = expression.LastIndexOf('(');
                else
                    erposition = expression.LastIndexOf(')');
                return false;
            }
           
            //якщо останній символ не є цифрою і не є ) 
            if (char.IsDigit(expression[expression.Length - 1]) == false && expression[expression.Length - 1] != ')')
            {
                erposition = expression.Length - 1;
                return false;
            }

            for (int i = 0; i < expression.Length; i++)
            {
                if (i == 0)
                    continue;
                if (standart_operators.Contains(expression[i].ToString())) //якщо це стандартний оператор і не дужка
                {

                    char prev = expression[i - 1];
                    if (char.IsDigit(prev) == false && (prev != '(' && prev != ')')) //якщо минулий символ теж оператор але не дужка 
                        if (expression[i] != '(')//якщо минулий символ оператор але поточний символ відкриваюча дужка Приклад(a+b)+(
                        return false;
                }
                else
                {
                    if (char.IsDigit(expression[i]) == false)
                    {
                        erposition = i;
                        return false;
                    }
                }

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
        /// розділяє на операнди та оператори 
        /// </summary>    
       
        private static IEnumerable<string> Separate(string input)
        {
            int pos = 0;
            while (pos < input.Length)
            {
                string s = string.Empty + input[pos];
                if (!standart_operators.Contains(input[pos].ToString()))
                {
                    if (Char.IsDigit(input[pos]))
                        for (int i = pos + 1; i < input.Length &&
                            (Char.IsDigit(input[i]) || input[i] == ',' || input[i] == '.'); i++)
                            s += input[i];
                    else if (Char.IsLetter(input[pos]))
                        for (int i = pos + 1; i < input.Length &&
                            (Char.IsLetter(input[i]) || Char.IsDigit(input[i])); i++)
                            s += input[i];
                }
                yield return s;
                pos += s.Length;
            }
        }
        /// <summary>
        /// повертає пріоритет оператора 
        /// </summary>
        /// <param name="s">символ </param>
        /// <returns> значення пріоритетності</returns>
        private static byte GetPriority(string s)
        {
            switch (s)
            {
                case "(":
                case ")":
                    return 0;
                case "+":
                case "-":
                    return 1;
                case "*":
                case "/":
                case "%":
                    return 2;
                default:
                    return 4;
            }
        }
        /// <summary> 
        /// Формує  масив, в якому розташовуються оператори і символи  представлені в зворотному польському записі(без дужок)
        /// На цьому ж етапі відшукується решта всіх помилок (див. код). По суті - це компіляція.
        /// </summary> 
        /// <returns>массив зворотнього польського запису</returns> 
        /// 
        public static System.Collections.ArrayList CreateStack()
        {
           
            System.Collections.ArrayList outputSeparated = new System.Collections.ArrayList();
            Stack<string> stack = new Stack<string>();
            foreach (string c in Separate(expression))
            {
                if (operators.Contains(c))
                {
                    if (stack.Count > 0 && !c.Equals("("))
                    {
                        if (c.Equals(")"))
                        {
                            string s = stack.Pop();
                            while (s != "(")
                            {
                                outputSeparated.Add(s);
                                s = stack.Pop();
                            }
                        }
                        else if (GetPriority(c) > GetPriority(stack.Peek()))
                            stack.Push(c);
                        else
                        {
                            while (stack.Count > 0 && GetPriority(c) <= GetPriority(stack.Peek()))
                                outputSeparated.Add(stack.Pop());
                            stack.Push(c);
                        }
                    }
                    else
                        stack.Push(c);
                }
                else
                    outputSeparated.Add(c);
            }
            if (stack.Count > 0)
                foreach (string c in stack)
                    outputSeparated.Add(c);

            return outputSeparated;
          
        }

        /// <summary> 
        /// Обчислення зворотнього польського запису 
        /// </summary> 
        ///<returns>результат обчислень,або повідомлення про помилку</returns> 
        public static string RunEstimate(string[] postfixNotation)
        {
            //(string[])CreateStack().ToArray()
            Stack<string> stack = new Stack<string>();
            Queue<string> queue = new Queue<string>(postfixNotation);
            string str = queue.Dequeue();
            while (queue.Count >= 0)
            {
                if (!operators.Contains(str))
                {
                    stack.Push(str);
                    str = queue.Dequeue();
                }
                else
                {
                    decimal summ = 0;
                    try
                    {

                        switch (str)
                        {

                            case "+":
                                {
                                    double a = Convert.ToDouble(stack.Pop());
                                    double b = Convert.ToDouble(stack.Pop());
                                    summ = CalcFunction.Math.Add(a,b);
                                    break;
                                }
                            case "-":
                                {
                                    double a = Convert.ToDouble(stack.Pop());
                                    double b = Convert.ToDouble(stack.Pop());
                                    summ =CalcFunction.Math.Sub(a,b);
                                    break;
                                }
                            case "*":
                                {
                                    double a = Convert.ToDouble(stack.Pop());
                                    double b = Convert.ToDouble(stack.Pop());
                                    summ = CalcFunction.Math.Mult(a,b);
                                    break;
                                }
                            case "/":
                                {
                                    double a = Convert.ToDouble(stack.Pop());
                                    double b = Convert.ToDouble(stack.Pop());
                                    summ = CalcFunction.Math.Div(a,b) ;
                                    break;
                                }
                            case "%":
                                {
                                    double a = Convert.ToDouble(stack.Pop());
                                    double b = Convert.ToDouble(stack.Pop());
                                    summ = CalcFunction.Math.Mod(a, b);
                                    break;
                                }
                        }
                    }
                    catch (Exception ex)
                    {                        
                        return $"$ {ex.Message}";
                    }
                    stack.Push(summ.ToString());
                    if (queue.Count > 0)
                        str = queue.Dequeue();
                    else
                        break;
                }

            }
            return Convert.ToString(stack.Pop());
        }

        /// <summary> 
        /// Метод, який організовує обчислення. По черзі запускає CheckCorrncy, Format, CreateStack і RunEstimate
        /// </summary> 
        /// <returns></returns> 
        public static string Estimate()
        {
            if (CheckCurrency())
            {
                Format();
                var postfixNotation = CreateStack();
                return RunEstimate((string[])postfixNotation.ToArray(typeof(string)));
            }
            else
                return "$Error";         
        }
    }
}
