/****************************************************************************************************************************************************
 * 文件名: ColorPalette.cs                                                                                                                         **
 * 版  权: Micro Application Copyright (c) 2002-2005 公司开发部                                                                                    **
 * 创建人: 张得斌                                                                                                                                  **
 * 日  期: 2004-01-01                                                                                                                              **
 * 描  述:                                                                                                                                         **
 * 版  本: Version 5.00(v2010.1.6)                                                                                                                 **
 ****************************************************************************************************************************************************/

using System.Windows.Forms;
using System.ComponentModel;

namespace HuiruiSoft.UI.Controls
{
     //[ToolboxItem(true), System.Drawing.ToolboxBitmap(typeof(HuiruiSoft.Shared.ResourceFinder), "Images.ColorPalette.bmp")]
     [DefaultProperty("Value"), DefaultEvent("ValueChanged"), Designer("HuiruiSoft.UI.Controls.Design.FixedSizeDesigner, HuiruiSoft.Design")]
     public class ColorPalette : UserControl
     {
          private int markerPositionX = 0;
          private int markerPositionY = 0;
          private bool mouseIsDown = false;

          private System.Drawing.Bitmap colorPaletteMap;
          private System.Drawing.Color currentColor;
          private HuiruiSoft.Drawing.HSBCOLOR hsbColor;
          private HuiruiSoft.Drawing.CIELabColor labColor;
          private HuiruiSoft.Drawing.ColorCubeZAxes cubeZAxes = HuiruiSoft.Drawing.ColorCubeZAxes.Hue;

          private const int BorderSize = 2;

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


