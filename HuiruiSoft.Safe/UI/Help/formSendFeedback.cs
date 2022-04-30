using System.Linq;
using System.Windows.Forms;
using HuiruiSoft.Safe.Model;
using HuiruiSoft.Safe.Resources;
using HuiruiSoft.Safe.Configuration;

namespace HuiruiSoft.Safe
{
     public partial class formSendFeedback : System.Windows.Forms.Form
     {
          private static readonly log4net.ILog loger = log4net.LogManager.GetLogger("loger");

          private System.ComponentModel.IContainer components = null;
          private System.Windows.Forms.Button buttonSubmit;
          private System.Windows.Forms.Button buttonClose;
          private System.Windows.Forms.Label labelContactWay;
          private System.Windows.Forms.Label labelCaptchaCode;
          private System.Windows.Forms.Label labelDescription;
          private System.Windows.Forms.Label labelQuestionType;
          private System.Windows.Forms.Label labelRefreshPrompt;
          private System.Windows.Forms.Label labelPromptQuestionType;
          private System.Windows.Forms.Label labelPromptDescription;
          private System.Windows.Forms.Label labelPromptContact;
          private System.Windows.Forms.TextBox textBoxContact;
          private System.Windows.Forms.TextBox textCaptchaCode;
          private System.Windows.Forms.TextBox textBoxDescription;
          private System.Windows.Forms.ComboBox listBoxContactWay;
          private System.Windows.Forms.ComboBox listBoxQuestionType;
          private System.Windows.Forms.PictureBox imageBoxCaptchaCode;

          private const string CookieName_SessionId = "JSESSIONID";

          internal formSendFeedback()
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
                    this.CancelButton = this.buttonClose;

                    this.Icon = HuiruiSoft.Utils.WindowsUtils.DefaultAppIcon;
                    this.Text = SafePassResource.SendFeedbackWindowCaption;
                    this.buttonClose.Text = SafePassResource.ButtonClose;
                    this.buttonSubmit.Text = SafePassResource.SendFeedbackWindowButtonSendFeedback;
                    this.labelQuestionType.Text = SafePassResource.SendFeedbackWindowLabelQuestionType;
                    this.labelDescription.Text = SafePassResource.SendFeedbackWindowLabelDescription;
                    this.labelCaptchaCode.Text = SafePassResource.SendFeedbackWindowLabelCaptchaCode;
                    this.labelContactWay.Text = SafePassResource.SendFeedbackWindowLabelContactWay;
                    this.labelRefreshPrompt.Text = SafePassResource.SendFeedbackWindowLabelRefreshPrompt;

                    this.imageBoxCaptchaCode.Cursor = System.Windows.Forms.Cursors.Hand;

                    this.listBoxContactWay.DropDownStyle = ComboBoxStyle.DropDownList;
                    var tmpContactWays = new System.Collections.Generic.List<ListItemContactWay>();
                    tmpContactWays.Add(new ListItemContactWay(ContactWays.QQ, SafePassResource.SendFeedbackWindowListContactWayQQ));
                    tmpContactWays.Add(new ListItemContactWay(ContactWays.Email, SafePassResource.SendFeedbackWindowListContactWayEmail));
                    tmpContactWays.Add(new ListItemContactWay(ContactWays.Mobile, SafePassResource.SendFeedbackWindowListContactWayMobile));
                    tmpContactWays.Add(new ListItemContactWay(ContactWays.WeChat, SafePassResource.SendFeedbackWindowListContactWayWeChat));
                    this.listBoxContactWay.DataSource = tmpContactWays;
                    this.listBoxContactWay.ValueMember = "ContactWay";
                    this.listBoxContactWay.DisplayMember = "Text";

                    this.listBoxQuestionType.MaxDropDownItems = 15;
                    this.listBoxQuestionType.DropDownStyle = ComboBoxStyle.DropDownList;

                    if (Program.FeedbackCache.FeedbackSubjects == null)
                    {
                         var tmpFeedbackClient = new HuiruiSoft.Safe.Net.SoftFeedbackClient();
                         var tmpDataResponse = tmpFeedbackClient.GetAppFeedbackSubjects(ApplicationDefines.AppCode);
                         if (tmpDataResponse != null && tmpDataResponse.Data != null)
                         {
                              Program.FeedbackCache.FeedbackSubjects = tmpDataResponse.Data;
                         }
                    }

