using System.Xml;
using System.Diagnostics;
using HuiruiSoft.Safe.Configuration;

namespace HuiruiSoft.Utils.XmlSerialization
{
     public sealed partial class XmlSerializerExtend : IXmlSerializer
     {
          private static SafePassConfiguration ReadSafePassConfiguration(XmlReader reader)
          {
               var tmpApplicationConfig = new SafePassConfiguration();

               if (SkipEmptyElement(reader))
               {
                    return tmpApplicationConfig;
               }

               reader.ReadStartElement();
               reader.MoveToContent();

               while (true)
               {
                    var tmpNodeType = reader.NodeType;
                    if (tmpNodeType == XmlNodeType.None || tmpNodeType == XmlNodeType.EndElement)
                    {
                         break;
                    }

                    if (tmpNodeType == XmlNodeType.Element)
                    {
                         switch (reader.LocalName)
                         {
                              default:
                                   reader.Skip();
                                   break;

                              case "Application":
                                   tmpApplicationConfig.Application = ReadApplicationConfig(reader);
                                   break;

                              case "MainWindow":
                                   tmpApplicationConfig.MainWindow = ReadWindowSettings(reader);
                                   break;
                         }

                         reader.MoveToContent();
                    }
               }

               reader.ReadEndElement();

               return tmpApplicationConfig;
          }

          private static WindowSettings ReadWindowSettings(XmlReader reader)
          {
               var tmpWindowSettings = new WindowSettings();
               if (SkipEmptyElement(reader))
               {
                    return tmpWindowSettings;
               }

               Debug.Assert(reader.NodeType == XmlNodeType.Element);
               reader.ReadStartElement();
               reader.MoveToContent();

               while (true)
               {
                    var tmpNodeType = reader.NodeType;
                    if (tmpNodeType == XmlNodeType.None || tmpNodeType == XmlNodeType.EndElement)
                    {
                         break;
                    }

                    if (tmpNodeType == XmlNodeType.Element)
                    {
                         switch (reader.LocalName)
                         {
                              default:
                                   reader.Skip();
                                   break;

                              case "X":
                                   tmpWindowSettings.X = ReadInt32(reader);
                                   break;

                              case "Y":
                                   tmpWindowSettings.Y = ReadInt32(reader);
                                   break;

                              case "Width":
                                   tmpWindowSettings.Width = ReadInt32(reader);
                                   break;

                              case "Height":
                                   tmpWindowSettings.Height = ReadInt32(reader);
                                   break;

                              case "SplitPosition":
                                   tmpWindowSettings.SplitPosition = ReadInt32(reader);
                                   break;

                              case "TopMost":
                                   tmpWindowSettings.TopMost = ReadBoolean(reader);
                                   break;

                              case "Minimized":
                                   tmpWindowSettings.Minimized = ReadBoolean(reader);
                                   break;

                              case "Maximized":
                                   tmpWindowSettings.Maximized = ReadBoolean(reader);
                                   break;

                              case "ActionTraySingleClick":
                                   tmpWindowSettings.ActionTraySingleClick = ReadBoolean(reader);
                                   break;

                              case "MinimizeWindowToTray":
                                   tmpWindowSettings.MinimizeWindowToTray = ReadBoolean(reader);
                                   break;

                              case "MinimizeAtCloseButton":
                                   tmpWindowSettings.MinimizeAtCloseButton = ReadBoolean(reader);
                                   break;
                         }

                         reader.MoveToContent();
                    }
               }

               reader.ReadEndElement();

               return tmpWindowSettings;
          }

          private static ApplicationConfig ReadApplicationConfig(XmlReader reader)
          {
               var tmpApplicationConfig = new ApplicationConfig();
               if (SkipEmptyElement(reader))
               {
                    return tmpApplicationConfig;
               }

               Debug.Assert(reader.NodeType == XmlNodeType.Element);
               reader.ReadStartElement();
               reader.MoveToContent();

               while (true)
               {
                    var tmpNodeType = reader.NodeType;
                    if (tmpNodeType == XmlNodeType.None || tmpNodeType == XmlNodeType.EndElement)
                    {
                         break;
                    }

                    if (tmpNodeType == XmlNodeType.Element)
                    {
                         switch (reader.LocalName)
                         {
                              default:
                                   reader.Skip();
                                   break;

                              case "LanguageFile":
                                   tmpApplicationConfig.LanguageFile = ReadString(reader);
                                   break;

                              case "Security":
                                   tmpApplicationConfig.Security = ReadSecurityConfig(reader);
                                   break;

                              case "PasswordGenerator":
                                   tmpApplicationConfig.PasswordGenerator = ReadPasswordProfile(reader);
                                   break;
                         }

                         reader.MoveToContent();
                    }
               }

               reader.ReadEndElement();

               return tmpApplicationConfig;
          }

