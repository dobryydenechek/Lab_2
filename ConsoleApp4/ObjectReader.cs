using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp4
{
    interface IReadble
    {
        void FromString(string data);
    }
    class ObjectReader
    {
        public static T Read<T>(TextReader input) 
            where T: IReadble, new()
        {
            string data = input.ReadLine();
            var t = new T();
            t.FromString(data);
            return t;
        }

    }
}
