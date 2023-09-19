using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace ThirukuralAPI.Models
{
    public class திருக்குறள்
    {
        public static HttpResponseMessage திருக்குறள்கள்()
        {
            HttpResponseMessage message = new HttpResponseMessage();
            try
            {
                message.StatusCode = System.Net.HttpStatusCode.OK;
                List<List<குறள்கள்>> list = new List<List<குறள்கள்>>();
                List<குறள்கள்> குறள்வரிசை = new List<குறள்கள்>();
                List<List<List<குறள்கள்>>> அதிகாரவரிசை = new List<List<List<குறள்கள்>>>();
                var FilePaths = Directory.GetFiles(@"C:\Users\Gowrishankar\source\repos\ThirukuralAPI\ThirukuralAPI\ThirukuralA2Z\Thirukural");
                var FileName = FilePaths.Select(s => Path.GetFileName(s)).ToList();
                var AthikaramList = File.ReadAllLines(@"C:\Users\Gowrishankar\source\repos\ThirukuralAPI\ThirukuralAPI\ThirukuralA2Z\chapters.txt");
                FileName.Sort();
                for (int i = 0; i < FilePaths.Length; i++)
                {
                    string FilePath = @"C:\Users\Gowrishankar\source\repos\ThirukuralAPI\ThirukuralAPI\ThirukuralA2Z/Thirukural/" + FileName[i] + "";
                    string[] thirukural = File.ReadAllLines(FilePath);
                    for (int j = 0; j < thirukural.Length; j += 5)
                    {
                        குறள்வரிசை.Add(new குறள்கள்(thirukural[j].Split(' ')[1], $"{thirukural[j + 1]} {thirukural[j + 2]}", thirukural[j + 4]));
                    }
                }

                for (int i = 0; ; i+=10)
                {
                    if(i == குறள்வரிசை.Count)
                    {
                        break;
                    }
                    list.Add(குறள்வரிசை.GetRange(i,10));
                }

                message.Content = new StringContent("{" + JsonConvert.SerializeObject(list) + "\n}", System.Text.Encoding.UTF8, "application/json");
                return message;
            }
            catch(Exception ex)
            {
                message.StatusCode = System.Net.HttpStatusCode.BadRequest;
                message.Content = new StringContent("{ \n\tError Message : "+ ex.Message+"}", System.Text.Encoding.UTF8, "application/json");
                return message;
            }
        }
    }
}