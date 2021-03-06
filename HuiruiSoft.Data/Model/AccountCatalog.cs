
namespace HuiruiSoft.Safe.Model
{
     /// <summary>
     ///    定义账号目录管理的模型。
     /// </summary>
     public class AccountCatalog : System.ICloneable
     {
          /// <summary>返回或设置目录编码。</summary>
          public int CatalogId
          {
               get;
               set;
          }

          /// <summary>返回或设置目录名称。</summary>
          public string Name
          {
               get;
               set;
          }

          /// <summary>返回或设置上级目录编码。</summary>
          public int ParentId
          {
               get;
               set;
          }

          /// <summary>返回或设置目录序号。</summary>
          public int Order
          {
               get;
               set;
          }

          /// <summary>返回或设置目录深度。</summary>
          public int Depth
          {
               get;
               set;
          }

          /// <summary>返回或设置数据版本号。</summary>
          public virtual int VersionNo
          {
               get; set;
          }

          /// <summary>返回或设置目录创建时间。</summary>
          public System.DateTime CreateTime
          {
               get;
               set;
          }

          /// <summary>返回或设置目录最后更新时间。</summary>
          public System.DateTime UpdateTime
          {
               get;
               set;
          }

          /// <summary>返回或设置目录的描述信息。</summary>
          public string Description
          {
               get;
               set;
          }

          /// <summary>返回表示当前目录对象文本内容。</summary>
          /// <returns>string，表示当前的目录对象的文本内容。</returns>
          public override string ToString()
          {
               return string.Format("{0}:{1}", this.CatalogId, this.Name);
          }

          /// <summary>返回当前目录对象的哈希代码。</summary>
          /// <returns>返回当前目录对象的哈希代码。</returns>
          public override int GetHashCode()
          {
               return this.CatalogId.GetHashCode() ^ this.Name.GetHashCode();
          }

          public virtual object Clone()
          {
               return new AccountCatalog()
               {
                    CatalogId = this.CatalogId,
                    Name = this.Name,
                    Order = this.Order,
                    Depth = this.Depth,
                    ParentId = this.ParentId,
                    Description = this.Description,
                    CreateTime = this.CreateTime,
                    UpdateTime = this.UpdateTime
               };
          }

          /// <summary>确定指定的 AccountCatalog 是否等于当前的 AccountCatalog。</summary>
          /// <param name="object">与当前的 AccountCatalog 进行比较的 AccountCatalog。</param>
          /// <returns>如果指定的 AccountCatalog 等于当前的 AccountCatalog，则为 true；否则为 false。</returns>
          public override bool Equals(object @object)
          {
               if (!(@object is AccountCatalog))
               {
                    return false;
               }
               else
               {
                    var tmpCatalog = (AccountCatalog)@object;

                    return
                         tmpCatalog.CatalogId == this.CatalogId &&
                         tmpCatalog.Name == this.Name &&
                         tmpCatalog.Order == this.Order &&
                         tmpCatalog.Depth == this.Depth &&
                         tmpCatalog.ParentId == this.ParentId &&
                         tmpCatalog.Description == this.Description &&
                         tmpCatalog.CreateTime == this.CreateTime &&
                         tmpCatalog.UpdateTime == this.UpdateTime;
               }
          }
     }
}