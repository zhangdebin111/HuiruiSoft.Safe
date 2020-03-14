
namespace HuiruiSoft.Drawing
{
     public struct CIELabColor
     {
          public static readonly CIELabColor Empty = new CIELabColor( );

          private int luminance, labColorA, labColorB;

          public int L
          {
               get
               {
                    return this.luminance;
               }

               set
               {
                    this.luminance = HuiruiSoft.Drawing.ColorTranslator.GetBetween(value, 0, 100);
               }
          }

          public int A
          {
               get
               {
                    return this.labColorA;
               }

               set
               {
                    this.labColorA = HuiruiSoft.Drawing.ColorTranslator.GetBetween(value, -128, +127);
               }
          }

          public int B
          {
               get
               {
                    return this.labColorB;
               }

               set
               {
                    this.labColorB = HuiruiSoft.Drawing.ColorTranslator.GetBetween(value, -128, +127);
               }
          }

          public CIELabColor(System.Drawing.Color color)
          {
               this = HuiruiSoft.Drawing.ColorTranslator.RGBToCIELab(color);
          }

          public CIELabColor(int luminance, int labColorA, int labColorB) : this( )
          {
               this.luminance = luminance; this.labColorA = labColorA; this.labColorB = labColorB;
          }


          public static implicit operator System.Drawing.Color(CIELabColor color)
          {
               return color.ToColor( );
          }

          public static implicit operator CIELabColor(System.Drawing.Color color)
          {
               return HuiruiSoft.Drawing.ColorTranslator.RGBToCIELab(color);
          }

          public static bool operator ==(CIELabColor left, CIELabColor right)
          {
               return (left.L == right.L) && (left.A == right.A) && (left.B == right.B);
          }

          public static bool operator !=(CIELabColor left, CIELabColor right)
          {
               return !(left == right);
          }

          public System.Drawing.Color ToColor( )
          {
               return CIELabColor.ToColor(this);
          }

          public static System.Drawing.Color ToColor(CIELabColor color)
          {
               return HuiruiSoft.Drawing.ColorTranslator.FromCIELab(color.L, color.A, color.B);
          }

          public static System.Drawing.Color ToColor(int luminance, int labColorA, int labColorB)
          {
               return CIELabColor.ToColor(new CIELabColor(luminance, labColorA, labColorB));
          }

          public override int GetHashCode( )
          {
               return this.L.GetHashCode( ) ^ this.A.GetHashCode( ) ^ this.B.GetHashCode( );
          }

          public override bool Equals(object @object)
          {
               if(@object == null || GetType( ) != @object.GetType( ))
               {
                    return false;
               }
               else
               {
                    return this == (CIELabColor)@object;
               }
          }

          public override string ToString()
          {
               return string.Format("Luminance: {0}, A: {1}, B: {2}", ColorTranslator.Round(this.L), ColorTranslator.Round(this.A), ColorTranslator.Round(this.B));
          }
     }
}