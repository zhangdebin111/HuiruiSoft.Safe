
namespace HuiruiSoft.Drawing
{
     public struct CIEXYZColor
     {
          /// <summary>Gets an empty CIEXYZColor structure.</summary>
          public static readonly CIEXYZColor Empty = new CIEXYZColor( );

          /// <summary>Gets the CIE D65 (white) structure.</summary>
          public static readonly CIEXYZColor D65 = new CIEXYZColor(0.9505, 1.0, 1.0890);

          private double x;
          private double y;
          private double z;

          public double X
          {
               get
               {
                    return this.x;
               }

               set
               {
                    this.x = (value > 0.9505) ? 0.9505 : (value < 0 ? 0 : value);
               }
          }

          public double Y
          {
               get
               {
                    return this.y;
               }

               set
               {
                    this.y = (value > 1.0000) ? 1.0000 : (value < 0 ? 0 : value);
               }
          }

          public double Z
          {
               get
               {
                    return this.z;
               }

               set
               {
                    this.z = (value > 1.0890) ? 1.0890 : (value < 0 ? 0 : value);
               }
          }

          public CIEXYZColor(double x, double y, double z)
          {
               this.x = (x > 0.9505) ? 0.9505 : (x < 0 ? 0 : x);
               this.y = (y > 1.0000) ? 1.0000 : (y < 0 ? 0 : y);
               this.z = (z > 1.0890) ? 1.0890 : (z < 0 ? 0 : z);
          }

          public static bool operator ==(CIEXYZColor left, CIEXYZColor right)
          {
               return (left.X == right.X && left.Y == right.Y && left.Z == right.Z);
          }

          public static bool operator !=(CIEXYZColor left, CIEXYZColor right)
          {
               return (left.X != right.X || left.Y != right.Y || left.Z != right.Z);
          }

          public override bool Equals(object @object)
          {
               if(@object == null || GetType( ) != @object.GetType( ))
               {
                    return false;
               }
               else
               {
                    return this == (CIEXYZColor)@object;
               }
          }

          public override int GetHashCode( )
          {
               return this.X.GetHashCode( ) ^ this.Y.GetHashCode( ) ^ this.Z.GetHashCode( );
          }
     }
}