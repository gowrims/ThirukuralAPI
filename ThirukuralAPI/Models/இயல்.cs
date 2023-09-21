using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Text;

namespace ThirukuralAPI.Models
{
    public class இயல்_தோகுப்பு
    {
        private readonly static string _iyalFilePath = @"C:\Users\Gowrishankar\source\repos\ThirukuralAPI\ThirukuralAPI\ThirukuralA2Z\Iyal.txt";

        private readonly static string _athikaramFilePath = @"C:\Users\Gowrishankar\source\repos\ThirukuralAPI\ThirukuralAPI\ThirukuralA2Z\chapters.txt";

        public static HttpResponseMessage இயல்கள்()
        {
            HttpResponseMessage message = new HttpResponseMessage();
            try
            {
                string[] Iyal = File.ReadAllLines(_iyalFilePath);
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

        public static HttpResponseMessage Getஇயல்(string input)
        {
            HttpResponseMessage message = new HttpResponseMessage();

            try
            {

            }
            catch(Exception)
            {
                throw;
            }

            return message;
        }
    }
}