
using System.Xml;

namespace HuiruiSoft.Utils
{
     public static class XmlDocumentHelper
     {
          public static XmlDocument CreateXmlDocument()
          {
               var tmpXmlDocument = new XmlDocument();
               tmpXmlDocument.XmlResolver = null;
               return tmpXmlDocument;
          }

          public static XmlReaderSettings CreateXmlReaderSettings()
          {
               var tmpReaderSettings = new XmlReaderSettings();

               tmpReaderSettings.CloseInput = false;
               tmpReaderSettings.ProhibitDtd = true;
               tmpReaderSettings.IgnoreComments = true;
               tmpReaderSettings.IgnoreWhitespace = true;
               tmpReaderSettings.XmlResolver = null;
               tmpReaderSettings.IgnoreProcessingInstructions = true;
               tmpReaderSettings.ValidationType = ValidationType.None;

               return tmpReaderSettings;
          }

          public static XmlReader CreateXmlReader(System.IO.Stream stream)
          {
               if (stream == null)
               {
                    System.Diagnostics.Debug.Assert(false);
                    throw new System.ArgumentNullException("stream");
               }

               return XmlReader.Create(stream, CreateXmlReaderSettings());
          }

          public static XmlWriterSettings CreateXmlWriterSettings()
          {
               var tmpWriterSettings = new XmlWriterSettings();

               tmpWriterSettings.CloseOutput = false;
               tmpWriterSettings.Encoding = HuiruiSoft.Utils.StringHelper.UTF8;
               tmpWriterSettings.Indent = true;
               tmpWriterSettings.IndentChars = "\t";
               tmpWriterSettings.NewLineOnAttributes = false;
               tmpWriterSettings.NewLineChars = System.Environment.NewLine;
               tmpWriterSettings.NewLineHandling = NewLineHandling.Entitize;

               return tmpWriterSettings;
          }

          public static XmlWriter CreateXmlWriter(System.IO.Stream stream)
          {
               if (stream == null)
               {
                    System.Diagnostics.Debug.Assert(false);
                    throw new System.ArgumentNullException("stream");
               }

               return XmlWriter.Create(stream, CreateXmlWriterSettings());
          }

          public static void Serialize<T>(System.IO.Stream stream, T t)
          {
               if (stream == null)
               {
                    System.Diagnostics.Debug.Assert(false);
                    throw new System.ArgumentNullException("stream");
               }

               var tmpXmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
               using (var tmpXmlWriter = CreateXmlWriter(stream))
               {
                    tmpXmlSerializer.Serialize(tmpXmlWriter, t);
               }
          }

          public static T Deserialize<T>(System.IO.Stream stream)
          {
               if (stream == null)
               {
                    System.Diagnostics.Debug.Assert(false);
                    throw new System.ArgumentNullException("stream");
               }

               var tmpXmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

               T tmpResult = default(T);
               using (var tmpXmlReader = CreateXmlReader(stream))
               {
                    tmpResult = (T)tmpXmlSerializer.Deserialize(tmpXmlReader);
               }

               return tmpResult;
          }

          public static bool GetAttributeValue(XmlElement element, string attributeName, bool defaultValue)
          {
               try
               {
                    defaultValue = System.Convert.ToBoolean(GetAttributeString(element, attributeName, defaultValue.ToString()));
               }
               catch (System.Exception)
               {
                    //
               }

               return defaultValue;
          }

          public static T GetAttributeValue<T>(XmlElement element, string attributeName, T defaultValue) where T : System.Enum
          {
               try
               {
                    defaultValue = (T)System.Enum.Parse(typeof(T), GetAttributeString(element, attributeName));
               }
               catch (System.Exception exception)
               {
                    System.Diagnostics.Debug.WriteLine(exception.StackTrace);
               }

               return defaultValue;
          }

          public static int GetAttributeValue(XmlElement element, string attributeName, int defaultValue)
          {
               try
               {
                    defaultValue = System.Convert.ToInt32(GetAttributeString(element, attributeName, defaultValue.ToString()));
               }
               catch (System.Exception)
               {
                    //
               }

               return defaultValue;
          }

