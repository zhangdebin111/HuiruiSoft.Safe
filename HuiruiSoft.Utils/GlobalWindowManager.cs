
using System.Windows.Forms;
using System.Collections.Generic;

namespace HuiruiSoft.Utils
{
     public static class GlobalWindowManager
     {
          private static readonly object rootSyncObject = new object();

          private static List<Form> windowTable = new List<Form>();
          private static List<CommonDialog> dialogTable = new List<CommonDialog>();

          public static void AddDialog(CommonDialog dialog)
          {
               System.Diagnostics.Debug.Assert(dialog != null);
               if (dialog == null)
               {
                    throw new System.ArgumentNullException("dialog");
               }

               lock (rootSyncObject)
               {
                    dialogTable.Add(dialog);
               }
          }

          public static void RemoveDialog(CommonDialog dialog)
          {
               System.Diagnostics.Debug.Assert(dialog != null);
               if (dialog == null)
               {
                    throw new System.ArgumentNullException("dialog");
               }

               lock (rootSyncObject)
               {
                    System.Diagnostics.Debug.Assert(dialogTable.IndexOf(dialog) >= 0);
                    dialogTable.Remove(dialog);
               }
          }

          public static void AddWindow(System.Windows.Forms.Form form, bool canClose = true)
          {
               System.Diagnostics.Debug.Assert(form != null);
               if (form == null)
               {
                    throw new System.ArgumentNullException("form");
               }

               lock (rootSyncObject)
               {
                    windowTable.Add(form);
               }
          }

          public static void RemoveWindow(System.Windows.Forms.Form form)
          {
               System.Diagnostics.Debug.Assert(form != null);
               if (form == null)
               {
                    throw new System.ArgumentNullException("form");
               }

               lock (rootSyncObject)
               {
                    System.Diagnostics.Debug.Assert(windowTable.IndexOf(form) >= 0);
                    if (windowTable.IndexOf(form) >= 0)
                    {
                         windowTable.Remove(form);
                    }
               }
          }

          public static void HideAllWindows()
          {
               lock (rootSyncObject)
               {

                    foreach (Form window in Application.OpenForms)
                    {
                         window.Hide();
                         Application.DoEvents();
                    }

                    foreach (CommonDialog dialog in dialogTable)
                    {
                         //Application.DoEvents();
                    }
               }
          }

          public static void ShowAllWindows()
          {
               lock (rootSyncObject)
               {
                    foreach (Form window in Application.OpenForms)
                    {
                         if (!window.IsDisposed)
                         {
                              window.Visible = true;
                         }

                         Application.DoEvents();
                    }

                    foreach (CommonDialog dialog in dialogTable)
                    {
                         //Application.DoEvents();
                    }
               }
          }
     }
}