          /// <summary>返回或设置颜色的 Z-Axis。</summary>
          [Browsable(true), Category("外观"), DefaultValue(HuiruiSoft.Drawing.ColorCubeZAxes.Red), Description("返回或设置颜色的 Z-Axis。")]
          public HuiruiSoft.Drawing.ColorCubeZAxes ZAxes
          {
               get
               {
                    return this.cubeZAxes;
               }

               set
               {
                    if(this.cubeZAxes != value)
                    {
                         this.cubeZAxes = value;
                         this.ResetColorPalette( );
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
                    this.labColor = HuiruiSoft.Drawing.ColorTranslator.RGBToCIELab(this.currentColor);

                    this.ResetColorPalette();
               }
          }

          internal HuiruiSoft.Drawing.CIELabColor CIELab
          {
               get
               {
                    return this.labColor;
               }

               set
               {
                    this.labColor = value;
                    this.hsbColor = HuiruiSoft.Drawing.ColorTranslator.RGBToHSB(this.currentColor);
                    this.currentColor = HuiruiSoft.Drawing.ColorTranslator.CIELabToColor(this.labColor);

                    this.ResetColorPalette( );
               }
          }

          public System.Drawing.Color RGBColor
          {
               get
               {
                    return this.currentColor;
               }

               set
               {
                    this.currentColor = value;
                    this.hsbColor = HuiruiSoft.Drawing.ColorTranslator.RGBToHSB(this.currentColor);
                    this.labColor = HuiruiSoft.Drawing.ColorTranslator.RGBToCIELab(this.currentColor);

                    this.ResetColorPalette( );
               }
          }

          public ColorPalette( )
          {
               this.hsbColor = new HuiruiSoft.Drawing.HSBCOLOR( );
               this.hsbColor.Hue = this.hsbColor.Saturation = this.hsbColor.Brightness = 1.0;
               this.labColor = new HuiruiSoft.Drawing.CIELabColor( );
               this.labColor.L = this.labColor.A = this.labColor.B = 0;

               this.cubeZAxes = HuiruiSoft.Drawing.ColorCubeZAxes.Hue;
               this.currentColor = HuiruiSoft.Drawing.ColorTranslator.HSBToRGB(this.hsbColor);

               this.InitializeComponent( );

               base.TabStop = true;
               this.Cursor = System.Windows.Forms.Cursors.Cross;

               base.SetStyle(
                    ControlStyles.UserPaint |
                    ControlStyles.UserMouse |
                    ControlStyles.Selectable |
                    ControlStyles.ResizeRedraw |
                    ControlStyles.DoubleBuffer |
                    ControlStyles.StandardClick |
                    ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.StandardDoubleClick, true);
          }

          protected override void OnLoad(System.EventArgs args)
          {
               base.OnLoad(args);

               if (this.IsHandleCreated)
               {
                    if (this.colorPaletteMap != null)
                    {
                         this.colorPaletteMap.Dispose();
                         this.colorPaletteMap = null;
                    }
                    this.colorPaletteMap = new System.Drawing.Bitmap(this.Width, this.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
               }
          }

          #region 组件设计器生成的代码

          private void InitializeComponent( )
          {
               this.SuspendLayout();
               // 
               // ColorPalette
               // 
               this.Name = "ColorPalette";
               this.Size = new System.Drawing.Size(260, 260);
               this.ResumeLayout(false);

          }

          #endregion

          private void RaiseColorChangedEvent( )
          {
               this.OnColorChanged(new System.EventArgs( ));
          }

          protected virtual void OnColorChanged(System.EventArgs args)
          {
               this.ColorChanged?.Invoke(this, args);
          }

          protected override void OnResize(System.EventArgs eArgs)
          {
               base.OnResize(eArgs);
               base.Size = new System.Drawing.Size(260, 260);
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

          protected override void OnPaint(System.Windows.Forms.PaintEventArgs args)
          {
               if(this.colorPaletteMap != null)
               {
                    args.Graphics.DrawImage(this.colorPaletteMap, 0, 0, this.Width, this.Height);
               }

               args.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

               using(var tmpDrawPenObject = new System.Drawing.Pen(System.Drawing.Color.Black))
               {
                    if((ModifierKeys & Keys.Shift) != 0)
                    {
                         float dx = (float)(this.Width - 3) / 8f, dy = (float)(this.Height - 3) / 8f, x = 1f, y = 1f;
                         tmpDrawPenObject.Brush = new System.Drawing.Drawing2D.HatchBrush(System.Drawing.Drawing2D.HatchStyle.SmallCheckerBoard, System.Drawing.Color.FromArgb(80, 255, 255, 255), System.Drawing.Color.FromArgb(0, 0, 0, 0));

                         for(int i = 0; i <= 8; i++, x += dx, y += dy)
                         {
                              args.Graphics.DrawLine(tmpDrawPenObject, 0, (int)y, this.Width, (int)y);
                              args.Graphics.DrawLine(tmpDrawPenObject, (int)x, 0, (int)x, this.Height);
                         }
                    }

                    var tmpHslColor = this.GetColor(this.markerPositionX, this.markerPositionY);

                    if(tmpHslColor.Brightness < 200.0 / 255.0)
                    {
                         tmpDrawPenObject.Color = System.Drawing.Color.White;
                    }
                    else if(tmpHslColor.Hue < 26.0 / 360.0 || tmpHslColor.Hue > 200.0 / 360.0)
                    {
                         tmpDrawPenObject.Color = (tmpHslColor.Saturation > 70.0 / 255.0) ? System.Drawing.Color.White : System.Drawing.Color.Black;
                    }
                    else
                    {
                         tmpDrawPenObject.Color = System.Drawing.Color.Black;
                    }

                    args.Graphics.DrawEllipse(tmpDrawPenObject, this.GetCursorMarkerBounds( ));
               }
          }

          protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs args)
          {
               base.OnMouseDown(args);

               if(this.Enabled && args.Button == System.Windows.Forms.MouseButtons.Left)
               {
                    this.mouseIsDown = true;
                    this.SetMarkerPosition(args.X - BorderSize, args.Y - BorderSize);
               }
          }

          protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs args)
          {
               base.OnMouseMove(args);

               if(this.mouseIsDown)
               {
                    this.SetMarkerPosition(args.X - BorderSize, args.Y - BorderSize);
               }
          }

          protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs args)
          {
               base.OnMouseUp(args);

               this.mouseIsDown = false;
               if(args.Button == System.Windows.Forms.MouseButtons.Left)
               {
                    this.SetMarkerPosition(args.X - BorderSize, args.Y - BorderSize);
               }
          }

          protected override bool ProcessDialogKey(Keys keyData)
          {
               if(this.Enabled)
               {
                    int tmpMarkerPositionX = this.markerPositionX, tmpMarkerPositionY = this.markerPositionY;
                    switch(keyData)
                    {
                         case Keys.Up:
                              tmpMarkerPositionY -= 1;
                              break;

                         case Keys.PageUp:
                              tmpMarkerPositionY -= 10;
                              break;

                         case Keys.Down:
                              tmpMarkerPositionY += 1;
                              break;

                         case Keys.PageDown:
                              tmpMarkerPositionY += 10;
                              break;

                         case Keys.Left:
                              tmpMarkerPositionX -= 1;
                              break;

                         case Keys.Right:
                              tmpMarkerPositionX += 1;
                              break;

                         default:
                              return base.ProcessDialogKey(keyData);
                    }

                    this.SetMarkerPosition(tmpMarkerPositionX, tmpMarkerPositionY);
               }

               return true;
          }

