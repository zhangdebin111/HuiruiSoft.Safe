
using System.Windows.Forms;
using HuiruiSoft.Utils;
using HuiruiSoft.Safe.Resources;

namespace HuiruiSoft.Safe
{
     internal class formAccountBase : System.Windows.Forms.Form
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
          private System.Windows.Forms.Label labelPwdRepeat;
          private System.Windows.Forms.Label labelPwdQuality;
          protected System.Windows.Forms.TabControl tabControlAttribute;
          protected System.Windows.Forms.TabPage tabPageComment;
          protected System.Windows.Forms.TabPage tabPageAttributes;
          protected System.Windows.Forms.Button buttonBuildPassword;
          protected System.Windows.Forms.Button buttonOK;
          protected System.Windows.Forms.Button buttonCancel;
          protected System.Windows.Forms.Button buttonShowPassword;
          protected System.Windows.Forms.Button buttonAddAttribute;
          protected System.Windows.Forms.Button buttonDeleteAttribute;
          protected System.Windows.Forms.Button buttonMoveDown;
          protected System.Windows.Forms.Button buttonMoveUp;
          protected System.Windows.Forms.TextBox textName;
          protected System.Windows.Forms.TextBox textLoginName;
          protected System.Windows.Forms.TextBox textURL;
          protected System.Windows.Forms.TextBox textPassword;
          protected System.Windows.Forms.TextBox textPwdRepeat;
          protected System.Windows.Forms.TextBox textEmail;
          protected System.Windows.Forms.TextBox textMobile;
          protected System.Windows.Forms.TextBox textComment;
          protected System.Windows.Forms.RadioButton radioSecretRank3;
          protected System.Windows.Forms.RadioButton radioSecretRank2;
          protected System.Windows.Forms.RadioButton radioSecretRank1;
          protected System.Windows.Forms.RadioButton radioSecretRank0;
          protected System.Windows.Forms.DataGridView dataGridAccount;
          protected HuiruiSoft.UI.Controls.QualityProgressBar qualityProgressBar;

          protected System.Data.DataTable accountDataTable;

          protected const string
               Account_Column_AccountId = "AccountId",
               Account_Column_Id = "Id",
               Account_Column_Order = "Order",
               Account_Column_Name = "Name",
               Account_Column_Value = "Value",
               Account_Column_Encrypt = "Encrypt";

          internal formAccountBase( )
          {
               this.InitializeComponent( );

               this.MinimizeBox = false;
               this.MaximizeBox = false;
               this.ShowInTaskbar = false;

               this.CancelButton = this.buttonCancel;
               this.Font = new System.Drawing.Font(this.Font.FontFamily, this.Font.Size + 1.25f);
               this.tabControlAttribute.Font = this.tabPageAttributes.Font = this.tabPageComment.Font = this.Font;
               this.FormBorderStyle = FormBorderStyle.FixedDialog;
               this.StartPosition = FormStartPosition.CenterScreen;

               System.Drawing.Font tmpOldFont = this.textComment.Font;
               this.textComment.Font = new System.Drawing.Font("Courier New", tmpOldFont.Size, tmpOldFont.Style, tmpOldFont.Unit);

               this.InitializeAccountDataGrid( );
          }

