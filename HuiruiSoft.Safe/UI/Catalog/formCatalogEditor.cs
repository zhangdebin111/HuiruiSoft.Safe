
using System.Windows.Forms;
using HuiruiSoft.Safe.Model;
using HuiruiSoft.Safe.Resources;

namespace HuiruiSoft.Safe
{
     internal class formCatalogEditor : formCatalogBase
     {
          private AccountCatalog currentCatalogItem;

          private formCatalogEditor()
          {
               //
          }

          public formCatalogEditor(AccountCatalog currentCatalog) : base()
          {
               this.currentCatalogItem = currentCatalog;
               this.textCatalogName.Text = this.currentCatalogItem.Name;
               this.textDescription.Text = this.currentCatalogItem.Description;
          }

          protected override void OnLoad(System.EventArgs args)
          {
               base.OnLoad(args);

               if (!base.DesignMode)
               {
                    this.Text = SafePassResource.CatalogEditorCaption;
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

                    bool tmpCheckupResult = false;
                    string tmpCatalogName = this.textCatalogName.Text;
                    if (!string.Equals(this.currentCatalogItem.Name, tmpCatalogName, System.StringComparison.CurrentCultureIgnoreCase))
                    {
                         //
                    }

                    if (tmpCheckupResult)
                    {
                         MessageBox.Show(string.Format(SafePassResource.CatalogEditorPromptCatalogNameRepeat, tmpCatalogName), tmpInputErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                         this.textCatalogName.Focus();
                         return;
                    }
                    else
                    {
                         string tmpDescription = this.textDescription.Text.Trim();
                         this.currentCatalogItem.Name = tmpCatalogName;
                         this.currentCatalogItem.UpdateTime = System.DateTime.Now;
                         this.currentCatalogItem.Description = string.IsNullOrEmpty(tmpDescription) ? null : tmpDescription;

                         var tmpCatalogService = new HuiruiSoft.Safe.Service.CatalogService();
                         if (tmpCatalogService.Update(this.currentCatalogItem))
                         {
                              this.DialogResult = System.Windows.Forms.DialogResult.OK;
                         }
                    }
               }
          }
     }
}