          private System.Drawing.Rectangle GetCursorMarkerBounds( )
          {
               return new System.Drawing.Rectangle(this.markerPositionX - 5, this.markerPositionY - 5, 10, 10);
          }

          private void SetMarkerPosition(int markerPositionX, int markerPositionY)
          {
               if(markerPositionX < 0) markerPositionX = 0;
               if(markerPositionY < 0) markerPositionY = 0;
               if(markerPositionX > this.Width - 2 * BorderSize) markerPositionX = this.Width - 2 * BorderSize;
               if(markerPositionY > this.Height - 2 * BorderSize) markerPositionY = this.Height - 2 * BorderSize;

               if(markerPositionX != this.markerPositionX || markerPositionY != this.markerPositionY)
               {
                    this.Invalidate(System.Drawing.Rectangle.Inflate(this.GetCursorMarkerBounds( ), 2, 2));
                    this.markerPositionX = markerPositionX; this.markerPositionY = markerPositionY;
                    this.Invalidate(System.Drawing.Rectangle.Inflate(this.GetCursorMarkerBounds( ), 2, 2));

                    this.Update( );

                    this.ResetHSLRGB( );
                    this.RaiseColorChangedEvent( );
               }
          }

          private void ResetHSLRGB( )
          {
               int tmpRGBColorR, tmpRGBColorG, tmpRGBColorB;

               var tmpBoundWidth = (double)(this.Width - 2 * BorderSize);
               var tmpBoundHeight = (double)(this.Height - 2 * BorderSize);

               switch(this.cubeZAxes)
               {
                    case HuiruiSoft.Drawing.ColorCubeZAxes.Red:
                    case HuiruiSoft.Drawing.ColorCubeZAxes.Green:
                    case HuiruiSoft.Drawing.ColorCubeZAxes.Blue:
                         switch(this.cubeZAxes)
                         {
                              case HuiruiSoft.Drawing.ColorCubeZAxes.Red:
                                   tmpRGBColorB = this.Round(255 * (0.0 + (double)this.markerPositionX / tmpBoundWidth));
                                   tmpRGBColorG = this.Round(255 * (1.0 - (double)this.markerPositionY / tmpBoundHeight));
                                   this.currentColor = System.Drawing.Color.FromArgb(this.currentColor.R, tmpRGBColorG, tmpRGBColorB);
                                   break;

                              case HuiruiSoft.Drawing.ColorCubeZAxes.Green:
                                   tmpRGBColorB = this.Round(255 * (0.0 + (double)this.markerPositionX / tmpBoundWidth));
                                   tmpRGBColorR = this.Round(255 * (1.0 - (double)this.markerPositionY / tmpBoundHeight));
                                   this.currentColor = System.Drawing.Color.FromArgb(tmpRGBColorR, this.currentColor.G, tmpRGBColorB);
                                   break;

                              case HuiruiSoft.Drawing.ColorCubeZAxes.Blue:
                                   tmpRGBColorR = this.Round(255 * (0.0 + (double)this.markerPositionX / tmpBoundWidth));
                                   tmpRGBColorG = this.Round(255 * (1.0 - (double)this.markerPositionY / tmpBoundHeight));
                                   this.currentColor = System.Drawing.Color.FromArgb(tmpRGBColorR, tmpRGBColorG, this.currentColor.B);
                                   break;
                         }
                         this.hsbColor = HuiruiSoft.Drawing.ColorTranslator.RGBToHSB(this.currentColor);
                         this.labColor = HuiruiSoft.Drawing.ColorTranslator.RGBToCIELab(this.currentColor);

                         break;
                    case HuiruiSoft.Drawing.ColorCubeZAxes.Hue:
                    case HuiruiSoft.Drawing.ColorCubeZAxes.Saturation:
                    case HuiruiSoft.Drawing.ColorCubeZAxes.Brightness:
                         switch(this.cubeZAxes)
                         {
                              case HuiruiSoft.Drawing.ColorCubeZAxes.Hue:
                                   this.hsbColor.Saturation = (double)this.markerPositionX / tmpBoundWidth;
                                   this.hsbColor.Brightness = 1.0 - (double)this.markerPositionY / tmpBoundHeight;
                                   break;

                              case HuiruiSoft.Drawing.ColorCubeZAxes.Saturation:
                                   this.hsbColor.Hue = (double)this.markerPositionX / tmpBoundWidth;
                                   this.hsbColor.Brightness = 1.0 - (double)this.markerPositionY / tmpBoundHeight;
                                   break;

                              case HuiruiSoft.Drawing.ColorCubeZAxes.Brightness:
                                   this.hsbColor.Hue = (double)this.markerPositionX / tmpBoundWidth;
                                   this.hsbColor.Saturation = 1.0 - (double)this.markerPositionY / tmpBoundHeight;
                                   break;
                         }
                         this.currentColor = HuiruiSoft.Drawing.ColorTranslator.HSBToRGB(this.hsbColor);
                         this.labColor = HuiruiSoft.Drawing.ColorTranslator.RGBToCIELab(this.currentColor);

                         break;
                    case HuiruiSoft.Drawing.ColorCubeZAxes.Luminance:
                    case HuiruiSoft.Drawing.ColorCubeZAxes.A:
                    case HuiruiSoft.Drawing.ColorCubeZAxes.B:
                         switch(this.cubeZAxes)
                         {
                              case HuiruiSoft.Drawing.ColorCubeZAxes.Luminance:
                                   this.labColor.A = this.Round(255 * (double)this.markerPositionX / tmpBoundWidth - 128);
                                   this.labColor.B = this.Round(127 - 255 * (double)this.markerPositionY / tmpBoundHeight);
                                   break;

                              case HuiruiSoft.Drawing.ColorCubeZAxes.A:
                                   this.labColor.L = this.Round(100 - (double)this.markerPositionY * 100 / tmpBoundHeight);
                                   this.labColor.B = this.Round(255 * (double)this.markerPositionX / tmpBoundWidth - 128);
                                   break;

                              case HuiruiSoft.Drawing.ColorCubeZAxes.B:
                                   this.labColor.L = this.Round(100 - (double)this.markerPositionY * 100 / tmpBoundHeight);
                                   this.labColor.A = this.Round(255 * (double)this.markerPositionX / tmpBoundWidth - 128);
                                   break;
                         }

                         this.currentColor = HuiruiSoft.Drawing.ColorTranslator.CIELabToColor(this.labColor);
                         this.hsbColor = HuiruiSoft.Drawing.ColorTranslator.RGBToHSB(this.currentColor);
                         break;
               }
          }

