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
        private static string[] fileContent = File.ReadAllLines(Environment.CurrentDirectory + "/ThirukuralA2Z/chapters.txt");

        public static string[] FileContent { get => fileContent; set => fileContent = value; }

        public static string அதிகாரங்கள்()
        {
            //HttpResponseMessage response = new HttpResponseMessage();

            //response.StatusCode = System.Net.HttpStatusCode.OK;
            //response.Content = new string
            return "{\"அதிகாரங்கள்\" : " + JsonConvert.SerializeObject(FileContent.ToList()) + "}";
        }
    }
}