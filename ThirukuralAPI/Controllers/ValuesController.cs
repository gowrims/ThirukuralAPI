﻿using System;
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
        [HttpGet]
        public HttpResponseMessage GetIyal()
        {
            return இயல்_தோகுப்பு.இயல்கள்();
        }

        [HttpGet]
        public HttpResponseMessage GetAthikaram()
        {
            return அதிகார_தோகுப்பு.அதிகாரங்கள்();
        }

        [HttpGet]
        public HttpResponseMessage GetThirukuralAll()
        {
            return திருக்குறள்.திருக்குறள்கள்();
        }

        [HttpPost]
        public HttpResponseMessage Search(dynamic dynamicinput)
        {
            HttpResponseMessage message = new HttpResponseMessage();

            try
            {
                var JsonString = JsonConvert.SerializeObject(dynamicinput);
                Search search = JsonConvert.DeserializeObject<Search>(JsonString);
                if (search.அதிகாரம் != null)
                {
                    var lists = திருக்குறள்.Getஅதிகாரகுறள்(search.அதிகாரம்);
                    message = new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent("{ \n\t \"அதிகாரம்\" : \"" + search.அதிகாரம் + "\"\t\t" + JsonConvert.SerializeObject(lists) + "\n}", Encoding.UTF8, "application/json")
                    };
                }
                else if(search.இயல் != string.Empty)
                {
                    இயல்_தோகுப்பு lists = இயல்_தோகுப்பு.Getஇயல்(input: search.இயல்);
                    message = new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent($"{JsonConvert.SerializeObject(lists)}", Encoding.UTF8, "application/json")
                    };
                }
                else if(search.குறள்_எண் != string.Empty)
                {

                }
            }
            catch (Exception ex)
            {
                message.StatusCode = System.Net.HttpStatusCode.BadRequest;
                message.Content = new StringContent(ex.Message,Encoding.UTF8,"application/json");
            }

            return message;
        }

    }
}
