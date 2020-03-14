using System.Windows.Forms;
using HuiruiSoft.Utils;
using HuiruiSoft.Safe.Exchange;
using HuiruiSoft.Safe.Resources;

namespace HuiruiSoft.Safe
{
     internal partial class formImportAccount : System.Windows.Forms.Form
     {
          private System.ComponentModel.IContainer components = null;
          private System.Windows.Forms.Button buttonOK;
          private System.Windows.Forms.Button buttonCancel;
          private System.Windows.Forms.Label labelImportFile;
          private System.Windows.Forms.Button buttonSelectFile;
          private System.Windows.Forms.TextBox textImportFile;
          private System.Windows.Forms.GroupBox groupImportOptions;
          private System.Windows.Forms.GroupBox groupImportFile;

          internal formImportAccount()
          {
               this.InitializeComponent();

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
                    this.CancelButton = this.buttonCancel;

                    this.buttonOK.Text = SafePassResource.ButtonOK;
                    this.buttonCancel.Text = SafePassResource.ButtonCancel;

                    this.Icon = WindowsUtils.DefaultAppIcon;
                    this.Text = SafePassResource.ImportWindowCaption;
                    this.groupImportFile.Text = SafePassResource.ImportWindowGroupBoxFileInfo;
                    this.labelImportFile.Text = SafePassResource.ImportWindowLabelImportFile;
                    this.groupImportOptions.Text = SafePassResource.ImportWindowGroupBoxOptions;

                    this.UpdateControlState();
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
               this.groupImportOptions = new System.Windows.Forms.GroupBox();
               this.groupImportFile = new System.Windows.Forms.GroupBox();
               this.buttonSelectFile = new System.Windows.Forms.Button();
               this.textImportFile = new System.Windows.Forms.TextBox();
               this.labelImportFile = new System.Windows.Forms.Label();
               this.groupImportFile.SuspendLayout();
               this.SuspendLayout();
               // 
               // buttonCancel
               // 
               this.buttonCancel.Location = new System.Drawing.Point(741, 509);
               this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
               this.buttonCancel.Name = "buttonCancel";
               this.buttonCancel.Size = new System.Drawing.Size(180, 55);
               this.buttonCancel.TabIndex = 3;
               this.buttonCancel.Text = "&Cancel";
               this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
               // 
               // buttonOK
               // 
               this.buttonOK.Location = new System.Drawing.Point(529, 509);
               this.buttonOK.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
               this.buttonOK.Name = "buttonOK";
               this.buttonOK.Size = new System.Drawing.Size(180, 55);
               this.buttonOK.TabIndex = 2;
               this.buttonOK.Text = "&OK";
               this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
               // 
               // groupImportOptions
               // 
               this.groupImportOptions.Location = new System.Drawing.Point(30, 154);
               this.groupImportOptions.Name = "groupImportOptions";
               this.groupImportOptions.Size = new System.Drawing.Size(891, 307);
               this.groupImportOptions.TabIndex = 0;
               this.groupImportOptions.TabStop = false;
               this.groupImportOptions.Text = "Options";
               // 
               // groupImportFile
               // 
               this.groupImportFile.Controls.Add(this.buttonSelectFile);
               this.groupImportFile.Controls.Add(this.textImportFile);
               this.groupImportFile.Controls.Add(this.labelImportFile);
               this.groupImportFile.Location = new System.Drawing.Point(30, 26);
               this.groupImportFile.Margin = new System.Windows.Forms.Padding(4);
               this.groupImportFile.Name = "groupImportFile";
               this.groupImportFile.Padding = new System.Windows.Forms.Padding(4);
               this.groupImportFile.Size = new System.Drawing.Size(891, 99);
               this.groupImportFile.TabIndex = 1;
               this.groupImportFile.TabStop = false;
               this.groupImportFile.Text = "File";
               // 
               // buttonSelectFile
               // 
               this.buttonSelectFile.Location = new System.Drawing.Point(829, 39);
               this.buttonSelectFile.Margin = new System.Windows.Forms.Padding(4);
               this.buttonSelectFile.Name = "buttonSelectFile";
               this.buttonSelectFile.Size = new System.Drawing.Size(48, 32);
               this.buttonSelectFile.TabIndex = 2;
               this.buttonSelectFile.UseVisualStyleBackColor = true;
               this.buttonSelectFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
               // 
               // textImportFile
               // 
               this.textImportFile.Location = new System.Drawing.Point(187, 40);
               this.textImportFile.Margin = new System.Windows.Forms.Padding(4);
               this.textImportFile.Name = "textImportFile";
               this.textImportFile.Size = new System.Drawing.Size(634, 28);
               this.textImportFile.TabIndex = 1;
               this.textImportFile.TextChanged += new System.EventHandler(this.textImportFile_TextChanged);
               // 
               // labelImportFile
               // 
               this.labelImportFile.AutoSize = true;
               this.labelImportFile.Location = new System.Drawing.Point(18, 45);
               this.labelImportFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.labelImportFile.Name = "labelImportFile";
               this.labelImportFile.Size = new System.Drawing.Size(161, 18);
               this.labelImportFile.TabIndex = 0;
               this.labelImportFile.Text = "Import from file:";
               // 
               // formImportAccount
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(956, 613);
               this.Controls.Add(this.groupImportFile);
               this.Controls.Add(this.groupImportOptions);
               this.Controls.Add(this.buttonCancel);
               this.Controls.Add(this.buttonOK);
               this.Margin = new System.Windows.Forms.Padding(4);
               this.Name = "formImportAccount";
               this.Text = "Import";
               this.groupImportFile.ResumeLayout(false);
               this.groupImportFile.PerformLayout();
               this.ResumeLayout(false);

          }

