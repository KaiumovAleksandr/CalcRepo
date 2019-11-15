using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcExceptionLibrary
{
    public class CalcException : Exception
    {
        public int ErrorPos { get; }
        public int ErrorCode { get; }
        public CalcException(int error_code, int error_index)
        {
            ErrorPos = error_index + 1;
            ErrorCode = error_code;
        }
        public CalcException(int error_code) { ErrorCode = error_code; }
    }
}
