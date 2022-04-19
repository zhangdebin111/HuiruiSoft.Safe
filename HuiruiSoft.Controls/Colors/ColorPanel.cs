
using System.Windows.Forms;
using System.ComponentModel;

namespace HuiruiSoft.UI.Controls
{
     //[ToolboxItem(true), System.Drawing.ToolboxBitmap(typeof(HuiruiSoft.Shared.ResourceFinder), "Images.ColorPanel.bmp")]
     [DefaultProperty("Value"), DefaultEvent("ValueChanged"), Designer("HuiruiSoft.UI.Controls.Design.FixedSizeDesigner, HuiruiSoft.Design")]
     public class ColorPanel : UserControl
     {
          private System.Windows.Forms.Panel panelControls;
          private System.Windows.Forms.Panel panelColorSample;
          private System.Windows.Forms.Label labelColorHue;
          private System.Windows.Forms.Label labelColorSaturation;
          private System.Windows.Forms.Label labelColorBrightness;
          private System.Windows.Forms.Label labelColorCyan;
          private System.Windows.Forms.Label labelPromptCyan;
          private System.Windows.Forms.Label labelColorMagenta;
          private System.Windows.Forms.Label labelPromptMagenta;
          private System.Windows.Forms.Label labelColorYellow;
          private System.Windows.Forms.Label labelPromptYellow;
          private System.Windows.Forms.Label labelColorBlack;
          private System.Windows.Forms.Label labelPromptBlack;
          private System.Windows.Forms.Label labelNewColor;
          private System.Windows.Forms.Label labelOldColor;
          private System.Windows.Forms.Label labelCurrColor;
          private System.Windows.Forms.TextBox textCurrColor;
          private System.Windows.Forms.RadioButton radioColorHue;
          private System.Windows.Forms.RadioButton radioColorSaturation;
          private System.Windows.Forms.RadioButton radioColorBrightness;
          private System.Windows.Forms.RadioButton radioColorRed;
          private System.Windows.Forms.RadioButton radioColorGreen;
          private System.Windows.Forms.RadioButton radioColorBlue;
          private System.Windows.Forms.RadioButton radioLuminance;
          private System.Windows.Forms.RadioButton radioChannelA;
          private System.Windows.Forms.RadioButton radioChannelB;
          private System.Windows.Forms.NumericUpDown numericCyan;
          private System.Windows.Forms.NumericUpDown numericMagenta;
          private System.Windows.Forms.NumericUpDown numericYellow;
          private System.Windows.Forms.NumericUpDown numericBlack;
          private System.Windows.Forms.NumericUpDown numericRed;
          private System.Windows.Forms.NumericUpDown numericGreen;
          private System.Windows.Forms.NumericUpDown numericBlue;
          private System.Windows.Forms.NumericUpDown numericHue;
          private System.Windows.Forms.NumericUpDown numericBrightness;
          private System.Windows.Forms.NumericUpDown numericSaturation;
          private System.Windows.Forms.NumericUpDown numericChannelB;
          private System.Windows.Forms.NumericUpDown numericLuminance;
          private System.Windows.Forms.NumericUpDown numericChannelA;
          private HuiruiSoft.UI.Controls.ColorSlider colorSlider;
          private HuiruiSoft.UI.Controls.ColorPalette colorPicker;

          private HuiruiSoft.Drawing.HSBCOLOR hsbColor;
          private HuiruiSoft.Drawing.CMYKCOLOR cmykColor;
          private HuiruiSoft.Drawing.CIELabColor labColor;
          private System.Drawing.Color selectedColor = System.Drawing.Color.Black;

          /// <summary>返回或设置选取的颜色值。</summary>
          [Browsable(true), Category("外观"), Description("返回或设置选取的颜色值。")]
          public System.Drawing.Color Color
          {
               get
               {
                    return this.colorPicker.RGBColor;
               }

               set
               {
                    if (value != this.selectedColor)
                    {
                         this.selectedColor = value;
                         this.colorPicker.RGBColor = value;
                         this.labelOldColor.BackColor = value;
                         this.labelNewColor.BackColor = value;

                         this.RaiseColorChangedEvent();
                    }
               }
          }

          public ColorPanel()
          {
               this.InitializeComponent();
               this.DoubleBuffered = true;
          }

          protected override void OnLoad(System.EventArgs args)
          {
               base.OnLoad(args);

               this.numericRed.Minimum = 0;
               this.numericGreen.Minimum = 0;
               this.numericBlue.Minimum = 0;
               this.numericHue.Minimum = 0;
               this.numericSaturation.Minimum = 0;
               this.numericBrightness.Minimum = 0;
               this.numericLuminance.Minimum = 0;
               this.numericChannelA.Minimum = -128;
               this.numericChannelB.Minimum = -128;
               this.numericCyan.Minimum = 0;
               this.numericMagenta.Minimum = 0;
               this.numericYellow.Minimum = 0;
               this.numericBlack.Minimum = 0;
               this.numericRed.Maximum = 255;
               this.numericGreen.Maximum = 255;
               this.numericBlue.Maximum = 255;
               this.numericHue.Maximum = 360;
               this.numericSaturation.Maximum = 100;
               this.numericBrightness.Maximum = 100;
               this.numericLuminance.Maximum = 100;
               this.numericChannelA.Maximum = 127;
               this.numericChannelB.Maximum = 127;
               this.numericCyan.Maximum = 100;
               this.numericMagenta.Maximum = 100;
               this.numericYellow.Maximum = 100;
               this.numericBlack.Maximum = 100;

               this.numericCyan.Controls.RemoveAt(0);
               this.numericMagenta.Controls.RemoveAt(0);
               this.numericYellow.Controls.RemoveAt(0);
               this.numericBlack.Controls.RemoveAt(0);

               this.numericRed.Controls.RemoveAt(0);
               this.numericGreen.Controls.RemoveAt(0);
               this.numericBlue.Controls.RemoveAt(0);

               this.numericHue.Controls.RemoveAt(0);
               this.numericBrightness.Controls.RemoveAt(0);
               this.numericSaturation.Controls.RemoveAt(0);

               this.numericChannelB.Controls.RemoveAt(0);
               this.numericLuminance.Controls.RemoveAt(0);
               this.numericChannelA.Controls.RemoveAt(0);

               this.hsbColor = HuiruiSoft.Drawing.ColorTranslator.RGBToHSB(this.selectedColor);
               this.cmykColor = HuiruiSoft.Drawing.ColorTranslator.RGBToCMYK(this.selectedColor);
               this.labColor = HuiruiSoft.Drawing.ColorTranslator.RGBToCIELab(this.selectedColor);
               this.cmykColor = HuiruiSoft.Drawing.ColorTranslator.RGBToCMYK(this.selectedColor);

               this.radioColorRed.Checked = true;
               this.colorPicker.HSB = this.colorSlider.HSB = this.hsbColor;
               this.colorSlider.ZAxes = this.colorPicker.ZAxes = HuiruiSoft.Drawing.ColorCubeZAxes.Hue;
               this.UpdateControls();

               base.SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
          }

