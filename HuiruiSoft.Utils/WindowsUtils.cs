
namespace HuiruiSoft.Utils
{
     using System.Windows.Forms;
     using HuiruiSoft.Win32;

     public static class WindowsUtils
     {
          public static bool IsWindows9x { get; private set; } = false;

          public static bool IsWindowsXP { get; private set; } = false;

          public static bool IsWindows2000 { get; private set; } = false;

          public static bool IsAtLeastWindows7 { get; private set; } = false;

          public static bool IsAtLeastWindows8 { get; private set; } = false;

          public static bool IsAtLeastWindows10 { get; private set; } = false;

          public static bool IsAtLeastWindows2000 { get; private set; } = false;

          public static bool IsAtLeastWindowsVista { get; private set; } = false;

          public static bool IsWindowsAppX { get; } = false;

          private static System.Drawing.Icon defaultAppIcon = null;

          public static System.Drawing.Icon DefaultAppIcon
          {
               get
               {
                    return defaultAppIcon;
               }
          }


          private static string executablePath = null;

          private static System.Drawing.Image imageShowPassword = null;
          private static System.Drawing.Image imageHidePassword = null;


          static WindowsUtils()
          {
               var tmpOperatingSystem = System.Environment.OSVersion;
               var tmpSystemVersion = tmpOperatingSystem.Version;

               IsWindows9x = (tmpOperatingSystem.Platform == System.PlatformID.Win32Windows);
               IsWindowsXP = (tmpSystemVersion.Major == 5 && tmpSystemVersion.Minor == 1);
               IsWindows2000 = (tmpSystemVersion.Major == 5 && tmpSystemVersion.Minor == 0);

               IsAtLeastWindows2000 = (tmpSystemVersion.Major >= 5);
               IsAtLeastWindowsVista = (tmpSystemVersion.Major >= 6);
               IsAtLeastWindows7 = (tmpSystemVersion.Major >= 7 || (tmpSystemVersion.Major == 6 && tmpSystemVersion.Minor >= 1));
               IsAtLeastWindows8 = (tmpSystemVersion.Major >= 7 || (tmpSystemVersion.Major == 6 && tmpSystemVersion.Minor >= 2));

               // https://msdn.microsoft.com/library/windows/desktop/ms724832.aspx
               Microsoft.Win32.RegistryKey tmpRegistryKey = null;
               try
               {
                    tmpRegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", false);
                    if (tmpRegistryKey == null)
                    {
                         System.Diagnostics.Debug.Assert(NativeMethods.IsUnix());
                    }
                    else
                    {
                         var tmpMajorVersion = tmpRegistryKey.GetValue("CurrentMajorVersionNumber", string.Empty).ToString();

                         uint u;
                         if (uint.TryParse(tmpMajorVersion, out u))
                         {
                              IsAtLeastWindows10 = (u >= 10);
                         }
                         else
                         {
                              System.Diagnostics.Debug.Assert(string.IsNullOrEmpty(tmpMajorVersion));
                         }
                    }
               }
               catch (System.Exception)
               {
                    System.Diagnostics.Debug.Assert(NativeMethods.IsUnix());
               }
               finally
               {
                    if (tmpRegistryKey != null)
                    {
                         tmpRegistryKey.Close();
                    }
               }
          }

          public static void LoadAppIconFromResource(System.Type resourceFinder)
          {
               try
               {
                    defaultAppIcon = ResourceImageHelper.CreateIconFromResource("resources.images.SafePass.ico", resourceFinder);
               }
               catch (System.Exception exception)
               {
                    System.Diagnostics.Debug.WriteLine(exception.StackTrace);
               }
          }

          public static void LoadImageFromResource(System.Type resourceFinder)
          {
               try
               {
                    imageShowPassword = ResourceImageHelper.CreateImageFromResource("resources.images.show-password32x32.png", resourceFinder);
               }
               catch (System.Exception exception)
               {
                    System.Diagnostics.Debug.WriteLine(exception.StackTrace);
               }

               try
               {
                    imageHidePassword = ResourceImageHelper.CreateImageFromResource("resources.images.hide-password32x32.png", resourceFinder);
               }
               catch (System.Exception exception)
               {
                    System.Diagnostics.Debug.WriteLine(exception.StackTrace);
               }
          }

