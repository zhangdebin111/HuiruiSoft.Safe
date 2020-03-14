
using System.Windows.Forms;
using HuiruiSoft.Utils;
using HuiruiSoft.Safe.Model;
using HuiruiSoft.Safe.Resources;

namespace HuiruiSoft.Safe
{
     internal class formAccountViewer : System.Windows.Forms.Form
     {
          private static readonly log4net.ILog loger = log4net.LogManager.GetLogger("loger");

          private System.ComponentModel.IContainer components = null;
          private System.Windows.Forms.Label labelName;
          private System.Windows.Forms.Label labelEmail;
          private System.Windows.Forms.Label labelURL;
          private System.Windows.Forms.Label labelMobile;
          private System.Windows.Forms.Label labelSecret;
          private System.Windows.Forms.Label labelPassword;
          private System.Windows.Forms.Label labelLoginName;
          private System.Windows.Forms.Label labelPwdQuality;
          private System.Windows.Forms.TabControl tabControlAttribute;
          private System.Windows.Forms.TabPage tabPageComment;
          private System.Windows.Forms.TabPage tabPageAttributes;
          private System.Windows.Forms.Button buttonClose;
          private System.Windows.Forms.Button buttonShowPassword;
          private System.Windows.Forms.TextBox textName;
          private System.Windows.Forms.TextBox textLoginName;
          private System.Windows.Forms.TextBox textPassword;
          private System.Windows.Forms.TextBox textEmail;
          private System.Windows.Forms.TextBox textMobile;
          private System.Windows.Forms.LinkLabel linkLabelURL;
          private System.Windows.Forms.TextBox textComment;
          private System.Windows.Forms.RadioButton radioSecretRank3;
          private System.Windows.Forms.RadioButton radioSecretRank2;
          private System.Windows.Forms.RadioButton radioSecretRank1;
          private System.Windows.Forms.RadioButton radioSecretRank0;
          private System.Windows.Forms.DataGridView dataGridAccount;
          private HuiruiSoft.UI.Controls.QualityProgressBar qualityProgressBar;

          private AccountModel currentAccount;
          private System.Data.DataTable accountDataTable;

          private const string
               Account_Column_AccountId = "AccountId",
               Account_Column_Id = "Id",
               Account_Column_Order = "Order",
               Account_Column_Name = "Name",
               Account_Column_Value = "Value",
               Account_Column_Encrypt = "Encrypt";

          internal formAccountViewer(AccountModel account) : this()
          {
               this.currentAccount = account;
          }

          internal formAccountViewer( )
          {
               this.InitializeComponent( );

               this.MinimizeBox = false;
               this.MaximizeBox = false;
               this.ShowInTaskbar = false;

               this.buttonClose.Visible = true;
               this.AcceptButton = this.buttonClose;
               this.CancelButton = this.buttonClose;
               this.labelEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
               this.Font = new System.Drawing.Font(this.Font.FontFamily, this.Font.Size + 1.25f);
               this.tabControlAttribute.Font = this.tabPageAttributes.Font = this.tabPageComment.Font = this.Font;
               this.FormBorderStyle = FormBorderStyle.FixedDialog;
               this.StartPosition = FormStartPosition.CenterScreen;

               var tmpOldFont = this.textComment.Font;
               this.textComment.Font = new System.Drawing.Font("Courier New", tmpOldFont.Size, tmpOldFont.Style, tmpOldFont.Unit);

               this.InitializeAccountDataGrid( );
          }

