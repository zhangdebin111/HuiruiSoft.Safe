
namespace HuiruiSoft.Safe.Model
{
     /// <summary>
     ///    �����˺�Ŀ¼�����ģ�͡�
     /// </summary>
     public class AccountCatalog : System.ICloneable
     {
          /// <summary>���ػ�����Ŀ¼���롣</summary>
          public int CatalogId
          {
               get;
               set;
          }

          /// <summary>���ػ�����Ŀ¼���ơ�</summary>
          public string Name
          {
               get;
               set;
          }

          /// <summary>���ػ������ϼ�Ŀ¼���롣</summary>
          public int ParentId
          {
               get;
               set;
          }

          /// <summary>���ػ�����Ŀ¼��š�</summary>
          public int Order
          {
               get;
               set;
          }

          /// <summary>���ػ�����Ŀ¼��ȡ�</summary>
          public int Depth
          {
               get;
               set;
          }

          /// <summary>���ػ��������ݰ汾�š�</summary>
          public virtual int VersionNo
          {
               get; set;
          }

          /// <summary>���ػ�����Ŀ¼����ʱ�䡣</summary>
          public System.DateTime CreateTime
          {
               get;
               set;
          }

          /// <summary>���ػ�����Ŀ¼������ʱ�䡣</summary>
          public System.DateTime UpdateTime
          {
               get;
               set;
          }

          /// <summary>���ػ�����Ŀ¼��������Ϣ��</summary>
          public string Description
          {
               get;
               set;
          }

          /// <summary>���ر�ʾ��ǰĿ¼�����ı����ݡ�</summary>
          /// <returns>string����ʾ��ǰ��Ŀ¼������ı����ݡ�</returns>
          public override string ToString()
          {
               return string.Format("{0}:{1}", this.CatalogId, this.Name);
          }

          /// <summary>���ص�ǰĿ¼����Ĺ�ϣ���롣</summary>
          /// <returns>���ص�ǰĿ¼����Ĺ�ϣ���롣</returns>
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

          /// <summary>ȷ��ָ���� AccountCatalog �Ƿ���ڵ�ǰ�� AccountCatalog��</summary>
          /// <param name="object">�뵱ǰ�� AccountCatalog ���бȽϵ� AccountCatalog��</param>
          /// <returns>���ָ���� AccountCatalog ���ڵ�ǰ�� AccountCatalog����Ϊ true������Ϊ false��</returns>
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