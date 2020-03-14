
using System.Runtime.InteropServices;

namespace HuiruiSoft.Win32
{
     [StructLayout(LayoutKind.Explicit)]
     public struct INPUT32
     {
          [FieldOffset(0)]
          public uint Type;

          [FieldOffset(0)]
          public MOUSEINPUT32_WithSkip MouseInput;

          [FieldOffset(0)]
          public KEYBDINPUT32_WithSkip KeyboardInput;
     }


     [StructLayout(LayoutKind.Explicit)]
     public struct INPUT64
     {
          [FieldOffset(0)]
          public int InputType;

          [FieldOffset(8)]
          public MOUSEINPUT MouseInput;

          [FieldOffset(8)]
          public KEYBDINPUT KeyboardInput;

          [FieldOffset(8)]
          public HARDWAREINPUT HardwareInput;

          /*
          typedef struct tagINPUT {
               DWORD      type;
               MOUSEINPUT mi;
               KEYBDINPUT ki;
          } INPUT, *PINPUT;
          */
     }


     [StructLayout(LayoutKind.Sequential, Pack = 1)]
     public struct MOUSEINPUT32_WithSkip
     {
          public uint __Unused0; // See INPUT32 structure

          public int X;
          public int Y;
          public uint MouseData;
          public uint Flags;
          public uint Time;
          public System.IntPtr ExtraInfo;
     }

     [StructLayout(LayoutKind.Sequential, Pack = 1)]
     public struct KEYBDINPUT32_WithSkip
     {
          public uint __Unused0; // See INPUT32 structure

          public ushort VirtualKeyCode;
          public ushort ScanCode;
          public uint Flags;
          public uint Time;
          public System.IntPtr ExtraInfo;
     }


     // INPUT.KI (40). vk: 8, sc: 10, fl: 12, t: 16, ex: 24
     [StructLayout(LayoutKind.Explicit, Size = 40)]
     public struct SpecializedKeyboardINPUT64
     {
          [FieldOffset(0)]
          public uint Type;

          [FieldOffset(8)]
          public ushort VirtualKeyCode;

          [FieldOffset(10)]
          public ushort ScanCode;

          [FieldOffset(12)]
          public uint Flags;

          [FieldOffset(16)]
          public uint Time;

          [FieldOffset(24)]
          public System.IntPtr ExtraInfo;
     }


     [StructLayout(LayoutKind.Sequential)]
     public struct MOUSEINPUT
     {
          public int dx;

          public int dy;

          public int mouseData;

          public int dwFlags;

          public int time;

          public int dwExtraInfo;   //public System.IntPtr dwExtraInfo;


          /*
           typedef struct tagMOUSEINPUT
           {
                 LONG      dx;
                 LONG      dy;
                 DWORD     mouseData;
                 DWORD     dwFlags;
                 DWORD     time;
                 ULONG_PTR dwExtraInfo;
           } MOUSEINPUT, *PMOUSEINPUT;
           */
     }


     [StructLayout(LayoutKind.Sequential)]
     public struct KEYBDINPUT
     {
          public short wVk;

          public short wScan;

          public int dwFlags;

          public int time;

          public int dwExtraInfo; //public System.IntPtr dwExtraInfo;

          /*
           typedef struct tagKEYBDINPUT
           {
                 WORD      wVk;
                 WORD      wScan;
                 DWORD     dwFlags;
                 DWORD     time;
                 ULONG_PTR dwExtraInfo;
           } KEYBDINPUT, *PKEYBDINPUT;
           */
     }


     [StructLayout(LayoutKind.Sequential)]
     public struct HARDWAREINPUT
     {
          public int uMsg;

          public short wParamL;

          public short wParamH;

          /*
           typedef struct tagHARDWAREINPUT
           {
                 DWORD uMsg;
                 WORD  wParamL;
                 WORD  wParamH;
           } HARDWAREINPUT, *PHARDWAREINPUT;
           */
     }


     [StructLayout(LayoutKind.Sequential)]
     public struct LASTINPUTINFO
     {
          [MarshalAs(UnmanagedType.U4)]
          public int cbSize;

          [MarshalAs(UnmanagedType.U4)]
          public int dwTime;

          /*
           typedef struct tagLASTINPUTINFO
           {
                 UINT  cbSize;
                 DWORD dwTime;
           } LASTINPUTINFO, *PLASTINPUTINFO;
           */
     }
}