
using System.Runtime.InteropServices;

namespace HuiruiSoft.Win32
{
     [System.Serializable, StructLayout(LayoutKind.Sequential)]
     public struct RECT
     {
          public int Left;

          public int Top;

          public int Right;

          public int Bottom;

          
          public bool IsEmpty
          {
               get
               {
                    return this.Left >= this.Right || this.Top >= this.Bottom;
               }
          }


          public int X
          {
               get
               {
                    return this.Left;
               }

               set
               {
                    this.Left = value;
               }
          }

          public int Y
          {
               get
               {
                    return this.Top;
               }

               set
               {
                    this.Top = value;
               }
          }


          public int Width
          {
               get
               {
                    return this.Right - this.Left;
               }

               set
               {
                    this.Right = this.Left + value;
               }
          }

          public int Height
          {
               get
               {
                    return this.Bottom - this.Top;
               }

               set
               {
                    this.Bottom = this.Top + value;
               }
          }


          public System.Drawing.Size Size
          {
               set
               {
                    this.Width  = value.Width;
                    this.Height = value.Height;
               }

               get
               {
                    return new System.Drawing.Size(this.Width, this.Height);
               }
          }

          public System.Drawing.Point Location
          {
               set
               {
                    this.Left = value.X;
                    this.Top  = value.Y;
               }

               get
               {
                    return new System.Drawing.Point(this.Left, this.Top);
               }
          }

          public static readonly RECT Empty = new RECT(0, 0, 0, 0);


          public RECT(int left, int top, int right, int bottom)
          {
               this.Left   = left;
               this.Top    = top;
               this.Right  = right;
               this.Bottom = bottom;
          }

          public RECT(System.Drawing.Rectangle rectangle)
          {
               this.Left   = rectangle.Left;
               this.Top    = rectangle.Top;
               this.Right  = rectangle.Right;
               this.Bottom = rectangle.Bottom;
          }

          #region IEquatable<T>

          public bool Equals(RECT rectangle)
          {
               return (rectangle.Left == this.Left) && (rectangle.Top == this.Top) && (rectangle.Width == this.Width) && (rectangle.Height == this.Height);
          }

          #endregion

          public override bool Equals(object obj)
          {
               if(!(obj is RECT))
               {
                    return false;
               }
               else
               {
                    return this.Equals((RECT)obj);
               }
          }

          public static implicit operator RECT(System.Drawing.Rectangle rectangle)
          {
               return new RECT(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom);
          }


          public static implicit operator System.Drawing.Rectangle(RECT rectangle)
          {
               return System.Drawing.Rectangle.FromLTRB(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom);
          }

          public static bool operator ==(RECT left, RECT right)
          {
               return (left.Left == right.Left) && (left.Top == right.Top) && (left.Width == right.Width) && (left.Height == right.Height);
          }

          public static bool operator !=(RECT left, RECT right)
          {
               return !(left == right);
          }

          public static RECT FromXYWH(int x, int y, int width, int height)
          {
               return new RECT(x, y, x + width, y + height);
          }

          public static RECT FromLTRB(int left, int top, int right, int bottom)
          {
               return new RECT(left, top, right - left, bottom - top);
          }

          public static RECT FromExtents(int x1, int y1, int x2, int y2)
          {
               return FromLTRB(System.Math.Min(x1, x2), System.Math.Min(y1, y2), System.Math.Max(x1, x2), System.Math.Max(y1, y2));
          }

          public System.Drawing.Rectangle GetRectangle( )
          {
               return new System.Drawing.Rectangle(this.Left, this.Top, this.Right - this.Left, this.Bottom - this.Top);
          }

          public System.Drawing.Rectangle ToRectangle( )
          {
               return System.Drawing.Rectangle.FromLTRB(this.Left, this.Top, this.Right, this.Bottom);
          }

          public static RECT FromRectangle(System.Drawing.Rectangle rectangle)
          {
               return new RECT(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom);
          }

          public void RestoreFromRectangle(System.Drawing.Rectangle original)
          {
               this.Left   = original.Left;
               this.Right  = original.Right;
               this.Top    = original.Top;
               this.Bottom = original.Bottom;
          }

          public bool Contains(int x, int y)
          {
               return (this.Left <= x) && (x < this.Right) && (this.Top <= y) && (y < this.Bottom);
          }

          public bool Contains(POINT point)
          {
               return this.Contains(point.X, point.Y);
          }

          public bool Contains(RECT rect)
          {
               return (this.Left <= rect.Left) && (rect.Right <= this.Right) && (this.Top <= rect.Top) && (rect.Bottom <= this.Bottom);
          }

          public void Offset(int x, int y)
          {
               this.Left   += x;
               this.Top    += y;
               this.Right  += x;
               this.Bottom += y;
          }

          public void Offset(SIZE size)
          {
               this.Offset(size.Width, size.Height);
          }

          public void Resize(int width, int height)
          {
               this.Right  += width;
               this.Bottom += height;
          }

          public void Inset(int width, int height)
          {
               this.Width  = this.Width  - width;
               this.Height = this.Height - height;

               this.Left   = this.Left   + (width  / 2);
               this.Top    = this.Top    + (height / 2);
          }


          public void Intersect(RECT rect)
          {
               RECT result = RECT.Intersect(rect, this);
               this.Left   = result.Left;
               this.Top    = result.Top;
               this.Width  = result.Width;
               this.Height = result.Height;
          }


          public static RECT Intersect(RECT left, RECT right)
          {
               int x1 = System.Math.Max(left.Left,   right.Left);
               int x2 = System.Math.Min(left.Right,  right.Right);
               int y1 = System.Math.Max(left.Top,    right.Top);
               int y2 = System.Math.Min(left.Bottom, right.Bottom);

               if(x2 < x1 || y2 < y1)
               {
                    return RECT.Empty;
               }
               else
               {
                    return new RECT(x1, y1, x2 - x1, y2 - y1);
               }
          }


          public bool IntersectsWith(RECT rect)
          {
               return (rect.Left < this.Right) && (this.Left < rect.Right) && (rect.Top < this.Bottom) && (this.Top < rect.Bottom);
          }

          public static RECT Union(RECT left, RECT right)
          {
               int x1 = System.Math.Min(left.Left,   right.Left);
               int x2 = System.Math.Max(left.Right,  right.Right);
               int y1 = System.Math.Min(left.Top,    right.Top);
               int y2 = System.Math.Max(left.Bottom, right.Bottom);

               return new RECT(x1, y1, x2 - x1, y2 - y1);
          }

          public override int GetHashCode( )
          {
               return this.Left ^ ((this.Top << 13) | (this.Top >> 0x13)) ^ ((this.Width << 0x1a) | (this.Width >> 6)) ^ ((this.Height << 7) | (this.Height >> 0x19));
          }

          public override string ToString( )
          {
               return string.Concat(new object[ ] { "Left = ", this.Left, " Top ", this.Top, " Right = ", this.Right, " Bottom = ", this.Bottom });
          }
     }
}