                    if (Program.FeedbackCache.FeedbackSubjects != null)
                    {
                         this.listBoxQuestionType.DataSource = Program.FeedbackCache.FeedbackSubjects;
                         this.listBoxQuestionType.ValueMember = "SubjectId";
                         this.listBoxQuestionType.DisplayMember = "Subject";
                    }

                    if (Program.Config.Application.FeedbackConfig.ContactNo != null)
                    {
                         this.textBoxContact.Text = Program.Config.Application.FeedbackConfig.ContactNo;
                    }

                    var tmpDefaultContactWay = tmpContactWays.FirstOrDefault(item => (item.ContactWay == Program.Config.Application.FeedbackConfig.ContactWay));
                    if (tmpDefaultContactWay != null)
                    {
                         this.listBoxContactWay.SelectedItem = tmpDefaultContactWay;
                    }

                    this.LoadImageAuthCode();
               }
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
               this.buttonClose = new System.Windows.Forms.Button();
               this.labelQuestionType = new System.Windows.Forms.Label();
               this.listBoxQuestionType = new System.Windows.Forms.ComboBox();
               this.labelDescription = new System.Windows.Forms.Label();
               this.textBoxDescription = new System.Windows.Forms.TextBox();
               this.listBoxContactWay = new System.Windows.Forms.ComboBox();
               this.labelContactWay = new System.Windows.Forms.Label();
               this.textBoxContact = new System.Windows.Forms.TextBox();
               this.buttonSubmit = new System.Windows.Forms.Button();
               this.textCaptchaCode = new System.Windows.Forms.TextBox();
               this.labelCaptchaCode = new System.Windows.Forms.Label();
               this.imageBoxCaptchaCode = new System.Windows.Forms.PictureBox();
               this.labelRefreshPrompt = new System.Windows.Forms.Label();
               this.labelPromptQuestionType = new System.Windows.Forms.Label();
               this.labelPromptDescription = new System.Windows.Forms.Label();
               this.labelPromptContact = new System.Windows.Forms.Label();
               ((System.ComponentModel.ISupportInitialize)(this.imageBoxCaptchaCode)).BeginInit();
               this.SuspendLayout();
               // 
               // buttonClose
               // 
               this.buttonClose.Location = new System.Drawing.Point(720, 536);
               this.buttonClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
               this.buttonClose.Name = "buttonClose";
               this.buttonClose.Size = new System.Drawing.Size(180, 55);
               this.buttonClose.TabIndex = 14;
               this.buttonClose.Text = "&Close";
               this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
               // 
               // labelQuestionType
               // 
               this.labelQuestionType.Location = new System.Drawing.Point(30, 36);
               this.labelQuestionType.Name = "labelQuestionType";
               this.labelQuestionType.Size = new System.Drawing.Size(180, 36);
               this.labelQuestionType.TabIndex = 0;
               this.labelQuestionType.Text = "Question type:";
               this.labelQuestionType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
               // 
               // listBoxQuestionType
               // 
               this.listBoxQuestionType.FormattingEnabled = true;
               this.listBoxQuestionType.Location = new System.Drawing.Point(220, 41);
               this.listBoxQuestionType.Name = "listBoxQuestionType";
               this.listBoxQuestionType.Size = new System.Drawing.Size(680, 26);
               this.listBoxQuestionType.TabIndex = 1;
               this.listBoxQuestionType.SelectedIndexChanged += new System.EventHandler(this.listBoxQuestionType_SelectedIndexChanged);
               // 
               // labelDescription
               // 
               this.labelDescription.Location = new System.Drawing.Point(30, 96);
               this.labelDescription.Name = "labelDescription";
               this.labelDescription.Size = new System.Drawing.Size(180, 36);
               this.labelDescription.TabIndex = 3;
               this.labelDescription.Text = "Description:";
               this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
               // 
               // textBoxDescription
               // 
               this.textBoxDescription.Location = new System.Drawing.Point(220, 96);
               this.textBoxDescription.Multiline = true;
               this.textBoxDescription.Name = "textBoxDescription";
               this.textBoxDescription.Size = new System.Drawing.Size(680, 263);
               this.textBoxDescription.TabIndex = 4;
               this.textBoxDescription.TextChanged += new System.EventHandler(this.textBoxDescription_TextChanged);
               // 
               // listBoxContactWay
               // 
               this.listBoxContactWay.FormattingEnabled = true;
               this.listBoxContactWay.Location = new System.Drawing.Point(220, 463);
               this.listBoxContactWay.Name = "listBoxContactWay";
               this.listBoxContactWay.Size = new System.Drawing.Size(180, 26);
               this.listBoxContactWay.TabIndex = 10;
               this.listBoxContactWay.SelectedIndexChanged += new System.EventHandler(this.listBoxContact_SelectedIndexChanged);
               // 
               // labelContactWay
               // 
               this.labelContactWay.Location = new System.Drawing.Point(30, 458);
               this.labelContactWay.Name = "labelContactWay";
               this.labelContactWay.Size = new System.Drawing.Size(180, 36);
               this.labelContactWay.TabIndex = 9;
               this.labelContactWay.Text = "Contact:";
               this.labelContactWay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
               // 
               // textBoxContact
               // 
               this.textBoxContact.Location = new System.Drawing.Point(414, 462);
               this.textBoxContact.Name = "textBoxContact";
               this.textBoxContact.Size = new System.Drawing.Size(478, 28);
               this.textBoxContact.TabIndex = 11;
               this.textBoxContact.TextChanged += new System.EventHandler(this.textBoxContact_TextChanged);
               // 
               // buttonSubmit
               // 
               this.buttonSubmit.Location = new System.Drawing.Point(492, 536);
               this.buttonSubmit.Name = "buttonSubmit";
               this.buttonSubmit.Size = new System.Drawing.Size(180, 55);
               this.buttonSubmit.TabIndex = 13;
               this.buttonSubmit.Text = "Submit";
               this.buttonSubmit.UseVisualStyleBackColor = true;
               this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
               // 
               // textCaptchaCode
               // 
               this.textCaptchaCode.Location = new System.Drawing.Point(220, 400);
               this.textCaptchaCode.Name = "textCaptchaCode";
               this.textCaptchaCode.Size = new System.Drawing.Size(180, 28);
               this.textCaptchaCode.TabIndex = 7;
               this.textCaptchaCode.TextChanged += new System.EventHandler(this.textCaptchaCode_TextChanged);
               // 
               // labelCaptchaCode
               // 
               this.labelCaptchaCode.Location = new System.Drawing.Point(30, 396);
               this.labelCaptchaCode.Name = "labelCaptchaCode";
               this.labelCaptchaCode.Size = new System.Drawing.Size(180, 36);
               this.labelCaptchaCode.TabIndex = 6;
               this.labelCaptchaCode.Text = "Verification Code:";
               this.labelCaptchaCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
               // 
               // imageBoxCaptchaCode
               // 
               this.imageBoxCaptchaCode.Location = new System.Drawing.Point(405, 380);
               this.imageBoxCaptchaCode.Name = "imageBoxCaptchaCode";
               this.imageBoxCaptchaCode.Size = new System.Drawing.Size(180, 60);
               this.imageBoxCaptchaCode.TabIndex = 11;
               this.imageBoxCaptchaCode.TabStop = false;
               this.imageBoxCaptchaCode.Click += new System.EventHandler(this.imageBoxCaptchaCode_Click);
               // 
               // labelRefreshPrompt
               // 
               this.labelRefreshPrompt.Location = new System.Drawing.Point(590, 394);
               this.labelRefreshPrompt.Name = "labelRefreshPrompt";
               this.labelRefreshPrompt.Size = new System.Drawing.Size(320, 40);
               this.labelRefreshPrompt.TabIndex = 8;
               this.labelRefreshPrompt.Text = "invisibility? Please click the picture to refresh";
               this.labelRefreshPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
               // 
               // labelPromptQuestionType
               // 
               this.labelPromptQuestionType.AutoSize = true;
               this.labelPromptQuestionType.ForeColor = System.Drawing.Color.Red;
               this.labelPromptQuestionType.Location = new System.Drawing.Point(907, 45);
               this.labelPromptQuestionType.Name = "labelPromptQuestionType";
               this.labelPromptQuestionType.Size = new System.Drawing.Size(17, 18);
               this.labelPromptQuestionType.TabIndex = 2;
               this.labelPromptQuestionType.Text = "*";
               this.labelPromptQuestionType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
               // 
               // labelPromptDescription
               // 
               this.labelPromptDescription.AutoSize = true;
               this.labelPromptDescription.ForeColor = System.Drawing.Color.Red;
               this.labelPromptDescription.Location = new System.Drawing.Point(907, 96);
               this.labelPromptDescription.Name = "labelPromptDescription";
               this.labelPromptDescription.Size = new System.Drawing.Size(17, 18);
               this.labelPromptDescription.TabIndex = 5;
               this.labelPromptDescription.Text = "*";
               this.labelPromptDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
               // 
               // labelPromptContact
               // 
               this.labelPromptContact.AutoSize = true;
               this.labelPromptContact.ForeColor = System.Drawing.Color.Red;
               this.labelPromptContact.Location = new System.Drawing.Point(907, 467);
               this.labelPromptContact.Name = "labelPromptContact";
               this.labelPromptContact.Size = new System.Drawing.Size(17, 18);
               this.labelPromptContact.TabIndex = 12;
               this.labelPromptContact.Text = "*";
               this.labelPromptContact.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
               // 
               // formSendFeedback
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(978, 624);
               this.Controls.Add(this.labelPromptContact);
               this.Controls.Add(this.labelPromptDescription);
               this.Controls.Add(this.labelPromptQuestionType);
               this.Controls.Add(this.labelRefreshPrompt);
               this.Controls.Add(this.imageBoxCaptchaCode);
               this.Controls.Add(this.textCaptchaCode);
               this.Controls.Add(this.labelCaptchaCode);
               this.Controls.Add(this.buttonSubmit);
               this.Controls.Add(this.textBoxContact);
               this.Controls.Add(this.listBoxContactWay);
               this.Controls.Add(this.labelContactWay);
               this.Controls.Add(this.textBoxDescription);
               this.Controls.Add(this.labelDescription);
               this.Controls.Add(this.listBoxQuestionType);
               this.Controls.Add(this.labelQuestionType);
               this.Controls.Add(this.buttonClose);
               this.Margin = new System.Windows.Forms.Padding(4);
               this.Name = "formSendFeedback";
               this.Text = "Send feedback";
               ((System.ComponentModel.ISupportInitialize)(this.imageBoxCaptchaCode)).EndInit();
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion

          private void buttonClose_Click(object sender, System.EventArgs args)
          {
               this.Close();
          }

          private void buttonSubmit_Click(object sender, System.EventArgs args)
          {
               if (!this.CheckImageAuthCode())
               {
                    this.textCaptchaCode.Focus();
                    return;
               }

               var tmpContactWay = listBoxContactWay.SelectedItem as ListItemContactWay;
               var tmpQuestionType = listBoxQuestionType.SelectedItem as FeedbackSubject;

               var tmpSoftFeedback = new SoftFeedbackModel();
               tmpSoftFeedback.AppCode = ApplicationDefines.AppCode;
               tmpSoftFeedback.VersionNo = ApplicationDefines.VersionNo;
               tmpSoftFeedback.ContactNo = this.textBoxContact.Text.Trim();
               tmpSoftFeedback.UserClient = ClientUserAgents.Client;
               tmpSoftFeedback.Description = this.textBoxDescription.Text.Trim();
               tmpSoftFeedback.ImageAuthCode = this.textCaptchaCode.Text.Trim();

               if (tmpContactWay != null)
               {
                    tmpSoftFeedback.ContactWay = tmpContactWay.ContactWay;
               }

               if (tmpQuestionType != null)
               {
                    tmpSoftFeedback.SubjectId = tmpQuestionType.SubjectId;
               }

               Program.Config.Application.FeedbackConfig.ContactWay = tmpSoftFeedback.ContactWay;
               Program.Config.Application.FeedbackConfig.ContactNo = tmpSoftFeedback.ContactNo;

               if (Program.FeedbackCache.Cookies != null)
               {
                    foreach (var tmpCookie in Program.FeedbackCache.Cookies)
                    {
                         if (string.Equals(tmpCookie.Name, CookieName_SessionId, System.StringComparison.CurrentCultureIgnoreCase))
                         {
                              tmpSoftFeedback.SessionId = tmpCookie.Value;
                              break;
                         }
                    }
               }

               var tmpFeedbackClient = new HuiruiSoft.Safe.Net.SoftFeedbackClient();

               var tmpHttpResponse = tmpFeedbackClient.SendFeedback(tmpSoftFeedback);
               if (tmpHttpResponse != null)
               {
                    if (tmpHttpResponse.Code == 0 && tmpHttpResponse.Data)
                    {
                         MessageBox.Show(SafePassResource.SendFeedbackWindowDialogMessageSendSuccess, SafePassResource.SendFeedbackWindowDialogTitleSendSuccess, MessageBoxButtons.OK, MessageBoxIcon.Information);
                         this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                         MessageBox.Show(string.Format(SafePassResource.SendFeedbackWindowDialogMessageSendFailed, tmpHttpResponse.Message), SafePassResource.SendFeedbackWindowDialogTitleSendFailed, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
               }
          }

          private void imageBoxCaptchaCode_Click(object sender, System.EventArgs args)
          {
               this.LoadImageAuthCode();
          }

          private void LoadImageAuthCode()
          {
               this.imageBoxCaptchaCode.SizeMode = PictureBoxSizeMode.Zoom;

               var tmpFeedbackClient = new HuiruiSoft.Safe.Net.SoftFeedbackClient();
               var tmpHttpResponse = tmpFeedbackClient.GetImageAuthCode();
               if (tmpHttpResponse != null)
               {
                    if (tmpHttpResponse.Code == 0 && tmpHttpResponse.Data != null)
                    {
                         try
                         {
                              var tmpImageStream = new System.IO.MemoryStream(tmpHttpResponse.Data);
                              this.imageBoxCaptchaCode.Image = System.Drawing.Image.FromStream(tmpImageStream);
                              if (tmpHttpResponse.Cookies != null && tmpHttpResponse.Cookies.Count > 0)
                              {
                                   if (Program.FeedbackCache.Cookies != tmpHttpResponse.Cookies)
                                   {
                                        Program.FeedbackCache.Cookies = tmpHttpResponse.Cookies;
                                   }
                              }
                         }
                         catch (System.SystemException exception)
                         {
                              loger.Error(exception);
                              MessageBox.Show(SafePassResource.SendFeedbackWindowDialogRefreshFailed, SafePassResource.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                         }
                    }
               }
          }

          private bool CheckImageAuthCode()
          {
               var tmpImageCode = this.textCaptchaCode.Text.Trim();
               if (string.IsNullOrEmpty(tmpImageCode))
               {
                    MessageBox.Show(SafePassResource.SendFeedbackWindowVerificationCodeIsEmpty, SafePassResource.Info, MessageBoxButtons.OK, MessageBoxIcon.Warning);
               }
               else
               {
                    var tmpFeedbackClient = new HuiruiSoft.Safe.Net.SoftFeedbackClient();
                    var tmpHttpResponse = tmpFeedbackClient.CheckImageAuthCode(tmpImageCode);
                    if (tmpHttpResponse != null)
                    {
                         if (tmpHttpResponse.Code == 0 && tmpHttpResponse.Data)
                         {
                              return true;
                         }
                         else
                         {
                              MessageBox.Show(SafePassResource.SendFeedbackWindowVerificationCodeIncorrect, SafePassResource.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                         }
                    }
               }

               return false;
          }

          private void textBoxContact_TextChanged(object sender, System.EventArgs args)
          {
               this.UpdateControlState();
          }

          private void textCaptchaCode_TextChanged(object sender, System.EventArgs args)
          {
               this.UpdateControlState();
          }

          private void textBoxDescription_TextChanged(object sender, System.EventArgs args)
          {
               this.UpdateControlState();
          }

          private void listBoxQuestionType_SelectedIndexChanged(object sender, System.EventArgs args)
          {
               this.UpdateControlState();
          }

          private void listBoxContact_SelectedIndexChanged(object sender, System.EventArgs args)
          {
               this.UpdateControlState();
          }

          private void UpdateControlState()
          {
               var tmpSubmitEnabled = this.listBoxQuestionType.SelectedItem != null;
               if (tmpSubmitEnabled)
               {
                    tmpSubmitEnabled = this.listBoxContactWay.SelectedItem != null;
               }

               if (tmpSubmitEnabled)
               {
                    tmpSubmitEnabled = !string.IsNullOrEmpty(this.textBoxDescription.Text.Trim());
               }

               if (tmpSubmitEnabled)
               {
                    tmpSubmitEnabled = !string.IsNullOrEmpty(this.textBoxContact.Text.Trim());
               }

               if (tmpSubmitEnabled)
               {
                    tmpSubmitEnabled = !string.IsNullOrEmpty(this.textCaptchaCode.Text.Trim());
               }

               this.buttonSubmit.Enabled = tmpSubmitEnabled;
          }

          private class ListItemContactWay
          {
               public string Text
               {
                    get; set;
               }

               public ContactWays ContactWay
               {
                    get; set;
               }

               internal ListItemContactWay(ContactWays contactWay, string text)
               {
                    this.Text = text;
                    this.ContactWay = contactWay;
               }
          }
     }
}
