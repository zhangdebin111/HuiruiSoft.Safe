using System.Xml.Serialization;

namespace HuiruiSoft.Safe.Configuration
{
     public sealed class SecurityConfig
     {
          private LockWorkspace lockWorkspace = null;
          private MasterPassword masterPassword = null;
          private ClipboardSettings clipboardSettings = null;
          private SecretRankSettings secretRankSettings = null;

          [XmlElement("Account")]
          public Account CurrentAccount
          {
               set
               {
                    //
               }

               get
               {
                    return Account.CurrentAccount;
               }
          }

          public LockWorkspace LockWorkspace
          {
               set
               {
                    this.lockWorkspace = value ?? throw new System.ArgumentNullException("value");
               }

               get
               {
                    if(this.lockWorkspace == null)
                    {
                         this.lockWorkspace = new LockWorkspace( );
                    }

                    return this.lockWorkspace;
               }
          }

          public MasterPassword MasterPassword
          {
               set
               {
                    this.masterPassword = value ?? throw new System.ArgumentNullException("value");
               }

               get
               {
                    if(this.masterPassword == null)
                    {
                         this.masterPassword = new MasterPassword( );
                    }

                    return this.masterPassword;
               }
          }

          [XmlElement]
          public ClipboardSettings Clipboard
          {
               set
               {
                    this.clipboardSettings = value ?? throw new System.ArgumentNullException("value");
               }

               get
               {
                    if(this.clipboardSettings == null)
                    {
                         this.clipboardSettings = new ClipboardSettings( );
                    }

                    return this.clipboardSettings;
               }
          }

          [XmlElement]
          public SecretRankSettings SecretRank
          {
               set
               {
                    this.secretRankSettings = value ?? throw new System.ArgumentNullException("value");
               }

               get
               {
                    if(this.secretRankSettings == null)
                    {
                         this.secretRankSettings = new SecretRankSettings( );
                    }

                    return this.secretRankSettings;
               }
          }
     }

     public sealed class LockWorkspace
     {
          public uint LockAfterTime { get; set; } = 300;

          public uint LockGlobalTime { get; set; } = 600;
     }

     public sealed class SecretRankSettings
     {
          [XmlElement]
          public string SecretRank0Color
          {
               set
               {
                    //
               }

               get
               {
                    return System.Drawing.ColorTranslator.ToHtml(this.Rank0BackColor);
               }
          }

          [XmlElement]
          public string SecretRank1Color
          {
               set
               {
                    //
               }

               get
               {
                    return System.Drawing.ColorTranslator.ToHtml(this.Rank1BackColor);
               }
          }

          [XmlElement]
          public string SecretRank2Color
          {
               set
               {
                    //
               }

               get
               {
                    return System.Drawing.ColorTranslator.ToHtml(this.Rank2BackColor);
               }
          }

          [XmlElement]
          public string SecretRank3Color
          {
               set
               {
                    //
               }

               get
               {
                    return System.Drawing.ColorTranslator.ToHtml(this.Rank3BackColor);
               }
          }

          [XmlIgnore]
          public System.Drawing.Color Rank0BackColor { get; set; } = System.Drawing.ColorTranslator.FromHtml("#33AA33");

          [XmlIgnore]
          public System.Drawing.Color Rank1BackColor { get; set; } = System.Drawing.ColorTranslator.FromHtml("#F79F14");

          [XmlIgnore]
          public System.Drawing.Color Rank2BackColor { get; set; } = System.Drawing.Color.CadetBlue;

          [XmlIgnore]
          public System.Drawing.Color Rank3BackColor { get; set; } = System.Drawing.ColorTranslator.FromHtml("#0F5B8F");
     }

     public sealed class MasterPassword
     {
          public uint MinimumLength { get; set; } = 5;

          public uint MinimumQuality { get; set; } = 30;
     }

     public sealed class ClipboardSettings
     {
          [XmlElement]
          public bool ClipboardClearOnExit { get; set; } = true;

          [XmlElement]
          public int ClipboardClearAfterSeconds { get; set; } = 12;
     }

     public sealed class PasswordGeneratorProfile
     {
          public bool UsingAllNumeric { get; set; } = false;

          public uint Length { get; set; } = 16;

          public bool UsingUpperCase { get; set; } = true;

          public bool UsingLowerCase { get; set; } = true;

          public bool UsingDigitChars { get; set; } = true;

          public bool UsingMinusChar
          {
               get;
               set;
          }

          public bool UsingUnderline
          {
               get;
               set;
          }

          public bool UsingSpaceChar
          {
               get;
               set;
          }

          public bool UsingSpecialChars
          {
               get;
               set;
          }

          public bool UsingBracketChars
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
     }
}