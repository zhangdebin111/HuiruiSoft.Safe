
using System.Windows.Forms;
using System.ComponentModel;

namespace HuiruiSoft.UI.Controls
{
     //[ToolboxItem(true), System.Drawing.ToolboxBitmap(typeof(HuiruiSoft.Shared.ResourceFinder), "Images.ColorSlider.bmp")]
     public class ColorSlider : System.Windows.Forms.Control
     {
          private int markerPosition = 0;
          private bool mouseIsPressed = false;
          private Orientation orientation;
          private System.Drawing.Color currentColor;
          private HuiruiSoft.Drawing.HSBCOLOR hsbColor;
          private HuiruiSoft.Drawing.CIELabColor cieLabColor;
          private HuiruiSoft.Drawing.ColorCubeZAxes cubeZaxes;

          private const int SliderMarkerSize = 5, BorderOffsetSize = 2;

          private System.Drawing.Bitmap colorBitmap;

          /// <summary>每当此控件的"Color"属性更改时发生。</summary>
          [Browsable(true), Category("数据"), Description("每当此控件的 Color 属性更改时发生。")]
          public event System.EventHandler ColorChanged;  // 定义新事件 ColorChanged

          [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
          public override System.Drawing.Color ForeColor
          {
               get
               {
                    return base.ForeColor;
               }

               set
               {
                    base.ForeColor = value;
               }
          }

          [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
          public override System.Drawing.Color BackColor
          {
               get
               {
                    return base.BackColor;
               }

               set
               {
                    base.BackColor = value;
               }
          }

          [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
          public override System.Drawing.Font Font
          {
               get
               {
                    return base.Font;
               }

               set
               {
                    base.Font = value;
               }
          }

          [Bindable(false), Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
          public override string Text
          {
               get
               {
                    return base.Text;
               }

               set
               {
                    base.Text = value;
               }
          }


          [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
          public override System.Drawing.Image BackgroundImage
          {
               get
               {
                    return base.BackgroundImage;
               }

               set
               {
                    base.BackgroundImage = value;
               }
          }


          /// <summary>获取或设置一个值，该值指示跟踪条在水平方向还在垂直方向。</summary>
          [Browsable(true), DefaultValue(Orientation.Vertical)]
          [Category("外观"), Description("获取或设置一个值，该值指示跟踪条在水平方向还在垂直方向。")]
          public Orientation Orientation
          {
               get
               {
                    return this.orientation;
               }

               set
               {
                    if(this.orientation != value)
                    {
                         this.orientation = value;
                         this.OnResize(new System.EventArgs( ));
                    }
               }
          }

          /// <summary>返回或设置颜色的 Z-Axis。</summary>
          [Browsable(true), Category("外观"), DefaultValue(HuiruiSoft.Drawing.ColorCubeZAxes.Red), Description("返回或设置颜色的 Z-Axis。")]
          public HuiruiSoft.Drawing.ColorCubeZAxes ZAxes
          {
               get
               {
                    return this.cubeZaxes;
               }

               set
               {
                    if(this.cubeZaxes != value)
                    {
                         this.cubeZaxes = value;
                         this.ResetColorSlider(true);
                    }
               }
          }

          /// <summary>返回或设置 Color 值。</summary>
          [Browsable(false), Category("数据"), DefaultValue(typeof(System.Drawing.Color), "White"), Description("返回或设置 Color 值。")]
          public System.Drawing.Color Color
          {
               get
               {
                    return this.currentColor;
               }

               set
               {
                    if(!this.currentColor.Equals(value))
                    {
                         this.HSB = HuiruiSoft.Drawing.ColorTranslator.RGBToHSB(value);
                         this.ResetColorSlider(true);
                    }
               }
          }

          internal HuiruiSoft.Drawing.HSBCOLOR HSB
          {
               get
               {
                    return this.hsbColor;
               }

               set
               {
                    this.hsbColor = value;
                    this.currentColor = HuiruiSoft.Drawing.ColorTranslator.HSBToRGB(this.hsbColor);
                    this.cieLabColor = HuiruiSoft.Drawing.ColorTranslator.RGBToCIELab(this.currentColor);
                    this.ResetColorSlider(true);
               }
          }

          internal HuiruiSoft.Drawing.CIELabColor CIELab
          {
               get
               {
                    return this.cieLabColor;
               }

               set
               {
                    this.cieLabColor = value;
                    this.currentColor = HuiruiSoft.Drawing.ColorTranslator.CIELabToColor(this.cieLabColor);
                    this.hsbColor = HuiruiSoft.Drawing.ColorTranslator.RGBToHSB(this.currentColor);
                    this.ResetColorSlider(true);
               }
          }

          public ColorSlider( )
          {
               this.cubeZaxes = HuiruiSoft.Drawing.ColorCubeZAxes.Hue;
               this.orientation = Orientation.Vertical;

               this.hsbColor = new HuiruiSoft.Drawing.HSBCOLOR( );
               this.hsbColor.Hue = 360.0;
               this.hsbColor.Saturation = 1.0;
               this.hsbColor.Brightness = 1.0;
               this.cubeZaxes = HuiruiSoft.Drawing.ColorCubeZAxes.Hue;
               this.cieLabColor = new HuiruiSoft.Drawing.CIELabColor( );
               this.currentColor = HuiruiSoft.Drawing.ColorTranslator.HSBToRGB(this.hsbColor);

               base.TabStop = true;

               base.SetStyle(
                    ControlStyles.UserPaint |
                    ControlStyles.UserMouse |
                    ControlStyles.Selectable |
                    ControlStyles.ResizeRedraw |
                    ControlStyles.DoubleBuffer |
                    ControlStyles.StandardClick |
                    ControlStyles.StandardDoubleClick |
                    ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.SupportsTransparentBackColor, true);
          }

          protected override void OnCreateControl( )
          {
               base.OnCreateControl( );

               System.Drawing.Size tmpMinWorkSize, tmpMaxWorkSize;
               if (this.Orientation == Orientation.Vertical)
               {
                    tmpMinWorkSize = new System.Drawing.Size(16, 85);
                    tmpMaxWorkSize = new System.Drawing.Size(36, 256);
               }
               else
               {
                    tmpMinWorkSize = new System.Drawing.Size(85, 16);
                    tmpMaxWorkSize = new System.Drawing.Size(256, 36);
               }

               int tmpClientWidth = this.Width, tmpClientHeight = this.Height;
               if (this.Orientation == Orientation.Vertical)
               {
                    if (this.Width  < tmpMinWorkSize.Width  + 2 * SliderMarkerSize) tmpClientWidth  = tmpMinWorkSize.Width  + 2 * SliderMarkerSize;
                    if (this.Width  > tmpMaxWorkSize.Width  + 2 * SliderMarkerSize) tmpClientWidth  = tmpMaxWorkSize.Width  + 2 * SliderMarkerSize;
                    if (this.Height < tmpMinWorkSize.Height + 2 * SliderMarkerSize) tmpClientHeight = tmpMinWorkSize.Height + 2 * SliderMarkerSize;
                    if (this.Height > tmpMaxWorkSize.Height + 2 * SliderMarkerSize) tmpClientHeight = tmpMaxWorkSize.Height + 2 * SliderMarkerSize;
               }
               else
               {
                    if (this.Width  < tmpMinWorkSize.Width  + 2 * SliderMarkerSize) tmpClientWidth  = tmpMinWorkSize.Width  + 2 * SliderMarkerSize;
                    if (this.Width  > tmpMaxWorkSize.Width  + 2 * SliderMarkerSize) tmpClientWidth  = tmpMaxWorkSize.Width  + 2 * SliderMarkerSize;
                    if (this.Height < tmpMinWorkSize.Height + 2 * SliderMarkerSize) tmpClientHeight = tmpMinWorkSize.Height + 2 * SliderMarkerSize;
                    if (this.Height > tmpMaxWorkSize.Height + 2 * SliderMarkerSize) tmpClientHeight = tmpMaxWorkSize.Height + 2 * SliderMarkerSize;
               }

               if (this.Size.Width != tmpClientWidth || this.Size.Height != tmpClientHeight)
               {
                    this.Size = new System.Drawing.Size(tmpClientWidth, tmpClientHeight);
               }

               if (this.colorBitmap != null)
               {
                    this.colorBitmap.Dispose();
                    this.colorBitmap = null;
               }

               if (this.Orientation == Orientation.Vertical)
               {
                    this.colorBitmap = new System.Drawing.Bitmap(System.Math.Max(1, this.Height - 2 * SliderMarkerSize), 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
               }
               else
               {
                    this.colorBitmap = new System.Drawing.Bitmap(System.Math.Max(1, this.Width - 2 * SliderMarkerSize), 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
               }
          }

          private void RaiseColorChangedEvent( )
          {
               this.OnColorChanged(new System.EventArgs( ));
          }

          protected virtual void OnColorChanged(System.EventArgs args)
          {
               this.ColorChanged?.Invoke(this, args);
          }

          protected override void OnSizeChanged(System.EventArgs args)
          {
               base.OnSizeChanged(args);
          }

          protected override void OnPaint(PaintEventArgs args)
          {
               base.OnPaint(args);

               var tmpGraphicsState = args.Graphics.Save( );
               args.Graphics.PixelOffsetMode   = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
               args.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

               if(this.Orientation == Orientation.Horizontal)
               {
                    args.Graphics.DrawImage(this.colorBitmap, SliderMarkerSize, SliderMarkerSize, this.Width - 2 * (SliderMarkerSize + BorderOffsetSize / 2), this.Height - 2 * (SliderMarkerSize + 1));
               }
               else
               {
                    args.Graphics.Transform = new System.Drawing.Drawing2D.Matrix(0f, 1f, 1f, 0f, 0f, 0f);
                    args.Graphics.DrawImage(this.colorBitmap, SliderMarkerSize - 1, SliderMarkerSize, this.Height - 2 * SliderMarkerSize, this.Width - 2 * (SliderMarkerSize + BorderOffsetSize / 2));
               }
               args.Graphics.Restore(tmpGraphicsState);

               using(var tmpDrawPenObject = new System.Drawing.Pen(System.Drawing.Color.Black))
               {
                    tmpDrawPenObject.Color = System.Drawing.Color.FromArgb(172, 168, 153);
                    var tempLeftTop     = new System.Drawing.Point(SliderMarkerSize, BorderOffsetSize);
                    var tempRightTop    = new System.Drawing.Point(this.Width - (SliderMarkerSize + BorderOffsetSize), BorderOffsetSize);
                    var tempLeftBottom  = new System.Drawing.Point(SliderMarkerSize, this.Height - (SliderMarkerSize + BorderOffsetSize));
                    var tempRightBottom = new System.Drawing.Point(this.Width - (SliderMarkerSize + BorderOffsetSize), this.Height - (SliderMarkerSize + BorderOffsetSize));

                    if(this.Orientation == Orientation.Horizontal)
                    {
                         tempLeftTop.Offset(0, 1); tempRightTop.Offset(0, 1); tempLeftBottom.Offset(0, 1); tempRightBottom.Offset(0, 1);
                    }

                    args.Graphics.DrawLine(tmpDrawPenObject, tempLeftTop, tempRightTop);	    //	Draw top line
                    args.Graphics.DrawLine(tmpDrawPenObject, tempLeftTop, tempLeftBottom);	    //	Draw left hand line

                    tmpDrawPenObject.Color = System.Drawing.Color.White;
                    args.Graphics.DrawLine(tmpDrawPenObject, tempRightTop, tempRightBottom);     //	Draw right hand line
                    args.Graphics.DrawLine(tmpDrawPenObject, tempLeftBottom, tempRightBottom);   //	Draw bottome line

                    tmpDrawPenObject.Color = System.Drawing.Color.Black;
                    var tmpInnerBorder = new System.Drawing.Rectangle(tempLeftTop, new System.Drawing.Size(System.Math.Abs(tempRightBottom.X - tempLeftBottom.X), System.Math.Abs(tempRightBottom.Y - tempLeftTop.Y)));
                    tmpInnerBorder.Inflate(-1, -1);
                    args.Graphics.DrawRectangle(tmpDrawPenObject, tmpInnerBorder);	//	Draw inner black rectangle

                    //draw gridlines
                    if((ModifierKeys & System.Windows.Forms.Keys.Shift) != 0)
                    {
                         tmpDrawPenObject.Brush = new System.Drawing.Drawing2D.HatchBrush(System.Drawing.Drawing2D.HatchStyle.SmallCheckerBoard, System.Drawing.Color.FromArgb(80, 255, 255, 255), System.Drawing.Color.FromArgb(0, 0, 0, 0));

                         float dy = (float)(this.Height - 2 * (SliderMarkerSize + 1)) / 8f, y = 5f;
                         for(int index = 0; index <= 8; index++, y += dy)
                         {
                              args.Graphics.DrawLine(tmpDrawPenObject, SliderMarkerSize, (int)y, this.Width - (SliderMarkerSize + 1), (int)y);
                         }
                    }
               }

               //draw fader
               var tempFaderBounds = this.GetScrollerRectangle( );
               args.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

               if(this.Orientation == Orientation.Vertical)
               {
                    tempFaderBounds.Offset(0, -BorderOffsetSize / 2);
                    System.Drawing.Point[ ] tempPolygonPoints =
                         new System.Drawing.Point[ ]
                              {
                                   new System.Drawing.Point(tempFaderBounds.X + 1, tempFaderBounds.Y),
                                   new System.Drawing.Point(tempFaderBounds.X + 4, tempFaderBounds.Y),
                                   new System.Drawing.Point(tempFaderBounds.X + 9, tempFaderBounds.Y + SliderMarkerSize),
                                   new System.Drawing.Point(tempFaderBounds.X + 4, tempFaderBounds.Bottom),
                                   new System.Drawing.Point(tempFaderBounds.X + 1, tempFaderBounds.Bottom),
                                   new System.Drawing.Point(tempFaderBounds.X + 0, tempFaderBounds.Bottom - 1),
                                   new System.Drawing.Point(tempFaderBounds.X + 0, tempFaderBounds.Y + 1)
                              };
                    args.Graphics.FillPolygon(System.Drawing.Brushes.White, tempPolygonPoints);
                    args.Graphics.DrawPolygon(System.Drawing.Pens.Silver, tempPolygonPoints);

                    tempPolygonPoints =
                         new System.Drawing.Point[ ]
                              {
                                   new System.Drawing.Point(tempFaderBounds.Right - 1, tempFaderBounds.Y),
                                   new System.Drawing.Point(tempFaderBounds.Right - 4, tempFaderBounds.Y),
                                   new System.Drawing.Point(tempFaderBounds.Right - 9, tempFaderBounds.Y + SliderMarkerSize),
                                   new System.Drawing.Point(tempFaderBounds.Right - 4, tempFaderBounds.Bottom),
                                   new System.Drawing.Point(tempFaderBounds.Right - 1, tempFaderBounds.Bottom),
                                   new System.Drawing.Point(tempFaderBounds.Right - 0, tempFaderBounds.Bottom - 1),
                                   new System.Drawing.Point(tempFaderBounds.Right - 0, tempFaderBounds.Y + 1)
                              };

                    args.Graphics.FillPolygon(System.Drawing.Brushes.White, tempPolygonPoints);
                    args.Graphics.DrawPolygon(System.Drawing.Pens.Silver, tempPolygonPoints);
               }
               else
               {
                    tempFaderBounds.Offset(-BorderOffsetSize / 2, 0);
                    System.Drawing.Point[ ] tempPolygonPoints =
                         new System.Drawing.Point[ ]
                              {
                                   new System.Drawing.Point(tempFaderBounds.X + 1, tempFaderBounds.Y),
                                   new System.Drawing.Point(tempFaderBounds.X + 0, tempFaderBounds.Y + 1),
                                   new System.Drawing.Point(tempFaderBounds.X + 0, tempFaderBounds.Y + 4),
                                   new System.Drawing.Point(tempFaderBounds.X + 1 * SliderMarkerSize, tempFaderBounds.Y + 9),
                                   new System.Drawing.Point(tempFaderBounds.X + 2 * SliderMarkerSize, tempFaderBounds.Y + 4),
                                   new System.Drawing.Point(tempFaderBounds.X + 2 * SliderMarkerSize, tempFaderBounds.Y + 1),
                                   new System.Drawing.Point(tempFaderBounds.X + 2 * SliderMarkerSize - 1, tempFaderBounds.Y),
                              };
                    args.Graphics.FillPolygon(System.Drawing.Brushes.White, tempPolygonPoints);
                    args.Graphics.DrawPolygon(System.Drawing.Pens.Silver, tempPolygonPoints);

                    tempPolygonPoints =
                         new System.Drawing.Point[ ]
                              {
                                   new System.Drawing.Point(tempFaderBounds.X + 1, tempFaderBounds.Bottom),
                                   new System.Drawing.Point(tempFaderBounds.X + 0, tempFaderBounds.Bottom - 1),
                                   new System.Drawing.Point(tempFaderBounds.X + 0, tempFaderBounds.Bottom - 4),
                                   new System.Drawing.Point(tempFaderBounds.X + 1 * SliderMarkerSize, tempFaderBounds.Bottom - 9),
                                   new System.Drawing.Point(tempFaderBounds.X + 2 * SliderMarkerSize, tempFaderBounds.Bottom - 4),
                                   new System.Drawing.Point(tempFaderBounds.X + 2 * SliderMarkerSize, tempFaderBounds.Bottom - 1),
                                   new System.Drawing.Point(tempFaderBounds.X + 2 * SliderMarkerSize - 1, tempFaderBounds.Bottom)
                              };
                    args.Graphics.FillPolygon(System.Drawing.Brushes.White, tempPolygonPoints);
                    args.Graphics.DrawPolygon(System.Drawing.Pens.Silver, tempPolygonPoints);
               }
          }

          private void SetMarkerPosition(int markerPosition)
          {
               if(markerPosition < 0) markerPosition = 0;
               if(this.orientation == Orientation.Horizontal)
               {
                    if(markerPosition > this.Width - 2 * (SliderMarkerSize + 1)) markerPosition = this.Width - 2 * (SliderMarkerSize + 1);
               }
               else
               {
                    if(markerPosition > this.Height - 2 * (SliderMarkerSize + 1)) markerPosition = this.Height - 2 * (SliderMarkerSize + 1);
               }

               if((ModifierKeys & System.Windows.Forms.Keys.Shift) != 0)
               {
                    markerPosition = markerPosition / 8 * 8;
               }

               if(markerPosition != this.markerPosition)
               {
                    this.Invalidate(System.Drawing.Rectangle.Inflate(this.GetScrollerRectangle( ), BorderOffsetSize, BorderOffsetSize));
                    this.markerPosition = markerPosition;
                    this.Invalidate(System.Drawing.Rectangle.Inflate(this.GetScrollerRectangle( ), BorderOffsetSize, BorderOffsetSize));
                    this.Update( );

                    this.ResetHSLRGB( );
                    this.RaiseColorChangedEvent( );
               }
          }


          private System.Drawing.Rectangle GetScrollerRectangle( )
          {
               if(this.orientation == Orientation.Horizontal)
               {
                    return new System.Drawing.Rectangle((int)((double)this.markerPosition / 255.0 * (double)(this.Width - 2 * (SliderMarkerSize + 1))), 0, 2 * SliderMarkerSize, this.Height - 2 * 1);
               }
               else
               {
                    return new System.Drawing.Rectangle(0, (int)((double)this.markerPosition / 255.0 * (double)(this.Height - 2 * (SliderMarkerSize + 1))), this.Width - 2 * 1, 2 * SliderMarkerSize);
               }
          }

          protected override void OnMouseDown(MouseEventArgs args)
          {
               base.OnMouseDown(args);

               if(this.Enabled && args.Button == MouseButtons.Left)
               {
                    this.mouseIsPressed = true;
                    this.SetMarkerPosition(this.orientation == Orientation.Horizontal ? args.X - (SliderMarkerSize / 2 + BorderOffsetSize) : args.Y - (SliderMarkerSize / 2 + BorderOffsetSize));
               }
          }

          protected override void OnMouseMove(MouseEventArgs args)
          {
               base.OnMouseMove(args);

               if(this.mouseIsPressed && args.Button == MouseButtons.Left)
               {
                    this.SetMarkerPosition(this.orientation == Orientation.Horizontal ? args.X - (SliderMarkerSize / 2 + BorderOffsetSize) : args.Y - (SliderMarkerSize / 2 + BorderOffsetSize));
               }
          }

          protected override void OnMouseUp(MouseEventArgs args)
          {
               base.OnMouseUp(args);

               this.mouseIsPressed = false;
               if(args.Button == MouseButtons.Left)
               {
                    this.SetMarkerPosition(this.orientation == Orientation.Horizontal ? args.X - (SliderMarkerSize / 2 + BorderOffsetSize) : args.Y - (SliderMarkerSize / 2 + BorderOffsetSize));
               }
          }

          protected override void OnKeyDown(KeyEventArgs args)
          {
               base.OnKeyDown(args);

               if((ModifierKeys & Keys.Shift) != 0)
               {
                    this.Refresh( );
               }
          }

          protected override void OnKeyUp(KeyEventArgs args)
          {
               base.OnKeyUp(args);

               if((ModifierKeys & Keys.Shift) != 0)
               {
                    this.Refresh( );
               }
          }

          /// <summary>处理对话框键。</summary>
          /// <param name="keyData"><seealso cref="Keys">Keys</seealso> 值之一，它表示要处理的键。</param>
          /// <returns>如果控件处理并使用击键，则为 <b>true</b>；否则为 <b>false</b>，以允许进一步处理。</returns>
          /// <remarks><b>ProcessDialogKey</b> 方法重写基 <seealso cref="ContainerControl.ProcessDialogKey">ContainerControl.ProcessDialogKey</seealso> 实现，以在对话框中提供额外的 Return 和 Esc 键处理。该方法对包括 Alt 或 Control 修饰符的击键不作任何处理。</remarks>
          protected override bool ProcessDialogKey(Keys keyData)
          {
               if(!this.Enabled) return true;

               int tmpMarkerPosition = this.markerPosition;
               switch(keyData)
               {
                    case Keys.Home:
                         tmpMarkerPosition = 0;
                         break;

                    case Keys.End:
                         tmpMarkerPosition = 255;
                         break;

                    case Keys.Up:
                    case Keys.Right:
                    case Keys.Add:
                    case Keys.Oemplus:
                         if(this.orientation == Orientation.Horizontal)
                         {
                              if(keyData == Keys.Up) return base.ProcessDialogKey(keyData);
                         }
                         else
                         {
                              if(keyData == Keys.Right) return base.ProcessDialogKey(keyData);
                         }

                         if(this.orientation == Orientation.Horizontal)
                         {
                              tmpMarkerPosition += 1;
                         }
                         else
                         {
                              tmpMarkerPosition -= 1;
                         }
                         break;

                    case Keys.Down:
                    case Keys.Left:
                    case Keys.Subtract:
                    case Keys.OemMinus:
                         if(this.orientation == Orientation.Horizontal)
                         {
                              if(keyData == Keys.Down) return base.ProcessDialogKey(keyData);
                         }
                         else
                         {
                              if(keyData == Keys.Left) return base.ProcessDialogKey(keyData);
                         }

                         if(this.orientation == Orientation.Horizontal)
                         {
                              tmpMarkerPosition -= 1;
                         }
                         else
                         {
                              tmpMarkerPosition += 1;
                         }
                         break;

                    case Keys.PageUp:
                         tmpMarkerPosition -= 10;
                         break;

                    case Keys.PageDown:
                         tmpMarkerPosition += 10;
                         break;

                    default:
                         return base.ProcessDialogKey(keyData);
               }

               this.SetMarkerPosition(tmpMarkerPosition);

               return true;
          }


          private void DrawColorMapContent( )
          {
               if(this.colorBitmap != null)
               {
                    using(System.Drawing.Graphics tmpImageGraphics = System.Drawing.Graphics.FromImage(this.colorBitmap))
                    {
                         int tmpBitmapWidth = this.colorBitmap.Size.Width;
                         switch(this.cubeZaxes)
                         {
                              case HuiruiSoft.Drawing.ColorCubeZAxes.Red:
                              case HuiruiSoft.Drawing.ColorCubeZAxes.Green:
                              case HuiruiSoft.Drawing.ColorCubeZAxes.Blue:
                                   System.Drawing.Color tempBrushColor1 = System.Drawing.Color.Empty;
                                   System.Drawing.Color tempBrushColor2 = System.Drawing.Color.Empty;
                                   switch(this.cubeZaxes)
                                   {
                                        case HuiruiSoft.Drawing.ColorCubeZAxes.Red:
                                             tempBrushColor1 = System.Drawing.Color.FromArgb(255, this.currentColor.G, this.currentColor.B);
                                             tempBrushColor2 = System.Drawing.Color.FromArgb(0, this.currentColor.G, this.currentColor.B);
                                             break;

                                        case HuiruiSoft.Drawing.ColorCubeZAxes.Green:
                                             tempBrushColor1 = System.Drawing.Color.FromArgb(this.currentColor.R, 255, this.currentColor.B);
                                             tempBrushColor2 = System.Drawing.Color.FromArgb(this.currentColor.R, 0, this.currentColor.B);
                                             break;

                                        case HuiruiSoft.Drawing.ColorCubeZAxes.Blue:
                                             tempBrushColor1 = System.Drawing.Color.FromArgb(this.currentColor.R, this.currentColor.G, 255);
                                             tempBrushColor2 = System.Drawing.Color.FromArgb(this.currentColor.R, this.currentColor.G, 0);
                                             break;
                                   }

                                   using(System.Drawing.Drawing2D.LinearGradientBrush tmpGradientBrush =
                                        new System.Drawing.Drawing2D.LinearGradientBrush(new System.Drawing.Point(0, 0), new System.Drawing.Point(this.colorBitmap.Width), tempBrushColor1, tempBrushColor2))
                                   {
                                        tmpImageGraphics.FillRectangle(tmpGradientBrush, new System.Drawing.Rectangle(System.Drawing.Point.Empty, this.colorBitmap.Size));
                                   }
                                   break;

                              case HuiruiSoft.Drawing.ColorCubeZAxes.Hue:
                              case HuiruiSoft.Drawing.ColorCubeZAxes.Brightness:
                              case HuiruiSoft.Drawing.ColorCubeZAxes.Saturation:
                                   HuiruiSoft.Drawing.HSBCOLOR tmpHSLColor = new HuiruiSoft.Drawing.HSBCOLOR( );
                                   switch(this.cubeZaxes)
                                   {
                                        case HuiruiSoft.Drawing.ColorCubeZAxes.Hue:
                                             tmpHSLColor.Saturation = 1.0;
                                             tmpHSLColor.Brightness = 1.0;

                                             for(int index = 0; index < tmpBitmapWidth; index++)
                                             {
                                                  tmpHSLColor.Hue = 1.0 - (double)index / tmpBitmapWidth;
                                                  this.colorBitmap.SetPixel(index, 0, HuiruiSoft.Drawing.ColorTranslator.HSBToRGB(tmpHSLColor));
                                             }
                                             break;

                                        case HuiruiSoft.Drawing.ColorCubeZAxes.Saturation:
                                             tmpHSLColor.Hue = this.hsbColor.Hue;
                                             tmpHSLColor.Brightness = this.hsbColor.Brightness;

                                             for(int index = 0; index < tmpBitmapWidth; index++)
                                             {
                                                  tmpHSLColor.Saturation = 1.0 - (double)index / tmpBitmapWidth;
                                                  this.colorBitmap.SetPixel(index, 0, HuiruiSoft.Drawing.ColorTranslator.HSBToRGB(tmpHSLColor));
                                             }
                                             break;

                                        case HuiruiSoft.Drawing.ColorCubeZAxes.Brightness:
                                             tmpHSLColor.Hue = this.hsbColor.Hue;
                                             tmpHSLColor.Saturation = this.hsbColor.Saturation;

                                             for(int index = 0; index < tmpBitmapWidth; index++)
                                             {
                                                  tmpHSLColor.Brightness = 1.0 - (double)index / tmpBitmapWidth;
                                                  this.colorBitmap.SetPixel(index, 0, HuiruiSoft.Drawing.ColorTranslator.HSBToRGB(tmpHSLColor));
                                             }
                                             break;
                                   }
                                   break;

                              case HuiruiSoft.Drawing.ColorCubeZAxes.Luminance:
                              case HuiruiSoft.Drawing.ColorCubeZAxes.A:
                              case HuiruiSoft.Drawing.ColorCubeZAxes.B:
                                   int tmpCIEColorL = this.cieLabColor.L, tmpCIEColorA = this.cieLabColor.A, tmpCIEColorB = this.cieLabColor.B;
                                   switch(this.cubeZaxes)
                                   {
                                        case HuiruiSoft.Drawing.ColorCubeZAxes.Luminance:
                                             for(int index = 0; index < tmpBitmapWidth; index++)
                                             {
                                                  tmpCIEColorL = this.Round(100 - 100 * (double)index / tmpBitmapWidth);
                                                  this.colorBitmap.SetPixel(index, 0, HuiruiSoft.Drawing.ColorTranslator.FromCIELab(tmpCIEColorL, tmpCIEColorA, tmpCIEColorB));
                                             }
                                             break;
                                        case HuiruiSoft.Drawing.ColorCubeZAxes.A:
                                             for(int index = 0; index < tmpBitmapWidth; index++)
                                             {
                                                  tmpCIEColorA = this.Round(127 - 255 * (double)index / tmpBitmapWidth);
                                                  this.colorBitmap.SetPixel(index, 0, HuiruiSoft.Drawing.ColorTranslator.FromCIELab(tmpCIEColorL, tmpCIEColorA, tmpCIEColorB));
                                             }
                                             break;
                                        case HuiruiSoft.Drawing.ColorCubeZAxes.B:
                                             for(int index = 0; index < tmpBitmapWidth; index++)
                                             {
                                                  tmpCIEColorB = this.Round(127 - 255 * (double)index / tmpBitmapWidth);
                                                  this.colorBitmap.SetPixel(index, 0, HuiruiSoft.Drawing.ColorTranslator.FromCIELab(tmpCIEColorL, tmpCIEColorA, tmpCIEColorB));
                                             }
                                             break;
                                   }
                                   break;
                         }
                    }
               }
          }

          private void ResetColorSlider(bool forceRedraw = true)
          {
               if(this.Orientation == Orientation.Vertical)
               {
                    int tmpFillHeight = this.Height - 2 * SliderMarkerSize;
                    switch(this.cubeZaxes)
                    {
                         case HuiruiSoft.Drawing.ColorCubeZAxes.Red:
                              this.markerPosition = tmpFillHeight - this.Round(tmpFillHeight * (double)this.currentColor.R / 255);
                              break;

                         case HuiruiSoft.Drawing.ColorCubeZAxes.Green:
                              this.markerPosition = tmpFillHeight - this.Round(tmpFillHeight * (double)this.currentColor.G / 255);
                              break;

                         case HuiruiSoft.Drawing.ColorCubeZAxes.Blue:
                              this.markerPosition = tmpFillHeight - this.Round(tmpFillHeight * (double)this.currentColor.B / 255);
                              break;

                         case HuiruiSoft.Drawing.ColorCubeZAxes.Hue:
                              this.markerPosition = tmpFillHeight - this.Round(tmpFillHeight * this.hsbColor.Hue);
                              break;

                         case HuiruiSoft.Drawing.ColorCubeZAxes.Saturation:
                              this.markerPosition = tmpFillHeight - this.Round(tmpFillHeight * this.hsbColor.Saturation);
                              break;

                         case HuiruiSoft.Drawing.ColorCubeZAxes.Brightness:
                              this.markerPosition = tmpFillHeight - this.Round(tmpFillHeight * this.hsbColor.Brightness);
                              break;

                         case HuiruiSoft.Drawing.ColorCubeZAxes.Luminance:
                              this.markerPosition = tmpFillHeight - this.Round(tmpFillHeight * (double)this.cieLabColor.L / 100);
                              break;

                         case HuiruiSoft.Drawing.ColorCubeZAxes.A:
                              this.markerPosition = tmpFillHeight - this.Round(tmpFillHeight * (double)(this.cieLabColor.A + 128) / 255);
                              break;

                         case HuiruiSoft.Drawing.ColorCubeZAxes.B:
                              this.markerPosition = tmpFillHeight - this.Round(tmpFillHeight * (double)(this.cieLabColor.B + 128) / 255);
                              break;
                    }
               }
               else
               {
                    int tmpFillWidth = this.Width - 2 * SliderMarkerSize;
                    switch(this.cubeZaxes)
                    {
                         case HuiruiSoft.Drawing.ColorCubeZAxes.Red:
                              this.markerPosition = this.Round(tmpFillWidth * (double)this.currentColor.R / 255);
                              break;

                         case HuiruiSoft.Drawing.ColorCubeZAxes.Green:
                              this.markerPosition = this.Round(tmpFillWidth * (double)this.currentColor.G / 255);
                              break;

                         case HuiruiSoft.Drawing.ColorCubeZAxes.Blue:
                              this.markerPosition = this.Round(tmpFillWidth * (double)this.currentColor.B / 255);
                              break;

                         case HuiruiSoft.Drawing.ColorCubeZAxes.Hue:
                              this.markerPosition = this.Round(tmpFillWidth * this.hsbColor.Hue);
                              break;

                         case HuiruiSoft.Drawing.ColorCubeZAxes.Saturation:
                              this.markerPosition = this.Round(tmpFillWidth * this.hsbColor.Saturation);
                              break;
                         case HuiruiSoft.Drawing.ColorCubeZAxes.Brightness:
                              this.markerPosition = this.Round(tmpFillWidth * this.hsbColor.Brightness);
                              break;

                         case HuiruiSoft.Drawing.ColorCubeZAxes.Luminance:
                              this.markerPosition = this.Round(tmpFillWidth * (double)this.cieLabColor.L / 100);
                              break;

                         case HuiruiSoft.Drawing.ColorCubeZAxes.A:
                              this.markerPosition = this.Round(tmpFillWidth * (double)(this.cieLabColor.A + 128) / 255);
                              break;

                         case HuiruiSoft.Drawing.ColorCubeZAxes.B:
                              this.markerPosition = this.Round(tmpFillWidth * (double)(this.cieLabColor.B + 128) / 255);
                              break;
                    }
               }

               if(forceRedraw)
               {
                    this.DrawColorMapContent( );
                    this.Refresh( );
               }
          }

          private void ResetHSLRGB( )
          {
               if(this.Orientation == Orientation.Vertical)
               {
                    int tmpFillHeight = this.Height - 2 * (SliderMarkerSize + 1);

                    switch(this.cubeZaxes)
                    {
                         case HuiruiSoft.Drawing.ColorCubeZAxes.Red:
                         case HuiruiSoft.Drawing.ColorCubeZAxes.Green:
                         case HuiruiSoft.Drawing.ColorCubeZAxes.Blue:
                              switch(this.cubeZaxes)
                              {
                                   case HuiruiSoft.Drawing.ColorCubeZAxes.Red:
                                        this.currentColor = System.Drawing.Color.FromArgb(255 - this.Round(255 * (double)this.markerPosition / tmpFillHeight), this.currentColor.G, this.currentColor.B);
                                        break;
                                   case HuiruiSoft.Drawing.ColorCubeZAxes.Green:
                                        this.currentColor = System.Drawing.Color.FromArgb(this.currentColor.R, 255 - this.Round(255 * (double)this.markerPosition / tmpFillHeight), this.currentColor.B);
                                        break;
                                   case HuiruiSoft.Drawing.ColorCubeZAxes.Blue:
                                        this.currentColor = System.Drawing.Color.FromArgb(this.currentColor.R, this.currentColor.G, 255 - this.Round(255 * (double)this.markerPosition / tmpFillHeight));
                                        break;
                              }
                              this.hsbColor = HuiruiSoft.Drawing.ColorTranslator.RGBToHSB(this.currentColor);
                              this.cieLabColor = HuiruiSoft.Drawing.ColorTranslator.RGBToCIELab(this.currentColor);
                              break;

                         case HuiruiSoft.Drawing.ColorCubeZAxes.Hue:
                         case HuiruiSoft.Drawing.ColorCubeZAxes.Saturation:
                         case HuiruiSoft.Drawing.ColorCubeZAxes.Brightness:
                              switch(this.cubeZaxes)
                              {
                                   case HuiruiSoft.Drawing.ColorCubeZAxes.Hue:
                                        this.hsbColor.Hue = 1.0 - (double)this.markerPosition / tmpFillHeight;
                                        break;
                                   case HuiruiSoft.Drawing.ColorCubeZAxes.Saturation:
                                        this.hsbColor.Saturation = 1.0 - (double)this.markerPosition / tmpFillHeight;
                                        break;
                                   case HuiruiSoft.Drawing.ColorCubeZAxes.Brightness:
                                        this.hsbColor.Brightness = 1.0 - (double)this.markerPosition / tmpFillHeight;
                                        break;
                              }
                              this.currentColor = HuiruiSoft.Drawing.ColorTranslator.HSBToRGB(this.hsbColor);
                              this.cieLabColor = HuiruiSoft.Drawing.ColorTranslator.RGBToCIELab(this.currentColor);
                              break;

                         case HuiruiSoft.Drawing.ColorCubeZAxes.Luminance:
                         case HuiruiSoft.Drawing.ColorCubeZAxes.A:
                         case HuiruiSoft.Drawing.ColorCubeZAxes.B:
                              switch(this.cubeZaxes)
                              {
                                   case HuiruiSoft.Drawing.ColorCubeZAxes.Luminance:
                                        this.cieLabColor.L = this.Round(100 - (double)this.markerPosition * 100 / tmpFillHeight);
                                        break;
                                   case HuiruiSoft.Drawing.ColorCubeZAxes.A:
                                        this.cieLabColor.A = this.Round(127 - (double)this.markerPosition * 255 / tmpFillHeight);
                                        break;
                                   case HuiruiSoft.Drawing.ColorCubeZAxes.B:
                                        this.cieLabColor.B = this.Round(127 - (double)this.markerPosition * 255 / tmpFillHeight);
                                        break;
                              }
                              this.currentColor = HuiruiSoft.Drawing.ColorTranslator.CIELabToColor(this.cieLabColor);
                              this.hsbColor = HuiruiSoft.Drawing.ColorTranslator.RGBToHSB(this.currentColor);
                              break;
                    }
               }
               else
               {
                    int tmpFillWidth = this.Width - 2 * (SliderMarkerSize + 1);

                    switch(this.cubeZaxes)
                    {
                         case HuiruiSoft.Drawing.ColorCubeZAxes.Red:
                         case HuiruiSoft.Drawing.ColorCubeZAxes.Green:
                         case HuiruiSoft.Drawing.ColorCubeZAxes.Blue:
                              switch(this.cubeZaxes)
                              {
                                   case HuiruiSoft.Drawing.ColorCubeZAxes.Red:
                                        this.currentColor = System.Drawing.Color.FromArgb(this.Round(255 * (double)this.markerPosition / tmpFillWidth), this.currentColor.G, this.currentColor.B);
                                        break;
                                   case HuiruiSoft.Drawing.ColorCubeZAxes.Green:
                                        this.currentColor = System.Drawing.Color.FromArgb(this.currentColor.R, this.Round(255 * (double)this.markerPosition / tmpFillWidth), this.currentColor.B);
                                        break;
                                   case HuiruiSoft.Drawing.ColorCubeZAxes.Blue:
                                        this.currentColor = System.Drawing.Color.FromArgb(this.currentColor.R, this.currentColor.G, this.Round(255 * (double)this.markerPosition / tmpFillWidth));
                                        break;
                              }
                              this.hsbColor = HuiruiSoft.Drawing.ColorTranslator.RGBToHSB(this.currentColor);
                              this.cieLabColor = HuiruiSoft.Drawing.ColorTranslator.RGBToCIELab(this.currentColor);
                              break;

                         case HuiruiSoft.Drawing.ColorCubeZAxes.Hue:
                         case HuiruiSoft.Drawing.ColorCubeZAxes.Saturation:
                         case HuiruiSoft.Drawing.ColorCubeZAxes.Brightness:
                              switch(this.cubeZaxes)
                              {
                                   case HuiruiSoft.Drawing.ColorCubeZAxes.Hue:
                                        this.hsbColor.Hue = (double)this.markerPosition / tmpFillWidth;
                                        break;
                                   case HuiruiSoft.Drawing.ColorCubeZAxes.Saturation:
                                        this.hsbColor.Saturation = (double)this.markerPosition / tmpFillWidth;
                                        break;
                                   case HuiruiSoft.Drawing.ColorCubeZAxes.Brightness:
                                        this.hsbColor.Brightness = (double)this.markerPosition / tmpFillWidth;
                                        break;
                              }
                              this.currentColor = HuiruiSoft.Drawing.ColorTranslator.HSBToRGB(this.hsbColor);
                              this.cieLabColor = HuiruiSoft.Drawing.ColorTranslator.RGBToCIELab(this.currentColor);
                              break;

                         case HuiruiSoft.Drawing.ColorCubeZAxes.Luminance:
                         case HuiruiSoft.Drawing.ColorCubeZAxes.A:
                         case HuiruiSoft.Drawing.ColorCubeZAxes.B:
                              switch(this.cubeZaxes)
                              {
                                   case HuiruiSoft.Drawing.ColorCubeZAxes.Luminance:
                                        this.cieLabColor.L = this.Round((double)this.markerPosition * 100 / tmpFillWidth);
                                        break;
                                   case HuiruiSoft.Drawing.ColorCubeZAxes.A:
                                        this.cieLabColor.A = this.Round((double)this.markerPosition * 255 / tmpFillWidth - 128);
                                        break;
                                   case HuiruiSoft.Drawing.ColorCubeZAxes.B:
                                        this.cieLabColor.B = this.Round((double)this.markerPosition * 255 / tmpFillWidth - 128);
                                        break;
                              }
                              this.currentColor = HuiruiSoft.Drawing.ColorTranslator.CIELabToColor(this.cieLabColor);
                              this.hsbColor = HuiruiSoft.Drawing.ColorTranslator.RGBToHSB(this.currentColor);
                              break;
                    }
               }
          }

          private int Round(double value)
          {
               int tmpRoundValue = (int)value;

               if(((int)(value * 100) % 100) >= 50)
               {
                    tmpRoundValue += 1;
               }

               return tmpRoundValue;
          }
     }
}