
using System.Runtime.InteropServices;

namespace HuiruiSoft.Win32
{
     [StructLayout(LayoutKind.Sequential)]
     public struct SIZE
     {
          public int Width;

          public int Height;

          public SIZE(int width, int height)
          {
               this.Width = width;
               this.Height = height;
          }

          public System.Drawing.Size ToSize( )
          {
               return new System.Drawing.Size(this.Width, this.Height);
          }

          public static explicit operator System.Drawing.Size(SIZE size)
          {
               return new System.Drawing.Size(size.Width, size.Height);
          }

          /*
           typedef struct tagSIZE
           {
                 LONG cx;
                 LONG cy;
           } SIZE, *PSIZE;
           */
     }
}