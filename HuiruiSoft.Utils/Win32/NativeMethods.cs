
namespace HuiruiSoft.Win32
{
     using HuiruiSoft.Utils;
     using System.Runtime.Versioning;
     using System.Runtime.InteropServices;

     internal static class NativeExternDll
     {
          /// <summary>user32.dll是Windows用户界面相关应用程序接口，用于包括Windows处理，基本用户界面等特性，如创建窗口和发送消息。</summary>
          internal const string User32 = "User32.dll";

          /// <summary>Kernel32.dll是Windows 9x/Me中非常重要的32位动态链接库文件，属于内核级文件。它控制着系统的内存管理、数据的输入输出操作和中断处理，当Windows启动时，kernel32.dll就驻留在内存中特定的写保护区域，使别的程序无法占用这个内存区域。</summary>
          internal const string Kernel32 = "Kernel32.dll";

          /// <summary>Microsoft Windows Shell Library(微软视窗外壳要求生效的命令代码集合)。
          ///    <para>shell32.dll是Windows的32位外壳动态链接库文件，用于打开网页和文件，建立文件时的默认文件名的设置等大量功能。</para>
          ///    <para>严格来讲，它只是代码的合集，真正执行这些功能的是操作系统的相关程序，dll文件只是根据设置调用这些程序的相关功能罢了。</para>
          /// </summary>
          internal const string Shell32 = "Shell32.dll";

          /// <summary>gdi32.dll是Windows GDI图形用户界面相关程序，包含的函数用来绘制图像和显示文字。</summary>
          internal const string Gdi32 = "Gdi32.dll";

          /// <summary>winmm.dll是Windows多媒体相关应用程序接口，用于低档的音频和游戏手柄。</summary>
          internal const string WinMM = "winMM.dll";

          /// <summary>comctl32.dll是Windows应用程序公用GUI图形用户界面模块。</summary>
          internal const string ComCtl32 = "ComCtl32.dll";

          /// <summary>advapi32.dll是一个高级API应用程序接口服务库的一部分，包含的函数与对象的安全性，注册表的操控以及事件日志有关。</summary>
          internal const string AdvApi32 = "AdvApi32.dll";
     }


     //[System.CLSCompliant(false)]
     public delegate bool EnumWindowsProc(System.IntPtr windowHandle, System.IntPtr param);
     

     //  函数原型： HRESULT  CALLBACK TaskDialogCallbackProc(__in HWND hwnd, __in UINT uNotification, __in WPARAM wParam, __in LPARAM lParam, __in LONG_PTR dwRefData);
     public delegate int TaskDialogCallback([In] System.IntPtr hwnd, [In] uint message, [In] System.UIntPtr wParam, [In] System.IntPtr lParam, [In] System.IntPtr refData);


     public static class NativeMethods
     {
          public static readonly System.IntPtr NULL = System.IntPtr.Zero;

          internal const int MAX_PATH = 260;

          internal const long INVALID_HANDLE_VALUE = -1;

          internal const int MOVEFILE_REPLACE_EXISTING = 0x00000001;
          internal const int MOVEFILE_COPY_ALLOWED = 0x00000002;

          internal const int FILE_SUPPORTS_TRANSACTIONS = 0x00200000;
          internal const int MAX_TRANSACTION_DESCRIPTION_LENGTH = 64;

          internal const int ACTCTXSize32 = 32;
          internal const int ACTCTXSize64 = 56;
          internal const int PROCESSENTRY32SizeUni32 = 556;
          internal const int PROCESSENTRY32SizeUni64 = 568;

          // ScrollInfo consts and struct
          internal const int SIF_RANGE = 0x0001;
          internal const int SIF_PAGE = 0x0002;
          internal const int SIF_POS = 0x0004;
          internal const int SIF_DISABLENOSCROLL = 0x0008;
          internal const int SIF_TRACKPOS = 0x0010;
          internal const int SIF_ALL = (SIF_RANGE | SIF_PAGE | SIF_POS | SIF_TRACKPOS);

