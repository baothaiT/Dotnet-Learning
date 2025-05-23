﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shared.Commons
{
    public class ApiResult<T>
    {
        public ApiResult()
        {
        }

        [JsonConstructor]
        public ApiResult(bool isSucceeded, string message = null)
        {
            Message = message;
            IsSucceeded = isSucceeded;
        }

        public ApiResult(bool isSucceeded, T data, string message = null)
        {
            Data = data;
            Message = message;
            IsSucceeded = isSucceeded;
        }

        public bool IsSucceeded { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
