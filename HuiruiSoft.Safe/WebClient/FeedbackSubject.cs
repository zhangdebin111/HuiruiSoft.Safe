namespace HuiruiSoft.Safe.Model
{
     public class FeedbackSubject
     {
          public int SubjectId
          {
               get; set;
          }

          public int AppCode
          {
               get; set;
          }

          public int Order
          {
               get; set;
          }

          public string Subject
          {
               get; set;
          }

          public virtual string Description
          {
               get; set;
          }
     }
}
