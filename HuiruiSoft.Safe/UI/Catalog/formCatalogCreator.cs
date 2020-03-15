
using System.Windows.Forms;
using HuiruiSoft.Safe.Model;
using HuiruiSoft.Safe.Resources;

namespace HuiruiSoft.Safe
{
     internal class formCatalogCreator : formCatalogBase
     {
          private AccountCatalog parentCatalogItem;
          private AccountCatalog createCatalogItem;

          public AccountCatalog NewCatalog
          {
               get { return this.createCatalogItem; }
          }

          private formCatalogCreator()
          {
               //
          }


          public formCatalogCreator(AccountCatalog parentCatalog) : base()
          {
               this.parentCatalogItem = parentCatalog;
          }

          protected override void OnLoad(System.EventArgs args)
          {
               base.OnLoad(args);

               if (!base.DesignMode)
               {
                    this.Text = SafePassResource.CatalogCreatorCaption;
               }
          }

          protected override void OnClosed(System.EventArgs args)
          {
               base.OnClosed(args);
          }

          protected override void buttonCancel_Click(object sender, System.EventArgs args)
          {
               this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          }

          protected override void buttonOK_Click(object sender, System.EventArgs args)
          {
               if (base.CheckInputValidity())
               {
                    var tmpInputErrorCaption = SafePassResource.MessageBoxCaptionInputError;

                    string tmpCatalogName = this.textCatalogName.Text;

                    bool tmpCheckupResult = true;
                    if (this.parentCatalogItem == null)
                    {
                         //检查在此目录下是否已经存在一个相同名称的目录
                    }
                    else
                    {
                         //检查在此目录下是否已经存在一个相同名称的目录
                    }

                    if (!tmpCheckupResult)
                    {
                         MessageBox.Show(string.Format(SafePassResource.CatalogEditorPromptCatalogNameRepeat, tmpCatalogName), tmpInputErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                         this.textCatalogName.Focus();
                         return;
                    }
                    else
                    {
                         this.createCatalogItem = new AccountCatalog();
                         this.createCatalogItem.Name = tmpCatalogName;

                         string tmpDescription = this.textDescription.Text.Trim();
                         if (!string.IsNullOrEmpty(tmpDescription))
                         {
                              this.createCatalogItem.Description = tmpDescription;
                         }

                         if (this.parentCatalogItem == null)
                         {
                              this.createCatalogItem.Depth = 1;
                              this.createCatalogItem.ParentId = -1;
                         }
                         else
                         {
                              this.createCatalogItem.Depth = this.parentCatalogItem.Depth + 1;
                              this.createCatalogItem.ParentId = this.parentCatalogItem.CatalogId;
                         }

                         var tmpCatalogService = new HuiruiSoft.Safe.Service.CatalogService();
                         if (tmpCatalogService.New(this.createCatalogItem))
                         {
                              this.DialogResult = System.Windows.Forms.DialogResult.OK;
                         }
                         else
                         {
                              this.createCatalogItem = null;
                         }
                    }
               }
          }
     }
}
