using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirukuralAPI.Models
{
    public class Search
    {
        public string அதிகாரம் {  get; set; }
        public string இயல் { get; set; }
        [JsonProperty("குறள் எண்")]
        public string குறள்_எண் {  get; set; }
        public string உள்ளீடு { get; set; }
    }
}
