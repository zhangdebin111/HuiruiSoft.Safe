
using RestSharp;
using Newtonsoft.Json;
using System.Net;
using System.Globalization;
using System.Collections.Generic;

namespace HuiruiSoft.Safe.Net
{
     public class HttpRequestApi
     {
          private const int defaultRequestTryTime = 3, defaultRequestTimeOut = 8 * 1000;
          private const string defaultUserAgent = "Mozilla/5.0 (Windows NT 6.1; rv:25.0) Gecko/20100101 Firefox/25.0";

          private const string apiRequestUrl = "http://help.huiruisoft.com/";

          public static readonly string RequestBodyName = "RequestBody";

          protected CultureInfo CurrentCulture = CultureInfo.CurrentCulture;
          protected DateTimeStyles CurrentTimeStyle = DateTimeStyles.AssumeLocal | DateTimeStyles.AllowWhiteSpaces;

          protected readonly static string[] DateTimeFormats =
          {
               "yy-MM-dd HH:mm:ss", HuiruiSoft.Utils.DateTimeHelper.GeneralDateTimePattern,
               "yyyy-M-d HH:mm", "yyyy-M-d HH:mm:ss", "yyyy-MM-dd HH:mm", HuiruiSoft.Utils.DateTimeHelper.GeneralDateTimePattern
          };

          private const string ContenType_JSON = "application/json";

          public IList<RestResponseCookie> Cookies
          {
               get;
               set;
          }

          public static string ClientUserAgent { set; private get; } = "Web";

          public string BaseUrl { get; set; } = apiRequestUrl;

          public int? MaxRedirects { get; set; } = defaultRequestTryTime;

          public int Timeout { get; set; } = defaultRequestTimeOut;

          public string RequestBodyFormat { get; set; } = "JSON";

          public int ReadWriteTimeout
          {
               get; set;
          }

          public string UserAgent
          {
               get; set;
          }

          public string ContentType
          {
               get;

               set;
          }

          public CookieContainer CookieContainer { get; set; } = null;

          /// <summary>获取和设置响应的字符集。</summary>
          /// <value>一个字符串，包含响应的字符集。</value>
          /// <remarks>CharacterSet 属性包含一个描述响应的字符集的值。 该字符集信息取自与响应一起返回的标头。</remarks>
          public System.Text.Encoding Encoding { get; set; } = System.Text.Encoding.UTF8;

          public HttpDataResponse<object> CreateImageAuthCode(string httpRequestUrl)
          {
               var tmpHttpResponse = new HttpDataResponse<object>();

               var tmpHttpRequest = new RestRequest(Method.POST);
               if (this.Timeout > 0)
               {
                    tmpHttpRequest.Timeout = this.Timeout;
               }

               if (this.ReadWriteTimeout > 0)
               {
                    tmpHttpRequest.ReadWriteTimeout = this.ReadWriteTimeout;
               }

               var tmpHttpEncoding = this.Encoding != null ? this.Encoding : System.Text.Encoding.UTF8;
               tmpHttpRequest.AddHeader("Cache-Control", "no-cache");
               tmpHttpRequest.AddHeader("Accept-Language", "zh-cn,zh;q=0.8,en-us;q=0.5,en;q=0.3");
               tmpHttpRequest.AddHeader("Accept-Encoding", "gzip, deflate");
               tmpHttpRequest.AddHeader("User-Agent", !string.IsNullOrEmpty(this.UserAgent) ? this.UserAgent : defaultUserAgent);

               if (this.Cookies != null)
               {
                    foreach (var item in this.Cookies)
                    {
                         tmpHttpRequest.AddCookie(item.Name, item.Value);
                    }
               }

               var tmpHttpClient = new RestClient(httpRequestUrl);
               tmpHttpClient.Encoding = tmpHttpEncoding;

               var tmpRestResponse = tmpHttpClient.Execute(tmpHttpRequest);
               if (tmpRestResponse != null)
               {
                    tmpHttpResponse.Cookies = tmpRestResponse.Cookies;
                    tmpHttpResponse.Headers = tmpRestResponse.Headers;
                    tmpHttpResponse.Content = tmpRestResponse.Content;
                    tmpHttpResponse.StatusCode = tmpRestResponse.StatusCode;
                    tmpHttpResponse.ContentType = tmpRestResponse.ContentType;
                    tmpHttpResponse.ContentLength = tmpRestResponse.ContentLength;
                    tmpHttpResponse.ResponseStatus = tmpRestResponse.ResponseStatus;
                    tmpHttpResponse.ContentEncoding = tmpRestResponse.ContentEncoding;
                    tmpHttpResponse.StatusDescription = tmpRestResponse.StatusDescription;

                    switch (tmpRestResponse.StatusCode)
                    {
                         case HttpStatusCode.OK:
                         case HttpStatusCode.Created:
                         case HttpStatusCode.Accepted:
                         case HttpStatusCode.NoContent:
                         case HttpStatusCode.ResetContent:
                         case HttpStatusCode.PartialContent:
                         case HttpStatusCode.NonAuthoritativeInformation:
                              break;

                         case HttpStatusCode.BadRequest:
                         case HttpStatusCode.Unauthorized:
                         case HttpStatusCode.PaymentRequired:
                         case HttpStatusCode.Forbidden:
                         case HttpStatusCode.NotFound:
                         case HttpStatusCode.MethodNotAllowed:
                         case HttpStatusCode.NotAcceptable:
                         case HttpStatusCode.ProxyAuthenticationRequired:
                         case HttpStatusCode.RequestTimeout:
                         case HttpStatusCode.Conflict:
                         case HttpStatusCode.Gone:
                         case HttpStatusCode.LengthRequired:
                         case HttpStatusCode.PreconditionFailed:
                         case HttpStatusCode.RequestEntityTooLarge:
                         case HttpStatusCode.RequestUriTooLong:
                         case HttpStatusCode.UnsupportedMediaType:
                         case HttpStatusCode.RequestedRangeNotSatisfiable:
                         case HttpStatusCode.ExpectationFailed:

                         case HttpStatusCode.InternalServerError:
                         case HttpStatusCode.NotImplemented:
                         case HttpStatusCode.BadGateway:
                         case HttpStatusCode.ServiceUnavailable:
                         case HttpStatusCode.GatewayTimeout:
                         case HttpStatusCode.HttpVersionNotSupported:
                              tmpHttpResponse.Code = (int)tmpRestResponse.StatusCode;
                              tmpHttpResponse.Message = tmpRestResponse.ErrorMessage == null ? tmpRestResponse.Content : tmpRestResponse.ErrorMessage;
                              break;
                    }
               }

               return tmpHttpResponse;
          }

