using System.Windows.Forms;
using HuiruiSoft.Win32;

namespace HuiruiSoft.Safe
{
     internal sealed class CustomMessageFilter : IMessageFilter
     {
          public bool PreFilterMessage(ref Message message)
          {
               switch (message.Msg)
               {
                    case WindowsMessages.WM_MOVE:
                    case WindowsMessages.WM_SIZE:
                    case WindowsMessages.WM_ACTIVATE:
                    case WindowsMessages.WM_KEYUP:
                    case WindowsMessages.WM_KEYDOWN:
                    case WindowsMessages.WM_MOUSEMOVE:
                    case WindowsMessages.WM_LBUTTONDOWN:
                    case WindowsMessages.WM_RBUTTONDOWN:
                    case WindowsMessages.WM_MBUTTONDOWN:
                    case WindowsMessages.WM_MOUSEWHEEL:
                         Program.NotifyUserActivity();
                         break;
               }

               if (message.Msg == WindowsMessages.WM_INPUTLANGCHANGEREQUEST)
               {
                    long messageParam = message.LParam.ToInt64();
                    if (messageParam < int.MinValue || messageParam > int.MaxValue)
                    {
                         return true;
                    }
               }

               return false;
          }
     }
}
