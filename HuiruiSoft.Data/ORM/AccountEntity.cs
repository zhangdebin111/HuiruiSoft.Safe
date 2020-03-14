
namespace HuiruiSoft.Safe.ORM
{
     /// <summary>定义账户基本信息的模型类。</summary>
     public class AccountEntity : System.ICloneable
     {
          /// <summary>获取或设置一个值，该值指示账号Id。</summary>
          public int AccountId
          {
               get;
               set;
          }

          /// <summary>获取或设置一个值，该值指示账号Guid。</summary>
          public string AccountGuid
          {
               get;
               set;
          }

          /// <summary>返回或设置目录编码。</summary>
          public int CatalogId
          {
               get;
               set;
          }

          /// <summary>获取或设置一个值，该值指示账号名称。</summary>
          public string Name
          {
               get;
               set;
          }

          /// <summary>返回或设置固顶级别。</summary>
          public short TopMost
          {
               get;
               set;
          }

          /// <summary>返回或设置是否删除状态。</summary>
          public bool Deleted
          {
               get;
               set;
          }

          /// <summary>返回或设置账户排列序号。</summary>
          public int Order
          {
               get;
               set;
          }

          /// <summary>返回或设置账户秘密等级。</summary>
          public ushort SecretRank
          {
               get;
               set;
          }

          /// <summary>获取或设置一个值，该值指示账号的网站网址。</summary>
          public string URL
          {
               get;
               set;
          }

          /// <summary>获取或设置一个值，该值指示登录账号。</summary>
          public string LoginName
          {
               get;
               set;
          }

          /// <summary>获取或设置一个值，该值指示登录密码。</summary>
          public string Password
          {
               get;
               set;
          }
          
          /// <summary>获取或设置一个值，该值指示账号的电子邮件。</summary>
          public string Email
          {
               get;
               set;
          }

          /// <summary>获取或设置一个值，该值指示账号的手机号码。</summary>
          public string Mobile
          {
               get;
               set;
          }

          /// <summary>返回或设置数据版本号。</summary>
          public virtual int VersionNo
          {
               get; set;
          }

          /// <summary>获取或设置一个值，该值指示该记录信息的创建时间。</summary>
          public System.DateTime CreateTime
          {
               get;
               set;
          }

          /// <summary>获取或设置一个值，该值指示该记录信息的修改时间。</summary>
          public System.DateTime UpdateTime
          {
               get;
               set;
          }

          /// <summary>获取或设置一个值，该值指示该记录信息的的备注信息。</summary>
          public string Comment
          {
               get;
               set;
          }

          public AccountEntity( )
          {
               this.CreateTime = System.DateTime.Now;
               this.UpdateTime = System.DateTime.Now;
          }

          /// <summary>返回当前账户信息对象的哈希代码。</summary>
          /// <returns>返回当前账户信息对象的哈希代码。</returns>
          public override int GetHashCode( )
          {
               return this.AccountId.GetHashCode( )^ this.AccountGuid.GetHashCode( )^this.Name.GetHashCode( );
          }

          /// <summary>返回表示当前账户信息对象文本内容。</summary>
          /// <returns>string，表示当前的账户信息对象的文本内容。</returns>
          public override string ToString( )
          {
               return string.Format("{0}:{1}", this.AccountGuid, this.Name);
          }

          public virtual object Clone( )
          {
               return new AccountEntity( )
               {
                    AccountId = this.AccountId,
                    AccountGuid = this.AccountGuid,
                    CatalogId = this.CatalogId,
                    Name = this.Name,
                    URL = this.URL,
                    Order = this.Order,
                    Email = this.Email,
                    Mobile = this.Mobile,
                    TopMost = this.TopMost,
                    Deleted = this.Deleted,
                    LoginName = this.LoginName,
                    Password = this.Password,
                    SecretRank = this.SecretRank,
                    VersionNo = this.VersionNo,
                    CreateTime = this.CreateTime,
                    UpdateTime = this.UpdateTime,
                    Comment = this.Comment
               };
          }

          /// <summary>确定指定的 AccountEntity 是否等于当前的 AccountEntity。</summary>
          /// <param name="object">与当前的 AccountEntity 进行比较的 AccountEntity。</param>
          /// <returns>如果指定的 AccountEntity 等于当前的 AccountEntity，则为 true；否则为 false。</returns>
          public override bool Equals(object @object)
          {
               if (!(@object is AccountEntity))
               {
                    return false;
               }
               else
               {
                    var entity = (AccountEntity)@object;

                    return
                         entity.AccountId == this.AccountId &&
                         entity.AccountGuid == this.AccountGuid &&
                         entity.CatalogId == this.CatalogId &&
                         entity.Name == this.Name &&
                         entity.URL == this.URL &&
                         entity.Order == this.Order &&
                         entity.Email == this.Email &&
                         entity.Mobile == this.Mobile &&
                         entity.TopMost == this.TopMost &&
                         entity.Deleted == this.Deleted &&
                         entity.LoginName == this.LoginName &&
                         entity.Password == this.Password &&
                         entity.SecretRank == this.SecretRank &&
                         entity.VersionNo == this.VersionNo &&
                         entity.CreateTime == this.CreateTime &&
                         entity.UpdateTime == this.UpdateTime &&
                         entity.Comment == this.Comment;
               }
          }
     }
}