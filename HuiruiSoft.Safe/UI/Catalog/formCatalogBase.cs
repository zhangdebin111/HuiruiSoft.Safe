
using System.Windows.Forms;
using HuiruiSoft.Safe.Resources;

namespace HuiruiSoft.Safe
{
     internal class formCatalogBase : System.Windows.Forms.Form
     {
          private System.ComponentModel.Container components = null;

          protected System.Windows.Forms.Button buttonOK;
          protected System.Windows.Forms.Button buttonCancel;
          protected System.Windows.Forms.Label labelCatalogName;
          protected System.Windows.Forms.Label lblDescription;
          protected System.Windows.Forms.TextBox textCatalogName;
          protected System.Windows.Forms.TextBox textDescription;

          protected formCatalogBase()
          {
               this.InitializeComponent();

               this.MinimizeBox = false;
               this.MaximizeBox = false;
               this.ShowInTaskbar = false;
               this.AcceptButton = this.buttonOK;
               this.CancelButton = this.buttonCancel;
               this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
               this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
          }

          protected override void OnLoad(System.EventArgs args)
          {
               base.OnLoad(args);

               if (!base.DesignMode)
               {
                    this.Icon = HuiruiSoft.Utils.WindowsUtils.DefaultAppIcon;
                    this.buttonOK.Text = SafePassResource.ButtonOK;
                    this.buttonCancel.Text = SafePassResource.ButtonCancel;
                    this.labelCatalogName.Text = SafePassResource.CatalogEditorName;
                    this.lblDescription.Text = SafePassResource.CatalogEditorDescription;

                    this.textCatalogName.MaxLength = 30;
                    this.textDescription.MaxLength = 100;
               }
          }

          protected override void Dispose(bool disposing)
          {
               if (disposing)
               {
                    if (components != null)
                    {
                         components.Dispose();
                    }
               }
               base.Dispose(disposing);
          }

          #region Windows 窗体设计器生成的代码

          private void InitializeComponent()
          {
               this.lblDescription = new System.Windows.Forms.Label();
               this.textDescription = new System.Windows.Forms.TextBox();
               this.textCatalogName = new System.Windows.Forms.TextBox();
               this.labelCatalogName = new System.Windows.Forms.Label();
               this.buttonCancel = new System.Windows.Forms.Button();
               this.buttonOK = new System.Windows.Forms.Button();
               this.SuspendLayout();
               // 
               // lblDescription
               // 
               this.lblDescription.Location = new System.Drawing.Point(14, 78);
               this.lblDescription.Name = "lblDescription";
               this.lblDescription.Size = new System.Drawing.Size(134, 35);
               this.lblDescription.TabIndex = 2;
               this.lblDescription.Text = "Description:";
               // 
               // textDescription
               // 
               this.textDescription.Location = new System.Drawing.Point(150, 78);
               this.textDescription.Multiline = true;
               this.textDescription.Name = "textDescription";
               this.textDescription.Size = new System.Drawing.Size(575, 282);
               this.textDescription.TabIndex = 3;
               // 
               // textCatalogName
               // 
               this.textCatalogName.Location = new System.Drawing.Point(150, 26);
               this.textCatalogName.Name = "textCatalogName";
               this.textCatalogName.Size = new System.Drawing.Size(575, 28);
               this.textCatalogName.TabIndex = 1;
               // 
               // labelCatalogName
               // 
               this.labelCatalogName.Location = new System.Drawing.Point(18, 31);
               this.labelCatalogName.Name = "labelCatalogName";
               this.labelCatalogName.Size = new System.Drawing.Size(134, 35);
               this.labelCatalogName.TabIndex = 0;
               this.labelCatalogName.Text = "Name:";
               // 
               // buttonCancel
               // 
               this.buttonCancel.Location = new System.Drawing.Point(545, 401);
               this.buttonCancel.Name = "buttonCancel";
               this.buttonCancel.Size = new System.Drawing.Size(180, 49);
               this.buttonCancel.TabIndex = 5;
               this.buttonCancel.Text = "&Close";
               this.buttonCancel.UseVisualStyleBackColor = true;
               this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
               // 
               // buttonOK
               // 
               this.buttonOK.Location = new System.Drawing.Point(321, 401);
               this.buttonOK.Name = "buttonOK";
               this.buttonOK.Size = new System.Drawing.Size(180, 49);
               this.buttonOK.TabIndex = 4;
               this.buttonOK.Text = "&OK";
               this.buttonOK.UseVisualStyleBackColor = true;
               this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
               // 
               // formCatalogBase
               // 
               this.AutoScaleBaseSize = new System.Drawing.Size(10, 21);
               this.ClientSize = new System.Drawing.Size(767, 486);
               this.Controls.Add(this.buttonOK);
               this.Controls.Add(this.buttonCancel);
               this.Controls.Add(this.textCatalogName);
               this.Controls.Add(this.labelCatalogName);
               this.Controls.Add(this.textDescription);
               this.Controls.Add(this.lblDescription);
               this.Name = "formCatalogBase";
               this.Text = "Catalog";
               this.ResumeLayout(false);
               this.PerformLayout();

          }
          #endregion

          protected virtual void buttonOK_Click(object sender, System.EventArgs args)
          {
               this.DialogResult = System.Windows.Forms.DialogResult.OK;
          }

          protected virtual void buttonCancel_Click(object sender, System.EventArgs args)
          {
               this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          }

          protected bool CheckInputValidity()
          {
               var tmpInputErrorCaption = SafePassResource.MessageBoxCaptionInputError;

               string tmpCatalogName = this.textCatalogName.Text.Trim();
               if (string.IsNullOrEmpty(tmpCatalogName))
               {
                    this.textCatalogName.Focus();
                    MessageBox.Show(SafePassResource.CatalogEditorPromptNameIsEmpty, tmpInputErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
               }
               else if (HuiruiSoft.Utils.StringHelper.GetStringBytesCount(tmpCatalogName) > 100)
               {
                    this.textCatalogName.Focus();
                    MessageBox.Show(SafePassResource.CatalogEditorPromptNameTooLong, tmpInputErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
               }

               if (HuiruiSoft.Utils.StringHelper.GetStringBytesCount(this.textDescription.Text) > 500)
               {
                    this.textDescription.Focus();
                    MessageBox.Show(SafePassResource.CatalogEditorPromptDescriptionTooLong, tmpInputErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
               }

               return true;
          }
     }
}