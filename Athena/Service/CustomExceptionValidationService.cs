using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
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
            var resultResponse = JsonConvert.SerializeObject(
                                new ErrorMessageDto { ErrorMessage = message, ErrorCode = statusCode }, Formatting.Indented,
                            new JsonSerializerSettings()
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            });
            var response = new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(resultResponse, System.Text.Encoding.UTF8, "text/plain"),
                StatusCode = statusCode
            };
            throw new HttpResponseException(response);
        }
    }
    /// <summary>
    /// Error Message
    /// </summary>
    public class ErrorMessageDto {
        /// <summary>
        /// Message
        /// </summary>
        public string ErrorMessage { get; set; }
        public HttpStatusCode ErrorCode { get; set; }
    }
}