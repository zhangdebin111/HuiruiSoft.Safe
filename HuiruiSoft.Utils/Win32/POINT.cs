
using System.Runtime.InteropServices;

namespace HuiruiSoft.Win32
{
     [System.Serializable]
     [StructLayout(LayoutKind.Sequential)]
     public struct POINT : System.IEquatable<POINT>
     {
          public int X;


          public int Y;


          public POINT(int x, int y)
          {
               this.X = x;
               this.Y = y;
          }

          public bool Equals(POINT point)
          {
               return (point.X == this.X) && (point.Y == this.Y);
          }

          public static implicit operator System.Drawing.Point(POINT point)
          {
               return new System.Drawing.Point(point.X, point.Y);
          }

          public static implicit operator POINT(System.Drawing.Point point)
          {
               return new POINT(point.X, point.Y);
          }

          public static explicit operator System.Drawing.Size(POINT point)
          {
               return new System.Drawing.Size(point.X, point.Y);
          }
     }
}