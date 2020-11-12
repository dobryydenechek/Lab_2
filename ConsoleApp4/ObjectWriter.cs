using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp4
{
    class ObjectWriter
    {
        public static void Write<T>(TextWriter output, T student)
        {
            output.WriteLine(student.ToString());
        }
    }
}
