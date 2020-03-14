
namespace HuiruiSoft.Utils
{
     using System.Text.RegularExpressions;

     public static class CryptoObfuscateHelper
     {
          private const int Minimum_Placeholder_Count = 1;
          private const int Maximum_Placeholder_Count = 10;

          public static string ObfuscateUserName(string userName, int placeholderCount = 3)
          {
               string tmpObfuscatedText = userName;
               if(!string.IsNullOrEmpty(userName))
               {
                    if(isValidMobileNumber(userName))
                    {
                         tmpObfuscatedText = ObfuscateMobile(userName, placeholderCount);
                    }
                    else if(isValidEmailAddress(userName))
                    {
                         tmpObfuscatedText = ObfuscateMail(userName, placeholderCount);
                    }
                    else
                    {
                         tmpObfuscatedText = ObfuscateRealName(userName, placeholderCount);
                    }
               }

               return tmpObfuscatedText;
          }

          public static string ObfuscateMobile(string mobile, int placeholderCount = 3)
          {
               string tmpObfuscatedText = mobile;
               if(!string.IsNullOrEmpty(mobile))
               {
                    int tmpPlaceholderCount = GetValidPlaceholderCount(placeholderCount);
                    tmpObfuscatedText = Regex.Replace(mobile, "(\\d{3})(\\d{3,8})(\\d{3})", string.Format("$1{0}$3", new string('*', tmpPlaceholderCount)));
               }

               return tmpObfuscatedText;
          }

          public static bool isValidMobileNumber(string mobile)
          {
               if(string.IsNullOrEmpty(mobile))
               {
                    return false;
               }
               else
               {
                    return System.Text.RegularExpressions.Regex.IsMatch(mobile, "^[1]([3,4,5,7,8][0-9]{1})[0-9]{8}$");
               }
          }

          public static bool isValidEmailAddress(string mail)
          {
               if(string.IsNullOrEmpty(mail))
               {
                    return false;
               }
               else
               {
                    return System.Text.RegularExpressions.Regex.IsMatch(mail, "^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$");
               }
          }
          
          public static string ObfuscateBankCard(string bankAccount, int placeholderCount = 3)
          {
               string tmpObfuscatedText = bankAccount;
               if(!string.IsNullOrEmpty(bankAccount))
               {
                    int tmpPlaceholderCount = GetValidPlaceholderCount(placeholderCount);
                    tmpObfuscatedText = Regex.Replace(bankAccount, "(\\d{4})(\\d{4,14})(\\d{2})", string.Format("$1{0}$3", new string('*', tmpPlaceholderCount)));
               }

               return tmpObfuscatedText;
          }

          public static string ObfuscateIdCardNumber(string idCardNumber, int placeholderCount = 3)
          {
               string tmpObfuscatedText = idCardNumber;
               if(!string.IsNullOrEmpty(idCardNumber))
               {
                    int tmpPlaceholderCount = GetValidPlaceholderCount(placeholderCount);

                    if(idCardNumber.Length == 15)
                    {
                         tmpObfuscatedText = Regex.Replace(idCardNumber, "(\\d{4})(\\d{6,9})(\\d{3})", string.Format("$1{0}$3", new string('*', tmpPlaceholderCount)));
                    }
                    else if(idCardNumber.Length == 18)
                    {
                         tmpObfuscatedText = Regex.Replace(idCardNumber, "(\\d{4})(\\d{9,12})(\\d{3})", string.Format("$1{0}$3", new string('*', tmpPlaceholderCount)));
                    }
               }

               return tmpObfuscatedText;
          }

          public static string ObfuscateMail(string mail, int placeholderCount = 3)
          {
               string tmpObfuscatedText = mail;

               if(!string.IsNullOrEmpty(mail))
               {
                    int tmpIndexOf = mail.IndexOf('@');
                    if(tmpIndexOf > 0)
                    {
                         int tmpPlaceholderCount = GetValidPlaceholderCount(placeholderCount);

                         string tmpMailDomain = mail.Substring(tmpIndexOf);
                         string tmpMailAccount = mail.Substring(0, tmpIndexOf);

                         int tmpCharCount = tmpMailAccount.Length;

                         var tmpAccountBuffer = new System.Text.StringBuilder( );
                         tmpAccountBuffer.Append(tmpMailAccount[0]);
                         for(int index = 1; index < 3 && index < tmpCharCount; index++)
                         {
                              tmpAccountBuffer.Append(tmpMailAccount[index]);
                         }
                         tmpAccountBuffer.Append(new string('*', tmpPlaceholderCount));
                         tmpAccountBuffer.Append(tmpMailDomain);

                         tmpObfuscatedText = tmpAccountBuffer.ToString( );
                    }
               }

               return tmpObfuscatedText;
          }

          public static string ObfuscateRealName(string realName, int placeholderCount = 3)
          {
               string tmpObfuscatedText = realName;

               if(!string.IsNullOrEmpty(realName))
               {
                    int tmpPlaceholderCount = GetValidPlaceholderCount(placeholderCount);

                    int tmpCharCount = realName.Length;
                    if(tmpCharCount == 2)
                    {
                         tmpObfuscatedText = realName.Substring(0, 1) + "*";
                    }
                    else if(tmpCharCount >= 8)
                    {
                         tmpObfuscatedText = string.Format("{0}{2}{1}", realName.Substring(0, 3), realName.Substring(realName.Length - 3), new string('*', tmpPlaceholderCount));
                    }
                    else
                    {
                         var tmpRealNameBuffer = new System.Text.StringBuilder( );

                         tmpRealNameBuffer.Append(realName.Substring(0, 1));
                         for(int index = 0; index < tmpPlaceholderCount && index < tmpCharCount - 2; index++)
                         {
                              tmpRealNameBuffer.Append("*");
                         }
                         tmpRealNameBuffer.Append(realName.Substring(tmpCharCount - 1));

                         tmpObfuscatedText = tmpRealNameBuffer.ToString( );
                    }
               }

               return tmpObfuscatedText;
          }

          private static int GetValidPlaceholderCount(int placeholderCount)
          {
               int tmpPlaceholderCount = placeholderCount;

               if(placeholderCount < Minimum_Placeholder_Count)
               {
                    tmpPlaceholderCount = Minimum_Placeholder_Count;
               }
               else if(placeholderCount > Maximum_Placeholder_Count)
               {
                    tmpPlaceholderCount = Maximum_Placeholder_Count;
               }

               return tmpPlaceholderCount;
          }
     }
}