
using System.Windows.Forms;
using System.Collections.Generic;
using OfficeOpenXml.Style;
using HuiruiSoft.Safe.Model;
using HuiruiSoft.Safe.Resources;
using HuiruiSoft.Safe.Configuration;

namespace HuiruiSoft.Safe.Exchange
{
     public class ExportAccountUtil
     {
          private const string ElementRootNode = "Account";
          private const string ElementMetaNode = "Meta";
          private const string ElementCatalog = "Catalog";
          private const string ElementAccount = "Account";

          public static bool ExportSafePassXml(TreeNodeCollection treeNodes, List<AccountModel> accountModels, string fileName)
          {
               bool tmpExportResult = false;

               var tmpOutputDocument = new System.Xml.XmlDocument();
               tmpOutputDocument.AppendChild(tmpOutputDocument.CreateXmlDeclaration("1.0", "UTF-8", null));

               var tmpRootElement = tmpOutputDocument.CreateElement(ElementRootNode);
               tmpOutputDocument.AppendChild(tmpRootElement);
               if (treeNodes != null && treeNodes.Count > 0)
               {
                    BuildAccountNodes(treeNodes, tmpRootElement, accountModels);
               }

               tmpOutputDocument.Save(fileName);

               return tmpExportResult;
          }

          private static void BuildAccountNodes(TreeNodeCollection treeNodes, System.Xml.XmlElement element, List<AccountModel> accountModels)
          {
               if (treeNodes == null || element == null)
               {
                    return;
               }

               foreach (TreeNode tmpTreeNode in treeNodes)
               {
                    if (tmpTreeNode.Tag is AccountCatalog)
                    {
                         var tmpCatalog = (AccountCatalog)tmpTreeNode.Tag;

                         var tmpCatalogNode = BuildCatalogElement(element, tmpCatalog);
                         if (tmpCatalogNode != null)
                         {
                              if (accountModels != null)
                              {
                                   var tmpCatalogId = tmpCatalog.CatalogId;
                                   accountModels.ForEach(account =>
                                   {
                                        if (account.CatalogId == tmpCatalogId)
                                        {
                                             var tmpAccountNode = BuildAccountElement(tmpCatalogNode, account);
                                        }
                                   });
                              }

                              if (tmpTreeNode.Nodes.Count > 0)
                              {
                                   BuildAccountNodes(tmpTreeNode.Nodes, tmpCatalogNode, accountModels);
                              }
                         }
                    }
               }
          }

          private static System.Xml.XmlElement BuildCatalogElement(System.Xml.XmlElement parentNode, AccountCatalog catalog)
          {
               System.Xml.XmlElement tmpCatalogNode = null;
               if (catalog != null && parentNode != null)
               {
                    tmpCatalogNode = parentNode.OwnerDocument.CreateElement(ElementCatalog);
                    tmpCatalogNode.SetAttribute("id", string.Format("{0}", catalog.CatalogId));
                    tmpCatalogNode.SetAttribute("Name", catalog.Name);
                    tmpCatalogNode.SetAttribute("Depth", string.Format("{0}", catalog.Depth));
                    tmpCatalogNode.SetAttribute("Order", string.Format("{0}", catalog.Order));
                    tmpCatalogNode.SetAttribute("Version", string.Format("{0}", catalog.VersionNo));
                    tmpCatalogNode.SetAttribute("CreateTime", catalog.CreateTime.ToString(ApplicationDefines.DateTimeFormat));
                    tmpCatalogNode.SetAttribute("UpdateTime", catalog.UpdateTime.ToString(ApplicationDefines.DateTimeFormat));

                    if (!string.IsNullOrEmpty(catalog.Description))
                    {
                         var tmpCommentNode = tmpCatalogNode.OwnerDocument.CreateElement("Comment");
                         tmpCommentNode.InnerText = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(catalog.Description));
                         tmpCatalogNode.AppendChild(tmpCommentNode);
                    }

                    parentNode.AppendChild(tmpCatalogNode);
               }

               return tmpCatalogNode;
          }

