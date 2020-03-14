
namespace HuiruiSoft.Drawing
{
     public struct CMYKCOLOR
     {
          public readonly static CMYKCOLOR Empty = new CMYKCOLOR( );

          private double cyan, magenta, yellow, black;

          public double Cyan
          {
               get
               {
                    return this.cyan;
               }

               set
               {
                    this.cyan = HuiruiSoft.Drawing.ColorTranslator.GetBetween(value, 0, 1.0);
               }
          }

          public double Cyan100
          {
               get
               {
                    return this.cyan * 100;
               }

               set
               {
                    this.cyan = HuiruiSoft.Drawing.ColorTranslator.GetBetween(value / 100, 0, 1.0);
               }
          }

          public double Magenta
          {
               get
               {
                    return this.magenta;
               }

               set
               {
                    this.magenta = HuiruiSoft.Drawing.ColorTranslator.GetBetween(value, 0, 1.0);
               }
          }

          public double Magenta100
          {
               get
               {
                    return this.magenta * 100;
               }

               set
               {
                    this.magenta = HuiruiSoft.Drawing.ColorTranslator.GetBetween(value / 100, 0, 1.0);
               }
          }

          public double Yellow
          {
               get
               {
                    return this.yellow;
               }

               set
               {
                    this.yellow = HuiruiSoft.Drawing.ColorTranslator.GetBetween(value, 0, 1.0);
               }
          }

          public double Yellow100
          {
               get
               {
                    return this.yellow * 100;
               }

               set
               {
                    this.yellow = HuiruiSoft.Drawing.ColorTranslator.GetBetween(value / 100, 0, 1.0);
               }
          }

          public double Black
          {
               get
               {
                    return this.black;
               }

               set
               {
                    this.black = HuiruiSoft.Drawing.ColorTranslator.GetBetween(value, 0, 1.0);
               }
          }

          public double Black100
          {
               get
               {
                    return this.black * 100;
               }

               set
               {
                    this.black = HuiruiSoft.Drawing.ColorTranslator.GetBetween(value / 100, 0, 1.0);
               }
          }

          public CMYKCOLOR(System.Drawing.Color color)
          {
               this = RGBColor.ToCMYK(color);
          }

          public CMYKCOLOR(int cyan, int magenta, int yellow, int black) : this( )
          {
               this.Cyan100 = cyan; this.Magenta100 = magenta; this.Yellow100 = yellow; this.Black100 = black;
          }
          
          public CMYKCOLOR(double cyan, double magenta, double yellow, double black) : this( )
          {
               this.Cyan = cyan; this.Magenta = magenta; this.Yellow = yellow; this.Black = black;
          }

          public static implicit operator HSLCOLOR(CMYKCOLOR color)
          {
               return color.ToColor( );
          }

          public static implicit operator RGBColor(CMYKCOLOR color)
          {
               return color.ToColor( );
          }

          public static implicit operator System.Drawing.Color(CMYKCOLOR color)
          {
               return color.ToColor( );
          }

          public static implicit operator CMYKCOLOR(System.Drawing.Color color)
          {
               return RGBColor.ToCMYK(color);
          }

          public static bool operator ==(CMYKCOLOR left, CMYKCOLOR right)
          {
               return (left.Cyan == right.Cyan) && (left.Magenta == right.Magenta) && (left.Yellow == right.Yellow) && (left.Black == right.Black);
          }

          public static bool operator !=(CMYKCOLOR left, CMYKCOLOR right)
          {
               return !(left == right);
          }

          public System.Drawing.Color ToColor( )
          {
               return ToColor(this);
          }

          public static System.Drawing.Color ToColor(CMYKCOLOR cmykColor)
          {
               return HuiruiSoft.Drawing.ColorTranslator.CMYKToRGB(cmykColor);
          }

          public static System.Drawing.Color ToColor(double cyan, double magenta, double yellow, double black)
          {
               return ToColor(new CMYKCOLOR(cyan, magenta, yellow, black));
          }

          public override bool Equals(object @object)
          {
               if(@object == null || GetType( ) != @object.GetType( ))
               {
                    return false;
               }
               else
               {
                    return this == (CMYKCOLOR)@object;
               }
          }

          public override int GetHashCode( )
          {
               return this.Cyan.GetHashCode( ) ^ this.Magenta.GetHashCode( ) ^ this.Yellow.GetHashCode( ) ^ this.Black.GetHashCode( );
          }

          public override string ToString( )
          {
               return string.Format(
                    "Cyan: {0}, Magenta: {1}, Yellow: {2}, Black: {3}",
                    ColorTranslator.Round(this.Cyan100),
                    ColorTranslator.Round(this.Magenta100),
                    ColorTranslator.Round(this.Yellow100),
                    ColorTranslator.Round(this.Black100));
          }
     }
}