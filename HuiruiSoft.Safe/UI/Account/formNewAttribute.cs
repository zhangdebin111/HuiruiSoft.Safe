
using System.Windows.Forms;
using HuiruiSoft.Utils;
using HuiruiSoft.Safe.Resources;

namespace HuiruiSoft.Safe
{
     public partial class formNewAttribute : System.Windows.Forms.Form
     {
          private System.ComponentModel.IContainer components = null;

          private System.Windows.Forms.Button buttonOK;
          private System.Windows.Forms.Button buttonCancel;
          private System.Windows.Forms.Label labelAttributeName;
          private System.Windows.Forms.Label labelAttributeValue;
          private System.Windows.Forms.TextBox textAttributeName;
          private System.Windows.Forms.TextBox textAttributeValue;
          private System.Windows.Forms.CheckBox checkEncryptValue;

          private formAccountBase accountWindow;

          internal formNewAttribute(formAccountBase accountWindow)
          {
               this.InitializeComponent();

               this.MinimizeBox = false;
               this.MaximizeBox = false;
               this.ShowInTaskbar = false;

               this.WindowState = FormWindowState.Normal;
               this.FormBorderStyle = FormBorderStyle.FixedDialog;
               this.StartPosition = FormStartPosition.CenterScreen;

               this.accountWindow = accountWindow;

               this.AcceptButton = this.buttonOK;
               this.CancelButton = this.buttonCancel;
          }

          protected override void OnLoad(System.EventArgs args)
          {
               base.OnLoad(args);

               if (!base.DesignMode)
               {
                    this.buttonOK.Text = SafePassResource.ButtonOK;
                    this.buttonCancel.Text = SafePassResource.ButtonClose;

                    this.Text = SafePassResource.AddAttributeWindowTitle;
                    this.labelAttributeName.Text = SafePassResource.AddAttributeWindowLabelName;
                    this.labelAttributeValue.Text = SafePassResource.AddAttributeWindowLabelValue;
                    this.checkEncryptValue.Text = SafePassResource.AddAttributeWindowCheckBoxEncrypt;

                    this.textAttributeName.MaxLength = 50;
                    this.textAttributeValue.MaxLength = 400;

                    this.UpdateControlState(true);
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
               }
               base.Dispose(disposing);
          }

          #region Windows 窗体设计器生成的代码

