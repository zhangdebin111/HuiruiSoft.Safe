using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace HuiruiSoft.Safe.Localization
{
     [XmlRoot("Localization")]
     public sealed class LocalizationResources
     {
          [XmlElement("Header")]
          public LanguageHeader Header
          {
               get; set;
          }

          [XmlElement("LocalizedStrings")]
          public LocalizedStringTable LocalizedStrings
          {
               get; set;
          }
     }

     public sealed class LocalizedStringTable
     {
          [XmlArrayItem("item")]
          [XmlArray("General")]
          public List<LocalizedStringItem> General
          {
               get; set;
          }

          [XmlArrayItem("item")]
          [XmlArray("MainMenu")]
          public List<LocalizedStringItem> MainMenu
          {
               get; set;
          }

          [XmlArrayItem("item")]
          [XmlArray("MainToolBar")]
          public List<LocalizedStringItem> MainToolbar
          {
               get; set;
          }

          [XmlArrayItem("item")]
          [XmlArray("Windows")]
          public List<LocalizedStringItem> Windows
          {
               get; set;
          }
     }
}