          /// <summary>清理所有正在使用的资源。</summary>
          /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
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
               this.buttonOK = new System.Windows.Forms.Button();
               this.buttonCancel = new System.Windows.Forms.Button();
               this.labelName = new System.Windows.Forms.Label();
               this.textName = new System.Windows.Forms.TextBox();
               this.labelLoginName = new System.Windows.Forms.Label();
               this.textLoginName = new System.Windows.Forms.TextBox();
               this.labelPassword = new System.Windows.Forms.Label();
               this.textPassword = new System.Windows.Forms.TextBox();
               this.textEmail = new System.Windows.Forms.TextBox();
               this.labelEmail = new System.Windows.Forms.Label();
               this.labelURL = new System.Windows.Forms.Label();
               this.textURL = new System.Windows.Forms.TextBox();
               this.labelMobile = new System.Windows.Forms.Label();
               this.textMobile = new System.Windows.Forms.TextBox();
               this.dataGridAccount = new System.Windows.Forms.DataGridView();
               this.textComment = new System.Windows.Forms.TextBox();
               this.tabControlAttribute = new System.Windows.Forms.TabControl();
               this.tabPageAttributes = new System.Windows.Forms.TabPage();
               this.buttonMoveDown = new System.Windows.Forms.Button();
               this.buttonMoveUp = new System.Windows.Forms.Button();
               this.buttonDeleteAttribute = new System.Windows.Forms.Button();
               this.buttonAddAttribute = new System.Windows.Forms.Button();
               this.tabPageComment = new System.Windows.Forms.TabPage();
               this.buttonShowPassword = new System.Windows.Forms.Button();
               this.radioSecretRank3 = new System.Windows.Forms.RadioButton();
               this.radioSecretRank2 = new System.Windows.Forms.RadioButton();
               this.radioSecretRank1 = new System.Windows.Forms.RadioButton();
               this.radioSecretRank0 = new System.Windows.Forms.RadioButton();
               this.labelSecret = new System.Windows.Forms.Label();
               this.labelPwdQuality = new System.Windows.Forms.Label();
               this.labelPwdRepeat = new System.Windows.Forms.Label();
               this.buttonBuildPassword = new System.Windows.Forms.Button();
               this.qualityProgressBar = new HuiruiSoft.UI.Controls.QualityProgressBar();
               this.textPwdRepeat = new System.Windows.Forms.TextBox();
               ((System.ComponentModel.ISupportInitialize)(this.dataGridAccount)).BeginInit();
               this.tabControlAttribute.SuspendLayout();
               this.tabPageAttributes.SuspendLayout();
               this.tabPageComment.SuspendLayout();
               this.SuspendLayout();
               // 
               // buttonOK
               // 
               this.buttonOK.Location = new System.Drawing.Point(1106, 24);
               this.buttonOK.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
               this.buttonOK.Name = "buttonOK";
               this.buttonOK.Size = new System.Drawing.Size(180, 55);
               this.buttonOK.TabIndex = 24;
               this.buttonOK.Text = "&OK";
               this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
               // 
               // buttonCancel
               // 
               this.buttonCancel.Location = new System.Drawing.Point(1106, 111);
               this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
               this.buttonCancel.Name = "buttonCancel";
               this.buttonCancel.Size = new System.Drawing.Size(180, 55);
               this.buttonCancel.TabIndex = 25;
               this.buttonCancel.Text = "&Cancel";
               this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
               // 
               // labelName
               // 
               this.labelName.AutoSize = true;
               this.labelName.Location = new System.Drawing.Point(24, 29);
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
               this.labelLoginName.Location = new System.Drawing.Point(24, 84);
               this.labelLoginName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.labelLoginName.Name = "labelLoginName";
               this.labelLoginName.Size = new System.Drawing.Size(98, 18);
               this.labelLoginName.TabIndex = 4;
               this.labelLoginName.Text = "&User name:";
               // 
               // textLoginName
               // 
               this.textLoginName.Location = new System.Drawing.Point(129, 79);
               this.textLoginName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
               this.textLoginName.Name = "textLoginName";
               this.textLoginName.Size = new System.Drawing.Size(388, 28);
               this.textLoginName.TabIndex = 5;
               // 
               // labelPassword
               // 
               this.labelPassword.AutoSize = true;
               this.labelPassword.Location = new System.Drawing.Point(24, 138);
               this.labelPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.labelPassword.Name = "labelPassword";
               this.labelPassword.Size = new System.Drawing.Size(89, 18);
               this.labelPassword.TabIndex = 8;
               this.labelPassword.Text = "&Password:";
               // 
               // textPassword
               // 
               this.textPassword.Location = new System.Drawing.Point(129, 133);
               this.textPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
               this.textPassword.Name = "textPassword";
               this.textPassword.Size = new System.Drawing.Size(313, 28);
               this.textPassword.TabIndex = 9;
               this.textPassword.TextChanged += new System.EventHandler(this.textPassword_TextChanged);
               // 
               // textEmail
               // 
               this.textEmail.Location = new System.Drawing.Point(669, 79);
               this.textEmail.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
               this.textEmail.Name = "textEmail";
               this.textEmail.Size = new System.Drawing.Size(388, 28);
               this.textEmail.TabIndex = 7;
               // 
               // labelEmail
               // 
               this.labelEmail.AutoSize = true;
               this.labelEmail.Location = new System.Drawing.Point(566, 84);
               this.labelEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.labelEmail.Name = "labelEmail";
               this.labelEmail.Size = new System.Drawing.Size(62, 18);
               this.labelEmail.TabIndex = 6;
               this.labelEmail.Text = "&Email:";
               // 
               // labelURL
               // 
               this.labelURL.AutoSize = true;
               this.labelURL.Location = new System.Drawing.Point(24, 302);
               this.labelURL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.labelURL.Name = "labelURL";
               this.labelURL.Size = new System.Drawing.Size(44, 18);
               this.labelURL.TabIndex = 21;
               this.labelURL.Text = "UR&L:";
               // 
               // textURL
               // 
               this.textURL.Location = new System.Drawing.Point(129, 297);
               this.textURL.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
               this.textURL.Name = "textURL";
               this.textURL.Size = new System.Drawing.Size(928, 28);
               this.textURL.TabIndex = 22;
               // 
               // labelMobile
               // 
               this.labelMobile.AutoSize = true;
               this.labelMobile.Location = new System.Drawing.Point(566, 29);
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
               this.dataGridAccount.Size = new System.Drawing.Size(1005, 416);
               this.dataGridAccount.TabIndex = 0;
               // 
               // textComment
               // 
               this.textComment.Location = new System.Drawing.Point(18, 21);
               this.textComment.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
               this.textComment.Multiline = true;
               this.textComment.Name = "textComment";
               this.textComment.ScrollBars = System.Windows.Forms.ScrollBars.Both;
               this.textComment.Size = new System.Drawing.Size(1215, 412);
               this.textComment.TabIndex = 0;
               // 
               // tabControlAttribute
               // 
               this.tabControlAttribute.Controls.Add(this.tabPageAttributes);
               this.tabControlAttribute.Controls.Add(this.tabPageComment);
               this.tabControlAttribute.Location = new System.Drawing.Point(28, 357);
               this.tabControlAttribute.Margin = new System.Windows.Forms.Padding(4);
               this.tabControlAttribute.Name = "tabControlAttribute";
               this.tabControlAttribute.SelectedIndex = 0;
               this.tabControlAttribute.Size = new System.Drawing.Size(1258, 484);
               this.tabControlAttribute.TabIndex = 23;
               // 
               // tabPageAttributes
               // 
               this.tabPageAttributes.BackColor = System.Drawing.SystemColors.Control;
               this.tabPageAttributes.Controls.Add(this.buttonMoveDown);
               this.tabPageAttributes.Controls.Add(this.buttonMoveUp);
               this.tabPageAttributes.Controls.Add(this.buttonDeleteAttribute);
               this.tabPageAttributes.Controls.Add(this.buttonAddAttribute);
               this.tabPageAttributes.Controls.Add(this.dataGridAccount);
               this.tabPageAttributes.Location = new System.Drawing.Point(4, 28);
               this.tabPageAttributes.Margin = new System.Windows.Forms.Padding(4);
               this.tabPageAttributes.Name = "tabPageAttributes";
               this.tabPageAttributes.Padding = new System.Windows.Forms.Padding(4);
               this.tabPageAttributes.Size = new System.Drawing.Size(1250, 452);
               this.tabPageAttributes.TabIndex = 0;
               this.tabPageAttributes.Text = "Attributes";
               // 
               // buttonMoveDown
               // 
               this.buttonMoveDown.Location = new System.Drawing.Point(1047, 244);
               this.buttonMoveDown.Margin = new System.Windows.Forms.Padding(4);
               this.buttonMoveDown.Name = "buttonMoveDown";
               this.buttonMoveDown.Size = new System.Drawing.Size(185, 44);
               this.buttonMoveDown.TabIndex = 4;
               this.buttonMoveDown.UseVisualStyleBackColor = true;
               this.buttonMoveDown.Click += new System.EventHandler(this.buttonMoveDown_Click);
               // 
               // buttonMoveUp
               // 
               this.buttonMoveUp.Location = new System.Drawing.Point(1047, 186);
               this.buttonMoveUp.Margin = new System.Windows.Forms.Padding(4);
               this.buttonMoveUp.Name = "buttonMoveUp";
               this.buttonMoveUp.Size = new System.Drawing.Size(185, 44);
               this.buttonMoveUp.TabIndex = 3;
               this.buttonMoveUp.UseVisualStyleBackColor = true;
               this.buttonMoveUp.Click += new System.EventHandler(this.buttonMoveUp_Click);
               // 
               // buttonDeleteAttribute
               // 
               this.buttonDeleteAttribute.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
               this.buttonDeleteAttribute.Location = new System.Drawing.Point(1047, 78);
               this.buttonDeleteAttribute.Margin = new System.Windows.Forms.Padding(4);
               this.buttonDeleteAttribute.Name = "buttonDeleteAttribute";
               this.buttonDeleteAttribute.Size = new System.Drawing.Size(185, 44);
               this.buttonDeleteAttribute.TabIndex = 2;
               this.buttonDeleteAttribute.Text = "Delete Attribute";
               this.buttonDeleteAttribute.Click += new System.EventHandler(this.buttonDeleteAttribute_Click);
               // 
               // buttonAddAttribute
               // 
               this.buttonAddAttribute.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
               this.buttonAddAttribute.Location = new System.Drawing.Point(1047, 19);
               this.buttonAddAttribute.Margin = new System.Windows.Forms.Padding(4);
               this.buttonAddAttribute.Name = "buttonAddAttribute";
               this.buttonAddAttribute.Size = new System.Drawing.Size(185, 44);
               this.buttonAddAttribute.TabIndex = 1;
               this.buttonAddAttribute.Text = "Add Attribute";
               this.buttonAddAttribute.Click += new System.EventHandler(this.buttonAddAttribute_Click);
               // 
               // tabPageComment
               // 
               this.tabPageComment.BackColor = System.Drawing.SystemColors.Control;
               this.tabPageComment.Controls.Add(this.textComment);
               this.tabPageComment.Location = new System.Drawing.Point(4, 28);
               this.tabPageComment.Margin = new System.Windows.Forms.Padding(4);
               this.tabPageComment.Name = "tabPageComment";
               this.tabPageComment.Padding = new System.Windows.Forms.Padding(4);
               this.tabPageComment.Size = new System.Drawing.Size(1250, 452);
               this.tabPageComment.TabIndex = 1;
               this.tabPageComment.Text = "Comment";
               // 
               // buttonShowPassword
               // 
               this.buttonShowPassword.Location = new System.Drawing.Point(453, 128);
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
               this.radioSecretRank3.Location = new System.Drawing.Point(129, 242);
               this.radioSecretRank3.Margin = new System.Windows.Forms.Padding(4);
               this.radioSecretRank3.Name = "radioSecretRank3";
               this.radioSecretRank3.Size = new System.Drawing.Size(123, 22);
               this.radioSecretRank3.TabIndex = 17;
               this.radioSecretRank3.TabStop = true;
               this.radioSecretRank3.Text = "Top secret";
               this.radioSecretRank3.UseVisualStyleBackColor = true;
               // 
               // radioSecretRank2
               // 
               this.radioSecretRank2.AutoSize = true;
               this.radioSecretRank2.Location = new System.Drawing.Point(259, 242);
               this.radioSecretRank2.Margin = new System.Windows.Forms.Padding(4);
               this.radioSecretRank2.Name = "radioSecretRank2";
               this.radioSecretRank2.Size = new System.Drawing.Size(141, 22);
               this.radioSecretRank2.TabIndex = 18;
               this.radioSecretRank2.Text = "confidential";
               this.radioSecretRank2.UseVisualStyleBackColor = true;
               // 
               // radioSecretRank1
               // 
               this.radioSecretRank1.AutoSize = true;
               this.radioSecretRank1.Location = new System.Drawing.Point(406, 242);
               this.radioSecretRank1.Margin = new System.Windows.Forms.Padding(4);
               this.radioSecretRank1.Name = "radioSecretRank1";
               this.radioSecretRank1.Size = new System.Drawing.Size(87, 22);
               this.radioSecretRank1.TabIndex = 19;
               this.radioSecretRank1.Text = "secret";
               this.radioSecretRank1.UseVisualStyleBackColor = true;
               // 
               // radioSecretRank0
               // 
               this.radioSecretRank0.AutoSize = true;
               this.radioSecretRank0.Location = new System.Drawing.Point(518, 242);
               this.radioSecretRank0.Margin = new System.Windows.Forms.Padding(4);
               this.radioSecretRank0.Name = "radioSecretRank0";
               this.radioSecretRank0.Size = new System.Drawing.Size(87, 22);
               this.radioSecretRank0.TabIndex = 20;
               this.radioSecretRank0.Text = "public";
               this.radioSecretRank0.UseVisualStyleBackColor = true;
               // 
               // labelSecret
               // 
               this.labelSecret.AutoSize = true;
               this.labelSecret.Location = new System.Drawing.Point(24, 244);
               this.labelSecret.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.labelSecret.Name = "labelSecret";
               this.labelSecret.Size = new System.Drawing.Size(71, 18);
               this.labelSecret.TabIndex = 16;
               this.labelSecret.Text = "Secret:";
               // 
               // labelPwdQuality
               // 
               this.labelPwdQuality.AutoSize = true;
               this.labelPwdQuality.Location = new System.Drawing.Point(566, 138);
               this.labelPwdQuality.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.labelPwdQuality.Name = "labelPwdQuality";
               this.labelPwdQuality.Size = new System.Drawing.Size(80, 18);
               this.labelPwdQuality.TabIndex = 14;
               this.labelPwdQuality.Text = "Quality:";
               // 
               // labelPwdRepeat
               // 
               this.labelPwdRepeat.AutoSize = true;
               this.labelPwdRepeat.Location = new System.Drawing.Point(24, 195);
               this.labelPwdRepeat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.labelPwdRepeat.Name = "labelPwdRepeat";
               this.labelPwdRepeat.Size = new System.Drawing.Size(71, 18);
               this.labelPwdRepeat.TabIndex = 11;
               this.labelPwdRepeat.Text = "&Repeat:";
               // 
               // buttonBuildPassword
               // 
               this.buttonBuildPassword.Location = new System.Drawing.Point(453, 185);
               this.buttonBuildPassword.Margin = new System.Windows.Forms.Padding(4);
               this.buttonBuildPassword.Name = "buttonBuildPassword";
               this.buttonBuildPassword.Size = new System.Drawing.Size(68, 39);
               this.buttonBuildPassword.TabIndex = 13;
               this.buttonBuildPassword.Text = "...";
               this.buttonBuildPassword.UseVisualStyleBackColor = true;
               this.buttonBuildPassword.Click += new System.EventHandler(this.buttonBuildPassword_Click);
               // 
               // qualityProgressBar
               // 
               this.qualityProgressBar.Location = new System.Drawing.Point(669, 133);
               this.qualityProgressBar.Margin = new System.Windows.Forms.Padding(4);
               this.qualityProgressBar.Name = "qualityProgressBar";
               this.qualityProgressBar.QualityHighColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
               this.qualityProgressBar.QualityLowColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
               this.qualityProgressBar.Size = new System.Drawing.Size(388, 28);
               this.qualityProgressBar.TabIndex = 15;
               this.qualityProgressBar.Text = "qualityProgressBar";
               // 
               // textPwdRepeat
               // 
               this.textPwdRepeat.AllowDrop = true;
               this.textPwdRepeat.Location = new System.Drawing.Point(129, 190);
               this.textPwdRepeat.Margin = new System.Windows.Forms.Padding(4);
               this.textPwdRepeat.Name = "textPwdRepeat";
               this.textPwdRepeat.Size = new System.Drawing.Size(313, 28);
               this.textPwdRepeat.TabIndex = 12;
               this.textPwdRepeat.UseSystemPasswordChar = true;
               // 
               // formAccountBase
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(1308, 856);
               this.Controls.Add(this.buttonBuildPassword);
               this.Controls.Add(this.labelPwdRepeat);
               this.Controls.Add(this.qualityProgressBar);
               this.Controls.Add(this.textPwdRepeat);
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
               this.Controls.Add(this.textURL);
               this.Controls.Add(this.labelURL);
               this.Controls.Add(this.textEmail);
               this.Controls.Add(this.labelEmail);
               this.Controls.Add(this.textPassword);
               this.Controls.Add(this.labelPassword);
               this.Controls.Add(this.textLoginName);
               this.Controls.Add(this.labelLoginName);
               this.Controls.Add(this.textName);
               this.Controls.Add(this.labelName);
               this.Controls.Add(this.buttonCancel);
               this.Controls.Add(this.buttonOK);
               this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
               this.Name = "formAccountBase";
               ((System.ComponentModel.ISupportInitialize)(this.dataGridAccount)).EndInit();
               this.tabControlAttribute.ResumeLayout(false);
               this.tabPageAttributes.ResumeLayout(false);
               this.tabPageComment.ResumeLayout(false);
               this.tabPageComment.PerformLayout();
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion

