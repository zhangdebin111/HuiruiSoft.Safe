using System.Text;
using System.Collections.Generic;

namespace HuiruiSoft.Security.Cryptography
{
     public sealed class PasswordGenerator
     {
          public uint Length
          {
               get;
               set;
          }

          public bool ExcludeLookAlike
          {
               get;
               set;
          }

          public bool NoRepeatingChars
          {
               get;
               set;
          }

          public string ExcludeCharacters
          {
               get;
               set;
          }

          private PasswordCharSet passwordCharSet = new PasswordCharSet(PasswordCharSet.UpperChars + PasswordCharSet.LowerChars + PasswordCharSet.DigitChars);

          public PasswordCharSet CharSet
          {
               get { return this.passwordCharSet; }

               set
               {
                    if (value == null)
                    {
                         throw new System.ArgumentNullException("value");
                    }

                    this.passwordCharSet = value;
               }
          }

          public string GeneratePassword( )
          {
               if (this.passwordCharSet == null)
               {
                    throw new System.ArgumentNullException("charSet");
               }

               if (this.ExcludeLookAlike)
               {
                    passwordCharSet.Remove(PasswordCharSet.LookAlikes);
               }

               if (!string.IsNullOrEmpty(this.ExcludeCharacters))
               {
                    passwordCharSet.Remove(this.ExcludeCharacters);
               }

               var tmpCharSet = this.passwordCharSet.CharSet;
               if (this.NoRepeatingChars)
               {
                    if (tmpCharSet.Count < this.Length)
                    {
                         throw new TooFewCharacterException("There are too few characters in the character set.");
                    }
               }

               if (tmpCharSet.Count < 1)
               {
                    throw new TooFewCharacterException("There are too few characters in the character set.");
               }

               var tmpPasswordBuffer = new char[this.Length];
               var tmpRandomBuilder = new System.Random(System.Guid.NewGuid().GetHashCode());

               int count = 0;
               while (count < this.Length)
               {
                    var tmpExisting = false;
                    var tmpCharacter = tmpCharSet[tmpRandomBuilder.Next(tmpCharSet.Count)];
                    if (this.NoRepeatingChars)
                    {
                         for (int index = 0; index < count; index++)
                         {
                              if (tmpPasswordBuffer[index] == tmpCharacter)
                              {
                                   tmpExisting = true; break;
                              }
                         }
                    }

                    if (!tmpExisting)
                    {
                         tmpPasswordBuffer[count] = tmpCharacter;
                         count++;
                    }
               }

               return new string(tmpPasswordBuffer);
          }
     }

     public sealed class TooFewCharacterException : System.Exception
     {
          public TooFewCharacterException() : base()
          {
               // 
          }

          public TooFewCharacterException(string message) : base(message)
          {
               // 
          }

          public TooFewCharacterException(string message, System.Exception innerException) : base(message, innerException)
          {
               // 
          }
     }

     public sealed class PasswordCharSet
     {
          public static readonly string LookAlikes = @"O0l1I|";
          public static readonly string DigitChars = "0123456789";
          public static readonly string UpperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
          public static readonly string LowerChars = "abcdefghijklmnopqrstuvwxyz";
          public static readonly string BracketChars = @"[]{}()<>";
          public static readonly string SpecialChars = "!\"#$%&'*+,./:;=?@\\^`|~";

          public List<char> CharSet { get; private set; } = new List<char>();

          public PasswordCharSet( )
          {
               //
          }

          public PasswordCharSet(string charSet)
          {
               this.Add(charSet);
          }

          public void Add(char character)
          {
               if (character == char.MinValue)
               {
                    System.Diagnostics.Debug.Assert(false); return;
               }

               if (!this.Contains(character))
               {
                    if (!(character == char.MinValue || character == '\t' || character == '\r' || character == '\n' || char.IsSurrogate(character)))
                    {
                         this.CharSet.Add(character);
                    }
               }
          }

          public void Add(string charSet)
          {
               System.Diagnostics.Debug.Assert(charSet != null);
               if (charSet == null)
               {
                    throw new System.ArgumentNullException("charSet");
               }

               foreach (char character in charSet)
               {
                    this.Add(character);
               }
          }

          public bool Remove(char character)
          {
               return this.CharSet.Remove(character);
          }

          public bool Remove(string characters)
          {
               System.Diagnostics.Debug.Assert(characters != null);
               if (characters == null)
               {
                    throw new System.ArgumentNullException("characters");
               }

               bool tmpRemoveResult = true;
               foreach (char character in characters)
               {
                    if (!this.Remove(character))
                    {
                         tmpRemoveResult = false;
                    }
               }

               return tmpRemoveResult;
          }

          public void Clear()
          {
               this.CharSet.Clear();
          }

          public bool Contains(char character)
          {
               return this.CharSet.Contains(character);
          }

          public bool Contains(string characters)
          {
               System.Diagnostics.Debug.Assert(characters != null);
               if (characters == null)
               {
                    throw new System.ArgumentNullException("characters");
               }

               foreach (char character in characters)
               {
                    if (!this.Contains(character))
                    {
                         return false;
                    }
               }

               return true;
          }
     }
}
