using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
                List<குறள்கள்> குறள் = new List<குறள்கள்>();
                var FilePaths = Directory.GetFiles(@"C:\Users\Gowrishankar\source\repos\ThirukuralAPI\ThirukuralAPI\ThirukuralA2Z\Thirukural");
                var FileName = FilePaths.Select(s => Path.GetFileName(s)).ToList();
                FileName.Sort();
                for (int i = 0; i < FilePaths.Length; i++)
                {
                    string FilePath = @"C:\Users\Gowrishankar\source\repos\ThirukuralAPI\ThirukuralAPI\ThirukuralA2Z/Thirukural/" + FileName[i] + "";
                    string[] thirukural = File.ReadAllLines(FilePath);
                    for (int j = 0; j < thirukural.Length; j += 5)
                    {
                        குறள்.Add(new குறள்கள்(thirukural[j].Split(' ')[1], thirukural[j + 1] + "" + thirukural[j + 2], thirukural[j + 4])); 
                    }
                }

                message.StatusCode = System.Net.HttpStatusCode.OK;
                message.Content = new StringContent("{" + JsonConvert.SerializeObject(குறள்) + "\n}", System.Text.Encoding.UTF8, "application/json");
                return message;
            }
            catch(Exception ex)
            {
                message.StatusCode = System.Net.HttpStatusCode.BadRequest;
                message.Content = new StringContent(ex.Message, System.Text.Encoding.UTF8, "application/json");
                return message;
            }
        }
    }
}