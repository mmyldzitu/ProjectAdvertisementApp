using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Common
{
    public class Response:IResponse
    {
        public Response(ResponseType _responseType)
        {
            ResponseType = _responseType;
        }
        public Response(ResponseType _responseType, string  _message)
        {
            ResponseType = _responseType;
            Message = _message;
        }
        public string Message { get; set; }
        public ResponseType ResponseType { get; set; }
    }
    public enum ResponseType
    {
        Success,
        ValidationError,
        NotFound
    }
}
