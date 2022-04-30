using System.Windows.Forms;
using HuiruiSoft.Safe.Resources;
using HuiruiSoft.Safe.Configuration;

namespace HuiruiSoft.Safe
{
     public partial class formHelpAbout : System.Windows.Forms.Form
     {
          private System.ComponentModel.IContainer components = null;
          private System.Windows.Forms.Button buttonClose;
          private System.Windows.Forms.Label labelGpl;
          private System.Windows.Forms.Label labelCopyright;
          private System.Windows.Forms.Label labelHomepage;
          private System.Windows.Forms.Label labelOpensource;
          private System.Windows.Forms.Label labelLicense;
          private System.Windows.Forms.LinkLabel linkHomepage;
          private System.Windows.Forms.LinkLabel linkOpenSource;
          private System.Windows.Forms.LinkLabel linkLicense;
          private System.Windows.Forms.PictureBox pictureBoxIcon;
          private HuiruiSoft.UI.Controls.FlashBar flashBar;

          internal formHelpAbout()
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

                    this.Text = SafePassResource.AboutWindowCaption;
                    this.Icon = HuiruiSoft.Utils.WindowsUtils.DefaultAppIcon;
                    this.labelCopyright.Text = ApplicationDefines.Copyright;
                    this.labelGpl.Text = SafePassResource.AboutWindowLabelGpl;
                    this.buttonClose.Text = SafePassResource.ButtonClose;
                    this.labelLicense.Text = SafePassResource.AboutWindowLabelLicense;
                    this.labelHomepage.Text = SafePassResource.AboutWindowLabelHomepage;
                    this.labelOpensource.Text = SafePassResource.AboutWindowLabelOpensource;

                    var tmpHomepageUrl =  ApplicationDefines.HomepageUrl;
                    this.linkHomepage.Text = tmpHomepageUrl;
                    this.linkHomepage.Links.Add(0, tmpHomepageUrl.Length, tmpHomepageUrl);

                    var tmpOpenSourceUrl = ApplicationDefines.OpenSourceUrl;
                    this.linkOpenSource.Text = tmpOpenSourceUrl;
                    this.linkOpenSource.Links.Add(0, tmpOpenSourceUrl.Length, tmpOpenSourceUrl);

                    var tmpLicenseUrl =  ApplicationDefines.LicenseUrl;
                    if (string.IsNullOrEmpty(tmpLicenseUrl))
                    {
                         this.linkLicense.Text = string.Empty;
                    }
                    else
                    {
                         this.linkLicense.Text = tmpLicenseUrl;
                         this.linkLicense.Links.Add(0, tmpLicenseUrl.Length, tmpLicenseUrl);
                    }