          protected override void OnLoad(System.EventArgs args)
          {
               base.OnLoad(args);

               if(!this.DesignMode)
               {
                    this.Icon = WindowsUtils.DefaultAppIcon;
                    this.Text = SafePassResource.AccountViewerCaption;
                    this.buttonOK.Text = SafePassResource.ButtonOK;
                    this.buttonCancel.Text = SafePassResource.ButtonCancel;
                    this.labelName.Text = SafePassResource.AccountEditorLabelName;
                    this.labelLoginName.Text = SafePassResource.AccountEditorLabelUserName;
                    this.labelMobile.Text = SafePassResource.AccountEditorLabelMobile;
                    this.labelEmail.Text = SafePassResource.AccountEditorLabelEmail;
                    this.labelPassword.Text = SafePassResource.AccountEditorLabelPassword;
                    this.labelPwdRepeat.Text = SafePassResource.AccountEditorLabelPwdRepeat;
                    this.labelPwdQuality.Text = SafePassResource.AccountEditorLabelPasswordQuality;
                    this.labelURL.Text = SafePassResource.AccountEditorLabelURL;
                    this.labelSecret.Text = SafePassResource.AccountEditorLabelSecret;
                    this.radioSecretRank0.Text = SafePassResource.SecretRankpublic;
                    this.radioSecretRank1.Text = SafePassResource.SecretRankSecret;
                    this.radioSecretRank2.Text = SafePassResource.SecretRankConfidential;
                    this.radioSecretRank3.Text = SafePassResource.SecretRankTopsecret;
                    this.tabPageAttributes.Text = SafePassResource.AccountEditorTabPageAttributes;
                    this.tabPageComment.Text = SafePassResource.AccountEditorTabPageComment;
                    this.buttonAddAttribute.Text = SafePassResource.AccountEditorButtonAddAttribute;
                    this.buttonDeleteAttribute.Text = SafePassResource.AccountEditorButtonDeleteAttribute;

                    this.buttonMoveUp.Text = "";
                    this.buttonMoveDown.Text = "";
                    this.buttonMoveUp.Font = new System.Drawing.Font("Wingdings 3", this.Font.Size + 1.0f);
                    this.buttonMoveDown.Font = new System.Drawing.Font("Wingdings 3", this.Font.Size + 1.0f);

                    this.textName.MaxLength = 50;
                    this.textEmail.MaxLength = 80;
                    this.textMobile.MaxLength = 20;
                    this.textLoginName.MaxLength = 60;
                    this.textPassword.MaxLength = 60;
                    this.textURL.MaxLength = 200;
                    this.textComment.MaxLength = 5000;

                    this.radioSecretRank0.ForeColor = Program.Config.Application.Security.SecretRank.Rank0BackColor;
                    this.radioSecretRank1.ForeColor = Program.Config.Application.Security.SecretRank.Rank1BackColor;
                    this.radioSecretRank2.ForeColor = Program.Config.Application.Security.SecretRank.Rank2BackColor;
                    this.radioSecretRank3.ForeColor = Program.Config.Application.Security.SecretRank.Rank3BackColor;

                    if (this.textURL.ForeColor.ToArgb( ) == System.Drawing.Color.Black.ToArgb( ))
                    {
                         this.textURL.ForeColor = System.Drawing.Color.Blue;
                    }

                    this.textPassword.PasswordChar = '*';
                    this.textPwdRepeat.ImeMode = ImeMode.Disable;
                    this.textPassword.ImeMode = ImeMode.Disable;
                    WindowsUtils.SetShowPasswordImage(this.buttonShowPassword, true);
               }
          }