          protected override void OnLoad(System.EventArgs args)
          {
               base.OnLoad(args);

               if (!base.DesignMode)
               {
                    this.Text = SafePassResource.AccountViewerCaption;
                    this.buttonClose.Text = SafePassResource.ButtonClose;
                    this.labelName.Text = SafePassResource.AccountEditorLabelName;
                    this.labelLoginName.Text = SafePassResource.AccountEditorLabelUserName;
                    this.labelMobile.Text = SafePassResource.AccountEditorLabelMobile;
                    this.labelEmail.Text = SafePassResource.AccountEditorLabelEmail;
                    this.labelPassword.Text = SafePassResource.AccountEditorLabelPassword;
                    this.labelPwdQuality.Text = SafePassResource.AccountEditorLabelPasswordQuality;
                    this.labelURL.Text = SafePassResource.AccountEditorLabelURL;
                    this.labelSecret.Text = SafePassResource.AccountEditorLabelSecret;
                    this.radioSecretRank0.Text = SafePassResource.SecretRankpublic;
                    this.radioSecretRank1.Text = SafePassResource.SecretRankSecret;
                    this.radioSecretRank2.Text = SafePassResource.SecretRankConfidential;
                    this.radioSecretRank3.Text = SafePassResource.SecretRankTopsecret;
                    this.tabPageAttributes.Text = SafePassResource.AccountEditorTabPageAttributes;
                    this.tabPageComment.Text = SafePassResource.AccountEditorTabPageComment;

                    if (this.linkLabelURL.ForeColor.ToArgb() == System.Drawing.Color.Black.ToArgb())
                    {
                         this.linkLabelURL.ForeColor = System.Drawing.Color.Blue;
                    }

                    this.textPassword.PasswordChar = '*';
                    WindowsUtils.SetShowPasswordImage(this.buttonShowPassword, true);
               }

               if (this.currentAccount != null)
               {
                    this.textName.Text = this.currentAccount.Name;
                    this.textLoginName.Text = this.currentAccount.LoginName;
                    this.textPassword.Text = this.currentAccount.Password;

                    var tmpLinkUrl = string.Format("{0}", this.currentAccount.URL);
                    if (!string.IsNullOrEmpty(tmpLinkUrl))
                    {
                         this.linkLabelURL.Text = tmpLinkUrl;
                         this.linkLabelURL.Links.Add(0, tmpLinkUrl.Length, tmpLinkUrl);
                    }

                    this.textEmail.Text = this.currentAccount.Email;
                    this.textMobile.Text = this.currentAccount.Mobile;
                    this.textComment.Text = this.currentAccount.Comment;

                    foreach (var item in this.currentAccount.Attributes)
                    {
                         var tmpNewAttributeRow = this.accountDataTable.NewRow();
                         tmpNewAttributeRow[Account_Column_AccountId] = item.AccountId;
                         tmpNewAttributeRow[Account_Column_Id] = item.AttributeId;
                         tmpNewAttributeRow[Account_Column_Order] = item.Order;
                         tmpNewAttributeRow[Account_Column_Name] = item.Name;
                         tmpNewAttributeRow[Account_Column_Value] = item.Value;
                         tmpNewAttributeRow[Account_Column_Encrypt] = item.Encrypted;

                         this.accountDataTable.Rows.Add(tmpNewAttributeRow);
                    }

                    this.textName.ReadOnly = true;
                    this.textLoginName.ReadOnly = true;
                    this.textPassword.ReadOnly = true;
                    this.textEmail.ReadOnly = true;
                    this.textMobile.ReadOnly = true;
                    this.textComment.ReadOnly = true;

                    this.dataGridAccount.ReadOnly = true;

                    this.dataGridAccount.Width = this.dataGridAccount.Parent.Width - this.dataGridAccount.Left * 2;
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
               this.buttonClose = new System.Windows.Forms.Button();
               this.labelName = new System.Windows.Forms.Label();
               this.textName = new System.Windows.Forms.TextBox();
               this.labelLoginName = new System.Windows.Forms.Label();
               this.textLoginName = new System.Windows.Forms.TextBox();
               this.labelPassword = new System.Windows.Forms.Label();
               this.textPassword = new System.Windows.Forms.TextBox();
               this.textEmail = new System.Windows.Forms.TextBox();
               this.labelEmail = new System.Windows.Forms.Label();
               this.labelURL = new System.Windows.Forms.Label();
               this.labelMobile = new System.Windows.Forms.Label();
               this.textMobile = new System.Windows.Forms.TextBox();
               this.dataGridAccount = new System.Windows.Forms.DataGridView();
               this.textComment = new System.Windows.Forms.TextBox();
               this.tabControlAttribute = new System.Windows.Forms.TabControl();
               this.tabPageAttributes = new System.Windows.Forms.TabPage();
               this.tabPageComment = new System.Windows.Forms.TabPage();
               this.buttonShowPassword = new System.Windows.Forms.Button();
               this.radioSecretRank3 = new System.Windows.Forms.RadioButton();
               this.radioSecretRank2 = new System.Windows.Forms.RadioButton();
               this.radioSecretRank1 = new System.Windows.Forms.RadioButton();
               this.radioSecretRank0 = new System.Windows.Forms.RadioButton();
               this.labelSecret = new System.Windows.Forms.Label();
               this.labelPwdQuality = new System.Windows.Forms.Label();
               this.qualityProgressBar = new HuiruiSoft.UI.Controls.QualityProgressBar();
               this.linkLabelURL = new System.Windows.Forms.LinkLabel();
               ((System.ComponentModel.ISupportInitialize)(this.dataGridAccount)).BeginInit();
               this.tabControlAttribute.SuspendLayout();
               this.tabPageAttributes.SuspendLayout();
               this.tabPageComment.SuspendLayout();
               this.SuspendLayout();
               // 
               // buttonClose
               // 
               this.buttonClose.Location = new System.Drawing.Point(1092, 21);
               this.buttonClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
               this.buttonClose.Name = "buttonClose";
               this.buttonClose.Size = new System.Drawing.Size(180, 55);
               this.buttonClose.TabIndex = 25;
               this.buttonClose.Text = "&Close";
               this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
               // 
               // labelName
               // 
               this.labelName.AutoSize = true;
               this.labelName.Location = new System.Drawing.Point(26, 29);
               this.labelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.labelName.Name = "labelName";
               this.labelName.Size = new System.Drawing.Size(80, 18);
               this.labelName.TabIndex = 0;
               this.labelName.Text = "&Account:";
               // 
               // textName
               // 
               this.textName.Location = new System.Drawing.Point(129, 24);
               this.textName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
               this.textName.Name = "textName";
               this.textName.Size = new System.Drawing.Size(388, 28);
               this.textName.TabIndex = 1;
               // 
               // labelLoginName
               // 
               this.labelLoginName.AutoSize = true;
               this.labelLoginName.Location = new System.Drawing.Point(26, 82);
               this.labelLoginName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.labelLoginName.Name = "labelLoginName";
               this.labelLoginName.Size = new System.Drawing.Size(98, 18);
               this.labelLoginName.TabIndex = 4;
               this.labelLoginName.Text = "&User name:";
               // 
               // textLoginName
               // 
               this.textLoginName.Location = new System.Drawing.Point(129, 76);
               this.textLoginName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
               this.textLoginName.Name = "textLoginName";
               this.textLoginName.Size = new System.Drawing.Size(388, 28);
               this.textLoginName.TabIndex = 5;
               // 
               // labelPassword
               // 
               this.labelPassword.AutoSize = true;
               this.labelPassword.Location = new System.Drawing.Point(26, 133);
               this.labelPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.labelPassword.Name = "labelPassword";
               this.labelPassword.Size = new System.Drawing.Size(89, 18);
               this.labelPassword.TabIndex = 8;
               this.labelPassword.Text = "&Password:";
               // 
               // textPassword
               // 
               this.textPassword.Location = new System.Drawing.Point(129, 128);
               this.textPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
               this.textPassword.Name = "textPassword";
               this.textPassword.Size = new System.Drawing.Size(313, 28);
               this.textPassword.TabIndex = 9;
               this.textPassword.TextChanged += new System.EventHandler(this.textPassword_TextChanged);
               // 
               // textEmail
               // 
               this.textEmail.Location = new System.Drawing.Point(669, 76);
               this.textEmail.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
               this.textEmail.Name = "textEmail";
               this.textEmail.Size = new System.Drawing.Size(388, 28);
               this.textEmail.TabIndex = 7;
               // 
               // labelEmail
               // 
               this.labelEmail.AutoSize = true;
               this.labelEmail.Location = new System.Drawing.Point(564, 82);
               this.labelEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.labelEmail.Name = "labelEmail";
               this.labelEmail.Size = new System.Drawing.Size(62, 18);
               this.labelEmail.TabIndex = 6;
               this.labelEmail.Text = "&Email:";
               // 
               // labelURL
               // 
               this.labelURL.AutoSize = true;
               this.labelURL.Location = new System.Drawing.Point(26, 241);
               this.labelURL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.labelURL.Name = "labelURL";
               this.labelURL.Size = new System.Drawing.Size(44, 18);
               this.labelURL.TabIndex = 18;
               this.labelURL.Text = "UR&L:";
               // 
               // labelMobile
               // 
               this.labelMobile.AutoSize = true;
               this.labelMobile.Location = new System.Drawing.Point(564, 29);
               this.labelMobile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.labelMobile.Name = "labelMobile";
               this.labelMobile.Size = new System.Drawing.Size(71, 18);
               this.labelMobile.TabIndex = 2;
               this.labelMobile.Text = "&Mobile:";
               // 
               // textMobile
               // 
               this.textMobile.Location = new System.Drawing.Point(669, 24);
               this.textMobile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
               this.textMobile.Name = "textMobile";
               this.textMobile.Size = new System.Drawing.Size(388, 28);
               this.textMobile.TabIndex = 3;
               // 
               // dataGridAccount
               // 
               this.dataGridAccount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
               this.dataGridAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
               this.dataGridAccount.Location = new System.Drawing.Point(20, 19);
               this.dataGridAccount.Margin = new System.Windows.Forms.Padding(4);
               this.dataGridAccount.Name = "dataGridAccount";
               this.dataGridAccount.RowHeadersWidth = 62;
               this.dataGridAccount.RowTemplate.Height = 23;
               this.dataGridAccount.Size = new System.Drawing.Size(1196, 445);
               this.dataGridAccount.TabIndex = 0;
               // 
               // textComment
               // 
               this.textComment.Location = new System.Drawing.Point(18, 21);
               this.textComment.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
               this.textComment.Multiline = true;
               this.textComment.Name = "textComment";
               this.textComment.ScrollBars = System.Windows.Forms.ScrollBars.Both;
               this.textComment.Size = new System.Drawing.Size(1200, 452);
               this.textComment.TabIndex = 0;
               // 
               // tabControlAttribute
               // 
               this.tabControlAttribute.Controls.Add(this.tabPageAttributes);
               this.tabControlAttribute.Controls.Add(this.tabPageComment);
               this.tabControlAttribute.Location = new System.Drawing.Point(28, 294);
               this.tabControlAttribute.Margin = new System.Windows.Forms.Padding(4);
               this.tabControlAttribute.Name = "tabControlAttribute";
               this.tabControlAttribute.SelectedIndex = 0;
               this.tabControlAttribute.Size = new System.Drawing.Size(1244, 520);
               this.tabControlAttribute.TabIndex = 20;
               // 
               // tabPageAttributes
               // 
               this.tabPageAttributes.BackColor = System.Drawing.SystemColors.Control;
               this.tabPageAttributes.Controls.Add(this.dataGridAccount);
               this.tabPageAttributes.Location = new System.Drawing.Point(4, 28);
               this.tabPageAttributes.Margin = new System.Windows.Forms.Padding(4);
               this.tabPageAttributes.Name = "tabPageAttributes";
               this.tabPageAttributes.Padding = new System.Windows.Forms.Padding(4);
               this.tabPageAttributes.Size = new System.Drawing.Size(1236, 488);
               this.tabPageAttributes.TabIndex = 0;
               this.tabPageAttributes.Text = "Extension";
               // 
               // tabPageComment
               // 
               this.tabPageComment.BackColor = System.Drawing.SystemColors.Control;
               this.tabPageComment.Controls.Add(this.textComment);
               this.tabPageComment.Location = new System.Drawing.Point(4, 28);
               this.tabPageComment.Margin = new System.Windows.Forms.Padding(4);
               this.tabPageComment.Name = "tabPageComment";
               this.tabPageComment.Padding = new System.Windows.Forms.Padding(4);
               this.tabPageComment.Size = new System.Drawing.Size(1236, 488);
               this.tabPageComment.TabIndex = 1;
               this.tabPageComment.Text = "Comment";
               // 
               // buttonShowPassword
               // 
               this.buttonShowPassword.Location = new System.Drawing.Point(453, 123);
               this.buttonShowPassword.Margin = new System.Windows.Forms.Padding(4);
               this.buttonShowPassword.Name = "buttonShowPassword";
               this.buttonShowPassword.Size = new System.Drawing.Size(68, 39);
               this.buttonShowPassword.TabIndex = 10;
               this.buttonShowPassword.UseVisualStyleBackColor = true;
               this.buttonShowPassword.Click += new System.EventHandler(this.buttonShowPassword_Click);
               // 
               // radioSecretRank3
               // 
               this.radioSecretRank3.AutoSize = true;
               this.radioSecretRank3.Checked = true;
               this.radioSecretRank3.Location = new System.Drawing.Point(129, 186);
               this.radioSecretRank3.Margin = new System.Windows.Forms.Padding(4);
               this.radioSecretRank3.Name = "radioSecretRank3";
               this.radioSecretRank3.Size = new System.Drawing.Size(123, 22);
               this.radioSecretRank3.TabIndex = 14;
               this.radioSecretRank3.TabStop = true;
               this.radioSecretRank3.Text = "Top secret";
               this.radioSecretRank3.UseVisualStyleBackColor = true;
               // 
               // radioSecretRank2
               // 
               this.radioSecretRank2.AutoSize = true;
               this.radioSecretRank2.Location = new System.Drawing.Point(257, 186);
               this.radioSecretRank2.Margin = new System.Windows.Forms.Padding(4);
               this.radioSecretRank2.Name = "radioSecretRank2";
               this.radioSecretRank2.Size = new System.Drawing.Size(141, 22);
               this.radioSecretRank2.TabIndex = 15;
               this.radioSecretRank2.Text = "confidential";
               this.radioSecretRank2.UseVisualStyleBackColor = true;
               // 
               // radioSecretRank1
               // 
               this.radioSecretRank1.AutoSize = true;
               this.radioSecretRank1.Location = new System.Drawing.Point(403, 186);
               this.radioSecretRank1.Margin = new System.Windows.Forms.Padding(4);
               this.radioSecretRank1.Name = "radioSecretRank1";
               this.radioSecretRank1.Size = new System.Drawing.Size(87, 22);
               this.radioSecretRank1.TabIndex = 16;
               this.radioSecretRank1.Text = "secret";
               this.radioSecretRank1.UseVisualStyleBackColor = true;
               // 
               // radioSecretRank0
               // 
               this.radioSecretRank0.AutoSize = true;
               this.radioSecretRank0.Location = new System.Drawing.Point(522, 186);
               this.radioSecretRank0.Margin = new System.Windows.Forms.Padding(4);
               this.radioSecretRank0.Name = "radioSecretRank0";
               this.radioSecretRank0.Size = new System.Drawing.Size(87, 22);
               this.radioSecretRank0.TabIndex = 17;
               this.radioSecretRank0.Text = "public";
               this.radioSecretRank0.UseVisualStyleBackColor = true;
               // 
               // labelSecret
               // 
               this.labelSecret.AutoSize = true;
               this.labelSecret.Location = new System.Drawing.Point(26, 188);
               this.labelSecret.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.labelSecret.Name = "labelSecret";
               this.labelSecret.Size = new System.Drawing.Size(71, 18);
               this.labelSecret.TabIndex = 13;
               this.labelSecret.Text = "Secret:";
               // 
               // labelPwdQuality
               // 
               this.labelPwdQuality.AutoSize = true;
               this.labelPwdQuality.Location = new System.Drawing.Point(564, 133);
               this.labelPwdQuality.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.labelPwdQuality.Name = "labelPwdQuality";
               this.labelPwdQuality.Size = new System.Drawing.Size(80, 18);
               this.labelPwdQuality.TabIndex = 11;
               this.labelPwdQuality.Text = "Quality:";
               // 
               // qualityProgressBar
               // 
               this.qualityProgressBar.Location = new System.Drawing.Point(669, 128);
               this.qualityProgressBar.Margin = new System.Windows.Forms.Padding(4);
               this.qualityProgressBar.Name = "qualityProgressBar";
               this.qualityProgressBar.QualityHighColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
               this.qualityProgressBar.QualityLowColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
               this.qualityProgressBar.Size = new System.Drawing.Size(388, 28);
               this.qualityProgressBar.TabIndex = 12;
               this.qualityProgressBar.Text = "qualityProgressBar";
               // 
               // linkLabelURL
               // 
               this.linkLabelURL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
               this.linkLabelURL.Location = new System.Drawing.Point(129, 232);
               this.linkLabelURL.Name = "linkLabelURL";
               this.linkLabelURL.Size = new System.Drawing.Size(928, 36);
               this.linkLabelURL.TabIndex = 19;
               this.linkLabelURL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
               this.linkLabelURL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelURL_LinkClicked);
               // 
               // formAccountViewer
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(1300, 836);
               this.Controls.Add(this.linkLabelURL);
               this.Controls.Add(this.qualityProgressBar);
               this.Controls.Add(this.labelPwdQuality);
               this.Controls.Add(this.labelSecret);
               this.Controls.Add(this.radioSecretRank0);
               this.Controls.Add(this.radioSecretRank1);
               this.Controls.Add(this.radioSecretRank2);
               this.Controls.Add(this.radioSecretRank3);
               this.Controls.Add(this.buttonShowPassword);
               this.Controls.Add(this.tabControlAttribute);
               this.Controls.Add(this.textMobile);
               this.Controls.Add(this.labelMobile);
               this.Controls.Add(this.labelURL);
               this.Controls.Add(this.textEmail);
               this.Controls.Add(this.labelEmail);
               this.Controls.Add(this.textPassword);
               this.Controls.Add(this.labelPassword);
               this.Controls.Add(this.textLoginName);
               this.Controls.Add(this.labelLoginName);
               this.Controls.Add(this.textName);
               this.Controls.Add(this.labelName);
               this.Controls.Add(this.buttonClose);
               this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
               this.Name = "formAccountViewer";
               ((System.ComponentModel.ISupportInitialize)(this.dataGridAccount)).EndInit();
               this.tabControlAttribute.ResumeLayout(false);
               this.tabPageAttributes.ResumeLayout(false);
               this.tabPageComment.ResumeLayout(false);
               this.tabPageComment.PerformLayout();
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion


          private void linkLabelURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs args)
          {
               string url = string.Format("{0}", args.Link.LinkData);
               if (!string.IsNullOrEmpty(url))
               {
                    var tmpBrowserProcess = System.Diagnostics.Process.Start(url);
               }
          }

