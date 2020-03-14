using System.Security.Cryptography;

namespace HuiruiSoft.Security.Cryptography
{
     public abstract class Md5DigestHelper
     {
          public static string Md5(string input, bool toUpperCase = true)
          {
               return Md5(input, null, toUpperCase);
          }

          public static string Md5Salt(string input, string salt, bool toUpperCase = true)
          {
               return Md5Salt(input, salt, null, toUpperCase);
          }

          public static string Md5Salt(string input, string salt, System.Text.Encoding encoding, bool toUpperCase = true)
          {
               return Md5(input + salt, encoding, toUpperCase);
          }

          public static string Md5(string input, System.Text.Encoding encoding, bool toUpperCase = true)
          {
               string tmpDigestResult;
               if (encoding != null)
               {
                    tmpDigestResult = Md5DigestAsHex(encoding.GetBytes(input), toUpperCase);
               }
               else
               {
                    tmpDigestResult = Md5DigestAsHex(System.Text.Encoding.UTF8.GetBytes(input), toUpperCase);
               }

               return tmpDigestResult;
          }

          public static string Md5Base64(string input)
          {
               return Md5Base64(input, null);
          }

          public static string Md5SaltBase64(string input, string salt)
          {
               return Md5SaltBase64(input, salt, null);
          }

          public static string Md5SaltBase64(string input, string salt, System.Text.Encoding encoding)
          {
               return Md5Base64(input + salt, encoding);
          }

          public static string Md5Base64(string input, System.Text.Encoding encoding)
          {
               string tmpDigestResult;
               if (encoding != null)
               {
                    tmpDigestResult = Md5DigestAsBase64(encoding.GetBytes(input));
               }
               else
               {
                    tmpDigestResult = Md5DigestAsBase64(System.Text.Encoding.UTF8.GetBytes(input));
               }

               return tmpDigestResult;
          }

          public static byte[] Md5Digest(System.IO.Stream inputStream)
          {
               return Digest(inputStream);
          }

          public static string Md5DigestAsHex(byte[] buffer, bool toUpperCase = true)
          {
               return DigestAsHexString(buffer, toUpperCase);
          }

          public static string Md5DigestAsBase64(byte[] buffer)
          {
               byte[] tmpDigestBytes = Digest(buffer);
               return System.Convert.ToBase64String(tmpDigestBytes);
          }

          public static string Md5DigestAsHex(System.IO.Stream inputStream)
          {
               return DigestAsHexString(inputStream);
          }

          public static System.Text.StringBuilder AppendMd5DigestAsHex(byte[] buffer, System.Text.StringBuilder builder)
          {
               return AppendDigestAsHex(buffer, builder);
          }

          public static System.Text.StringBuilder AppendMd5DigestAsHex(System.IO.Stream inputStream, System.Text.StringBuilder builder)
          {
               return AppendDigestAsHex(inputStream, builder);
          }

          public static string EncodeHexString(byte[] data)
          {
               return EncodeHexString(data, true);
          }

          public static string EncodeHexString(byte[] data, bool toLowerCase)
          {
               var tmpStringBuffer = new System.Text.StringBuilder();

               string format = toLowerCase ? "X2" : "x2";
               for (int index = 0; index < data.Length; index++)
               {
                    tmpStringBuffer.Append(data[index].ToString(format));
               }

               return tmpStringBuffer.ToString();
          }

          private static byte[] Digest(byte[] buffer)
          {
               byte[] tmpDigestBytes;
               using (var tmpMD5Algorithm = MD5.Create())
               {
                    tmpDigestBytes = tmpMD5Algorithm.ComputeHash(buffer);
               }

               return tmpDigestBytes;
          }

          private static byte[] Digest(System.IO.Stream inputStream)
          {
               byte[] tmpDigestBytes;
               using (var tmpMD5Algorithm = MD5.Create())
               {
                    tmpDigestBytes = tmpMD5Algorithm.ComputeHash(inputStream);
               }

               return tmpDigestBytes;
          }

          private static string DigestAsHexString(byte[] buffer)
          {
               byte[] tmpDigestBytes = Digest(buffer);
               return EncodeHexString(tmpDigestBytes);
          }

          private static string DigestAsHexString(byte[] buffer, bool toUpperCase)
          {
               byte[] tmpDigestBytes = Digest(buffer);
               return EncodeHexString(tmpDigestBytes, toUpperCase);
          }

          private static string DigestAsHexString(System.IO.Stream inputStream)
          {
               byte[] tmpDigestBytes = Digest(inputStream);
               return EncodeHexString(tmpDigestBytes);
          }

          private static System.Text.StringBuilder AppendDigestAsHex(byte[] buffer, System.Text.StringBuilder builder)
          {
               var tmpHexDigest = DigestAsHexString(buffer);
               return builder.Append(tmpHexDigest);
          }

          private static System.Text.StringBuilder AppendDigestAsHex(System.IO.Stream inputStream, System.Text.StringBuilder builder)
          {
               var tmpHexDigest = DigestAsHexString(inputStream);
               return builder.Append(tmpHexDigest);
          }
     }
}