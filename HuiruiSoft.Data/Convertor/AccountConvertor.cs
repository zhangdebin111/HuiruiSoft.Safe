using System.Collections.Generic;
using HuiruiSoft.Safe.ORM;
using HuiruiSoft.Safe.Model;
using HuiruiSoft.Security.Cryptography;

namespace HuiruiSoft.Safe.Convertor
{
     public static class AccountConvertor
     {
          public static List<AccountModel> Convert(string encryptKey, List<AccountEntity> entities)
          {
               var tmpAccountModels = new List<AccountModel>();
               if (entities != null)
               {
                    foreach (var entity in entities)
                    {
                         tmpAccountModels.Add(Convert(encryptKey, entity));
                    }
               }

               return tmpAccountModels;
          }

          public static List<AccountEntity> Convert(string encryptKey, List<AccountModel> accounts)
          {
               var tmpCatalogEntities = new List<AccountEntity>();
               if (accounts != null)
               {
                    foreach (var account in accounts)
                    {
                         tmpCatalogEntities.Add(Convert(encryptKey, account));
                    }
               }

               return tmpCatalogEntities;
          }

          public static AccountModel Convert(string encryptKey, AccountEntity entity)
          {
               AccountModel tmpAccountModel = null;
               if (entity != null)
               {
                    tmpAccountModel = new AccountModel();

                    tmpAccountModel.AccountId = entity.AccountId;
                    tmpAccountModel.AccountGuid = entity.AccountGuid;
                    tmpAccountModel.CatalogId = entity.CatalogId;
                    tmpAccountModel.Name = entity.Name;
                    tmpAccountModel.URL = entity.URL;
                    tmpAccountModel.Order = entity.Order;
                    tmpAccountModel.TopMost = entity.TopMost;
                    tmpAccountModel.Deleted = entity.Deleted;
                    tmpAccountModel.VersionNo = entity.VersionNo;

                    if (System.Enum.IsDefined(typeof(SecretRank), entity.SecretRank))
                    {
                         tmpAccountModel.SecretRank = (SecretRank)entity.SecretRank;
                    }

                    tmpAccountModel.Email = EncryptorHelper.DESDecrypt(encryptKey, entity.Email);
                    tmpAccountModel.Mobile = EncryptorHelper.DESDecrypt(encryptKey, entity.Mobile);
                    tmpAccountModel.LoginName = EncryptorHelper.DESDecrypt(encryptKey, entity.LoginName);
                    tmpAccountModel.Password = EncryptorHelper.DESDecrypt(encryptKey, entity.Password);

                    tmpAccountModel.CreateTime = entity.CreateTime;
                    tmpAccountModel.UpdateTime = entity.UpdateTime;
                    tmpAccountModel.Comment = entity.Comment;
               }

               return tmpAccountModel;
          }

          public static AccountEntity Convert(string encryptKey, AccountModel account)
          {
               AccountEntity tmpAccountEntity = null;
               if (account != null)
               {
                    tmpAccountEntity = new AccountEntity();

                    tmpAccountEntity.AccountId = account.AccountId;
                    tmpAccountEntity.AccountGuid = account.AccountGuid;
                    tmpAccountEntity.CatalogId = account.CatalogId;
                    tmpAccountEntity.Name = account.Name;
                    tmpAccountEntity.URL = account.URL;
                    tmpAccountEntity.Order = account.Order;
                    tmpAccountEntity.TopMost = account.TopMost;
                    tmpAccountEntity.Deleted = account.Deleted;
                    tmpAccountEntity.VersionNo = account.VersionNo;
                    tmpAccountEntity.SecretRank = (ushort)account.SecretRank;

                    tmpAccountEntity.Email = EncryptorHelper.DESEncrypt(encryptKey, account.Email);
                    tmpAccountEntity.Mobile = EncryptorHelper.DESEncrypt(encryptKey, account.Mobile);
                    tmpAccountEntity.LoginName = EncryptorHelper.DESEncrypt(encryptKey, account.LoginName);
                    tmpAccountEntity.Password = EncryptorHelper.DESEncrypt(encryptKey, account.Password);

                    tmpAccountEntity.CreateTime = account.CreateTime;
                    tmpAccountEntity.UpdateTime = account.UpdateTime;
                    tmpAccountEntity.Comment = account.Comment;
               }

               return tmpAccountEntity;
          }

          public static AccountAttributeEntity ConvertAttribute(string encryptKey, AccountAttribute attribute)
          {
               AccountAttributeEntity tmpAttributeEntity = null;
               if (attribute != null)
               {
                    tmpAttributeEntity = new AccountAttributeEntity();
                    tmpAttributeEntity.AttributeId = attribute.AttributeId;
                    tmpAttributeEntity.Order = attribute.Order;
                    tmpAttributeEntity.Name = attribute.Name;
                    tmpAttributeEntity.AccountId = attribute.AccountId;
                    tmpAttributeEntity.Encrypted = attribute.Encrypted;

                    if (!tmpAttributeEntity.Encrypted)
                    {
                         tmpAttributeEntity.Value = attribute.Value;
                    }
                    else
                    {
                         tmpAttributeEntity.Value = EncryptorHelper.DESEncrypt(encryptKey, attribute.Value);
                    }
               }

               return tmpAttributeEntity;
          }

          public static AccountAttribute ConvertAttribute(string encryptKey, AccountAttributeEntity entity)
          {
               AccountAttribute tmpAttribute = null;
               if (entity != null)
               {
                    tmpAttribute = new AccountAttribute();
                    tmpAttribute.AttributeId = entity.AttributeId;
                    tmpAttribute.Order = entity.Order;
                    tmpAttribute.Name = entity.Name;
                    tmpAttribute.AccountId = entity.AccountId;
                    tmpAttribute.Encrypted = entity.Encrypted;

                    if (!tmpAttribute.Encrypted)
                    {
                         tmpAttribute.Value = entity.Value;
                    }
                    else
                    {
                         tmpAttribute.Value = EncryptorHelper.DESDecrypt(encryptKey, entity.Value);
                    }
               }

               return tmpAttribute;
          }
     }
}