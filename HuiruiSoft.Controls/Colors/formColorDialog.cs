
using System.Windows.Forms;
using HuiruiSoft.Utils;

namespace HuiruiSoft.UI.Controls
{
     public class formColorDialog : Form
     {
          private System.ComponentModel.Container components = null;
          private System.Windows.Forms.Button buttonOK;
          private System.Windows.Forms.Button buttonCancel;
          private HuiruiSoft.UI.Controls.ColorPanel colorPicker;

          public System.Drawing.Color Color
          {
               get
               {
                    return this.colorPicker.Color;
               }

               set
               {
                    this.colorPicker.Color = (value.IsEmpty ? System.Drawing.Color.Black : value);
               }
          }

          public formColorDialog()
          {
               this.InitializeComponent();

               this.MinimizeBox = false;
               this.MaximizeBox = false;
               this.ShowInTaskbar = false;
               this.DoubleBuffered = true;
               this.CancelButton = this.buttonCancel;
               this.FormBorderStyle = FormBorderStyle.FixedDialog;
          }

          protected override void OnLoad(System.EventArgs args)
          {
               base.OnLoad(args);

               if (!base.DesignMode)
               {
                    this.CancelButton = this.buttonCancel;

                    this.Text = "拾色器";
                    this.buttonOK.Text = "&OK";
                    this.buttonCancel.Text = "&Cancel";
               }
          }

          protected override void OnClosed(System.EventArgs args)
          {
               base.OnClosed(args);
          }

          protected override void Dispose(bool disposing)
          {
               if (disposing && components != null)
               {
                    this.components.Dispose();
               }

               base.Dispose(disposing);
          }

          #region Windows 窗体设计器生成的代码
          private void InitializeComponent()
          {
               this.buttonCancel = new System.Windows.Forms.Button();
               this.buttonOK = new System.Windows.Forms.Button();
               this.colorPicker = new HuiruiSoft.UI.Controls.ColorPanel();
               this.SuspendLayout();
               // 
               // buttonCancel
               // 
               this.buttonCancel.Location = new System.Drawing.Point(665, 465);
               this.buttonCancel.Name = "buttonCancel";
               this.buttonCancel.Size = new System.Drawing.Size(180, 50);
               this.buttonCancel.TabIndex = 3;
               this.buttonCancel.Text = "Cancel";
               this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
               // 
               // buttonOK
               // 
               this.buttonOK.Location = new System.Drawing.Point(440, 465);
               this.buttonOK.Name = "buttonOK";
               this.buttonOK.Size = new System.Drawing.Size(180, 50);
               this.buttonOK.TabIndex = 2;
               this.buttonOK.Text = "OK";
               this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
               // 
               // colorPicker
               // 
               this.colorPicker.AutoSize = true;
               this.colorPicker.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
               this.colorPicker.Location = new System.Drawing.Point(20, 25);
               this.colorPicker.Name = "colorPicker";
               this.colorPicker.Size = new System.Drawing.Size(643, 369);
               this.colorPicker.TabIndex = 0;
               this.colorPicker.ColorChanged += new HuiruiSoft.UI.Controls.ColorChangedEventHandler(this.OnColorPickerColorChanged);
               this.colorPicker.PanelClosing += new HuiruiSoft.UI.Controls.PanelClosingEventHandler(this.OnColorPickerPanelClosing);
               // 
               // formColorDialog
               // 
               this.AutoScaleBaseSize = new System.Drawing.Size(10, 21);
               this.ClientSize = new System.Drawing.Size(888, 544);
               this.Controls.Add(this.colorPicker);
               this.Controls.Add(this.buttonCancel);
               this.Controls.Add(this.buttonOK);
               this.Name = "formColorDialog";
               this.Text = "Color picker";
               this.ResumeLayout(false);
               this.PerformLayout();

          }
          #endregion

          private void buttonOK_Click(object sender, System.EventArgs args)
          {
               if (this.buttonOK.Enabled)
               {
                    this.DialogResult = DialogResult.OK;
               }
          }

          private void buttonCancel_Click(object sender, System.EventArgs args)
          {
               this.Close();
          }

          private void OnColorPickerPanelClosing(object sender, System.EventArgs args)
          {
               this.DialogResult = DialogResult.OK;
          }

          private void OnColorPickerColorChanged(object sender, ColorChangedEventArgs args)
          {
               if (!this.buttonOK.Enabled)
               {
                    this.buttonOK.Enabled = true;
               }
          }
     }
}