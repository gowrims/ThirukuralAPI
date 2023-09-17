using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace ThirukuralAPI.Models
{
    public class அதிகாரம்
    {
        public static HttpResponseMessage அதிகாரங்கள்()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                string[] fileContent = File.ReadAllLines(@"C:\Users\Gowrishankar\source\repos\ThirukuralAPI\ThirukuralAPI\ThirukuralA2Z\chapters.txt");           
                response. StatusCode = System.Net.HttpStatusCode.OK;
                response.Content = new StringContent("{\n\t\"அதிகாரங்கள்\":" + JsonConvert.SerializeObject(fileContent.ToList()) + "\n}", System.Text.Encoding.UTF8, "application/json");
            }
            catch(Exception ex)
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.Content = new StringContent($"Error Message : {ex.Message}", System.Text.Encoding.UTF8, "application/json");
            }
            return response;
        }
    }
}