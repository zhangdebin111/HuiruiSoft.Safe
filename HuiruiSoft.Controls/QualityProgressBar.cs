using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace HuiruiSoft.UI.Controls
{
     public sealed class QualityProgressBar : System.Windows.Forms.Control
     {
          private int minimum = 0;
          private int maximum = 100;
          private int position = 0;
          private string progressText = string.Empty;
          private ProgressBarStyle progressBarStyle = ProgressBarStyle.Continuous;

          private System.Drawing.Color qualityLowColor = Color.FromArgb(255, 128, 0);
          private System.Drawing.Color qualityHighColor = Color.FromArgb(000, 255, 0);

          [DefaultValue(0)]
          public int Minimum
          {
               get
               {
                    return this.minimum;
               }

               set
               {
                    this.minimum = value; this.Invalidate( );
               }
          }


          [DefaultValue(100)]
          public int Maximum
          {
               get
               {
                    return this.maximum;
               }

               set
               {
                    this.maximum = value; this.Invalidate( );
               }
          }


          [DefaultValue(0)]
          public int Value
          {
               get
               {
                    return this.position;
               }

               set
               {
                    this.position = value; this.Invalidate( );
               }
          }

          [DefaultValue("")]
          public string ProgressText
          {
               get
               {
                    return this.progressText;
               }

               set
               {
                    this.progressText = value; this.Invalidate( );
               }
          }

          public Color QualityLowColor
          {
               get
               {
                    return this.qualityLowColor;
               }

               set
               {
                    if(this.qualityLowColor != value)
                    {
                         this.qualityLowColor = value;
                         base.Invalidate( );
                    }
               }
          }

          public Color QualityHighColor
          {
               get
               {
                    return this.qualityHighColor;
               }

               set
               {
                    if(this.qualityHighColor != value)
                    {
                         this.qualityHighColor = value;
                         base.Invalidate( );
                    }
               }
          }

          [Browsable(false)]
          [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
          public ProgressBarStyle Style
          {
               get
               {
                    return this.progressBarStyle;
               }

               set
               {
                    this.progressBarStyle = value; this.Invalidate( );
               }
          }

          public QualityProgressBar( ) : base( )
          {
               this.DoubleBuffered = true;
          }

          public bool ShouldSerializeStyle( )
          {
               return false;
          }

          protected override void OnPaint(PaintEventArgs args)
          {
               try
               {
                    var tmpGraphics = args.Graphics;
                    if(tmpGraphics == null)
                    {
                         base.OnPaint(args); return;
                    }

                    int normPosition = position - minimum, normMaximum = maximum - minimum;
                    if(normMaximum <= 0)
                    {
                         normMaximum = 100;
                         System.Diagnostics.Debug.Assert(false);
                    }
                    if(normPosition < 0)
                    {
                         normPosition = 0;
                         System.Diagnostics.Debug.Assert(false);
                    }
                    if(normPosition > normMaximum)
                    {
                         normPosition = normMaximum;
                    }

                    Rectangle tmpDrawRectangle, tmpClientRectangle = this.ClientRectangle;

                    var tmpStyleElement = VisualStyleElement.ProgressBar.Bar.Normal;
                    if(VisualStyleRenderer.IsSupported && VisualStyleRenderer.IsElementDefined(tmpStyleElement))
                    {
                         var tmpStyleRenderer = new VisualStyleRenderer(tmpStyleElement);

                         if(tmpStyleRenderer.IsBackgroundPartiallyTransparent( ))
                         {
                              tmpStyleRenderer.DrawParentBackground(tmpGraphics, tmpClientRectangle, this);
                         }
                         tmpStyleRenderer.DrawBackground(tmpGraphics, tmpClientRectangle);
                         tmpDrawRectangle = tmpStyleRenderer.GetBackgroundContentRectangle(tmpGraphics, tmpClientRectangle);
                    }
                    else
                    {
                         tmpGraphics.FillRectangle(SystemBrushes.Control, tmpClientRectangle);

                         var tempGrayPen = System.Drawing.SystemPens.ControlDark;
                         var tmpWhitePen = System.Drawing.SystemPens.ControlLight;
                         tmpGraphics.DrawLine(tempGrayPen, 0, 0, tmpClientRectangle.Width - 1, 0);
                         tmpGraphics.DrawLine(tempGrayPen, 0, 0, 0, tmpClientRectangle.Height - 1);
                         tmpGraphics.DrawLine(tmpWhitePen, tmpClientRectangle.Width - 1, 0, tmpClientRectangle.Width - 1, tmpClientRectangle.Height - 1);
                         tmpGraphics.DrawLine(tmpWhitePen, 0, tmpClientRectangle.Height - 1, tmpClientRectangle.Width - 1, tmpClientRectangle.Height - 1);

                         tmpDrawRectangle = new Rectangle(tmpClientRectangle.X + 1, tmpClientRectangle.Y + 1, tmpClientRectangle.Width - 2, tmpClientRectangle.Height - 2);
                    }

                    int tmpDrawWidth = (int)((float)tmpDrawRectangle.Width * normPosition / normMaximum);

                    var tmpStartColor = this.qualityLowColor;
                    var tmpEndOfColor = this.qualityHighColor;
                    if(!this.Enabled)
                    {
                         tmpStartColor = HuiruiSoft.Utils.ColorUtils.ColorToGrayscale(SystemColors.ControlDark);
                         tmpEndOfColor = HuiruiSoft.Utils.ColorUtils.ColorToGrayscale(SystemColors.ControlLight);
                    }

                    bool tmpRightToLeft = (this.RightToLeft == RightToLeft.Yes);
                    if(tmpRightToLeft)
                    {
                         var tempColor = tmpStartColor; tmpStartColor = tmpEndOfColor; tmpEndOfColor = tempColor;
                    }

                    var tmpGradientBounds = new Rectangle(tmpDrawRectangle.X, tmpDrawRectangle.Y, tmpDrawRectangle.Width, tmpDrawRectangle.Height);

                    if(!HuiruiSoft.Utils.WindowsUtils.IsAtLeastWindowsVista)
                    {
                         tmpGradientBounds.Inflate(1, 0);
                    }

                    using(var tmpFillBrush = new LinearGradientBrush(tmpGradientBounds, tmpStartColor, tmpEndOfColor, LinearGradientMode.Horizontal))
                    {
                         tmpGraphics.FillRectangle(tmpFillBrush, tmpRightToLeft ? (tmpDrawRectangle.Width - tmpDrawWidth + 1) : tmpDrawRectangle.Left, tmpDrawRectangle.Top, tmpDrawWidth, tmpDrawRectangle.Height);
                    }

                    this.PaintText(tmpGraphics, tmpDrawRectangle, tmpRightToLeft);
               }
               catch(System.Exception)
               {
                    System.Diagnostics.Debug.Assert(false);
               }
          }

          private void PaintText(System.Drawing.Graphics graphics, System.Drawing.Rectangle drawBounds, bool rightToLeft)
          {
               if(string.IsNullOrEmpty(progressText))
               {
                    return;
               }

               var tmpForeColor = HuiruiSoft.Utils.ColorUtils.ColorToGrayscale(this.ForeColor);
               var tmpBackColor = System.Drawing.Color.FromArgb(tmpForeColor.ToArgb( ) ^ 0x20FFFFFF);

               if(!HuiruiSoft.Win32.NativeMethods.IsUnix( ))
               {
                    int x = drawBounds.X;
                    int y = drawBounds.Y;
                    int width = drawBounds.Width;
                    int height = drawBounds.Height;

                    var tmpGlowBounds = drawBounds;
                    tmpGlowBounds.Width = TextRenderer.MeasureText(graphics, progressText, this.Font).Width;
                    tmpGlowBounds.X = (width - tmpGlowBounds.Width) / 2 + x;
                    tmpGlowBounds.Inflate(tmpGlowBounds.Width / 2, tmpGlowBounds.Height / 2);

                    using(var tmpGlowPath = new GraphicsPath( ))
                    {
                         tmpGlowPath.AddEllipse(tmpGlowBounds);

                         using(var tmpGlowBrush = new PathGradientBrush(tmpGlowPath))
                         {
                              tmpGlowBrush.CenterPoint = new PointF(width / 2.0f + x, height / 2.0f + y);
                              tmpGlowBrush.CenterColor = tmpBackColor;
                              tmpGlowBrush.SurroundColors = new System.Drawing.Color[ ] { Color.Transparent };

                              var tmpOrgClip = graphics.Clip;
                              graphics.SetClip(drawBounds);
                              graphics.FillPath(tmpGlowBrush, tmpGlowPath);
                              graphics.Clip = tmpOrgClip;
                         }
                    }
               }

               using(var tmpSolidBrush = new SolidBrush(tmpForeColor))
               {
                    var tmpFormatFlags = (StringFormatFlags.FitBlackBox | StringFormatFlags.NoClip);
                    if(rightToLeft)
                    {
                         tmpFormatFlags |= StringFormatFlags.DirectionRightToLeft;
                    }

                    using(var tmpStringFormat = new StringFormat(tmpFormatFlags))
                    {
                         tmpStringFormat.Alignment = StringAlignment.Center;
                         tmpStringFormat.LineAlignment = StringAlignment.Center;
                         graphics.DrawString(progressText, this.Font, tmpSolidBrush, new RectangleF(drawBounds.X, drawBounds.Y, drawBounds.Width, drawBounds.Height), tmpStringFormat);
                    }
               }
          }
     }
}
