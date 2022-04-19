namespace HuiruiSoft.Safe
{
     partial class formAccountManager
     {
          private System.ComponentModel.IContainer components = null;

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
               System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formAccountManager));
               this.dataGridAccount = new SourceGrid.DataGrid();
               this.toolBarStrip = new System.Windows.Forms.ToolStrip();
               this.toolButtonCatalogCreate = new System.Windows.Forms.ToolStripButton();
               this.toolButtonCatalogEdit = new System.Windows.Forms.ToolStripButton();
               this.toolButtonCatalogDelete = new System.Windows.Forms.ToolStripButton();
               this.toolSeparatorEntry = new System.Windows.Forms.ToolStripSeparator();
               this.toolButtonEntryCreate = new System.Windows.Forms.ToolStripButton();
               this.toolButtonEntryEdit = new System.Windows.Forms.ToolStripButton();
               this.toolButtonEntryDelete = new System.Windows.Forms.ToolStripButton();
               this.toolComboBoxQuickFind = new System.Windows.Forms.ToolStripComboBox();
               this.toolSeparatorRefresh = new System.Windows.Forms.ToolStripSeparator();
               this.toolButtonDataRefresh = new System.Windows.Forms.ToolStripButton();
               this.toolSeparatorTools = new System.Windows.Forms.ToolStripSeparator();
               this.toolButtonToolsOptions = new System.Windows.Forms.ToolStripButton();
               this.toolSeparatorLock = new System.Windows.Forms.ToolStripSeparator();
               this.toolButtonLockWindow = new System.Windows.Forms.ToolStripButton();
               this.toolButtonLockScreen = new System.Windows.Forms.ToolStripButton();
               this.toolButtonExitWorkspace = new System.Windows.Forms.ToolStripButton();
               this.stripStatusBar = new System.Windows.Forms.StatusStrip();
               this.statusPartSelected = new System.Windows.Forms.ToolStripStatusLabel();
               this.statusPartMessage = new System.Windows.Forms.ToolStripStatusLabel();
               this.statusPartClipboard = new System.Windows.Forms.ToolStripProgressBar();
               this.statusPartProgress = new System.Windows.Forms.ToolStripProgressBar();
               this.splitControls = new System.Windows.Forms.SplitContainer();
               this.treeViewCatalog = new System.Windows.Forms.TreeView();
               this.treeNodeImages = new System.Windows.Forms.ImageList(this.components);
               this.menuStripMain = new System.Windows.Forms.MenuStrip();
               this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
               this.menuItemChangePassword = new System.Windows.Forms.ToolStripMenuItem();
               this.toolSeparatorFile2 = new System.Windows.Forms.ToolStripSeparator();
               this.menuItemFileImport = new System.Windows.Forms.ToolStripMenuItem();
               this.menuItemFileExport = new System.Windows.Forms.ToolStripMenuItem();
               this.toolSeparatorFile3 = new System.Windows.Forms.ToolStripSeparator();
               this.menuItemExitWorkspace = new System.Windows.Forms.ToolStripMenuItem();
               this.menuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
               this.menuItemView = new System.Windows.Forms.ToolStripMenuItem();
               this.menuItemChangeLanguage = new System.Windows.Forms.ToolStripMenuItem();
               this.toolSeparatorView1 = new System.Windows.Forms.ToolStripSeparator();
               this.menuItemViewToolBar = new System.Windows.Forms.ToolStripMenuItem();
               this.menuItemViewStatusBar = new System.Windows.Forms.ToolStripMenuItem();
               this.menuItemTools = new System.Windows.Forms.ToolStripMenuItem();
               this.menuItemLockWindow = new System.Windows.Forms.ToolStripMenuItem();
               this.menuItemLockScreen = new System.Windows.Forms.ToolStripMenuItem();
               this.toolSeparatorTools1 = new System.Windows.Forms.ToolStripSeparator();
               this.menuItemToolsOptions = new System.Windows.Forms.ToolStripMenuItem();
               this.menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
               this.menuItemHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
               this.menuItemHelpCheckUpdate = new System.Windows.Forms.ToolStripMenuItem();
               this.menuStripDataGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
               this.menuItemRestoreRecycleBin = new System.Windows.Forms.ToolStripMenuItem();
               this.toolSeparatorRestore = new System.Windows.Forms.ToolStripSeparator();
               this.menuItemAccountTopLevel = new System.Windows.Forms.ToolStripMenuItem();
               this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
               this.menuItemEntryCreate = new System.Windows.Forms.ToolStripMenuItem();
               this.menuItemEntryEdit = new System.Windows.Forms.ToolStripMenuItem();
               this.menuItemEntryDelete = new System.Windows.Forms.ToolStripMenuItem();
               this.menuItemEntryMoveTo = new System.Windows.Forms.ToolStripMenuItem();
               this.menuItemSelectAll = new System.Windows.Forms.ToolStripMenuItem();
               this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
               this.menuItemCopyUserName = new System.Windows.Forms.ToolStripMenuItem();
               this.menuItemCopyPassword = new System.Windows.Forms.ToolStripMenuItem();
               this.menuItemCopyMobile = new System.Windows.Forms.ToolStripMenuItem();
               this.menuItemCopyEmail = new System.Windows.Forms.ToolStripMenuItem();
               this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
               this.menuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
               this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
               this.menuItemReArrangePopup = new System.Windows.Forms.ToolStripMenuItem();
               this.menuItemAccountMoveToTop = new System.Windows.Forms.ToolStripMenuItem();
               this.menuItemAccountMoveOneUp = new System.Windows.Forms.ToolStripMenuItem();
               this.menuItemAccountMoveOneDown = new System.Windows.Forms.ToolStripMenuItem();
               this.menuItemAccountMoveToBottom = new System.Windows.Forms.ToolStripMenuItem();
               this.menuStripTreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
               this.menuItemCatalogCreate = new System.Windows.Forms.ToolStripMenuItem();
               this.menuItemCatalogEdit = new System.Windows.Forms.ToolStripMenuItem();
               this.menuItemCatalogDelete = new System.Windows.Forms.ToolStripMenuItem();
               this.toolSeparatorRecycleBin = new System.Windows.Forms.ToolStripSeparator();
               this.menuItemEmptyRecycleBin = new System.Windows.Forms.ToolStripMenuItem();
               this.menuStripTray = new System.Windows.Forms.ContextMenuStrip(this.components);
               this.menuItemSwitchSystemTray = new System.Windows.Forms.ToolStripMenuItem();
               this.notifyIconTray = new System.Windows.Forms.NotifyIcon(this.components);
               this.toolSeparatorHelp = new System.Windows.Forms.ToolStripSeparator();
               this.toolBarStrip.SuspendLayout();
               this.stripStatusBar.SuspendLayout();
               this.splitControls.Panel1.SuspendLayout();
               this.splitControls.Panel2.SuspendLayout();
               this.splitControls.SuspendLayout();
               this.menuStripMain.SuspendLayout();
               this.menuStripDataGrid.SuspendLayout();
               this.menuStripTreeView.SuspendLayout();
               this.menuStripTray.SuspendLayout();
               this.SuspendLayout();
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
               this.dataGridAccount.Size = new System.Drawing.Size(1119, 615);
               this.dataGridAccount.TabIndex = 5;
               this.dataGridAccount.TabStop = true;
               this.dataGridAccount.ToolTipText = "";
               this.dataGridAccount.DoubleClick += new System.EventHandler(this.dataGridAccount_DoubleClick);
               this.dataGridAccount.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridAccount_MouseDown);
               this.dataGridAccount.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dataGridAccount_MouseUp);
               this.dataGridAccount.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dataGridAccount_PreviewKeyDown);
               // 
               // toolBarStrip
               // 
               this.toolBarStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
               this.toolBarStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolButtonCatalogCreate,
            this.toolButtonCatalogEdit,
            this.toolButtonCatalogDelete,
            this.toolSeparatorEntry,
            this.toolButtonEntryCreate,
            this.toolButtonEntryEdit,
            this.toolButtonEntryDelete,
            this.toolComboBoxQuickFind,
            this.toolSeparatorRefresh,
            this.toolButtonDataRefresh,
            this.toolSeparatorTools,
            this.toolButtonToolsOptions,
            this.toolSeparatorLock,
            this.toolButtonLockWindow,
            this.toolButtonLockScreen,
            this.toolButtonExitWorkspace});
               this.toolBarStrip.Location = new System.Drawing.Point(0, 32);
               this.toolBarStrip.Name = "toolBarStrip";
               this.toolBarStrip.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
               this.toolBarStrip.Size = new System.Drawing.Size(1512, 65);
               this.toolBarStrip.TabIndex = 8;
               // 
               // toolButtonCatalogCreate
               // 
               this.toolButtonCatalogCreate.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonCatalogCreate.Image")));
               this.toolButtonCatalogCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
               this.toolButtonCatalogCreate.Name = "toolButtonCatalogCreate";
               this.toolButtonCatalogCreate.Size = new System.Drawing.Size(125, 60);
               this.toolButtonCatalogCreate.Text = "New Catalog";
               this.toolButtonCatalogCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
               this.toolButtonCatalogCreate.ToolTipText = "New Catalog...";
               // 
               // toolButtonCatalogEdit
               // 
               this.toolButtonCatalogEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonCatalogEdit.Image")));
               this.toolButtonCatalogEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
               this.toolButtonCatalogEdit.Name = "toolButtonCatalogEdit";
               this.toolButtonCatalogEdit.Size = new System.Drawing.Size(120, 60);
               this.toolButtonCatalogEdit.Text = "Edit Catalog";
               this.toolButtonCatalogEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
               this.toolButtonCatalogEdit.ToolTipText = "Edit Catalog...";
               // 
               // toolButtonCatalogDelete
               // 
               this.toolButtonCatalogDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonCatalogDelete.Image")));
               this.toolButtonCatalogDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
               this.toolButtonCatalogDelete.Name = "toolButtonCatalogDelete";
               this.toolButtonCatalogDelete.Size = new System.Drawing.Size(142, 60);
               this.toolButtonCatalogDelete.Text = "Delete Catalog";
               this.toolButtonCatalogDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
               this.toolButtonCatalogDelete.ToolTipText = "Delete Catalog";
               // 
               // toolSeparatorEntry
               // 
               this.toolSeparatorEntry.Name = "toolSeparatorEntry";
               this.toolSeparatorEntry.Size = new System.Drawing.Size(6, 65);
               // 
               // toolButtonEntryCreate
               // 
               this.toolButtonEntryCreate.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonEntryCreate.Image")));
               this.toolButtonEntryCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
               this.toolButtonEntryCreate.Name = "toolButtonEntryCreate";
               this.toolButtonEntryCreate.Size = new System.Drawing.Size(129, 60);
               this.toolButtonEntryCreate.Text = "New Account";
               this.toolButtonEntryCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
               // 
               // toolButtonEntryEdit
               // 
               this.toolButtonEntryEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonEntryEdit.Image")));
               this.toolButtonEntryEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
               this.toolButtonEntryEdit.Name = "toolButtonEntryEdit";
               this.toolButtonEntryEdit.Size = new System.Drawing.Size(124, 60);
               this.toolButtonEntryEdit.Text = "Edit Account";
               this.toolButtonEntryEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
               // 
               // toolButtonEntryDelete
               // 
               this.toolButtonEntryDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonEntryDelete.Image")));
               this.toolButtonEntryDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
               this.toolButtonEntryDelete.Name = "toolButtonEntryDelete";
               this.toolButtonEntryDelete.Size = new System.Drawing.Size(146, 60);
               this.toolButtonEntryDelete.Text = "Delete Account";
               this.toolButtonEntryDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
               // 
               // toolComboBoxQuickFind
               // 
               this.toolComboBoxQuickFind.Name = "toolComboBoxQuickFind";
               this.toolComboBoxQuickFind.Size = new System.Drawing.Size(300, 65);
               this.toolComboBoxQuickFind.SelectedIndexChanged += new System.EventHandler(this.OnToolComboBoxQuickFindSelectedIndexChanged);
               this.toolComboBoxQuickFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnToolComboBoxQuickFindKeyDown);
               this.toolComboBoxQuickFind.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnToolComboBoxQuickFindKeyUp);
               // 
               // toolSeparatorRefresh
               // 
               this.toolSeparatorRefresh.Name = "toolSeparatorRefresh";
               this.toolSeparatorRefresh.Size = new System.Drawing.Size(6, 65);
               // 
               // toolButtonDataRefresh
               // 
               this.toolButtonDataRefresh.Image = global::HuiruiSoft.Safe.Properties.Resources.Refresh32x32;
               this.toolButtonDataRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
               this.toolButtonDataRefresh.Name = "toolButtonDataRefresh";
               this.toolButtonDataRefresh.Size = new System.Drawing.Size(78, 60);
               this.toolButtonDataRefresh.Text = "Refresh";
               this.toolButtonDataRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
               // 
               // toolSeparatorTools
               // 
               this.toolSeparatorTools.Name = "toolSeparatorTools";
               this.toolSeparatorTools.Size = new System.Drawing.Size(6, 65);
               // 
               // toolButtonToolsOptions
               // 
               this.toolButtonToolsOptions.Image = global::HuiruiSoft.Safe.Properties.Resources.CustomizeLarge;
               this.toolButtonToolsOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
               this.toolButtonToolsOptions.Name = "toolButtonToolsOptions";
               this.toolButtonToolsOptions.Size = new System.Drawing.Size(83, 60);
               this.toolButtonToolsOptions.Text = "Options";
               this.toolButtonToolsOptions.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
               // 
               // toolSeparatorLock
               // 
               this.toolSeparatorLock.Name = "toolSeparatorLock";
               this.toolSeparatorLock.Size = new System.Drawing.Size(6, 65);
               // 
               // toolButtonLockWindow
               // 
               this.toolButtonLockWindow.Image = global::HuiruiSoft.Safe.Properties.Resources.LockWindow;
               this.toolButtonLockWindow.ImageTransparentColor = System.Drawing.Color.Magenta;
               this.toolButtonLockWindow.Name = "toolButtonLockWindow";
               this.toolButtonLockWindow.Size = new System.Drawing.Size(129, 60);
               this.toolButtonLockWindow.Text = "Lock Window";
               this.toolButtonLockWindow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
               // 
               // toolButtonLockScreen
               // 
               this.toolButtonLockScreen.Image = global::HuiruiSoft.Safe.Properties.Resources.Shutdown_02;
               this.toolButtonLockScreen.ImageTransparentColor = System.Drawing.Color.Magenta;
               this.toolButtonLockScreen.Name = "toolButtonLockScreen";
               this.toolButtonLockScreen.Size = new System.Drawing.Size(115, 60);
               this.toolButtonLockScreen.Text = "Lock Screen";
               this.toolButtonLockScreen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
               // 
               // toolButtonExitWorkspace
               // 
               this.toolButtonExitWorkspace.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonExitWorkspace.Image")));
               this.toolButtonExitWorkspace.ImageTransparentColor = System.Drawing.Color.Magenta;
               this.toolButtonExitWorkspace.Name = "toolButtonExitWorkspace";
               this.toolButtonExitWorkspace.Size = new System.Drawing.Size(121, 60);
               this.toolButtonExitWorkspace.Text = "Exit Window";
               this.toolButtonExitWorkspace.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
               // 
               // stripStatusBar
               // 
               this.stripStatusBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
               this.stripStatusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
               this.stripStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusPartSelected,
            this.statusPartMessage,
            this.statusPartClipboard,
            this.statusPartProgress});
               this.stripStatusBar.Location = new System.Drawing.Point(0, 808);
               this.stripStatusBar.Name = "stripStatusBar";
               this.stripStatusBar.Padding = new System.Windows.Forms.Padding(2, 0, 15, 0);
               this.stripStatusBar.Size = new System.Drawing.Size(1512, 38);
               this.stripStatusBar.SizingGrip = false;
               this.stripStatusBar.TabIndex = 7;
               // 
               // statusPartSelected
               // 
               this.statusPartSelected.AutoSize = false;
               this.statusPartSelected.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
               this.statusPartSelected.Name = "statusPartSelected";
               this.statusPartSelected.Size = new System.Drawing.Size(360, 31);
               this.statusPartSelected.Text = "0 items";
               this.statusPartSelected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
               // 
               // statusPartMessage
               // 
               this.statusPartMessage.Name = "statusPartMessage";
               this.statusPartMessage.Size = new System.Drawing.Size(847, 31);
               this.statusPartMessage.Spring = true;
               this.statusPartMessage.Text = "Ready.";
               this.statusPartMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
               // 
               // statusPartClipboard
               // 
               this.statusPartClipboard.AutoSize = false;
               this.statusPartClipboard.Name = "statusPartClipboard";
               this.statusPartClipboard.Size = new System.Drawing.Size(100, 30);
               // 
               // statusPartProgress
               // 
               this.statusPartProgress.AutoSize = false;
               this.statusPartProgress.Name = "statusPartProgress";
               this.statusPartProgress.Size = new System.Drawing.Size(180, 30);
               this.statusPartProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
               this.statusPartProgress.Value = 90;
               // 
               // splitControls
               // 
               this.splitControls.Location = new System.Drawing.Point(15, 137);
               this.splitControls.Name = "splitControls";
               // 
               // splitControls.Panel1
               // 
               this.splitControls.Panel1.Controls.Add(this.treeViewCatalog);
               // 
               // splitControls.Panel2
               // 
               this.splitControls.Panel2.Controls.Add(this.dataGridAccount);
               this.splitControls.Size = new System.Drawing.Size(1483, 651);
               this.splitControls.SplitterDistance = 328;
               this.splitControls.SplitterWidth = 6;
               this.splitControls.TabIndex = 9;
               // 
               // treeViewCatalog
               // 
               this.treeViewCatalog.ImageIndex = 0;
               this.treeViewCatalog.ImageList = this.treeNodeImages;
               this.treeViewCatalog.Location = new System.Drawing.Point(16, 19);
               this.treeViewCatalog.Name = "treeViewCatalog";
               this.treeViewCatalog.SelectedImageIndex = 0;
               this.treeViewCatalog.Size = new System.Drawing.Size(289, 615);
               this.treeViewCatalog.TabIndex = 0;
               this.treeViewCatalog.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnTreeViewCatalogAfterSelect);
               this.treeViewCatalog.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.OnTreeViewCatalogNodeMouseClick);
               this.treeViewCatalog.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnTreeViewCatalogKeyDown);
               this.treeViewCatalog.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnTreeViewCatalogKeyUp);
               // 
               // treeNodeImages
               // 
               this.treeNodeImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeNodeImages.ImageStream")));
               this.treeNodeImages.TransparentColor = System.Drawing.Color.Transparent;
               this.treeNodeImages.Images.SetKeyName(0, "Small_Explorer.ico");
               this.treeNodeImages.Images.SetKeyName(1, "Small_FolderExpanded.ico");
               this.treeNodeImages.Images.SetKeyName(2, "DataManagement.png");
               this.treeNodeImages.Images.SetKeyName(3, "search_128x128.png");
               // 
               // menuStripMain
               // 
               this.menuStripMain.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
               this.menuStripMain.ImageScalingSize = new System.Drawing.Size(24, 24);
               this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemEdit,
            this.menuItemView,
            this.menuItemTools,
            this.menuItemHelp});
               this.menuStripMain.Location = new System.Drawing.Point(0, 0);
               this.menuStripMain.Name = "menuStripMain";
               this.menuStripMain.Size = new System.Drawing.Size(1512, 32);
               this.menuStripMain.TabIndex = 10;
               this.menuStripMain.Text = "Main Menu";
               // 
               // menuItemFile
               // 
               this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemChangePassword,
            this.toolSeparatorFile2,
            this.menuItemFileImport,
            this.menuItemFileExport,
            this.toolSeparatorFile3,
            this.menuItemExitWorkspace});
               this.menuItemFile.Name = "menuItemFile";
               this.menuItemFile.Size = new System.Drawing.Size(56, 28);
               this.menuItemFile.Text = "&File";
               // 
               // menuItemChangePassword
               // 
               this.menuItemChangePassword.Name = "menuItemChangePassword";
               this.menuItemChangePassword.Size = new System.Drawing.Size(275, 34);
               this.menuItemChangePassword.Text = "Change password...";
               this.menuItemChangePassword.Click += new System.EventHandler(this.OnChangePasswordMenuItemClick);
               // 
               // toolSeparatorFile2
               // 
               this.toolSeparatorFile2.Name = "toolSeparatorFile2";
               this.toolSeparatorFile2.Size = new System.Drawing.Size(272, 6);
               // 
               // menuItemFileImport
               // 
               this.menuItemFileImport.Name = "menuItemFileImport";
               this.menuItemFileImport.Size = new System.Drawing.Size(275, 34);
               this.menuItemFileImport.Text = "&Import...";
               this.menuItemFileImport.Click += new System.EventHandler(this.OnImportEntryMenuItemClick);
               // 
               // menuItemFileExport
               // 
               this.menuItemFileExport.Image = ((System.Drawing.Image)(resources.GetObject("menuItemFileExport.Image")));
               this.menuItemFileExport.Name = "menuItemFileExport";
               this.menuItemFileExport.Size = new System.Drawing.Size(275, 34);
               this.menuItemFileExport.Text = "&Export...";
               this.menuItemFileExport.Click += new System.EventHandler(this.OnExportEntryMenuItemClick);
               // 
               // toolSeparatorFile3
               // 
               this.toolSeparatorFile3.Name = "toolSeparatorFile3";
               this.toolSeparatorFile3.Size = new System.Drawing.Size(272, 6);
               // 
               // menuItemExitWorkspace
               // 
               this.menuItemExitWorkspace.Name = "menuItemExitWorkspace";
               this.menuItemExitWorkspace.Size = new System.Drawing.Size(275, 34);
               this.menuItemExitWorkspace.Text = "E&xit";
               this.menuItemExitWorkspace.Click += new System.EventHandler(this.OnExitWorkspaceMenuItemClick);
               // 
               // menuItemEdit
               // 
               this.menuItemEdit.Name = "menuItemEdit";
               this.menuItemEdit.Size = new System.Drawing.Size(60, 28);
               this.menuItemEdit.Text = "&Edit";
               // 
               // menuItemView
               // 
               this.menuItemView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemChangeLanguage,
            this.toolSeparatorView1,
            this.menuItemViewToolBar,
            this.menuItemViewStatusBar});
               this.menuItemView.Name = "menuItemView";
               this.menuItemView.Size = new System.Drawing.Size(67, 28);
               this.menuItemView.Text = "&View";
               // 
               // menuItemChangeLanguage
               // 
               this.menuItemChangeLanguage.Name = "menuItemChangeLanguage";
               this.menuItemChangeLanguage.Size = new System.Drawing.Size(291, 34);
               this.menuItemChangeLanguage.Text = "Change &Language...";
               this.menuItemChangeLanguage.Click += new System.EventHandler(this.OnChangeLanguageMenuItemClick);
               // 
               // toolSeparatorView1
               // 
               this.toolSeparatorView1.Name = "toolSeparatorView1";
               this.toolSeparatorView1.Size = new System.Drawing.Size(288, 6);
               // 
               // menuItemViewToolBar
               // 
               this.menuItemViewToolBar.Name = "menuItemViewToolBar";
               this.menuItemViewToolBar.Size = new System.Drawing.Size(291, 34);
               this.menuItemViewToolBar.Text = "Show/Hide ToolBar";
               this.menuItemViewToolBar.Click += new System.EventHandler(this.OnShowToolBarMenuItemClick);
               // 
               // menuItemViewStatusBar
               // 
               this.menuItemViewStatusBar.Name = "menuItemViewStatusBar";
               this.menuItemViewStatusBar.Size = new System.Drawing.Size(291, 34);
               this.menuItemViewStatusBar.Text = "Show/Hide StatusBar";
               this.menuItemViewStatusBar.Click += new System.EventHandler(this.OnShowStatusBarMenuItemClick);
               // 
               // menuItemTools
               // 
               this.menuItemTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemLockWindow,
            this.menuItemLockScreen,
            this.toolSeparatorTools1,
            this.menuItemToolsOptions});
               this.menuItemTools.Name = "menuItemTools";
               this.menuItemTools.Size = new System.Drawing.Size(71, 28);
               this.menuItemTools.Text = "&Tools";
               // 
               // menuItemLockWindow
               // 
               this.menuItemLockWindow.Name = "menuItemLockWindow";
               this.menuItemLockWindow.Size = new System.Drawing.Size(270, 34);
               this.menuItemLockWindow.Text = "Lock &Window";
               this.menuItemLockWindow.Click += new System.EventHandler(this.OnLockWindowMenuItemClick);
               // 
               // menuItemLockScreen
               // 
               this.menuItemLockScreen.Name = "menuItemLockScreen";
               this.menuItemLockScreen.Size = new System.Drawing.Size(270, 34);
               this.menuItemLockScreen.Text = "Lock &Screen";
               this.menuItemLockScreen.Click += new System.EventHandler(this.OnLockScreenMenuItemClick);
               // 
               // toolSeparatorTools1
               // 
               this.toolSeparatorTools1.Name = "toolSeparatorTools1";
               this.toolSeparatorTools1.Size = new System.Drawing.Size(267, 6);
               // 
               // menuItemToolsOptions
               // 
               this.menuItemToolsOptions.Name = "menuItemToolsOptions";
               this.menuItemToolsOptions.Size = new System.Drawing.Size(270, 34);
               this.menuItemToolsOptions.Text = "&Options...";
               this.menuItemToolsOptions.Click += new System.EventHandler(this.OnSystemOptionMenuItemClick);
               // 
               // menuItemHelp
               // 
               this.menuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemHelpCheckUpdate,
            this.toolSeparatorHelp,
            this.menuItemHelpAbout});
               this.menuItemHelp.Name = "menuItemHelp";
               this.menuItemHelp.Size = new System.Drawing.Size(67, 28);
               this.menuItemHelp.Text = "&Help";
               // 
               // menuItemHelpAbout
               // 
               this.menuItemHelpAbout.Image = ((System.Drawing.Image)(resources.GetObject("menuItemHelpAbout.Image")));
               this.menuItemHelpAbout.Name = "menuItemHelpAbout";
               this.menuItemHelpAbout.Size = new System.Drawing.Size(270, 34);
               this.menuItemHelpAbout.Text = "&About...";
               this.menuItemHelpAbout.Click += new System.EventHandler(this.OnHelpAboutMenuItemClick);
               // 
               // menuItemHelpCheckUpdate
               // 
               this.menuItemHelpCheckUpdate.Name = "menuItemHelpCheckUpdate";
               this.menuItemHelpCheckUpdate.Size = new System.Drawing.Size(270, 34);
               this.menuItemHelpCheckUpdate.Text = "Check for Updates";
               this.menuItemHelpCheckUpdate.Click += new System.EventHandler(this.OnHelpCheckUpdateMenuItemClick);
               // 
               // menuStripDataGrid
               // 
               this.menuStripDataGrid.ImageScalingSize = new System.Drawing.Size(24, 24);
               this.menuStripDataGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemRestoreRecycleBin,
            this.toolSeparatorRestore,
            this.menuItemAccountTopLevel,
            this.toolStripSeparator3,
            this.menuItemEntryCreate,
            this.menuItemEntryEdit,
            this.menuItemEntryDelete,
            this.menuItemEntryMoveTo,
            this.menuItemSelectAll,
            this.toolStripSeparator4,
            this.menuItemCopyUserName,
            this.menuItemCopyPassword,
            this.menuItemCopyMobile,
            this.menuItemCopyEmail,
            this.toolStripSeparator5,
            this.menuItemRefresh,
            this.toolStripSeparator6,
            this.menuItemReArrangePopup});
               this.menuStripDataGrid.Name = "contextMenuDataGrid";
               this.menuStripDataGrid.Size = new System.Drawing.Size(234, 450);
               // 
               // menuItemRestoreRecycleBin
               // 
               this.menuItemRestoreRecycleBin.Name = "menuItemRestoreRecycleBin";
               this.menuItemRestoreRecycleBin.Size = new System.Drawing.Size(233, 32);
               this.menuItemRestoreRecycleBin.Text = "Restore";
               this.menuItemRestoreRecycleBin.Click += new System.EventHandler(this.OnRestoreRecycleBinMenuItemClick);
               // 
               // toolSeparatorRestore
               // 
               this.toolSeparatorRestore.Name = "toolSeparatorRestore";
               this.toolSeparatorRestore.Size = new System.Drawing.Size(230, 6);
               // 
               // menuItemAccountTopLevel
               // 
               this.menuItemAccountTopLevel.Name = "menuItemAccountTopLevel";
               this.menuItemAccountTopLevel.Size = new System.Drawing.Size(233, 32);
               this.menuItemAccountTopLevel.Text = "&Top Most";
               this.menuItemAccountTopLevel.Click += new System.EventHandler(this.OnAccountSetTopLevelMenuItemClick);
               // 
               // toolStripSeparator3
               // 
               this.toolStripSeparator3.Name = "toolStripSeparator3";
               this.toolStripSeparator3.Size = new System.Drawing.Size(230, 6);
               // 
               // menuItemEntryCreate
               // 
               this.menuItemEntryCreate.Name = "menuItemEntryCreate";
               this.menuItemEntryCreate.Size = new System.Drawing.Size(233, 32);
               this.menuItemEntryCreate.Text = "&New Account...";
               this.menuItemEntryCreate.Click += new System.EventHandler(this.OnCreateAccountMenuItemClick);
               // 
               // menuItemEntryEdit
               // 
               this.menuItemEntryEdit.Name = "menuItemEntryEdit";
               this.menuItemEntryEdit.Size = new System.Drawing.Size(233, 32);
               this.menuItemEntryEdit.Text = "&Edit Account...";
               this.menuItemEntryEdit.Click += new System.EventHandler(this.OnUpdateAccountMenuItemClick);
               // 
               // menuItemEntryDelete
               // 
               this.menuItemEntryDelete.Name = "menuItemEntryDelete";
               this.menuItemEntryDelete.Size = new System.Drawing.Size(233, 32);
               this.menuItemEntryDelete.Text = "&Delete Account";
               this.menuItemEntryDelete.Click += new System.EventHandler(this.OnDeleteAccountMenuItemClick);
               // 
               // menuItemEntryMoveTo
               // 
               this.menuItemEntryMoveTo.Name = "menuItemEntryMoveTo";
               this.menuItemEntryMoveTo.Size = new System.Drawing.Size(233, 32);
               this.menuItemEntryMoveTo.Text = "Mo&ve to...";
               this.menuItemEntryMoveTo.Click += new System.EventHandler(this.OnMoveAccountMenuItemClick);
               // 
               // menuItemSelectAll
               // 
               this.menuItemSelectAll.Name = "menuItemSelectAll";
               this.menuItemSelectAll.Size = new System.Drawing.Size(233, 32);
               this.menuItemSelectAll.Text = "&Select All";
               this.menuItemSelectAll.Click += new System.EventHandler(this.OnSelectAllMenuItemClick);
               // 
               // toolStripSeparator4
               // 
               this.toolStripSeparator4.Name = "toolStripSeparator4";
               this.toolStripSeparator4.Size = new System.Drawing.Size(230, 6);
               // 
               // menuItemCopyUserName
               // 
               this.menuItemCopyUserName.Name = "menuItemCopyUserName";
               this.menuItemCopyUserName.Size = new System.Drawing.Size(233, 32);
               this.menuItemCopyUserName.Text = "Copy &User Name";
               this.menuItemCopyUserName.Click += new System.EventHandler(this.OnCopyUserNameMenuItemClick);
               // 
               // menuItemCopyPassword
               // 
               this.menuItemCopyPassword.Name = "menuItemCopyPassword";
               this.menuItemCopyPassword.Size = new System.Drawing.Size(233, 32);
               this.menuItemCopyPassword.Text = "Copy &Password";
               this.menuItemCopyPassword.Click += new System.EventHandler(this.OnCopyPasswordMenuItemClick);
               // 
               // menuItemCopyMobile
               // 
               this.menuItemCopyMobile.Name = "menuItemCopyMobile";
               this.menuItemCopyMobile.Size = new System.Drawing.Size(233, 32);
               this.menuItemCopyMobile.Text = "Copy &Mobile";
               this.menuItemCopyMobile.Click += new System.EventHandler(this.OnCopyMobileMenuItemClick);
               // 
               // menuItemCopyEmail
               // 
               this.menuItemCopyEmail.Name = "menuItemCopyEmail";
               this.menuItemCopyEmail.Size = new System.Drawing.Size(233, 32);
               this.menuItemCopyEmail.Text = "Copy &Email";
               this.menuItemCopyEmail.Click += new System.EventHandler(this.OnCopyEmailMenuItemClick);
               // 
               // toolStripSeparator5
               // 
               this.toolStripSeparator5.Name = "toolStripSeparator5";
               this.toolStripSeparator5.Size = new System.Drawing.Size(230, 6);
               // 
               // menuItemRefresh
               // 
               this.menuItemRefresh.Image = ((System.Drawing.Image)(resources.GetObject("menuItemRefresh.Image")));
               this.menuItemRefresh.Name = "menuItemRefresh";
               this.menuItemRefresh.Size = new System.Drawing.Size(233, 32);
               this.menuItemRefresh.Text = "Refresh";
               this.menuItemRefresh.Click += new System.EventHandler(this.OnRefreshMenuItemClick);
               // 
               // toolStripSeparator6
               // 
               this.toolStripSeparator6.Name = "toolStripSeparator6";
               this.toolStripSeparator6.Size = new System.Drawing.Size(230, 6);
               // 
               // menuItemReArrangePopup
               // 
               this.menuItemReArrangePopup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAccountMoveToTop,
            this.menuItemAccountMoveOneUp,
            this.menuItemAccountMoveOneDown,
            this.menuItemAccountMoveToBottom});
               this.menuItemReArrangePopup.Name = "menuItemReArrangePopup";
               this.menuItemReArrangePopup.Size = new System.Drawing.Size(233, 32);
               this.menuItemReArrangePopup.Text = "&Rearrange";
               // 
               // menuItemAccountMoveToTop
               // 
               this.menuItemAccountMoveToTop.Name = "menuItemAccountMoveToTop";
               this.menuItemAccountMoveToTop.Size = new System.Drawing.Size(330, 34);
               this.menuItemAccountMoveToTop.Text = "Move Account to &Top";
               this.menuItemAccountMoveToTop.Click += new System.EventHandler(this.OnAccountMoveToTopMenuItemClick);
               // 
               // menuItemAccountMoveOneUp
               // 
               this.menuItemAccountMoveOneUp.Name = "menuItemAccountMoveOneUp";
               this.menuItemAccountMoveOneUp.Size = new System.Drawing.Size(330, 34);
               this.menuItemAccountMoveOneUp.Text = "Move Account One &Up";
               this.menuItemAccountMoveOneUp.Click += new System.EventHandler(this.OnAccountMoveUpMenuItemClick);
               // 
               // menuItemAccountMoveOneDown
               // 
               this.menuItemAccountMoveOneDown.Name = "menuItemAccountMoveOneDown";
               this.menuItemAccountMoveOneDown.Size = new System.Drawing.Size(330, 34);
               this.menuItemAccountMoveOneDown.Text = "Move Account One &Down";
               this.menuItemAccountMoveOneDown.Click += new System.EventHandler(this.OnAccountMoveDownMenuItemClick);
               // 
               // menuItemAccountMoveToBottom
               // 
               this.menuItemAccountMoveToBottom.Name = "menuItemAccountMoveToBottom";
               this.menuItemAccountMoveToBottom.Size = new System.Drawing.Size(330, 34);
               this.menuItemAccountMoveToBottom.Text = "Move Account to &Bottom";
               this.menuItemAccountMoveToBottom.Click += new System.EventHandler(this.OnAccountMoveToBottomMenuItemClick);
               // 
               // menuStripTreeView
               // 
               this.menuStripTreeView.ImageScalingSize = new System.Drawing.Size(24, 24);
               this.menuStripTreeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemCatalogCreate,
            this.menuItemCatalogEdit,
            this.menuItemCatalogDelete,
            this.toolSeparatorRecycleBin,
            this.menuItemEmptyRecycleBin});
               this.menuStripTreeView.Name = "menuStripTreeView";
               this.menuStripTreeView.Size = new System.Drawing.Size(239, 130);
               // 
               // menuItemCatalogCreate
               // 
               this.menuItemCatalogCreate.Name = "menuItemCatalogCreate";
               this.menuItemCatalogCreate.Size = new System.Drawing.Size(238, 30);
               this.menuItemCatalogCreate.Text = "&New Catalog...";
               this.menuItemCatalogCreate.Click += new System.EventHandler(this.OnCreateCatalogMenuItemClick);
               // 
               // menuItemCatalogEdit
               // 
               this.menuItemCatalogEdit.Name = "menuItemCatalogEdit";
               this.menuItemCatalogEdit.Size = new System.Drawing.Size(238, 30);
               this.menuItemCatalogEdit.Text = "&Edit Catalog...";
               this.menuItemCatalogEdit.Click += new System.EventHandler(this.OnUpdateCatalogMenuItemClick);
               // 
               // menuItemCatalogDelete
               // 
               this.menuItemCatalogDelete.Name = "menuItemCatalogDelete";
               this.menuItemCatalogDelete.Size = new System.Drawing.Size(238, 30);
               this.menuItemCatalogDelete.Text = "&Delete Catalog";
               this.menuItemCatalogDelete.Click += new System.EventHandler(this.OnDeleteCatalogMenuItemClick);
               // 
               // toolSeparatorRecycleBin
               // 
               this.toolSeparatorRecycleBin.Name = "toolSeparatorRecycleBin";
               this.toolSeparatorRecycleBin.Size = new System.Drawing.Size(235, 6);
               // 
               // menuItemEmptyRecycleBin
               // 
               this.menuItemEmptyRecycleBin.Name = "menuItemEmptyRecycleBin";
               this.menuItemEmptyRecycleBin.Size = new System.Drawing.Size(238, 30);
               this.menuItemEmptyRecycleBin.Text = "Empty Recycle &Bin";
               this.menuItemEmptyRecycleBin.Click += new System.EventHandler(this.OnEmptyRecycleBinMenuItemClick);
               // 
               // menuStripTray
               // 
               this.menuStripTray.ImageScalingSize = new System.Drawing.Size(24, 24);
               this.menuStripTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSwitchSystemTray});
               this.menuStripTray.Name = "menuStripTray";
               this.menuStripTray.Size = new System.Drawing.Size(194, 34);
               this.menuStripTray.Opening += new System.ComponentModel.CancelEventHandler(this.OnTrayMenuStripOpening);
               // 
               // menuItemSwitchSystemTray
               // 
               this.menuItemSwitchSystemTray.Name = "menuItemSwitchSystemTray";
               this.menuItemSwitchSystemTray.Size = new System.Drawing.Size(193, 30);
               this.menuItemSwitchSystemTray.Text = "&Tray / Untray";
               this.menuItemSwitchSystemTray.Click += new System.EventHandler(this.OnSwitchSystemTrayMenuItemClick);
               // 
               // notifyIconTray
               // 
               this.notifyIconTray.Visible = true;
               this.notifyIconTray.Click += new System.EventHandler(this.OnSystemTrayIconClick);
               this.notifyIconTray.DoubleClick += new System.EventHandler(this.OnSystemTrayIconDoubleClick);
               this.notifyIconTray.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnSystemTrayIconMouseDown);
               // 
               // toolSeparatorHelp
               // 
               this.toolSeparatorHelp.Name = "toolSeparatorHelp";
               this.toolSeparatorHelp.Size = new System.Drawing.Size(267, 6);
               // 
               // formAccountManager
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(1512, 846);
               this.Controls.Add(this.splitControls);
               this.Controls.Add(this.toolBarStrip);
               this.Controls.Add(this.stripStatusBar);
               this.Controls.Add(this.menuStripMain);
               this.MainMenuStrip = this.menuStripMain;
               this.Margin = new System.Windows.Forms.Padding(4);
               this.Name = "formAccountManager";
               this.Text = "SafePass";
               this.toolBarStrip.ResumeLayout(false);
               this.toolBarStrip.PerformLayout();
               this.stripStatusBar.ResumeLayout(false);
               this.stripStatusBar.PerformLayout();
               this.splitControls.Panel1.ResumeLayout(false);
               this.splitControls.Panel2.ResumeLayout(false);
               this.splitControls.ResumeLayout(false);
               this.menuStripMain.ResumeLayout(false);
               this.menuStripMain.PerformLayout();
               this.menuStripDataGrid.ResumeLayout(false);
               this.menuStripTreeView.ResumeLayout(false);
               this.menuStripTray.ResumeLayout(false);
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion

          private SourceGrid.DataGrid dataGridAccount;
          private System.Windows.Forms.TreeView treeViewCatalog;
          private System.Windows.Forms.ImageList treeNodeImages;
          private System.Windows.Forms.ToolStrip toolBarStrip;
          private System.Windows.Forms.SplitContainer splitControls;
          private System.Windows.Forms.MenuStrip menuStripMain;
          private System.Windows.Forms.StatusStrip stripStatusBar;
          private System.Windows.Forms.NotifyIcon notifyIconTray;
          private System.Windows.Forms.ContextMenuStrip menuStripTray;
          private System.Windows.Forms.ContextMenuStrip menuStripDataGrid;
          private System.Windows.Forms.ContextMenuStrip menuStripTreeView;
          private System.Windows.Forms.ToolStripButton toolButtonDataRefresh;
          private System.Windows.Forms.ToolStripButton toolButtonCatalogCreate;
          private System.Windows.Forms.ToolStripButton toolButtonCatalogEdit;
          private System.Windows.Forms.ToolStripButton toolButtonCatalogDelete;
          private System.Windows.Forms.ToolStripSeparator toolSeparatorEntry;
          private System.Windows.Forms.ToolStripButton toolButtonEntryCreate;
          private System.Windows.Forms.ToolStripButton toolButtonEntryEdit;
          private System.Windows.Forms.ToolStripButton toolButtonEntryDelete;
          private System.Windows.Forms.ToolStripSeparator toolSeparatorRefresh;
          private System.Windows.Forms.ToolStripSeparator toolSeparatorTools;
          private System.Windows.Forms.ToolStripSeparator toolSeparatorLock;
          private System.Windows.Forms.ToolStripButton toolButtonLockWindow;
          private System.Windows.Forms.ToolStripButton toolButtonLockScreen;
          private System.Windows.Forms.ToolStripButton toolButtonToolsOptions;
          private System.Windows.Forms.ToolStripMenuItem menuItemFile;
          private System.Windows.Forms.ToolStripMenuItem menuItemEdit;
          private System.Windows.Forms.ToolStripMenuItem menuItemView;
          private System.Windows.Forms.ToolStripMenuItem menuItemTools;
          private System.Windows.Forms.ToolStripMenuItem menuItemHelp;
          private System.Windows.Forms.ToolStripMenuItem menuItemExitWorkspace;
          private System.Windows.Forms.ToolStripMenuItem menuItemHelpAbout;
          private System.Windows.Forms.ToolStripSeparator toolSeparatorFile3;
          private System.Windows.Forms.ToolStripMenuItem menuItemEntryCreate;
          private System.Windows.Forms.ToolStripMenuItem menuItemEntryEdit;
          private System.Windows.Forms.ToolStripMenuItem menuItemEntryDelete;
          private System.Windows.Forms.ToolStripMenuItem menuItemEntryMoveTo;
          private System.Windows.Forms.ToolStripMenuItem menuItemCopyUserName;
          private System.Windows.Forms.ToolStripMenuItem menuItemCopyPassword;
          private System.Windows.Forms.ToolStripMenuItem menuItemCopyMobile;
          private System.Windows.Forms.ToolStripMenuItem menuItemCopyEmail;
          private System.Windows.Forms.ToolStripMenuItem menuItemRefresh;
          private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
          private System.Windows.Forms.ToolStripMenuItem menuItemCatalogCreate;
          private System.Windows.Forms.ToolStripMenuItem menuItemCatalogEdit;
          private System.Windows.Forms.ToolStripMenuItem menuItemCatalogDelete;
          private System.Windows.Forms.ToolStripSeparator toolSeparatorRecycleBin;
          private System.Windows.Forms.ToolStripMenuItem menuItemEmptyRecycleBin;
          private System.Windows.Forms.ToolStripMenuItem menuItemRestoreRecycleBin;
          private System.Windows.Forms.ToolStripMenuItem menuItemLockWindow;
          private System.Windows.Forms.ToolStripMenuItem menuItemLockScreen;
          private System.Windows.Forms.ToolStripSeparator toolSeparatorTools1;
          private System.Windows.Forms.ToolStripMenuItem menuItemToolsOptions;
          private System.Windows.Forms.ToolStripMenuItem menuItemAccountTopLevel;
          private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
          private System.Windows.Forms.ToolStripMenuItem menuItemReArrangePopup;
          private System.Windows.Forms.ToolStripMenuItem menuItemAccountMoveToTop;
          private System.Windows.Forms.ToolStripMenuItem menuItemAccountMoveOneUp;
          private System.Windows.Forms.ToolStripMenuItem menuItemAccountMoveOneDown;
          private System.Windows.Forms.ToolStripMenuItem menuItemAccountMoveToBottom;
          private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
          private System.Windows.Forms.ToolStripMenuItem menuItemSelectAll;
          private System.Windows.Forms.ToolStripSeparator toolSeparatorRestore;
          private System.Windows.Forms.ToolStripMenuItem menuItemFileExport;
          private System.Windows.Forms.ToolStripMenuItem menuItemFileImport;
          private System.Windows.Forms.ToolStripStatusLabel statusPartMessage;
          private System.Windows.Forms.ToolStripStatusLabel statusPartSelected;
          private System.Windows.Forms.ToolStripProgressBar statusPartProgress;
          private System.Windows.Forms.ToolStripProgressBar statusPartClipboard;
          private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
          private System.Windows.Forms.ToolStripMenuItem menuItemViewToolBar;
          private System.Windows.Forms.ToolStripMenuItem menuItemViewStatusBar;
          private System.Windows.Forms.ToolStripSeparator toolSeparatorFile2;
          private System.Windows.Forms.ToolStripMenuItem menuItemChangePassword;
          private System.Windows.Forms.ToolStripSeparator toolSeparatorView1;
          private System.Windows.Forms.ToolStripMenuItem menuItemChangeLanguage;
          private System.Windows.Forms.ToolStripComboBox toolComboBoxQuickFind;
          private System.Windows.Forms.ToolStripMenuItem menuItemSwitchSystemTray;
          private System.Windows.Forms.ToolStripButton toolButtonExitWorkspace;
          private System.Windows.Forms.ToolStripMenuItem menuItemHelpCheckUpdate;
          private System.Windows.Forms.ToolStripSeparator toolSeparatorHelp;
     }
}