          private static SecurityConfig ReadSecurityConfig(XmlReader reader)
          {
               var tmpSecurityConfig = new SecurityConfig();
               if (SkipEmptyElement(reader))
               {
                    return tmpSecurityConfig;
               }

               Debug.Assert(reader.NodeType == XmlNodeType.Element);
               reader.ReadStartElement();
               reader.MoveToContent();

               while (true)
               {
                    var tmpNodeType = reader.NodeType;
                    if (tmpNodeType == XmlNodeType.None || tmpNodeType == XmlNodeType.EndElement)
                    {
                         break;
                    }

                    if (tmpNodeType == XmlNodeType.Element)
                    {
                         switch (reader.LocalName)
                         {
                              default:
                                   reader.Skip();
                                   break;

                              case "Account":
                                   ReadAccountConfig(tmpSecurityConfig.CurrentAccount, reader);
                                   break;

                              case "LockWorkspace":
                                   tmpSecurityConfig.LockWorkspace = ReadLockWorkspaceConfig(reader);
                                   break;

                              case "MasterPassword":
                                   tmpSecurityConfig.MasterPassword = ReadMasterPasswordConfig(reader);
                                   break;

                              case "Clipboard":
                                   tmpSecurityConfig.Clipboard = ReadClipboardSettings(reader);
                                   break;

                              case "SecretRank":
                                   tmpSecurityConfig.SecretRank = ReadSecretRankSettings(reader);
                                   break;
                         }

                         reader.MoveToContent();
                    }
               }

               reader.ReadEndElement();

               return tmpSecurityConfig;
          }
          
          private static PasswordGeneratorProfile ReadPasswordProfile(XmlReader reader)
          {
               var tmpPasswordProfile = new PasswordGeneratorProfile();
               if (SkipEmptyElement(reader))
               {
                    return tmpPasswordProfile;
               }

               Debug.Assert(reader.NodeType == XmlNodeType.Element);
               reader.ReadStartElement();
               reader.MoveToContent();

               while (true)
               {
                    var tmpNodeType = reader.NodeType;
                    if (tmpNodeType == XmlNodeType.None || tmpNodeType == XmlNodeType.EndElement)
                    {
                         break;
                    }

                    if (tmpNodeType == XmlNodeType.Element)
                    {
                         switch (reader.LocalName)
                         {
                              default:
                                   reader.Skip();
                                   break;

                              case "UsingAllNumeric":
                                   tmpPasswordProfile.UsingAllNumeric = ReadBoolean(reader);
                                   break;

                              case "Length":
                                   tmpPasswordProfile.Length = ReadUInt32(reader);
                                   break;

                              case "UsingUpperCase":
                                   tmpPasswordProfile.UsingUpperCase = ReadBoolean(reader);
                                   break;

                              case "UsingLowerCase":
                                   tmpPasswordProfile.UsingLowerCase = ReadBoolean(reader);
                                   break;

                              case "UsingDigitChars":
                                   tmpPasswordProfile.UsingDigitChars = ReadBoolean(reader);
                                   break;

                              case "UsingMinusChar":
                                   tmpPasswordProfile.UsingMinusChar = ReadBoolean(reader);
                                   break;

                              case "UsingUnderline":
                                   tmpPasswordProfile.UsingUnderline = ReadBoolean(reader);
                                   break;

                              case "UsingSpaceChar":
                                   tmpPasswordProfile.UsingSpaceChar = ReadBoolean(reader);
                                   break;

                              case "UsingSpecialChars":
                                   tmpPasswordProfile.UsingSpecialChars = ReadBoolean(reader);
                                   break;

                              case "UsingBracketChars":
                                   tmpPasswordProfile.UsingBracketChars = ReadBoolean(reader);
                                   break;

                              case "ExcludeLookAlike":
                                   tmpPasswordProfile.ExcludeLookAlike = ReadBoolean(reader);
                                   break;

                              case "NoRepeatingChars":
                                   tmpPasswordProfile.NoRepeatingChars = ReadBoolean(reader);
                                   break;

                              case "ExcludeCharacters":
                                   tmpPasswordProfile.ExcludeCharacters = ReadString(reader);
                                   break;
                         }

                         reader.MoveToContent();
                    }
               }

               reader.ReadEndElement();

               return tmpPasswordProfile;
          }

