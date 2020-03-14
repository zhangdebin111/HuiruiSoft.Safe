using Microsoft.Win32;
using System.Diagnostics;

namespace HuiruiSoft.Utils
{
     public static class NativeShellHelper
     {
          private const string REGKEY_CLASSES_ROOT     = "HKEY_CLASSES_ROOT";
          private const string REGKEY_CURRENT_USER     = "HKEY_CURRENT_USER";
          private const string REGKEY_LOCAL_MACHINE    = "HKEY_LOCAL_MACHINE";
          private const string REGKEY_USERS            = "HKEY_USERS";
          private const string REGKEY_CURRENT_CONFIG   = "HKEY_CURRENT_CONFIG";
          private const string REGKEY_DYN_DATA         = "HKEY_DYN_DATA";

          private const string SafePassKey   = @"Software\HuiruiSoft\SafePass";
          private const string WorkPathKey   = @"WorkPath";
          private const string AutoRunKey    = @"Software\Microsoft\Windows\CurrentVersion\Run";

          public static string GetWorkingDirectory()
          {
               string tmpWorkDirectory = null;

               try
               {
                    string tmpNotFound = System.Guid.NewGuid().ToString();
                    string tmpWorkPath = Registry.GetValue(string.Format("{0}\\{1}", REGKEY_CURRENT_USER, SafePassKey), WorkPathKey, tmpNotFound) as string;

                    if (!string.IsNullOrEmpty(tmpWorkPath) && tmpWorkPath != tmpNotFound)
                    {
                         tmpWorkDirectory = tmpWorkPath;
                    }
               }
               catch (System.Exception)
               {
                    System.Diagnostics.Debug.Assert(false);
               }

               return tmpWorkDirectory;
          }

          public static bool SetDefaultWorkingDirectory()
          {
               bool tmpExecResult = false;

               var tmpWorkDirectory = System.IO.Path.Combine(GetLocalDataDirectory(), @"HuiruiSoft\SafePass");
               try
               {
                    var tmpDirectoryInfo = new System.IO.DirectoryInfo(tmpWorkDirectory);
                    if (!tmpDirectoryInfo.Exists)
                    {
                         tmpDirectoryInfo = System.IO.Directory.CreateDirectory(tmpWorkDirectory);
                    }

                    if (tmpDirectoryInfo != null && tmpDirectoryInfo.Exists)
                    {
                         Registry.SetValue(string.Format("{0}\\{1}", REGKEY_CURRENT_USER, SafePassKey), WorkPathKey, tmpWorkDirectory);
                         tmpExecResult = true;
                    }
               }
               catch (System.Exception exception)
               {
                    System.Diagnostics.Debug.Fail(exception.StackTrace);
               }

               return tmpExecResult;
          }

          public static void SetWorkingDirectory(string workDirectory)
          {
               try
               {
                    Registry.SetValue(string.Format("{0}\\{1}", REGKEY_CURRENT_USER, SafePassKey), WorkPathKey, workDirectory);
               }
               catch (System.Exception exception)
               {
                    System.Diagnostics.Debug.Fail(exception.StackTrace);
               }
          }

          public static string GetLocalDataDirectory()
          {
               string tmpWorkDirectory = null;
               try
               {
                    tmpWorkDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
               }
               catch (System.Exception)
               {
                    System.Diagnostics.Debug.Assert(false);
               }

               return tmpWorkDirectory;
          }

          public static bool GetStartWithWindows(string appName)
          {
               try
               {
                    string tmpNotFound = System.Guid.NewGuid().ToString();
                    string tmpExecPath = Registry.GetValue(string.Format("{0}\\{1}", REGKEY_CURRENT_USER, AutoRunKey), appName, tmpNotFound) as string;

                    return !string.IsNullOrEmpty(tmpExecPath) && tmpExecPath != tmpNotFound;
               }
               catch (System.Exception)
               {
                    System.Diagnostics.Debug.Assert(false);
               }

               return false;
          }

          public static void SetStartWithWindows(string appName, string appPath, bool autoStart)
          {
               string tmpRegistryKey = string.Format("{0}\\{1}", REGKEY_CURRENT_USER, AutoRunKey);

               try
               {
                    if (autoStart)
                    {
                         Registry.SetValue(tmpRegistryKey, appName, appPath, RegistryValueKind.String);
                    }
                    else
                    {
                         using (RegistryKey tmpAutoRunKey = Registry.CurrentUser.OpenSubKey(AutoRunKey, true))
                         {
                              tmpAutoRunKey.DeleteValue(appName);
                         }
                    }
               }
               catch (System.Exception exception)
               {
                    System.Diagnostics.Debug.Fail(exception.StackTrace);
               }
          }

          public static void StartProcess(string fileName, string arguments = null)
          {
               var tmpProcessInfo = new ProcessStartInfo();
               if (!string.IsNullOrEmpty(fileName))
               {
                    tmpProcessInfo.FileName = fileName;
               }

               if (!string.IsNullOrEmpty(arguments))
               {
                    tmpProcessInfo.Arguments = arguments;
               }

               StartProcess(tmpProcessInfo);
          }

          public static void StartProcess(ProcessStartInfo processStartInfo)
          {
               Process tmpProcess = StartRunProcess(processStartInfo);

               try
               {
                    if (tmpProcess != null)
                    {
                         tmpProcess.Dispose();
                    }
               }
               catch (System.Exception)
               {
                    Debug.Assert(false);
               }
          }

          public static Process StartRunProcess(ProcessStartInfo processStartInfo)
          {
               if (processStartInfo == null)
               {
                    Debug.Assert(false);
                    return null;
               }

               string tmpFileOriginal = processStartInfo.FileName;
               if (string.IsNullOrEmpty(tmpFileOriginal))
               {
                    Debug.Assert(false);
                    return null;
               }

               Process tmpProcess;
               try
               {
                    string tmpFileName = tmpFileOriginal;

                    string[] tmpUrlSchemes = new string[] { "file:", "ftp:", "ftps:", "http:", "https:", "mailto:", "scp:", "sftp:" };

                    foreach (string tmpUrlScheme in tmpUrlSchemes)
                    {
                         if (tmpFileName.StartsWith(tmpUrlScheme, System.StringComparison.OrdinalIgnoreCase))
                         {
                              Debug.Assert(string.IsNullOrEmpty(processStartInfo.Arguments));

                              tmpFileName = tmpFileName.Replace("\"", "%22");
                              tmpFileName = tmpFileName.Replace("\'", "%27");
                              tmpFileName = tmpFileName.Replace("\\", "%5C");

                              break;
                         }
                    }

                    processStartInfo.FileName = tmpFileName;
                    tmpProcess = Process.Start(processStartInfo);
               }
               finally
               {
                    processStartInfo.FileName = tmpFileOriginal;
               }

               return tmpProcess;
          }
     }
}
