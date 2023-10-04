using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Xml;

namespace ThirukuralAPI.Models
{
    public class குறள்கள்
    {
        [JsonProperty("குறள் எண்")]
        public string குறள்_எண் { get; set; }
        public string குறள் { get; set; }
        [JsonProperty("குறள் விளக்கம்")]
        public string குறள்_விளக்கம் { get; set; }

        private static readonly string FolderPath = HostingEnvironment.MapPath("~/ThirukuralA2Z\\Thirukural");

        public குறள்கள்(string Number, string Line, string Explian)
        {
            குறள்_எண் = Number;
            குறள் = Line;
            குறள்_விளக்கம் = Explian;
        }

        public static குறள்கள் Getகுறள்கள்(int KuralNumber)
        {
            var Files = Directory.GetFiles(FolderPath);
            குறள்கள் kural = new குறள்கள்(string.Empty,string.Empty,string.Empty);
            int count = 0;
            for (int i = 0;i < Files.Count(); i++)
            {
                string[] thirukural = File.ReadAllLines(Files[i]);
                for (int j = 0; j < thirukural.Length; j += 5)
                {
                    count++;
                    if (count == KuralNumber)
                    {
                        kural = new குறள்கள்(thirukural[j].Split(' ')[1], $"{thirukural[j + 1]} {thirukural[j + 2]}", thirukural[j + 4]);
                        break;
                    }
                }
                if (count == KuralNumber) { break; };
            }
            if(count < KuralNumber)
            {
                kural = null;
            }
            return kural;
        }

        public static List<குறள்கள்> வெளியீட்டுகுறள்(string input)
        {
            var Files = Directory.GetFiles(FolderPath);
            List<குறள்கள்> list = new List<குறள்கள்>();
            for (int i = 0; i < Files.Count(); i++)
            {
                string[] thirukural = File.ReadAllLines(Files[i]);
                for (int j = 0; j < thirukural.Length; j += 5)
                {
                    if (thirukural[j + 1].Contains(input) || thirukural[j + 2].Contains(input))
                    {
                        list.Add(new குறள்கள்(thirukural[j].Split(' ')[1], $"{thirukural[j + 1]} {thirukural[j + 2]}", thirukural[j + 4]));
                    }
                }
            }
            return list;
        }

        
    }
}