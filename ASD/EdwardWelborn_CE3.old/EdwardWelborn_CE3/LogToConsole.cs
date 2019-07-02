using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdwardWelborn_CE3
{
    class LogToConsole : Logger
    {
        private static int _lineNumber;

        public override void Log(string LogIt)
        {
            _lineNumber++;
            Console.WriteLine(_lineNumber + " " + LogIt);
        }

        public override void LogD(string LogIt)
        {
            _lineNumber++;
            Console.WriteLine(_lineNumber + ": Debug: " + LogIt);
        }

        public override void LogW(string LogIt)
        {
            _lineNumber++;
            Console.WriteLine(_lineNumber + ": Warning:" + LogIt);
        }

    }
}
/*
 * LogToConsole
Log - should use Console.Writeline to output the lineNumber and the string that was passed in.  It should also increase the lineNumber.
LogD - should use Console.Writeline to output the lineNumber, the word DEBUG, and the string that was passed in.  It should also increase the lineNumber.
LogW - should use Console.Writeline to output the lineNumber, the word WARNING, and the string that was passed in.  It should also increase the lineNumber.
----optional
output different parts in color
 */

