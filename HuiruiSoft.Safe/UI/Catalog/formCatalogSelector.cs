
using System.Windows.Forms;
using HuiruiSoft.Utils;
using HuiruiSoft.Safe.Model;
using HuiruiSoft.Safe.Resources;

namespace HuiruiSoft.Safe
{
     public partial class formCatalogSelector : Form
     {
          private System.ComponentModel.IContainer components = null;
          private System.Windows.Forms.Label labelCatalogTip;
          private System.Windows.Forms.Button buttonOK;
          private System.Windows.Forms.Button buttonClose;
          private System.Windows.Forms.TreeView treeViewCatalog;
          private System.Windows.Forms.ImageList treeNodeImages;
          
          public int? CatalogId
          {
               get;
               set;
          }

          public TreeNode SelectedNode
          {
               set;

               private get;
          }

          internal formCatalogSelector(TreeNodeCollection treeNodes)
          {
               this.InitializeComponent( );
               this.ShowInTaskbar = true;

               this.WindowState = FormWindowState.Normal;
               this.FormBorderStyle = FormBorderStyle.FixedDialog;
               this.StartPosition = FormStartPosition.CenterScreen;
               this.treeViewCatalog.ImageList = this.treeNodeImages;

               this.buttonOK.Enabled = false;
               foreach(TreeNode tmpTreeNode in treeNodes)
               {
                    this.treeViewCatalog.Nodes.Add((TreeNode)tmpTreeNode.Clone( ));
               }
          }

          protected override void OnLoad(System.EventArgs args)
          {
               base.OnLoad(args);

               if (!base.DesignMode)
               {
                    this.MinimizeBox = false;
                    this.MaximizeBox = false;

                    this.AcceptButton = this.buttonOK;
                    this.CancelButton = this.buttonClose;

                    this.Text = SafePassResource.CatalogSelectorCaption;
                    this.buttonOK.Text = SafePassResource.ButtonOK;
                    this.buttonClose.Text = SafePassResource.ButtonClose;
                    this.labelCatalogTip.Text = SafePassResource.CatalogSelectorPrompt;

                    this.treeViewCatalog.ExpandAll( );
                    this.treeViewCatalog.AfterSelect += new TreeViewEventHandler(this.OnTreeViewAfterSelect);
               }
          }

          protected override void OnClosed(System.EventArgs args)
          {
               base.OnClosed(args);
          }

          protected override void Dispose(bool disposing)
          {
               if(disposing && (components != null))
               {
                    components.Dispose( );
               }
               base.Dispose(disposing);
          }

          #region Windows 窗体设计器生成的代码

          private void InitializeComponent( )
          {
               this.components = new System.ComponentModel.Container();
               System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formCatalogSelector));
               this.buttonClose = new System.Windows.Forms.Button();
               this.labelCatalogTip = new System.Windows.Forms.Label();
               this.buttonOK = new System.Windows.Forms.Button();
               this.treeViewCatalog = new System.Windows.Forms.TreeView();
               this.treeNodeImages = new System.Windows.Forms.ImageList(this.components);
               this.SuspendLayout();
               // 
               // buttonClose
               // 
               this.buttonClose.Location = new System.Drawing.Point(294, 114);
               this.buttonClose.Margin = new System.Windows.Forms.Padding(4);
               this.buttonClose.Name = "buttonClose";
               this.buttonClose.Size = new System.Drawing.Size(120, 45);
               this.buttonClose.TabIndex = 2;
               this.buttonClose.Text = "&Close";
               this.buttonClose.UseVisualStyleBackColor = true;
               this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
               // 
               // labelCatalogTip
               // 
               this.labelCatalogTip.AutoSize = true;
               this.labelCatalogTip.Location = new System.Drawing.Point(16, 10);
               this.labelCatalogTip.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.labelCatalogTip.Name = "labelCatalogTip";
               this.labelCatalogTip.Size = new System.Drawing.Size(70, 13);
               this.labelCatalogTip.TabIndex = 0;
               this.labelCatalogTip.Text = "Please select a catalog:";
               // 
               // buttonOK
               // 
               this.buttonOK.Location = new System.Drawing.Point(294, 39);
               this.buttonOK.Margin = new System.Windows.Forms.Padding(4);
               this.buttonOK.Name = "buttonOK";
               this.buttonOK.Size = new System.Drawing.Size(120, 45);
               this.buttonOK.TabIndex = 1;
               this.buttonOK.Text = "&OK";
               this.buttonOK.UseVisualStyleBackColor = true;
               this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
               // 
               // treeViewCatalog
               // 
               this.treeViewCatalog.Location = new System.Drawing.Point(16, 39);
               this.treeViewCatalog.Margin = new System.Windows.Forms.Padding(2);
               this.treeViewCatalog.Name = "treeViewCatalog";
               this.treeViewCatalog.Size = new System.Drawing.Size(260, 380);
               this.treeViewCatalog.TabIndex = 3;
               // 
               // treeNodeImages
               // 
               this.treeNodeImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeNodeImages.ImageStream")));
               this.treeNodeImages.TransparentColor = System.Drawing.Color.Transparent;
               this.treeNodeImages.Images.SetKeyName(0, "Small_Explorer.ico");
               this.treeNodeImages.Images.SetKeyName(1, "Small_FolderExpanded.ico");
               this.treeNodeImages.Images.SetKeyName(2, "DataManagement.png");
               // 
               // formCatalogSelector
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(434, 446);
               this.Controls.Add(this.treeViewCatalog);
               this.Controls.Add(this.buttonClose);
               this.Controls.Add(this.buttonOK);
               this.Controls.Add(this.labelCatalogTip);
               this.Name = "formCatalogSelector";
               this.Text = "Select Catalog";
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion

          private void buttonOK_Click(object sender, System.EventArgs args)
          {
               var tmpSelectedNode = this.treeViewCatalog.SelectedNode;

               if(tmpSelectedNode != null)
               {
                    if(tmpSelectedNode.Tag is AccountCatalog)
                    {
                         this.CatalogId = ((AccountCatalog)(tmpSelectedNode.Tag)).CatalogId;
                    }

                    this.SelectedNode = null;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
               }
          }

          private void buttonClose_Click(object sender, System.EventArgs args)
          {
               this.Close( );
          }

          private void OnTreeViewAfterSelect(object sender, TreeViewEventArgs args)
          {
               if(this.SelectedNode == null)
               {
                    this.buttonOK.Enabled = true;
               }
               else if(this.treeViewCatalog.SelectedNode == null)
               {
                    this.buttonOK.Enabled = false;
               }
               else
               {
                    this.buttonOK.Enabled = !this.treeViewCatalog.SelectedNode.Tag.Equals(this.SelectedNode.Tag);
               }
          }
     }
}
