using System.Xml;
using System.Collections.Generic;
using HuiruiSoft.Utils;
using HuiruiSoft.Safe.Model;

namespace HuiruiSoft.Safe.Exchange
{
     public class ImportAccountHelper
     {
          public static List<AccountCatalog> ReadAccountCatalogs(string fileName)
          {
               List<AccountCatalog> tmpAccountCatalogs = null;

               var tmpImportDocument = new XmlDocument();
               tmpImportDocument.Load(fileName);
               var tmpAccountNodes = tmpImportDocument.SelectNodes("Account//Catalog");
               if (tmpAccountNodes != null)
               {
                    tmpAccountCatalogs = new List<AccountCatalog>();
                    foreach (XmlElement tmpCatalogNode in tmpAccountNodes)
                    {
                         var tmpCatalogInfo = new AccountCatalog();

                         tmpCatalogInfo.CatalogId = XmlDocumentHelper.GetAttributeValue(tmpCatalogNode, "id", 0);
                         tmpCatalogInfo.ParentId = XmlDocumentHelper.GetAttributeValue(tmpCatalogNode, "ParentId", -1);
                         tmpCatalogInfo.Name = XmlDocumentHelper.GetAttributeString(tmpCatalogNode, "Name");
                         tmpCatalogInfo.Order = XmlDocumentHelper.GetAttributeValue(tmpCatalogNode, "Order", 0);
                         tmpCatalogInfo.Depth = XmlDocumentHelper.GetAttributeValue(tmpCatalogNode, "Depth", 1);
                         tmpCatalogInfo.VersionNo = XmlDocumentHelper.GetAttributeValue(tmpCatalogNode, "Version", 1);
                         tmpCatalogInfo.CreateTime = XmlDocumentHelper.GetAttributeValue(tmpCatalogNode, "CreateTime");
                         tmpCatalogInfo.UpdateTime = XmlDocumentHelper.GetAttributeValue(tmpCatalogNode, "UpdateTime");

                         tmpAccountCatalogs.Add(tmpCatalogInfo);
                    }
               }

               return tmpAccountCatalogs;
          }

          public static List<AccountModel> ReadAccountModels(string fileName)
          {
               List<AccountModel> tmpAccountModels = null;

               var tmpImportDocument = new XmlDocument();
               tmpImportDocument.Load(fileName);
               var tmpAccountNodes = tmpImportDocument.SelectNodes("Account//item");
               if (tmpAccountNodes != null)
               {
                    tmpAccountModels = new List<AccountModel>();
                    foreach (XmlElement tmpAccountNode in tmpAccountNodes)
                    {
                         var tmpAccountInfo = new AccountModel();

                         tmpAccountInfo.AccountId = XmlDocumentHelper.GetAttributeValue(tmpAccountNode, "id", 0);
                         tmpAccountInfo.CatalogId = XmlDocumentHelper.GetAttributeValue(tmpAccountNode, "CatalogId", 0);
                         tmpAccountInfo.AccountGuid = XmlDocumentHelper.GetAttributeString(tmpAccountNode, "Guid");
                         tmpAccountInfo.Name = XmlDocumentHelper.GetAttributeString(tmpAccountNode, "Name", null);
                         tmpAccountInfo.Order = XmlDocumentHelper.GetAttributeValue(tmpAccountNode, "Order", 0);
                         tmpAccountInfo.URL = XmlDocumentHelper.GetAttributeString(tmpAccountNode, "URL", null);
                         tmpAccountInfo.LoginName = XmlDocumentHelper.GetAttributeString(tmpAccountNode, "LoginName", null);
                         tmpAccountInfo.Password = XmlDocumentHelper.GetAttributeString(tmpAccountNode, "Password", null);
                         tmpAccountInfo.Email = XmlDocumentHelper.GetAttributeString(tmpAccountNode, "Email", null);
                         tmpAccountInfo.Mobile = XmlDocumentHelper.GetAttributeString(tmpAccountNode, "Mobile", null);
                         tmpAccountInfo.Deleted = XmlDocumentHelper.GetAttributeValue(tmpAccountNode, "Delete", false);
                         tmpAccountInfo.TopMost = (short)XmlDocumentHelper.GetAttributeValue(tmpAccountNode, "TopMost", 0);
                         tmpAccountInfo.VersionNo = XmlDocumentHelper.GetAttributeValue(tmpAccountNode, "Version", 1);
                         tmpAccountInfo.SecretRank = XmlDocumentHelper.GetAttributeValue(tmpAccountNode, "SecretRank", SecretRank.绝密);
                         tmpAccountInfo.CreateTime = XmlDocumentHelper.GetAttributeValue(tmpAccountNode, "CreateTime");
                         tmpAccountInfo.UpdateTime = XmlDocumentHelper.GetAttributeValue(tmpAccountNode, "UpdateTime");

                         var tmpComment = XmlDocumentHelper.GetNodeInnerString(tmpAccountNode, "Comment");
                         if (!string.IsNullOrEmpty(tmpComment))
                         {
                              tmpAccountInfo.Comment = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(tmpComment));
                         }

                         var tmpAttributeNodes = tmpAccountNode.SelectNodes("Attributes/Attribute");
                         if (tmpAttributeNodes != null)
                         {
                              foreach (XmlElement tmpAttributeNode in tmpAttributeNodes)
                              {
                                   var tmpAttribute = new AccountAttribute();
                                   tmpAttribute.AccountId = tmpAccountInfo.AccountId;
                                   tmpAttribute.AttributeId = XmlDocumentHelper.GetAttributeValue(tmpAttributeNode, "Id", 0);
                                   tmpAttribute.Order = (short)XmlDocumentHelper.GetAttributeValue(tmpAttributeNode, "Order", 0);
                                   tmpAttribute.Encrypted = XmlDocumentHelper.GetAttributeValue(tmpAttributeNode, "Encrypted", false);
                                   tmpAttribute.Name = XmlDocumentHelper.GetAttributeString(tmpAttributeNode, "Name", string.Empty);
                                   tmpAttribute.Value = tmpAttributeNode.InnerText;

                                   tmpAccountInfo.Attributes.Add(tmpAttribute);
                              }
                         }

                         tmpAccountModels.Add(tmpAccountInfo);
                    }
               }

               return tmpAccountModels;
          }
     }
}