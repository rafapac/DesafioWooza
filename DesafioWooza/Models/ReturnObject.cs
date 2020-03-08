using System.Collections.Generic;
using System.Net;

namespace DesafioWooza.Models
{
    public class ReturnObject
    {
        public HttpStatusCode StatusCode { get; set; }
        public IList<string> Messages { get; set; }
    }
}
