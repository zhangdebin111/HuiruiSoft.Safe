
namespace HuiruiSoft.Safe.ORM
{
     /// <summary>定义账户扩展信息的模型类。</summary>
     public class AccountAttributeEntity : System.ICloneable
     {
          /// <summary>返回或设置账户扩展信息Id，唯一标识。</summary>
          public int AttributeId
          {
               get;
               set;
          }

          /// <summary>返回或设置账户扩展信息顺序号。</summary>
          public int AccountId
          {
               get;
               set;
          }

          /// <summary>返回或设置账户扩展信息顺序号。</summary>
          public short Order
          {
               get;
               set;
          }

          /// <summary>返回或设置扩展信息是否加密存储: 0, 不加密; 1, 加密。</summary>
          public bool Encrypted
          {
               get;
               set;
          }

          /// <summary>返回或设置扩展信息名称。</summary>
          public string Name
          {
               get;
               set;
          }

          /// <summary>返回或设置扩展信息值。</summary>
          public string Value
          {
               get;
               set;
          }

          public AccountAttributeEntity()
          {
               //
          }

          /// <summary>返回扩展信息对象的哈希代码。</summary>
          /// <returns>返回扩展信息对象的哈希代码。</returns>
          public override int GetHashCode()
          {
               return this.AttributeId.GetHashCode() ^ this.Name.GetHashCode();
          }

          /// <summary>返回表示扩展信息对象文本内容。</summary>
          /// <returns>string，表示扩展信息对象的文本内容。</returns>
          public override string ToString()
          {
               return string.Format("Name:{0}\r\nValue:{1}", this.Name, this.Value);
          }

          public virtual object Clone()
          {
               return new AccountAttributeEntity()
               {
                    AccountId = this.AccountId,
                    AttributeId = this.AttributeId,
                    Order = this.Order,
                    Name = this.Name,
                    Value = this.Value,
                    Encrypted = this.Encrypted,
               };
          }

          /// <summary>确定指定的 AccountProfile 是否等于当前的 AccountProfile。</summary>
          /// <param name="object">与当前的 AccountProfile 进行比较的 AccountProfile。</param>
          /// <returns>如果指定的 AccountProfile 等于当前的 AccountProfile，则为 true；否则为 false。</returns>
          public override bool Equals(object @object)
          {
               if (!(@object is AccountAttributeEntity))
               {
                    return false;
               }
               else
               {
                    var tmpAttribute = (AccountAttributeEntity)@object;

                    return
                         tmpAttribute.AttributeId == this.AttributeId &&
                         tmpAttribute.AccountId == this.AccountId &&
                         tmpAttribute.Encrypted == this.Encrypted &&
                         tmpAttribute.Order == this.Order &&
                         tmpAttribute.Name == this.Name &&
                         tmpAttribute.Value == this.Value;
               }
          }
     }
}