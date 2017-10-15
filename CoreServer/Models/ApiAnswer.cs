using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreServer.Models
{
    public class ApiAnswer
    {
        public bool Success { get; set; }
        public object Value { get; set; }
    }
}
