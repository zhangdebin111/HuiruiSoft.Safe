
namespace HuiruiSoft.Drawing
{
     public struct YUVCOLOR
     {
          public static readonly YUVCOLOR Empty = new YUVCOLOR();

          private double y;
          private double u;
          private double v;

          public double Y
          {
               get
               {
                    return this.y;
               }

               set
               {
                    this.y = HuiruiSoft.Drawing.ColorTranslator.GetBetween(value, 0, 1.0);
               }
          }

          public double U
          {
               get
               {
                    return this.u;
               }

               set
               {
                    this.u = HuiruiSoft.Drawing.ColorTranslator.GetBetween(value, -0.436, +0.436);
               }
          }

          public double V
          {
               get
               {
                    return this.v;
               }
               set
               {
                    this.v = HuiruiSoft.Drawing.ColorTranslator.GetBetween(value, -0.615, +0.615);
               }
          }

          public YUVCOLOR(double y, double u, double v)
          {
               this.y = y;
               this.u = u;
               this.v = v;
          }

          public static bool operator ==(YUVCOLOR left, YUVCOLOR right)
          {
               return (left.Y == right.Y && left.U == right.U && left.V == right.V);
          }

          public static bool operator !=(YUVCOLOR left, YUVCOLOR right)
          {
               return (left.Y != right.Y || left.U != right.U || left.V != right.V);
          }

          public override bool Equals(object @object)
          {
               if (@object == null || this.GetType() != @object.GetType())
               {
                    return false;
               }
               else
               {
                    return this == (YUVCOLOR)@object;
               }
          }

          public override int GetHashCode()
          {
               return this.Y.GetHashCode() ^ this.U.GetHashCode() ^ this.V.GetHashCode();
          }
     }
}