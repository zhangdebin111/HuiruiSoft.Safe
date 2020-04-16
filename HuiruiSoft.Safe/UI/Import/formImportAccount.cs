using System.Windows.Forms;
using HuiruiSoft.Utils;
using HuiruiSoft.Safe.Model;
using HuiruiSoft.Safe.Exchange;
using HuiruiSoft.Safe.Resources;
using System.Collections.Generic;
using HuiruiSoft.Safe.Configuration;

namespace HuiruiSoft.Safe
{
     internal partial class formImportAccount : System.Windows.Forms.Form
     {
          private System.ComponentModel.IContainer components = null;
          private SourceGrid.DataGrid dataGridAccount;
          private System.Windows.Forms.Label labelImportFile;
          private System.Windows.Forms.Panel panelPrompt;
          private System.Windows.Forms.Label labelNoFoundColor;
          private System.Windows.Forms.Label labelUnEqualColor;
          private System.Windows.Forms.Label labelNoFoundPrompt;
          private System.Windows.Forms.Label labelUnEqualPrompt;
          private System.Windows.Forms.Panel panelProgress;
          private System.Windows.Forms.Label labelProgress;
          private System.Windows.Forms.Button buttonClose;
          private System.Windows.Forms.Button buttonSelectAll;
          private System.Windows.Forms.Button buttonSelectNone;
          private System.Windows.Forms.Button buttonUnSelected;
          private System.Windows.Forms.Button buttonSelectFile;
          private System.Windows.Forms.Button buttonStartImport;
          private System.Windows.Forms.CheckBox checkCompareWith;
          private System.Windows.Forms.GroupBox groupImportOptions;
          private System.Windows.Forms.TextBox textImportFile;
          private System.Windows.Forms.TreeView treeViewCatalog;
          private System.Windows.Forms.ImageList treeNodeImages;
          private System.Windows.Forms.ProgressBar progressBarImport;
          private System.Windows.Forms.SplitContainer splitControls;

          internal List<AccountModel> CurrentAccounts
          {
               private get;

               set;
          }

          private formImportAccount() : this(null)
          {
               //
          }

          internal formImportAccount(List<AccountModel> accounts)
          {
               this.CurrentAccounts = accounts;

               this.InitializeComponent();

               this.MinimizeBox = true;
               this.MaximizeBox = true;
               this.ShowInTaskbar = false;
               this.WindowState = FormWindowState.Normal;
               this.FormBorderStyle = FormBorderStyle.Sizable;
               this.StartPosition = FormStartPosition.CenterScreen;
          }

          protected override void OnLoad(System.EventArgs args)
          {
               base.OnLoad(args);

               if (!base.DesignMode)
               {
                    this.CancelButton = this.buttonClose;
                    this.splitControls.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

                    var tmpScreenBounds = Screen.PrimaryScreen.Bounds;
                    this.ClientSize = new System.Drawing.Size(tmpScreenBounds.Width * 85 / 100, tmpScreenBounds.Height * 85 / 100);
                    this.MinimumSize = new System.Drawing.Size(tmpScreenBounds.Width * 40 / 100, tmpScreenBounds.Height * 40 / 100);
                    this.splitControls.Panel1MinSize = 150;
                    this.splitControls.SplitterDistance = 200;
                    this.Location = new System.Drawing.Point((tmpScreenBounds.Width - this.ClientSize.Width) / 2, 50);

                    this.treeViewCatalog.Dock = System.Windows.Forms.DockStyle.Fill;
                    this.dataGridAccount.Dock = System.Windows.Forms.DockStyle.Fill;

                    this.InitializeImportDataGrid();
                    this.treeViewCatalog.CheckBoxes = true;
                    this.treeViewCatalog.ImageIndex = 0;
                    this.treeViewCatalog.ImageList = this.treeNodeImages;

                    this.Icon = WindowsUtils.DefaultAppIcon;
                    this.Text = SafePassResource.ImportWindowCaption;
                    this.buttonClose.Text = SafePassResource.ButtonClose;
                    this.buttonStartImport.Text = SafePassResource.ImportWindowButtonStartImport;
                    this.buttonSelectAll.Text = SafePassResource.ImportWindowButtonSelectAll;
                    this.buttonUnSelected.Text = SafePassResource.ImportWindowButtonUnSelected;
                    this.buttonSelectNone.Text = SafePassResource.ImportWindowButtonSelectNone;
                    this.labelImportFile.Text = SafePassResource.ImportWindowLabelImportFile;
                    this.checkCompareWith.Text = SafePassResource.ImportWindowCheckBoxCompare;
                    this.groupImportOptions.Text = SafePassResource.ImportWindowGroupBoxOptions;
                    this.labelNoFoundPrompt.Text = SafePassResource.ImportWindowLabelPromptNotFound;
                    this.labelUnEqualPrompt.Text = SafePassResource.ImportWindowLabelPromptUnequal;

                    this.labelNoFoundColor.BackColor = this.noFoundBackColor;
                    this.labelUnEqualColor.BackColor = this.unEqualBackColor;
                    this.labelNoFoundColor.BorderStyle = BorderStyle.FixedSingle;
                    this.labelUnEqualColor.BorderStyle = BorderStyle.FixedSingle;

                    this.checkCompareWith.Checked = true;
                    this.SetDataGridLocalizedStrings();
                    this.UpdateControlState();
                    this.UpdateProgressControls(false);
               }
          }

          protected override void OnClosed(System.EventArgs args)
          {
               base.OnClosed(args);
          }

          protected override void Dispose(bool disposing)
          {
               if (disposing && (components != null))
               {
                    components.Dispose();

                    if (this.accountDataTable != null)
                    {
                         this.accountDataTable.RowChanged -= new System.Data.DataRowChangeEventHandler(this.OnImportDataTableRowChanged);
                         this.accountDataTable.Dispose();
                    }
               }

               base.Dispose(disposing);
          }

          #region Windows 窗体设计器生成的代码

