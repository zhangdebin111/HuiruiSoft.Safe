using System.Windows.Forms;
using HuiruiSoft.Utils;
using HuiruiSoft.Safe.Exchange;
using HuiruiSoft.Safe.Resources;

namespace HuiruiSoft.Safe
{
     internal partial class formExportAccount : System.Windows.Forms.Form
     {
          private System.ComponentModel.IContainer components = null;
          private System.Windows.Forms.Button buttonOK;
          private System.Windows.Forms.Button buttonCancel;
          private System.Windows.Forms.Label labelExportFile;
          private System.Windows.Forms.Button buttonSelectFile;
          private System.Windows.Forms.TextBox textExportFile;
          private System.Windows.Forms.GroupBox groupDataFormat;
          private System.Windows.Forms.GroupBox groupExportFile;
          private System.Windows.Forms.RadioButton radioExportXML1;
          private System.Windows.Forms.RadioButton radioExportExcel;

          private TreeNodeCollection treeViewNodes;

          internal formExportAccount(TreeNodeCollection treeViewNodes)
          {
               this.treeViewNodes = treeViewNodes;

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
                    this.Text = SafePassResource.ExportWindowCaption;
                    this.groupDataFormat.Text = SafePassResource.ExportWindowGroupBoxFormat;
                    this.groupExportFile.Text = SafePassResource.ExportWindowGroupBoxFileInfo;
                    this.labelExportFile.Text = SafePassResource.ExportWindowLabelExportFile;

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
               this.groupDataFormat = new System.Windows.Forms.GroupBox();
               this.radioExportXML1 = new System.Windows.Forms.RadioButton();
               this.radioExportExcel = new System.Windows.Forms.RadioButton();
               this.groupExportFile = new System.Windows.Forms.GroupBox();
               this.buttonSelectFile = new System.Windows.Forms.Button();
               this.textExportFile = new System.Windows.Forms.TextBox();
               this.labelExportFile = new System.Windows.Forms.Label();
               this.groupDataFormat.SuspendLayout();
               this.groupExportFile.SuspendLayout();
               this.SuspendLayout();
               // 
               // buttonCancel
               // 
               this.buttonCancel.Location = new System.Drawing.Point(741, 378);
               this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
               this.buttonCancel.Name = "buttonCancel";
               this.buttonCancel.Size = new System.Drawing.Size(180, 55);
               this.buttonCancel.TabIndex = 3;
               this.buttonCancel.Text = "&Cancel";
               this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
               // 
               // buttonOK
               // 
               this.buttonOK.Location = new System.Drawing.Point(529, 378);
               this.buttonOK.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
               this.buttonOK.Name = "buttonOK";
               this.buttonOK.Size = new System.Drawing.Size(180, 55);
               this.buttonOK.TabIndex = 2;
               this.buttonOK.Text = "&OK";
               this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
               // 
               // groupDataFormat
               // 
               this.groupDataFormat.Controls.Add(this.radioExportXML1);
               this.groupDataFormat.Controls.Add(this.radioExportExcel);
               this.groupDataFormat.Location = new System.Drawing.Point(30, 34);
               this.groupDataFormat.Name = "groupDataFormat";
               this.groupDataFormat.Size = new System.Drawing.Size(891, 143);
               this.groupDataFormat.TabIndex = 0;
               this.groupDataFormat.TabStop = false;
               this.groupDataFormat.Text = "Format";
               // 
               // radioExportXML1
               // 
               this.radioExportXML1.AutoSize = true;
               this.radioExportXML1.Checked = true;
               this.radioExportXML1.Location = new System.Drawing.Point(47, 86);
               this.radioExportXML1.Name = "radioExportXML1";
               this.radioExportXML1.Size = new System.Drawing.Size(186, 22);
               this.radioExportXML1.TabIndex = 1;
               this.radioExportXML1.TabStop = true;
               this.radioExportXML1.Text = "SafePass XML(1.x)";
               this.radioExportXML1.UseVisualStyleBackColor = true;
               this.radioExportXML1.CheckedChanged += new System.EventHandler(this.OnExportFileTypeCheckedChanged);
               // 
               // radioExportExcel
               // 
               this.radioExportExcel.AutoSize = true;
               this.radioExportExcel.Location = new System.Drawing.Point(47, 39);
               this.radioExportExcel.Name = "radioExportExcel";
               this.radioExportExcel.Size = new System.Drawing.Size(78, 22);
               this.radioExportExcel.TabIndex = 0;
               this.radioExportExcel.Text = "Excel";
               this.radioExportExcel.UseVisualStyleBackColor = true;
               this.radioExportExcel.CheckedChanged += new System.EventHandler(this.OnExportFileTypeCheckedChanged);
               // 
               // groupExportFile
               // 
               this.groupExportFile.Controls.Add(this.buttonSelectFile);
               this.groupExportFile.Controls.Add(this.textExportFile);
               this.groupExportFile.Controls.Add(this.labelExportFile);
               this.groupExportFile.Location = new System.Drawing.Point(30, 207);
               this.groupExportFile.Margin = new System.Windows.Forms.Padding(4);
               this.groupExportFile.Name = "groupExportFile";
               this.groupExportFile.Padding = new System.Windows.Forms.Padding(4);
               this.groupExportFile.Size = new System.Drawing.Size(891, 99);
               this.groupExportFile.TabIndex = 1;
               this.groupExportFile.TabStop = false;
               this.groupExportFile.Text = "File";
               // 
               // buttonSelectFile
               // 
               this.buttonSelectFile.Location = new System.Drawing.Point(829, 39);
               this.buttonSelectFile.Margin = new System.Windows.Forms.Padding(4);
               this.buttonSelectFile.Name = "buttonSelectFile";
               this.buttonSelectFile.Size = new System.Drawing.Size(48, 32);
               this.buttonSelectFile.TabIndex = 2;
               this.buttonSelectFile.UseVisualStyleBackColor = true;
               this.buttonSelectFile.Click += new System.EventHandler(this.OnSelectFileButtonClick);
               // 
               // textExportFile
               // 
               this.textExportFile.Location = new System.Drawing.Point(142, 40);
               this.textExportFile.Margin = new System.Windows.Forms.Padding(4);
               this.textExportFile.Name = "textExportFile";
               this.textExportFile.Size = new System.Drawing.Size(679, 28);
               this.textExportFile.TabIndex = 1;
               this.textExportFile.TextChanged += new System.EventHandler(this.textExportFile_TextChanged);
               // 
               // labelExportFile
               // 
               this.labelExportFile.AutoSize = true;
               this.labelExportFile.Location = new System.Drawing.Point(18, 45);
               this.labelExportFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.labelExportFile.Name = "labelExportFile";
               this.labelExportFile.Size = new System.Drawing.Size(98, 18);
               this.labelExportFile.TabIndex = 0;
               this.labelExportFile.Text = "Export to:";
               // 
               // formExportAccount
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(956, 485);
               this.Controls.Add(this.groupExportFile);
               this.Controls.Add(this.groupDataFormat);
               this.Controls.Add(this.buttonCancel);
               this.Controls.Add(this.buttonOK);
               this.Margin = new System.Windows.Forms.Padding(4);
               this.Name = "formExportAccount";
               this.Text = "Export";
               this.groupDataFormat.ResumeLayout(false);
               this.groupDataFormat.PerformLayout();
               this.groupExportFile.ResumeLayout(false);
               this.groupExportFile.PerformLayout();
               this.ResumeLayout(false);

          }

