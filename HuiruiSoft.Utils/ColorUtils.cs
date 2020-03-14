

namespace HuiruiSoft.Utils
{
     public static class ColorUtils
     {
          private static ColorInfo colorInfo = new ColorInfo();

          protected class ColorInfo
          {
               public int ButtonFaceColorPart, HighlightColorPart, WindowColorPart;
          }

          public static System.Drawing.Color LightenColor(System.Drawing.Color baseColor, double factor)
          {
               if (factor <= 0.0 || factor > 1.0)
               {
                    return baseColor;
               }

               unchecked
               {
                    byte r = (byte)((255 - baseColor.R) * factor + baseColor.R);
                    byte g = (byte)((255 - baseColor.G) * factor + baseColor.G);
                    byte b = (byte)((255 - baseColor.B) * factor + baseColor.B);

                    return System.Drawing.Color.FromArgb(r, g, b);
               }
          }

          public static System.Drawing.Color DarkenColor(System.Drawing.Color baseColor, double factor)
          {
               if (factor <= 0.0 || factor > 1.0)
               {
                    return baseColor;
               }

               unchecked
               {
                    byte r = (byte)(baseColor.R - baseColor.R * factor);
                    byte g = (byte)(baseColor.G - baseColor.G * factor);
                    byte b = (byte)(baseColor.B - baseColor.B * factor);

                    return System.Drawing.Color.FromArgb(r, g, b);
               }
          }

          public static System.Drawing.Color ColorToGrayscale(System.Drawing.Color color)
          {
               var tmpColorGray = (int)(0.3f * color.R + 0.59f * color.G + 0.11f * color.B);
               if (tmpColorGray >= 256)
               {
                    tmpColorGray = 255;
               }

               return System.Drawing.Color.FromArgb(tmpColorGray, tmpColorGray, tmpColorGray);
          }

          public static System.Drawing.Color ColorTowards(System.Drawing.Color color, System.Drawing.Color baseColor, double factor)
          {
               var tmpColorGray = (int)(0.3f * baseColor.R + 0.59f * baseColor.G + 0.11f * baseColor.B);

               return tmpColorGray < 128 ? DarkenColor(color, factor) : LightenColor(color, factor);
          }

          public static System.Drawing.Color ColorTowardsGrayscale(System.Drawing.Color color, System.Drawing.Color baseColor, double factor)
          {
               return ColorToGrayscale(ColorTowards(color, baseColor, factor));
          }

          public static bool IsDarkColor(System.Drawing.Color color)
          {
               var tmpGrayColor = ColorToGrayscale(color);
               return (tmpGrayColor.R < 128);
          }

          public static System.Drawing.Color ColorMiddle(System.Drawing.Color color1, System.Drawing.Color color2)
          {
               return System.Drawing.Color.FromArgb((color1.A + color2.A) / 2, (color1.R + color2.R) / 2, (color1.G + color2.G) / 2, (color1.B + color2.B) / 2);
          }

          public static System.Drawing.Drawing2D.GraphicsPath CreateRoundedRectangle(int x, int y, int width, int height, int radius)
          {
               var tmpRoundedPath = new System.Drawing.Drawing2D.GraphicsPath();

               tmpRoundedPath.AddLine(x + radius, y, x + width - radius * 2, y);
               tmpRoundedPath.AddArc(x + width - radius * 2, y, radius * 2, radius * 2, 270.0f, 90.0f);
               tmpRoundedPath.AddLine(x + width, y + radius, x + width, y + height - radius * 2);
               tmpRoundedPath.AddArc(x + width - radius * 2, y + height - radius * 2, radius * 2, radius * 2, 0.0f, 90.0f);
               tmpRoundedPath.AddLine(x + width - radius * 2, y + height, x + radius, y + height);
               tmpRoundedPath.AddArc(x, y + height - radius * 2, radius * 2, radius * 2, 90.0f, 90.0f);
               tmpRoundedPath.AddLine(x, y + height - radius * 2, x, y + radius);
               tmpRoundedPath.AddArc(x, y, radius * 2, radius * 2, 180.0f, 90.0f);

               tmpRoundedPath.CloseFigure();

               return tmpRoundedPath;
          }

