using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ThirukuralAPI.Models
{
    public class IyalDetails
    {
        public string இயல் { get; set; }

        [JsonProperty("அதிகார எண்ணிக்கை")]
        public int அதிகார_எண்ணிக்கை { get; set; }
        [JsonProperty("குறள் எண்ணிக்கை")]
        public int குறள்_எண்ணிக்கை { get; set;}

        public IyalDetails(string இயல், int அதிகார_எண்ணிக்கை,int குறள்_எண்ணிக்கை)
        {
            this.இயல் = இயல்;
            this.அதிகார_எண்ணிக்கை = அதிகார_எண்ணிக்கை;
            this.குறள்_எண்ணிக்கை = குறள்_எண்ணிக்கை;
        }
    }
}