
namespace HuiruiSoft.Drawing
{
     public struct HSLCOLOR
     {
          public static readonly HSLCOLOR Empty = new HSLCOLOR( );

          private double colorHue, saturation, luminance;

          public double Hue
          {
               get
               {
                    return this.colorHue;
               }

               set
               {
                    this.colorHue = HuiruiSoft.Drawing.ColorTranslator.GetBetween(value, 0, 1.0);
               }
          }

          public double Hue360
          {
               get
               {
                    return this.colorHue * 360;
               }

               set
               {
                    this.colorHue = HuiruiSoft.Drawing.ColorTranslator.GetBetween(value / 360, 0, 1.0);
               }
          }

          public double Saturation
          {
               get
               {
                    return this.saturation;
               }

               set
               {
                    this.saturation = HuiruiSoft.Drawing.ColorTranslator.GetBetween(value, 0, 1.0);
               }
          }

          public double Saturation100
          {
               get
               {
                    return this.saturation * 100;
               }

               set
               {
                    this.saturation = HuiruiSoft.Drawing.ColorTranslator.GetBetween(value / 100, 0, 1.0);
               }
          }

          public double Luminance
          {
               get
               {
                    return this.luminance;
               }

               set
               {
                    this.luminance = HuiruiSoft.Drawing.ColorTranslator.GetBetween(value, 0, 1.0);
               }
          }

          public double Luminance100
          {
               get
               {
                    return this.luminance * 100;
               }

               set
               {
                    this.luminance = HuiruiSoft.Drawing.ColorTranslator.GetBetween(value / 100, 0, 1.0);
               }
          }


          public HSLCOLOR(System.Drawing.Color color)
          {
               this = HuiruiSoft.Drawing.ColorTranslator.RGBToHSL(color);
          }

          public HSLCOLOR(int hue, int saturation, int brightness) : this( )
          {
               this.Hue360 = hue; this.Saturation100 = saturation; this.Luminance100 = brightness;
          }

          public HSLCOLOR(double hue, double saturation, double brightness) : this( )
          {
               this.Hue = hue; this.Saturation = saturation; this.Luminance = brightness;
          }

          public static implicit operator HSLCOLOR(System.Drawing.Color color)
          {
               return HuiruiSoft.Drawing.ColorTranslator.RGBToHSL(color);
          }

          public static implicit operator System.Drawing.Color(HSLCOLOR color)
          {
               return color.ToColor( );
          }

          public static implicit operator RGBColor(HSLCOLOR color)
          {
               return color.ToColor( );
          }

          public static implicit operator CMYKCOLOR(HSLCOLOR color)
          {
               return color.ToColor( );
          }

          public static bool operator ==(HSLCOLOR left, HSLCOLOR right)
          {
               return (left.Hue == right.Hue) && (left.Saturation == right.Saturation) && (left.Luminance == right.Luminance);
          }

          public static bool operator !=(HSLCOLOR left, HSLCOLOR right)
          {
               return !(left == right);
          }

          public System.Drawing.Color ToColor( )
          {
               return ToColor(this);
          }

          public static System.Drawing.Color ToColor(HSLCOLOR hsbColor)
          {
               return HuiruiSoft.Drawing.ColorTranslator.HSLToRGB(hsbColor);
          }

          public static System.Drawing.Color ToColor(double hue, double saturation, double brightness)
          {
               return ToColor(new HSLCOLOR(hue, saturation, brightness));
          }

          public override int GetHashCode( )
          {
               return this.Hue360.GetHashCode( ) ^ this.Saturation100.GetHashCode( ) ^ this.Luminance100.GetHashCode( );
          }

          public override bool Equals(object @object)
          {
               if(@object == null || this.GetType( ) != @object.GetType( ))
               {
                    return false;
               }
               else
               {
                    return (this == (HSLCOLOR)@object);
               }
          }

          public override string ToString( )
          {
               return string.Format(
                    "Hue: {0}, Saturation: {1}, Luminance: {2}",
                    HuiruiSoft.Drawing.ColorTranslator.Round(this.Hue360),
                    HuiruiSoft.Drawing.ColorTranslator.Round(this.Saturation100),
                    HuiruiSoft.Drawing.ColorTranslator.Round(this.Luminance100));
          }
     }
}