          private void ResetColorPalette(bool forceRedraw = true)
          {
               if (this.IsHandleCreated)
               {
                    this.ResetHottestMarker();

                    if (forceRedraw)
                    {
                         this.DrawColorMapContent();
                    }
               }
          }

          private void ResetHottestMarker( )
          {
               double tmpBoundWidth = (double)(this.Width - 2 * BorderSize);
               double tmpBoundHeight = (double)(this.Height - 2 * BorderSize);

               switch(this.cubeZAxes)
               {
                    case HuiruiSoft.Drawing.ColorCubeZAxes.Hue:
                         this.markerPositionX = this.Round(tmpBoundWidth * this.hsbColor.Saturation);
                         this.markerPositionY = this.Round(tmpBoundHeight * (1.0 - this.hsbColor.Brightness));
                         break;

                    case HuiruiSoft.Drawing.ColorCubeZAxes.Saturation:
                         this.markerPositionX = this.Round(tmpBoundWidth * this.hsbColor.Hue);
                         this.markerPositionY = this.Round(tmpBoundHeight * (1.0 - this.hsbColor.Brightness));
                         break;

                    case HuiruiSoft.Drawing.ColorCubeZAxes.Brightness:
                         this.markerPositionX = this.Round(tmpBoundWidth * this.hsbColor.Hue);
                         this.markerPositionY = this.Round(tmpBoundHeight * (1.0 - this.hsbColor.Saturation));
                         break;

                    case HuiruiSoft.Drawing.ColorCubeZAxes.Red:
                         this.markerPositionX = this.Round(tmpBoundWidth * this.currentColor.B / 255);
                         this.markerPositionY = this.Round(tmpBoundHeight * (1.0 - this.currentColor.G / 255));
                         break;
                    case HuiruiSoft.Drawing.ColorCubeZAxes.Green:
                         this.markerPositionX = this.Round(tmpBoundWidth * this.currentColor.B / 255);
                         this.markerPositionY = this.Round(tmpBoundHeight * (1.0 - this.currentColor.R / 255));
                         break;

                    case HuiruiSoft.Drawing.ColorCubeZAxes.Blue:
                         this.markerPositionX = this.Round(tmpBoundWidth * this.currentColor.R / 255);
                         this.markerPositionY = this.Round(tmpBoundHeight * (1.0 - this.currentColor.G / 255));
                         break;

                    case HuiruiSoft.Drawing.ColorCubeZAxes.Luminance:
                         this.markerPositionX = this.Round(tmpBoundWidth * (this.labColor.A + 128) / 255);
                         this.markerPositionY = this.Round(127 - tmpBoundHeight * (this.labColor.B) / 255);
                         break;

                    case HuiruiSoft.Drawing.ColorCubeZAxes.A:
                         this.markerPositionX = this.Round(tmpBoundWidth * (this.labColor.B + 128) / 255);
                         this.markerPositionY = this.Round(255 - tmpBoundHeight * this.labColor.L / 100);
                         break;

                    case HuiruiSoft.Drawing.ColorCubeZAxes.B:
                         this.markerPositionX = this.Round(tmpBoundWidth * (this.labColor.A + 128) / 255);
                         this.markerPositionY = this.Round(255 - tmpBoundHeight * this.labColor.L / 100);
                         break;
               }
          }