          public static int? GetLastInputTime()
          {
               int? tmpLastInputTime = null;
               try
               {
                    var tmpLastInputInfo = new LASTINPUTINFO();
                    tmpLastInputInfo.cbSize = Marshal.SizeOf(tmpLastInputInfo);
                    if (GetLastInputInfo(ref tmpLastInputInfo))
                    {
                         tmpLastInputTime = tmpLastInputInfo.dwTime;
                    }
                    else
                    {
                         System.Diagnostics.Debug.Assert(false);
                    }
               }
               catch (System.Exception)
               {
                    System.Diagnostics.Debug.Assert(IsUnix() || WindowsUtils.IsWindows9x);
               }

               return tmpLastInputTime;
          }

          public static int GetApplicationIdleTick()
          {
               int tmpIdleTick = 0;

               var tmpLastInputInfo = new LASTINPUTINFO();
               tmpLastInputInfo.cbSize = Marshal.SizeOf(tmpLastInputInfo);
               if (GetLastInputInfo(ref tmpLastInputInfo))
               {
                    tmpIdleTick = System.Environment.TickCount - tmpLastInputInfo.dwTime;
               }

               return tmpIdleTick;
          }


          [DllImport(NativeExternDll.User32, SetLastError = true, ExactSpelling = true, EntryPoint = "LockWorkStation")]
          public static extern void LockWorkStation();

          [DllImport(NativeExternDll.User32)]
          [return: MarshalAs(UnmanagedType.Bool)]
          public static extern bool GetLastInputInfo(ref LASTINPUTINFO lastInputInfo);


          [DllImport(NativeExternDll.User32, CharSet = CharSet.Auto, ExactSpelling = true)]
          [System.Security.SecurityCritical, System.Security.SuppressUnmanagedCodeSecurity]
          [return: MarshalAs(UnmanagedType.Bool)]
          public static extern bool IsWindow(System.IntPtr windowHandle);


          [DllImport(NativeExternDll.User32, CharSet = CharSet.Auto)]
          public static extern int AnimateWindow(System.IntPtr windowHandle, int time, AnimateWindowFlags flags);


          [DllImport(NativeExternDll.User32, CharSet = CharSet.Auto, ExactSpelling = true)]
          public static extern System.IntPtr SetActiveWindow([In] System.IntPtr windowHandle);


          [DllImport(NativeExternDll.User32, CharSet = CharSet.Auto, ExactSpelling = true)]
          public static extern System.IntPtr SetFocus([In] System.IntPtr windowHandle);


          [DllImport(NativeExternDll.User32, CharSet = CharSet.Auto)]
          public static extern int SendMessage(System.IntPtr windowHandle, int message, System.IntPtr wParam, System.IntPtr lParam);


          [DllImport(NativeExternDll.User32, EntryPoint = "SendMessage")]
          public static extern System.IntPtr SendMessageHDItem(System.IntPtr windowHandle, int message, System.IntPtr wParam, ref HDITEM hdItem);


          [DllImport(NativeExternDll.User32, SetLastError = true, CharSet = CharSet.Auto)]
          public static extern System.IntPtr SendMessageTimeout(System.IntPtr windowHandle, int message, System.IntPtr wParam, System.IntPtr lParam, uint fuFlags, uint uTimeout, ref System.IntPtr lpdwResult);


          [DllImport(NativeExternDll.User32, SetLastError = true, CharSet = CharSet.Auto)]
          [return: MarshalAs(UnmanagedType.Bool)]
          public static extern bool PostMessage(System.IntPtr windowHandle, int message, System.IntPtr wParam, System.IntPtr lParam);


          [DllImport(NativeExternDll.User32, SetLastError = true, CharSet = CharSet.Auto)]
          public static extern int RegisterWindowMessage(string message);


          [DllImport(NativeExternDll.User32, SetLastError = true, CharSet = CharSet.Auto)]
          public static extern System.IntPtr FindWindowEx(System.IntPtr hwndParent, System.IntPtr hwndChildAfter, string lpszClass, string lpszWindow);


