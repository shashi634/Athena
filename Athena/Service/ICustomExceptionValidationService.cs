using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Athena.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICustomExceptionValidationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="statusCode"></param>
        HttpResponseException CustomValidation(string message, HttpStatusCode statusCode);
    }
}
