using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TELFAIR_BACKEND.Classes.Services
{
    public class APIResponse
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
