using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
    public class Constants
    {
        public static readonly string ValidSerialsFilePath = Path.Combine(Environment.CurrentDirectory, "ValidSerials.txt");
    }
}
