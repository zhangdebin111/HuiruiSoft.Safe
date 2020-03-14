
using HuiruiSoft.Win32;

namespace HuiruiSoft.Utils
{
     public static partial class BroadcastHelper
     {
          public static void Send(int applicationMessage, int wParam, int lParam, bool waitWithTimeout)
          {
               if (!waitWithTimeout)
               {
                    NativeMethods.PostMessage((System.IntPtr)WindowsMessages.HWND_BROADCAST, applicationMessage, (System.IntPtr)wParam, (System.IntPtr)lParam);
               }
               else
               {
                    var tmpSendResult = System.IntPtr.Zero;
                    NativeMethods.SendMessageTimeout((System.IntPtr)WindowsMessages.HWND_BROADCAST, applicationMessage, (System.IntPtr)wParam, (System.IntPtr)lParam, SendMessageTimeoutFlags.SMTO_ABORTIFHUNG, 5000, ref tmpSendResult);
               }
          }
     }
}