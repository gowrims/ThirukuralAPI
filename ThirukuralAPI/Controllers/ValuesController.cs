using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using ThirukuralAPI.Models;

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

        public HttpResponseMessage GetThirukural()
        {
            return திருக்குறள்.திருக்குறள்கள்();
        }

        public void Post([FromBody] string value)
        {
        }

        public void Put(int id, [FromBody] string value)
        {
        }

        public void Delete(int id)
        {
        }
    }
}
