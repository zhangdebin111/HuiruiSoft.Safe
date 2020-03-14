
using HuiruiSoft.Utils;
using HuiruiSoft.Safe.Model;
using HuiruiSoft.Safe.Resources;

namespace HuiruiSoft.Safe
{
     internal class formCatalogViewer : formCatalogBase
     {
          private AccountCatalog currentCatalogItem;

          private formCatalogViewer()
          {
               //
          }

          public formCatalogViewer(AccountCatalog currentCatalog) : base()
          {
               this.currentCatalogItem = currentCatalog;
               if (this.currentCatalogItem != null)
               {
                    this.textCatalogName.Text = this.currentCatalogItem.Name;
                    this.textDescription.Text = this.currentCatalogItem.Description;
               }

               this.textCatalogName.ReadOnly = true;
               this.textDescription.ReadOnly = true;

               this.buttonOK.Visible = false;
               this.CancelButton = this.buttonCancel;
               this.AcceptButton = this.buttonCancel;
          }

          protected override void OnLoad(System.EventArgs args)
          {
               base.OnLoad(args);

               if (!base.DesignMode)
               {
                    this.Text = SafePassResource.CatalogViewerCaption;
                    this.buttonOK.Text = SafePassResource.ButtonClose;
                    this.buttonCancel.Text = SafePassResource.ButtonClose;
               }
          }

          protected override void OnClosed(System.EventArgs args)
          {
               base.OnClosed(args);
          }

          protected override void buttonCancel_Click(object sender, System.EventArgs args)
          {
               this.Close();
          }

          protected override void buttonOK_Click(object sender, System.EventArgs args)
          {
               this.Close();
          }
     }
}