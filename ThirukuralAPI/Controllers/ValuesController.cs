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
            return இயல்.இயல்கள்();
        }

        public HttpResponseMessage GetAthikaram()
        {
            return அதிகாரம்.அதிகாரங்கள்();
        }

        public HttpResponseMessage GetAthikaram()
        {
            return அதிகாரம்.அதிகாரங்கள்();
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
