namespace HuiruiSoft.Security.Cryptography
{
     using System.Security.Cryptography;

     public class EncryptorHelper
     {
          public static byte[] HashSha256(byte[] buffer)
          {
               if (buffer == null)
               {
                    throw new System.ArgumentNullException("buffer");
               }

               return HashSha256(buffer, 0, buffer.Length);
          }


          public static byte[] HashSha256(byte[] buffer, int offset, int count)
          {
               if (buffer == null)
               {
                    throw new System.ArgumentNullException("buffer");
               }

               byte[] tmpHashResult;
               using (var tmpHashAlgorithm = new SHA256Managed())
               {
                    tmpHashResult = tmpHashAlgorithm.ComputeHash(buffer, offset, count);
               }

               return tmpHashResult;
          }

          public static string AESEncrypt(string plainText, string secretKey, string iv)
          {
               byte[] tmpEncrypted;
               using (var tmpRijndael = new RijndaelManaged())
               {
                    tmpRijndael.Mode = CipherMode.CBC;
                    tmpRijndael.Padding = PaddingMode.Zeros;
                    tmpRijndael.IV = System.Text.Encoding.UTF8.GetBytes(iv);
                    tmpRijndael.Key = System.Text.Encoding.UTF8.GetBytes(secretKey);

                    var tmpCryptoTransform = tmpRijndael.CreateEncryptor();
                    var tmpToEncryptBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
                    tmpEncrypted = tmpCryptoTransform.TransformFinalBlock(tmpToEncryptBytes, 0, tmpToEncryptBytes.Length);
               }

               return System.Convert.ToBase64String(tmpEncrypted, 0, tmpEncrypted.Length);
          }

          public static string AESDecrypt(string cipherText, string secretKey, string iv)
          {
               byte[] tmpDecrypted;

               using (var tmpRijndael = new RijndaelManaged())
               {
                    tmpRijndael.Mode = CipherMode.CBC;
                    tmpRijndael.Padding = PaddingMode.Zeros;
                    tmpRijndael.IV = System.Text.Encoding.UTF8.GetBytes(iv);
                    tmpRijndael.Key = System.Text.Encoding.UTF8.GetBytes(secretKey);

                    var tmpCryptoTransform = tmpRijndael.CreateDecryptor();
                    var tmpToDecryptBytes = System.Convert.FromBase64String(cipherText);
                    tmpDecrypted = tmpCryptoTransform.TransformFinalBlock(tmpToDecryptBytes, 0, tmpToDecryptBytes.Length);
               }

               return System.Text.Encoding.UTF8.GetString(tmpDecrypted);
          }

          public static string DESEncrypt(string encryptKey, string plainText)
          {
               string tmpDecryptedString = plainText;
               if (!string.IsNullOrEmpty(plainText))
               {
                    try
                    {
                         var tmpCryptoProvider = new DESCryptoServiceProvider();
                         tmpCryptoProvider.Key = System.Text.Encoding.ASCII.GetBytes(encryptKey);
                         tmpCryptoProvider.IV = System.Text.Encoding.ASCII.GetBytes(encryptKey);

                         var tmpMemoryStream = new System.IO.MemoryStream();
                         var tmpCryptoStream = new CryptoStream(tmpMemoryStream, tmpCryptoProvider.CreateEncryptor(), CryptoStreamMode.Write);

                         byte[] tmpSourceBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
                         tmpCryptoStream.Write(tmpSourceBytes, 0, tmpSourceBytes.Length);
                         tmpCryptoStream.FlushFinalBlock();
                         tmpDecryptedString = System.Convert.ToBase64String(tmpMemoryStream.ToArray());
                    }
                    catch (System.Exception exception)
                    {
                         System.Diagnostics.Debug.Write(exception.Message);
                    }
               }

               return tmpDecryptedString;
          }

          public static string DESDecrypt(string secretKey, string cipherText)
          {
               if (string.IsNullOrEmpty(cipherText))
               {
                    return cipherText;
               }
               else
               {
                    var tmpMemoryStream = new System.IO.MemoryStream();

                    try
                    {
                         var tmpCryptoProvider = new DESCryptoServiceProvider();
                         tmpCryptoProvider.Key = System.Text.Encoding.ASCII.GetBytes(secretKey);
                         tmpCryptoProvider.IV = System.Text.Encoding.ASCII.GetBytes(secretKey);

                         var tmpCryptoStream = new CryptoStream(tmpMemoryStream, tmpCryptoProvider.CreateDecryptor(), CryptoStreamMode.Write);

                         byte[] tmpSourceBytes = System.Convert.FromBase64String(cipherText);
                         tmpCryptoStream.Write(tmpSourceBytes, 0, tmpSourceBytes.Length);
                         tmpCryptoStream.FlushFinalBlock();
                    }
                    catch (System.Exception exception)
                    {
                         System.Diagnostics.Debug.Write(exception.Message);
                    }

                    return System.Text.Encoding.UTF8.GetString(tmpMemoryStream.ToArray());
               }
          }


