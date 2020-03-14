using System.Xml.Serialization;

namespace HuiruiSoft.Safe.Localization
{
     public sealed class LocalizedStringItem
     {
          [XmlAttribute("key")]
          public string Name { get; set; } = string.Empty;

          [XmlText()]
          public string Value { get; set; } = string.Empty;
     }
}