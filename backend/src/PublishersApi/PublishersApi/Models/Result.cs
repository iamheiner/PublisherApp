using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class Result
    {
        internal Result(bool succeeded, object data, List<string> errors = null)
        {
            this.Succeeded = succeeded;
            this.Data = data;
            this.Errors = errors;
        }
        public object Data { get; set; }
        public bool Succeeded { get; set; }
        public List<string> Errors { get; set; }
    }
}
