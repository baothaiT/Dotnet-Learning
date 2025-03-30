using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Application.UserCases.V1
{
    public class BaseHandler
    {
        private readonly IMapper _mapper;
        public BaseHandler(IMapper mapper) 
        {
            _mapper = mapper;
        }
    }
}
