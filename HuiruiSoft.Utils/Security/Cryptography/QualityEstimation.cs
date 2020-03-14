
namespace HuiruiSoft.Security.Cryptography
{
     public static class QualityEstimation
     {
          public static readonly string SpecialChars = "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";

          public static uint EstimatePasswordQuality(string password)
          {
               if (password == null || password.Length == 0)
               {
                    return 0;
               }

               return EstimatePasswordQuality(password.ToCharArray());
          }

          public static uint EstimatePasswordQuality(byte[] unprotectedUtf8)
          {
               if (unprotectedUtf8 == null)
               {
                    System.Diagnostics.Debug.Assert(false);
                    return 0;
               }

               uint passwordQuality;
               char[] chars = HuiruiSoft.Utils.StringHelper.UTF8.GetChars(unprotectedUtf8);
               try
               {
                    passwordQuality = EstimatePasswordQuality(chars);
               }
               finally
               {
                    System.Array.Clear(chars, 0, chars.Length);
               }

               return passwordQuality;
          }

          public static uint EstimatePasswordQuality(char[] password)
          {
               if (password == null || password.Length == 0)
               {
                    return 0;
               }

               decimal passwordQuality = 0;
               if (password.Length <= 6)
               {
                    passwordQuality += System.Math.Max(1, password.Length * 5 / 6);
               }
               else if (password.Length <= 10)
               {
                    passwordQuality += System.Math.Max(6, password.Length * 10 / 10);
               }
               else
               {
                    passwordQuality += System.Math.Max(10, password.Length * 1.5m);
               }

               int digitAmount = 0, lowerAmount = 0, upperAmount = 0, specialAmount = 0;
               foreach (char @char in password)
               {
                    if (@char >= '0' && @char <= '9')
                    {
                         digitAmount++;
                    }
                    else if (@char >= 'a' && @char <= 'z')
                    {
                         lowerAmount++;
                    }
                    else if (@char >= 'A' && @char <= 'Z')
                    {
                         upperAmount++;
                    }
                    else if (SpecialChars.IndexOf(@char) >= 0)
                    {
                         specialAmount++;
                    }
               }

               if (lowerAmount == 0 && upperAmount == 0)
               {
                    passwordQuality += 0;
               }
               else if (lowerAmount == 0 || upperAmount == 0)
               {
                    passwordQuality += 10;
               }
               else
               {
                    passwordQuality += 25;
               }

               if (digitAmount == 0)
               {
                    passwordQuality += 0;
               }
               else if (digitAmount <= 2)
               {
                    passwordQuality += 10;
               }
               else if (digitAmount > 2)
               {
                    passwordQuality += 25;
               }

               if (specialAmount == 0)
               {
                    passwordQuality += 0;
               }
               else if (specialAmount == 1)
               {
                    passwordQuality += 10;
               }
               else if (digitAmount > 1)
               {
                    passwordQuality += 25;
               }

               if (digitAmount > 0 && lowerAmount > 0 && upperAmount > 0 && specialAmount > 0)
               {
                    passwordQuality += 8;
               }
               else if ((digitAmount > 0 || lowerAmount > 0) && upperAmount > 0 && specialAmount > 0)
               {
                    passwordQuality += 5;
               }
               else if ((digitAmount > 0 || lowerAmount > 0) && upperAmount > 0)
               {
                    passwordQuality += 3;
               }

               if (passwordQuality > 100)
               {
                    passwordQuality = 100;
               }

               return (uint)System.Math.Ceiling(passwordQuality);
          }
     }
}