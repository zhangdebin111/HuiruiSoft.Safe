
namespace HuiruiSoft.Utils
{
     public static class StringHelper
     {
          public static readonly System.StringComparison CaseIgnoreComparison = System.StringComparison.OrdinalIgnoreCase;

          public static System.StringComparer CaseIgnoreComparer
          {
               get
               {
                    return System.StringComparer.OrdinalIgnoreCase;
               }
          }

          public static int GetStringBytesCount(string text)
          {
               if(string.IsNullOrEmpty(text))
               {
                    return 0;
               }
               else
               {
                    return System.Text.Encoding.Default.GetByteCount(text);
               }
          }

          private static System.Text.UTF8Encoding utf8Encoding = null;
          public static System.Text.UTF8Encoding UTF8
          {
               get
               {
                    if(utf8Encoding == null)
                    {
                         utf8Encoding = new System.Text.UTF8Encoding(false, false);
                    }

                    return utf8Encoding;
               }
          }

          private const string RegexPhoneExpression = @"(\(\d{3}\)|\d{3}-)?\d{8}$";
          private const string RegexMobileExpression = @"^(13|14|15|16|18|19)\d{9}$";
          private const string RegexMailExpression  = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";

          public static bool CheckPhoneValidity(string phoneCode)
          {
               if(string.IsNullOrEmpty(phoneCode))
               {
                    return false;
               }
               else
               {
                    System.Text.RegularExpressions.RegexOptions tmpRegexOptions =
                         System.Text.RegularExpressions.RegexOptions.Multiline |
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase |
                         System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace;

                    return System.Text.RegularExpressions.Regex.IsMatch(phoneCode, RegexPhoneExpression, tmpRegexOptions);
               }
          }

          public static bool CheckMobileValidity(string mobile)
          {
               if(string.IsNullOrEmpty(mobile))
               {
                    return false;
               }
               else
               {
                    System.Text.RegularExpressions.RegexOptions tmpRegexOptions =
                         System.Text.RegularExpressions.RegexOptions.Multiline |
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase |
                         System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace;

                    return System.Text.RegularExpressions.Regex.IsMatch(mobile, RegexMobileExpression, tmpRegexOptions);
               }
          }

          public static bool CheckEmailValidity(string mail)
          {
               if(string.IsNullOrEmpty(mail))
               {
                    return false;
               }
               else
               {
                    System.Text.RegularExpressions.RegexOptions tmpRegexOptions =
                         System.Text.RegularExpressions.RegexOptions.Multiline |
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase |
                         System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace;

                    return System.Text.RegularExpressions.Regex.IsMatch(mail, RegexMailExpression, tmpRegexOptions);
               }
          }
     }
}