          public virtual HttpDataResponse<T> Execute<T>(string httpRequestUrl, List<Parameter> parameters = null)
          {
               return this.Execute<T>(httpRequestUrl, parameters, Method.POST);
          }

          public virtual HttpDataResponse<T> Execute<T>(string httpRequestUrl, List<Parameter> parameters, Method httpMethod = Method.POST)
          {
               var tmpHttpResponse = new HttpDataResponse<T>();
               var tmpHttpEncoding = this.Encoding != null ? this.Encoding : System.Text.Encoding.UTF8;

               var tmpHttpRequest = new RestRequest(httpMethod);
               if (this.Timeout > 0)
               {
                    tmpHttpRequest.Timeout = this.Timeout;
               }

               if (this.ReadWriteTimeout > 0)
               {
                    tmpHttpRequest.ReadWriteTimeout = this.ReadWriteTimeout;
               }

               tmpHttpRequest.AddHeader("Cache-Control", "no-cache");
               tmpHttpRequest.AddHeader("Accept", ContenType_JSON);
               tmpHttpRequest.AddHeader("Content-Type", !string.IsNullOrEmpty(this.ContentType) ? this.ContentType : ContenType_JSON);
               tmpHttpRequest.AddHeader("Accept-Language", "zh-cn,zh;q=0.8,en-us;q=0.5,en;q=0.3");
               tmpHttpRequest.AddHeader("Accept-Encoding", "gzip, deflate");
               tmpHttpRequest.AddHeader("User-Agent", !string.IsNullOrEmpty(this.UserAgent) ? this.UserAgent : defaultUserAgent);

               if (this.Cookies != null)
               {
                    foreach (var item in this.Cookies)
                    {
                         tmpHttpRequest.AddCookie(item.Name, item.Value);
                    }
               }

               if (parameters != null && parameters.Count > 0)
               {
                    parameters.ForEach(item =>
                    {
                         if (item.Value != null)
                         {
                              switch (item.Type)
                              {
                                   case ParameterType.HttpHeader:
                                        tmpHttpRequest.AddHeader(item.Name, string.Format("{0}", item.Value));
                                        break;

                                   case ParameterType.Cookie:
                                        tmpHttpRequest.AddCookie(item.Name, string.Format("{0}", item.Value));
                                        break;

                                   case ParameterType.QueryString:
                                        tmpHttpRequest.AddQueryParameter(item.Name, string.Format("{0}", item.Value));
                                        break;

                                   case ParameterType.GetOrPost:
                                        tmpHttpRequest.AddParameter(item.Name, item.Value);
                                        break;

                                   case ParameterType.UrlSegment:
                                        tmpHttpRequest.AddUrlSegment(item.Name, string.Format("{0}", item.Value));
                                        break;

                                   case ParameterType.RequestBody:
                                        var tmpRequestBody = JsonConvert.SerializeObject(item.Value, Formatting.None, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });

                                        tmpHttpRequest.AddParameter(ContenType_JSON, tmpRequestBody, ParameterType.RequestBody);
                                        break;
                              }
                         }
                    });
               }

