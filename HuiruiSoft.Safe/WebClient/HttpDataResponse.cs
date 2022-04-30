namespace HuiruiSoft.Safe.Net
{
     using RestSharp;
     using System.Net;
     using System.Collections.Generic;

     public class HttpDataResponse<T>
     {
          public int Code
          {
               get;
               set;
          }

          public string Message
          {
               get;
               set;
          }

          public T Data
          {
               get;
               set;
          }

          public string Content { get; set; }

          public long ContentLength { get; set; }

          public string ContentType { get; set; }

          public string ContentEncoding { get; set; }

          public string StatusDescription { get; set; }

          public HttpStatusCode StatusCode { get; set; }

          public ResponseStatus ResponseStatus { get; set; }

          public IList<Parameter> Headers
          {
               get;

               set;
          }

          public IList<RestResponseCookie> Cookies
          {
               get;

               set;
          }
     }
}
