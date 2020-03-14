using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace HuiruiSoft.UI.Controls
{
     [DefaultBindingProperty("EditValue"), DefaultEvent("EditValueChanged")]
     public sealed class GradientBand : System.Windows.Forms.Control
     {
          private int gradientSize = 30;
          private int gradientStep = 5;
          private int timerInterval = 50;
          private System.Windows.Forms.Timer timerDrawTrack;
          private System.Windows.Forms.Orientation orientation;
          private System.Drawing.Color startColor = System.Drawing.SystemColors.Control;
          private System.Drawing.Color middleColor = System.Drawing.SystemColors.Highlight;
          private System.Drawing.Color endOfColor = System.Drawing.SystemColors.Control;

          [Category("外观"), DefaultValue(30), Description("Gets or sets the size of the gradient bar.")]
          public int GradientSize
          {
               get { return this.gradientSize; }

               set
               {
                    if (this.gradientSize != value)
                    {
                         this.gradientSize = value;
                         base.Invalidate();
                    }
               }
          }

          public bool Reversed { get; set; } = false;

          public int BlockPosition { get; set; } = 0;

          [Category("外观"), Description("Gets or sets a start color of the gradient bar.")]
          [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
          public System.Drawing.Color StartColor
          {
               get { return this.startColor; }

               set
               {
                    if (this.startColor != value)
                    {
                         this.startColor = value;
                         base.Invalidate();
                    }
               }
          }

          [Category("外观"), Description("Gets or sets a middle color of the gradient bar.")]
          [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
          public System.Drawing.Color MiddleColor
          {
               get { return this.middleColor; }

               set
               {
                    if (this.middleColor != value)
                    {
                         this.middleColor = value;
                         base.Invalidate();
                    }
               }
          }

          [Category("外观"), Description("Gets or sets a end color of the gradient bar.")]
          [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
          public System.Drawing.Color EndColor
          {
               get { return this.endOfColor; }

               set
               {
                    if (this.endOfColor != value)
                    {
                         this.endOfColor = value;
                         base.Invalidate();
                    }
               }
          }


          [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
          [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
          public override System.Drawing.Image BackgroundImage
          {
               get { return base.BackgroundImage; }

               set
               {
                    base.BackgroundImage = value;
                    base.SetStyle(System.Windows.Forms.ControlStyles.Opaque, value != null);
                    base.Invalidate();
                    this.OnBackgroundImageChanged(System.EventArgs.Empty);
               }
          }

          [Category("外观"), DefaultValue(System.Windows.Forms.Orientation.Horizontal)]
          [Description("Gets or sets a value indicating the horizontal or vertical orientation of the gradient band.")]
          public System.Windows.Forms.Orientation Orientation
          {
               get { return this.orientation; }

               set
               {
                    if (!System.Enum.IsDefined(typeof(System.Windows.Forms.Orientation), value))
                    {
                         throw new InvalidEnumArgumentException("Orientation", (int)value, typeof(System.Windows.Forms.Orientation));
                    }

                    if (this.orientation != value)
                    {
                         this.orientation = value;

                         if (base.IsHandleCreated)
                         {
                              System.Drawing.Rectangle tmpRectBounds = base.Bounds;
                              base.RecreateHandle();
                              base.SetBounds(tmpRectBounds.X, tmpRectBounds.Y, tmpRectBounds.Height, tmpRectBounds.Width, System.Windows.Forms.BoundsSpecified.All);
                         }
                         base.Invalidate();
                    }
               }
          }

          [Category("行为"), DefaultValue(5), Description("Gets or sets the step of the gradient bar.")]
          public int Step
          {
               get { return this.gradientStep; }

               set
               {
                    if (this.gradientStep != value)
                    {
                         this.gradientStep = value;
                         base.Invalidate();
                    }
               }
          }

          [Category("行为"), DefaultValue(50), Description("Get or sets the number of milliseconds between redraws the gradient bar.")]
          public int Speed
          {
               get { return this.timerDrawTrack.Interval; }

               set
               {
                    if (this.timerDrawTrack.Interval != value)
                    {
                         bool tmpEnabled = this.timerDrawTrack.Enabled;
                         if (this.timerDrawTrack.Enabled)
                         {
                              this.timerDrawTrack.Stop();
                         }

                         this.timerInterval = value;
                         this.timerDrawTrack.Interval = value;
                         if (tmpEnabled)
                         {
                              this.timerDrawTrack.Start();
                         }
                    }
               }
          }

          public GradientBand()
          {
               base.TabStop = false;
               this.timerDrawTrack = new System.Windows.Forms.Timer();
               this.timerDrawTrack.Tick += new System.EventHandler(this.OnDrawTrackTimerTick);
               this.timerDrawTrack.Interval = this.timerInterval;

               base.SetStyle(
                              System.Windows.Forms.ControlStyles.UserPaint |
                              System.Windows.Forms.ControlStyles.ResizeRedraw |
                              System.Windows.Forms.ControlStyles.DoubleBuffer |
                              System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                              System.Windows.Forms.ControlStyles.SupportsTransparentBackColor, true);
               base.SetStyle(
                              System.Windows.Forms.ControlStyles.UserMouse |
                              System.Windows.Forms.ControlStyles.Selectable |
                              System.Windows.Forms.ControlStyles.StandardClick |
                              System.Windows.Forms.ControlStyles.StandardDoubleClick, false);
          }


          private void OnDrawTrackTimerTick(object sender, System.EventArgs args)
          {
               if (this.Orientation == System.Windows.Forms.Orientation.Horizontal)
               {
                    this.BlockPosition += this.gradientStep;
               }
               else
               {
                    this.BlockPosition -= this.gradientStep;
               }

               var tmpClientBounds = System.Drawing.Rectangle.Inflate(this.ClientRectangle, -1, -1);

               if (this.gradientStep < 0)
               {
                    if ((this.Orientation == System.Windows.Forms.Orientation.Horizontal) && (this.BlockPosition < tmpClientBounds.Left))
                    {
                         this.Reversed = !this.Reversed;
                         this.BlockPosition = tmpClientBounds.Width;
                    }
                    else if ((this.Orientation == System.Windows.Forms.Orientation.Vertical) && (this.BlockPosition > tmpClientBounds.Bottom))
                    {
                         this.Reversed = !this.Reversed;
                         this.BlockPosition = tmpClientBounds.Top;
                    }
               }
               else if ((this.Orientation == System.Windows.Forms.Orientation.Horizontal) && (this.BlockPosition > tmpClientBounds.Width))
               {
                    this.Reversed = !this.Reversed;
                    this.BlockPosition = tmpClientBounds.Left;
               }
               else if ((this.Orientation == System.Windows.Forms.Orientation.Vertical) && (this.BlockPosition < tmpClientBounds.Top))
               {
                    this.Reversed = !this.Reversed;
                    this.BlockPosition = tmpClientBounds.Bottom;
               }

               base.Invalidate();
          }

          [System.ComponentModel.Description("Start the gradient bar scrolling.")]
          public void Start()
          {
               this.timerDrawTrack.Start();
          }

          [System.ComponentModel.Description("Stop the gradient bar scrolling.")]
          public void Stop()
          {
               this.timerDrawTrack.Stop();
               base.Invalidate();
          }

          protected override void OnPaint(System.Windows.Forms.PaintEventArgs args)
          {
               args.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

               if (this.Orientation == System.Windows.Forms.Orientation.Horizontal)
               {
                    this.DrawBarHorizontal(args);
               }
               else
               {
                    this.DrawBarVertical(args);
               }
          }


          private void DrawBarHorizontal(System.Windows.Forms.PaintEventArgs args)
          {
               var tmpRectRegion = args.Graphics.Clip;
               var tmpClientBounds = this.ClientRectangle;
               args.Graphics.Clip = new System.Drawing.Region(tmpClientBounds);

               System.Drawing.Color tmpStartColor = this.StartColor, tmpEndOfColor = this.EndColor;

               var tmpFlag1 = false;
               var tmpFlag2 = false;

               var tmpRectBlock1 = tmpClientBounds;
               var tmpRectBlock2 = tmpClientBounds;
               var tmpRectBlock3 = tmpClientBounds;
               var tmpRectBlock4 = tmpClientBounds;
               var tmpRectBlock5 = tmpClientBounds;
               var tmpRectBlock6 = tmpClientBounds;

               var tmpBlockSize = (int)(this.GradientSize / 2 * ((float)tmpClientBounds.Width) / 50f);
               tmpRectBlock1.Width = tmpBlockSize;
               tmpRectBlock1.X = this.BlockPosition - tmpBlockSize;
               tmpRectBlock2.X = this.BlockPosition;
               tmpRectBlock2.Width = tmpBlockSize;
               tmpRectBlock3.Width = this.BlockPosition - tmpBlockSize;
               tmpRectBlock4.X = this.BlockPosition + tmpBlockSize - 1;
               tmpRectBlock4.Width = this.ClientRectangle.Width - (this.BlockPosition + tmpBlockSize);

               if ((this.BlockPosition + tmpBlockSize) > tmpClientBounds.Width)
               {
                    tmpFlag2 = true;
                    tmpRectBlock6.X = -(tmpClientBounds.Width - this.BlockPosition + tmpClientBounds.Left);
                    tmpRectBlock6.Width = tmpBlockSize;
                    tmpRectBlock3.X = (tmpRectBlock6.X + tmpBlockSize);
                    tmpRectBlock3.Width -= tmpRectBlock6.X + tmpBlockSize - 1;
               }

               if (this.BlockPosition < tmpBlockSize)
               {
                    tmpFlag1 = true;
                    tmpRectBlock5.X = (tmpClientBounds.Width - tmpBlockSize) + this.BlockPosition;
                    tmpRectBlock5.Width = tmpBlockSize;
                    tmpRectBlock4.X = tmpRectBlock2.X + tmpBlockSize;
                    tmpRectBlock4.Width = tmpRectBlock5.X - tmpRectBlock4.X;
               }

               var color3 = (tmpFlag2 && tmpFlag1) ? tmpEndOfColor : tmpStartColor;
               var color4 = (tmpFlag2 && tmpFlag1) ? tmpStartColor : tmpEndOfColor;

               if (tmpFlag2 && tmpRectBlock6.Width > 0 && tmpRectBlock6.Height > 0)
               {
                    tmpRectBlock6.Width++;
                    using (var tmpLinearBrush = new LinearGradientBrush(tmpRectBlock6, this.MiddleColor, color3, LinearGradientMode.Horizontal))
                    {
                         tmpRectBlock6.X++;
                         tmpRectBlock6.Width--;
                         args.Graphics.FillRectangle(tmpLinearBrush, tmpRectBlock6);
                    }
               }

               if (tmpFlag1 && tmpRectBlock5.Width > 0 && tmpRectBlock5.Height > 0)
               {
                    tmpRectBlock5.Width++;
                    using (var tmpLinearBrush = new LinearGradientBrush(tmpRectBlock5, color4, this.MiddleColor, LinearGradientMode.Horizontal))
                    {
                         tmpRectBlock5.X++;
                         tmpRectBlock5.Width--;
                         args.Graphics.FillRectangle(tmpLinearBrush, tmpRectBlock5);
                    }
               }

               using (var tmpSolidBrush = new System.Drawing.SolidBrush(tmpStartColor))
               {
                    args.Graphics.FillRectangle(tmpSolidBrush, tmpRectBlock3);
               }

               if (tmpRectBlock1.Width > 0 && tmpRectBlock1.Height > 0)
               {
                    tmpRectBlock1.Width++;
                    using (var tmpLinearBrush = new LinearGradientBrush(tmpRectBlock1, tmpStartColor, this.MiddleColor, LinearGradientMode.Horizontal))
                    {
                         tmpRectBlock1.X++;
                         tmpRectBlock1.Width--;
                         args.Graphics.FillRectangle(tmpLinearBrush, tmpRectBlock1);
                    }
               }

               if (tmpRectBlock2.Width > 0 && tmpRectBlock2.Height > 0)
               {
                    tmpRectBlock2.Width++;
                    using (var tmpLinearBrush = new LinearGradientBrush(tmpRectBlock2, this.MiddleColor, tmpEndOfColor, LinearGradientMode.Horizontal))
                    {
                         tmpRectBlock2.X++;
                         tmpRectBlock2.Width--;
                         args.Graphics.FillRectangle(tmpLinearBrush, tmpRectBlock2);
                    }
               }

               using (var tmpSolidBrush = new System.Drawing.SolidBrush(tmpEndOfColor))
               {
                    tmpRectBlock4.Width += 2;
                    args.Graphics.FillRectangle(tmpSolidBrush, tmpRectBlock4);
               }
               args.Graphics.Clip = tmpRectRegion;
          }

          private void DrawBarVertical(System.Windows.Forms.PaintEventArgs args)
          {
               var tmpRectRegion = args.Graphics.Clip;
               var tmpClientBounds = this.ClientRectangle;
               args.Graphics.Clip = new System.Drawing.Region(tmpClientBounds);

               var tmpStartColor = this.StartColor;
               var tmpEndOfColor = this.EndColor;

               var tmpFlag1 = false;
               var tmpFlag2 = false;

               var tmpRectBlock1 = tmpClientBounds;
               var tmpRectBlock2 = tmpClientBounds;
               var tmpRectBlock3 = tmpClientBounds;
               var tmpRectBlock4 = tmpClientBounds;
               var tmpRectBlock5 = tmpClientBounds;
               var tmpRectBlock6 = tmpClientBounds;

               var tmpBlockSize = (int)(this.GradientSize / 2 * ((float)tmpClientBounds.Height) / 50f);
               tmpRectBlock1.Height = tmpBlockSize;
               tmpRectBlock1.Y = this.BlockPosition - tmpBlockSize;
               tmpRectBlock2.Y = this.BlockPosition;
               tmpRectBlock2.Height = tmpBlockSize;
               tmpRectBlock3.Height = this.BlockPosition - tmpBlockSize;
               tmpRectBlock4.Y = this.BlockPosition + tmpBlockSize - 1;
               tmpRectBlock4.Height = this.ClientRectangle.Height - (this.BlockPosition + tmpBlockSize);

               if ((this.BlockPosition + tmpBlockSize) > tmpClientBounds.Height)
               {
                    tmpFlag2 = true;
                    tmpRectBlock6.Y = -(tmpClientBounds.Height - this.BlockPosition + tmpClientBounds.Top);
                    tmpRectBlock6.Height = tmpBlockSize;
                    tmpRectBlock3.Y = (tmpRectBlock6.Y + tmpBlockSize);
                    tmpRectBlock3.Height -= (tmpRectBlock6.Y + tmpBlockSize - 1);
               }

               if (this.BlockPosition < tmpBlockSize)
               {
                    tmpFlag1 = true;
                    tmpRectBlock5.Y = (tmpClientBounds.Height - tmpBlockSize) + this.BlockPosition;
                    tmpRectBlock5.Height = tmpBlockSize;
                    tmpRectBlock4.Y = tmpRectBlock2.Y + tmpBlockSize;
                    tmpRectBlock4.Height = tmpRectBlock5.Y - tmpRectBlock4.Y;
               }

               var color3 = (tmpFlag2 && tmpFlag1) ? tmpEndOfColor : tmpStartColor;
               var color4 = (tmpFlag2 && tmpFlag1) ? tmpStartColor : tmpEndOfColor;

               if (tmpFlag2 && tmpRectBlock6.Height > 0 && tmpRectBlock6.Width > 0)
               {
                    tmpRectBlock6.Height++;
                    using (var tmpLinearBrush = new LinearGradientBrush(tmpRectBlock6, this.MiddleColor, color3, LinearGradientMode.Vertical))
                    {
                         tmpRectBlock6.Y++;
                         tmpRectBlock6.Height--;
                         args.Graphics.FillRectangle(tmpLinearBrush, tmpRectBlock6);
                    }
               }

               if (tmpFlag1 && tmpRectBlock5.Height > 0 && tmpRectBlock5.Width > 0)
               {
                    tmpRectBlock5.Height++;
                    using (var tmpLinearBrush = new LinearGradientBrush(tmpRectBlock5, color4, this.MiddleColor, LinearGradientMode.Vertical))
                    {
                         tmpRectBlock5.Y++;
                         tmpRectBlock5.Height--;
                         args.Graphics.FillRectangle(tmpLinearBrush, tmpRectBlock5);
                    }
               }

               using (var tmpSolidBrush = new System.Drawing.SolidBrush(tmpStartColor))
               {
                    args.Graphics.FillRectangle(tmpSolidBrush, tmpRectBlock3);
               }

               if (tmpRectBlock1.Height > 0 && tmpRectBlock1.Width > 0)
               {
                    tmpRectBlock1.Height++;
                    using (var tmpLinearBrush = new LinearGradientBrush(tmpRectBlock1, tmpStartColor, this.MiddleColor, LinearGradientMode.Vertical))
                    {
                         tmpRectBlock1.Y++;
                         tmpRectBlock1.Height--;
                         args.Graphics.FillRectangle(tmpLinearBrush, tmpRectBlock1);
                    }
               }

               if (tmpRectBlock2.Height > 0 && tmpRectBlock2.Width > 0)
               {
                    tmpRectBlock2.Height++;
                    using (var tmpLinearBrush = new LinearGradientBrush(tmpRectBlock2, this.MiddleColor, tmpEndOfColor, LinearGradientMode.Vertical))
                    {
                         tmpRectBlock2.Y++;
                         tmpRectBlock2.Height--;
                         args.Graphics.FillRectangle(tmpLinearBrush, tmpRectBlock2);
                    }
               }

               using (var tmpSolidBrush = new System.Drawing.SolidBrush(tmpEndOfColor))
               {
                    tmpRectBlock4.Height += 2;
                    args.Graphics.FillRectangle(tmpSolidBrush, tmpRectBlock4);
               }

               args.Graphics.Clip = tmpRectRegion;
          }
     }
}
