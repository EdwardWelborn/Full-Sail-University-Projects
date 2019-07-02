using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdwardWelborn_CE3
{
    class DotNotLog : Logger
    {
        public override void Log(string Log)
        {
        }

        public override void LogD(string Log)
        {
        }

        public override void LogW(string Log)
        {
        }
    }
}
/*
 * DoNotLog
Log - should do nothing
LogD - should do nothing
LogW - should do nothing
*/

