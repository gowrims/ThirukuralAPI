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
    public class இயல்
    {
        public static HttpResponseMessage இயல்கள்()
        {
            HttpResponseMessage message = new HttpResponseMessage();
            string[] Iyal = new string[13];
            try
            {
                string FilePath = @"C:\Users\Gowrishankar\source\repos\ThirukuralAPI\ThirukuralAPI\ThirukuralA2Z\Iyal.txt";
                Iyal = File.ReadAllLines(FilePath);
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
    }
}