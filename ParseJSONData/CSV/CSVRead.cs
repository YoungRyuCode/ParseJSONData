using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ParseJSONData
{
    public class CSVRead
    {
        public static Array ReadFrom(string filePath)
        {            
            var arrInput = File.ReadAllText(filePath).Split('\n');

            return arrInput;
        }
    }
}