          #endregion

          private void buttonCancel_Click(object sender, System.EventArgs args)
          {
               this.DialogResult = DialogResult.Cancel;
          }

          private void textImportFile_TextChanged(object sender, System.EventArgs args)
          {
               this.UpdateControlState();
          }

          private void buttonOK_Click(object sender, System.EventArgs args)
          {
               var tmpFileName = this.textImportFile.Text;
               if (!string.IsNullOrEmpty(tmpFileName))
               {
                    var tmpFileInfo = new System.IO.FileInfo(tmpFileName);
                    if (tmpFileInfo.Exists)
                    {
                         if (MessageBox.Show(string.Format(SafePassResource.ExportOverwriteDialogPrompt, tmpFileInfo.Name, System.Environment.NewLine),
                               SafePassResource.ExportOverwriteDialogCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                         {
                              return;
                         }
                    }
                    else if (!tmpFileInfo.Directory.Exists)
                    {
                         MessageBox.Show(string.Format(SafePassResource.ExportInvalidPathDialogPrompt, tmpFileInfo.Directory, System.Environment.NewLine),
                               SafePassResource.ExportInvalidPathDialogCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                         return;
                    }

                    this.DialogResult = DialogResult.OK;
               }
          }

          private void buttonSelectFile_Click(object sender, System.EventArgs args)
          {
               var tmpOpenFileDialog = new OpenFileDialog();
               tmpOpenFileDialog.ShowHelp = false;
               tmpOpenFileDialog.ShowReadOnly = false;
               tmpOpenFileDialog.CheckFileExists = true;
               tmpOpenFileDialog.CheckPathExists = true;
               tmpOpenFileDialog.ReadOnlyChecked = false;
               tmpOpenFileDialog.DereferenceLinks = true;
               tmpOpenFileDialog.ValidateNames = true;
               tmpOpenFileDialog.RestoreDirectory = false;
               tmpOpenFileDialog.Title = SafePassResource.ImportDialogTitle;

               if (System.IO.Directory.Exists(this.textImportFile.Text))
               {
                    tmpOpenFileDialog.InitialDirectory = this.textImportFile.Text;
               }

               if (tmpOpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
               {
                    this.textImportFile.Text = tmpOpenFileDialog.FileName;
                    this.UpdateControlState();
               }
          }

          private void UpdateControlState( )
          {
               this.buttonOK.Enabled = !string.IsNullOrEmpty(this.textImportFile.Text);
          }
     }
}
