namespace HuiruiSoft.Safe.Configuration
{
     using System.Xml.Serialization;

     public sealed class ApplicationConfig
     {
          private SecurityConfig securityConfig = null;

          [XmlElement]
          public string LanguageFile { get; set; } = null;

          [XmlElement]
          public SecurityConfig Security
          {
               set
               {
                    this.securityConfig = value ?? throw new System.ArgumentNullException("value");
               }

               get
               {
                    if (this.securityConfig == null)
                    {
                         this.securityConfig = new SecurityConfig();
                    }

                    return this.securityConfig;
               }
          }

          private PasswordGeneratorProfile generatorProfile = null;

          [XmlElement]
          public PasswordGeneratorProfile PasswordGenerator
          {
               set
               {
                    this.generatorProfile = value ?? throw new System.ArgumentNullException("value");
               }

               get
               {
                    if (this.generatorProfile == null)
                    {
                         this.generatorProfile = new PasswordGeneratorProfile();
                    }

                    return this.generatorProfile;
               }
          }
     }
}