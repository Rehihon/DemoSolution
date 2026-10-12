using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Empsolution.Service
{
    public static class ServiceExceptionHandler
    {
        public static string GetErrorMessage(Exception ex, string serviceName)
        {
            if (ex is HttpRequestException)
            {
                return $"Unable to connect to {serviceName}.\n\n" +
                       "Please check your internet connection and try again.";
            }

            if (ex is TaskCanceledException)
            {
                return $"{serviceName} is taking too long to respond.\n\n" +
                       "Please try again later.";
            }

            return $"An error occurred while communicating with {serviceName}.\n\n" +
                   "Please try again later.";
        }
    }
}