          protected override void OnLayout(LayoutEventArgs args)
          {
               base.OnLayout(args);

               if (args.AffectedControl == this.colorPicker)
               {
                    this.colorPicker.Location = new System.Drawing.Point(8, 8);

                    this.colorSlider.Size = new System.Drawing.Size(40, 268);
                    this.colorSlider.Location = new System.Drawing.Point(this.colorPicker.Right + 8, 9);

                    this.panelControls.Size = new System.Drawing.Size(215, 268);
                    this.panelControls.Location = new System.Drawing.Point(this.colorSlider.Right + 8, 5);
               }
          }

          protected override void OnEnabledChanged(System.EventArgs args)
          {
               base.OnEnabledChanged(args);
               this.colorPicker.Refresh();
          }

          protected override void Dispose(bool disposing)
          {
               base.Dispose(disposing);
          }

          /// <summary>每当此控件的"Color"属性更改时发生。</summary>
          [Browsable(true), Category("数据"), Description("每当此控件的 Color 属性更改时发生。")]
          public event ColorChangedEventHandler ColorChanged;  // 定义新事件 ColorChanged

          private void RaiseColorChangedEvent()
          {
               this.OnColorChanged(new ColorChangedEventArgs(this.colorPicker.RGBColor));
          }

          /// <summary>引发 ColorChanged 事件。</summary>
          /// <param name="args"></param>
          protected virtual void OnColorChanged(ColorChangedEventArgs args)
          {
               this.ColorChanged?.Invoke(this, args);
          }

          /// <summary>每当此控件的"PanelClosing"属性更改时发生。</summary>
          [Browsable(true), Category("行为")]
          public event PanelClosingEventHandler PanelClosing;  // 定义新事件 PanelClosing

          /// <summary>Raises the PanelClosing event.</summary>
          /// <param name="args">包含事件数据的 ColorChangedEventArgs。</param>
          protected virtual void OnPanelClosing(System.EventArgs args)
          {
               this.PanelClosing?.Invoke(this, args);
          }

          #region 组件设计器生成的代码

