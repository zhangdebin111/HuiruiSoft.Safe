using HuiruiSoft.Safe.Configuration;

namespace HuiruiSoft.Utils.XmlSerialization
{
     public interface IXmlSerializer
     {
          object Deserialize(System.IO.Stream stream);

          void Serialize(System.Xml.XmlWriter xmlWriter, object @object);
     }


     public sealed partial class XmlSerializerExtend : IXmlSerializer
     {
          private readonly System.Type objectType;

          public XmlSerializerExtend(System.Type type)
          {
               this.objectType = type;
          }

          public void Serialize(System.Xml.XmlWriter xmlWriter, object @object)
          {
               //var tmpSerializer = new System.Xml.Serialization.XmlSerializer(this.objectType); // TODO  未能加载文件或程序集 FileNotFoundException
               var tmpSerializer = System.Xml.Serialization.XmlSerializer.FromTypes(new[] { this.objectType })[0];
               tmpSerializer.Serialize(xmlWriter, @object);
          }

          public object Deserialize(System.IO.Stream stream)
          {
               object deserializeResult = null;
               using(var tmpXmlReader = XmlDocumentHelper.CreateXmlReader(stream))
               {
                    if(this.objectType == typeof(SafePassConfiguration))
                    {
                         var tmpRootName = GetXmlName(this.objectType);
                         var tmpRootFound = SkipToRoot(tmpXmlReader, tmpRootName);
                         if(tmpRootFound)
                         {
                              deserializeResult = ReadSafePassConfiguration(tmpXmlReader);
                         }
                         else
                         {
                              System.Diagnostics.Debug.Assert(false);
                         }
                    }
                    else
                    {
                         //var tmpSerializer = new System.Xml.Serialization.XmlSerializer(this.objectType); // TODO  未能加载文件或程序集 FileNotFoundException
                         var tmpSerializer = System.Xml.Serialization.XmlSerializer.FromTypes(new[] { this.objectType })[0];
                         deserializeResult = tmpSerializer.Deserialize(tmpXmlReader);
                    }
               }

               return deserializeResult;
          }

          private static bool SkipEmptyElement(System.Xml.XmlReader xmlReader)
          {
               xmlReader.MoveToElement( );

               if(xmlReader.IsEmptyElement)
               {
                    xmlReader.Skip( );
                    return true;
               }
               else
               {
                    return false;
               }
          }

          private static bool SkipToRoot(System.Xml.XmlReader xmlReader, string strRootName)
          {
               xmlReader.Read( ); // Initialize reader

               bool tmpRootFound = false;
               while(true)
               {
                    if(xmlReader.NodeType == System.Xml.XmlNodeType.Document ||
                         xmlReader.NodeType == System.Xml.XmlNodeType.Element ||
                         xmlReader.NodeType == System.Xml.XmlNodeType.DocumentFragment)
                    {
                         if(xmlReader.Name == strRootName)
                         {
                              tmpRootFound = true; break;
                         }

                         xmlReader.Skip( );
                    }
                    else if(!xmlReader.Read( ))
                    {
                         System.Diagnostics.Debug.Assert(false); break;
                    }
               }

               return tmpRootFound;
          }

          internal static T GetAttribute<T>(object[ ] attributes) where T : System.Attribute
          {
               if(attributes != null)
               {
                    foreach(object o in attributes)
                    {
                         if(o != null && o.GetType( ) == typeof(T))
                         {
                              return (o as T);
                         }
                    }
               }

               return null;
          }

          internal static string GetXmlName(System.Reflection.MemberInfo memberInfo)
          {
               var tmpXmlName = memberInfo.Name;
               var tmpAttributes = memberInfo.GetCustomAttributes(true);

               var tmpXmlType = GetAttribute<System.Xml.Serialization.XmlTypeAttribute>(tmpAttributes);
               if(tmpXmlType != null)
               {
                    tmpXmlName = tmpXmlType.TypeName;
               }

               var tmpXmlRoot = GetAttribute<System.Xml.Serialization.XmlRootAttribute>(tmpAttributes);
               if(tmpXmlRoot != null)
               {
                    tmpXmlName = tmpXmlRoot.ElementName;
               }

               var tmpXmlArray = GetAttribute<System.Xml.Serialization.XmlArrayAttribute>(tmpAttributes);
               if(tmpXmlArray != null)
               {
                    tmpXmlName = tmpXmlArray.ElementName;
               }

               var tmpXmlElement = GetAttribute<System.Xml.Serialization.XmlElementAttribute>(tmpAttributes);
               if(tmpXmlElement != null)
               {
                    tmpXmlName = tmpXmlElement.ElementName;
               }

               return tmpXmlName;
          }

          private sealed class XmlsTypeInfo
          {
               public System.Type Type
               {
                    get;
               }

               public string ReadCode
               {
                    get;
               }

               public bool HasInfo
               {
                    get
                    {
                         return this.ReadCode.Length > 0;
                    }
               }

               public XmlsTypeInfo(System.Type type)
               {
                    this.Type = type;
                    this.ReadCode = string.Empty;
               }

               public XmlsTypeInfo(System.Type type, string readCode, string writeCode)
               {
                    this.Type = type;
                    this.ReadCode = (readCode ?? string.Empty);
               }
          }
     }
}
