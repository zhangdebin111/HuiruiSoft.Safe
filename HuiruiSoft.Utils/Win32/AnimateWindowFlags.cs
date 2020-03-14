
namespace HuiruiSoft.Win32
{
     [System.Flags]
     public enum AnimateWindowFlags
     {
          AW_HOR_POSITIVE = 0x00001,

          AW_HOR_NEGATIVE = 0x00002,

          AW_VER_POSITIVE = 0X00004,

          AW_VER_NEGATIVE = 0x00008,

          AW_CENTER      = 0x00010,

          AW_HIDE        = 0x10000,

          AW_ACTIVATE    = 0x20000,

          AW_SLIDE       = 0x40000,

          AW_BLEND       = 0x80000
     }
}