          public static System.DateTime GetAttributeValue(XmlElement element, string attributeName)
          {
               return GetAttributeValue(element, attributeName, System.DateTime.Now);
          }

          public static System.DateTime GetAttributeValue(XmlElement element, string attributeName, System.DateTime defaultValue)
          {
               try
               {
                    string tmpStringValue = GetAttributeString(element, attributeName);
                    if (!string.IsNullOrEmpty(tmpStringValue))
                    {
                         defaultValue = System.Convert.ToDateTime(tmpStringValue);
                    }
               }
               catch (System.Exception)
               {
                    //
               }

               return defaultValue;
          }

          public static System.Drawing.Color GetAttributeValue(XmlElement element, string attributeName, System.Drawing.Color defaultColor)
          {
               try
               {
                    defaultColor = System.Drawing.ColorTranslator.FromHtml(GetAttributeString(element, attributeName, System.Drawing.ColorTranslator.ToHtml(defaultColor)));
               }
               catch (System.Exception)
               {
                    //
               }

               return (defaultColor);
          }


          public static string GetAttributeString(XmlElement element, string attributeName)
          {
               return GetAttributeString(element, attributeName, string.Empty);
          }

          public static string GetAttributeString(XmlElement element, string attributeName, string defaultValue)
          {
               if (element != null && element.HasAttribute(attributeName))
               {
                    defaultValue = element.GetAttribute(attributeName);
               }

               return defaultValue;
          }

          public static bool GetNodeInnerValue(XmlNode node, string childNodeName, bool defaultValue)
          {
               try
               {
                    defaultValue = System.Convert.ToBoolean(GetNodeInnerString(node, childNodeName, defaultValue.ToString()));
               }
               catch (System.Exception)
               {
                    //
               }

               return defaultValue;
          }

          public static int GetNodeInnerValue(XmlNode node, string childNodeName, int defaultValue)
          {
               try
               {
                    defaultValue = System.Convert.ToInt32(GetNodeInnerString(node, childNodeName, defaultValue.ToString()));
               }
               catch (System.Exception)
               {
                    //
               }

               return defaultValue;
          }

          public static System.DateTime GetNodeInnerValue(XmlNode node, string childNodeName)
          {
               return GetNodeInnerValue(node, childNodeName, System.DateTime.Now);
          }

          public static System.DateTime GetNodeInnerValue(XmlNode node, string childNodeName, System.DateTime defaultValue)
          {
               try
               {
                    string tmpStringValue = GetNodeInnerString(node, childNodeName);
                    if (!string.IsNullOrEmpty(tmpStringValue))
                    {
                         defaultValue = System.Convert.ToDateTime(tmpStringValue);
                    }
               }
               catch (System.Exception)
               {
                    //
               }

               return defaultValue;
          }

          public static System.Drawing.Color GetNodeInnerValue(XmlNode node, string childNodeName, System.Drawing.Color defaultColor)
          {
               try
               {
                    defaultColor = System.Drawing.ColorTranslator.FromHtml(GetNodeInnerString(node, childNodeName, System.Drawing.ColorTranslator.ToHtml(defaultColor)));
               }
               catch (System.Exception)
               {
                    //
               }

               return defaultColor;
          }

          public static string GetNodeInnerString(XmlNode node, string childNodeName)
          {
               return GetNodeInnerString(node, childNodeName, string.Empty);
          }

          public static string GetNodeInnerString(XmlNode node, string childNodeName, string defaultValue)
          {
               string tmpInnerString = defaultValue;
               if (node != null)
               {
                    for (int index = 0; index < node.ChildNodes.Count; index++)
                    {
                         XmlNode tmpChildNode = node.ChildNodes[index];
                         if (string.Compare(tmpChildNode.Name, childNodeName, true) == 0)
                         {
                              tmpInnerString = tmpChildNode.InnerText;
                              break;
                         }
                    }
               }

               return tmpInnerString;
          }
     }
}