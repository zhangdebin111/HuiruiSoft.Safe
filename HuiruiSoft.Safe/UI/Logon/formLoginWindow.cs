
using System.Windows.Forms;
using HuiruiSoft.Safe.Resources;

namespace HuiruiSoft.Safe
{
     internal class formLoginWindow : formLoginBase
     {
          internal formLoginWindow( )
          {
               //
          }

          protected override void OnLoad(System.EventArgs args)
          {
               base.OnLoad(args);

               if (!base.DesignMode)
               {
                    this.MinimizeBox = true;
                    this.MaximizeBox = false;
                    this.ShowInTaskbar = true;
                    this.AcceptButton = this.buttonOK;
                    this.CancelButton = this.buttonCancel;

                    this.Text = SafePassResource.LoginWindowCaption;
                    this.buttonOK.Text = SafePassResource.ButtonOK;
                    this.buttonCancel.Text = SafePassResource.ButtonCancel;
                    this.groupOptions.Text = SafePassResource.LoginWindowOptions;
                    this.labelLoginName.Text = SafePassResource.LoginWindowUserName;
                    this.labelPassword.Text = SafePassResource.LoginWindowPassword;
               }
          }

          protected override void OnLoginButtonClick(object sender, System.EventArgs args)
          {
               base.OnLoginButtonClick(sender, args);
          }

          protected override void OnCloseButtonClick(object sender, System.EventArgs args)
          {
               HuiruiSoft.Safe.Localization.LocalizationResSerializerZHN.SaveLocalResources();
               this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          }
     }
}