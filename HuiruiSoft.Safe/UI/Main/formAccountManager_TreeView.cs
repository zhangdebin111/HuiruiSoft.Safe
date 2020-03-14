
using System.Windows.Forms;
using HuiruiSoft.Safe.Model;

namespace HuiruiSoft.Safe
{
     public partial class formAccountManager : Form
     {
          private bool rightButtonNodeClick = false;
          private Keys lastUnhandledTreeKey = Keys.None;
          private TreeNode recycleBinTreeNode;

          private void InitializeTreeView()
          {
               this.treeViewCatalog.HideSelection = false;
               this.treeViewCatalog.Nodes.Clear();

               var tmpCatalogService = new HuiruiSoft.Safe.Service.CatalogService();
               var tmpCatalogDataTable = tmpCatalogService.GetCatalogTable();
               if (tmpCatalogDataTable != null)
               {
                    this.CreateCatalogTreeNodes(tmpCatalogDataTable, null, -1);

                    this.CreateRecycleBinNode();
                    this.treeViewCatalog.Nodes.Add(this.recycleBinTreeNode);
               }

               this.treeViewCatalog.ExpandAll();
               this.treeViewCatalog.LabelEdit = false;
          }

          private void CreateRecycleBinNode()
          {
               if (this.recycleBinTreeNode == null)
               {
                    this.recycleBinTreeNode = new TreeNode();
                    this.recycleBinTreeNode.Text = "Recycle Bin";
                    this.recycleBinTreeNode.Tag = "RecycleBin";
                    this.recycleBinTreeNode.ImageIndex = 2;
                    this.recycleBinTreeNode.SelectedImageIndex = 2;
               }
          }

          private void CreateCatalogTreeNodes(System.Data.DataTable catalogTable, TreeNode parentTreeNode, int parentId)
          {
               if (catalogTable != null)
               {
                    catalogTable.DefaultView.RowFilter = string.Format("ParentId = {0}", parentId);
                    for (int i = 0; i < catalogTable.DefaultView.Count; i++)
                    {
                         var tmpCatalogItem = new AccountCatalog();
                         tmpCatalogItem.CatalogId = int.Parse(string.Format("{0}", catalogTable.DefaultView[i]["CatalogId"]));
                         tmpCatalogItem.ParentId = int.Parse(string.Format("{0}", catalogTable.DefaultView[i]["ParentId"]));
                         tmpCatalogItem.Name = string.Format("{0}", catalogTable.DefaultView[i]["Name"]);
                         tmpCatalogItem.Depth = int.Parse(string.Format("{0}", catalogTable.DefaultView[i]["Depth"]));
                         tmpCatalogItem.Order = int.Parse(string.Format("{0}", catalogTable.DefaultView[i]["OrderNo"]));
                         tmpCatalogItem.VersionNo = int.Parse(string.Format("{0}", catalogTable.DefaultView[i]["VersionNo"]));
                         tmpCatalogItem.CreateTime = (System.DateTime)catalogTable.DefaultView[i]["CreateTime"];
                         tmpCatalogItem.UpdateTime = (System.DateTime)catalogTable.DefaultView[i]["UpdateTime"];
                         tmpCatalogItem.Description = string.Format("{0}", catalogTable.DefaultView[i]["Description"]);

                         var tmpCatalogNode = new TreeNode();
                         tmpCatalogNode.Text = tmpCatalogItem.Name;
                         tmpCatalogNode.Tag = tmpCatalogItem;
                         tmpCatalogNode.ImageIndex = 0;
                         tmpCatalogNode.SelectedImageIndex = 1;

                         if (parentTreeNode != null)
                         {
                              parentTreeNode.Nodes.Add(tmpCatalogNode);
                         }
                         else
                         {
                              this.treeViewCatalog.Nodes.Add(tmpCatalogNode);
                         }
                    }

                    if (parentTreeNode == null)
                    {
                         foreach (TreeNode tmpCatalogNode in this.treeViewCatalog.Nodes)
                         {
                              this.CreateCatalogTreeNodes(catalogTable, tmpCatalogNode, ((AccountCatalog)(tmpCatalogNode.Tag)).CatalogId);
                         }
                    }
                    else
                    {
                         foreach (TreeNode tmpCatalogNode in parentTreeNode.Nodes)
                         {
                              this.CreateCatalogTreeNodes(catalogTable, tmpCatalogNode, ((AccountCatalog)(tmpCatalogNode.Tag)).CatalogId);
                         }
                    }
               }
          }

          private void OnTreeViewCatalogAfterSelect(object sender, TreeViewEventArgs args)
          {
               if (!this.rightButtonNodeClick)
               {
                    this.GetCatalogChildAccounts();
               }

               this.UpdateControlState();
          }

          private void OnTreeViewCatalogNodeMouseClick(object sender, TreeNodeMouseClickEventArgs args)
          {
               this.NotifyUserActivity();
               this.rightButtonNodeClick = false;

               if (args.Button == MouseButtons.Right)
               {
                    this.rightButtonNodeClick = true;
                    this.treeViewCatalog.SelectedNode = args.Node; // var tmpHitTestNode = args.Node;
               }
          }

          private void OnTreeViewCatalogKeyDown(object sender, KeyEventArgs args)
          {
               this.NotifyUserActivity();
               this.rightButtonNodeClick = false;

               if (this.HandleMainWindowKeyMessage(args, true))
               {
                    return;
               }

               bool tmpMessageHandled = true;
               if (args.Alt)
               {
                    tmpMessageHandled = false;
               }
               else if (args.KeyCode == Keys.Delete)
               {
                    this.DeleteCatalog();
               }
               else if (args.KeyCode == Keys.F2)
               {
                    if (this.treeViewCatalog.SelectedNode != null)
                    {
                         this.OpenCatalogEditor();
                    }
               }
               else
               {
                    tmpMessageHandled = false;
               }

               if (tmpMessageHandled)
               {
                    args.Handled = true;
                    args.SuppressKeyPress = true;
               }
               else
               {
                    this.lastUnhandledTreeKey = args.KeyCode;
               }
          }

          private void OnTreeViewCatalogKeyUp(object sender, KeyEventArgs args)
          {
               this.rightButtonNodeClick = false;

               if (this.HandleMainWindowKeyMessage(args, false))
               {
                    return;
               }

               bool tmpUnHandled = false;

               if (args.Alt)
               {
                    tmpUnHandled = true;
               }
               else if (args.KeyCode == Keys.Delete)
               {
                    //
               }
               else if (args.KeyCode == Keys.F2)
               {
                    //
               }
               else if (
                    (args.KeyCode == Keys.Up) ||
                    (args.KeyCode == Keys.Down) ||
                    (args.KeyCode == Keys.Left) ||
                    (args.KeyCode == Keys.Right) ||
                    (args.KeyCode == Keys.Home) ||
                    (args.KeyCode == Keys.End) ||
                    (args.KeyCode >= Keys.A && args.KeyCode <= Keys.Z) ||
                    (args.KeyCode >= Keys.D0 && args.KeyCode <= Keys.D9) ||
                    (args.KeyCode >= Keys.NumPad0 && args.KeyCode <= Keys.NumPad9))
               {
                    if (args.KeyCode == this.lastUnhandledTreeKey)
                    {
                         //
                    }
               }
               else
               {
                    tmpUnHandled = true;
               }

               if (!tmpUnHandled)
               {
                    args.Handled = true;
                    args.SuppressKeyPress = true;
               }
          }
     }
}