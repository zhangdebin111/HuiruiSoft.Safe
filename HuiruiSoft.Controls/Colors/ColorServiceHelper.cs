
namespace HuiruiSoft.Drawing
{
     public enum ColorText
     {
          Integer = 0,
          Native = 1
     }

     /// <summary>This represents the Z Axis of an RGB color cube.</summary>
     public enum ColorSystem
     {
          /// <summary>立方色 </summary>
          Cubes = 0,

          /// <summary>连续色调 </summary>
          Continuous = 1,

          /// <summary>Windows 系统 </summary>
          WindowsOs = 2,

          /// <summary>Mac 系统 </summary>
          MacOs = 3,

          /// <summary>灰度级 </summary>
          Grayscale = 4,
     }

     /// <summary>This represents the Z Axis of an RGB color cube.</summary>
     public enum ColorCubeZAxes
     {
          /// <summary>The Z Axis is Red</summary>
          Red,

          /// <summary>The Z Axis is Green</summary>
          Green,

          /// <summary>The Z Axis is Blue</summary>
          Blue,

          /// <summary>色相(Hue):指红、橙、黄、绿、蓝、靛、紫等色彩成分，黑、白以及各种灰色属于无色系。色相用于调整颜色，取值范围为（0，360）度。</summary>
          Hue,

          /// <summary>饱和度(Saturation):指色彩的纯度。加入白光可以降低色彩饱和度，取值范围为 0%（灰色）——100%（纯色）。</summary>
          Saturation,

          /// <summary>亮度(Brightness):亮度指颜色明暗程度，彩色光的功率越大，其亮度感觉也越大。取值范围为 0%（黑色）——100%（白色）。</summary>
          Brightness,

          /// <summary>光亮度通道(L)，光亮度分量范围是(0，100)。</summary>
          Luminance,

          /// <summary>a通道包括的颜色(绿-灰-粉红)，a分量量的范围可以是(+120，-120)</summary>
          A,

          /// <summary>b通道包括的颜色(蓝-灰-  黄)，b分量量的范围可以是(+120，-120)</summary>
          B
     }

     public static class ColorServiceHelper
     {
          public static string ColorToHex(System.Drawing.Color color)
          {
               return string.Format("{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B);
          }

          public static int ColorToDecimal(System.Drawing.Color color)
          {
               return HexToDecimal(ColorToHex(color));
          }

          public static System.Drawing.Color HexToColor(string hex)
          {
               if(hex.StartsWith("#"))
               {
                    hex.Remove(0, 1);
               }

               string r = hex.Substring(0, 2);
               string g = hex.Substring(2, 2);
               string b = hex.Substring(4, 2);

               return System.Drawing.Color.FromArgb(HexToDecimal(r), HexToDecimal(g), HexToDecimal(b));
          }

          public static int HexToDecimal(string hex)
          {
               return System.Convert.ToInt32(hex, 16);
          }

          public static string DecimalToHex(int dec)
          {
               return dec.ToString("X6");
          }

          public static System.Drawing.Color DecimalToColor(int dec)
          {
               return System.Drawing.Color.FromArgb(dec & 0xFF, (dec & 0xff00) / 256, dec / 65536);
          }

          public static System.Drawing.Color SetHue(System.Drawing.Color color, double Hue)
          {
               var tmpHSLColor = RGBColor.ToHSB(color);
               tmpHSLColor.Hue = Hue;

               return tmpHSLColor.ToColor( );
          }

          public static System.Drawing.Color ModifyHue(System.Drawing.Color color, double Hue)
          {
               var tmpHSLColor = RGBColor.ToHSB(color);
               tmpHSLColor.Hue *= Hue;

               return tmpHSLColor.ToColor( );
          }

          public static System.Drawing.Color SetSaturation(System.Drawing.Color color, double saturation)
          {
               var tmpHSLColor = RGBColor.ToHSB(color);
               tmpHSLColor.Saturation = saturation;

               return tmpHSLColor.ToColor( );
          }

          public static System.Drawing.Color ModifySaturation(System.Drawing.Color color, double saturation)
          {
               var tmpHSLColor = RGBColor.ToHSB(color);
               tmpHSLColor.Saturation *= saturation;

               return tmpHSLColor.ToColor( );
          }

          public static System.Drawing.Color SetBrightness(System.Drawing.Color color, double brightness)
          {
               var tmpHSLColor = RGBColor.ToHSB(color);
               tmpHSLColor.Luminance = brightness;

               return tmpHSLColor.ToColor( );
          }

          public static System.Drawing.Color ModifyBrightness(System.Drawing.Color color, double brightness)
          {
               var tmpHSLColor = RGBColor.ToHSB(color);
               tmpHSLColor.Luminance *= brightness;

               return tmpHSLColor.ToColor( );
          }

          public static System.Drawing.Color RandomColor( )
          {
               var tmpColorRandom = new System.Random( );
               return System.Drawing.Color.FromArgb(tmpColorRandom.Next(256), tmpColorRandom.Next(256), tmpColorRandom.Next(256));
          }

          public static System.Drawing.Color GetPixelColor(System.Drawing.Point point)
          {
               var tmpBitmap = new System.Drawing.Bitmap(1, 1);
               System.Drawing.Graphics.FromImage(tmpBitmap).CopyFromScreen(point, new System.Drawing.Point(0, 0), new System.Drawing.Size(1, 1));

               return tmpBitmap.GetPixel(0, 0);
          }
     }
}