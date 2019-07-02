using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdwardWelborn_CE3
{
    abstract class Logger : iLog
    {
        
        abstract public void Log(string LogIt);

        abstract public void LogD(string LogIt);

        abstract public void LogW(string LogIt);

    }
}