          [System.Security.SecurityCritical, System.Security.SuppressUnmanagedCodeSecurity]
          [DllImport(NativeExternDll.User32, SetLastError = true, CharSet = CharSet.Auto, ExactSpelling = true)]
          public static extern System.IntPtr GetWindow(System.IntPtr windowHandle, uint uCmd);


          [DllImport(NativeExternDll.User32, EntryPoint = "GetWindowLong")]
          public static extern long GetWindowLong(System.IntPtr windowHandle, int index);


          [DllImport(NativeExternDll.User32, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = false)]
          public static extern System.IntPtr GetClassLong(System.IntPtr windowHandle, int index);


          [DllImport(NativeExternDll.User32, CharSet = CharSet.Auto, ExactSpelling = false)]
          public static extern System.IntPtr GetClassLongPtr(System.IntPtr windowHandle, int index);


          [DllImport(NativeExternDll.User32, EntryPoint = "GetClassLongPtr")]
          public static extern System.IntPtr GetClassLongPtr64(System.IntPtr windowHandle, int index);


          [DllImport(NativeExternDll.User32, CharSet = CharSet.Auto)]
          [return: MarshalAs(UnmanagedType.Bool)]
          public static extern bool IsZoomed(System.IntPtr windowHandle);


          [DllImport(NativeExternDll.User32, SetLastError = true, CharSet = CharSet.Auto)]
          [return: MarshalAs(UnmanagedType.Bool)]
          public static extern bool IsIconic(System.IntPtr windowHandle);


          [DllImport(NativeExternDll.User32, SetLastError = true, CharSet = CharSet.Auto, ExactSpelling = false)]
          public static extern int GetWindowTextLength(System.IntPtr windowHandle);


          [DllImport(NativeExternDll.User32, SetLastError = true, CharSet = CharSet.Auto, ExactSpelling = false)]
          public static extern int GetWindowText(System.IntPtr windowHandle, System.IntPtr lpString, int size);

          [DllImport(NativeExternDll.User32, CharSet = CharSet.Auto)]
          public static extern int GetWindowText(System.IntPtr windowHandle, System.Text.StringBuilder titleBuffer, int size);

          [DllImport(NativeExternDll.User32, SetLastError = true, CharSet = CharSet.Auto)]
          [return: MarshalAs(UnmanagedType.Bool)]
          public static extern bool GetWindowRect(System.IntPtr windowHandle, ref RECT rectangle);


          [DllImport(NativeExternDll.User32, CharSet = CharSet.Auto, ExactSpelling = true)]
          public static extern System.IntPtr GetForegroundWindow();


