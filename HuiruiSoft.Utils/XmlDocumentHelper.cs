
namespace HuiruiSoft.Utils
{
     public static class XmlDocumentHelper
     {
          public static System.Xml.XmlDocument CreateXmlDocument()
          {
               var tmpXmlDocument = new System.Xml.XmlDocument();
               tmpXmlDocument.XmlResolver = null;
               return tmpXmlDocument;
          }

          public static System.Xml.XmlReaderSettings CreateXmlReaderSettings()
          {
               var tmpReaderSettings = new System.Xml.XmlReaderSettings();

               tmpReaderSettings.CloseInput = false;
               tmpReaderSettings.ProhibitDtd = true;
               tmpReaderSettings.IgnoreComments = true;
               tmpReaderSettings.IgnoreWhitespace = true;
               tmpReaderSettings.XmlResolver = null;
               tmpReaderSettings.IgnoreProcessingInstructions = true;
               tmpReaderSettings.ValidationType = System.Xml.ValidationType.None;

               return tmpReaderSettings;
          }

          public static System.Xml.XmlReader CreateXmlReader(System.IO.Stream stream)
          {
               if (stream == null)
               {
                    System.Diagnostics.Debug.Assert(false);
                    throw new System.ArgumentNullException("stream");
               }

               return System.Xml.XmlReader.Create(stream, CreateXmlReaderSettings());
          }

          public static System.Xml.XmlWriterSettings CreateXmlWriterSettings()
          {
               var tmpWriterSettings = new System.Xml.XmlWriterSettings();

               tmpWriterSettings.CloseOutput = false;
               tmpWriterSettings.Encoding = HuiruiSoft.Utils.StringHelper.UTF8;
               tmpWriterSettings.Indent = true;
               tmpWriterSettings.IndentChars = "\t";
               tmpWriterSettings.NewLineOnAttributes = false;
               tmpWriterSettings.NewLineChars = System.Environment.NewLine;
               tmpWriterSettings.NewLineHandling = System.Xml.NewLineHandling.Entitize;

               return tmpWriterSettings;
          }

          public static System.Xml.XmlWriter CreateXmlWriter(System.IO.Stream stream)
          {
               if (stream == null)
               {
                    System.Diagnostics.Debug.Assert(false);
                    throw new System.ArgumentNullException("stream");
               }

               return System.Xml.XmlWriter.Create(stream, CreateXmlWriterSettings());
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
     }
}