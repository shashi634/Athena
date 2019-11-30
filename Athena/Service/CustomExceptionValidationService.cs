using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Athena.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomExceptionValidationService : ICustomExceptionValidationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="statusCode"></param>
        public HttpResponseException CustomValidation(string message, HttpStatusCode statusCode)
        {
            var response = new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(message, System.Text.Encoding.UTF8, "text/plain"),
                StatusCode = statusCode
            };
            throw new HttpResponseException(response);
        }
    }
    /// <summary>
    /// Error Message
    /// </summary>
    public class ErrorMessage {
        /// <summary>
        /// Message
        /// </summary>
        public int Message { get; set; }
    }
}