          private static void ReadAccountConfig(HuiruiSoft.Safe.Account account, XmlReader reader)
          {
               if (SkipEmptyElement(reader))
               {
                    return;
               }

               Debug.Assert(reader.NodeType == XmlNodeType.Element);
               reader.ReadStartElement();
               reader.MoveToContent();

               while (true)
               {
                    var tmpNodeType = reader.NodeType;
                    if (tmpNodeType == XmlNodeType.None || tmpNodeType == XmlNodeType.EndElement)
                    {
                         break;
                    }

                    if (tmpNodeType == XmlNodeType.Element)
                    {
                         switch (reader.LocalName)
                         {
                              default:
                                   reader.Skip();
                                   break;

                              case "UserName":
                                   account.UserName = ReadString(reader);
                                   break;

                              case "Password":
                                   account.PasswordStored = ReadString(reader);
                                   break;
                         }

                         reader.MoveToContent();
                    }
               }

               reader.ReadEndElement();
          }

          private static LockWorkspace ReadLockWorkspaceConfig(XmlReader reader)
          {
               var tmpLockConfig = new LockWorkspace();
               if (SkipEmptyElement(reader))
               {
                    return tmpLockConfig;
               }

               Debug.Assert(reader.NodeType == XmlNodeType.Element);
               reader.ReadStartElement();
               reader.MoveToContent();

               while (true)
               {
                    var tmpNodeType = reader.NodeType;
                    if (tmpNodeType == XmlNodeType.None || tmpNodeType == XmlNodeType.EndElement)
                    {
                         break;
                    }

                    if (tmpNodeType == XmlNodeType.Element)
                    {
                         switch (reader.LocalName)
                         {
                              default:
                                   reader.Skip();
                                   break;

                              case "LockWindowAfterTime":
                                   tmpLockConfig.LockWindowAfterTime = ReadUInt32(reader);
                                   break;

                              case "LockScreenAfterTime":
                                   tmpLockConfig.LockScreenAfterTime = ReadUInt32(reader);
                                   break;

                              case "LockOnMinimizeTaskbar":
                                   tmpLockConfig.LockOnMinimizeTaskbar = ReadBoolean(reader);
                                   break;

                              case "LockOnMinimizeToTray":
                                   tmpLockConfig.LockOnMinimizeToTray = ReadBoolean(reader);
                                   break;
                         }

                         reader.MoveToContent();
                    }
               }

               reader.ReadEndElement();

               return tmpLockConfig;
          }

          private static MasterPassword ReadMasterPasswordConfig(XmlReader reader)
          {
               var tmpMasterPassword = new MasterPassword();
               if (SkipEmptyElement(reader))
               {
                    return tmpMasterPassword;
               }

               Debug.Assert(reader.NodeType == XmlNodeType.Element);
               reader.ReadStartElement();
               reader.MoveToContent();

               while (true)
               {
                    var tmpNodeType = reader.NodeType;
                    if (tmpNodeType == XmlNodeType.None || tmpNodeType == XmlNodeType.EndElement)
                    {
                         break;
                    }

                    if (tmpNodeType == XmlNodeType.Element)
                    {
                         switch (reader.LocalName)
                         {
                              default:
                                   reader.Skip();
                                   break;

                              case "MinimumLength":
                                   tmpMasterPassword.MinimumLength = ReadUInt32(reader);
                                   break;

                              case "MinimumQuality":
                                   tmpMasterPassword.MinimumQuality = ReadUInt32(reader);
                                   break;
                         }

                         reader.MoveToContent();
                    }
               }

               reader.ReadEndElement();

               return tmpMasterPassword;
          }

