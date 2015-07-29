using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Lab_7_variant_2
{
    class Reader
    {
        string data;
        public Reader(string route)
        {
            StreamReader StrRdr = new StreamReader(route);
            data = StrRdr.ReadToEnd();
        }
        public string ReadFile
        {
            get
            {
                return data.Replace('\r', ' ').Replace('\n', ' ');
            }
        }
    }
}
