using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Application.Models.Requests
{
    public class DocumentRequest
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
    }
}
