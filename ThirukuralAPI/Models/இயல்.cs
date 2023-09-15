using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ThirukuralAPI.Models
{
    public class இயல்
    {
        public static string இயல்கள்()
        {
            string FilePath = @"C:\Users\Gowrishankar\source\repos\ThirukuralAPI\ThirukuralAPI\ThirukuralA2Z\Iyal.txt";
            string[] Iyal = File.ReadAllLines(FilePath);
            return "{\n\t\"இயல்கள்\":" + JsonConvert.SerializeObject(Iyal.ToList()) + "\n}";
        }
    }
}