          private static ClipboardSettings ReadClipboardSettings(XmlReader reader)
          {
               var tmpClipboardSettings = new ClipboardSettings();
               if (SkipEmptyElement(reader))
               {
                    return tmpClipboardSettings;
               }

               Debug.Assert(reader.NodeType == XmlNodeType.Element);
               reader.ReadStartElement();
               reader.MoveToContent();

               while (true)
               {
                    var tmpNodeType = reader.NodeType;
                    if (tmpNodeType == XmlNodeType.None || tmpNodeType == XmlNodeType.EndElement)
                    {
                         break;
                    }

                    if (tmpNodeType == XmlNodeType.Element)
                    {
                         switch (reader.LocalName)
                         {
                              default:
                                   reader.Skip();
                                   break;

                              case "ClipboardClearOnExit":
                                   tmpClipboardSettings.ClipboardClearOnExit = ReadBoolean(reader);
                                   break;

                              case "ClipboardClearAfterSeconds":
                                   tmpClipboardSettings.ClipboardClearAfterSeconds = ReadUInt32(reader);
                                   break;
                         }

                         reader.MoveToContent();
                    }
               }

               reader.ReadEndElement();

               return tmpClipboardSettings;
          }


          private static SecretRankSettings ReadSecretRankSettings(XmlReader reader)
          {
               var tmpSecretRankSettings = new SecretRankSettings();
               if (SkipEmptyElement(reader))
               {
                    return tmpSecretRankSettings;
               }

               Debug.Assert(reader.NodeType == XmlNodeType.Element);
               reader.ReadStartElement();
               reader.MoveToContent();

               while (true)
               {
                    var tmpNodeType = reader.NodeType;
                    if (tmpNodeType == XmlNodeType.None || tmpNodeType == XmlNodeType.EndElement)
                    {
                         break;
                    }

                    if (tmpNodeType == XmlNodeType.Element)
                    {
                         switch (reader.LocalName)
                         {
                              default:
                                   reader.Skip();
                                   break;

                              case "SecretRank0Color":
                                   tmpSecretRankSettings.Rank0BackColor = ReadColor(reader, tmpSecretRankSettings.Rank0BackColor);
                                   break;

                              case "SecretRank1Color":
                                   tmpSecretRankSettings.Rank1BackColor = ReadColor(reader, tmpSecretRankSettings.Rank1BackColor);
                                   break;

                              case "SecretRank2Color":
                                   tmpSecretRankSettings.Rank2BackColor = ReadColor(reader, tmpSecretRankSettings.Rank2BackColor);
                                   break;

                              case "SecretRank3Color":
                                   tmpSecretRankSettings.Rank3BackColor = ReadColor(reader, tmpSecretRankSettings.Rank3BackColor);
                                   break;
                         }

                         reader.MoveToContent();
                    }
               }

               reader.ReadEndElement();

               return tmpSecretRankSettings;
          }


          private static string ReadString(XmlReader reader)
          {
               return reader.ReadElementString();
          }

          private static bool ReadBoolean(XmlReader reader)
          {
               return XmlConvert.ToBoolean(reader.ReadElementString());
          }

          private static int ReadInt32(XmlReader reader)
          {
               return XmlConvert.ToInt32(reader.ReadElementString());
          }

          private static uint ReadUInt32(XmlReader reader)
          {
               return XmlConvert.ToUInt32(reader.ReadElementString());
          }

          private static long ReadInt64(XmlReader reader)
          {
               return XmlConvert.ToInt64(reader.ReadElementString());
          }

          private static ulong ReadUInt64(XmlReader reader)
          {
               return XmlConvert.ToUInt64(reader.ReadElementString());
          }

          private static float ReadSingle(XmlReader reader)
          {
               return XmlConvert.ToSingle(reader.ReadElementString());
          }

          private static double ReadDouble(XmlReader reader)
          {
               return XmlConvert.ToDouble(reader.ReadElementString());
          }

          private static System.Drawing.Color ReadColor(XmlReader reader, System.Drawing.Color? defaultColor = null)
          {
               var tmpColorResult = System.Drawing.Color.Empty;

               var tmpNodeContent = reader.ReadElementString();
               if (string.IsNullOrEmpty(tmpNodeContent))
               {
                    if (defaultColor.HasValue)
                    {
                         tmpColorResult = defaultColor.Value;
                    }
               }
               else
               {
                    try
                    {
                         tmpColorResult = HuiruiSoft.Drawing.ColorTranslator.FromHtml(tmpNodeContent);
                    }
                    catch (System.Exception)
                    {
                         if (defaultColor.HasValue)
                         {
                              tmpColorResult = defaultColor.Value;
                         }
                    }
               }

               return tmpColorResult;
          }
     }
}