          [DllImport(NativeExternDll.User32, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
          [return: MarshalAs(UnmanagedType.Bool)]
          public static extern bool SetForegroundWindow(System.IntPtr windowHandle);

          [DllImport(NativeExternDll.User32, EntryPoint = "EnumWindows")]
          [return: MarshalAs(UnmanagedType.Bool)]
          public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, System.IntPtr lParam);

          [DllImport(NativeExternDll.User32, CharSet = CharSet.Auto, ExactSpelling = true)]
          public static extern System.IntPtr GetParent(System.IntPtr windowHandle);


          [System.Security.SuppressUnmanagedCodeSecurity]
          [DllImport(NativeExternDll.User32, CallingConvention = CallingConvention.StdCall)]
          public static extern int SetParent(int hWndChild, int hWndNewParent);

          [DllImport(NativeExternDll.User32, CharSet = CharSet.Auto)]
          [return: MarshalAs(UnmanagedType.Bool)]
          public static extern bool IsWindowVisible(int windowHandle);


          [DllImport(NativeExternDll.User32, SetLastError = true, CharSet = CharSet.Unicode)]
          [return: MarshalAs(UnmanagedType.Bool)]
          public static extern bool IsWindowVisible(System.IntPtr windowHandle);

          [DllImport(NativeExternDll.User32)]
          [return: MarshalAs(UnmanagedType.Bool)]
          public static extern bool RegisterHotKey(System.IntPtr windowHandle, int hotKeyId, uint modifierKeyCode, uint virtualKeyCode);

          [DllImport(NativeExternDll.User32)]
          [return: MarshalAs(UnmanagedType.Bool)]
          public static extern bool UnregisterHotKey(System.IntPtr windowHandle, int hotKeyId);


          [DllImport(NativeExternDll.User32, SetLastError = true, EntryPoint = "SendInput")]
          public static extern uint SendInput32(uint nInputs, INPUT32[] pInputs, int size);

          [DllImport(NativeExternDll.User32, SetLastError = true, EntryPoint = "SendInput")]
          public static extern uint SendInput64Special(uint nInputs, SpecializedKeyboardINPUT64[] pInputs, int cbSize);


          [DllImport(NativeExternDll.User32)]
          public static extern System.IntPtr GetMessageExtraInfo();


          [DllImport(NativeExternDll.User32, CharSet = CharSet.Auto, ExactSpelling = true)]
          [return: MarshalAs(UnmanagedType.Bool)]
          internal static extern bool BlockInput([MarshalAs(UnmanagedType.Bool)] bool fBlockIt);


          [DllImport(NativeExternDll.User32, SetLastError = true, EntryPoint = "SetClipboardViewer")]
          internal static extern System.IntPtr SetClipboardViewer(System.IntPtr hWndNewViewer);


          [DllImport(NativeExternDll.User32, CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "ChangeClipboardChain")]
          [return: MarshalAs(UnmanagedType.Bool)]
          //BOOL WINAPI ChangeClipboardChain(__in HWND hWndRemove, __in HWND hWndNewNext);
          internal static extern bool ChangeClipboardChain(System.IntPtr hWndRemove, System.IntPtr hWndNewNext);


          [DllImport(NativeExternDll.User32, CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "OpenClipboard")]
          [return: MarshalAs(UnmanagedType.Bool)]
          //BOOL WINAPI OpenClipboard(__in_opt HWND hWndNewOwner);
          internal static extern bool OpenClipboard(System.IntPtr hWndNewOwner);


          [DllImport(NativeExternDll.User32, CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "EmptyClipboard")]
          [return: MarshalAs(UnmanagedType.Bool)]
          //BOOL WINAPI EmptyClipboard(void);
          internal static extern bool EmptyClipboard();


          [DllImport(NativeExternDll.User32, CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "CloseClipboard")]
          [return: MarshalAs(UnmanagedType.Bool)]
          //BOOL WINAPI CloseClipboard(void);
          internal static extern bool CloseClipboard();

          /// <SecurityNote>This code elevates to unmanaged code permission</SecurityNote> 
          [System.Security.SecurityCritical, System.Security.SuppressUnmanagedCodeSecurity]
          [DllImport(NativeExternDll.User32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false)]
          internal static extern int RegisterClipboardFormat(string format);


          [DllImport(NativeExternDll.User32, CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "GetClipboardSequenceNumber")]
          //DWORD WINAPI GetClipboardSequenceNumber(void);
          internal static extern uint GetClipboardSequenceNumber();


          [DllImport(NativeExternDll.User32, EntryPoint = "DrawAnimatedRects")]
          [return: MarshalAs(UnmanagedType.Bool)]
          internal static extern bool DrawAnimatedRects(System.IntPtr hwnd, int idAni, [In] ref RECT lprcFrom, [In] ref RECT lprcTo);


          [DllImport(NativeExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
          //HDESK WINAPI CreateDesktop(__in LPCTSTR lpszDesktop, __reserved LPCTSTR lpszDevice, __reserved DEVMODE *pDevmode, __in DWORD dwFlags, __in ACCESS_MASK dwDesiredAccess, __in_opt LPSECURITY_ATTRIBUTES lpsa);
          internal static extern System.IntPtr CreateDesktop(string lpszDesktop, System.IntPtr lpszDevice, System.IntPtr pDevmode, uint dwFlags, [MarshalAs(UnmanagedType.U4)] DesktopFlags dwDesiredAccess, System.IntPtr lpSecurityAttributes);


          [DllImport(NativeExternDll.User32, SetLastError = true, EntryPoint = "CloseDesktop")]
          [return: MarshalAs(UnmanagedType.Bool)]
          internal static extern bool CloseDesktop(System.IntPtr desktopHandle);


          [DllImport(NativeExternDll.User32, CharSet = CharSet.Auto)]
          internal static extern System.IntPtr GetDesktopWindow();


          [DllImport(NativeExternDll.User32, SetLastError = true, EntryPoint = "SwitchDesktop")]
          [return: MarshalAs(UnmanagedType.Bool)]
          internal static extern bool SwitchDesktop(System.IntPtr desktopHandle);


          [DllImport(NativeExternDll.User32, SetLastError = true, EntryPoint = "OpenInputDesktop")]
          internal static extern System.IntPtr OpenInputDesktop(uint dwFlags, [MarshalAs(UnmanagedType.Bool)] bool fInherit, [MarshalAs(UnmanagedType.U4)] DesktopFlags dwDesiredAccess);


          [DllImport(NativeExternDll.User32, SetLastError = true)]
          internal static extern System.IntPtr GetThreadDesktop(uint dwThreadId);


          [DllImport(NativeExternDll.User32, SetLastError = true)]
          [return: MarshalAs(UnmanagedType.Bool)]
          internal static extern bool SetThreadDesktop(System.IntPtr desktopHandle);


          [DllImport(NativeExternDll.User32, SetLastError = true)]
          [ResourceExposure(ResourceScope.None)]
          [return: MarshalAs(UnmanagedType.Bool)]
          internal static extern bool GetUserObjectInformation(System.IntPtr objectHandle, int nIndex, [MarshalAs(UnmanagedType.LPStruct)] USEROBJECTFLAGS pvBuffer, int length, ref int lpnLengthNeeded);


          [DllImport(NativeExternDll.User32, SetLastError = true)]
          internal static extern int GetScrollInfo(System.IntPtr scrollBarHandle, int fnBar, ref SCROLLINFO scrollInfo);


          [DllImport(NativeExternDll.User32, CharSet = CharSet.Auto)]
          internal static extern int SetScrollInfo(System.IntPtr scrollBarHandle, int fnBar, [In] ref SCROLLINFO scrollInfo, bool redraw);


          [DllImport(NativeExternDll.User32, CharSet = CharSet.Auto, ExactSpelling = true, EntryPoint = "GetKeyboardLayout")]
          internal static extern System.IntPtr GetKeyboardLayout(int dwLayout);


          [DllImport(NativeExternDll.User32, CharSet = CharSet.Auto, ExactSpelling = true)]
          internal static extern System.IntPtr ActivateKeyboardLayout(System.IntPtr hkl, int flags);


          [DllImport(NativeExternDll.User32, SetLastError = true)]
          internal static extern int GetWindowThreadProcessId([In] System.IntPtr windowHandle, [Out] out int processId);


          [DllImport(NativeExternDll.User32, SetLastError = true)]
          [return: MarshalAs(UnmanagedType.Bool)]
          internal static extern bool DestroyIcon(System.IntPtr hIcon);


          [DllImport(NativeExternDll.User32, CharSet = CharSet.Auto)]
          //函数原型：int WINAPI MessageBox(__in_opt HWND hWnd, __in_opt LPCTSTR lpText, __in_opt LPCTSTR lpCaption, __in UINT uType);
          internal static extern int MessageBox(System.IntPtr hWnd, string lpText, string lpCaption, int type);


          [DllImport(NativeExternDll.User32, CharSet = CharSet.Auto)]
          internal static extern int MessageBox(System.IntPtr hWnd, string lpText, string lpCaption, [MarshalAs(UnmanagedType.U4)] MessageBoxFlags uType);


          [DllImport(NativeExternDll.User32, CharSet = CharSet.Auto, EntryPoint = "GetDC")]
          internal static extern System.IntPtr GetDC(System.IntPtr deviceContextHandle);


          [DllImport(NativeExternDll.User32, CharSet = CharSet.Auto, EntryPoint = "ReleaseDC")]
          internal static extern System.IntPtr ReleaseDC(System.IntPtr deviceContextHandle, System.IntPtr deviceHandle);


          [DllImport(NativeExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
          [return: MarshalAs(UnmanagedType.Bool)]
          //BOOL WINAPI SetProcessDPIAware(void);
          internal static extern bool SetProcessDPIAware();


          [DllImport(NativeExternDll.User32, SetLastError = true)]
          [return: MarshalAs(UnmanagedType.Bool)]
          internal static extern bool ShutdownBlockReasonCreate(System.IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)] string reason);


          [DllImport(NativeExternDll.User32, SetLastError = true)]
          [return: MarshalAs(UnmanagedType.Bool)]
          internal static extern bool ShutdownBlockReasonDestroy(System.IntPtr hWnd);


          [DllImport(NativeExternDll.Kernel32, SetLastError = true)]
          [ResourceExposure(ResourceScope.Machine)]
          [System.Runtime.ConstrainedExecution.ReliabilityContract(System.Runtime.ConstrainedExecution.Consistency.WillNotCorruptState, System.Runtime.ConstrainedExecution.Cer.Success)]
          [return: MarshalAs(UnmanagedType.Bool)]
          internal static extern bool CloseHandle(System.IntPtr handle);


          [DllImport(NativeExternDll.Kernel32, CharSet = CharSet.Auto, ExactSpelling = false, SetLastError = true, BestFitMapping = false)]
          [ResourceExposure(ResourceScope.None)]
          [return: MarshalAs(UnmanagedType.Bool)]
          internal static extern bool GetVolumeInformation(string rootPathName, System.Text.StringBuilder volumeNameBuffer, int volumeNameSize, out int volumeSerialNumber, out int maximumComponentLength, out int fileSystemFlags, System.Text.StringBuilder fileSystemNameBuffer, int fileSystemNameSize);


          [DllImport(NativeExternDll.Kernel32, CharSet = CharSet.Auto, ExactSpelling = false, SetLastError = true, BestFitMapping = false)]
          [return: MarshalAs(UnmanagedType.Bool)]
          //BOOL WINAPI MoveFileEx(__in LPCTSTR lpExistingFileName, __in_opt LPCTSTR lpNewFileName, __in DWORD dwFlags);
          internal static extern bool MoveFileEx(string lpExistingFileName, string lpNewFileName, int dwFlags);


          [DllImport(NativeExternDll.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
          [return: MarshalAs(UnmanagedType.Bool)]
          internal static extern bool SetDllDirectory(string pathName);


          [DllImport(NativeExternDll.Kernel32, CharSet = CharSet.Auto, ExactSpelling = true)]
          internal static extern System.IntPtr GlobalAlloc(int flags, System.UIntPtr bytes);


          [DllImport(NativeExternDll.Kernel32, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
          internal static extern System.IntPtr GlobalFree(System.IntPtr memoryHandle);


          [DllImport(NativeExternDll.Kernel32, CharSet = CharSet.Auto, ExactSpelling = true, EntryPoint = "GlobalLock")]
          internal static extern System.IntPtr GlobalLock(System.IntPtr memoryHandle);


          [DllImport(NativeExternDll.Kernel32, CharSet = CharSet.Auto, ExactSpelling = true, EntryPoint = "GlobalUnlock")]
          [return: MarshalAs(UnmanagedType.Bool)]
          internal static extern bool GlobalUnlock(System.IntPtr handle);


          [DllImport(NativeExternDll.Kernel32, SetLastError = true, EntryPoint = "GlobalSize")]
          internal static extern int GlobalSize(System.IntPtr memoryHandle);


          [DllImport(NativeExternDll.Kernel32, CharSet = CharSet.Auto, ExactSpelling = true)]
          internal static extern int GetCurrentThreadId();


          [DllImport(NativeExternDll.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
          internal static extern System.IntPtr CreateFile(string lpFileName,
               [MarshalAs(UnmanagedType.U4)] EFileAccess dwDesiredAccess,
               [MarshalAs(UnmanagedType.U4)] EFileShare dwShareMode,
               System.IntPtr lpSecurityAttributes,
               [MarshalAs(UnmanagedType.U4)] ECreationDisposition dwCreationDisposition,
               [MarshalAs(UnmanagedType.U4)] uint dwFlagsAndAttributes,
               System.IntPtr hTemplateFile);


          [DllImport(NativeExternDll.Kernel32, CharSet = CharSet.Auto, SetLastError = true)]
          internal static extern int GetFileAttributes(string fileName);


          [DllImport(NativeExternDll.Kernel32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false)]
          [return: MarshalAs(UnmanagedType.Bool)]
          internal static extern bool DeleteFile([In] string fileName);


          [DllImport(NativeExternDll.Kernel32, ExactSpelling = true, SetLastError = true)]
          [return: MarshalAs(UnmanagedType.Bool)]
          internal static extern bool DeviceIoControl(System.IntPtr device, uint dwIoControlCode, System.IntPtr lpInBuffer,
               uint nInBufferSize, System.IntPtr lpOutBuffer, uint nOutBufferSize, out uint lpBytesReturned, System.IntPtr lpOverlapped);


          [DllImport(NativeExternDll.Kernel32, CharSet = CharSet.Auto, SetLastError = true)]
          internal static extern System.IntPtr CreateToolhelp32Snapshot([MarshalAs(UnmanagedType.U4)] ToolHelpFlags dwFlags, uint th32ProcessID);


          [DllImport(NativeExternDll.Kernel32, CharSet = CharSet.Auto)]
          internal static extern uint WTSGetActiveConsoleSessionId();


          [DllImport(NativeExternDll.Shell32)]
          internal static extern void SHChangeNotify(int wEventId, uint flags, System.IntPtr dwItem1, System.IntPtr dwItem2);


          [DllImport(NativeExternDll.Shell32, CharSet = CharSet.Auto)]
          internal static extern System.IntPtr SHGetFileInfo(string path, int fileAttributes, out SHFILEINFO fileInfo, int cbFileInfo, int flags);


          [DllImport(NativeExternDll.Shell32, CharSet = CharSet.Auto)]
          internal static extern System.IntPtr ShellExecute(System.IntPtr hwnd, string operation, string file, string parameters, string directory, int showCommand);


          [DllImport(NativeExternDll.Gdi32, CharSet = CharSet.Auto, SetLastError = true), System.Security.SuppressUnmanagedCodeSecurity]
          [return: MarshalAs(UnmanagedType.Bool)]
          internal static extern bool DeleteObject(System.IntPtr objectHandle);


          [DllImport(NativeExternDll.Gdi32, SetLastError = true), System.Security.SuppressUnmanagedCodeSecurity]
          internal static extern int GetDeviceCaps(System.IntPtr deviceHandle, int Index);


          [DllImport(NativeExternDll.WinMM, CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "PlaySound")]
          [return: MarshalAs(UnmanagedType.Bool)]
          //BOOL PlaySound(LPCTSTR pszSound, HMODULE hmod, DWORD fdwSound);
          internal static extern bool PlaySound(string sound, System.IntPtr hModule, HuiruiSoft.Win32.Media.PlaySoundFlags falgs);


          private static bool? isUnixSystem = null;
          private static System.PlatformID? platformID = null;

          public static bool IsUnix()
          {
               if (isUnixSystem == null)
               {
                    var tmpPlatformID = GetPlatformID();
                    isUnixSystem = (tmpPlatformID == System.PlatformID.Unix || tmpPlatformID == System.PlatformID.MacOSX || (int)tmpPlatformID == 128);
               }

               return isUnixSystem.Value;
          }

          public static System.PlatformID GetPlatformID()
          {
               if (platformID == null)
               {
                    platformID = System.Environment.OSVersion.Platform;
               }

               return platformID.Value;
          }
     }
}