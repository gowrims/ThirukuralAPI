using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using ThirukuralAPI.Models;

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
        public HttpResponseMessage GetThirukural()
        {
            return திருக்குறள்.திருக்குறள்கள்();
        }

        [HttpGet]
        public HttpResponseMessage GetPoruladakamadakam()
        {
            HttpResponseMessage message = new HttpResponseMessage();

            try
            {
                message.StatusCode = HttpStatusCode.OK;
                message.Content = new StringContent(JsonConvert.SerializeObject(Porulatakkam.GetPorulatakkam()), Encoding.UTF8, "application/json");
            }
            catch (Exception ex)
            {
                string text = "{\"Message\":\"" + ex.Message.ToString() + "\"}";
                message.StatusCode = HttpStatusCode.BadRequest;
                message.Content = new StringContent(text, Encoding.UTF8, "application/json");
            }

            return message;
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
                else if (search.இயல் != null)
                {
                    இயல்_தோகுப்பு lists = இயல்_தோகுப்பு.Getஇயல்(input: search.இயல்);
                    message = new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent($"{JsonConvert.SerializeObject(lists)}", Encoding.UTF8, "application/json")
                    };
                }
                else if (search.குறள்_எண் != null)
                {
                    குறள்கள் lists = குறள்கள்.Getகுறள்கள்(int.Parse(search.குறள்_எண்));
                    if (lists == null)
                    {
                        string Text = "{\"குறிப்பு\":\"தற்பொழுது நீங்கள் தேடும் குறள் எண் '" + search.குறள்_எண் + "' தற்சமயம் எங்களிடம் இல்லை விரைவில் வழங்கப்படும்.\"}";
                        message = new HttpResponseMessage
                        {
                            StatusCode = HttpStatusCode.NoContent,
                            Content = new StringContent(Text, Encoding.UTF8, "application/json")
                        };
                    }
                    else
                    {
                        message = new HttpResponseMessage
                        {
                            StatusCode = HttpStatusCode.OK,
                            Content = new StringContent($"{JsonConvert.SerializeObject(lists)}", Encoding.UTF8, "application/json")
                        };
                    }
                }
                else if (search.உள்ளீடு != null)
                {
                    var lists = குறள்கள்.வெளியீட்டுகுறள்(search.உள்ளீடு);
                    if (lists == null)
                    {
                        string Text = "{\"குறிப்பு\":\"தற்பொழுது நீங்கள் தேடும் குறள் எண் '" + search.குறள்_எண் + "' தற்சமயம் எங்களிடம் இல்லை விரைவில் வழங்கப்படும்.\"}";
                        message = new HttpResponseMessage
                        {
                            StatusCode = HttpStatusCode.NoContent,
                            Content = new StringContent(Text, Encoding.UTF8, "application/json")
                        };
                    }
                    else
                    {
                        message = new HttpResponseMessage
                        {
                            StatusCode = HttpStatusCode.OK,
                            Content = new StringContent($"{JsonConvert.SerializeObject(lists)}", Encoding.UTF8, "application/json")
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                message.StatusCode = System.Net.HttpStatusCode.BadRequest;
                message.Content = new StringContent(ex.Message, Encoding.UTF8, "application/json");
            }

            return message;
        }

    }
}