          public static string RSAEncrypt(string publicKey, string plainText)
          {
               if (string.IsNullOrEmpty(plainText))
               {
                    return plainText;
               }

               string tmpEncryptedString = plainText;
               using (var tmpRSACryptoGraphy = new RSACryptoServiceProvider())
               {
                    tmpRSACryptoGraphy.FromXmlString(publicKey);

                    int tmpMaxBlockSize = tmpRSACryptoGraphy.KeySize / 8 - 11;    //加密块最大长度限制

                    byte[] tmpPlainTextData = System.Text.Encoding.UTF8.GetBytes(plainText);
                    if (tmpPlainTextData.Length <= tmpMaxBlockSize)
                    {
                         tmpEncryptedString = System.Convert.ToBase64String(tmpRSACryptoGraphy.Encrypt(tmpPlainTextData, false));
                    }
                    else
                    {
                         using (var tmpCryptoStream = new System.IO.MemoryStream())
                         {
                              using (var tmpMemoryStream = new System.IO.MemoryStream(tmpPlainTextData))
                              {
                                   byte[] tmpBlockBuffer = new byte[tmpMaxBlockSize];

                                   int tmpBlockSize = tmpMemoryStream.Read(tmpBlockBuffer, 0, tmpMaxBlockSize);
                                   while (tmpBlockSize > 0)
                                   {
                                        byte[] tmpEncryptBytes = new byte[tmpBlockSize];
                                        System.Array.Copy(tmpBlockBuffer, 0, tmpEncryptBytes, 0, tmpBlockSize);

                                        byte[] tmpCryptoBytes = tmpRSACryptoGraphy.Encrypt(tmpEncryptBytes, false);
                                        tmpCryptoStream.Write(tmpCryptoBytes, 0, tmpCryptoBytes.Length);

                                        tmpBlockSize = tmpMemoryStream.Read(tmpBlockBuffer, 0, tmpMaxBlockSize);
                                   }

                                   tmpEncryptedString = System.Convert.ToBase64String(tmpCryptoStream.ToArray(), System.Base64FormattingOptions.None);
                              }
                         }
                    }
               }

               return tmpEncryptedString;
          }

          public static string RSADecrypt(string privateKey, string cipherText)
          {
               if (string.IsNullOrEmpty(cipherText))
               {
                    return cipherText;
               }

               string tmpDecryptedString = cipherText;
               using (var tmpRSACryptoGraphy = new RSACryptoServiceProvider())
               {
                    tmpRSACryptoGraphy.FromXmlString(privateKey);

                    int tmpMaxBlockSize = tmpRSACryptoGraphy.KeySize / 8;    //解密块最大长度限制

                    byte[] tmpCipherTextData = System.Convert.FromBase64String(cipherText);
                    if (tmpCipherTextData.Length <= tmpMaxBlockSize)
                    {
                         tmpDecryptedString = System.Text.Encoding.UTF8.GetString(tmpRSACryptoGraphy.Decrypt(tmpCipherTextData, false));
                    }
                    else
                    {
                         using (var tmpCryptoStream = new System.IO.MemoryStream(tmpCipherTextData))
                         {
                              using (var tmpPlainStream = new System.IO.MemoryStream())
                              {
                                   byte[] tmpBlockBuffer = new byte[tmpMaxBlockSize];

                                   int tmpBlockSize = tmpCryptoStream.Read(tmpBlockBuffer, 0, tmpMaxBlockSize);
                                   while (tmpBlockSize > 0)
                                   {
                                        byte[] tmpDecryptBytes = new byte[tmpBlockSize];
                                        System.Array.Copy(tmpBlockBuffer, 0, tmpDecryptBytes, 0, tmpBlockSize);

                                        byte[] tmpPlainBytes = tmpRSACryptoGraphy.Decrypt(tmpDecryptBytes, false);
                                        tmpPlainStream.Write(tmpPlainBytes, 0, tmpPlainBytes.Length);

                                        tmpBlockSize = tmpCryptoStream.Read(tmpBlockBuffer, 0, tmpMaxBlockSize);
                                   }

                                   tmpDecryptedString = System.Text.Encoding.UTF8.GetString(tmpPlainStream.ToArray());
                              }
                         }
                    }
               }

               return tmpDecryptedString;
          }
     }
}