namespace HuiruiSoft.Safe.Model
{
     using Newtonsoft.Json;

     public class SoftFeedbackModel
     {
          [JsonProperty(PropertyName = "feedbackId")]
          public int FeedbackId
          {
               get; set;
          }

          [JsonProperty(PropertyName = "userName")]
          public string UserName
          {
               get; set;
          }


          [JsonProperty(PropertyName = "contactWay")]
          public virtual ContactWays ContactWay
          {
               get;
               set;
          }

          [JsonProperty(PropertyName = "contactNo")]
          public string ContactNo
          {
               get; set;
          }

          [JsonProperty(PropertyName = "appCode")]
          public int AppCode
          {
               get; set;
          }

          [JsonProperty(PropertyName = "versionNo")]
          public string VersionNo
          {
               get; set;
          }

          [JsonProperty(PropertyName = "subjectId")]
          public int SubjectId
          {
               get; set;
          }

          /// <summary>
          /// 用户终端: 0-网站; 1-WAP; 2-PC 客户端; 3-iOS; 4-Android
          /// </summary>
          [JsonProperty(PropertyName = "userClient")]
          public ClientUserAgents UserClient
          {
               get; set;
          }

          [JsonProperty(PropertyName = "sessionId")]
          public string SessionId
          {
               get; set;
          }

          [JsonProperty(PropertyName = "description")]
          public virtual string Description
          {
               get; set;
          }

          [JsonProperty(PropertyName = "imageAuthCode")]
          public virtual string ImageAuthCode
          {
               get; set;
          }
     }
}
