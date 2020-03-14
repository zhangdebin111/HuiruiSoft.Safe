
namespace HuiruiSoft.Safe.ORM
{
     /// <summary>
     ///    �����˺�Ŀ¼�����ģ�͡�
     /// </summary>
     public class AccountCatalogEntity : System.ICloneable
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

          /// <summary>���ػ�����Ŀ¼��ȡ�</summary>
          public int Depth
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

          public AccountCatalogEntity()
          {
               //
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
               return new AccountCatalogEntity()
               {
                    CatalogId = this.CatalogId,
                    Name = this.Name,
                    Order = this.Order,
                    Depth = this.Depth,
                    ParentId = this.ParentId,
                    VersionNo = this.VersionNo,
                    CreateTime = this.CreateTime,
                    UpdateTime = this.UpdateTime,
                    Description = this.Description
               };
          }

          /// <summary>ȷ��ָ���� AccountCatalogEntity �Ƿ���ڵ�ǰ�� AccountCatalogEntity��</summary>
          /// <param name="object">�뵱ǰ�� AccountCatalogEntity ���бȽϵ� AccountCatalogEntity��</param>
          /// <returns>���ָ���� AccountCatalogEntity ���ڵ�ǰ�� AccountCatalogEntity����Ϊ true������Ϊ false��</returns>
          public override bool Equals(object @object)
          {
               if (!(@object is AccountCatalogEntity))
               {
                    return false;
               }
               else
               {
                    var tmpCatalogEntity = (AccountCatalogEntity)@object;

                    return
                         tmpCatalogEntity.CatalogId == this.CatalogId &&
                         tmpCatalogEntity.Name == this.Name &&
                         tmpCatalogEntity.Order == this.Order &&
                         tmpCatalogEntity.Depth == this.Depth &&
                         tmpCatalogEntity.ParentId == this.ParentId &&
                         tmpCatalogEntity.VersionNo == this.VersionNo &&
                         tmpCatalogEntity.CreateTime == this.CreateTime &&
                         tmpCatalogEntity.UpdateTime == this.UpdateTime &&
                         tmpCatalogEntity.Description == this.Description;
               }
          }
     }
}