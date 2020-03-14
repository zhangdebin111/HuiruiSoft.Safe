
using System.Windows.Forms;
using System.ComponentModel;

namespace HuiruiSoft.UI.Controls
{
     public class ColorBoxCombo : System.Windows.Forms.UserControl
     {
          private System.Windows.Forms.TextBox textColorBox;
          private HuiruiSoft.UI.Controls.ColorPicker colorPicker;

          /// <summary>每当此控件的 Color 属性更改时发生。</summary>
          [Browsable(true), Category("数据"), Description("每当此控件的 Color 属性更改时发生。")]
          public event ColorChangedEventHandler ColorChanged;

          private System.Drawing.Color currentColor = System.Drawing.Color.Empty;

          [Browsable(false), Category("数据"), DefaultValue(typeof(System.Drawing.Color), "White"), Description("返回或设置 Color 值。")]
          public System.Drawing.Color Color
          {
               get
               {
                    return this.colorPicker.Color;
               }

               set
               {
                    if (!this.currentColor.Equals(value))
                    {
                         this.currentColor = value;
                         this.RaiseColorChangedEvent();
                    }

                    if (!this.colorPicker.Color.Equals(value))
                    {
                         this.colorPicker.Color = value;
                         this.textColorBox.Text = HuiruiSoft.Drawing.ColorTranslator.ToHtml(value);
                    }
               }
          }

          public ColorBoxCombo()
          {
               this.InitializeComponent();

               this.colorPicker.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
               this.textColorBox.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;

               this.textColorBox.Leave += new System.EventHandler(this.OnColorTextBoxLeave);
               this.textColorBox.KeyDown += new KeyEventHandler(this.OnColorTextBoxKeyDown);
               this.colorPicker.ColorChanged += new ColorChangedEventHandler(this.OnColorPickerColorChanged);
          }

          private void InitializeComponent()
          {
               this.textColorBox = new System.Windows.Forms.TextBox();
               this.colorPicker = new HuiruiSoft.UI.Controls.ColorPicker();
               this.SuspendLayout();
               // 
               // textColorBox
               // 
               this.textColorBox.Location = new System.Drawing.Point(10, 10);
               this.textColorBox.Name = "textColorBox";
               this.textColorBox.Size = new System.Drawing.Size(135, 28);
               this.textColorBox.TabIndex = 0;
               // 
               // colorPicker
               // 
               this.colorPicker.Color = System.Drawing.Color.Empty;
               this.colorPicker.Location = new System.Drawing.Point(149, 2);
               this.colorPicker.MinimumSize = new System.Drawing.Size(24, 19);
               this.colorPicker.Name = "colorPicker";
               this.colorPicker.Size = new System.Drawing.Size(60, 45);
               this.colorPicker.TabIndex = 1;
               // 
               // ColorBoxCombo
               // 
               this.Controls.Add(this.textColorBox);
               this.Controls.Add(this.colorPicker);
               this.Name = "ColorBoxCombo";
               this.Size = new System.Drawing.Size(212, 48);
               this.ResumeLayout(false);
               this.PerformLayout();
          }

          private void RaiseColorChangedEvent()
          {
               this.OnColorChanged(new ColorChangedEventArgs(this.colorPicker.Color));
          }

          protected virtual void OnColorChanged(ColorChangedEventArgs args)
          {
               this.ColorChanged?.Invoke(this, args);
          }

          protected override void OnSizeChanged(System.EventArgs args)
          {
               base.OnSizeChanged(args);
          }

          private void OnColorPickerColorChanged(object sender, ColorChangedEventArgs args)
          {
               this.Color = args.Color;
          }

          private void OnColorTextBoxLeave(object sender, System.EventArgs args)
          {
               if (this.textColorBox.Modified)
               {
                    this.ResetColor();
               }
          }

          private void OnColorTextBoxKeyDown(object sender, KeyEventArgs args)
          {
               switch (args.KeyCode)
               {
                    case System.Windows.Forms.Keys.Enter:
                         this.ResetColor();
                         break;

                    case System.Windows.Forms.Keys.Delete:
                         break;
               }
          }

          private void ResetColor()
          {
               try
               {
                    this.Color = HuiruiSoft.Drawing.ColorTranslator.FromHtml(this.textColorBox.Text);
               }
               catch
               {
                    this.textColorBox.Text = HuiruiSoft.Drawing.ColorTranslator.ToHtml(this.Color);
                    this.textColorBox.SelectAll();
               }
          }
     }
}