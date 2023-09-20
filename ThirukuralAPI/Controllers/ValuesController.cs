using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ThirukuralAPI.Models;
using System.Text;
using Newtonsoft.Json;

namespace ThirukuralAPI.Controllers
{
    public class ValuesController : ApiController
    {
        public HttpResponseMessage GetIyal()
        {
            return இயல்_தோகுப்பு.இயல்கள்();
        }

        public HttpResponseMessage GetAthikaram()
        {
            return அதிகார_தோகுப்பு.அதிகாரங்கள்();
        }

        public HttpResponseMessage GetThirukuralAll()
        {
            return திருக்குறள்.திருக்குறள்கள்();
        }

        public HttpResponseMessage GetThirukural(dynamic dynamicinput)
        {
            HttpResponseMessage message = new HttpResponseMessage();

            try
            {
                var JsonString = JsonConvert.SerializeObject(dynamicinput);
                var search = JsonConvert.DeserializeObject<Search>(JsonString);
                var lists = திருக்குறள்.Getஅதிகாரகுறள்(search.அதிகாரம்);
                message = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{" + JsonConvert.SerializeObject(lists) + "\n}", Encoding.UTF8,"application/json")
                };
            }
            catch (Exception ex)
            {
                message.StatusCode = System.Net.HttpStatusCode.BadRequest;
                message.Content = new StringContent(ex.Message,Encoding.UTF8,"application/json");
            }

            return message;
        }

        public void Put(int id, [FromBody] string value)
        {
        }

        public void Delete(int id)
        {
        }
    }
}
