using System.Xml;
using HuiruiSoft.Safe.Configuration;

namespace HuiruiSoft.Utils.XmlSerialization
{
     public sealed partial class XmlSerializerExtend : IXmlSerializer
     {
          private static void WriteSafePassConfiguration(XmlWriter writer, SafePassConfiguration configuration)
          {
               writer.WriteStartDocument( );

               writer.WriteStartElement("Configuration");

               WriteWindowSettings(writer, configuration.MainWindow);
               WriteApplicationConfig(writer, configuration.Application);

               writer.WriteEndElement();
          }

          private static void WriteWindowSettings(XmlWriter writer, WindowSettings windowSettings)
          {
               writer.WriteStartElement("MainWindow");

               writer.WriteStartElement("X");
               WriteInt32(writer, windowSettings.X);
               writer.WriteEndElement();

               writer.WriteStartElement("Y");
               WriteInt32(writer, windowSettings.Y);
               writer.WriteEndElement();

               writer.WriteStartElement("Width");
               WriteInt32(writer, windowSettings.Width);
               writer.WriteEndElement();

               writer.WriteStartElement("Height");
               WriteInt32(writer, windowSettings.Height);
               writer.WriteEndElement();

               writer.WriteStartElement("SplitPosition");
               WriteDecimal(writer, windowSettings.SplitPosition);
               writer.WriteEndElement();

               writer.WriteStartElement("TopMost");
               WriteBoolean(writer, windowSettings.TopMost);
               writer.WriteEndElement();

               writer.WriteStartElement("Minimized");
               WriteBoolean(writer, windowSettings.Minimized);
               writer.WriteEndElement();

               writer.WriteStartElement("Maximized");
               WriteBoolean(writer, windowSettings.Maximized);
               writer.WriteEndElement();

               writer.WriteStartElement("ActionTraySingleClick");
               WriteBoolean(writer, windowSettings.ActionTraySingleClick);
               writer.WriteEndElement();

               writer.WriteStartElement("MinimizeWindowToTray");
               WriteBoolean(writer, windowSettings.MinimizeWindowToTray);
               writer.WriteEndElement();

               writer.WriteStartElement("MinimizeAtCloseButton");
               WriteBoolean(writer, windowSettings.MinimizeAtCloseButton);
               writer.WriteEndElement();

               writer.WriteEndElement();
          }

          private static void WriteApplicationConfig(XmlWriter writer, ApplicationConfig applicationConfig)
          {
               writer.WriteStartElement("Application");

               writer.WriteElementString("LanguageFile", applicationConfig.LanguageFile);
               WriteSecurityConfig(writer, applicationConfig.Security);
               WritePasswordProfile(writer, applicationConfig.PasswordGenerator);

               writer.WriteEndElement();
          }


          private static void WriteSecurityConfig(XmlWriter writer, SecurityConfig security)
          {
               writer.WriteStartElement("Security");

               WriteAccountConfig(writer, security.CurrentAccount);
               WriteLockWorkspaceConfig(writer, security.LockWorkspace);
               WriteMasterPasswordConfig(writer, security.MasterPassword);
               WriteClipboardSettings(writer, security.Clipboard);
               WriteSecretRankSettings(writer, security.SecretRank);

               writer.WriteEndElement();
          }

          private static void WriteAccountConfig(XmlWriter writer, HuiruiSoft.Safe.Account account)
          {
               writer.WriteStartElement("Account");
               writer.WriteElementString("UserName", account.UserName);
               writer.WriteElementString("Password", account.PasswordStored);
               writer.WriteEndElement();
          }

          private static void WriteLockWorkspaceConfig(XmlWriter writer, LockWorkspace lockWorkspace)
          {
               writer.WriteStartElement("LockWorkspace");

               writer.WriteStartElement("LockWindowAfterTime");
               WriteUInt32(writer, lockWorkspace.LockWindowAfterTime);
               writer.WriteEndElement();

               writer.WriteStartElement("LockScreenAfterTime");
               WriteUInt32(writer, lockWorkspace.LockScreenAfterTime);
               writer.WriteEndElement();

               writer.WriteStartElement("LockOnMinimizeTaskbar");
               WriteBoolean(writer, lockWorkspace.LockOnMinimizeTaskbar);
               writer.WriteEndElement();

               writer.WriteStartElement("LockOnMinimizeToTray");
               WriteBoolean(writer, lockWorkspace.LockOnMinimizeToTray);
               writer.WriteEndElement();

               writer.WriteStartElement("ExitInsteadOfLockAfterTime");
               WriteBoolean(writer, lockWorkspace.ExitInsteadOfLockAfterTime);
               writer.WriteEndElement();

               writer.WriteEndElement();
          }

          private static void WriteMasterPasswordConfig(XmlWriter writer, MasterPassword masterPassword)
          {
               writer.WriteStartElement("MasterPassword");

               writer.WriteStartElement("MinimumLength");
               WriteUInt32(writer, masterPassword.MinimumLength);
               writer.WriteEndElement();

               writer.WriteStartElement("MinimumQuality");
               WriteUInt32(writer, masterPassword.MinimumQuality);
               writer.WriteEndElement();

               writer.WriteEndElement();
          }

