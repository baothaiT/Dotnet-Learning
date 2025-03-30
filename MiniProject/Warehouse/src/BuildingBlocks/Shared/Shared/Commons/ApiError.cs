using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Commons;

public class ApiError<T> : ApiResult<T>
{
    public ApiError(string message)
    {
        this.IsSucceeded = false;
        this.Message = message;
    }
}