               var tmpHttpClient = new RestClient(httpRequestUrl);
               tmpHttpClient.Encoding = tmpHttpEncoding;

               var tmpRestResponse = tmpHttpClient.Execute(tmpHttpRequest);
               if (tmpRestResponse != null)
               {
                    tmpHttpResponse.Cookies = tmpRestResponse.Cookies;
                    tmpHttpResponse.Headers = tmpRestResponse.Headers;
                    tmpHttpResponse.Content = tmpRestResponse.Content;
                    tmpHttpResponse.StatusCode = tmpRestResponse.StatusCode;
                    tmpHttpResponse.ContentType = tmpRestResponse.ContentType;
                    tmpHttpResponse.ContentLength = tmpRestResponse.ContentLength;
                    tmpHttpResponse.ResponseStatus = tmpRestResponse.ResponseStatus;
                    tmpHttpResponse.ContentEncoding = tmpRestResponse.ContentEncoding;
                    tmpHttpResponse.StatusDescription = tmpRestResponse.StatusDescription;

                    switch (tmpRestResponse.StatusCode)
                    {
                         case HttpStatusCode.OK:
                         case HttpStatusCode.Created:
                         case HttpStatusCode.Accepted:
                         case HttpStatusCode.NoContent:
                         case HttpStatusCode.ResetContent:
                         case HttpStatusCode.PartialContent:
                         case HttpStatusCode.NonAuthoritativeInformation:
                              if (!string.IsNullOrEmpty(tmpRestResponse.Content))
                              {
                                   var tmpDataResponse = JsonConvert.DeserializeObject<HttpDataResponse<T>>(tmpRestResponse.Content);
                                   if (tmpDataResponse != null && tmpDataResponse.Code == 0)
                                   {
                                        tmpHttpResponse.Data = tmpDataResponse.Data;
                                   }
                              }
                              break;

                         case HttpStatusCode.BadRequest:
                         case HttpStatusCode.Unauthorized:
                         case HttpStatusCode.PaymentRequired:
                         case HttpStatusCode.Forbidden:
                         case HttpStatusCode.NotFound:
                         case HttpStatusCode.MethodNotAllowed:
                         case HttpStatusCode.NotAcceptable:
                         case HttpStatusCode.ProxyAuthenticationRequired:
                         case HttpStatusCode.RequestTimeout:
                         case HttpStatusCode.Conflict:
                         case HttpStatusCode.Gone:
                         case HttpStatusCode.LengthRequired:
                         case HttpStatusCode.PreconditionFailed:
                         case HttpStatusCode.RequestEntityTooLarge:
                         case HttpStatusCode.RequestUriTooLong:
                         case HttpStatusCode.UnsupportedMediaType:
                         case HttpStatusCode.RequestedRangeNotSatisfiable:
                         case HttpStatusCode.ExpectationFailed:

                         case HttpStatusCode.InternalServerError:
                         case HttpStatusCode.NotImplemented:
                         case HttpStatusCode.BadGateway:
                         case HttpStatusCode.ServiceUnavailable:
                         case HttpStatusCode.GatewayTimeout:
                         case HttpStatusCode.HttpVersionNotSupported:
                         default:
                              tmpHttpResponse.Code = (int)tmpRestResponse.StatusCode;
                              tmpHttpResponse.Message = tmpRestResponse.ErrorMessage == null ? tmpRestResponse.Content : tmpRestResponse.ErrorMessage;
                              break;
                    }
               }

               return tmpHttpResponse;
          }