          protected virtual void buttonClose_Click(object sender, System.EventArgs args)
          {
               this.DialogResult = DialogResult.OK;
          }

          private void buttonShowPassword_Click(object sender, System.EventArgs args)
          {
               if(this.textPassword.PasswordChar == '*')
               {
                    this.textPassword.PasswordChar = (char)0;
                    WindowsUtils.SetShowPasswordImage(this.buttonShowPassword, false);
               }
               else
               {
                    this.textPassword.PasswordChar = '*';
                    WindowsUtils.SetShowPasswordImage(this.buttonShowPassword, true);
               }
          }

          private void InitializeAccountDataGrid( )
          {
               #region InitializeAccountDataGrid
               
               this.dataGridAccount.RowHeadersWidth = 20;
               this.dataGridAccount.RowTemplate.Height = 30;
               this.dataGridAccount.ColumnHeadersHeight = 33;
               this.dataGridAccount.RowHeadersVisible = false;
               this.dataGridAccount.AllowUserToAddRows = false;
               this.dataGridAccount.AllowUserToResizeRows = false;
               this.dataGridAccount.AllowUserToOrderColumns = false;
               this.dataGridAccount.AdvancedRowHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;
               this.dataGridAccount.GridColor = System.Drawing.SystemColors.ActiveBorder;
               this.dataGridAccount.BorderStyle = BorderStyle.Fixed3D;
               this.dataGridAccount.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
               this.dataGridAccount.CellBorderStyle = DataGridViewCellBorderStyle.Single;
               this.dataGridAccount.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
               this.dataGridAccount.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
               this.dataGridAccount.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.WhiteSmoke;
               this.dataGridAccount.EditMode = DataGridViewEditMode.EditOnEnter;
               
               this.accountDataTable = new System.Data.DataTable( );
               this.accountDataTable.Columns.Add(Account_Column_AccountId, typeof(int));
               this.accountDataTable.Columns.Add(Account_Column_Id, typeof(int));
               this.accountDataTable.Columns.Add(Account_Column_Order, typeof(short));
               this.accountDataTable.Columns.Add(Account_Column_Name, typeof(string));
               this.accountDataTable.Columns.Add(Account_Column_Value, typeof(string));
               this.accountDataTable.Columns.Add(Account_Column_Encrypt, typeof(bool));

               this.dataGridAccount.DataSource = this.accountDataTable;
               for(int index = 0; index < this.dataGridAccount.Columns.Count; index++)
               {
                    var tmpCurrentColumn = this.dataGridAccount.Columns[index];
                    tmpCurrentColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                    tmpCurrentColumn.ReadOnly = true;

                    tmpCurrentColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    tmpCurrentColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    switch(tmpCurrentColumn.Name)
                    {
                         case Account_Column_AccountId:
                              tmpCurrentColumn.Width = 80;
                              tmpCurrentColumn.Visible = false;
                              tmpCurrentColumn.HeaderText = SafePassResource.DataGridAttributeColumnAccountId;
                              break;

                         case Account_Column_Id:
                              tmpCurrentColumn.Width = 80;
                              tmpCurrentColumn.Visible = false;
                              tmpCurrentColumn.HeaderText = SafePassResource.DataGridAttributeColumnId;
                              break;

                         case Account_Column_Order:
                              tmpCurrentColumn.Width = 60;
                              tmpCurrentColumn.Resizable = DataGridViewTriState.False;
                              tmpCurrentColumn.HeaderText = SafePassResource.DataGridAttributeColumnOrder;
                              tmpCurrentColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                              break;

                         case Account_Column_Encrypt:
                              tmpCurrentColumn.Width = 75;
                              tmpCurrentColumn.Resizable = DataGridViewTriState.False;
                              tmpCurrentColumn.HeaderText = SafePassResource.DataGridAttributeColumnEncrypt;
                              tmpCurrentColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                              break;

                         case Account_Column_Name:
                              tmpCurrentColumn.Width = 260;
                              tmpCurrentColumn.HeaderText = SafePassResource.DataGridAttributeColumnName;
                              break;

                         case Account_Column_Value:
                              tmpCurrentColumn.Width = 430;
                              tmpCurrentColumn.HeaderText = SafePassResource.DataGridAttributeColumnValue;
                              break;
                    }
               }

               this.dataGridAccount.Columns[Account_Column_Order].DisplayIndex = 1;
               this.dataGridAccount.Columns[Account_Column_Encrypt].DisplayIndex = 2;
               this.dataGridAccount.Columns[Account_Column_Name].DisplayIndex = 3;
               this.dataGridAccount.Columns[Account_Column_Value].DisplayIndex = 4;

               #endregion InitializeAccountDataGrid
          }

          private void textPassword_TextChanged(object sender, System.EventArgs args)
          {
               this.qualityProgressBar.Value = (int)HuiruiSoft.Security.Cryptography.QualityEstimation.EstimatePasswordQuality(this.textPassword.Text);
          }
     }
}