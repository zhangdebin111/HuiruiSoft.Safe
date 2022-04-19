
namespace HuiruiSoft.Safe
{
     partial class formAutoUpdater
     {
          /// <summary>
          /// Required designer variable.
          /// </summary>
          private System.ComponentModel.IContainer components = null;

          /// <summary>
          /// Clean up any resources being used.
          /// </summary>
          /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
          protected override void Dispose(bool disposing)
          {
               if (disposing && (components != null))
               {
                    components.Dispose();
               }
               base.Dispose(disposing);
          }

          #region Windows Form Designer generated code

          /// <summary>
          /// Required method for Designer support - do not modify
          /// the contents of this method with the code editor.
          /// </summary>
          private void InitializeComponent()
          {
               this.buttonCheckForUpdate = new System.Windows.Forms.Button();
               this.flashBar = new HuiruiSoft.UI.Controls.FlashBar();
               this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
               this.checkSkipUpdate = new System.Windows.Forms.CheckBox();
               this.webBrowser = new System.Windows.Forms.WebBrowser();
               this.buttonStartUpdate = new System.Windows.Forms.Button();
               ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
               this.SuspendLayout();
               // 
               // buttonCheckForUpdate
               // 
               this.buttonCheckForUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.buttonCheckForUpdate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.buttonCheckForUpdate.Location = new System.Drawing.Point(451, 477);
               this.buttonCheckForUpdate.Name = "buttonCheckForUpdate";
               this.buttonCheckForUpdate.Size = new System.Drawing.Size(180, 55);
               this.buttonCheckForUpdate.TabIndex = 3;
               this.buttonCheckForUpdate.Text = "Check for update";
               this.buttonCheckForUpdate.UseVisualStyleBackColor = true;
               this.buttonCheckForUpdate.Click += new System.EventHandler(this.buttonCheckForUpdate_Click);
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
               // pictureBoxIcon
               // 
               this.pictureBoxIcon.Image = global::HuiruiSoft.Safe.Properties.Resources.LockWindow;
               this.pictureBoxIcon.Location = new System.Drawing.Point(15, 150);
               this.pictureBoxIcon.Name = "pictureBoxIcon";
               this.pictureBoxIcon.Size = new System.Drawing.Size(128, 128);
               this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
               this.pictureBoxIcon.TabIndex = 36;
               this.pictureBoxIcon.TabStop = false;
               // 
               // checkSkipUpdate
               // 
               this.checkSkipUpdate.AutoSize = true;
               this.checkSkipUpdate.Location = new System.Drawing.Point(160, 487);
               this.checkSkipUpdate.Name = "checkSkipUpdate";
               this.checkSkipUpdate.Size = new System.Drawing.Size(187, 22);
               this.checkSkipUpdate.TabIndex = 2;
               this.checkSkipUpdate.Text = "Skip this version";
               this.checkSkipUpdate.UseVisualStyleBackColor = true;
               this.checkSkipUpdate.CheckedChanged += new System.EventHandler(this.checkSkipUpdate_CheckedChanged);
               // 
               // webBrowser
               // 
               this.webBrowser.Location = new System.Drawing.Point(160, 150);
               this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
               this.webBrowser.Name = "webBrowser";
               this.webBrowser.Size = new System.Drawing.Size(700, 300);
               this.webBrowser.TabIndex = 1;
               // 
               // buttonStartUpdate
               // 
               this.buttonStartUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.buttonStartUpdate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.buttonStartUpdate.Location = new System.Drawing.Point(680, 477);
               this.buttonStartUpdate.Name = "buttonStartUpdate";
               this.buttonStartUpdate.Size = new System.Drawing.Size(180, 55);
               this.buttonStartUpdate.TabIndex = 4;
               this.buttonStartUpdate.Text = "Start update";
               this.buttonStartUpdate.UseVisualStyleBackColor = true;
               this.buttonStartUpdate.Click += new System.EventHandler(this.buttonStartUpdate_Click);
               // 
               // formAutoUpdater
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(878, 544);
               this.Controls.Add(this.buttonStartUpdate);
               this.Controls.Add(this.webBrowser);
               this.Controls.Add(this.checkSkipUpdate);
               this.Controls.Add(this.pictureBoxIcon);
               this.Controls.Add(this.flashBar);
               this.Controls.Add(this.buttonCheckForUpdate);
               this.Name = "formAutoUpdater";
               this.Text = "Update";
               ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion
          
          private HuiruiSoft.UI.Controls.FlashBar flashBar;
          private System.Windows.Forms.PictureBox pictureBoxIcon;
          private System.Windows.Forms.CheckBox checkSkipUpdate;
          private System.Windows.Forms.WebBrowser webBrowser;
          private System.Windows.Forms.Button buttonStartUpdate;
          private System.Windows.Forms.Button buttonCheckForUpdate;
     }
}