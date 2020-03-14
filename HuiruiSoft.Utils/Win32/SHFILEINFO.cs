
using System.Runtime.InteropServices;

namespace HuiruiSoft.Win32
{
     [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
     public class SHFILEINFO
     {
          public System.IntPtr hIcon;

          public int iIcon;

          public int dwAttributes;

          [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NativeMethods.MAX_PATH)]
          public string szDisplayName;

          [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
          public string szTypeName;

          /*
           typedef struct _SHFILEINFO
           {
                 HICON hIcon;
                 int   iIcon;
                 DWORD dwAttributes;
                 TCHAR szDisplayName[MAX_PATH];
                 TCHAR szTypeName[80];
           } SHFILEINFO;
           */
     }
}