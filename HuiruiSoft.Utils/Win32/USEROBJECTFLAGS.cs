
using System.Runtime.InteropServices;

namespace HuiruiSoft.Win32
{
     [StructLayout(LayoutKind.Sequential)]
     public struct USEROBJECTFLAGS
     {
          [MarshalAs(UnmanagedType.Bool)]
          public bool fInherit;

          [MarshalAs(UnmanagedType.Bool)]
          public bool fReserved;

          public int dwFlags;

          /*
           typedef struct tagUSEROBJECTFLAGS
           {
                 BOOL  fInherit;
                 BOOL  fReserved;
                 DWORD dwFlags;
           } USEROBJECTFLAGS, *PUSEROBJECTFLAGS;
           */
     }
}