          protected virtual void buttonOK_Click(object sender, System.EventArgs args)
          {
               this.DialogResult = DialogResult.OK;
          }

          protected virtual void buttonCancel_Click(object sender, System.EventArgs args)
          {
               this.DialogResult = DialogResult.Cancel;
          }

          protected virtual bool CheckInputValidity( )
          {
               return true;
          }

          private void buttonDeleteAttribute_Click(object sender, System.EventArgs args)
          {
               if(MessageBox.Show(SafePassResource.DeleteAttributeMessageBoxConfirm, SafePassResource.DeleteAttributeMessageBoxCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
               {
                    this.dataGridAccount.Rows.Remove(this.dataGridAccount.CurrentRow);
                    this.ResetDataTableRowOrder( );
               }
          }

          private void buttonMoveUp_Click(object sender, System.EventArgs args)
          {
               if(this.dataGridAccount.CurrentRow != null)
               {
                    int tmpCurrentRowIndex = this.dataGridAccount.CurrentRow.Index;
                    if(tmpCurrentRowIndex >= 1)
                    {
                         var tmpCurrentDataRow = this.accountDataTable.Rows[tmpCurrentRowIndex];

                         var tmpTargetDataRow = this.CopyDataTableRow(tmpCurrentDataRow);
                         if(tmpTargetDataRow != null)
                         {
                              int tmpLastRowIndex = tmpCurrentRowIndex - 1;
                              int tempColumnIndex = this.dataGridAccount.CurrentCell.ColumnIndex;
                              this.accountDataTable.Rows.RemoveAt(tmpCurrentRowIndex);
                              this.accountDataTable.Rows.InsertAt(tmpTargetDataRow, tmpLastRowIndex);

                              this.ResetDataTableRowOrder( );

                              this.dataGridAccount.Rows[tmpLastRowIndex].Selected = true;
                              this.dataGridAccount.CurrentCell = this.dataGridAccount.Rows[tmpLastRowIndex].Cells[tempColumnIndex];
                         }
                    }
               }
          }

          private void buttonMoveDown_Click(object sender, System.EventArgs args)
          {
               if(this.dataGridAccount.CurrentRow != null)
               {
                    int tmpLastRowIndexOf = this.dataGridAccount.Rows.Count - 1;
                    int tmpCurrentRowIndex = this.dataGridAccount.CurrentRow.Index;
                    if(tmpCurrentRowIndex < tmpLastRowIndexOf)
                    {
                         var tmpCurrentDataRow = this.accountDataTable.Rows[tmpCurrentRowIndex];

                         var tmpTargetDataRow = this.CopyDataTableRow(tmpCurrentDataRow);
                         if(tmpTargetDataRow != null)
                         {
                              int tmpNextRowIndex = tmpCurrentRowIndex + 1;
                              int tempColumnIndex = this.dataGridAccount.CurrentCell.ColumnIndex;
                              this.accountDataTable.Rows.RemoveAt(tmpCurrentRowIndex);
                              this.accountDataTable.Rows.InsertAt(tmpTargetDataRow, tmpNextRowIndex);

                              this.ResetDataTableRowOrder( );

                              this.dataGridAccount.Rows[tmpNextRowIndex].Selected = true;
                              this.dataGridAccount.CurrentCell = this.dataGridAccount.Rows[tmpNextRowIndex].Cells[tempColumnIndex];
                         }
                    }
               }
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
               this.accountDataTable.Columns[Account_Column_AccountId].Caption = "";
               this.accountDataTable.TableNewRow += new System.Data.DataTableNewRowEventHandler(this.OnAccountDataTableNewRow);

               this.dataGridAccount.DataSource = this.accountDataTable;
               for(int index = 0; index < this.dataGridAccount.Columns.Count; index++)
               {
                    var tmpCurrentColumn = this.dataGridAccount.Columns[index];
                    tmpCurrentColumn.SortMode = DataGridViewColumnSortMode.NotSortable;

                    tmpCurrentColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    tmpCurrentColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    switch(tmpCurrentColumn.Name)
                    {
                         case Account_Column_AccountId:
                              tmpCurrentColumn.Width = 80;
                              tmpCurrentColumn.Visible = false;
                              tmpCurrentColumn.ReadOnly = true;
                              tmpCurrentColumn.HeaderText = SafePassResource.DataGridAttributeColumnAccountId;
                              break;

                         case Account_Column_Id:
                              tmpCurrentColumn.Width = 80;
                              tmpCurrentColumn.Visible = false;
                              tmpCurrentColumn.ReadOnly = true;
                              tmpCurrentColumn.HeaderText = SafePassResource.DataGridAttributeColumnId;
                              break;

                         case Account_Column_Order:
                              tmpCurrentColumn.Width = 60;
                              tmpCurrentColumn.ReadOnly = true;
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
                              tmpCurrentColumn.Width = 220;
                              tmpCurrentColumn.HeaderText = SafePassResource.DataGridAttributeColumnName;
                              break;

                         case Account_Column_Value:
                              tmpCurrentColumn.Width = 380;
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

          private void buttonBuildPassword_Click(object sender, System.EventArgs args)
          {
               var tmpPasswordBuilder = new formPasswordBuilder();
               var tmpDialogResult = tmpPasswordBuilder.ShowDialog();
               if (tmpDialogResult == DialogResult.OK)
               {
                    this.textPwdRepeat.Text = this.textPassword.Text = tmpPasswordBuilder.PasswordString;
               }

               tmpPasswordBuilder.Dispose();
          }

          private void textPassword_TextChanged(object sender, System.EventArgs args)
          {
               this.qualityProgressBar.Value = (int)HuiruiSoft.Security.Cryptography.QualityEstimation.EstimatePasswordQuality(this.textPassword.Text);
          }

          private void OnAccountDataTableNewRow(object sender, System.Data.DataTableNewRowEventArgs args)
          {
               this.ResetDataTableRowOrder( );
          }

          private void buttonAddAttribute_Click(object sender, System.EventArgs args)
          {
               var tmpNewAttributeDialog = new formNewAttribute(this);
               tmpNewAttributeDialog.ShowDialog(this);
          }

          internal bool NewAccountExtendAttribute(string attributeName, string attributeValue, bool encryptValue)
          {
               bool tmpCreateResult = false;

               if (!string.IsNullOrEmpty(attributeName) && !string.IsNullOrEmpty(attributeValue))
               {
                    var tempNewDataRow = this.accountDataTable.NewRow();
                    tempNewDataRow[Account_Column_Name] = attributeName;
                    tempNewDataRow[Account_Column_Value] = attributeValue;
                    tempNewDataRow[Account_Column_Encrypt] = encryptValue;

                    if (this.accountDataTable.Rows.Count == 0)
                    {
                         tempNewDataRow[Account_Column_Order] = 1;
                    }
                    else
                    {
                         var tmpLastDataRow = this.accountDataTable.Rows[this.accountDataTable.Rows.Count - 1];
                         if (tmpLastDataRow[Account_Column_Order] != System.DBNull.Value)
                         {
                              int tmpLastOrder;
                              if (int.TryParse(string.Format("{0}", tmpLastDataRow[Account_Column_Order]), out tmpLastOrder))
                              {
                                   tempNewDataRow[Account_Column_Order] = tmpLastOrder + 1;
                              }
                         }
                    }

                    this.accountDataTable.Rows.Add(tempNewDataRow);

                    tmpCreateResult = true;
               }

               return tmpCreateResult;
          }

          private void ResetDataTableRowOrder( )
          {
               for(short index = 0; index < this.accountDataTable.Rows.Count; index++)
               {
                    short order = (short)(index + 1);

                    var tmpCurrentGridRow = this.accountDataTable.Rows[index];
                    if(!object.Equals(tmpCurrentGridRow[Account_Column_Order], order))
                    {
                         tmpCurrentGridRow[Account_Column_Order] = order;
                    }
               }
          }

          private System.Data.DataRow CopyDataTableRow(System.Data.DataRow sourceDataRow)
          {
               System.Data.DataRow tmpTargetDataRow = null;

               if(sourceDataRow != null)
               {
                    tmpTargetDataRow = sourceDataRow.Table.NewRow( );
                    tmpTargetDataRow.ItemArray = sourceDataRow.ItemArray;
               }

               return tmpTargetDataRow;
          }
     }
}