          private void InitializeComponent()
          {
               this.buttonCancel = new System.Windows.Forms.Button();
               this.buttonOK = new System.Windows.Forms.Button();
               this.labelAttributeName = new System.Windows.Forms.Label();
               this.textAttributeName = new System.Windows.Forms.TextBox();
               this.textAttributeValue = new System.Windows.Forms.TextBox();
               this.labelAttributeValue = new System.Windows.Forms.Label();
               this.checkEncryptValue = new System.Windows.Forms.CheckBox();
               this.SuspendLayout();
               // 
               // buttonCancel
               // 
               this.buttonCancel.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
               this.buttonCancel.Location = new System.Drawing.Point(411, 176);
               this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
               this.buttonCancel.Name = "buttonCancel";
               this.buttonCancel.Size = new System.Drawing.Size(172, 55);
               this.buttonCancel.TabIndex = 5;
               this.buttonCancel.Text = "&Cancel";
               this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
               // 
               // buttonOK
               // 
               this.buttonOK.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
               this.buttonOK.Location = new System.Drawing.Point(614, 176);
               this.buttonOK.Margin = new System.Windows.Forms.Padding(4);
               this.buttonOK.Name = "buttonOK";
               this.buttonOK.Size = new System.Drawing.Size(172, 55);
               this.buttonOK.TabIndex = 6;
               this.buttonOK.Text = "&OK";
               this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
               // 
               // labelAttributeName
               // 
               this.labelAttributeName.AutoSize = true;
               this.labelAttributeName.Location = new System.Drawing.Point(42, 48);
               this.labelAttributeName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.labelAttributeName.Name = "labelAttributeName";
               this.labelAttributeName.Size = new System.Drawing.Size(53, 18);
               this.labelAttributeName.TabIndex = 0;
               this.labelAttributeName.Text = "Name:";
               // 
               // textAttributeName
               // 
               this.textAttributeName.Location = new System.Drawing.Point(149, 43);
               this.textAttributeName.Margin = new System.Windows.Forms.Padding(4);
               this.textAttributeName.Name = "textAttributeName";
               this.textAttributeName.Size = new System.Drawing.Size(637, 28);
               this.textAttributeName.TabIndex = 1;
               this.textAttributeName.TextChanged += new System.EventHandler(this.textAttributeName_TextChanged);
               // 
               // textAttributeValue
               // 
               this.textAttributeValue.Location = new System.Drawing.Point(149, 114);
               this.textAttributeValue.Margin = new System.Windows.Forms.Padding(4);
               this.textAttributeValue.Name = "textAttributeValue";
               this.textAttributeValue.Size = new System.Drawing.Size(637, 28);
               this.textAttributeValue.TabIndex = 3;
               this.textAttributeValue.TextChanged += new System.EventHandler(this.textAttributeValue_TextChanged);
               // 
               // labelAttributeValue
               // 
               this.labelAttributeValue.AutoSize = true;
               this.labelAttributeValue.Location = new System.Drawing.Point(42, 119);
               this.labelAttributeValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.labelAttributeValue.Name = "labelAttributeValue";
               this.labelAttributeValue.Size = new System.Drawing.Size(62, 18);
               this.labelAttributeValue.TabIndex = 2;
               this.labelAttributeValue.Text = "Value:";
               // 
               // checkEncryptValue
               // 
               this.checkEncryptValue.AutoSize = true;
               this.checkEncryptValue.Location = new System.Drawing.Point(149, 194);
               this.checkEncryptValue.Margin = new System.Windows.Forms.Padding(4);
               this.checkEncryptValue.Name = "checkEncryptValue";
               this.checkEncryptValue.Size = new System.Drawing.Size(241, 22);
               this.checkEncryptValue.TabIndex = 4;
               this.checkEncryptValue.Text = "Encrypt attribute value";
               this.checkEncryptValue.UseVisualStyleBackColor = true;
               // 
               // formNewAttribute
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(832, 290);
               this.Controls.Add(this.checkEncryptValue);
               this.Controls.Add(this.textAttributeValue);
               this.Controls.Add(this.labelAttributeValue);
               this.Controls.Add(this.textAttributeName);
               this.Controls.Add(this.labelAttributeName);
               this.Controls.Add(this.buttonOK);
               this.Controls.Add(this.buttonCancel);
               this.Margin = new System.Windows.Forms.Padding(4);
               this.Name = "formNewAttribute";
               this.Text = "New attribute";
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion

          private void textAttributeName_TextChanged(object sender, System.EventArgs args)
          {
               this.UpdateControlState(true);
          }

          private void textAttributeValue_TextChanged(object sender, System.EventArgs args)
          {
               this.UpdateControlState(true);
          }

          private void UpdateControlState(bool setModified = true)
          {
               string tmpAttributeName = this.textAttributeName.Text.Trim();
               string tmpAttributeValue = this.textAttributeValue.Text.Trim();
               this.buttonOK.Enabled = !string.IsNullOrEmpty(tmpAttributeName) && !string.IsNullOrEmpty(tmpAttributeValue);
          }

          private void buttonCancel_Click(object sender, System.EventArgs args)
          {
               this.DialogResult = DialogResult.Cancel;
          }

          private void buttonOK_Click(object sender, System.EventArgs args)
          {
               string tmpAttributeName = this.textAttributeName.Text.Trim();
               string tmpAttributeValue = this.textAttributeValue.Text.Trim();

               var tmpInputErrorCaption = SafePassResource.MessageBoxCaptionInputError;
               if (string.IsNullOrEmpty(tmpAttributeName))
               {
                    this.textAttributeName.Focus();
                    MessageBox.Show(SafePassResource.AddAttributeWindowFieldNameEmpty, tmpInputErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
               }
               else if (string.IsNullOrEmpty(tmpAttributeValue))
               {
                    this.textAttributeValue.Focus();
                    MessageBox.Show(SafePassResource.AddAttributeWindowFieldValueEmpty, tmpInputErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
               }
               else
               {
                    bool tmpCreateResult = this.accountWindow.NewAccountExtendAttribute(tmpAttributeName, tmpAttributeValue, this.checkEncryptValue.Checked);
                    if (tmpCreateResult)
                    {
                         var tmpMessageBoxTitle = SafePassResource.AddAttributeMessageBoxTitleSuccess;
                         var tmpMessageBoxPrompt = SafePassResource.AddAttributeMessageBoxAddedSuccess;
                         MessageBox.Show(string.Format(tmpMessageBoxPrompt, tmpAttributeName, tmpAttributeValue), tmpMessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                         this.DialogResult = DialogResult.OK;
                    }
               }
          }
     }
}
