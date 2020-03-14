
using System.Runtime.InteropServices;

namespace HuiruiSoft.Win32
{
     [System.Flags]
     internal enum EFileAccess : uint
     {
          GenericRead = 0x80000000,
          GenericWrite = 0x40000000,
          GenericExecute = 0x20000000,
          GenericAll = 0x10000000
     }


     [System.Flags]
     internal enum EFileShare : uint
     {
          None = 0x00000000,
          Read = 0x00000001,
          Write = 0x00000002,
          Delete = 0x00000004
     }

     internal enum ECreationDisposition : uint
     {
          CreateNew = 1,
          CreateAlways = 2,
          OpenExisting = 3,
          OpenAlways = 4,
          TruncateExisting = 5
     }



     [System.Flags]
     internal enum ToolHelpFlags : uint
     {
          SnapHeapList = 0x00000001,
          SnapProcess = 0x00000002,
          SnapThread = 0x00000004,
          SnapModule = 0x00000008,
          SnapModule32 = 0x00000010,

          SnapAll = (SnapHeapList | SnapProcess | SnapThread | SnapModule),

          Inherit = 0x80000000U
     }




     [System.Flags]
     internal enum MessageBoxFlags : uint
     {
          // Buttons
          MB_ABORTRETRYIGNORE = 0x00000002,
          MB_CANCELTRYCONTINUE = 0x00000006,
          MB_HELP = 0x00004000,
          MB_OK = 0,
          MB_OKCANCEL = 0x00000001,
          MB_RETRYCANCEL = 0x00000005,
          MB_YESNO = 0x00000004,
          MB_YESNOCANCEL = 0x00000003,

          // Icons
          MB_ICONEXCLAMATION = 0x00000030,
          MB_ICONWARNING = 0x00000030,
          MB_ICONINFORMATION = 0x00000040,
          MB_ICONASTERISK = 0x00000040,
          MB_ICONQUESTION = 0x00000020,
          MB_ICONSTOP = 0x00000010,
          MB_ICONERROR = 0x00000010,
          MB_ICONHAND = 0x00000010,

          // Default buttons
          MB_DEFBUTTON1 = 0,
          MB_DEFBUTTON2 = 0x00000100,
          MB_DEFBUTTON3 = 0x00000200,
          MB_DEFBUTTON4 = 0x00000300,

          // Modality
          MB_APPLMODAL = 0,
          MB_SYSTEMMODAL = 0x00001000,
          MB_TASKMODAL = 0x00002000,

          // Other options
          MB_DEFAULT_DESKTOP_ONLY = 0x00020000,
          MB_RIGHT = 0x00080000,
          MB_RTLREADING = 0x00100000,
          MB_SETFOREGROUND = 0x00010000,
          MB_TOPMOST = 0x00040000,
          MB_SERVICE_NOTIFICATION = 0x00200000
     }
}