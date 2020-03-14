using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace HuiruiSoft.UI.Controls
{
     //[ToolboxItem(false)]
     public class FlashBar : System.Windows.Forms.UserControl
     {
          private System.ComponentModel.IContainer components = null;
          private System.Windows.Forms.Timer timerSplash;
          private HuiruiSoft.UI.Controls.GradientBand lineSplitter;

          public static readonly int DEFAULT_BOUNDRYSIZE = 15;

          private int splashBars = 4;
          private int boundarySize = DEFAULT_BOUNDRYSIZE;

          private bool showFlashBars = false;
          private string flashBarTitle = string.Empty;
          private string messageString = string.Empty;

          private System.Drawing.Point textStartPoint = new Point(DEFAULT_BOUNDRYSIZE, DEFAULT_BOUNDRYSIZE);
          private System.Drawing.Color startColor = System.Drawing.Color.FromKnownColor(KnownColor.Control);
          private System.Drawing.Color endColor   = System.Drawing.Color.FromKnownColor(KnownColor.Control);
          private System.Drawing.Font titleFont;
          private System.Drawing.Font messageFont;
          private System.Drawing.Icon iconObject = null;
          private System.Drawing.Image imageObject = null;

          private System.Drawing.FontStyle titleFontStyle = FontStyle.Bold;
          private System.Drawing.FontStyle messageFontStyle = FontStyle.Regular;

          /// <summary>返回或设置运动的频率。</summary>
          [Browsable(true), Category("行为"), DefaultValue(200), Description("返回或设置运动的频率。")]
          public int Speed
          {
               get { return this.timerSplash.Interval; }

               set
               {
                    if (this.timerSplash.Interval != value)
                    {
                         if (value >= 100 && value <= 5000)
                         {
                              this.timerSplash.Interval = value;
                         }
                    }
               }
          }

          /// <summary>返回或设置运动条是否处于运动状态。</summary>
          [Browsable(true), Category("行为"), DefaultValue(false), Description("返回或设置运动条是否处于运动状态。")]
          public bool Active
          {
               get { return this.timerSplash.Enabled; }

               set
               {
                    if (this.showFlashBars)
                    {
                         if (this.timerSplash.Enabled != value)
                         {
                              this.timerSplash.Enabled = value;
                         }
                    }
                    else
                    {
                         this.timerSplash.Enabled = false;
                    }
                    base.Invalidate();
               }
          }

          /// <summary>返回或设置是否显示运动条。</summary>
          [Browsable(true), Category("行为"), DefaultValue(false), Description("返回或设置是否显示运动条。")]
          public bool ShowBars
          {
               get { return showFlashBars; }

               set
               {
                    if (this.showFlashBars != value)
                    {
                         this.showFlashBars = value;
                         if (!value && this.timerSplash.Enabled)
                         {
                              this.timerSplash.Enabled = false;
                         }
                         base.Invalidate();
                    }
               }
          }

          /// <summary>返回或设置运动条的个数。</summary>
          [Browsable(true), Category("外观"), DefaultValue(3), Description("返回或设置运动条的个数。")]
          public int Bars
          {
               get { return splashBars; }

               set
               {
                    if (this.splashBars != value)
                    {
                         if (value >= 0 && value <= 1000)
                         {
                              this.splashBars = value;
                              base.Invalidate();
                         }
                    }
               }
          }

          public System.Drawing.Color StartColor
          {
               get { return startColor; }

               set
               {
                    if (this.startColor != value)
                    {
                         this.startColor = value;
                         base.Invalidate();
                    }
               }
          }

          public System.Drawing.Color EndColor
          {
               get { return endColor; }

               set
               {
                    if (this.endColor != value)
                    {
                         this.endColor = value;
                         base.Invalidate();
                    }
               }
          }

          [Browsable(true), Category("外观")]
          public string Message
          {
               get { return messageString; }

               set
               {
                    if (this.messageString != value)
                    {
                         this.messageString = value;
                         base.Invalidate();
                    }
               }
          }

          [Browsable(true), Category("外观")]
          public string Title
          {
               get { return flashBarTitle; }

               set
               {
                    if (this.flashBarTitle != value)
                    {
                         flashBarTitle = value;
                         base.Invalidate();
                    }
               }
          }

          [Browsable(true), Category("外观"), DefaultValue(null)]
          public System.Drawing.Icon Icon
          {
               get { return this.iconObject; }

               set
               {
                    if (this.iconObject != value)
                    {
                         this.iconObject = value;
                         base.Invalidate();
                    }
               }
          }

          [Browsable(true), Category("外观"), DefaultValue(null)]
          public System.Drawing.Image Image
          {
               get { return this.imageObject; }

               set
               {
                    if (this.imageObject != value)
                    {
                         this.imageObject = value;
                         base.Invalidate();
                    }
               }
          }

          [Browsable(true), Category("外观")]
          public System.Drawing.FontStyle TitleFontStyle
          {
               get { return this.titleFontStyle; }

               set
               {
                    if (this.titleFontStyle != value)
                    {
                         this.titleFontStyle = value;
                         this.CreateTitleFont();
                         base.Invalidate();
                    }
               }
          }

          [Browsable(true), Category("外观")]
          public System.Drawing.FontStyle MessageFontStyle
          {
               get { return this.messageFontStyle; }

               set
               {
                    if (this.messageFontStyle != value)
                    {
                         this.messageFontStyle = value;
                         this.CreateMessageFont();
                         base.Invalidate();
                    }
               }
          }

          [Browsable(true), Category("外观")]
          public int BoundarySize
          {
               get { return boundarySize; }

               set
               {
                    if (this.boundarySize != value)
                    {
                         this.boundarySize = value;
                         base.Invalidate();
                    }
               }
          }

          [Browsable(true), Category("外观")]
          public System.Drawing.Point TextStartPosition
          {
               get { return textStartPoint; }

               set
               {
                    if (this.textStartPoint != value)
                    {
                         textStartPoint = value;
                         base.Invalidate();
                    }
               }
          }

          public FlashBar()
          {
               this.InitializeComponent();

               base.SetStyle(
                    System.Windows.Forms.ControlStyles.Opaque |
                    System.Windows.Forms.ControlStyles.UserPaint |
                    System.Windows.Forms.ControlStyles.DoubleBuffer |
                    System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                    System.Windows.Forms.ControlStyles.ResizeRedraw, true);

               base.UpdateStyles();

               this.lineSplitter.StartColor = System.Drawing.Color.WhiteSmoke;
               this.lineSplitter.MiddleColor = System.Drawing.Color.OrangeRed;
               this.lineSplitter.EndColor = System.Drawing.Color.SlateBlue;
               this.lineSplitter.Dock = System.Windows.Forms.DockStyle.Bottom;
               this.lineSplitter.Start();

               this.Dock = System.Windows.Forms.DockStyle.Top;
               this.CreateTitleFont();
               this.CreateMessageFont();
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
               this.components = new System.ComponentModel.Container();
               this.timerSplash = new System.Windows.Forms.Timer(this.components);
               this.lineSplitter = new HuiruiSoft.UI.Controls.GradientBand();
               this.SuspendLayout();
               // 
               // timerSplash
               // 
               this.timerSplash.Interval = 200;
               this.timerSplash.Tick += new System.EventHandler(this.OnSplashTimerTick);
               // 
               // lineSplitter
               // 
               this.lineSplitter.BlockPosition = 0;
               this.lineSplitter.Location = new System.Drawing.Point(94, 107);
               this.lineSplitter.Name = "lineSplitter";
               this.lineSplitter.Reversed = false;
               this.lineSplitter.Size = new System.Drawing.Size(176, 5);
               this.lineSplitter.TabIndex = 2;
               this.lineSplitter.TabStop = false;
               // 
               // FlashBar
               // 
               this.BackColor = System.Drawing.Color.White;
               this.Controls.Add(this.lineSplitter);
               this.ForeColor = System.Drawing.Color.Black;
               this.Name = "FlashBar";
               this.Size = new System.Drawing.Size(387, 139);
               this.ResumeLayout(false);

          }

          #endregion Windows 窗体设计器生成的代码

          protected void CreateTitleFont()
          {
               this.titleFont = new Font(this.Font.FontFamily, this.Font.Size, this.titleFontStyle);
          }

          protected void CreateMessageFont()
          {
               this.messageFont = new Font(this.Font.FontFamily, this.Font.Size, this.messageFontStyle);
          }

          protected override void OnFontChanged(System.EventArgs args)
          {
               this.CreateTitleFont();
               base.OnFontChanged(args);
          }

          protected override void OnPaint(System.Windows.Forms.PaintEventArgs args)
          {
               base.OnPaint(args);

               var tmpGradientBounds = new System.Drawing.Rectangle(0, 0, this.Width, this.Height);
               var tmpGradientBrush = new LinearGradientBrush(tmpGradientBounds, this.startColor, this.endColor, 0, true);

               tmpGradientBrush.GammaCorrection = true;
               args.Graphics.FillRectangle(tmpGradientBrush, 0, 0, this.Width, this.Height);

               tmpGradientBounds = new System.Drawing.Rectangle(0, 0, 8, this.Height);
               tmpGradientBrush = new LinearGradientBrush(tmpGradientBounds, this.BackColor, Color.Transparent, 0, true);
               tmpGradientBrush.GammaCorrection = true;

               if (showFlashBars)
               {
                    var tmpRandom = new System.Random(unchecked((int)System.DateTime.Now.Ticks));
                    for (int index = 0; index < this.splashBars; index++)
                    {
                         args.Graphics.FillRectangle(tmpGradientBrush, tmpRandom.Next(this.Width - 20), 0, tmpRandom.Next(10) + 10, this.Height);
                    }
               }
               else
               {
                    args.Graphics.FillRectangle(tmpGradientBrush, 0, 0, 0, this.Height);
               }

               args.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
               args.Graphics.DrawString(this.flashBarTitle, this.titleFont, new SolidBrush(this.ForeColor), this.TextStartPosition);

               this.DrawMessage(args.Graphics);

               if (this.imageObject != null)
               {
                    this.DrawImage(args.Graphics);
               }
               else if (this.iconObject != null)
               {
                    this.DrawIcon(args.Graphics);
               }
          }

          protected void DrawMessage(Graphics graphics)
          {
               int tmpNewXposition = this.TextStartPosition.X + this.Font.Height * 3 / 2;
               int tmpNewYposition = this.TextStartPosition.Y + this.Font.Height * 3 / 2;
               int tmpTextBoxWidth = this.Width - tmpNewXposition;
               int tmpTextBoxHeight = this.Height - tmpNewYposition;

               if (this.imageObject != null)
               {
                    tmpTextBoxWidth -= (this.boundarySize + this.imageObject.Width);
               }
               else if (this.iconObject != null)
               {
                    tmpTextBoxWidth -= (this.boundarySize + this.iconObject.Width);
               }

               var tmpMessageBounds = new Rectangle(tmpNewXposition, tmpNewYposition, tmpTextBoxWidth, tmpTextBoxHeight);
               graphics.DrawString(this.messageString, this.messageFont, new SolidBrush(this.ForeColor), tmpMessageBounds);
          }

          protected void DrawIcon(Graphics graphics)
          {
               if (this.iconObject != null)
               {
                    graphics.DrawIcon(this.iconObject, this.Width - this.iconObject.Width - this.boundarySize, (this.Height - this.iconObject.Height) / 2);
               }
          }

          protected void DrawImage(Graphics graphics)
          {
               if (this.imageObject != null)
               {
                    graphics.DrawImage(this.imageObject, this.Width - this.imageObject.Width - this.boundarySize, (this.Height - this.imageObject.Height) / 2);
               }
          }

          private void OnSplashTimerTick(object sender, System.EventArgs args)
          {
               this.Update();
               this.Invalidate();
          }
     }
}
