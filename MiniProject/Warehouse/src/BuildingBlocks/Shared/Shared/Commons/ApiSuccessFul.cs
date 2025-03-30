using Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Commons;

public class ApiSuccessFul<T> : ApiResult<T>
{
    public ApiSuccessFul(T data)
    {
        this.IsSucceeded = true;
        this.Message = ResponseAPIStatic.Succeeded;
        this.Data = data;
    }
}
