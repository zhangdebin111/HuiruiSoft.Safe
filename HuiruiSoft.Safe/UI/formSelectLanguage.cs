using System.Windows.Forms;
using HuiruiSoft.Safe.Resources;
using HuiruiSoft.Safe.Localization;
using HuiruiSoft.Safe.Configuration;

namespace HuiruiSoft.Safe
{
     public partial class formSelectLanguage : System.Windows.Forms.Form
     {
          private System.ComponentModel.IContainer components = null;
          private System.Windows.Forms.Button buttonOK;
          private System.Windows.Forms.Button buttonCancel;
          private System.Windows.Forms.ListView listViewLanguages;

          internal formSelectLanguage( )
          {
               this.InitializeComponent( );

               this.MinimizeBox = false;
               this.MaximizeBox = false;
               this.ShowInTaskbar = false;
               this.WindowState = FormWindowState.Normal;
               this.FormBorderStyle = FormBorderStyle.FixedDialog;
               this.StartPosition = FormStartPosition.CenterScreen;
          }

          protected override void OnLoad(System.EventArgs args)
          {
               base.OnLoad(args);

               if (!base.DesignMode)
               {
                    this.Icon = HuiruiSoft.Utils.WindowsUtils.DefaultAppIcon;
                    this.Text = SafePassResource.ChangeLanguageWindowCaption;
                    this.CancelButton = this.buttonCancel;
                    this.buttonOK.Text = SafePassResource.ButtonOK;
                    this.buttonCancel.Text = SafePassResource.ButtonCancel;

                    this.InitializeLanguages();
               }

               this.buttonOK.Enabled = false;
          }

          private void InitializeLanguages()
          {
               this.listViewLanguages.Columns.Add(new ColumnHeader() { Width = 200, TextAlign = HorizontalAlignment.Left, Text= SafePassResource.ChangeLanguageWindowColumnLanguageName });
               this.listViewLanguages.Columns.Add(new ColumnHeader() { Width = 080, TextAlign = HorizontalAlignment.Left, Text = SafePassResource.ChangeLanguageWindowColumnLanguageVersion });
               this.listViewLanguages.Columns.Add(new ColumnHeader() { Width = 320, TextAlign = HorizontalAlignment.Left, Text = SafePassResource.ChangeLanguageWindowColumnLanguageFile });

               this.listViewLanguages.View = System.Windows.Forms.View.Details;

               var tmpListViewItem = new ListViewItem();
               tmpListViewItem.ImageIndex = 0;
               tmpListViewItem.Text = "English(English)";
               tmpListViewItem.SubItems.Add(ApplicationDefines.VersionNo);
               tmpListViewItem.SubItems.Add(SafePassResource.ChangeLanguageWindowLanguageBuiltIn);
               this.listViewLanguages.Items.Add(tmpListViewItem);

               var tmpLanguageDirectory = new System.IO.DirectoryInfo(System.IO.Path.Combine(Application.StartupPath, @"languages"));
               if (tmpLanguageDirectory != null && tmpLanguageDirectory.Exists)
               {
                    var tmpLanguageFileInfos = tmpLanguageDirectory.GetFiles("*.lng");

                    this.listViewLanguages.BeginUpdate();
                    foreach (var tmpLanguageFile in tmpLanguageFileInfos)
                    {
                         var localization = LocalizationResourceReader.ReadLocalResource(tmpLanguageFile.FullName);
                         if (localization != null)
                         {
                              tmpListViewItem = new ListViewItem();
                              tmpListViewItem.ImageIndex = 0;
                              tmpListViewItem.Text = string.Format("{0}({1})", localization.Header.EnglishName, localization.Header.NativeName);
                              tmpListViewItem.SubItems.Add(localization.Header.Version);
                              tmpListViewItem.SubItems.Add(string.Format(@"languages\{0}", tmpLanguageFile.Name));
                              tmpListViewItem.Tag = localization.Header;

                              this.listViewLanguages.Items.Add(tmpListViewItem);
                         }
                    }

                    this.listViewLanguages.EndUpdate();
               }

               this.listViewLanguages.MultiSelect = false;
               this.listViewLanguages.FullRowSelect = true;
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
               this.buttonOK = new System.Windows.Forms.Button();
               this.buttonCancel = new System.Windows.Forms.Button();
               this.listViewLanguages = new System.Windows.Forms.ListView();
               this.SuspendLayout();
               // 
               // buttonOK
               // 
               this.buttonOK.Location = new System.Drawing.Point(568, 549);
               this.buttonOK.Name = "buttonOK";
               this.buttonOK.Size = new System.Drawing.Size(180, 49);
               this.buttonOK.TabIndex = 17;
               this.buttonOK.Text = "&OK";
               this.buttonOK.UseVisualStyleBackColor = true;
               this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
               // 
               // buttonCancel
               // 
               this.buttonCancel.Location = new System.Drawing.Point(792, 549);
               this.buttonCancel.Name = "buttonCancel";
               this.buttonCancel.Size = new System.Drawing.Size(180, 49);
               this.buttonCancel.TabIndex = 18;
               this.buttonCancel.Text = "&Close";
               this.buttonCancel.UseVisualStyleBackColor = true;
               this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
               // 
               // listViewLanguages
               // 
               this.listViewLanguages.HideSelection = false;
               this.listViewLanguages.Location = new System.Drawing.Point(21, 29);
               this.listViewLanguages.Name = "listViewLanguages";
               this.listViewLanguages.Size = new System.Drawing.Size(951, 482);
               this.listViewLanguages.TabIndex = 19;
               this.listViewLanguages.UseCompatibleStateImageBehavior = false;
               this.listViewLanguages.SelectedIndexChanged += new System.EventHandler(this.listViewLanguages_SelectedIndexChanged);
               // 
               // formSelectLanguage
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(996, 635);
               this.Controls.Add(this.listViewLanguages);
               this.Controls.Add(this.buttonOK);
               this.Controls.Add(this.buttonCancel);
               this.Margin = new System.Windows.Forms.Padding(4);
               this.Name = "formSelectLanguage";
               this.Text = "Select Language";
               this.ResumeLayout(false);

          }

