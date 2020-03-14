
namespace HuiruiSoft.Drawing
{
     public struct HSBCOLOR
     {
          public static readonly HSBCOLOR Empty = new HSBCOLOR( );

          private double colorHue, saturation, brightness;

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

          public double Brightness
          {
               get
               {
                    return this.brightness;
               }

               set
               {
                    this.brightness = HuiruiSoft.Drawing.ColorTranslator.GetBetween(value, 0, 1.0);
               }
          }

          public double Brightness100
          {
               get
               {
                    return this.brightness * 100;
               }

               set
               {
                    this.brightness = HuiruiSoft.Drawing.ColorTranslator.GetBetween(value / 100, 0, 1.0);
               }
          }


          public HSBCOLOR(System.Drawing.Color color)
          {
               this = HuiruiSoft.Drawing.ColorTranslator.RGBToHSB(color);
          }

          public HSBCOLOR(int hue, int saturation, int brightness) : this( )
          {
               this.Hue360 = hue; this.Saturation100 = saturation; this.Brightness100 = brightness;
          }

          public HSBCOLOR(double hue, double saturation, double brightness) : this( )
          {
               this.Hue = hue; this.Saturation = saturation; this.Brightness = brightness;
          }


          public static implicit operator HSBCOLOR(System.Drawing.Color color)
          {
               return HuiruiSoft.Drawing.ColorTranslator.RGBToHSB(color);
          }

          public static implicit operator System.Drawing.Color(HSBCOLOR color)
          {
               return color.ToColor( );
          }

          public static implicit operator RGBColor(HSBCOLOR color)
          {
               return color.ToColor( );
          }


          public static implicit operator CMYKCOLOR(HSBCOLOR color)
          {
               return color.ToColor( );
          }

          public static bool operator ==(HSBCOLOR left, HSBCOLOR right)
          {
               return (left.Hue == right.Hue) && (left.Saturation == right.Saturation) && (left.Brightness == right.Brightness);
          }

          public static bool operator !=(HSBCOLOR left, HSBCOLOR right)
          {
               return !(left == right);
          }


          public System.Drawing.Color ToColor( )
          {
               return ToColor(this);
          }

          public static System.Drawing.Color ToColor(HSBCOLOR hsbColor)
          {
               return HuiruiSoft.Drawing.ColorTranslator.HSBToRGB(hsbColor);
          }

          public static System.Drawing.Color ToColor(double hue, double saturation, double brightness)
          {
               return ToColor(new HSBCOLOR(hue, saturation, brightness));
          }

          public override int GetHashCode( )
          {
               return this.Hue360.GetHashCode( ) ^ this.Saturation100.GetHashCode( ) ^ this.Brightness100.GetHashCode( );
          }

          public override bool Equals(object @object)
          {
               if(@object == null || this.GetType( ) != @object.GetType( ))
               {
                    return false;
               }
               else
               {
                    return (this == (HSBCOLOR)@object);
               }
          }


          public override string ToString( )
          {
               return string.Format(
                    "Hue: {0}, Saturation: {1}, Brightness: {2}",
                    HuiruiSoft.Drawing.ColorTranslator.Round(this.Hue360),
                    HuiruiSoft.Drawing.ColorTranslator.Round(this.Saturation100),
                    HuiruiSoft.Drawing.ColorTranslator.Round(this.Brightness100));
          }
     }
}