          private static System.Xml.XmlElement BuildAccountElement(System.Xml.XmlElement catalogNode, AccountModel account)
          {
               System.Xml.XmlElement tmpAccountNode = null;
               if (account != null && catalogNode != null)
               {
                    tmpAccountNode = catalogNode.OwnerDocument.CreateElement("item");
                    tmpAccountNode.SetAttribute("id", string.Format("{0}", account.AccountId));
                    tmpAccountNode.SetAttribute("Guid", account.AccountGuid);
                    tmpAccountNode.SetAttribute("Order", string.Format("{0}", account.Order));
                    tmpAccountNode.SetAttribute("Delete", string.Format("{0}", account.Deleted));
                    tmpAccountNode.SetAttribute("TopMost", string.Format("{0}", account.TopMost));
                    tmpAccountNode.SetAttribute("Name", account.Name);
                    tmpAccountNode.SetAttribute("LoginName", account.LoginName);
                    tmpAccountNode.SetAttribute("Password", account.Password);
                    tmpAccountNode.SetAttribute("Mobile", account.Mobile);
                    tmpAccountNode.SetAttribute("Email", account.Email);
                    tmpAccountNode.SetAttribute("SecretRank", string.Format("{0}", account.SecretRank));

                    tmpAccountNode.SetAttribute("Version", string.Format("{0}", account.VersionNo));
                    tmpAccountNode.SetAttribute("CreateTime", account.CreateTime.ToString(ApplicationDefines.DateTimeFormat));
                    tmpAccountNode.SetAttribute("UpdateTime", account.UpdateTime.ToString(ApplicationDefines.DateTimeFormat));

                    if (!string.IsNullOrEmpty(account.Comment))
                    {
                         var tmpCommentNode = tmpAccountNode.OwnerDocument.CreateElement("Comment");
                         tmpCommentNode.InnerText = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(account.Comment));
                         tmpAccountNode.AppendChild(tmpCommentNode);
                    }

                    if (account.Attributes.Count > 0)
                    {
                         var tmpAttributesNode = tmpAccountNode.OwnerDocument.CreateElement("Attributes");
                         account.Attributes.ForEach(item =>
                         {
                              var tmpAttributeNode = tmpAttributesNode.OwnerDocument.CreateElement("Attribute");
                              tmpAttributeNode.SetAttribute("Id", string.Format("{0}", item.AttributeId));
                              tmpAttributeNode.SetAttribute("Order", string.Format("{0}", item.Order));
                              tmpAttributeNode.SetAttribute("Encrypted", string.Format("{0}", item.Encrypted));
                              tmpAttributeNode.SetAttribute("Name",  item.Name);
                              tmpAttributeNode.InnerText = item.Value;

                              tmpAttributesNode.AppendChild(tmpAttributeNode);
                         });

                         tmpAccountNode.AppendChild(tmpAttributesNode);
                    }

                    catalogNode.AppendChild(tmpAccountNode);
               }

