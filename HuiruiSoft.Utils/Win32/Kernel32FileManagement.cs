
using WORD = System.Int16;
using BOOL = System.Boolean;
using HANDLE = System.IntPtr;
using System.Security;
using System.Security.Permissions;
using System.Runtime.Versioning;
using System.Runtime.InteropServices;

namespace HuiruiSoft.Win32
{
     public static partial class Kernel32NativeMethods
     {
          internal const int MAX_ALTERNATE = 14;

          // From WinBase.h 
          internal const int FILE_TYPE_UNKNOWN = 0x0000;
          internal const int FILE_TYPE_DISK    = 0x0001;
          internal const int FILE_TYPE_CHAR    = 0x0002;
          internal const int FILE_TYPE_PIPE    = 0x0003;
          internal const int FILE_TYPE_REMOTE  = unchecked((int)0x8000);

          // Constants from WinNT.h 
          internal const int FILE_ATTRIBUTE_READONLY       = 0x00000001;
          internal const int FILE_ATTRIBUTE_DIRECTORY      = 0x00000010;
          internal const int FILE_ATTRIBUTE_REPARSE_POINT  = 0x00000400;
          internal const int FILE_ATTRIBUTE_NORMAL         = 0x00000080;

          // dwAdditionalFlags:
          public const int FIND_FIRST_EX_CASE_SENSITIVE    = 1;
          public const int FIND_FIRST_EX_LARGE_FETCH       = 2;


          internal const uint INVALID_FILE_SIZE            = (0xFFFFFFFF);
          internal const int INVALID_SET_FILE_POINTER      = (-1);
          internal const int INVALID_FILE_ATTRIBUTES       = (-1);

          internal const int FILE_READ_DATA                = 0x00000001;
          internal const int FILE_WRITE_DATA               = 0x00000002;
          internal const int FILE_READ_PROPERTIES          = FILE_READ_EA;
          internal const int FILE_WRITE_PROPERTIES         = FILE_WRITE_EA;

          internal const int FILE_LIST_DIRECTORY           = 0x00000001;
          internal const int FILE_ADD_FILE                 = 0x00000002;    // directory
          internal const int FILE_APPEND_DATA              = 0x00000004;    // file
          internal const int FILE_ADD_SUBDIRECTORY         = 0x00000004;    // directory 
          internal const int FILE_READ_EA                  = 0x00000008;    // file & directory 
          internal const int FILE_WRITE_EA                 = 0x00000010;    // file & directory 
          internal const int FILE_EXECUTE                  = 0x00000020;    // file
          internal const int FILE_TRAVERSE                 = 0x00000020;    // directory 
          internal const int FILE_DELETE_CHILD             = 0x00000040;    // directory
          internal const int FILE_READ_ATTRIBUTES          = 0x00000080;    // all
          internal const int FILE_WRITE_ATTRIBUTES         = 0x00000100;    // all


          internal const int FILE_ACTION_ADDED             = 0x00000001;
          internal const int FILE_ACTION_REMOVED           = 0x00000002;
          internal const int FILE_ACTION_MODIFIED          = 0x00000003;
          internal const int FILE_ACTION_RENAMED_OLD_NAME  = 0x00000004;
          internal const int FILE_ACTION_RENAMED_NEW_NAME  = 0x00000005;

          internal const int FILE_FLAG_POSIX_SEMANTICS     = 0x01000000;
          internal const int FILE_FLAG_BACKUP_SEMANTICS    = 0x02000000;
          internal const int FILE_FLAG_DELETE_ON_CLOSE     = 0x04000000;
          internal const int FILE_FLAG_SEQUENTIAL_SCAN     = 0x08000000;
          internal const int FILE_FLAG_RANDOM_ACCESS       = 0x10000000;
          internal const int FILE_FLAG_NO_BUFFERING        = 0x20000000;
          internal const int FILE_FLAG_OVERLAPPED          = 0x40000000;
          internal const int FILE_FLAG_WRITE_THROUGH       = unchecked((int)0x80000000);

          internal const int SYNCHRONIZE                   = 0x00100000;
          internal const int READ_CONTROL                  = 0x00020000;
          internal const int STANDARD_RIGHTS_ALL           = 0x001F0000;
          internal const int STANDARD_RIGHTS_EXECUTE       = READ_CONTROL;
          internal const int STANDARD_RIGHTS_READ          = READ_CONTROL;
          internal const int STANDARD_RIGHTS_WRITE         = READ_CONTROL;
          internal const int STANDARD_RIGHTS_REQUIRED      = 0x000F0000;

          internal const int SECTION_QUERY                 = 0x0001;
          internal const int SECTION_MAP_WRITE             = 0x0002;
          internal const int SECTION_MAP_READ              = 0x0004;
          internal const int SECTION_MAP_EXECUTE           = 0x0008;
          internal const int SECTION_EXTEND_SIZE           = 0x0010;
          internal const int SECTION_ALL_ACCESS            = STANDARD_RIGHTS_REQUIRED | SECTION_QUERY | SECTION_MAP_WRITE | SECTION_MAP_READ | SECTION_MAP_EXECUTE | SECTION_EXTEND_SIZE;

          internal const string LSTRCPY = "lstrcpy";
          internal const string LSTRCPYN = "lstrcpyn";
          internal const string LSTRLEN = "lstrlen";
          internal const string LSTRLENA = "lstrlenA";
          internal const string LSTRLENW = "lstrlenW";

          [ResourceExposure(ResourceScope.None)]
          [DllImport(NativeExternDll.Kernel32, CharSet = CharSet.Auto, EntryPoint = LSTRLEN)]
          // int WINAPI lstrlen(__in LPCTSTR lpString);
          internal static extern int lstrlen(sbyte[] ptr);
     }
}