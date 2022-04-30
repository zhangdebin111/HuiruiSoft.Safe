using HuiruiSoft.Safe.Model;
using System.Collections.Generic;

namespace HuiruiSoft.Safe.Net
{
     internal class SoftFeedbackClient : HttpRequestApi
     {
          internal SoftFeedbackClient()
          {
               //
          }

          public HttpDataResponse<IList<FeedbackSubject>> GetAppFeedbackSubjects(int appCode)
          {
               var parameters = new List<RestSharp.Parameter>();
               parameters.Add(new RestSharp.Parameter() { Name = "appCode", Value = appCode, Type = RestSharp.ParameterType.QueryString });

               var tmpHttpRequestApi = new HttpRequestApi();
               if (Program.FeedbackCache.Cookies != null)
               {
                    tmpHttpRequestApi.Cookies = Program.FeedbackCache.Cookies;
               }

               return tmpHttpRequestApi.Execute<IList<FeedbackSubject>>(Program.FeedbackApiConfig.GetFeedbackSubjects, parameters, RestSharp.Method.GET);
          }

          internal HttpDataResponse<bool> SendFeedback(SoftFeedbackModel feedback)
          {
               var parameters = new List<RestSharp.Parameter>();
               parameters.Add(new RestSharp.Parameter() { Name = RequestBodyName, Value = feedback, Type = RestSharp.ParameterType.RequestBody });

               var tmpHttpRequestApi = new HttpRequestApi();
               if (Program.FeedbackCache.Cookies != null)
               {
                    tmpHttpRequestApi.Cookies = Program.FeedbackCache.Cookies;
               }

               return tmpHttpRequestApi.Execute<bool>(Program.FeedbackApiConfig.SendFeedback, parameters);
          }

          internal HttpDataResponse<bool> CheckImageAuthCode(string imageCode)
          {
               var parameters = new List<RestSharp.Parameter>();
               parameters.Add(new RestSharp.Parameter() { Name = "imageCode", Value = imageCode, Type = RestSharp.ParameterType.QueryString });

               var tmpHttpRequestApi = new HttpRequestApi();
               if (Program.FeedbackCache.Cookies != null)
               {
                    tmpHttpRequestApi.Cookies = Program.FeedbackCache.Cookies;
               }

               return tmpHttpRequestApi.Execute<bool>(Program.FeedbackApiConfig.CheckImageCode, parameters);
          }

          internal HttpDataResponse<byte[]> GetImageAuthCode()
          {
               var tmpHttpRequestApi = new HttpRequestApi();
               if (Program.FeedbackCache.Cookies != null)
               {
                    tmpHttpRequestApi.Cookies = Program.FeedbackCache.Cookies;
               }
               return tmpHttpRequestApi.ExecuteStream(Program.FeedbackApiConfig.CreateImageCode, null, RestSharp.Method.GET);
          }
     }
}