using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Text;
using System.Web.Hosting;

namespace ThirukuralAPI.Models
{
    public class இயல்_தோகுப்பு
    {
        private readonly static string _iyalFilePath = HostingEnvironment.MapPath("~/ThirukuralA2Z\\Iyal.txt");
        readonly static string[] Iyal = File.ReadAllLines(_iyalFilePath);
        private readonly static string _athikaramFilePath = HostingEnvironment.MapPath("~/ThirukuralA2Z\\chapters.txt");
        readonly static string[] FileChapter = File.ReadAllLines(_athikaramFilePath);

        public string இயல் { get; set; }
        
        public List<string> அதிகாரம் { get; set; }

        public இயல்_தோகுப்பு (string இயல், List<string> அதிகாரம்)
        {
            this.இயல் = இயல்;
            this.அதிகாரம் = அதிகாரம்;
        }

        public static HttpResponseMessage இயல்கள்()
        {
            HttpResponseMessage message = new HttpResponseMessage();
            try
            {       
                message.StatusCode = System.Net.HttpStatusCode.OK;
                message.Content = new StringContent("{\n\t\"இயல்கள்\":" + JsonConvert.SerializeObject(Iyal.ToList()) + "\n}", System.Text.Encoding.UTF8, "application/json");
                return message;
            }
            catch(Exception ex)     
            {
                message.StatusCode = System.Net.HttpStatusCode.BadRequest;
                message.Content = new StringContent($"Error Message : {ex.Message}", Encoding.UTF8, "application/json");
                return message;
            }
        }

        public static இயல்_தோகுப்பு Getஇயல்(string input)
        {
            List<string> Chapterslist = new List<string>();

            try
            {
                int அதிகாரம்எண்ணிக்கை = 0;
                var இயல்வரிசைஎண் = (int)Enum.Parse(typeof(EnumIyal), input);

                foreach (var data in Iyal)
                {
                    if (data == input) break;
                    அதிகாரம்எண்ணிக்கை += (int)Enum.Parse(typeof(EnumIyal), data);
                }
                for (int i = அதிகாரம்எண்ணிக்கை; i < (இயல்வரிசைஎண் + அதிகாரம்எண்ணிக்கை); i++)
                {
                    Chapterslist.Add(FileChapter[i]);
                }
            }
            catch(Exception)
            {
                throw;
            }
            return new இயல்_தோகுப்பு(input, Chapterslist);
        }
    }
}