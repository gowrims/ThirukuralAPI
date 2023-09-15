using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThirukuralAPI.Models
{
    public class குறள்கள்
    {
        [JsonProperty("குறள் எண்")]
        public string குறள்_எண் { get; set; }
        public string குறள் { get; set; }
        public string விளக்கம் { get; set; }

        public குறள்கள்(string Number, string Line, string Explian)
        {
            குறள்_எண் = Number;
            குறள் = Line;
            விளக்கம் = Explian;
        }
    }
}