          private void InitializeComponent()
          {
               this.panelControls = new System.Windows.Forms.Panel();
               this.numericBlack = new System.Windows.Forms.NumericUpDown();
               this.numericYellow = new System.Windows.Forms.NumericUpDown();
               this.numericMagenta = new System.Windows.Forms.NumericUpDown();
               this.numericCyan = new System.Windows.Forms.NumericUpDown();
               this.textCurrColor = new System.Windows.Forms.TextBox();
               this.numericChannelB = new System.Windows.Forms.NumericUpDown();
               this.numericLuminance = new System.Windows.Forms.NumericUpDown();
               this.numericChannelA = new System.Windows.Forms.NumericUpDown();
               this.numericHue = new System.Windows.Forms.NumericUpDown();
               this.numericBrightness = new System.Windows.Forms.NumericUpDown();
               this.numericSaturation = new System.Windows.Forms.NumericUpDown();
               this.numericBlue = new System.Windows.Forms.NumericUpDown();
               this.numericGreen = new System.Windows.Forms.NumericUpDown();
               this.numericRed = new System.Windows.Forms.NumericUpDown();
               this.panelColorSample = new System.Windows.Forms.Panel();
               this.labelNewColor = new System.Windows.Forms.Label();
               this.labelOldColor = new System.Windows.Forms.Label();
               this.labelColorHue = new System.Windows.Forms.Label();
               this.radioColorRed = new System.Windows.Forms.RadioButton();
               this.radioColorGreen = new System.Windows.Forms.RadioButton();
               this.radioColorBlue = new System.Windows.Forms.RadioButton();
               this.radioColorBrightness = new System.Windows.Forms.RadioButton();
               this.radioColorSaturation = new System.Windows.Forms.RadioButton();
               this.radioColorHue = new System.Windows.Forms.RadioButton();
               this.labelColorSaturation = new System.Windows.Forms.Label();
               this.labelColorBrightness = new System.Windows.Forms.Label();
               this.radioLuminance = new System.Windows.Forms.RadioButton();
               this.radioChannelA = new System.Windows.Forms.RadioButton();
               this.radioChannelB = new System.Windows.Forms.RadioButton();
               this.labelColorCyan = new System.Windows.Forms.Label();
               this.labelColorMagenta = new System.Windows.Forms.Label();
               this.labelColorYellow = new System.Windows.Forms.Label();
               this.labelColorBlack = new System.Windows.Forms.Label();
               this.labelPromptCyan = new System.Windows.Forms.Label();
               this.labelPromptMagenta = new System.Windows.Forms.Label();
               this.labelPromptYellow = new System.Windows.Forms.Label();
               this.labelPromptBlack = new System.Windows.Forms.Label();
               this.labelCurrColor = new System.Windows.Forms.Label();
               this.colorSlider = new HuiruiSoft.UI.Controls.ColorSlider();
               this.colorPicker = new HuiruiSoft.UI.Controls.ColorPalette();
               this.panelControls.SuspendLayout();
               ((System.ComponentModel.ISupportInitialize)(this.numericBlack)).BeginInit();
               ((System.ComponentModel.ISupportInitialize)(this.numericYellow)).BeginInit();
               ((System.ComponentModel.ISupportInitialize)(this.numericMagenta)).BeginInit();
               ((System.ComponentModel.ISupportInitialize)(this.numericCyan)).BeginInit();
               ((System.ComponentModel.ISupportInitialize)(this.numericChannelB)).BeginInit();
               ((System.ComponentModel.ISupportInitialize)(this.numericLuminance)).BeginInit();
               ((System.ComponentModel.ISupportInitialize)(this.numericChannelA)).BeginInit();
               ((System.ComponentModel.ISupportInitialize)(this.numericHue)).BeginInit();
               ((System.ComponentModel.ISupportInitialize)(this.numericBrightness)).BeginInit();
               ((System.ComponentModel.ISupportInitialize)(this.numericSaturation)).BeginInit();
               ((System.ComponentModel.ISupportInitialize)(this.numericBlue)).BeginInit();
               ((System.ComponentModel.ISupportInitialize)(this.numericGreen)).BeginInit();
               ((System.ComponentModel.ISupportInitialize)(this.numericRed)).BeginInit();
               this.panelColorSample.SuspendLayout();
               this.SuspendLayout();
               // 
               // panelControls
               // 
               this.panelControls.Controls.Add(this.numericBlack);
               this.panelControls.Controls.Add(this.numericYellow);
               this.panelControls.Controls.Add(this.numericMagenta);
               this.panelControls.Controls.Add(this.numericCyan);
               this.panelControls.Controls.Add(this.textCurrColor);
               this.panelControls.Controls.Add(this.numericChannelB);
               this.panelControls.Controls.Add(this.numericLuminance);
               this.panelControls.Controls.Add(this.numericChannelA);
               this.panelControls.Controls.Add(this.numericHue);
               this.panelControls.Controls.Add(this.numericBrightness);
               this.panelControls.Controls.Add(this.numericSaturation);
               this.panelControls.Controls.Add(this.numericBlue);
               this.panelControls.Controls.Add(this.numericGreen);
               this.panelControls.Controls.Add(this.numericRed);
               this.panelControls.Controls.Add(this.panelColorSample);
               this.panelControls.Controls.Add(this.labelColorHue);
               this.panelControls.Controls.Add(this.radioColorRed);
               this.panelControls.Controls.Add(this.radioColorGreen);
               this.panelControls.Controls.Add(this.radioColorBlue);
               this.panelControls.Controls.Add(this.radioColorBrightness);
               this.panelControls.Controls.Add(this.radioColorSaturation);
               this.panelControls.Controls.Add(this.radioColorHue);
               this.panelControls.Controls.Add(this.labelColorSaturation);
               this.panelControls.Controls.Add(this.labelColorBrightness);
               this.panelControls.Controls.Add(this.radioLuminance);
               this.panelControls.Controls.Add(this.radioChannelA);
               this.panelControls.Controls.Add(this.radioChannelB);
               this.panelControls.Controls.Add(this.labelColorCyan);
               this.panelControls.Controls.Add(this.labelColorMagenta);
               this.panelControls.Controls.Add(this.labelColorYellow);
               this.panelControls.Controls.Add(this.labelColorBlack);
               this.panelControls.Controls.Add(this.labelPromptCyan);
               this.panelControls.Controls.Add(this.labelPromptMagenta);
               this.panelControls.Controls.Add(this.labelPromptYellow);
               this.panelControls.Controls.Add(this.labelPromptBlack);
               this.panelControls.Controls.Add(this.labelCurrColor);
               this.panelControls.Location = new System.Drawing.Point(331, 8);
               this.panelControls.Name = "panelControls";
               this.panelControls.Size = new System.Drawing.Size(306, 363);
               this.panelControls.TabIndex = 2;
               // 
               // numericBlack
               // 
               this.numericBlack.Location = new System.Drawing.Point(202, 237);
               this.numericBlack.Name = "numericBlack";
               this.numericBlack.Size = new System.Drawing.Size(63, 28);
               this.numericBlack.TabIndex = 31;
               this.numericBlack.ValueChanged += new System.EventHandler(this.OnCMYKNumericValueChanged);
               // 
               // numericYellow
               // 
               this.numericYellow.Location = new System.Drawing.Point(202, 199);
               this.numericYellow.Name = "numericYellow";
               this.numericYellow.Size = new System.Drawing.Size(63, 28);
               this.numericYellow.TabIndex = 28;
               this.numericYellow.ValueChanged += new System.EventHandler(this.OnCMYKNumericValueChanged);
               // 
               // numericMagenta
               // 
               this.numericMagenta.Location = new System.Drawing.Point(202, 161);
               this.numericMagenta.Name = "numericMagenta";
               this.numericMagenta.Size = new System.Drawing.Size(63, 28);
               this.numericMagenta.TabIndex = 25;
               this.numericMagenta.ValueChanged += new System.EventHandler(this.OnCMYKNumericValueChanged);
               // 
               // numericCyan
               // 
               this.numericCyan.Location = new System.Drawing.Point(202, 123);
               this.numericCyan.Name = "numericCyan";
               this.numericCyan.Size = new System.Drawing.Size(63, 28);
               this.numericCyan.TabIndex = 22;
               this.numericCyan.ValueChanged += new System.EventHandler(this.OnCMYKNumericValueChanged);
               // 
               // textCurrColor
               // 
               this.textCurrColor.ImeMode = System.Windows.Forms.ImeMode.Off;
               this.textCurrColor.Location = new System.Drawing.Point(168, 328);
               this.textCurrColor.Name = "textCurrColor";
               this.textCurrColor.Size = new System.Drawing.Size(106, 28);
               this.textCurrColor.TabIndex = 34;
               this.textCurrColor.TextChanged += new System.EventHandler(this.textCurrColor_TextChanged);
               this.textCurrColor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textCurrColor_KeyPress);
               // 
               // numericChannelB
               // 
               this.numericChannelB.Location = new System.Drawing.Point(202, 85);
               this.numericChannelB.Name = "numericChannelB";
               this.numericChannelB.Size = new System.Drawing.Size(63, 28);
               this.numericChannelB.TabIndex = 20;
               this.numericChannelB.ValueChanged += new System.EventHandler(this.OnLabNumericValueChanged);
               // 
               // numericLuminance
               // 
               this.numericLuminance.Location = new System.Drawing.Point(202, 9);
               this.numericLuminance.Name = "numericLuminance";
               this.numericLuminance.Size = new System.Drawing.Size(63, 28);
               this.numericLuminance.TabIndex = 14;
               this.numericLuminance.ValueChanged += new System.EventHandler(this.OnLabNumericValueChanged);
               // 
               // numericChannelA
               // 
               this.numericChannelA.Location = new System.Drawing.Point(202, 47);
               this.numericChannelA.Name = "numericChannelA";
               this.numericChannelA.Size = new System.Drawing.Size(63, 28);
               this.numericChannelA.TabIndex = 17;
               this.numericChannelA.ValueChanged += new System.EventHandler(this.OnLabNumericValueChanged);
               // 
               // numericHue
               // 
               this.numericHue.Location = new System.Drawing.Point(56, 9);
               this.numericHue.Name = "numericHue";
               this.numericHue.Size = new System.Drawing.Size(64, 28);
               this.numericHue.TabIndex = 1;
               this.numericHue.ValueChanged += new System.EventHandler(this.OnHSLNumericValueChanged);
               // 
               // numericBrightness
               // 
               this.numericBrightness.Location = new System.Drawing.Point(56, 85);
               this.numericBrightness.Name = "numericBrightness";
               this.numericBrightness.Size = new System.Drawing.Size(64, 28);
               this.numericBrightness.TabIndex = 5;
               this.numericBrightness.ValueChanged += new System.EventHandler(this.OnHSLNumericValueChanged);
               // 
               // numericSaturation
               // 
               this.numericSaturation.Location = new System.Drawing.Point(56, 47);
               this.numericSaturation.Name = "numericSaturation";
               this.numericSaturation.Size = new System.Drawing.Size(64, 28);
               this.numericSaturation.TabIndex = 3;
               this.numericSaturation.ValueChanged += new System.EventHandler(this.OnHSLNumericValueChanged);
               // 
               // numericBlue
               // 
               this.numericBlue.Location = new System.Drawing.Point(56, 199);
               this.numericBlue.Name = "numericBlue";
               this.numericBlue.Size = new System.Drawing.Size(64, 28);
               this.numericBlue.TabIndex = 11;
               this.numericBlue.ValueChanged += new System.EventHandler(this.OnRGBNumericValueChanged);
               // 
               // numericGreen
               // 
               this.numericGreen.Location = new System.Drawing.Point(56, 161);
               this.numericGreen.Name = "numericGreen";
               this.numericGreen.Size = new System.Drawing.Size(64, 28);
               this.numericGreen.TabIndex = 9;
               this.numericGreen.ValueChanged += new System.EventHandler(this.OnRGBNumericValueChanged);
               // 
               // numericRed
               // 
               this.numericRed.Location = new System.Drawing.Point(56, 123);
               this.numericRed.Name = "numericRed";
               this.numericRed.Size = new System.Drawing.Size(64, 28);
               this.numericRed.TabIndex = 7;
               this.numericRed.ValueChanged += new System.EventHandler(this.OnRGBNumericValueChanged);
               // 
               // panelColorSample
               // 
               this.panelColorSample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
               this.panelColorSample.Controls.Add(this.labelNewColor);
               this.panelColorSample.Controls.Add(this.labelOldColor);
               this.panelColorSample.Location = new System.Drawing.Point(20, 297);
               this.panelColorSample.Name = "panelColorSample";
               this.panelColorSample.Size = new System.Drawing.Size(100, 60);
               this.panelColorSample.TabIndex = 15;
               // 
               // labelNewColor
               // 
               this.labelNewColor.BackColor = System.Drawing.Color.Black;
               this.labelNewColor.Dock = System.Windows.Forms.DockStyle.Top;
               this.labelNewColor.ForeColor = System.Drawing.SystemColors.ControlText;
               this.labelNewColor.Location = new System.Drawing.Point(0, 0);
               this.labelNewColor.Name = "labelNewColor";
               this.labelNewColor.Size = new System.Drawing.Size(98, 30);
               this.labelNewColor.TabIndex = 1;
               // 
               // labelOldColor
               // 
               this.labelOldColor.BackColor = System.Drawing.Color.White;
               this.labelOldColor.Dock = System.Windows.Forms.DockStyle.Bottom;
               this.labelOldColor.Location = new System.Drawing.Point(0, 28);
               this.labelOldColor.Name = "labelOldColor";
               this.labelOldColor.Size = new System.Drawing.Size(98, 30);
               this.labelOldColor.TabIndex = 0;
               this.labelOldColor.Click += new System.EventHandler(this.labelOldColor_Click);
               // 
               // labelColorHue
               // 
               this.labelColorHue.Location = new System.Drawing.Point(125, 13);
               this.labelColorHue.Name = "labelColorHue";
               this.labelColorHue.Size = new System.Drawing.Size(15, 20);
               this.labelColorHue.TabIndex = 12;
               this.labelColorHue.Text = "°";
               // 
               // radioColorRed
               // 
               this.radioColorRed.Checked = true;
               this.radioColorRed.Location = new System.Drawing.Point(8, 127);
               this.radioColorRed.Name = "radioColorRed";
               this.radioColorRed.Size = new System.Drawing.Size(35, 20);
               this.radioColorRed.TabIndex = 6;
               this.radioColorRed.TabStop = true;
               this.radioColorRed.Text = "R";
               this.radioColorRed.CheckedChanged += new System.EventHandler(this.RadioButtons_CheckedChanged);
               // 
               // radioColorGreen
               // 
               this.radioColorGreen.Location = new System.Drawing.Point(8, 165);
               this.radioColorGreen.Name = "radioColorGreen";
               this.radioColorGreen.Size = new System.Drawing.Size(35, 20);
               this.radioColorGreen.TabIndex = 8;
               this.radioColorGreen.Text = "G";
               this.radioColorGreen.CheckedChanged += new System.EventHandler(this.RadioButtons_CheckedChanged);
               // 
               // radioColorBlue
               // 
               this.radioColorBlue.Location = new System.Drawing.Point(8, 203);
               this.radioColorBlue.Name = "radioColorBlue";
               this.radioColorBlue.Size = new System.Drawing.Size(35, 20);
               this.radioColorBlue.TabIndex = 10;
               this.radioColorBlue.Text = "B";
               this.radioColorBlue.CheckedChanged += new System.EventHandler(this.RadioButtons_CheckedChanged);
               // 
               // radioColorBrightness
               // 
               this.radioColorBrightness.Location = new System.Drawing.Point(8, 89);
               this.radioColorBrightness.Name = "radioColorBrightness";
               this.radioColorBrightness.Size = new System.Drawing.Size(35, 20);
               this.radioColorBrightness.TabIndex = 4;
               this.radioColorBrightness.Text = "B:";
               this.radioColorBrightness.CheckedChanged += new System.EventHandler(this.RadioButtons_CheckedChanged);
               // 
               // radioColorSaturation
               // 
               this.radioColorSaturation.Location = new System.Drawing.Point(8, 51);
               this.radioColorSaturation.Name = "radioColorSaturation";
               this.radioColorSaturation.Size = new System.Drawing.Size(35, 20);
               this.radioColorSaturation.TabIndex = 2;
               this.radioColorSaturation.Text = "S";
               this.radioColorSaturation.CheckedChanged += new System.EventHandler(this.RadioButtons_CheckedChanged);
               // 
               // radioColorHue
               // 
               this.radioColorHue.Location = new System.Drawing.Point(8, 13);
               this.radioColorHue.Name = "radioColorHue";
               this.radioColorHue.Size = new System.Drawing.Size(35, 20);
               this.radioColorHue.TabIndex = 0;
               this.radioColorHue.Text = "H";
               this.radioColorHue.CheckedChanged += new System.EventHandler(this.RadioButtons_CheckedChanged);
               // 
               // labelColorSaturation
               // 
               this.labelColorSaturation.Location = new System.Drawing.Point(125, 51);
               this.labelColorSaturation.Name = "labelColorSaturation";
               this.labelColorSaturation.Size = new System.Drawing.Size(15, 20);
               this.labelColorSaturation.TabIndex = 15;
               this.labelColorSaturation.Text = "%";
               // 
               // labelColorBrightness
               // 
               this.labelColorBrightness.Location = new System.Drawing.Point(125, 89);
               this.labelColorBrightness.Name = "labelColorBrightness";
               this.labelColorBrightness.Size = new System.Drawing.Size(15, 20);
               this.labelColorBrightness.TabIndex = 18;
               this.labelColorBrightness.Text = "%";
               // 
               // radioLuminance
               // 
               this.radioLuminance.Location = new System.Drawing.Point(153, 13);
               this.radioLuminance.Name = "radioLuminance";
               this.radioLuminance.Size = new System.Drawing.Size(35, 20);
               this.radioLuminance.TabIndex = 13;
               this.radioLuminance.Text = "L:";
               this.radioLuminance.CheckedChanged += new System.EventHandler(this.RadioButtons_CheckedChanged);
               // 
               // radioChannelA
               // 
               this.radioChannelA.Location = new System.Drawing.Point(153, 51);
               this.radioChannelA.Name = "radioChannelA";
               this.radioChannelA.Size = new System.Drawing.Size(35, 20);
               this.radioChannelA.TabIndex = 16;
               this.radioChannelA.Text = "a:";
               this.radioChannelA.CheckedChanged += new System.EventHandler(this.RadioButtons_CheckedChanged);
               // 
               // radioChannelB
               // 
               this.radioChannelB.Location = new System.Drawing.Point(153, 89);
               this.radioChannelB.Name = "radioChannelB";
               this.radioChannelB.Size = new System.Drawing.Size(35, 20);
               this.radioChannelB.TabIndex = 19;
               this.radioChannelB.Text = "b:";
               this.radioChannelB.CheckedChanged += new System.EventHandler(this.RadioButtons_CheckedChanged);
               // 
               // labelColorCyan
               // 
               this.labelColorCyan.Location = new System.Drawing.Point(174, 127);
               this.labelColorCyan.Name = "labelColorCyan";
               this.labelColorCyan.Size = new System.Drawing.Size(20, 20);
               this.labelColorCyan.TabIndex = 21;
               this.labelColorCyan.Text = "&C:";
               // 
               // labelColorMagenta
               // 
               this.labelColorMagenta.Location = new System.Drawing.Point(174, 165);
               this.labelColorMagenta.Name = "labelColorMagenta";
               this.labelColorMagenta.Size = new System.Drawing.Size(20, 20);
               this.labelColorMagenta.TabIndex = 24;
               this.labelColorMagenta.Text = "&M:";
               // 
               // labelColorYellow
               // 
               this.labelColorYellow.Location = new System.Drawing.Point(174, 203);
               this.labelColorYellow.Name = "labelColorYellow";
               this.labelColorYellow.Size = new System.Drawing.Size(20, 20);
               this.labelColorYellow.TabIndex = 27;
               this.labelColorYellow.Text = "&Y:";
               // 
               // labelColorBlack
               // 
               this.labelColorBlack.Location = new System.Drawing.Point(174, 241);
               this.labelColorBlack.Name = "labelColorBlack";
               this.labelColorBlack.Size = new System.Drawing.Size(20, 20);
               this.labelColorBlack.TabIndex = 30;
               this.labelColorBlack.Text = "&K:";
               // 
               // labelPromptCyan
               // 
               this.labelPromptCyan.Location = new System.Drawing.Point(273, 127);
               this.labelPromptCyan.Name = "labelPromptCyan";
               this.labelPromptCyan.Size = new System.Drawing.Size(15, 20);
               this.labelPromptCyan.TabIndex = 23;
               this.labelPromptCyan.Text = "%";
               // 
               // labelPromptMagenta
               // 
               this.labelPromptMagenta.Location = new System.Drawing.Point(273, 165);
               this.labelPromptMagenta.Name = "labelPromptMagenta";
               this.labelPromptMagenta.Size = new System.Drawing.Size(15, 20);
               this.labelPromptMagenta.TabIndex = 26;
               this.labelPromptMagenta.Text = "%";
               // 
               // labelPromptYellow
               // 
               this.labelPromptYellow.Location = new System.Drawing.Point(273, 203);
               this.labelPromptYellow.Name = "labelPromptYellow";
               this.labelPromptYellow.Size = new System.Drawing.Size(15, 20);
               this.labelPromptYellow.TabIndex = 29;
               this.labelPromptYellow.Text = "%";
               // 
               // labelPromptBlack
               // 
               this.labelPromptBlack.Location = new System.Drawing.Point(273, 241);
               this.labelPromptBlack.Name = "labelPromptBlack";
               this.labelPromptBlack.Size = new System.Drawing.Size(15, 20);
               this.labelPromptBlack.TabIndex = 32;
               this.labelPromptBlack.Text = "%";
               // 
               // labelCurrColor
               // 
               this.labelCurrColor.Location = new System.Drawing.Point(152, 333);
               this.labelCurrColor.Name = "labelCurrColor";
               this.labelCurrColor.Size = new System.Drawing.Size(15, 20);
               this.labelCurrColor.TabIndex = 33;
               this.labelCurrColor.Text = "#";
               // 
               // colorSlider
               // 
               this.colorSlider.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
               this.colorSlider.Location = new System.Drawing.Point(282, 8);
               this.colorSlider.Name = "colorSlider";
               this.colorSlider.Size = new System.Drawing.Size(36, 266);
               this.colorSlider.TabIndex = 1;
               this.colorSlider.ZAxes = HuiruiSoft.Drawing.ColorCubeZAxes.Hue;
               this.colorSlider.ColorChanged += new System.EventHandler(this.colorSlider_ColorChanged);
               // 
               // colorPicker
               // 
               this.colorPicker.Cursor = System.Windows.Forms.Cursors.Cross;
               this.colorPicker.Location = new System.Drawing.Point(8, 8);
               this.colorPicker.Name = "colorPicker";
               this.colorPicker.RGBColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
               this.colorPicker.Size = new System.Drawing.Size(260, 260);
               this.colorPicker.TabIndex = 0;
               this.colorPicker.ZAxes = HuiruiSoft.Drawing.ColorCubeZAxes.Hue;
               this.colorPicker.ColorChanged += new System.EventHandler(this.colorPicker_ColorChanged);
               // 
               // ColorPanel
               // 
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
               this.AutoSize = true;
               this.Controls.Add(this.colorSlider);
               this.Controls.Add(this.panelControls);
               this.Controls.Add(this.colorPicker);
               this.Name = "ColorPanel";
               this.Size = new System.Drawing.Size(650, 380);
               this.panelControls.ResumeLayout(false);
               this.panelControls.PerformLayout();
               ((System.ComponentModel.ISupportInitialize)(this.numericBlack)).EndInit();
               ((System.ComponentModel.ISupportInitialize)(this.numericYellow)).EndInit();
               ((System.ComponentModel.ISupportInitialize)(this.numericMagenta)).EndInit();
               ((System.ComponentModel.ISupportInitialize)(this.numericCyan)).EndInit();
               ((System.ComponentModel.ISupportInitialize)(this.numericChannelB)).EndInit();
               ((System.ComponentModel.ISupportInitialize)(this.numericLuminance)).EndInit();
               ((System.ComponentModel.ISupportInitialize)(this.numericChannelA)).EndInit();
               ((System.ComponentModel.ISupportInitialize)(this.numericHue)).EndInit();
               ((System.ComponentModel.ISupportInitialize)(this.numericBrightness)).EndInit();
               ((System.ComponentModel.ISupportInitialize)(this.numericSaturation)).EndInit();
               ((System.ComponentModel.ISupportInitialize)(this.numericBlue)).EndInit();
               ((System.ComponentModel.ISupportInitialize)(this.numericGreen)).EndInit();
               ((System.ComponentModel.ISupportInitialize)(this.numericRed)).EndInit();
               this.panelColorSample.ResumeLayout(false);
               this.ResumeLayout(false);

          }
          #endregion

