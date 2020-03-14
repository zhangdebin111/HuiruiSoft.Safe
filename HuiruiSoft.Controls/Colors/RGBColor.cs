
namespace HuiruiSoft.Drawing
{
     public struct RGBColor
     {
          public static readonly RGBColor Empty = new RGBColor( );

          private int red, green, blue;

          public int Red
          {
               get
               {
                    return this.red;
               }

               set
               {
                    this.red = HuiruiSoft.Drawing.ColorTranslator.CheckColor(value);
               }
          }

          public int Green
          {
               get
               {
                    return this.green;
               }

               set
               {
                    this.green = HuiruiSoft.Drawing.ColorTranslator.CheckColor(value);
               }
          }

          public int Blue
          {
               get
               {
                    return this.blue;
               }

               set
               {
                    this.blue = HuiruiSoft.Drawing.ColorTranslator.CheckColor(value);
               }
          }

          public RGBColor(int red, int green, int blue) : this( )
          {
               this.Red = red; this.Green = green; this.Blue = blue;
          }

          public RGBColor(System.Drawing.Color color)
          {
               this = new RGBColor(color.R, color.G, color.B);
          }


          public static implicit operator RGBColor(System.Drawing.Color color)
          {
               return new RGBColor(color.R, color.G, color.B);
          }


          public static implicit operator System.Drawing.Color(RGBColor color)
          {
               return color.ToColor( );
          }


          public static implicit operator HSLCOLOR(RGBColor color)
          {
               return color.ToHSB( );
          }


          public static implicit operator CMYKCOLOR(RGBColor color)
          {
               return color.ToCMYK( );
          }

          public static bool operator !=(RGBColor left, RGBColor right)
          {
               return !(left == right);
          }


          public static bool operator ==(RGBColor left, RGBColor right)
          {
               return (left.Red == right.Red) && (left.Green == right.Green) && (left.Blue == right.Blue);
          }

          public System.Drawing.Color ToColor( )
          {
               return ToColor(this.Red, this.Green, this.Blue);
          }

          public static System.Drawing.Color ToColor(int red, int green, int blue)
          {
               return System.Drawing.Color.FromArgb(red, green, blue);
          }

          public HSLCOLOR ToHSB( )
          {
               return HuiruiSoft.Drawing.ColorTranslator.RGBToHSL(this);
          }

          public static HSLCOLOR ToHSB(System.Drawing.Color color)
          {
               return HuiruiSoft.Drawing.ColorTranslator.RGBToHSL(color);
          }

          public CMYKCOLOR ToCMYK( )
          {
               return ToCMYK(this);
          }

          public static CMYKCOLOR ToCMYK(System.Drawing.Color color)
          {
               return HuiruiSoft.Drawing.ColorTranslator.RGBToCMYK(color);
          }

          public override int GetHashCode( )
          {
               return this.Red.GetHashCode( ) ^ this.Green.GetHashCode( ) ^ this.Blue.GetHashCode( );
          }

          public override bool Equals(object @object)
          {
               if(@object == null || this.GetType( ) != @object.GetType( ))
               {
                    return false;
               }
               else
               {
                    return this == (RGBColor)@object;
               }
          }

          public override string ToString( )
          {
               return string.Format("Red: {0}, Green: {1}, Blue: {2}", this.Red, this.Green, this.Blue);
          }
     }
}