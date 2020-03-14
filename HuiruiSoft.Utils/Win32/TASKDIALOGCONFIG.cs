
using System.Runtime.InteropServices;

namespace HuiruiSoft.Win32.Dialogs
{
     // Main task dialog configuration struct.
     // NOTE: Packing must be set to 4 to make this work on 64-bit platforms.
     [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
     public class TASKDIALOGCONFIG
     {
          public uint cbSize;

          public System.IntPtr hwndParent;

          public System.IntPtr hInstance;

          public TASKDIALOG_FLAGS dwFlags;

          public TASKDIALOG_COMMON_BUTTON_FLAGS dwCommonButtons;

          [MarshalAs(UnmanagedType.LPWStr)]
          public string pszWindowTitle;

          public TASKDIALOGCONFIG_ICON_UNION MainIcon; // NOTE: 32-bit union field, holds pszMainIcon as well

          [MarshalAs(UnmanagedType.LPWStr)]
          public string pszMainInstruction;

          [MarshalAs(UnmanagedType.LPWStr)]
          public string pszContent;

          public uint cButtons;

          public System.IntPtr pButtons;           // Ptr to TASKDIALOG_BUTTON structs

          public int nDefaultButton;

          public uint cRadioButtons;

          public System.IntPtr pRadioButtons;      // Ptr to TASKDIALOG_BUTTON structs

          public int nDefaultRadioButton;

          [MarshalAs(UnmanagedType.LPWStr)]
          public string pszVerificationText;

          [MarshalAs(UnmanagedType.LPWStr)]
          public string pszExpandedInformation;

          [MarshalAs(UnmanagedType.LPWStr)]
          public string pszExpandedControlText;

          [MarshalAs(UnmanagedType.LPWStr)]
          public string pszCollapsedControlText;

          public TASKDIALOGCONFIG_ICON_UNION FooterIcon;  // NOTE: 32-bit union field, holds pszFooterIcon as well

          [MarshalAs(UnmanagedType.LPWStr)]
          public string pszFooter;

          public TaskDialogCallback pfCallback;

          public System.IntPtr lpCallbackData;

          public uint cxWidth;


          public TASKDIALOGCONFIG(bool construct)
          {
               this.cbSize = (uint)Marshal.SizeOf(typeof(TASKDIALOGCONFIG));
               this.hwndParent = System.IntPtr.Zero;
               this.hInstance = System.IntPtr.Zero;

               this.dwFlags = TASKDIALOG_FLAGS.NONE;
               //if(Program.Translation.Properties.RightToLeft) dwFlags |= VtdFlags.RtlLayout;

               this.dwCommonButtons = TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_NONE_BUTTON;
               this.pszWindowTitle = null;
               this.MainIcon = new TASKDIALOGCONFIG_ICON_UNION( );
               this.pszMainInstruction = string.Empty;
               this.pszContent = string.Empty;
               this.cButtons = 0;
               this.pButtons = System.IntPtr.Zero;
               this.nDefaultButton = 0;
               this.cRadioButtons = 0;
               this.pRadioButtons = System.IntPtr.Zero;
               this.nDefaultRadioButton = 0;
               this.pszVerificationText = null;
               this.pszExpandedInformation = null;
               this.pszExpandedControlText = null;
               this.pszCollapsedControlText = null;
               this.FooterIcon = new TASKDIALOGCONFIG_ICON_UNION( );
               this.pszFooter = null;
               this.pfCallback = null;
               this.lpCallbackData = System.IntPtr.Zero;
               this.cxWidth = 0;
          }

          /*
           typedef struct _TASKDIALOGCONFIG
           {
                 UINT                           cbSize;
                 HWND                           hwndParent;
                 HINSTANCE                      hInstance;
                 TASKDIALOG_FLAGS               dwFlags;
                 TASKDIALOG_COMMON_BUTTON_FLAGS dwCommonButtons;
                 PCWSTR                         pszWindowTitle;
           
                 union
                 {
                      HICON  hMainIcon;
                      PCWSTR pszMainIcon;
                 } ;
           
                 PCWSTR                         pszMainInstruction;
                 PCWSTR                         pszContent;
                 UINT                           cButtons;
                 const TASKDIALOG_BUTTON        *pButtons;
                 int                            nDefaultButton;
                 UINT                           cRadioButtons;
                 const TASKDIALOG_BUTTON        *pRadioButtons;
                 int                            nDefaultRadioButton;
                 PCWSTR                         pszVerificationText;
                 PCWSTR                         pszExpandedInformation;
                 PCWSTR                         pszExpandedControlText;
                 PCWSTR                         pszCollapsedControlText;
           
                 union
                 {
                      HICON  hFooterIcon;
                      PCWSTR pszFooterIcon;
                 };
           
                 PCWSTR                         pszFooter;
                 PFTASKDIALOGCALLBACK           pfCallback;
                 LONG_PTR                       lpCallbackData;
                 UINT                           cxWidth;
           } TASKDIALOGCONFIG;
           */
     }
}