          private void RadioButtons_CheckedChanged(object sender, System.EventArgs args)
          {
               var tmpRadioButton = sender as System.Windows.Forms.RadioButton;
               if (tmpRadioButton != null && tmpRadioButton.Checked)
               {
                    if (tmpRadioButton == this.radioColorRed)
                    {
                         this.colorSlider.ZAxes = this.colorPicker.ZAxes = HuiruiSoft.Drawing.ColorCubeZAxes.Red;
                    }
                    else if (tmpRadioButton == this.radioColorGreen)
                    {
                         this.colorSlider.ZAxes = this.colorPicker.ZAxes = HuiruiSoft.Drawing.ColorCubeZAxes.Green;
                    }
                    else if (tmpRadioButton == this.radioColorBlue)
                    {
                         this.colorSlider.ZAxes = this.colorPicker.ZAxes = HuiruiSoft.Drawing.ColorCubeZAxes.Blue;
                    }
                    else if (tmpRadioButton == this.radioColorHue)
                    {
                         this.colorSlider.ZAxes = this.colorPicker.ZAxes = HuiruiSoft.Drawing.ColorCubeZAxes.Hue;
                    }
                    else if (tmpRadioButton == this.radioColorSaturation)
                    {
                         this.colorSlider.ZAxes = this.colorPicker.ZAxes = HuiruiSoft.Drawing.ColorCubeZAxes.Saturation;
                    }
                    else if (tmpRadioButton == this.radioColorBrightness)
                    {
                         this.colorSlider.ZAxes = this.colorPicker.ZAxes = HuiruiSoft.Drawing.ColorCubeZAxes.Brightness;
                    }
                    else if (tmpRadioButton == this.radioLuminance)
                    {
                         this.colorSlider.ZAxes = this.colorPicker.ZAxes = HuiruiSoft.Drawing.ColorCubeZAxes.Luminance;
                    }
                    else if (tmpRadioButton == this.radioChannelA)
                    {
                         this.colorSlider.ZAxes = this.colorPicker.ZAxes = HuiruiSoft.Drawing.ColorCubeZAxes.A;
                    }
                    else if (tmpRadioButton == this.radioChannelB)
                    {
                         this.colorSlider.ZAxes = this.colorPicker.ZAxes = HuiruiSoft.Drawing.ColorCubeZAxes.B;
                    }
               }
          }