          private void DrawColorMapContent( )
          {
               if(this.colorPaletteMap != null)
               {
                    System.Drawing.Rectangle tmpFillBounds, tmpLinearBounds;
                    System.Drawing.Drawing2D.LinearGradientBrush tmpGradientBrush;

                    int tmpBoundWidth = this.Width - 2 * BorderSize, tmpBoundHeight = this.Height - 2 * BorderSize;

                    using(var tmpImageGraphics = System.Drawing.Graphics.FromImage(this.colorPaletteMap))
                    {
                         switch(this.cubeZAxes)
                         {
                              case HuiruiSoft.Drawing.ColorCubeZAxes.Red:
                              case HuiruiSoft.Drawing.ColorCubeZAxes.Green:
                              case HuiruiSoft.Drawing.ColorCubeZAxes.Blue:
                                   int tmpRGBColorR, tmpRGBColorG, tmpRGBColorB;
                                   tmpFillBounds = tmpLinearBounds = new System.Drawing.Rectangle(BorderSize, BorderSize, tmpBoundWidth, 1);
                                   tmpGradientBrush = new System.Drawing.Drawing2D.LinearGradientBrush(tmpLinearBounds, this.currentColor, this.currentColor, 0, false);

                                   switch(this.cubeZAxes)
                                   {
                                        case HuiruiSoft.Drawing.ColorCubeZAxes.Red:
                                             tmpRGBColorR = this.currentColor.R;
                                             for(int index = 0; index < tmpBoundHeight; index++)
                                             {
                                                  tmpFillBounds.Y = index + BorderSize;
                                                  tmpRGBColorG = this.Round(255 - (255 * (double)index / tmpBoundHeight));

                                                  tmpGradientBrush.LinearColors = new System.Drawing.Color[ ] { System.Drawing.Color.FromArgb(tmpRGBColorR, tmpRGBColorG, 0), System.Drawing.Color.FromArgb(tmpRGBColorR, tmpRGBColorG, 255) };
                                                  tmpImageGraphics.FillRectangle(tmpGradientBrush, tmpFillBounds);
                                             }
                                             break;

                                        case HuiruiSoft.Drawing.ColorCubeZAxes.Green:
                                             tmpRGBColorG = this.currentColor.G;
                                             for(int index = 0; index < tmpBoundHeight; index++)
                                             {
                                                  tmpFillBounds.Y = index + BorderSize;
                                                  tmpRGBColorR = this.Round(255 - (255 * (double)index / tmpBoundHeight));

                                                  tmpGradientBrush.LinearColors = new System.Drawing.Color[ ] { System.Drawing.Color.FromArgb(tmpRGBColorR, tmpRGBColorG, 0), System.Drawing.Color.FromArgb(tmpRGBColorR, tmpRGBColorG, 255) };
                                                  tmpImageGraphics.FillRectangle(tmpGradientBrush, tmpFillBounds);
                                             }
                                             break;

                                        case HuiruiSoft.Drawing.ColorCubeZAxes.Blue:
                                             tmpRGBColorB = this.currentColor.B;
                                             for(int index = 0; index < tmpBoundHeight; index++)
                                             {
                                                  tmpFillBounds.Y = index + BorderSize;
                                                  tmpRGBColorG = this.Round(255 - (255 * (double)index / tmpBoundHeight));

                                                  tmpGradientBrush.LinearColors = new System.Drawing.Color[ ] { System.Drawing.Color.FromArgb(0, tmpRGBColorG, tmpRGBColorB), System.Drawing.Color.FromArgb(255, tmpRGBColorG, tmpRGBColorB) };
                                                  tmpImageGraphics.FillRectangle(tmpGradientBrush, tmpFillBounds);
                                             }
                                             break;
                                   }
                                   break;

                              case HuiruiSoft.Drawing.ColorCubeZAxes.Hue:
                              case HuiruiSoft.Drawing.ColorCubeZAxes.Brightness:
                              case HuiruiSoft.Drawing.ColorCubeZAxes.Saturation:
                                   var tmpHslStart = new HuiruiSoft.Drawing.HSBCOLOR( );
                                   var tmpHslEnd = new HuiruiSoft.Drawing.HSBCOLOR( );
                                   tmpFillBounds = tmpLinearBounds = new System.Drawing.Rectangle(BorderSize, BorderSize, tmpBoundWidth, 1);
                                   tmpGradientBrush = new System.Drawing.Drawing2D.LinearGradientBrush(tmpLinearBounds, this.currentColor, this.currentColor, 0, false);

                                   switch(this.cubeZAxes)
                                   {
                                        case HuiruiSoft.Drawing.ColorCubeZAxes.Hue:
                                             tmpHslStart.Hue = tmpHslEnd.Hue = this.hsbColor.Hue;
                                             tmpHslStart.Saturation = 0.0;
                                             tmpHslEnd.Saturation = 1.0;

                                             for(int index = 0; index < tmpBoundHeight; index++)
                                             {
                                                  tmpFillBounds.Y = index + BorderSize;
                                                  tmpHslStart.Brightness = tmpHslEnd.Brightness = 1.0 - (double)index / tmpBoundHeight;

                                                  tmpGradientBrush.LinearColors = new System.Drawing.Color[ ] { HuiruiSoft.Drawing.ColorTranslator.HSBToRGB(tmpHslStart), HuiruiSoft.Drawing.ColorTranslator.HSBToRGB(tmpHslEnd) };
                                                  tmpImageGraphics.FillRectangle(tmpGradientBrush, tmpFillBounds);
                                             }
                                             break;

                                        case HuiruiSoft.Drawing.ColorCubeZAxes.Saturation:
                                             tmpHslStart.Saturation = tmpHslEnd.Saturation = this.hsbColor.Saturation;
                                             tmpHslStart.Brightness = 1.0;
                                             tmpHslEnd.Brightness = 0.0;

                                             tmpGradientBrush.RotateTransform(90);
                                             tmpFillBounds = tmpLinearBounds = new System.Drawing.Rectangle(BorderSize, BorderSize, 1, tmpBoundHeight);
                                             for(int index = 0; index < tmpBoundWidth; index++)
                                             {
                                                  tmpFillBounds.X = index + BorderSize;
                                                  tmpHslStart.Hue = tmpHslEnd.Hue = (double)index / tmpBoundWidth;

                                                  tmpGradientBrush.LinearColors = new System.Drawing.Color[ ] { HuiruiSoft.Drawing.ColorTranslator.HSBToRGB(tmpHslStart), HuiruiSoft.Drawing.ColorTranslator.HSBToRGB(tmpHslEnd) };
                                                  tmpImageGraphics.FillRectangle(tmpGradientBrush, tmpFillBounds);
                                             }
                                             break;

                                        case HuiruiSoft.Drawing.ColorCubeZAxes.Brightness:
                                             tmpHslStart.Brightness = tmpHslEnd.Brightness = this.hsbColor.Brightness;
                                             tmpHslStart.Saturation = 1.0;
                                             tmpHslEnd.Saturation = 0.0;
                                             tmpFillBounds = tmpLinearBounds = new System.Drawing.Rectangle(BorderSize, BorderSize, 1, tmpBoundHeight);
                                             tmpGradientBrush.RotateTransform(90);

                                             for(int index = 0; index < tmpBoundWidth; index++)
                                             {
                                                  tmpFillBounds.X = index + BorderSize;
                                                  tmpHslStart.Hue = tmpHslEnd.Hue = (double)index / tmpBoundWidth;

                                                  tmpGradientBrush.LinearColors = new System.Drawing.Color[ ] { HuiruiSoft.Drawing.ColorTranslator.HSBToRGB(tmpHslStart), HuiruiSoft.Drawing.ColorTranslator.HSBToRGB(tmpHslEnd) };
                                                  tmpImageGraphics.FillRectangle(tmpGradientBrush, tmpFillBounds);
                                             }
                                             break;
                                   }
                                   break;

                              case HuiruiSoft.Drawing.ColorCubeZAxes.Luminance:
                              case HuiruiSoft.Drawing.ColorCubeZAxes.A:
                              case HuiruiSoft.Drawing.ColorCubeZAxes.B:
                                   HuiruiSoft.Drawing.CIELabColor tmpLabColor = new HuiruiSoft.Drawing.CIELabColor( );
                                   switch(this.cubeZAxes)
                                   {
                                        case HuiruiSoft.Drawing.ColorCubeZAxes.Luminance:
                                             tmpLabColor.L = this.labColor.L;
                                             for(int xAxis = 0; xAxis < 256; xAxis++)
                                             {
                                                  tmpLabColor.A = this.Round((double)xAxis * 255 / tmpBoundWidth - 128);
                                                  for(int yAxis = 0; yAxis < 256; yAxis++)
                                                  {
                                                       tmpLabColor.B = this.Round(127 - (double)yAxis * 255 / tmpBoundHeight);
                                                       this.colorPaletteMap.SetPixel(BorderSize + xAxis, BorderSize + yAxis, HuiruiSoft.Drawing.ColorTranslator.CIELabToColor(tmpLabColor));
                                                  }
                                             }
                                             break;

                                        case HuiruiSoft.Drawing.ColorCubeZAxes.A:
                                             tmpLabColor.A = this.labColor.A;

                                             for(int xAxis = 0; xAxis < 256; xAxis++)
                                             {
                                                  tmpLabColor.B = this.Round((double)xAxis * 255 / tmpBoundWidth - 128);
                                                  for(int yAxis = 0; yAxis < 256; yAxis++)
                                                  {
                                                       tmpLabColor.L = this.Round(100 - (double)yAxis * 100 / tmpBoundHeight);
                                                       this.colorPaletteMap.SetPixel(BorderSize + xAxis, BorderSize + yAxis, HuiruiSoft.Drawing.ColorTranslator.CIELabToColor(tmpLabColor));
                                                  }
                                             }
                                             break;

                                        case HuiruiSoft.Drawing.ColorCubeZAxes.B:
                                             tmpLabColor.B = this.labColor.B;

                                             for(int xAxis = 0; xAxis < 256; xAxis++)
                                             {
                                                  tmpLabColor.A = this.Round((double)xAxis * 255 / tmpBoundWidth - 128);
                                                  for(int yAxis = 0; yAxis < 256; yAxis++)
                                                  {
                                                       tmpLabColor.L = this.Round(100 - (double)yAxis * 100 / tmpBoundHeight);
                                                       this.colorPaletteMap.SetPixel(BorderSize + xAxis, BorderSize + yAxis, HuiruiSoft.Drawing.ColorTranslator.CIELabToColor(tmpLabColor));
                                                  }
                                             }
                                             break;
                                   }
                                   break;
                         }

                         using(var tmpDrawPenObject = new System.Drawing.Pen(System.Drawing.Color.FromArgb(172, 168, 153)))
                         {
                              var tempLeftTop = new System.Drawing.Point(0, 0);
                              var tempRightTop = new System.Drawing.Point(this.Width - BorderSize, 0);
                              var tempLeftBottom = new System.Drawing.Point(0, this.Height - BorderSize);
                              var tempRightBottom = new System.Drawing.Point(this.Width - BorderSize, this.Height - BorderSize);

                              tmpImageGraphics.DrawLine(tmpDrawPenObject, tempLeftTop, tempRightTop);	          //	Draw top line
                              tmpImageGraphics.DrawLine(tmpDrawPenObject, tempLeftTop, tempLeftBottom);	          //	Draw left hand line

                              tmpDrawPenObject.Color = System.Drawing.Color.White;
                              tmpImageGraphics.DrawLine(tmpDrawPenObject, tempRightTop, tempRightBottom);        //	Draw right hand line
                              tmpImageGraphics.DrawLine(tmpDrawPenObject, tempLeftBottom, tempRightBottom);        //	Draw bottome line

                              tmpDrawPenObject.Color = System.Drawing.Color.Black;
                              var tmpInnerBorder = new System.Drawing.Rectangle(tempLeftTop, new System.Drawing.Size(System.Math.Abs(tempRightBottom.X - tempLeftBottom.X), System.Math.Abs(tempRightBottom.Y - tempLeftTop.Y)));
                              tmpInnerBorder.Inflate(-1, -1);
                              tmpImageGraphics.DrawRectangle(tmpDrawPenObject, tmpInnerBorder);	//	Draw inner black rectangle
                         }
                    }

                    this.Refresh( );
               }
          }


