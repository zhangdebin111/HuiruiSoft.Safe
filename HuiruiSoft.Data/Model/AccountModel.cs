
namespace HuiruiSoft.Safe.Model
{
     /// <summary>定义账户基本信息模型类。</summary>
     public class AccountModel : System.ICloneable
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

          /// <summary>获取或设置一个值，该值指示账号排列序号。</summary>
          public int Order
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

          /// <summary>返回或设置账户秘密等级。</summary>
          public SecretRank SecretRank
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

          private System.Collections.Generic.List<AccountAttribute> attributeItems = null;

          public System.Collections.Generic.List<AccountAttribute> Attributes
          {
               get
               {
                    if(this.attributeItems == null)
                    {
                         this.attributeItems = new System.Collections.Generic.List<AccountAttribute>( );
                    }

                    return this.attributeItems;
               }
          }

          public AccountModel( )
          {
               this.CreateTime = System.DateTime.Now;
               this.UpdateTime = System.DateTime.Now;
          }

          /// <summary>返回当前账户信息对象的哈希代码。</summary>
          /// <returns>返回当前账户信息对象的哈希代码。</returns>
          public override int GetHashCode( )
          {
               return this.AccountId.GetHashCode( ) ^ this.AccountGuid.GetHashCode( ) ^ this.CatalogId.GetHashCode( )^ this.Name.GetHashCode( );
          }

          /// <summary>返回表示当前账户信息对象文本内容。</summary>
          /// <returns>string，表示当前的账户信息对象的文本内容。</returns>
          public override string ToString( )
          {
               return string.Format("{0}:{1}", this.AccountGuid, this.Name);
          }

          public virtual object Clone( )
          {
               var tmpCloneObject = new AccountModel( )
               {
                    AccountId = this.AccountId,
                    AccountGuid = this.AccountGuid,
                    CatalogId = this.CatalogId,
                    Name = this.Name,
                    Email = this.Email,
                    Mobile = this.Mobile,
                    Order = this.Order,
                    TopMost = this.TopMost,
                    Deleted = this.Deleted,
                    LoginName = this.LoginName,
                    Password = this.Password,
                    SecretRank = this.SecretRank,
                    URL = this.URL,
                    VersionNo = this.VersionNo,
                    CreateTime = this.CreateTime,
                    UpdateTime = this.UpdateTime,
                    Comment = this.Comment
               };

               this.Attributes.ForEach(item =>
               {
                    var tmpAttribute = (AccountAttribute)(item.Clone());
                    tmpAttribute.AccountId = this.AccountId;
                    tmpCloneObject.Attributes.Add(tmpAttribute);
               });

               return tmpCloneObject;
          }

          public bool CompareTo(AccountModel another)
          {
               if (another == null)
               {
                    return false;
               }

               var tmpCompareResult =
                    this.AccountGuid == another.AccountGuid &&
                    this.CatalogId == another.CatalogId &&
                    this.Name == another.Name &&
                    this.Email == another.Email &&
                    this.Mobile == another.Mobile &&
                    this.Order == another.Order &&
                    this.TopMost == another.TopMost &&
                    this.Deleted == another.Deleted &&
                    this.LoginName == another.LoginName &&
                    this.Password == another.Password &&
                    this.SecretRank == another.SecretRank &&
                    this.Comment == another.Comment;

               if (!tmpCompareResult)
               {
                    return false;
               }

               if (this.Attributes.Count != another.Attributes.Count)
               {
                    return false;
               }
               else
               {
                    for (int index = 0; index < this.Attributes.Count; index++)
                    {
                         if (!this.Attributes[index].CompareTo(another.Attributes[index]))
                         {
                              return false;
                         }
                    }
               }

               return true;
          }

          /// <summary>确定指定的 AccountModel 是否等于当前的 AccountModel。</summary>
          /// <param name="object">与当前的 AccountModel 进行比较的 AccountModel。</param>
          /// <returns>如果指定的 AccountModel 等于当前的 AccountModel，则为 true；否则为 false。</returns>
          public override bool Equals(object @object)
          {
               if (!(@object is AccountModel))
               {
                    return false;
               }
               else
               {
                    var account = (AccountModel)@object;

                    return
                         account.AccountId == this.AccountId &&
                         account.AccountGuid == this.AccountGuid &&
                         account.CatalogId == this.CatalogId &&
                         account.Name == this.Name &&
                         account.Email == this.Email &&
                         account.Mobile == this.Mobile &&
                         account.Order == this.Order &&
                         account.TopMost == this.TopMost &&
                         account.Deleted == this.Deleted &&
                         account.LoginName == this.LoginName &&
                         account.Password == this.Password &&
                         account.SecretRank == this.SecretRank &&
                         account.VersionNo == this.VersionNo &&
                         account.CreateTime == this.CreateTime &&
                         account.UpdateTime == this.UpdateTime &&
                         account.Comment == this.Comment;
               }
          }
     }
}