          private void InitializeComponent()
          {
               this.components = new System.ComponentModel.Container();
               System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formImportAccount));
               this.buttonClose = new System.Windows.Forms.Button();
               this.buttonStartImport = new System.Windows.Forms.Button();
               this.groupImportOptions = new System.Windows.Forms.GroupBox();
               this.buttonUnSelected = new System.Windows.Forms.Button();
               this.checkCompareWith = new System.Windows.Forms.CheckBox();
               this.buttonSelectNone = new System.Windows.Forms.Button();
               this.buttonSelectAll = new System.Windows.Forms.Button();
               this.buttonSelectFile = new System.Windows.Forms.Button();
               this.textImportFile = new System.Windows.Forms.TextBox();
               this.labelImportFile = new System.Windows.Forms.Label();
               this.splitControls = new System.Windows.Forms.SplitContainer();
               this.treeViewCatalog = new System.Windows.Forms.TreeView();
               this.dataGridAccount = new SourceGrid.DataGrid();
               this.treeNodeImages = new System.Windows.Forms.ImageList(this.components);
               this.panelPrompt = new System.Windows.Forms.Panel();
               this.labelUnEqualColor = new System.Windows.Forms.Label();
               this.labelNoFoundColor = new System.Windows.Forms.Label();
               this.labelUnEqualPrompt = new System.Windows.Forms.Label();
               this.labelNoFoundPrompt = new System.Windows.Forms.Label();
               this.panelProgress = new System.Windows.Forms.Panel();
               this.labelProgress = new System.Windows.Forms.Label();
               this.progressBarImport = new System.Windows.Forms.ProgressBar();
               this.groupImportOptions.SuspendLayout();
               this.splitControls.Panel1.SuspendLayout();
               this.splitControls.Panel2.SuspendLayout();
               this.splitControls.SuspendLayout();
               this.panelPrompt.SuspendLayout();
               this.panelProgress.SuspendLayout();
               this.SuspendLayout();
               // 
               // buttonClose
               // 
               this.buttonClose.Location = new System.Drawing.Point(1200, 118);
               this.buttonClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
               this.buttonClose.Name = "buttonClose";
               this.buttonClose.Size = new System.Drawing.Size(180, 55);
               this.buttonClose.TabIndex = 4;
               this.buttonClose.Text = "&Close";
               this.buttonClose.Click += new System.EventHandler(this.OnCloseButtonClick);
               // 
               // buttonStartImport
               // 
               this.buttonStartImport.Location = new System.Drawing.Point(1200, 47);
               this.buttonStartImport.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
               this.buttonStartImport.Name = "buttonStartImport";
               this.buttonStartImport.Size = new System.Drawing.Size(180, 55);
               this.buttonStartImport.TabIndex = 3;
               this.buttonStartImport.Text = "Start";
               this.buttonStartImport.Click += new System.EventHandler(this.OnStartImportButtonClick);
               // 
               // groupImportOptions
               // 
               this.groupImportOptions.Controls.Add(this.buttonUnSelected);
               this.groupImportOptions.Controls.Add(this.checkCompareWith);
               this.groupImportOptions.Controls.Add(this.buttonSelectNone);
               this.groupImportOptions.Controls.Add(this.buttonSelectAll);
               this.groupImportOptions.Controls.Add(this.buttonSelectFile);
               this.groupImportOptions.Controls.Add(this.textImportFile);
               this.groupImportOptions.Controls.Add(this.labelImportFile);
               this.groupImportOptions.Location = new System.Drawing.Point(18, 18);
               this.groupImportOptions.Name = "groupImportOptions";
               this.groupImportOptions.Size = new System.Drawing.Size(1157, 173);
               this.groupImportOptions.TabIndex = 0;
               this.groupImportOptions.TabStop = false;
               this.groupImportOptions.Text = "Options";
               // 
               // buttonUnSelected
               // 
               this.buttonUnSelected.Location = new System.Drawing.Point(569, 93);
               this.buttonUnSelected.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
               this.buttonUnSelected.Name = "buttonUnSelected";
               this.buttonUnSelected.Size = new System.Drawing.Size(180, 55);
               this.buttonUnSelected.TabIndex = 5;
               this.buttonUnSelected.Text = "Cancel Select";
               this.buttonUnSelected.Click += new System.EventHandler(this.buttonUnSelected_Click);
               // 
               // checkCompareWith
               // 
               this.checkCompareWith.AutoSize = true;
               this.checkCompareWith.Location = new System.Drawing.Point(12, 109);
               this.checkCompareWith.Name = "checkCompareWith";
               this.checkCompareWith.Size = new System.Drawing.Size(295, 22);
               this.checkCompareWith.TabIndex = 3;
               this.checkCompareWith.Text = "Compare with current database";
               this.checkCompareWith.UseVisualStyleBackColor = true;
               this.checkCompareWith.CheckedChanged += new System.EventHandler(this.OnCheckCompareWithCheckedChanged);
               // 
               // buttonSelectNone
               // 
               this.buttonSelectNone.Location = new System.Drawing.Point(796, 93);
               this.buttonSelectNone.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
               this.buttonSelectNone.Name = "buttonSelectNone";
               this.buttonSelectNone.Size = new System.Drawing.Size(180, 55);
               this.buttonSelectNone.TabIndex = 6;
               this.buttonSelectNone.Text = "Select None";
               this.buttonSelectNone.Click += new System.EventHandler(this.buttonSelectNone_Click);
               // 
               // buttonSelectAll
               // 
               this.buttonSelectAll.Location = new System.Drawing.Point(354, 93);
               this.buttonSelectAll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
               this.buttonSelectAll.Name = "buttonSelectAll";
               this.buttonSelectAll.Size = new System.Drawing.Size(180, 55);
               this.buttonSelectAll.TabIndex = 4;
               this.buttonSelectAll.Text = "Select All";
               this.buttonSelectAll.Click += new System.EventHandler(this.buttonSelectAll_Click);
               // 
               // buttonSelectFile
               // 
               this.buttonSelectFile.Location = new System.Drawing.Point(1086, 42);
               this.buttonSelectFile.Margin = new System.Windows.Forms.Padding(4);
               this.buttonSelectFile.Name = "buttonSelectFile";
               this.buttonSelectFile.Size = new System.Drawing.Size(48, 32);
               this.buttonSelectFile.TabIndex = 2;
               this.buttonSelectFile.UseVisualStyleBackColor = true;
               this.buttonSelectFile.Click += new System.EventHandler(this.OnSelectFileButtonClick);
               // 
               // textImportFile
               // 
               this.textImportFile.Location = new System.Drawing.Point(177, 44);
               this.textImportFile.Margin = new System.Windows.Forms.Padding(4);
               this.textImportFile.Name = "textImportFile";
               this.textImportFile.Size = new System.Drawing.Size(888, 28);
               this.textImportFile.TabIndex = 1;
               this.textImportFile.TextChanged += new System.EventHandler(this.textImportFile_TextChanged);
               // 
               // labelImportFile
               // 
               this.labelImportFile.AutoSize = true;
               this.labelImportFile.Location = new System.Drawing.Point(8, 49);
               this.labelImportFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.labelImportFile.Name = "labelImportFile";
               this.labelImportFile.Size = new System.Drawing.Size(161, 18);
               this.labelImportFile.TabIndex = 0;
               this.labelImportFile.Text = "Import from file:";
               // 
               // splitControls
               // 
               this.splitControls.Location = new System.Drawing.Point(18, 216);
               this.splitControls.Name = "splitControls";
               // 
               // splitControls.Panel1
               // 
               this.splitControls.Panel1.Controls.Add(this.treeViewCatalog);
               // 
               // splitControls.Panel2
               // 
               this.splitControls.Panel2.Controls.Add(this.dataGridAccount);
               this.splitControls.Size = new System.Drawing.Size(1420, 665);
               this.splitControls.SplitterDistance = 461;
               this.splitControls.SplitterWidth = 6;
               this.splitControls.TabIndex = 1;
               // 
               // treeViewCatalog
               // 
               this.treeViewCatalog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.treeViewCatalog.Location = new System.Drawing.Point(16, 19);
               this.treeViewCatalog.Name = "treeViewCatalog";
               this.treeViewCatalog.Size = new System.Drawing.Size(431, 629);
               this.treeViewCatalog.TabIndex = 0;
               this.treeViewCatalog.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.OnTreeViewCatalogAfterCheck);
               this.treeViewCatalog.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnTreeViewCatalogAfterSelect);
               // 
               // dataGridAccount
               // 
               this.dataGridAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.dataGridAccount.DeleteQuestionMessage = "Are you sure to delete all the selected rows?";
               this.dataGridAccount.EnableSort = false;
               this.dataGridAccount.FixedRows = 1;
               this.dataGridAccount.Location = new System.Drawing.Point(12, 19);
               this.dataGridAccount.Margin = new System.Windows.Forms.Padding(4);
               this.dataGridAccount.Name = "dataGridAccount";
               this.dataGridAccount.SelectionMode = SourceGrid.GridSelectionMode.Cell;
               this.dataGridAccount.Size = new System.Drawing.Size(924, 630);
               this.dataGridAccount.TabIndex = 0;
               this.dataGridAccount.TabStop = true;
               this.dataGridAccount.ToolTipText = "";
               // 
               // treeNodeImages
               // 
               this.treeNodeImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeNodeImages.ImageStream")));
               this.treeNodeImages.TransparentColor = System.Drawing.Color.Transparent;
               this.treeNodeImages.Images.SetKeyName(0, "Small_Explorer.ico");
               this.treeNodeImages.Images.SetKeyName(1, "Small_FolderExpanded.ico");
               this.treeNodeImages.Images.SetKeyName(2, "DataManagement.png");
               // 
               // panelPrompt
               // 
               this.panelPrompt.Controls.Add(this.labelUnEqualColor);
               this.panelPrompt.Controls.Add(this.labelNoFoundColor);
               this.panelPrompt.Controls.Add(this.labelUnEqualPrompt);
               this.panelPrompt.Controls.Add(this.labelNoFoundPrompt);
               this.panelPrompt.Dock = System.Windows.Forms.DockStyle.Bottom;
               this.panelPrompt.Location = new System.Drawing.Point(0, 895);
               this.panelPrompt.Name = "panelPrompt";
               this.panelPrompt.Size = new System.Drawing.Size(1455, 60);
               this.panelPrompt.TabIndex = 2;
               // 
               // labelUnEqualColor
               // 
               this.labelUnEqualColor.BackColor = System.Drawing.Color.LightGreen;
               this.labelUnEqualColor.Location = new System.Drawing.Point(711, 18);
               this.labelUnEqualColor.Name = "labelUnEqualColor";
               this.labelUnEqualColor.Size = new System.Drawing.Size(30, 30);
               this.labelUnEqualColor.TabIndex = 2;
               // 
               // labelNoFoundColor
               // 
               this.labelNoFoundColor.BackColor = System.Drawing.Color.LightGreen;
               this.labelNoFoundColor.Location = new System.Drawing.Point(15, 18);
               this.labelNoFoundColor.Name = "labelNoFoundColor";
               this.labelNoFoundColor.Size = new System.Drawing.Size(30, 30);
               this.labelNoFoundColor.TabIndex = 0;
               // 
               // labelUnEqualPrompt
               // 
               this.labelUnEqualPrompt.Location = new System.Drawing.Point(757, 18);
               this.labelUnEqualPrompt.Name = "labelUnEqualPrompt";
               this.labelUnEqualPrompt.Size = new System.Drawing.Size(680, 30);
               this.labelUnEqualPrompt.TabIndex = 3;
               this.labelUnEqualPrompt.Text = "label";
               this.labelUnEqualPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
               // 
               // labelNoFoundPrompt
               // 
               this.labelNoFoundPrompt.Location = new System.Drawing.Point(59, 18);
               this.labelNoFoundPrompt.Name = "labelNoFoundPrompt";
               this.labelNoFoundPrompt.Size = new System.Drawing.Size(630, 30);
               this.labelNoFoundPrompt.TabIndex = 1;
               this.labelNoFoundPrompt.Text = "label";
               this.labelNoFoundPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
               // 
               // panelProgress
               // 
               this.panelProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
               this.panelProgress.Controls.Add(this.labelProgress);
               this.panelProgress.Controls.Add(this.progressBarImport);
               this.panelProgress.Location = new System.Drawing.Point(1460, 308);
               this.panelProgress.Name = "panelProgress";
               this.panelProgress.Size = new System.Drawing.Size(856, 173);
               this.panelProgress.TabIndex = 5;
               // 
               // labelProgress
               // 
               this.labelProgress.AutoSize = true;
               this.labelProgress.Location = new System.Drawing.Point(28, 94);
               this.labelProgress.Name = "labelProgress";
               this.labelProgress.Size = new System.Drawing.Size(89, 18);
               this.labelProgress.TabIndex = 1;
               this.labelProgress.Text = "importing";
               // 
               // progressBarImport
               // 
               this.progressBarImport.Location = new System.Drawing.Point(247, 30);
               this.progressBarImport.Name = "progressBarImport";
               this.progressBarImport.Size = new System.Drawing.Size(360, 40);
               this.progressBarImport.TabIndex = 0;
               this.progressBarImport.Value = 50;
               // 
               // formImportAccount
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(1455, 955);
               this.Controls.Add(this.panelProgress);
               this.Controls.Add(this.panelPrompt);
               this.Controls.Add(this.splitControls);
               this.Controls.Add(this.groupImportOptions);
               this.Controls.Add(this.buttonClose);
               this.Controls.Add(this.buttonStartImport);
               this.Margin = new System.Windows.Forms.Padding(4);
               this.Name = "formImportAccount";
               this.Text = "Import";
               this.groupImportOptions.ResumeLayout(false);
               this.groupImportOptions.PerformLayout();
               this.splitControls.Panel1.ResumeLayout(false);
               this.splitControls.Panel2.ResumeLayout(false);
               this.splitControls.ResumeLayout(false);
               this.panelPrompt.ResumeLayout(false);
               this.panelProgress.ResumeLayout(false);
               this.panelProgress.PerformLayout();
               this.ResumeLayout(false);

          }

          #endregion


          protected override void OnSizeChanged(System.EventArgs args)
          {
               base.OnSizeChanged(args);
               this.panelProgress.Location = new System.Drawing.Point((this.ClientSize.Width - this.panelProgress.Width) / 2, (this.ClientSize.Height - this.panelProgress.Height) / 2 - 100);
          }

          private TreeNode recycleBinTreeNode;

          private void CreateSpecialTreeNode()
          {
               if (this.recycleBinTreeNode == null)
               {
                    this.recycleBinTreeNode = new TreeNode();
                    this.recycleBinTreeNode.Text = SafePassResource.RecycleBin;
                    this.recycleBinTreeNode.Tag = "RecycleBin";
                    this.recycleBinTreeNode.ImageIndex = 2;
                    this.recycleBinTreeNode.SelectedImageIndex = 2;
               }

               if (this.recycleBinTreeNode != null)
               {
                    this.treeViewCatalog.Nodes.Add(this.recycleBinTreeNode);
               }
          }

          private SourceGrid.Cells.Views.Cell noFoundCellLeft;
          private SourceGrid.Cells.Views.Cell noFoundCellCenter;
          private SourceGrid.Cells.Views.Cell unEqualCellLeft;
          private SourceGrid.Cells.Views.Cell unEqualCellCenter;
          private SourceGrid.Cells.Views.CheckBox checkBoxNoFound;
          private SourceGrid.Cells.Views.CheckBox checkBoxUnEqual;
          private System.Drawing.Color defaultBackColor = System.Drawing.Color.Empty;
          private System.Drawing.Color noFoundBackColor = System.Drawing.Color.FromArgb(215, 227, 188);
          private System.Drawing.Color unEqualBackColor = System.Drawing.Color.FromArgb(255, 204, 204);

          private System.Data.DataTable accountDataTable;

          private const string
               Account_Column_Selected = "Selected",
               Account_Column_Deleted = "Deleted",
               Account_Column_Order = "Order",
               Account_Column_CatalogId = "CatalogId",
               Account_Column_AccountId = "AccountId",
               Account_Column_AccountGuid = "AccountGuid",
               Account_Column_Name = "Name",
               Account_Column_URL = "URL",
               Account_Column_Secret = "Secret",
               Account_Column_TopMost = "TopMost",
               Account_Column_LoginName = "LoginName",
               Account_Column_Email = "Email",
               Account_Column_Mobile = "Mobile",
               Account_Column_CreateTime = "CreateTime",
               Account_Column_UpdateTime = "UpdateTime",
               Account_Column_CompareResult = "CompareResult";


          private void InitializeImportDataGrid()
          {
               #region InitializeImportDataGrid

               this.tableChangingBlock = true;

               this.accountDataTable = new System.Data.DataTable();
               this.accountDataTable.Columns.Add(Account_Column_Order, typeof(int));
               this.accountDataTable.Columns.Add(Account_Column_Selected, typeof(bool));
               this.accountDataTable.Columns.Add(Account_Column_Deleted, typeof(bool));
               this.accountDataTable.Columns.Add(Account_Column_AccountGuid, typeof(string));
               this.accountDataTable.Columns.Add(Account_Column_AccountId, typeof(int));
               this.accountDataTable.Columns.Add(Account_Column_CatalogId, typeof(int));
               this.accountDataTable.Columns.Add(Account_Column_TopMost, typeof(short));
               this.accountDataTable.Columns.Add(Account_Column_Name, typeof(string));
               this.accountDataTable.Columns.Add(Account_Column_LoginName, typeof(string));
               this.accountDataTable.Columns.Add(Account_Column_Secret, typeof(SecretRank));
               this.accountDataTable.Columns.Add(Account_Column_Email, typeof(string));
               this.accountDataTable.Columns.Add(Account_Column_Mobile, typeof(string));
               this.accountDataTable.Columns.Add(Account_Column_URL, typeof(string));
               this.accountDataTable.Columns.Add(Account_Column_CreateTime, typeof(System.DateTime));
               this.accountDataTable.Columns.Add(Account_Column_UpdateTime, typeof(System.DateTime));
               this.accountDataTable.Columns.Add(Account_Column_CompareResult, typeof(short));
               this.accountDataTable.RowChanged += new System.Data.DataRowChangeEventHandler(this.OnImportDataTableRowChanged);

               this.dataGridAccount.BorderStyle = BorderStyle.Fixed3D;
               this.dataGridAccount.BackColor = System.Drawing.SystemColors.AppWorkspace;
               this.dataGridAccount.Font = ApplicationDefines.DefaultDataGridCellFont;
               this.dataGridAccount.Rows.RowHeight = 30;
               this.dataGridAccount.Rows.SetHeight(0, 30);
               this.dataGridAccount.SelectionMode = SourceGrid.GridSelectionMode.Cell;
               this.dataGridAccount.Selection.EnableMultiSelection = true;
               this.dataGridAccount.ClipboardMode = SourceGrid.ClipboardMode.All;

               var tmpGridSelection = this.dataGridAccount.Selection as SourceGrid.Selection.SelectionBase;
               if (tmpGridSelection != null)
               {
                    tmpGridSelection.Border = tmpGridSelection.Border.SetColor(System.Drawing.Color.Blue);
                    tmpGridSelection.BackColor = System.Drawing.Color.FromArgb(60, tmpGridSelection.BackColor);
               }

               SourceGrid.DataGridColumn tmpGridColumn;
               tmpGridColumn = this.dataGridAccount.Columns.Add(Account_Column_Order, SafePassResource.DataGridAccountColumnOrderNo, typeof(int));
               tmpGridColumn = this.dataGridAccount.Columns.Add(Account_Column_Selected, SafePassResource.DataGridAccountColumnSelected, typeof(bool));
               tmpGridColumn = this.dataGridAccount.Columns.Add(Account_Column_AccountId, SafePassResource.DataGridAccountColumnAccountGuid, typeof(string));
               tmpGridColumn = this.dataGridAccount.Columns.Add(Account_Column_TopMost, SafePassResource.DataGridAccountColumnTopMost, typeof(short));
               tmpGridColumn = this.dataGridAccount.Columns.Add(Account_Column_Name, SafePassResource.DataGridAccountColumnName, typeof(string));
               tmpGridColumn = this.dataGridAccount.Columns.Add(Account_Column_Secret, SafePassResource.DataGridAccountColumnSecret, typeof(SecretRank));
               tmpGridColumn = this.dataGridAccount.Columns.Add(Account_Column_LoginName, SafePassResource.DataGridAccountColumnLoginName, typeof(string));
               tmpGridColumn = this.dataGridAccount.Columns.Add(Account_Column_Mobile, SafePassResource.DataGridAccountColumnMobile, typeof(string));
               tmpGridColumn = this.dataGridAccount.Columns.Add(Account_Column_Email, SafePassResource.DataGridAccountColumnEmail, typeof(string));
               tmpGridColumn = this.dataGridAccount.Columns.Add(Account_Column_CreateTime, SafePassResource.DataGridAccountColumnCreateTime, typeof(System.DateTime));
               tmpGridColumn = this.dataGridAccount.Columns.Add(Account_Column_UpdateTime, SafePassResource.DataGridAccountColumnUpdateTime, typeof(System.DateTime));
               tmpGridColumn = this.dataGridAccount.Columns.Add(Account_Column_URL, SafePassResource.DataGridAccountColumnURL, typeof(string));

               var tmpDateTimeFormat = ApplicationDefines.DateTimeFormat;
               var dateTimeParseFormats = new string[] { tmpDateTimeFormat };
               var tmpDateTimeStyles = System.Globalization.DateTimeStyles.AllowInnerWhite | System.Globalization.DateTimeStyles.AllowLeadingWhite | System.Globalization.DateTimeStyles.AllowTrailingWhite | System.Globalization.DateTimeStyles.AllowWhiteSpaces;
               var tmpDateTimeEditor = new SourceGrid.Cells.Editors.TextBoxUITypeEditor(typeof(System.DateTime));
               tmpDateTimeEditor.TypeConverter = new DevAge.ComponentModel.Converter.DateTimeTypeConverter(tmpDateTimeFormat, dateTimeParseFormats, tmpDateTimeStyles);

               var tmpDataSource = new DevAge.ComponentModel.BoundDataView(this.accountDataTable.DefaultView);
               tmpDataSource.AllowNew = false;
               tmpDataSource.AllowSort = true;
               this.dataGridAccount.DataSource = tmpDataSource;

               var tmpGridColor = System.Drawing.SystemColors.ActiveBorder;
               var tmpGridBorder = new DevAge.Drawing.RectangleBorder(new DevAge.Drawing.BorderLine(tmpGridColor, 0), new DevAge.Drawing.BorderLine(tmpGridColor));

               this.noFoundCellLeft = new SourceGrid.Cells.Views.Cell();
               this.defaultBackColor = this.noFoundCellLeft.BackColor;
               this.noFoundCellLeft.BackColor = this.noFoundBackColor;
               this.noFoundCellLeft.Font = ApplicationDefines.DefaultDataGridCellFont;
               this.noFoundCellLeft.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
               var tmpNoFoundViewLeft = new SourceGrid.Conditions.ConditionView(this.noFoundCellLeft);
               tmpNoFoundViewLeft.EvaluateFunction = delegate (SourceGrid.DataGridColumn column, int gridRow, object itemRow)
               {
                    var tmpDataRow = (System.Data.DataRowView)itemRow;
                    return (tmpDataRow[Account_Column_CompareResult] is short && (short)tmpDataRow[Account_Column_CompareResult] == 1);
               };

               this.noFoundCellCenter = new SourceGrid.Cells.Views.Cell();
               this.noFoundCellCenter.BackColor = this.noFoundBackColor;
               this.noFoundCellCenter.Font = ApplicationDefines.DefaultDataGridCellFont;
               this.noFoundCellCenter.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
               var tmpNoFoundViewCenter = new SourceGrid.Conditions.ConditionView(this.noFoundCellCenter);
               tmpNoFoundViewCenter.EvaluateFunction = delegate (SourceGrid.DataGridColumn column, int gridRow, object itemRow)
               {
                    var tmpDataRow = (System.Data.DataRowView)itemRow;
                    return (tmpDataRow[Account_Column_CompareResult] is short && (short)tmpDataRow[Account_Column_CompareResult] == 1);
               };

               var tmpSameLeftCell = new SourceGrid.Cells.Views.Cell();
               tmpSameLeftCell.Font = ApplicationDefines.DefaultDataGridCellFont;
               tmpSameLeftCell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
               var tmpSameLeftView = new SourceGrid.Conditions.ConditionView(tmpSameLeftCell);
               tmpSameLeftView.EvaluateFunction = delegate (SourceGrid.DataGridColumn column, int gridRow, object itemRow)
               {
                    var tmpDataRow = (System.Data.DataRowView)itemRow;
                    return (tmpDataRow[Account_Column_CompareResult] is short && (short)tmpDataRow[Account_Column_CompareResult] == 0);
               };

               var tmpSameCenterCell = new SourceGrid.Cells.Views.Cell();
               tmpSameCenterCell.Font = ApplicationDefines.DefaultDataGridCellFont;
               tmpSameCenterCell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
               var tmpSameCenterView = new SourceGrid.Conditions.ConditionView(tmpSameCenterCell);
               tmpSameCenterView.EvaluateFunction = delegate (SourceGrid.DataGridColumn column, int gridRow, object itemRow)
               {
                    var tmpDataRow = (System.Data.DataRowView)itemRow;
                    return (tmpDataRow[Account_Column_CompareResult] is short && (short)tmpDataRow[Account_Column_CompareResult] == 0);
               };


               this.unEqualCellLeft = new SourceGrid.Cells.Views.Cell();
               this.unEqualCellLeft.BackColor = this.unEqualBackColor;
               this.unEqualCellLeft.Font = ApplicationDefines.DefaultDataGridCellFont;
               this.unEqualCellLeft.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
               var tmpUnequalLeftView = new SourceGrid.Conditions.ConditionView(this.unEqualCellLeft);
               tmpUnequalLeftView.EvaluateFunction = delegate (SourceGrid.DataGridColumn column, int gridRow, object itemRow)
               {
                    var tmpDataRow = (System.Data.DataRowView)itemRow;
                    return (tmpDataRow[Account_Column_CompareResult] is short && (short)tmpDataRow[Account_Column_CompareResult] == 2);
               };

               this.unEqualCellCenter = new SourceGrid.Cells.Views.Cell();
               this.unEqualCellCenter.BackColor = this.unEqualBackColor;
               this.unEqualCellCenter.Font = ApplicationDefines.DefaultDataGridCellFont;
               this.unEqualCellCenter.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
               var tmpUnequalCenterView = new SourceGrid.Conditions.ConditionView(this.unEqualCellCenter);
               tmpUnequalCenterView.EvaluateFunction = delegate (SourceGrid.DataGridColumn column, int gridRow, object itemRow)
               {
                    var tmpDataRow = (System.Data.DataRowView)itemRow;
                    return (tmpDataRow[Account_Column_CompareResult] is short && (short)tmpDataRow[Account_Column_CompareResult] == 2);
               };


               this.checkBoxNoFound = new SourceGrid.Cells.Views.CheckBox();
               this.checkBoxNoFound.BackColor = this.noFoundBackColor;
               this.checkBoxNoFound.Font = ApplicationDefines.DefaultDataGridCellFont;
               this.checkBoxNoFound.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
               var tmpCheckViewNew = new SourceGrid.Conditions.ConditionView(this.checkBoxNoFound);
               tmpCheckViewNew.EvaluateFunction = delegate (SourceGrid.DataGridColumn column, int gridRow, object itemRow)
               {
                    var tmpDataRow = (System.Data.DataRowView)itemRow;
                    return (tmpDataRow[Account_Column_CompareResult] is short && (short)tmpDataRow[Account_Column_CompareResult] == 1);
               };

               var tmpCheckCellSame = new SourceGrid.Cells.Views.CheckBox();
               tmpCheckCellSame.Font = ApplicationDefines.DefaultDataGridCellFont;
               tmpCheckCellSame.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
               var tmpCheckViewSame = new SourceGrid.Conditions.ConditionView(tmpCheckCellSame);
               tmpCheckViewSame.EvaluateFunction = delegate (SourceGrid.DataGridColumn column, int gridRow, object itemRow)
               {
                    var tmpDataRow = (System.Data.DataRowView)itemRow;
                    return (tmpDataRow[Account_Column_CompareResult] is short && (short)tmpDataRow[Account_Column_CompareResult] == 0);
               };

               this.checkBoxUnEqual = new SourceGrid.Cells.Views.CheckBox();
               this.checkBoxUnEqual.BackColor = this.unEqualBackColor;
               this.checkBoxUnEqual.Font = ApplicationDefines.DefaultDataGridCellFont;
               this.checkBoxUnEqual.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
               var tmpCheckViewUnequal = new SourceGrid.Conditions.ConditionView(this.checkBoxUnEqual);
               tmpCheckViewUnequal.EvaluateFunction = delegate (SourceGrid.DataGridColumn column, int gridRow, object itemRow)
               {
                    var tmpDataRow = (System.Data.DataRowView)itemRow;
                    return (tmpDataRow[Account_Column_CompareResult] is short && (short)tmpDataRow[Account_Column_CompareResult] == 2);
               };

               for (int index = 0; index < this.dataGridAccount.Columns.Count; index++)
               {
                    var tmpCurrentColumn = this.dataGridAccount.Columns[index];
                    tmpCurrentColumn.HeaderCell.View.Border = tmpGridBorder;
                    tmpCurrentColumn.HeaderCell.View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;

                    if (tmpCurrentColumn.DataCell.Editor != null)
                    {
                         tmpCurrentColumn.DataCell.Editor.EnableEdit = false;
                    }

                    switch (tmpCurrentColumn.PropertyName)
                    {
                         case Account_Column_Order:
                         case Account_Column_TopMost:
                              tmpCurrentColumn.Width = 50;
                              tmpCurrentColumn.Visible = false;
                              break;

                         case Account_Column_AccountId:
                         case Account_Column_CreateTime:
                              tmpCurrentColumn.Width = 150;
                              tmpCurrentColumn.Visible = false;
                              break;

                         case Account_Column_Secret:
                              tmpCurrentColumn.Width = 80;
                              tmpCurrentColumn.Visible = false;
                              break;

                         case Account_Column_Selected:
                              tmpCurrentColumn.Width = 60;
                              tmpCurrentColumn.Visible = true;
                              tmpCurrentColumn.DataCell.Editor.EnableEdit = true;
                              break;

                         case Account_Column_Name:
                              tmpCurrentColumn.Width = 200;
                              break;

                         case Account_Column_LoginName:
                              tmpCurrentColumn.Width = 200;
                              break;

                         case Account_Column_Mobile:
                              tmpCurrentColumn.Width = 120;
                              break;

                         case Account_Column_Email:
                              tmpCurrentColumn.Width = 220;
                              break;

                         case Account_Column_URL:
                              tmpCurrentColumn.Width = 280;
                              break;

                         case Account_Column_UpdateTime:
                              tmpCurrentColumn.Width = 156;
                              tmpCurrentColumn.DataCell.Editor = tmpDateTimeEditor;
                              tmpCurrentColumn.DataCell.Editor.EnableEdit = false;
                              break;
                    }

                    switch (tmpCurrentColumn.PropertyName)
                    {
                         case Account_Column_Secret:
                              break;

                         case Account_Column_Selected:
                              tmpCurrentColumn.Conditions.Add(tmpCheckViewSame);
                              tmpCurrentColumn.Conditions.Add(tmpCheckViewNew);
                              tmpCurrentColumn.Conditions.Add(tmpCheckViewUnequal);
                              break;

                         case Account_Column_Name:
                         case Account_Column_LoginName:
                         case Account_Column_Email:
                         case Account_Column_URL:
                              tmpCurrentColumn.Conditions.Add(tmpSameLeftView);
                              tmpCurrentColumn.Conditions.Add(tmpNoFoundViewLeft);
                              tmpCurrentColumn.Conditions.Add(tmpUnequalLeftView);
                              break;

                         case Account_Column_Mobile:
                         case Account_Column_UpdateTime:
                              tmpCurrentColumn.Conditions.Add(tmpSameCenterView);
                              tmpCurrentColumn.Conditions.Add(tmpNoFoundViewCenter);
                              tmpCurrentColumn.Conditions.Add(tmpUnequalCenterView);
                              break;
                    }
               }

               this.tableChangingBlock = false;

               #endregion InitializeImportDataGrid
          }

          private void OnImportDataTableRowChanged(object sender, System.Data.DataRowChangeEventArgs args)
          {
               this.UpdateControlState();
          }

          private void SetDataGridLocalizedStrings()
          {
               const string FieldName = "m_Value";
               var tmpGridModelType = typeof(SourceGrid.Cells.Models.ValueModel);
               var tmpModelField = tmpGridModelType.GetField(FieldName);
               if (tmpModelField != null)
               {
                    for (int index = 0; index < this.dataGridAccount.Columns.Count; index++)
                    {
                         var tmpCurrentColumn = this.dataGridAccount.Columns[index];
                         switch (tmpCurrentColumn.PropertyName)
                         {
                              case Account_Column_AccountId:
                                   tmpModelField.SetValue(FieldName, SafePassResource.DataGridAccountColumnAccountGuid);
                                   break;

                              case Account_Column_TopMost:
                                   tmpModelField.SetValue(FieldName, SafePassResource.DataGridAccountColumnTopMost);
                                   break;

                              case Account_Column_Order:
                                   tmpModelField.SetValue(FieldName, SafePassResource.DataGridAccountColumnOrderNo);
                                   break;

                              case Account_Column_Name:
                                   tmpModelField.SetValue(FieldName, SafePassResource.DataGridAccountColumnName);
                                   break;

                              case Account_Column_Secret:
                                   tmpModelField.SetValue(FieldName, SafePassResource.DataGridAccountColumnSecret);
                                   break;

                              case Account_Column_LoginName:
                                   tmpModelField.SetValue(FieldName, SafePassResource.DataGridAccountColumnLoginName);
                                   break;

                              case Account_Column_Mobile:
                                   tmpModelField.SetValue(FieldName, SafePassResource.DataGridAccountColumnMobile);
                                   break;

                              case Account_Column_Email:
                                   tmpModelField.SetValue(FieldName, SafePassResource.DataGridAccountColumnEmail);
                                   break;

                              case Account_Column_URL:
                                   tmpModelField.SetValue(FieldName, SafePassResource.DataGridAccountColumnURL);
                                   break;

                              case Account_Column_CreateTime:
                                   tmpModelField.SetValue(FieldName, SafePassResource.DataGridAccountColumnCreateTime);
                                   break;

                              case Account_Column_UpdateTime:
                                   tmpModelField.SetValue(FieldName, SafePassResource.DataGridAccountColumnUpdateTime);
                                   break;
                         }
                    }
               }
          }

          private void OnCheckCompareWithCheckedChanged(object sender, System.EventArgs args)
          {
               if (!this.checkCompareWith.Checked)
               {
                    this.noFoundCellLeft.BackColor = this.defaultBackColor;
                    this.unEqualCellLeft.BackColor = this.defaultBackColor;

                    this.noFoundCellCenter.BackColor = this.defaultBackColor;
                    this.unEqualCellCenter.BackColor = this.defaultBackColor;

                    this.checkBoxNoFound.BackColor = this.defaultBackColor;
                    this.checkBoxUnEqual.BackColor = this.defaultBackColor;
               }
               else
               {
                    this.noFoundCellLeft.BackColor = this.noFoundBackColor;
                    this.unEqualCellLeft.BackColor = this.unEqualBackColor;

                    this.noFoundCellCenter.BackColor = this.noFoundBackColor;
                    this.unEqualCellCenter.BackColor = this.unEqualBackColor;

                    this.checkBoxNoFound.BackColor = this.noFoundBackColor;
                    this.checkBoxUnEqual.BackColor = this.unEqualBackColor;

                    if (this.accountDataTable != null)
                    {
                         foreach (System.Data.DataRow tmpCurrentRow in this.accountDataTable.Rows)
                         {
                              var tmpCompareResult = tmpCurrentRow[Account_Column_CompareResult];
                              if (tmpCompareResult is short)
                              {
                                   switch ((short)tmpCompareResult)
                                   {
                                        case 0:
                                        default:
                                             tmpCurrentRow[Account_Column_Selected] = false;
                                             break;

                                        case 1:
                                        case 2:
                                             tmpCurrentRow[Account_Column_Selected] = true;
                                             break;
                                   }
                              }
                         }
                    }
               }

               this.dataGridAccount.Refresh();
          }

          private void buttonSelectAll_Click(object sender, System.EventArgs args)
          {
               if (this.accountDataTable != null)
               {
                    for (int index = 0; index < this.accountDataTable.DefaultView.Count; index++)
                    {
                         this.accountDataTable.DefaultView[index][Account_Column_Selected] = true;
                    }
               }
          }

          private void buttonSelectNone_Click(object sender, System.EventArgs args)
          {
               if (this.accountDataTable != null)
               {
                    for (int index = 0; index < this.accountDataTable.DefaultView.Count; index++)
                    {
                         this.accountDataTable.DefaultView[index][Account_Column_Selected] = false;
                    }
               }
          }

          private void buttonUnSelected_Click(object sender, System.EventArgs args)
          {
               if (this.accountDataTable != null)
               {
                    for (int index = 0; index < this.accountDataTable.DefaultView.Count; index++)
                    {
                         if (object.Equals(this.accountDataTable.DefaultView[index][Account_Column_Selected], true))
                         {
                              this.accountDataTable.DefaultView[index][Account_Column_Selected] = false;
                         }
                         else
                         {
                              this.accountDataTable.DefaultView[index][Account_Column_Selected] = true;
                         }
                    }
               }
          }

          private void CreateCatalogTreeView(List<AccountCatalog> accountCatalogs)
          {
               this.treeViewCatalog.HideSelection = false;
               this.treeViewCatalog.Nodes.Clear();

               if (accountCatalogs != null)
               {
                    this.CreateCatalogTreeNodes(accountCatalogs, null, -1);
               }

               this.treeViewCatalog.ExpandAll();
               this.treeViewCatalog.LabelEdit = false;
          }

          private void CreateCatalogTreeNodes(List<AccountCatalog> accountCatalogs, TreeNode parentTreeNode, int parentId)
          {
               if (accountCatalogs == null)
               {
                    return;
               }

               accountCatalogs.ForEach(item =>
               {
                    if (item.ParentId == parentId)
                    {
                         var tmpCatalogNode = new TreeNode();
                         tmpCatalogNode.Text = item.Name;
                         tmpCatalogNode.Tag = item;
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
               });

               if (parentTreeNode != null)
               {
                    foreach (TreeNode tmpCatalogNode in parentTreeNode.Nodes)
                    {
                         this.CreateCatalogTreeNodes(accountCatalogs, tmpCatalogNode, ((AccountCatalog)(tmpCatalogNode.Tag)).CatalogId);
                    }
               }
               else
               {
                    foreach (TreeNode tmpCatalogNode in this.treeViewCatalog.Nodes)
                    {
                         this.CreateCatalogTreeNodes(accountCatalogs, tmpCatalogNode, ((AccountCatalog)(tmpCatalogNode.Tag)).CatalogId);
                    }
               }
          }

          private void OnTreeViewCatalogAfterSelect(object sender, TreeViewEventArgs args)
          {
               var tmpSelectedNode = this.treeViewCatalog.SelectedNode;
               if (tmpSelectedNode == this.recycleBinTreeNode)
               {
                    this.accountDataTable.DefaultView.RowFilter = string.Format("{0}={1}", Account_Column_Deleted, true);
               }
               else if (tmpSelectedNode != null && tmpSelectedNode.Tag is AccountCatalog)
               {
                    var tmpCatalogItem = (AccountCatalog)tmpSelectedNode.Tag;
                    if (tmpCatalogItem != null)
                    {
                         this.accountDataTable.DefaultView.RowFilter = string.Format("{0}={1} AND {2}={3}", Account_Column_Deleted, false, Account_Column_CatalogId, tmpCatalogItem.CatalogId);
                    }
               }

               this.UpdateControlState();
          }

          private void OnTreeViewCatalogAfterCheck(object sender, TreeViewEventArgs args)
          {
               System.Data.DataRow[] tmpAffectedRows = null;

               var tmpCheckTreeNode = args.Node;
               if (tmpCheckTreeNode == this.recycleBinTreeNode)
               {
                    tmpAffectedRows = this.accountDataTable.Select(string.Format("{0}={1}", Account_Column_Deleted, true));
               }
               else if (tmpCheckTreeNode != null && tmpCheckTreeNode.Tag is AccountCatalog)
               {
                    var tmpCurrentCatalog = (AccountCatalog)tmpCheckTreeNode.Tag;
                    if (tmpCurrentCatalog != null)
                    {
                         tmpAffectedRows = this.accountDataTable.Select(string.Format("{0}={1}", Account_Column_CatalogId, tmpCurrentCatalog.CatalogId));
                    }
               }

               if (tmpAffectedRows != null && tmpAffectedRows.Length > 0)
               {
                    var tmpNodeChecked = tmpCheckTreeNode.Checked;
                    foreach (var tmpCurrentRow in tmpAffectedRows)
                    {
                         tmpCurrentRow[Account_Column_Selected] = tmpNodeChecked;
                    }
               }
          }

          private void textImportFile_TextChanged(object sender, System.EventArgs args)
          {
               this.UpdateControlState();
          }

          private void OnCloseButtonClick(object sender, System.EventArgs args)
          {
               this.Close();
          }

          private List<AccountModel> importingAccounts = null;
          private List<AccountCatalog> accountCatalogs = null;

          private void OnSelectFileButtonClick(object sender, System.EventArgs args)
          {
               var tmpOpenFileDialog = new OpenFileDialog();
               tmpOpenFileDialog.ShowHelp = false;
               tmpOpenFileDialog.ShowReadOnly = false;
               tmpOpenFileDialog.CheckFileExists = true;
               tmpOpenFileDialog.CheckPathExists = true;
               tmpOpenFileDialog.ReadOnlyChecked = false;
               tmpOpenFileDialog.DereferenceLinks = true;
               tmpOpenFileDialog.ValidateNames = true;
               tmpOpenFileDialog.RestoreDirectory = false;
               tmpOpenFileDialog.Title = SafePassResource.ImportDialogTitle;
               tmpOpenFileDialog.Filter = SafePassResource.ImportXML1xFilter;

               if (System.IO.Directory.Exists(this.textImportFile.Text))
               {
                    tmpOpenFileDialog.InitialDirectory = this.textImportFile.Text;
               }

               if (tmpOpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
               {
                    this.textImportFile.Text = tmpOpenFileDialog.FileName;

                    var tmpFileInfo = new System.IO.FileInfo(tmpOpenFileDialog.FileName);
                    if (tmpFileInfo.Exists)
                    {
                         Cursor.Current = Cursors.WaitCursor;

                         this.tableChangingBlock = true;
                         this.accountDataTable.BeginLoadData();
                         this.accountDataTable.Rows.Clear();

                         this.accountCatalogs = ImportAccountHelper.ReadAccountCatalogs(tmpFileInfo.FullName);
                         if (this.accountCatalogs != null)
                         {
                              this.CreateCatalogTreeView(this.accountCatalogs);
                              this.CreateSpecialTreeNode();
                         }

                         this.importingAccounts = ImportAccountHelper.ReadAccountModels(tmpFileInfo.FullName);
                         if (this.importingAccounts != null)
                         {
                              int dataRowIndex = 0;
                              this.importingAccounts.ForEach(item =>
                              {
                                   AccountModel tmpAccountInfo = null;
                                   if (this.CurrentAccounts != null)
                                   {
                                        tmpAccountInfo = this.CurrentAccounts.Find(delegate (AccountModel account)
                                        {
                                             return account.AccountGuid == item.AccountGuid;
                                        });
                                   }

                                   var tmpNewAccountRow = this.accountDataTable.NewRow();

                                   if (tmpAccountInfo == null)
                                   {
                                        tmpNewAccountRow[Account_Column_Selected] = true;
                                        tmpNewAccountRow[Account_Column_CompareResult] = 1;
                                   }
                                   else if(item.CompareTo(tmpAccountInfo))
                                   {
                                        tmpNewAccountRow[Account_Column_Selected] = false;
                                        tmpNewAccountRow[Account_Column_CompareResult] = 0;
                                   }
                                   else
                                   {
                                        tmpNewAccountRow[Account_Column_Selected] = true;
                                        tmpNewAccountRow[Account_Column_CompareResult] = 2;
                                   }

                                   tmpNewAccountRow[Account_Column_Deleted] = item.Deleted;
                                   tmpNewAccountRow[Account_Column_Order] = ++dataRowIndex;
                                   tmpNewAccountRow[Account_Column_AccountGuid] = item.AccountGuid;
                                   tmpNewAccountRow[Account_Column_AccountId] = item.AccountId;
                                   tmpNewAccountRow[Account_Column_CatalogId] = item.CatalogId;
                                   tmpNewAccountRow[Account_Column_Name] = item.Name;
                                   tmpNewAccountRow[Account_Column_TopMost] = item.TopMost;
                                   tmpNewAccountRow[Account_Column_Secret] = item.SecretRank;

                                   tmpNewAccountRow[Account_Column_URL] = item.URL;
                                   tmpNewAccountRow[Account_Column_LoginName] = item.LoginName;
                                   tmpNewAccountRow[Account_Column_Email] = item.Email;
                                   tmpNewAccountRow[Account_Column_Mobile] = item.Mobile;
                                   tmpNewAccountRow[Account_Column_CreateTime] = item.CreateTime;
                                   tmpNewAccountRow[Account_Column_UpdateTime] = item.UpdateTime;

                                   this.accountDataTable.Rows.Add(tmpNewAccountRow);
                              });
                         }

                         this.accountDataTable.EndLoadData();
                         this.tableChangingBlock = false;

                         Cursor.Current = Cursors.Default;

                         if (this.treeViewCatalog.Nodes.Count > 0)
                         {
                              this.treeViewCatalog.SelectedNode = this.treeViewCatalog.Nodes[0];
                         }
                    }

                    this.UpdateControlState();
               }
          }

          private bool tableChangingBlock = false;

          private void UpdateControlState( )
          {
               if (this.tableChangingBlock)
               {
                    return;
               }

               if (this.accountDataTable == null)
               {
                    this.buttonSelectAll.Enabled = false;
                    this.buttonStartImport.Enabled = false;
               }
               else
               {
                    var tmpItemCount = this.accountDataTable.DefaultView.Count;
                    this.buttonSelectAll.Enabled = tmpItemCount > 0;

                    var tmpSelectedRows = this.accountDataTable.Select(string.Format("{0}=true", Account_Column_Selected));
                    this.buttonStartImport.Enabled = (tmpSelectedRows != null && tmpSelectedRows.Length > 0);
               }

               this.buttonUnSelected.Enabled = this.buttonSelectAll.Enabled;
               this.buttonSelectNone.Enabled = this.buttonSelectAll.Enabled;
          }

          private void UpdateProgressControls(bool show)
          {
               if (show)
               {
                    this.progressBarImport.Value = 0;
                    this.panelProgress.Visible = true;
                    this.labelProgress.Text = string.Format(SafePassResource.ImportWindowMessageImportProgress, string.Empty);
               }
               else
               {
                    this.progressBarImport.Value = 0;
                    this.panelProgress.Visible = false;
                    this.labelProgress.Text = string.Format(SafePassResource.ImportWindowMessageImportProgress, string.Empty);
               }
          }

          private void OnStartImportButtonClick(object sender, System.EventArgs args)
          {
               if (this.importingAccounts == null || this.accountDataTable == null)
               {
                    return;
               }

               this.buttonStartImport.Enabled = false;

               var tmpSelectedRows = this.accountDataTable.Select(string.Format("{0}=true", Account_Column_Selected));
               if (tmpSelectedRows != null && tmpSelectedRows.Length > 0)
               {
                    Cursor.Current = Cursors.WaitCursor;
                    var tmpProgressMessage = SafePassResource.ImportWindowMessageImportProgress;

                    int count = 0;
                    this.UpdateProgressControls(true);

                    var tmpCatalogService = new HuiruiSoft.Safe.Service.CatalogService();
                    foreach (var catalog in this.accountCatalogs)
                    {
                         var tmpDbCatalog = tmpCatalogService.GetAccountCatalog(catalog.CatalogId);
                         if (tmpDbCatalog == null)
                         {
                              var tmpCreateResult = tmpCatalogService.New(catalog);
                         }
                    }

                    var tmpAccountService = new HuiruiSoft.Safe.Service.AccountService();
                    foreach (var tmpCurrentRow in tmpSelectedRows)
                    {
                         count++;
                         this.progressBarImport.Value = count * 100 / tmpSelectedRows.Length;

                         var tmpAccountGuid = (string)(tmpCurrentRow[Account_Column_AccountGuid]);
                         var tmpAccountModel = this.importingAccounts.Find(delegate (AccountModel item)
                         {
                              return tmpAccountGuid == item.AccountGuid;
                         });

                         if (tmpAccountModel != null)
                         {
                              this.labelProgress.Text = string.Format(tmpProgressMessage, tmpAccountModel.Name);
                              System.Windows.Forms.Application.DoEvents();

                              var tmpAccountInfo = (AccountModel)tmpAccountModel.Clone();
                              if (string.IsNullOrEmpty(tmpAccountInfo.AccountGuid))
                              {
                                   tmpAccountInfo.AccountGuid = System.Guid.NewGuid().ToString("N");
                              }

                              if (tmpAccountInfo.Name == null)
                              {
                                   tmpAccountInfo.Name = string.Empty;
                              }

                              if (tmpAccountInfo.LoginName == null)
                              {
                                   tmpAccountInfo.LoginName = string.Empty;
                              }

                              if (tmpAccountInfo.Password == null)
                              {
                                   tmpAccountInfo.Password = string.Empty;
                              }

                              bool tmpFoundResult = false;
                              if (this.CurrentAccounts != null)
                              {
                                   tmpFoundResult = this.CurrentAccounts.Exists(item => item.AccountGuid == tmpAccountInfo.AccountGuid);
                              }

                              if (tmpFoundResult)
                              {
                                   bool tmpUpdateResult = tmpAccountService.UpdateAccount(tmpAccountInfo);
                              }
                              else
                              {
                                   bool tmpCreateResult = tmpAccountService.CreateAccount(tmpAccountInfo);
                              }
                         }
                    }

                    this.UpdateProgressControls(false);
                    Cursor.Current = Cursors.Default;
               }

               this.UpdateControlState();
               MessageBox.Show(string.Format(SafePassResource.ImportWindowMessageImportFinished, this.textImportFile.Text), SafePassResource.ImportWindowCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
               this.DialogResult = DialogResult.OK;
          }
     }
}
