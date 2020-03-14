using System.Xml.Serialization;

namespace HuiruiSoft.Safe.Configuration
{
     [XmlType(TypeName = "Configuration")]
     public sealed class SafePassConfiguration
     {
          public SafePassConfiguration()
          {
               //
          }

          private ApplicationConfig applicationConfig = null;
          private WindowSettings mainWindowConfig = null;

          [XmlIgnore]
          public string WorkingDirectory
          {
               set;
               get;
          }

          [XmlElement("MainWindow")]
          public WindowSettings MainWindow
          {
               set
               {
                    this.mainWindowConfig = value ?? throw new System.ArgumentNullException("value");
               }

               get
               {
                    if (this.mainWindowConfig == null)
                    {
                         this.mainWindowConfig = new WindowSettings();
                    }

                    return this.mainWindowConfig;
               }
          }

          [XmlElement("Application")]
          public ApplicationConfig Application
          {
               set
               {
                    this.applicationConfig = value ?? throw new System.ArgumentNullException("value");
               }

               get
               {
                    if (this.applicationConfig == null)
                    {
                         this.applicationConfig = new ApplicationConfig();
                    }

                    return this.applicationConfig;
               }
          }
     }
}