          #endregion

          private void buttonOK_Click(object sender, System.EventArgs args)
          {
               var tmpDialogResult = MessageBox.Show(SafePassResource.ChangeLanguageWindowMessage, SafePassResource.Info, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
               if (tmpDialogResult == DialogResult.Yes)
               {
                    string tmpLanguageFile = null;
                    if (this.listViewLanguages.SelectedItems.Count > 0)
                    {
                         var tmpListViewItem = this.listViewLanguages.SelectedItems[0];
                         if (tmpListViewItem.Tag != null && tmpListViewItem.Tag is LanguageHeader)
                         {
                              tmpLanguageFile = tmpListViewItem.SubItems[2].Text;
                         }
                    }

                    if (tmpLanguageFile != Program.Config.Application.LanguageFile)
                    {
                         Program.Config.Application.LanguageFile = tmpLanguageFile;
                         ApplicationConfigSerializer.SaveApplicationConfig(Program.Config);
                    }

                    this.DialogResult = DialogResult.OK;
               }
          }

          private void buttonCancel_Click(object sender, System.EventArgs args)
          {
               this.DialogResult = DialogResult.Cancel;
          }

          private void listViewLanguages_SelectedIndexChanged(object sender, System.EventArgs args)
          {
               var tmpLanguageChanged = false;

               if (this.listViewLanguages.SelectedItems.Count > 0)
               {
                    string tmpLanguageFile = null;

                    var tmpListViewItem = this.listViewLanguages.SelectedItems[0];
                    if (tmpListViewItem.Tag != null && tmpListViewItem.Tag is LanguageHeader)
                    {
                         tmpLanguageFile = tmpListViewItem.SubItems[2].Text;
                    }

                    tmpLanguageChanged = Program.Config.Application.LanguageFile != tmpLanguageFile;
               }

               this.buttonOK.Enabled = tmpLanguageChanged;
          }
     }
}