          public static void SetShowPasswordImage(System.Windows.Forms.Button buttonControl, bool showPassword)
          {
               if (buttonControl != null)
               {
                    if (showPassword)
                    {
                         if (imageShowPassword != null)
                         {
                              buttonControl.Image = imageShowPassword;
                         }
                    }
                    else
                    {
                         if (imageHidePassword != null)
                         {
                              buttonControl.Image = imageHidePassword;
                         }
                    }
               }
          }

          public static System.Drawing.Bitmap InvertImage(System.Drawing.Image image)
          {
               var tmpColorMatrix = new System.Drawing.Imaging.ColorMatrix(new float[][] {
                    new float[] { -1, 0, 0, 0, 0 },
                    new float[] { 0, -1, 0, 0, 0 },
                    new float[] { 0, 0, -1, 0, 0 },
                    new float[] { 0, 0, 0, 1, 0 },
                    new float[] { 1, 1, 1, 0, 1 }
               });

               return CloneWithColorMatrix(image, tmpColorMatrix);
          }

          public static System.Drawing.Bitmap CreateGrayImage(System.Drawing.Image image)
          {
               var tmpColorMatrix = new System.Drawing.Imaging.ColorMatrix(new float[][] {
                    new float[] { 0.30f, 0.30f, 0.30f, 0, 0 },
                    new float[] { 0.59f, 0.59f, 0.59f, 0, 0 },
                    new float[] { 0.11f, 0.11f, 0.11f, 0, 0 },
                    new float[] { 0.00f, 0.00f, 0.00f, 1, 0 },
                    new float[] { 0.00f, 0.00f, 0.00f, 0, 1 }
               });

               return CloneWithColorMatrix(image, tmpColorMatrix);
          }


          private static System.Drawing.Bitmap CloneWithColorMatrix(System.Drawing.Image image, System.Drawing.Imaging.ColorMatrix colorMatrix)
          {
               if (image == null || colorMatrix == null)
               {
                    System.Diagnostics.Debug.Assert(false);
                    return null;
               }

               try
               {
                    int width = image.Width, height = image.Height;

                    var tmpClonedBitmap = new System.Drawing.Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    using (var tmpGraphics = System.Drawing.Graphics.FromImage(tmpClonedBitmap))
                    {
                         tmpGraphics.Clear(System.Drawing.Color.Transparent);
                         tmpGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                         tmpGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

                         var tmpImageAttributes = new System.Drawing.Imaging.ImageAttributes();
                         tmpImageAttributes.SetColorMatrix(colorMatrix);
                         tmpGraphics.DrawImage(image, new System.Drawing.Rectangle(0, 0, width, height), 0, 0, width, height, System.Drawing.GraphicsUnit.Pixel, tmpImageAttributes);
                    }

                    return tmpClonedBitmap;
               }
               catch (System.Exception)
               {
                    System.Diagnostics.Debug.Assert(false);
               }

               return null;
          }

          public static void SetWindowState(Form window, FormWindowState windowState)
          {
               if (window == null)
               {
                    System.Diagnostics.Debug.Assert(false);
                    return;
               }

               window.WindowState = windowState;

               try
               {
                    var tmpStateCached = window.WindowState;

                    var tmpWindowHandle = window.Handle;
                    if (tmpWindowHandle == System.IntPtr.Zero)
                    {
                         System.Diagnostics.Debug.Assert(false);
                         return;
                    }

                    var tmpRealMinimized = NativeMethods.IsIconic(tmpWindowHandle);
                    var tmpRealMaximized = NativeMethods.IsZoomed(tmpWindowHandle);

                    FormWindowState? tmpFixWindowState = null;
                    if (tmpRealMinimized && (tmpStateCached != FormWindowState.Minimized))
                    {
                         tmpFixWindowState = FormWindowState.Minimized;
                    }
                    else if (tmpRealMaximized && (tmpStateCached != FormWindowState.Maximized) && !tmpRealMinimized)
                    {
                         tmpFixWindowState = FormWindowState.Maximized;
                    }
                    else if (!tmpRealMinimized && !tmpRealMaximized && (tmpStateCached != FormWindowState.Normal))
                    {
                         tmpFixWindowState = FormWindowState.Normal;
                    }

                    if (tmpFixWindowState.HasValue)
                    {
                         var tmpWindowVisible = window.Visible;
                         if (tmpWindowVisible)
                         {
                              window.Visible = false;
                         }

                         window.WindowState = tmpFixWindowState.Value;

                         if (tmpWindowVisible)
                         {
                              window.Visible = true;
                         }
                    }
               }
               catch (System.Exception)
               {
                    System.Diagnostics.Debug.Assert(NativeMethods.IsUnix());
               }
          }

