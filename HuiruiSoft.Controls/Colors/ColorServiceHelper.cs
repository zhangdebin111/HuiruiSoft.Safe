
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
          /// <summary>����ɫ </summary>
          Cubes = 0,

          /// <summary>����ɫ�� </summary>
          Continuous = 1,

          /// <summary>Windows ϵͳ </summary>
          WindowsOs = 2,

          /// <summary>Mac ϵͳ </summary>
          MacOs = 3,

          /// <summary>�Ҷȼ� </summary>
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

          /// <summary>ɫ��(Hue):ָ�졢�ȡ��ơ��̡������塢�ϵ�ɫ�ʳɷ֣��ڡ����Լ����ֻ�ɫ������ɫϵ��ɫ�����ڵ�����ɫ��ȡֵ��ΧΪ��0��360���ȡ�</summary>
          Hue,

          /// <summary>���Ͷ�(Saturation):ָɫ�ʵĴ��ȡ�����׹���Խ���ɫ�ʱ��Ͷȣ�ȡֵ��ΧΪ 0%����ɫ������100%����ɫ����</summary>
          Saturation,

          /// <summary>����(Brightness):����ָ��ɫ�����̶ȣ���ɫ��Ĺ���Խ�������ȸо�ҲԽ��ȡֵ��ΧΪ 0%����ɫ������100%����ɫ����</summary>
          Brightness,

          /// <summary>������ͨ��(L)�������ȷ�����Χ��(0��100)��</summary>
          Luminance,

          /// <summary>aͨ����������ɫ(��-��-�ۺ�)��a�������ķ�Χ������(+120��-120)</summary>
          A,

          /// <summary>bͨ����������ɫ(��-��-  ��)��b�������ķ�Χ������(+120��-120)</summary>
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