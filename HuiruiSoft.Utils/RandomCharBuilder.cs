
namespace HuiruiSoft.Utils
{
     public class RandomCharBuilder
     {
          private static char[ ] numberChars;
          private static char[ ] lowerCaseChars;
          private static char[ ] upperCaseChars;
          private static char[ ] specialChars = { '!', '@', '#', '$', '%', '&', '_', '+', '=', ';', '~', '^', '*', '?', ':', '.', ',', '|', '<', '>', '(', ')', '[', ']', '/', '\'', };
          
          private RandomCharBuilder( )
          {
               //
          }

          public static string CreateSimpleDigits(int length)
          {
               var tmpStringBuilder = new System.Text.StringBuilder( );
               var tmpRandomBuilder = new System.Random(System.Guid.NewGuid( ).GetHashCode( ));

               int count = 0;
               while(count < length)
               {
                    tmpStringBuilder.Append(numberChars[tmpRandomBuilder.Next(numberChars.Length)]);
                    count++;
               }

               return tmpStringBuilder.ToString( );
          }

          public static string CreateSimpleLowerCases(int length)
          {
               var tmpStringBuilder = new System.Text.StringBuilder( );
               var tmpRandomBuilder = new System.Random(System.Guid.NewGuid( ).GetHashCode( ));

               int count = 0;
               while(count < length)
               {
                    tmpStringBuilder.Append(lowerCaseChars[tmpRandomBuilder.Next(lowerCaseChars.Length)]);
                    count++;
               }

               return tmpStringBuilder.ToString( );
          }

          public static string CreateSimpleUpperCases(int length)
          {
               var tmpStringBuilder = new System.Text.StringBuilder( );
               var tmpRandomBuilder = new System.Random(System.Guid.NewGuid( ).GetHashCode( ));

               int count = 0;
               while(count < length)
               {
                    tmpStringBuilder.Append(upperCaseChars[tmpRandomBuilder.Next(upperCaseChars.Length)]);
                    count++;
               }

               return tmpStringBuilder.ToString( );
          }

          public static string CreateMixedCharacters(bool startWithChar, int length)
          {
               var tmpStringBuilder = new System.Text.StringBuilder( );
               var tmpRandomBuilder = new System.Random(System.Guid.NewGuid( ).GetHashCode( ));

               int count = 0;
               if(startWithChar)
               {
                    switch(tmpRandomBuilder.Next(2))
                    {
                         case 0:
                              tmpStringBuilder.Append(lowerCaseChars[tmpRandomBuilder.Next(lowerCaseChars.Length)]);
                              break;

                         case 1:
                              tmpStringBuilder.Append(upperCaseChars[tmpRandomBuilder.Next(upperCaseChars.Length)]);
                              break;
                    }

                    count++;
               }

               while(count < length)
               {
                    switch(tmpRandomBuilder.Next(4))
                    {
                         case 0:
                              tmpStringBuilder.Append(numberChars[tmpRandomBuilder.Next(numberChars.Length)]);
                              break;

                         case 1:
                              tmpStringBuilder.Append(lowerCaseChars[tmpRandomBuilder.Next(lowerCaseChars.Length)]);
                              break;

                         case 2:
                              tmpStringBuilder.Append(upperCaseChars[tmpRandomBuilder.Next(upperCaseChars.Length)]);
                              break;

                         case 3:
                              tmpStringBuilder.Append(specialChars[tmpRandomBuilder.Next(specialChars.Length)]);
                              break;
                    }
                    count++;
               }

               return tmpStringBuilder.ToString( );
          }
     }
}