          #endregion

          private void buttonCancel_Click(object sender, System.EventArgs args)
          {
               this.DialogResult = DialogResult.Cancel;
          }

          private void textExportFile_TextChanged(object sender, System.EventArgs args)
          {
               this.UpdateControlState();
          }

          private void OnExportFileTypeCheckedChanged(object sender, System.EventArgs args)
          {
               if ((sender is RadioButton) && ((RadioButton)sender).Checked)
               {
                    var tmpFileName = this.textExportFile.Text;
                    if (!string.IsNullOrEmpty(tmpFileName))
                    {
                         var tmpFileInfo = new System.IO.FileInfo(tmpFileName);

                         this.textExportFile.Clear();
                         var tmpLastIndex = tmpFileInfo.Name.LastIndexOf(".");
                         if (tmpLastIndex > 0)
                         {
                              string tmpNewExtension;
                              if (this.radioExportExcel.Checked)
                              {
                                   tmpNewExtension = "xlsx";
                              }
                              else
                              {
                                   tmpNewExtension = "xml";
                              }
                              this.textExportFile.Text = string.Format(@"{0}.{1}", tmpFileName.Substring(0, tmpFileName.Length - (tmpFileInfo.Name.Length - tmpLastIndex)), tmpNewExtension);
                         }
                    }
               }
          }