          private HuiruiSoft.Drawing.HSBCOLOR GetColor(int markerPositionX, int markerPositionY)
          {
               double tmpXcoordinate = (double)markerPositionX;
               double tmpYcoordinate = (double)markerPositionY;
               double tmpBoundWidth = (double)(this.Width - 2 * BorderSize);
               double tmpBoundHeight = (double)(this.Height - 2 * BorderSize);

               var tmpHslColor = new HuiruiSoft.Drawing.HSBCOLOR( );

               switch(this.cubeZAxes)
               {
                    case HuiruiSoft.Drawing.ColorCubeZAxes.Hue:
                         tmpHslColor.Hue = this.hsbColor.Hue;
                         tmpHslColor.Saturation = tmpXcoordinate / tmpBoundWidth;
                         tmpHslColor.Brightness = 1.0 - tmpYcoordinate / tmpBoundHeight;
                         break;

                    case HuiruiSoft.Drawing.ColorCubeZAxes.Saturation:
                         tmpHslColor.Saturation = this.hsbColor.Saturation;
                         tmpHslColor.Hue = tmpXcoordinate / tmpBoundWidth;
                         tmpHslColor.Brightness = 1.0 - tmpYcoordinate / tmpBoundHeight;
                         break;

                    case HuiruiSoft.Drawing.ColorCubeZAxes.Brightness:
                         tmpHslColor.Brightness = this.hsbColor.Brightness;
                         tmpHslColor.Hue = tmpXcoordinate / tmpBoundWidth;
                         tmpHslColor.Saturation = 1.0 - tmpYcoordinate / tmpBoundHeight;
                         break;

                    case HuiruiSoft.Drawing.ColorCubeZAxes.Red:
                    case HuiruiSoft.Drawing.ColorCubeZAxes.Green:
                    case HuiruiSoft.Drawing.ColorCubeZAxes.Blue:
                         int tmpColorX = this.Round(255 * tmpXcoordinate / tmpXcoordinate);
                         int tmpColorY = this.Round(255 * (1.0 - tmpYcoordinate / tmpBoundHeight));

                         if(tmpColorX < 000) tmpColorX = 0;
                         if(tmpColorY < 000) tmpColorY = 0;
                         if(tmpColorX > 255) tmpColorX = 255;
                         if(tmpColorY > 255) tmpColorY = 255;

                         switch(this.cubeZAxes)
                         {
                              case HuiruiSoft.Drawing.ColorCubeZAxes.Red:
                                   tmpHslColor = HuiruiSoft.Drawing.ColorTranslator.RGBToHSB(System.Drawing.Color.FromArgb(this.currentColor.R, tmpColorY, tmpColorX));
                                   break;
                              case HuiruiSoft.Drawing.ColorCubeZAxes.Green:
                                   tmpHslColor = HuiruiSoft.Drawing.ColorTranslator.RGBToHSB(System.Drawing.Color.FromArgb(tmpColorY, this.currentColor.G, tmpColorX));
                                   break;
                              case HuiruiSoft.Drawing.ColorCubeZAxes.Blue:
                                   tmpHslColor = HuiruiSoft.Drawing.ColorTranslator.RGBToHSB(System.Drawing.Color.FromArgb(tmpColorX, tmpColorY, this.currentColor.B));
                                   break;
                         }
                         break;

                    case HuiruiSoft.Drawing.ColorCubeZAxes.Luminance:
                    case HuiruiSoft.Drawing.ColorCubeZAxes.A:
                    case HuiruiSoft.Drawing.ColorCubeZAxes.B:
                         HuiruiSoft.Drawing.CIELabColor tmpLabColor = new HuiruiSoft.Drawing.CIELabColor( );

                         switch(this.cubeZAxes)
                         {
                              case HuiruiSoft.Drawing.ColorCubeZAxes.Luminance:
                                   tmpLabColor.L = this.labColor.L;
                                   tmpLabColor.A = this.Round((double)255 * tmpXcoordinate / tmpBoundWidth - 128);
                                   tmpLabColor.B = this.Round(127 - (double)255 * tmpYcoordinate / tmpBoundHeight);
                                   break;
                              case HuiruiSoft.Drawing.ColorCubeZAxes.A:
                                   tmpLabColor.L = this.Round(tmpYcoordinate * 255 / tmpBoundHeight);
                                   tmpLabColor.A = this.labColor.A;
                                   tmpLabColor.B = this.Round((double)255 * tmpXcoordinate / tmpBoundWidth - 128);
                                   break;
                              case HuiruiSoft.Drawing.ColorCubeZAxes.B:
                                   tmpLabColor.L = this.Round(tmpYcoordinate * 255 / tmpBoundHeight);
                                   tmpLabColor.A = this.Round((double)255 * tmpXcoordinate / tmpBoundWidth - 128);
                                   tmpLabColor.B = this.labColor.B;
                                   break;
                         }
                         tmpHslColor = HuiruiSoft.Drawing.ColorTranslator.RGBToHSB(HuiruiSoft.Drawing.ColorTranslator.CIELabToColor(tmpLabColor));

                         break;
               }

               return tmpHslColor;
          }

          private int Round(double pOrigValue)
          {
               int tmpRoundValue = (int)pOrigValue;

               if(((int)(pOrigValue * 100) % 100) >= 50)
               {
                    tmpRoundValue += 1;
               }

               return tmpRoundValue;
          }
     }
}