          private void textCurrColor_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs args)
          {
               if ((int)args.KeyChar != 8)
               {
                    string tmpValidString = "0123456789ABCDEF#";
                    if (tmpValidString.IndexOf(args.KeyChar.ToString().ToUpper()) < 0)
                    {
                         args.Handled = true;
                    }
               }
          }

          private void textCurrColor_TextChanged(object sender, System.EventArgs args)
          {
               //
          }

          private void labelOldColor_Click(object sender, System.EventArgs args)
          {
               this.selectedColor = this.labelOldColor.BackColor;
               this.colorPicker.HSB = this.colorSlider.HSB = this.hsbColor = HuiruiSoft.Drawing.ColorTranslator.RGBToHSB(this.selectedColor);
               this.colorSlider.CIELab = this.colorPicker.CIELab = this.labColor = HuiruiSoft.Drawing.ColorTranslator.RGBToCIELab(this.selectedColor);
               this.cmykColor = HuiruiSoft.Drawing.ColorTranslator.RGBToCMYK(this.selectedColor);

               this.UpdateControls();
          }


          private void OnRGBNumericValueChanged(object sender, System.EventArgs args)
          {
               if (this.updateEnabled)
               {
                    var tmpNumericBox = sender as System.Windows.Forms.NumericUpDown;
                    if (tmpNumericBox != null)
                    {
                         if (sender == this.numericRed)
                         {
                              int tmpColorR = System.Convert.ToInt32(this.numericRed.Value);

                              if (tmpColorR < 0 || tmpColorR > 255)
                              {
                                   if (tmpColorR < 0) tmpColorR = 0;
                                   if (tmpColorR > 255) tmpColorR = 255;
                              }
                              this.selectedColor = System.Drawing.Color.FromArgb(tmpColorR, this.selectedColor.G, this.selectedColor.B);
                         }
                         else if (sender == this.numericGreen)
                         {
                              int tmpColorG = System.Convert.ToInt32(this.numericGreen.Value);

                              if (tmpColorG < 0 || tmpColorG > 255)
                              {
                                   if (tmpColorG < 0) tmpColorG = 0;
                                   if (tmpColorG > 255) tmpColorG = 255;
                              }
                              this.selectedColor = System.Drawing.Color.FromArgb(this.selectedColor.R, tmpColorG, this.selectedColor.B);
                         }
                         else if (sender == this.numericBlue)
                         {
                              int tmpColorB = System.Convert.ToInt32(this.numericBlue.Value);

                              if (tmpColorB < 0 || tmpColorB > 255)
                              {
                                   if (tmpColorB < 0) tmpColorB = 0;
                                   if (tmpColorB > 255) tmpColorB = 255;
                              }
                              this.selectedColor = System.Drawing.Color.FromArgb(this.selectedColor.R, this.selectedColor.G, tmpColorB);
                         }

                         this.colorSlider.HSB = this.colorPicker.HSB = this.hsbColor = HuiruiSoft.Drawing.ColorTranslator.RGBToHSB(this.selectedColor);
                         this.colorSlider.CIELab = this.colorPicker.CIELab = this.labColor = HuiruiSoft.Drawing.ColorTranslator.RGBToCIELab(this.selectedColor);
                         this.cmykColor = HuiruiSoft.Drawing.ColorTranslator.RGBToCMYK(this.selectedColor);

                         this.UpdateControls();
                    }
               }
          }

          private void OnHSLNumericValueChanged(object sender, System.EventArgs args)
          {
               if (this.updateEnabled)
               {
                    var tmpNumericBox = sender as System.Windows.Forms.NumericUpDown;
                    if (tmpNumericBox != null)
                    {
                         if (sender == this.numericHue)
                         {
                              int tmpHslColorH = System.Convert.ToInt32(this.numericHue.Value);

                              if (tmpHslColorH < 0 || tmpHslColorH > 360)
                              {
                                   if (tmpHslColorH < 0) tmpHslColorH = 0;
                                   if (tmpHslColorH > 360) tmpHslColorH = 360;
                              }
                              this.hsbColor.Hue = (double)tmpHslColorH / 360;
                         }
                         else if (sender == this.numericSaturation)
                         {
                              int tmpHslColorS = System.Convert.ToInt32(this.numericSaturation.Value);

                              if (tmpHslColorS < 0 || tmpHslColorS > 100)
                              {
                                   if (tmpHslColorS < 0) tmpHslColorS = 0;
                                   if (tmpHslColorS > 100) tmpHslColorS = 100;
                              }
                              this.hsbColor.Saturation = (double)tmpHslColorS / 100;
                         }
                         else if (sender == this.numericBrightness)
                         {
                              int tmpHslColorL = System.Convert.ToInt32(this.numericBrightness.Value);

                              if (tmpHslColorL < 0 || tmpHslColorL > 100)
                              {
                                   if (tmpHslColorL < 0) tmpHslColorL = 0;
                                   if (tmpHslColorL > 100) tmpHslColorL = 100;
                              }
                              this.hsbColor.Brightness = (double)tmpHslColorL / 100;
                         }

                         this.selectedColor = HuiruiSoft.Drawing.ColorTranslator.HSBToRGB(this.hsbColor);
                         this.cmykColor = HuiruiSoft.Drawing.ColorTranslator.RGBToCMYK(this.selectedColor);
                         this.colorSlider.HSB = this.colorPicker.HSB = this.hsbColor;
                         this.colorSlider.CIELab = this.colorPicker.CIELab = this.labColor = HuiruiSoft.Drawing.ColorTranslator.RGBToCIELab(this.selectedColor);

                         this.UpdateControls();
                    }
               }
          }

          private void OnLabNumericValueChanged(object sender, System.EventArgs args)
          {
               if (this.updateEnabled)
               {
                    var tmpNumericBox = sender as System.Windows.Forms.NumericUpDown;
                    if (tmpNumericBox != null)
                    {
                         if (sender == this.numericLuminance)
                         {
                              int tmpLabColorL = System.Convert.ToInt32(this.numericLuminance.Value);

                              if (tmpLabColorL < 0 || tmpLabColorL > 100)
                              {
                                   if (tmpLabColorL < 0) tmpLabColorL = 0;
                                   if (tmpLabColorL > 100) tmpLabColorL = 100;
                              }
                              this.labColor.L = tmpLabColorL;
                         }
                         else if (sender == this.numericChannelA)
                         {
                              int tmpLabColorA = System.Convert.ToInt32(this.numericChannelA.Value);

                              if (tmpLabColorA < -128 || tmpLabColorA > +127)
                              {
                                   if (tmpLabColorA < -128) tmpLabColorA = -128;
                                   if (tmpLabColorA > +127) tmpLabColorA = +127;
                              }
                              this.labColor.A = tmpLabColorA;
                         }
                         else if (sender == this.numericChannelB)
                         {
                              int tmpLabColorB = System.Convert.ToInt32(this.numericChannelB.Value);

                              if (tmpLabColorB < -128 || tmpLabColorB > +127)
                              {
                                   if (tmpLabColorB < -128) tmpLabColorB = -128;
                                   if (tmpLabColorB > +127) tmpLabColorB = +127;
                              }
                              this.labColor.B = tmpLabColorB;
                         }

                         this.selectedColor = HuiruiSoft.Drawing.ColorTranslator.CIELabToColor(this.labColor);
                         this.cmykColor = HuiruiSoft.Drawing.ColorTranslator.RGBToCMYK(this.selectedColor);
                         this.colorSlider.HSB = this.colorPicker.HSB = this.hsbColor = HuiruiSoft.Drawing.ColorTranslator.RGBToHSB(this.selectedColor);
                         this.colorSlider.CIELab = this.colorPicker.CIELab = this.labColor;

                         this.UpdateControls();
                    }
               }
          }

          private void OnCMYKNumericValueChanged(object sender, System.EventArgs args)
          {
               if (this.updateEnabled)
               {
                    var tmpNumericBox = sender as System.Windows.Forms.NumericUpDown;
                    if (tmpNumericBox != null)
                    {
                         if (sender == this.numericCyan)
                         {
                              int tmpCMYKColorC = System.Convert.ToInt32(this.numericCyan.Value);

                              if (tmpCMYKColorC < 0 || tmpCMYKColorC > 100)
                              {
                                   if (tmpCMYKColorC < 0) tmpCMYKColorC = 0;
                                   if (tmpCMYKColorC > 100) tmpCMYKColorC = 100;
                              }
                              this.cmykColor.Cyan = (double)tmpCMYKColorC / 100;

                         }
                         else if (sender == this.numericMagenta)
                         {
                              int tmpCMYKColorM = System.Convert.ToInt32(this.numericMagenta.Value);

                              if (tmpCMYKColorM < 0 || tmpCMYKColorM > 100)
                              {
                                   if (tmpCMYKColorM < 0) tmpCMYKColorM = 0;
                                   if (tmpCMYKColorM > 100) tmpCMYKColorM = 100;
                              }
                              this.cmykColor.Magenta = (double)tmpCMYKColorM / 100;

                         }
                         else if (sender == this.numericYellow)
                         {
                              int tmpCMYKColorY = System.Convert.ToInt32(this.numericYellow.Value);

                              if (tmpCMYKColorY < 0 || tmpCMYKColorY > 100)
                              {
                                   if (tmpCMYKColorY < 0) tmpCMYKColorY = 0;
                                   if (tmpCMYKColorY > 100) tmpCMYKColorY = 100;
                              }
                              this.cmykColor.Yellow = (double)tmpCMYKColorY / 100;

                         }
                         else if (sender == this.numericBlack)
                         {
                              int tmpCMYKColorK = System.Convert.ToInt32(this.numericBlack.Value);

                              if (tmpCMYKColorK < 0 || tmpCMYKColorK > 100)
                              {
                                   if (tmpCMYKColorK < 0) tmpCMYKColorK = 0;
                                   if (tmpCMYKColorK > 100) tmpCMYKColorK = 100;
                              }
                              this.cmykColor.Black = (double)tmpCMYKColorK / 100;

                         }

                         this.selectedColor = HuiruiSoft.Drawing.ColorTranslator.CMYKToRGB(this.cmykColor);
                         this.hsbColor = HuiruiSoft.Drawing.ColorTranslator.RGBToHSB(this.selectedColor);
                         this.colorSlider.HSB = this.colorPicker.HSB = this.hsbColor;
                         this.colorSlider.CIELab = this.colorPicker.CIELab = this.labColor = HuiruiSoft.Drawing.ColorTranslator.RGBToCIELab(this.selectedColor);

                         this.UpdateControls();
                    }
               }
          }

          private void colorSlider_ColorChanged(object sender, System.EventArgs args)
          {
               switch (this.colorPicker.ZAxes)
               {
                    case HuiruiSoft.Drawing.ColorCubeZAxes.Red:
                    case HuiruiSoft.Drawing.ColorCubeZAxes.Green:
                    case HuiruiSoft.Drawing.ColorCubeZAxes.Blue:
                         this.selectedColor = this.colorSlider.Color;
                         this.colorPicker.HSB = this.hsbColor = HuiruiSoft.Drawing.ColorTranslator.RGBToHSB(this.selectedColor);
                         this.labColor = HuiruiSoft.Drawing.ColorTranslator.RGBToCIELab(this.selectedColor);
                         break;

                    case HuiruiSoft.Drawing.ColorCubeZAxes.Hue:
                    case HuiruiSoft.Drawing.ColorCubeZAxes.Saturation:
                    case HuiruiSoft.Drawing.ColorCubeZAxes.Brightness:
                         this.colorPicker.HSB = this.hsbColor = this.colorSlider.HSB;
                         this.selectedColor = HuiruiSoft.Drawing.ColorTranslator.HSBToRGB(this.hsbColor);
                         this.labColor = HuiruiSoft.Drawing.ColorTranslator.RGBToCIELab(this.selectedColor);
                         break;

                    case HuiruiSoft.Drawing.ColorCubeZAxes.Luminance:
                    case HuiruiSoft.Drawing.ColorCubeZAxes.A:
                    case HuiruiSoft.Drawing.ColorCubeZAxes.B:
                         this.labColor = this.colorPicker.CIELab = this.colorSlider.CIELab;
                         this.selectedColor = HuiruiSoft.Drawing.ColorTranslator.CIELabToColor(this.labColor);
                         this.hsbColor = HuiruiSoft.Drawing.ColorTranslator.RGBToHSB(this.selectedColor);
                         break;
               }

               this.UpdateControls();
          }

          private void colorPicker_ColorChanged(object sender, System.EventArgs args)
          {
               switch (this.colorPicker.ZAxes)
               {
                    case HuiruiSoft.Drawing.ColorCubeZAxes.Red:
                    case HuiruiSoft.Drawing.ColorCubeZAxes.Green:
                    case HuiruiSoft.Drawing.ColorCubeZAxes.Blue:
                         this.selectedColor = this.colorPicker.RGBColor;
                         this.colorSlider.HSB = this.hsbColor = HuiruiSoft.Drawing.ColorTranslator.RGBToHSB(this.selectedColor);
                         this.labColor = HuiruiSoft.Drawing.ColorTranslator.RGBToCIELab(this.selectedColor);
                         this.cmykColor = HuiruiSoft.Drawing.ColorTranslator.RGBToCMYK(this.selectedColor);
                         break;

                    case HuiruiSoft.Drawing.ColorCubeZAxes.Hue:
                    case HuiruiSoft.Drawing.ColorCubeZAxes.Saturation:
                    case HuiruiSoft.Drawing.ColorCubeZAxes.Brightness:
                         this.colorSlider.HSB = this.hsbColor = this.colorPicker.HSB;
                         this.selectedColor = HuiruiSoft.Drawing.ColorTranslator.HSBToRGB(this.hsbColor);
                         this.labColor = HuiruiSoft.Drawing.ColorTranslator.RGBToCIELab(this.selectedColor);
                         this.cmykColor = HuiruiSoft.Drawing.ColorTranslator.RGBToCMYK(this.selectedColor);
                         break;

                    case HuiruiSoft.Drawing.ColorCubeZAxes.Luminance:
                    case HuiruiSoft.Drawing.ColorCubeZAxes.A:
                    case HuiruiSoft.Drawing.ColorCubeZAxes.B:
                         this.colorSlider.CIELab = this.labColor = this.colorPicker.CIELab;
                         this.selectedColor = HuiruiSoft.Drawing.ColorTranslator.CIELabToColor(this.labColor);
                         this.hsbColor = HuiruiSoft.Drawing.ColorTranslator.RGBToHSB(this.selectedColor);
                         this.cmykColor = HuiruiSoft.Drawing.ColorTranslator.RGBToCMYK(this.selectedColor);
                         break;
               }

               this.UpdateControls();
          }

          private bool updateEnabled = true;

          public void UpdateControls()
          {
               if (this.updateEnabled)
               {
                    this.updateEnabled = false;

                    this.numericRed.Value = this.selectedColor.R;
                    this.numericGreen.Value = this.selectedColor.G;
                    this.numericBlue.Value = this.selectedColor.B;

                    this.numericHue.Value = this.Round(this.hsbColor.Hue * 360);
                    this.numericSaturation.Value = this.Round(this.hsbColor.Saturation * 100);
                    this.numericBrightness.Value = this.Round(this.hsbColor.Brightness * 100);

                    this.numericLuminance.Value = this.labColor.L;
                    this.numericChannelA.Value = this.labColor.A;
                    this.numericChannelB.Value = this.labColor.B;

                    this.numericCyan.Value = this.Round(this.cmykColor.Cyan * 100);
                    this.numericMagenta.Value = this.Round(this.cmykColor.Magenta * 100);
                    this.numericYellow.Value = this.Round(this.cmykColor.Yellow * 100);
                    this.numericBlack.Value = this.Round(this.cmykColor.Black * 100);

                    this.numericRed.Refresh();
                    this.numericGreen.Refresh();
                    this.numericBlue.Refresh();
                    this.numericHue.Refresh();
                    this.numericSaturation.Refresh();
                    this.numericBrightness.Refresh();
                    this.numericLuminance.Refresh();
                    this.numericChannelA.Refresh();
                    this.numericChannelB.Refresh();
                    this.numericCyan.Refresh();
                    this.numericMagenta.Refresh();
                    this.numericYellow.Refresh();
                    this.numericBlack.Refresh();

                    this.updateEnabled = true;

                    this.labelNewColor.BackColor = this.selectedColor;

                    string tmpHtmlColor = HuiruiSoft.Drawing.ColorTranslator.ToHtml(this.selectedColor);
                    if (tmpHtmlColor != null && tmpHtmlColor.StartsWith("#"))
                    {
                         tmpHtmlColor = tmpHtmlColor.Remove(0, 1);
                    }
                    this.textCurrColor.Text = tmpHtmlColor;
               }
          }

          private int Round(double pOrigValue)
          {
               int tmpRoundValue = (int)pOrigValue;

               if (((int)(pOrigValue * 100) % 100) >= 50)
               {
                    tmpRoundValue += 1;
               }

               return tmpRoundValue;
          }
     }


     /// <summary></summary>
     /// <param name="sender"></param>
     /// <param name="args"></param>
     public delegate void PanelClosingEventHandler(object sender, System.EventArgs args);

     public delegate void ColorChangedEventHandler(object sender, ColorChangedEventArgs args);

     public class ColorChangedEventArgs : System.EventArgs
     {
          public System.Drawing.Color Color
          {
               get; set;
          }

          public ColorChangedEventArgs(System.Drawing.Color selectColor)
          {
               this.Color = selectColor;
          }

          public override string ToString()
          {
               return this.Color.ToString();
          }
     }
}