          public static System.Drawing.Drawing2D.GraphicsPath CreateRoundedRectangle(System.Drawing.Rectangle rectangle, int radius)
          {
               var tmpRoundedPath = new System.Drawing.Drawing2D.GraphicsPath();

               tmpRoundedPath.AddArc(rectangle.X, rectangle.Y, radius * 2, radius * 2, 180, 90);
               tmpRoundedPath.AddLine(rectangle.X + radius, rectangle.Y, rectangle.Right - radius * 2, rectangle.Y);
               tmpRoundedPath.AddArc(rectangle.X + rectangle.Width - radius * 2, rectangle.Y, radius * 2, radius * 2, 270, 90);
               tmpRoundedPath.AddLine(rectangle.Right, rectangle.Y + radius * 2, rectangle.Right, rectangle.Y + rectangle.Height - radius * 2);
               tmpRoundedPath.AddArc(rectangle.X + rectangle.Width - radius * 2, rectangle.Y + rectangle.Height - radius * 2, radius * 2, radius * 2, 0, 90);
               tmpRoundedPath.AddLine(rectangle.Right - radius * 2, rectangle.Bottom, rectangle.X + radius * 2, rectangle.Bottom);
               tmpRoundedPath.AddArc(rectangle.X, rectangle.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
               tmpRoundedPath.AddLine(rectangle.X, rectangle.Bottom - radius * 2, rectangle.X, rectangle.Y + radius * 2);

               tmpRoundedPath.CloseFigure();

               return tmpRoundedPath;
          }



          public static System.Drawing.Color FlatBarBackColor
          {
               get
               {
                    var tmpBackColor = System.Drawing.SystemColors.Control;
                    tmpBackColor = System.Drawing.Color.FromArgb(GetLightValue(tmpBackColor.R), GetLightValue(tmpBackColor.G), GetLightValue(tmpBackColor.B));

                    return GetRealColor(tmpBackColor);
               }
          }

          public static System.Drawing.Color FlatBarBorderColor
          {
               get
               {
                    var tmpBorderColor = System.Drawing.SystemColors.ControlDark;

                    tmpBorderColor = System.Drawing.Color.FromArgb(GetDarkValue(tmpBorderColor.R), GetDarkValue(tmpBorderColor.G), GetDarkValue(tmpBorderColor.B));

                    return GetRealColor(tmpBorderColor);
               }
          }

          public static System.Drawing.Color FlatBarItemPressedBackColor
          {
               get
               {
                    return GetRealColor(GetLightColor(14, 44, 40));
               }
          }

          public static System.Drawing.Color FlatBarItemHighLightBackColor
          {
               get
               {
                    return GetRealColor(GetLightColor(-2, 30, 72));
               }
          }

          public static System.Drawing.Color FlatBarItemDownedColor
          {
               get
               {
                    return GetRealColor(GetLightColor(11, 9, 73));
               }
          }

          public static System.Drawing.Color FlatTabBackColor
          {
               get
               {
                    var tmpColor = System.Drawing.SystemColors.Control;

                    int tmpColorR = tmpColor.R, tmpColorG = tmpColor.G, tmpColorB = tmpColor.B;
                    int tmpDelta = 0x23, tmpMaxDelta = 255 - (System.Math.Max(System.Math.Max(tmpColorR, tmpColorG), tmpColorB) + tmpDelta);

                    if (tmpMaxDelta > 0) tmpMaxDelta = 0;

                    tmpColorR += (tmpDelta + tmpMaxDelta);
                    tmpColorG += (tmpDelta + tmpMaxDelta);
                    tmpColorB += (tmpDelta + tmpMaxDelta);

                    return System.Drawing.Color.FromArgb(tmpColorR, tmpColorG, tmpColorB);
               }
          }

          public static System.Drawing.Color GetRealColor(System.Drawing.Color color)
          {
               var tmpGraphics = System.Drawing.Graphics.FromHwnd(System.IntPtr.Zero);

               var tmpRealColor = tmpGraphics.GetNearestColor(color);
               tmpGraphics.Dispose();

               return tmpRealColor;
          }

          public static System.Drawing.Color OffsetColor(System.Drawing.Color color, int R, int G, int B)
          {
               R = System.Math.Min(255, color.R + R);
               G = System.Math.Min(255, color.G + G);
               B = System.Math.Min(255, color.B + B);

               return System.Drawing.Color.FromArgb(R, G, B);
          }

          public static int GetDarkValue(int value)
          {
               return value * 8 / 10;
          }

          public static int GetLightValue(byte value)
          {
               return value + (255 - value) * 16 / 100;
          }

          private static int GetLightIndex(ColorInfo colorInfo, byte buttonFaceValue, byte highlightValue, byte windowValue)
          {
               int tmpLightIndex = buttonFaceValue * colorInfo.ButtonFaceColorPart / 100 + highlightValue * colorInfo.HighlightColorPart / 100 + windowValue * colorInfo.WindowColorPart / 100;

               if (tmpLightIndex < 000) tmpLightIndex = 0;
               if (tmpLightIndex > 255) tmpLightIndex = 255;

               return tmpLightIndex;
          }

          public static System.Drawing.Color GetLightColor(int buttonFaceColorPart, int highlightColorPart, int windowColorPart)
          {
               colorInfo.ButtonFaceColorPart = buttonFaceColorPart;
               colorInfo.HighlightColorPart = highlightColorPart;
               colorInfo.WindowColorPart = windowColorPart;

               System.Drawing.Color tmpButtonFace = System.Drawing.SystemColors.Control, tmpHighlight = System.Drawing.SystemColors.Highlight, tmpWindowColor = System.Drawing.SystemColors.Window;
               if (tmpButtonFace == System.Drawing.Color.White || tmpButtonFace == System.Drawing.Color.Black)
               {
                    return tmpHighlight;
               }
               else
               {
                    return System.Drawing.Color.FromArgb(GetLightIndex(colorInfo, tmpButtonFace.R, tmpHighlight.R, tmpWindowColor.R), GetLightIndex(colorInfo, tmpButtonFace.G, tmpHighlight.G, tmpWindowColor.G), GetLightIndex(colorInfo, tmpButtonFace.B, tmpHighlight.B, tmpWindowColor.B));
               }
          }
     }
}