
using System.Runtime.InteropServices;

namespace HuiruiSoft.Win32
{
     [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
     public struct HDITEM
     {
          public static readonly HDITEM Empty = new HDITEM( );

          public int mask;

          public int cxy;

          public string pszText;

          public System.IntPtr hbm;

          public int cchTextMax;

          public int fmt;

          public System.IntPtr lParam;

          public int iImage;

          public int iOrder;

          public int type;

          public System.IntPtr pvFilter;


          /*
           typedef struct _HDITEM
           {
                 UINT    mask;
                 int     cxy;
                 LPTSTR  pszText;
                 HBITMAP hbm;
                 int     cchTextMax;
                 int     fmt;
                 LPARAM  lParam;
               #if (_WIN32_IE >= 0x0300)
                 int     iImage;
                 int     iOrder;
               #endif 
               #if (_WIN32_IE >= 0x0500)
                 UINT    type;
                 void    *pvFilter;
               #endif 
               #if (_WIN32_WINNT >= 0x0600)
                 UINT    state;
               #endif 
           } HDITEM, *LPHDITEM;
           */
     }


     // HDN_ITEMCHANGING will send us an HDITEM w/ pszText set to some random pointer.
     // Marshal.PtrToStructure chokes when it has to convert a random pointer to a string.  For HDN_ITEMCHANGING map pszText to an IntPtr 
     [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
     public class HDITEM2
     {
          public int mask = 0;
          public int cxy = 0;
          public System.IntPtr pszText_notUsed = System.IntPtr.Zero;
          public System.IntPtr hbm = System.IntPtr.Zero;
          public int cchTextMax = 0;
          public int fmt = 0;
          public System.IntPtr lParam = System.IntPtr.Zero;
          public int iImage = 0;
          public int iOrder = 0;
          public int type = 0;
          public System.IntPtr pvFilter = System.IntPtr.Zero;
     }
}