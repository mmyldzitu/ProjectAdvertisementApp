using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Common
{
    public class Response<T>:Response, IResponse<T> 
    {
        public T Data  { get; set; }
        public List<CustomValidationError> ValidationError { get; set; }
        public Response(ResponseType responseType, String message):base(responseType,message)
        {

        }
        public Response(ResponseType responseType, T data):base(responseType)
        {
            Data = data;
        }
        public Response( T data, List<CustomValidationError> errors):base(ResponseType.ValidationError)
        {
            ValidationError = errors;
            Data = data;

        }
    }
}
