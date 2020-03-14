using System.Windows.Forms;
using HuiruiSoft.Security.Cryptography;

namespace HuiruiSoft.Utils
{
     public static partial class ClipboardHelper
     {
          private static byte[] dataHashSha256 = null;

          public static bool Copy(string text)
          {
               if (text == null)
               {
                    throw new System.ArgumentNullException("text");
               }

               if (text.Length == 0)
               {
                    Clear();
                    return true;
               }
               else
               {
                    dataHashSha256 = HashSha256String(text);
                    System.Windows.Forms.Clipboard.SetText(text);
               }

               return true;
          }

          public static void Clear()
          {
               dataHashSha256 = null;
               try
               {
                    System.Windows.Forms.Clipboard.Clear();
               }
               catch (System.Exception)
               {
                    System.Diagnostics.Debug.Assert(false);
               }
          }


          public static void ClearIfOwner()
          {
               if (dataHashSha256 == null)
               {
                    return;
               }

               byte[] clipboardHash = ComputeHash();
               if (clipboardHash == null || !ArraysEqual(clipboardHash, dataHashSha256))
               {
                    return;
               }

               Clear();
          }

          public static byte[] ComputeHash()
          {
               try
               {
                    return HashSha256String(Clipboard.GetText());
               }
               catch (System.Exception)
               {
                    System.Diagnostics.Debug.Assert(false);
               }

               return null;
          }

          private static bool ArraysEqual(byte[] x, byte[] y)
          {
               if (x == null && y == null)
               {
                    return true;
               }
               else if (x == null || y == null)
               {
                    return false;
               }
               else if (x.Length != y.Length)
               {
                    return false;
               }
               else
               {
                    for (int i = 0; i < x.Length; ++i)
                    {
                         if (x[i] != y[i]) return false;
                    }
               }

               return true;
          }

          private static byte[] HashSha256String(string sourceString)
          {
               if (string.IsNullOrEmpty(sourceString))
               {
                    return null;
               }

               try
               {
                    return EncryptorHelper.HashSha256(System.Text.Encoding.UTF8.GetBytes(sourceString));
               }
               catch (System.Exception)
               {
                    System.Diagnostics.Debug.Assert(false);
               }

               return null;
          }
     }
}
