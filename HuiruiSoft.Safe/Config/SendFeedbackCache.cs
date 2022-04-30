using HuiruiSoft.Safe.Model;
using System.Collections.Generic;

namespace HuiruiSoft.Safe
{
     public sealed class SendFeedbackCache
     {
          public IList<FeedbackSubject> FeedbackSubjects
          {
               get;
               set;
          }

          public IList<RestSharp.RestResponseCookie> Cookies
          {
               get;
               set;
          }
     }
}