using System.Collections.Generic;

namespace DesafioWooza.Models
{
    public class ReturnObject
    {
        public int StatusCode { get; set; }
        public IList<string> Messages { get; set; }
    }
}