          public virtual HttpDataResponse<byte[]> ExecuteStream(string httpRequestUrl, List<Parameter> parameters, Method httpMethod = Method.POST)
          {
               var tmpHttpResponse = new HttpDataResponse<byte[]>();
               var tmpHttpEncoding = this.Encoding != null ? this.Encoding : System.Text.Encoding.UTF8;

               var tmpHttpRequest = new RestRequest(httpMethod);
               if (this.Timeout > 0)
               {
                    tmpHttpRequest.Timeout = this.Timeout;
               }

               if (this.ReadWriteTimeout > 0)
               {
                    tmpHttpRequest.ReadWriteTimeout = this.ReadWriteTimeout;
               }

               tmpHttpRequest.AddHeader("Cache-Control", "no-cache");
               tmpHttpRequest.AddHeader("Accept", ContenType_JSON);
               tmpHttpRequest.AddHeader("Content-Type", !string.IsNullOrEmpty(this.ContentType) ? this.ContentType : ContenType_JSON);
               tmpHttpRequest.AddHeader("Accept-Language", "zh-cn,zh;q=0.8,en-us;q=0.5,en;q=0.3");
               tmpHttpRequest.AddHeader("Accept-Encoding", "gzip, deflate");
               tmpHttpRequest.AddHeader("User-Agent", !string.IsNullOrEmpty(this.UserAgent) ? this.UserAgent : defaultUserAgent);

               if (this.Cookies != null)
               {
                    foreach (var item in this.Cookies)
                    {
                         tmpHttpRequest.AddCookie(item.Name, item.Value);
                    }
               }

               if (parameters != null && parameters.Count > 0)
               {
                    parameters.ForEach(item =>
                    {
                         if (item.Value != null)
                         {
                              switch (item.Type)
                              {
                                   case ParameterType.HttpHeader:
                                        tmpHttpRequest.AddHeader(item.Name, string.Format("{0}", item.Value));
                                        break;

                                   case ParameterType.Cookie:
                                        tmpHttpRequest.AddCookie(item.Name, string.Format("{0}", item.Value));
                                        break;

                                   case ParameterType.QueryString:
                                        tmpHttpRequest.AddQueryParameter(item.Name, string.Format("{0}", item.Value));
                                        break;

                                   case ParameterType.GetOrPost:
                                        tmpHttpRequest.AddParameter(item.Name, item.Value);
                                        break;

                                   case ParameterType.UrlSegment:
                                        tmpHttpRequest.AddUrlSegment(item.Name, string.Format("{0}", item.Value));
                                        break;

                                   case ParameterType.RequestBody:
                                        var tmpRequestBody = JsonConvert.SerializeObject(item.Value, Formatting.None, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });

                                        tmpHttpRequest.AddParameter(ContenType_JSON, tmpRequestBody, ParameterType.RequestBody);
                                        break;
                              }
                         }
                    });
               }

               var tmpHttpClient = new RestClient(httpRequestUrl);
               tmpHttpClient.Encoding = tmpHttpEncoding;

               var tmpRestResponse = tmpHttpClient.Execute(tmpHttpRequest);
               if (tmpRestResponse != null)
               {
                    tmpHttpResponse.Cookies = tmpRestResponse.Cookies;
                    tmpHttpResponse.Headers = tmpRestResponse.Headers;
                    tmpHttpResponse.Content = tmpRestResponse.Content;
                    tmpHttpResponse.StatusCode = tmpRestResponse.StatusCode;
                    tmpHttpResponse.ContentType = tmpRestResponse.ContentType;
                    tmpHttpResponse.ContentLength = tmpRestResponse.ContentLength;
                    tmpHttpResponse.ResponseStatus = tmpRestResponse.ResponseStatus;
                    tmpHttpResponse.ContentEncoding = tmpRestResponse.ContentEncoding;
                    tmpHttpResponse.StatusDescription = tmpRestResponse.StatusDescription;

                    switch (tmpRestResponse.StatusCode)
                    {
                         case HttpStatusCode.OK:
                         case HttpStatusCode.Created:
                         case HttpStatusCode.Accepted:
                         case HttpStatusCode.NoContent:
                         case HttpStatusCode.ResetContent:
                         case HttpStatusCode.PartialContent:
                         case HttpStatusCode.NonAuthoritativeInformation:
                              tmpHttpResponse.Data = tmpRestResponse.RawBytes;
                              break;

                         case HttpStatusCode.BadRequest:
                         case HttpStatusCode.Unauthorized:
                         case HttpStatusCode.PaymentRequired:
                         case HttpStatusCode.Forbidden:
                         case HttpStatusCode.NotFound:
                         case HttpStatusCode.MethodNotAllowed:
                         case HttpStatusCode.NotAcceptable:
                         case HttpStatusCode.ProxyAuthenticationRequired:
                         case HttpStatusCode.RequestTimeout:
                         case HttpStatusCode.Conflict:
                         case HttpStatusCode.Gone:
                         case HttpStatusCode.LengthRequired:
                         case HttpStatusCode.PreconditionFailed:
                         case HttpStatusCode.RequestEntityTooLarge:
                         case HttpStatusCode.RequestUriTooLong:
                         case HttpStatusCode.UnsupportedMediaType:
                         case HttpStatusCode.RequestedRangeNotSatisfiable:
                         case HttpStatusCode.ExpectationFailed:

                         case HttpStatusCode.InternalServerError:
                         case HttpStatusCode.NotImplemented:
                         case HttpStatusCode.BadGateway:
                         case HttpStatusCode.ServiceUnavailable:
                         case HttpStatusCode.GatewayTimeout:
                         case HttpStatusCode.HttpVersionNotSupported:
                         default:
                              tmpHttpResponse.Code = (int)tmpRestResponse.StatusCode;
                              tmpHttpResponse.Message = tmpRestResponse.ErrorMessage == null ? tmpRestResponse.Content : tmpRestResponse.ErrorMessage;
                              break;
                    }
               }

               return tmpHttpResponse;
          }
     }
}