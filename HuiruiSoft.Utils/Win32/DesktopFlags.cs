
namespace HuiruiSoft.Win32
{
     [System.Flags]
     internal enum DesktopFlags : uint
     {
          ReadObjects         = 0x0001,
          CreateWindow        = 0x0002,
          CreateMenu          = 0x0004,
          HookControl         = 0x0008,
          JournalRecord       = 0x0010,
          JournalPlayback     = 0x0020,
          Enumerate           = 0x0040,
          WriteObjects        = 0x0080,
          SwitchDesktop       = 0x0100,
     }
}