          private static void WriteClipboardSettings(XmlWriter writer, ClipboardSettings clipboardSettings)
          {
               writer.WriteStartElement("Clipboard");

               writer.WriteStartElement("ClipboardClearOnExit");
               WriteBoolean(writer, clipboardSettings.ClipboardClearOnExit);
               writer.WriteEndElement();

               writer.WriteStartElement("ClipboardClearAfterSeconds");
               WriteUInt32(writer, clipboardSettings.ClipboardClearAfterSeconds);
               writer.WriteEndElement();

               writer.WriteEndElement();
          }

          private static void WriteSecretRankSettings(XmlWriter writer, SecretRankSettings secretRankSettings)
          {
               writer.WriteStartElement("SecretRank");

               writer.WriteStartElement("SecretRank0Color");
               WriteColor(writer, secretRankSettings.Rank0BackColor);
               writer.WriteEndElement();

               writer.WriteStartElement("SecretRank1Color");
               WriteColor(writer, secretRankSettings.Rank1BackColor);
               writer.WriteEndElement();

               writer.WriteStartElement("SecretRank2Color");
               WriteColor(writer, secretRankSettings.Rank2BackColor);
               writer.WriteEndElement();

               writer.WriteStartElement("SecretRank3Color");
               WriteColor(writer, secretRankSettings.Rank3BackColor);
               writer.WriteEndElement();

               writer.WriteEndElement();
          }


          private static void WritePasswordProfile(XmlWriter writer, PasswordGeneratorProfile passwordProfile)
          {
               writer.WriteStartElement("PasswordGenerator");

               writer.WriteStartElement("UsingAllNumeric");
               WriteBoolean(writer, passwordProfile.UsingAllNumeric);
               writer.WriteEndElement();

               writer.WriteStartElement("Length");
               WriteUInt32(writer, passwordProfile.Length);
               writer.WriteEndElement();

               writer.WriteStartElement("UsingUpperCase");
               WriteBoolean(writer, passwordProfile.UsingUpperCase);
               writer.WriteEndElement();

               writer.WriteStartElement("UsingLowerCase");
               WriteBoolean(writer, passwordProfile.UsingLowerCase);
               writer.WriteEndElement();

               writer.WriteStartElement("UsingDigitChars");
               WriteBoolean(writer, passwordProfile.UsingDigitChars);
               writer.WriteEndElement();

               writer.WriteStartElement("UsingMinusChar");
               WriteBoolean(writer, passwordProfile.UsingMinusChar);
               writer.WriteEndElement();

               writer.WriteStartElement("UsingUnderline");
               WriteBoolean(writer, passwordProfile.UsingUnderline);
               writer.WriteEndElement();

               writer.WriteStartElement("UsingSpaceChar");
               WriteBoolean(writer, passwordProfile.UsingSpaceChar);
               writer.WriteEndElement();

               writer.WriteStartElement("UsingSpecialChars");
               WriteBoolean(writer, passwordProfile.UsingSpecialChars);
               writer.WriteEndElement();

               writer.WriteStartElement("UsingBracketChars");
               WriteBoolean(writer, passwordProfile.UsingBracketChars);
               writer.WriteEndElement();

               writer.WriteStartElement("ExcludeLookAlike");
               WriteBoolean(writer, passwordProfile.ExcludeLookAlike);
               writer.WriteEndElement();

               writer.WriteStartElement("NoRepeatingChars");
               WriteBoolean(writer, passwordProfile.NoRepeatingChars);
               writer.WriteEndElement();

               writer.WriteElementString("ExcludeCharacters", passwordProfile.ExcludeCharacters);

               writer.WriteEndElement();
          }


          private static void WriteString(XmlWriter writer, string text)
          {
               writer.WriteString(text);
          }

          private static void WriteElementString(XmlWriter writer, string name, string value)
          {
               writer.WriteElementString(name, value);
          }

          private static void WriteBoolean(XmlWriter writer, bool value)
          {
               writer.WriteValue(value);
          }

          private static void WriteInt32(XmlWriter writer, int value)
          {
               writer.WriteValue(value);
          }

          private static void WriteUInt32(XmlWriter writer, uint value)
          {
               writer.WriteValue(value);
          }

          private static void WriteInt64(XmlWriter writer, long value)
          {
               writer.WriteValue(value);
          }

          private static void WriteSingle(XmlWriter writer, float value)
          {
               writer.WriteValue(value);
          }

          private static void WriteDouble(XmlWriter writer, double value)
          {
               writer.WriteValue(value);
          }

          public static void WriteDecimal(XmlWriter writer, decimal value)
          {
               writer.WriteValue(value);
          }

          public static void WriteValue(XmlWriter writer, System.DateTime value)
          {
               writer.WriteValue(value);
          }

          private static void WriteColor(XmlWriter writer, System.Drawing.Color color)
          {
               writer.WriteValue(HuiruiSoft.Drawing.ColorTranslator.ToHtml(color));
          }
     }
}