          private void buttonOK_Click(object sender, System.EventArgs args)
          {
               var tmpFileName = this.textExportFile.Text;
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

                    FileFormatProvider tmpExportProvider;
                    if (this.radioExportExcel.Checked)
                    {
                         tmpExportProvider = new OfficeExcel() { FileName = tmpFileInfo.FullName };
                    }
                    else
                    {
                         tmpExportProvider = new SafePassXml1x() { FileName = tmpFileInfo.FullName };
                    }

                    var tmpAccountService = new HuiruiSoft.Safe.Service.AccountService();
                    var tmpAccountModels = tmpAccountService.GetAccountInfosWithAttributes();
                    if (tmpAccountModels != null)
                    {
                         bool tmpExportResult = false;
                         if (tmpExportProvider is OfficeExcel)
                         {
                              tmpExportResult = ExportAccountHelper.ExportExcel(this.treeViewNodes, tmpAccountModels, tmpExportProvider.FileName);
                         }
                         else if (tmpExportProvider is SafePassXml1x)
                         {
                              tmpExportResult = ExportAccountHelper.ExportSafePassXml(this.treeViewNodes, tmpAccountModels, tmpExportProvider.FileName);
                         }

                         var tmpDialogTitle = tmpExportResult ? SafePassResource.ExportWindowDialogTitleSuccess : SafePassResource.ExportWindowDialogTitleFailed;
                         if (!tmpExportResult)
                         {
                              MessageBox.Show(SafePassResource.ExportWindowDialogMessageFailed, tmpDialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                         }
                         else
                         {
                              MessageBox.Show(string.Format(SafePassResource.ExportWindowDialogMessageSuccess, System.Environment.NewLine, tmpFileInfo.FullName), tmpDialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                              this.DialogResult = DialogResult.OK;
                         }
                    }
               }
          }

          private void OnSelectFileButtonClick(object sender, System.EventArgs args)
          {
               var tmpSaveFileDialog = new SaveFileDialog();
               tmpSaveFileDialog.ShowHelp = false;
               tmpSaveFileDialog.AddExtension = true;
               tmpSaveFileDialog.CreatePrompt = false;
               tmpSaveFileDialog.CheckFileExists = false;
               tmpSaveFileDialog.CheckPathExists = true;
               tmpSaveFileDialog.ValidateNames = true;
               tmpSaveFileDialog.OverwritePrompt = true;
               tmpSaveFileDialog.DereferenceLinks = true;
               tmpSaveFileDialog.RestoreDirectory = false;
               tmpSaveFileDialog.Title = SafePassResource.ExportDialogTitle;
               if (this.radioExportExcel.Checked)
               {
                    tmpSaveFileDialog.Filter = SafePassResource.ExportExcelFilter;
               }
               else
               {
                    tmpSaveFileDialog.Filter = SafePassResource.ExportXML1xFilter;
               }

               if (System.IO.Directory.Exists(this.textExportFile.Text))
               {
                    tmpSaveFileDialog.InitialDirectory = this.textExportFile.Text;
               }

               if (tmpSaveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
               {
                    this.textExportFile.Text = tmpSaveFileDialog.FileName;
                    this.UpdateControlState();
               }
          }

          private void UpdateControlState( )
          {
               this.buttonOK.Enabled = !string.IsNullOrEmpty(this.textExportFile.Text);
          }
     }
}
