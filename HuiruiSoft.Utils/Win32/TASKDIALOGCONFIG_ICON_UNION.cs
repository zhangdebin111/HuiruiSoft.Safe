
using System.Runtime.InteropServices;

namespace HuiruiSoft.Win32.Dialogs
{
     // NOTE: We include a "spacer" so that the struct size varies on 64-bit architectures.
     [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Auto)]
     public struct TASKDIALOGCONFIG_ICON_UNION
     {
          [FieldOffset(0)]
          public int hMainIcon;

          [FieldOffset(0)]
          public int pszIcon;

          [FieldOffset(0)]
          public System.IntPtr spacer;


          public TASKDIALOGCONFIG_ICON_UNION(int hMainIcon)
          {
               this.pszIcon = 0;
               this.hMainIcon = hMainIcon;
               this.spacer = System.IntPtr.Zero;
          }
     }
}