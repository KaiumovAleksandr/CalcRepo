using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CalcExceptionLibrary;
using AnalyzerClass;

namespace CalcPM
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            if(args.Length > 0)
            {
                Analaizer.expression = args[0];
                string res = string.Empty;
                try
                {
                    res = Analaizer.Estimate();
                    ((TextBox)((Form1)Application.OpenForms[0]).Controls["textBox_Result"]).Text = res;
                }
                catch (CalcException ex)
                {
                    switch (ex.ErrorCode)
                    {
                        case 2:
                            ((TextBox)((Form1)Application.OpenForms[0]).Controls["textBox_Result"]).Text = $"Error 02. Unknown operator at {ex.ErrorPos} position.";
                            break;
                        case 3:
                            ((TextBox)((Form1)Application.OpenForms[0]).Controls["textBox_Result"]).Text = "Error 03. Incorrect syntax construction of expression.";
                            break;
                        case 4:
                            ((TextBox)((Form1)Application.OpenForms[0]).Controls["textBox_Result"]).Text = $"Error 04. Two same opeartors in a row at {ex.ErrorPos} position.";
                            break;
                        case 5:
                            ((TextBox)((Form1)Application.OpenForms[0]).Controls["textBox_Result"]).Text = "Error 05. Unfinished expression.";
                            break;
                        case 9:
                            ((TextBox)((Form1)Application.OpenForms[0]).Controls["textBox_Result"]).Text = "Error 09. Сannot be divided by zero.";
                            break;
                    }
                }
            }
        }
    }
}
