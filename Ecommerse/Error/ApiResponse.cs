﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerse.Error
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }



        public int StatusCode { get; set; }
        public string Message { get; set; }
        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A Bad Request you have made",
                401 => "Authorized, you are not",
                404 => "Resourse found, it was not",
                500 => "Errors are the path to the dark side.Errors lead to anger. Anger leads to hate. Hate leads to the career change",
                _ => null,
            };
        }

    }
}
