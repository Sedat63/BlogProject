using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ObjectDesign
{
    public class ServiceResponse<T>: ServiceResponse
    {
        public ServiceResponse
            (T data,
            bool successful = true,
            string message = "")
        {
            Data = data;
            Successful = successful;
            Message = message;
        }
        public ServiceResponse
          (string message = "",
            bool successful = true)
        {
            Successful = successful;
            Message = message;
        }

        public T Data { get; set; }
    }

    public class ServiceResponse
    {
        public ServiceResponse(string message = "",bool successful = true)
        {
            Successful = successful;
            Message = message;
        }

        public bool Successful { get; set; }
        public string Message { get; set; }
        public string ExceptionMessage { get; set; }
    }
   
}
