
using System.Runtime.InteropServices;

namespace HuiruiSoft.Win32
{
     [StructLayout(LayoutKind.Sequential)]
     public struct SCROLLINFO
     {
          public int cbSize;

          public int fMask;

          public int nMin, nMax, nPage, nPos, nTrackPos;

          public void Initialize( )
          {
               this.cbSize = Marshal.SizeOf(this);
               this.nMin = this.nMax = this.nPage = this.nPos = this.nTrackPos = 0;
               this.fMask = HuiruiSoft.Win32.NativeMethods.SIF_ALL;
          }

          /*           
           typedef struct tagSCROLLINFO
           {
                 UINT cbSize;
                 UINT fMask;
                 int  nMin;
                 int  nMax;
                 UINT nPage;
                 int  nPos;
                 int  nTrackPos;
           } SCROLLINFO, **LPCSCROLLINFO;
           */
     }
}