                    this.flashBar.Title = ApplicationDefines.ProductName;
                    this.flashBar.ForeColor = System.Drawing.Color.WhiteSmoke;
                    this.flashBar.Message = string.Format("{0} {1}", SafePassResource.Version, ApplicationDefines.VersionNo);
                    this.pictureBoxIcon.Image = HuiruiSoft.Safe.Properties.Resources.LockWindow;
               }
          }

          protected override void OnClosed(System.EventArgs args)
          {
               base.OnClosed(args);
          }

          private void buttonClose_Click(object sender, System.EventArgs args)
          {
               this.Close();
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
               this.flashBar = new HuiruiSoft.UI.Controls.FlashBar();
               this.labelGpl = new System.Windows.Forms.Label();
               this.labelCopyright = new System.Windows.Forms.Label();
               this.linkLicense = new System.Windows.Forms.LinkLabel();
               this.linkHomepage = new System.Windows.Forms.LinkLabel();
               this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
               this.labelHomepage = new System.Windows.Forms.Label();
               this.labelOpensource = new System.Windows.Forms.Label();
               this.linkOpenSource = new System.Windows.Forms.LinkLabel();
               this.labelLicense = new System.Windows.Forms.Label();
               ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
               this.SuspendLayout();
               // 
               // buttonClose
               // 
               this.buttonClose.Location = new System.Drawing.Point(660, 460);
               this.buttonClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
               this.buttonClose.Name = "buttonClose";
               this.buttonClose.Size = new System.Drawing.Size(180, 55);
               this.buttonClose.TabIndex = 9;
               this.buttonClose.Text = "&Close";
               this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
               // 
               // flashBar
               // 
               this.flashBar.BackColor = System.Drawing.Color.White;
               this.flashBar.Bars = 4;
               this.flashBar.BoundarySize = 15;
               this.flashBar.Dock = System.Windows.Forms.DockStyle.Top;
               this.flashBar.EndColor = System.Drawing.SystemColors.Control;
               this.flashBar.ForeColor = System.Drawing.Color.Black;
               this.flashBar.Location = new System.Drawing.Point(0, 0);
               this.flashBar.Message = "";
               this.flashBar.MessageFontStyle = System.Drawing.FontStyle.Regular;
               this.flashBar.Name = "flashBar";
               this.flashBar.Size = new System.Drawing.Size(878, 130);
               this.flashBar.StartColor = System.Drawing.Color.RoyalBlue;
               this.flashBar.TabIndex = 0;
               this.flashBar.TextStartPosition = new System.Drawing.Point(15, 15);
               this.flashBar.Title = "";
               this.flashBar.TitleFontStyle = System.Drawing.FontStyle.Bold;
               // 
               // labelGpl
               // 
               this.labelGpl.Location = new System.Drawing.Point(157, 214);
               this.labelGpl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.labelGpl.Name = "labelGpl";
               this.labelGpl.Size = new System.Drawing.Size(700, 40);
               this.labelGpl.TabIndex = 2;
               this.labelGpl.Text = "The program is distributed under the terms of the GNU General Public License v2 o" +
    "r later.";
               this.labelGpl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
               // 
               // labelCopyright
               // 
               this.labelCopyright.Location = new System.Drawing.Point(157, 155);
               this.labelCopyright.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.labelCopyright.Name = "labelCopyright";
               this.labelCopyright.Size = new System.Drawing.Size(700, 40);
               this.labelCopyright.TabIndex = 1;
               this.labelCopyright.Text = "Copyright";
               this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
               // 
               // linkLicense
               // 
               this.linkLicense.AutoSize = true;
               this.linkLicense.Location = new System.Drawing.Point(339, 386);
               this.linkLicense.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.linkLicense.Name = "linkLicense";
               this.linkLicense.Size = new System.Drawing.Size(71, 18);
               this.linkLicense.TabIndex = 8;
               this.linkLicense.TabStop = true;
               this.linkLicense.Text = "License";
               this.linkLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLicense_LinkClicked);
               // 
               // linkHomepage
               // 
               this.linkHomepage.AutoSize = true;
               this.linkHomepage.Location = new System.Drawing.Point(339, 288);
               this.linkHomepage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.linkHomepage.Name = "linkHomepage";
               this.linkHomepage.Size = new System.Drawing.Size(80, 18);
               this.linkHomepage.TabIndex = 4;
               this.linkHomepage.TabStop = true;
               this.linkHomepage.Text = "Website:";
               this.linkHomepage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkHomepage_LinkClicked);
               // 
               // pictureBoxIcon
               // 
               this.pictureBoxIcon.Image = global::HuiruiSoft.Safe.Properties.Resources.LockWindow;
               this.pictureBoxIcon.Location = new System.Drawing.Point(12, 178);
               this.pictureBoxIcon.Name = "pictureBoxIcon";
               this.pictureBoxIcon.Size = new System.Drawing.Size(128, 128);
               this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
               this.pictureBoxIcon.TabIndex = 35;
               this.pictureBoxIcon.TabStop = false;
               // 
               // labelHomepage
               // 
               this.labelHomepage.Location = new System.Drawing.Point(160, 288);
               this.labelHomepage.Name = "labelHomepage";
               this.labelHomepage.Size = new System.Drawing.Size(164, 18);
               this.labelHomepage.TabIndex = 3;
               this.labelHomepage.Text = "Official website:";
               this.labelHomepage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
               // 
               // labelOpensource
               // 
               this.labelOpensource.Location = new System.Drawing.Point(160, 337);
               this.labelOpensource.Name = "labelOpensource";
               this.labelOpensource.Size = new System.Drawing.Size(164, 18);
               this.labelOpensource.TabIndex = 5;
               this.labelOpensource.Text = "Open source:";
               this.labelOpensource.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
               // 
               // linkOpenSource
               // 
               this.linkOpenSource.AutoSize = true;
               this.linkOpenSource.Location = new System.Drawing.Point(339, 337);
               this.linkOpenSource.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.linkOpenSource.Name = "linkOpenSource";
               this.linkOpenSource.Size = new System.Drawing.Size(80, 18);
               this.linkOpenSource.TabIndex = 6;
               this.linkOpenSource.TabStop = true;
               this.linkOpenSource.Text = "Website:";
               this.linkOpenSource.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkOpenSource_LinkClicked);
               // 
               // labelLicense
               // 
               this.labelLicense.Location = new System.Drawing.Point(160, 386);
               this.labelLicense.Name = "labelLicense";
               this.labelLicense.Size = new System.Drawing.Size(164, 18);
               this.labelLicense.TabIndex = 7;
               this.labelLicense.Text = "License:";
               this.labelLicense.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
               // 
               // formHelpAbout
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(878, 544);
               this.Controls.Add(this.labelLicense);
               this.Controls.Add(this.labelOpensource);
               this.Controls.Add(this.linkOpenSource);
               this.Controls.Add(this.labelHomepage);
               this.Controls.Add(this.pictureBoxIcon);
               this.Controls.Add(this.linkLicense);
               this.Controls.Add(this.linkHomepage);
               this.Controls.Add(this.labelGpl);
               this.Controls.Add(this.labelCopyright);
               this.Controls.Add(this.flashBar);
               this.Controls.Add(this.buttonClose);
               this.Margin = new System.Windows.Forms.Padding(4);
               this.Name = "formHelpAbout";
               this.Text = "About";
               ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion

          private void linkLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs args)
          {
               string url = string.Format("{0}", args.Link.LinkData);
               if (!string.IsNullOrEmpty(url))
               {
                    var tmpBrowserProcess = System.Diagnostics.Process.Start(url);
               }
          }

          private void linkHomepage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs args)
          {
               string url = string.Format("{0}", args.Link.LinkData);
               if (!string.IsNullOrEmpty(url))
               {
                    var tmpBrowserProcess = System.Diagnostics.Process.Start(url);
               }
          }

          private void linkOpenSource_LinkClicked(object sender, LinkLabelLinkClickedEventArgs args)
          {
               string url = string.Format("{0}", args.Link.LinkData);
               if (!string.IsNullOrEmpty(url))
               {
                    var tmpBrowserProcess = System.Diagnostics.Process.Start(url);
               }
          }
     }
}