               return tmpAccountNode;
          }

          public static bool ExportExcel(TreeNodeCollection treeNodes, List<AccountModel> accountModels, string fileName)
          {
               bool tmpExportResult = false;

               int
                    Column_RowNo = 1,
                    Column_Deleted = 2,
                    Column_Rank = 3,
                    Column_Name = 4,
                    Column_LoginName = 5,
                    Column_Password = 6,
                    Column_Mobile = 7,
                    Column_Email = 8,
                    Column_URL = 9,
                    Column_CreateTime = 10,
                    Column_UpdateTime = 11,
                    Column_Comment = 12;

               var tmpExportFile = new System.IO.FileInfo(fileName);
               if (tmpExportFile.Exists)
               {
                    tmpExportFile.Delete();
               }

               using (var tmpExcelPackage = new OfficeOpenXml.ExcelPackage(new System.IO.FileInfo(fileName)))
               {
                    var tmpWorkSheet = tmpExcelPackage.Workbook.Worksheets.Add("account");
                    tmpWorkSheet.Cells.Style.Font.Name = "宋体";

                    tmpWorkSheet.Column(Column_RowNo).Width = 8;
                    tmpWorkSheet.Column(Column_RowNo).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    tmpWorkSheet.Column(Column_Deleted).Width = 8;
                    tmpWorkSheet.Column(Column_Deleted).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    tmpWorkSheet.Column(Column_Rank).Width = 8;
                    tmpWorkSheet.Column(Column_Rank).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    tmpWorkSheet.Column(Column_Name).Width = 30;
                    tmpWorkSheet.Column(Column_Name).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                    tmpWorkSheet.Column(Column_LoginName).Width = 30;
                    tmpWorkSheet.Column(Column_LoginName).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                    tmpWorkSheet.Column(Column_Password).Width = 25;
                    tmpWorkSheet.Column(Column_Password).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                    tmpWorkSheet.Column(Column_Mobile).Width = 15;
                    tmpWorkSheet.Column(Column_Mobile).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    tmpWorkSheet.Column(Column_Email).Width = 30;
                    tmpWorkSheet.Column(Column_Email).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                    tmpWorkSheet.Column(Column_URL).Width = 50;
                    tmpWorkSheet.Column(Column_URL).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                    tmpWorkSheet.Column(Column_CreateTime).Width = 22;
                    tmpWorkSheet.Column(Column_CreateTime).Style.Numberformat.Format = ApplicationDefines.DateTimeFormat;
                    tmpWorkSheet.Column(Column_CreateTime).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    tmpWorkSheet.Column(Column_UpdateTime).Width = 22;
                    tmpWorkSheet.Column(Column_UpdateTime).Style.Numberformat.Format = ApplicationDefines.DateTimeFormat;
                    tmpWorkSheet.Column(Column_UpdateTime).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    tmpWorkSheet.Cells[1, Column_RowNo].Value = SafePassResource.DataGridAccountColumnOrderNo;
                    tmpWorkSheet.Cells[1, Column_Deleted].Value = "删除";
                    tmpWorkSheet.Cells[1, Column_Rank].Value = SafePassResource.DataGridAccountColumnSecret;
                    tmpWorkSheet.Cells[1, Column_Name].Value = SafePassResource.DataGridAccountColumnName;
                    tmpWorkSheet.Cells[1, Column_LoginName].Value = SafePassResource.DataGridAccountColumnLoginName;
                    tmpWorkSheet.Cells[1, Column_Password].Value = SafePassResource.DataGridAccountColumnPassword;
                    tmpWorkSheet.Cells[1, Column_Mobile].Value = SafePassResource.DataGridAccountColumnMobile;
                    tmpWorkSheet.Cells[1, Column_Email].Value = SafePassResource.DataGridAccountColumnEmail;
                    tmpWorkSheet.Cells[1, Column_URL].Value = SafePassResource.DataGridAccountColumnURL;
                    tmpWorkSheet.Cells[1, Column_CreateTime].Value = SafePassResource.DataGridAccountColumnCreateTime;
                    tmpWorkSheet.Cells[1, Column_UpdateTime].Value = SafePassResource.DataGridAccountColumnUpdateTime;

                    for (var index = Column_RowNo; index <= Column_UpdateTime; index++)
                    {
                         tmpWorkSheet.Cells[1, index].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    }

                    int tmpRowIndex = 1;

                    accountModels.ForEach(account =>
                    {
                         tmpRowIndex++;

                         tmpWorkSheet.Cells[tmpRowIndex, Column_RowNo].Value = tmpRowIndex - 1;
                         tmpWorkSheet.Cells[tmpRowIndex, Column_Deleted].Value = account.Deleted;
                         tmpWorkSheet.Cells[tmpRowIndex, Column_Rank].Value = account.SecretRank;
                         tmpWorkSheet.Cells[tmpRowIndex, Column_Name].Value = account.Name;
                         tmpWorkSheet.Cells[tmpRowIndex, Column_LoginName].Value = account.LoginName;
                         tmpWorkSheet.Cells[tmpRowIndex, Column_Password].Value = account.Password;
                         tmpWorkSheet.Cells[tmpRowIndex, Column_Mobile].Value = account.Mobile;
                         tmpWorkSheet.Cells[tmpRowIndex, Column_Email].Value = account.Email;
                         tmpWorkSheet.Cells[tmpRowIndex, Column_URL].Value = account.URL;
                         tmpWorkSheet.Cells[tmpRowIndex, Column_CreateTime].Value = account.CreateTime;
                         tmpWorkSheet.Cells[tmpRowIndex, Column_UpdateTime].Value = account.UpdateTime;
                    });

                    tmpExcelPackage.Save();
                    tmpWorkSheet.Dispose();
                    tmpExcelPackage.Dispose();

                    System.GC.Collect();
               }

               return tmpExportResult;
          }
     }
}