using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ThirukuralAPI.Models
{
    public class குறள்கள்
    {
        [JsonProperty("குறள் எண்")]
        public string குறள்_எண் { get; set; }
        public string குறள் { get; set; }
        [JsonProperty("குறள் விளக்கம்")]
        public string குறள்_விளக்கம் { get; set; }

        private static readonly string FolderPath = "C:\\Users\\Gowrishankar\\source\\repos\\ThirukuralAPI\\ThirukuralAPI\\ThirukuralA2Z\\Thirukural";

        public குறள்கள்(string Number, string Line, string Explian)
        {
            குறள்_எண் = Number;
            குறள் = Line;
            குறள்_விளக்கம் = Explian;
        }

        public static குறள்கள் Getகுறள்கள்(int KuralNumber)
        {
            int number = (int)Math.Round((double)KuralNumber / 10) * 10;
            var Files = Directory.GetFiles(FolderPath);
            குறள்கள் kural = new குறள்கள்(string.Empty,string.Empty,string.Empty);
            string[] thirukural = File.ReadAllLines(Files[number]);
            int count = 0;
            for (int j = 0; j < thirukural.Length; j += 5)
            {
                if (count == number)
                {
                    kural = new குறள்கள்(thirukural[j].Split(' ')[1], $"{thirukural[j + 1]} {thirukural[j + 2]}", thirukural[j + 4]);
                    break;
                }
                count++;
            }
            return kural;
        }
    }
}