
namespace HuiruiSoft.Win32.Media
{
     [System.Flags]
     public enum PlaySoundFlags : int
     {
          SND_SYNC        = 0x00000000,

          SND_ASYNC       = 0x00000001,

          SND_NODEFAULT   = 0x00000002,

          SND_MEMORY      = 0x00000004,

          SND_LOOP        = 0x00000008,

          SND_NOSTOP      = 0x00000010,

          SND_NOWAIT      = 0x00002000,

          SND_ALIAS       = 0x00010000,

          SND_ALIAS_ID    = 0x00110000,

          SND_FILENAME    = 0x00020000,

          SND_RESOURCE    = 0x00040004,

          SND_PURGE       = 0x00000040,

          SND_APPLICATION = 0x00000080,
     }
}