          public static string GetExecutablePath()
          {
               if (string.IsNullOrEmpty(executablePath))
               {
                    executablePath = System.Windows.Forms.Application.ExecutablePath;
               }

               return executablePath;
          }

          private static string assemblyVersion = null;

          internal static string GetAssemblyVersion()
          {
               if (assemblyVersion == null)
               {
                    try
                    {
                         var tmpVersion = typeof(WindowsUtils).Assembly.GetName().Version;
                         assemblyVersion = tmpVersion.ToString(4);
                    }
                    catch (System.Exception)
                    {
                         System.Diagnostics.Debug.Assert(false);
                    }

                    if (assemblyVersion == null)
                    {
                         // g_strAsmVersion = StrUtil.VersionToString(PwDefs.FileVersion64, 4);  // TODO
                    }
               }

               return assemblyVersion;
          }

          public static string GetHomeDirectory()
          {
               string tmpHomeDirectory = null;
               try
               {
                    tmpHomeDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
               }
               catch (System.Exception)
               {
                    System.Diagnostics.Debug.Assert(false);
               }

               if (string.IsNullOrEmpty(tmpHomeDirectory))
               {
                    try
                    {
                         tmpHomeDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                    }
                    catch (System.Exception)
                    {
                         System.Diagnostics.Debug.Assert(false);
                    }
               }

               if (string.IsNullOrEmpty(tmpHomeDirectory))
               {
                    System.Diagnostics.Debug.Assert(false);
               }

               return string.IsNullOrEmpty(tmpHomeDirectory) ? string.Empty : tmpHomeDirectory;
          }

          public static string GetCurrentDirectory()
          {
               string tmpWorkingDirectory = null;
               try
               {
                    tmpWorkingDirectory = System.IO.Directory.GetCurrentDirectory();
               }
               catch (System.Exception)
               {
                    System.Diagnostics.Debug.Assert(false);
               }

               return !string.IsNullOrEmpty(tmpWorkingDirectory) ? tmpWorkingDirectory : GetHomeDirectory();
          }

          public static void SetCurrentDirectory(string workingDirectory)
          {
               string tmpCurrentDirectory = workingDirectory; // May be null

               if (!string.IsNullOrEmpty(tmpCurrentDirectory))
               {
                    try
                    {
                         if (!System.IO.Directory.Exists(tmpCurrentDirectory))
                         {
                              tmpCurrentDirectory = null;
                         }
                    }
                    catch (System.Exception)
                    {
                         tmpCurrentDirectory = null;
                         System.Diagnostics.Debug.Assert(false);
                    }
               }

               if (string.IsNullOrEmpty(tmpCurrentDirectory))
               {
                    tmpCurrentDirectory = GetHomeDirectory(); // Not app dir
               }

               try
               {
                    System.IO.Directory.SetCurrentDirectory(tmpCurrentDirectory);
               }
               catch (System.Exception)
               {
                    System.Diagnostics.Debug.Assert(false);
               }
          }


          private static System.Windows.Forms.KeysConverter keysConverter = null;

          public static string GetKeysName(System.Windows.Forms.Keys key)
          {
               if (keysConverter == null)
               {
                    keysConverter = new System.Windows.Forms.KeysConverter();
               }

               return keysConverter.ConvertToString(key);
          }

          private static string keyboardCode_Alt = "Alt";
          private static string keyboardCode_Ctrl = "Ctrl";
          private static string keyboardCode_Shift = "Shift";

          public static void AssignShortcut(ToolStripMenuItem toolMenuItem, Keys shortcutKey)
          {
               if (toolMenuItem == null)
               {
                    System.Diagnostics.Debug.Assert(false);
               }
               else
               {
                    toolMenuItem.ShortcutKeys = shortcutKey;

                    string tmpKeyDisplayString = string.Empty;
                    if ((shortcutKey & Keys.Control) != Keys.None)
                    {
                         tmpKeyDisplayString += keyboardCode_Ctrl + "+";
                    }

                    if ((shortcutKey & Keys.Alt) != Keys.None)
                    {
                         tmpKeyDisplayString += keyboardCode_Alt + "+";
                    }

                    if ((shortcutKey & Keys.Shift) != Keys.None)
                    {
                         tmpKeyDisplayString += keyboardCode_Shift + "+";
                    }

                    tmpKeyDisplayString += GetKeysName(shortcutKey & Keys.KeyCode);

                    toolMenuItem.ShortcutKeyDisplayString = tmpKeyDisplayString;
               }
          }
     }
}
