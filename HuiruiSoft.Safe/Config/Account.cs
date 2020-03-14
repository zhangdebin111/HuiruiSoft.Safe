using System.Xml.Serialization;
using HuiruiSoft.Security.Cryptography;

namespace HuiruiSoft.Safe
{
     public class Account
     {
          private string userName;

          [XmlElement("UserName")]
          public string UserName
          {
               get
               {
                    return this.userName;
               }

               set
               {
                    if (value == null)
                    {
                         this.userName = value;
                         this.SecretKey = null;
                    }
                    else if (!string.Equals(this.userName, value, System.StringComparison.OrdinalIgnoreCase))
                    {
                         this.userName = value.ToLower();
                         var tmpSecretKey = Md5DigestHelper.Md5(this.userName);
                         this.SecretKey = tmpSecretKey == null ? null : tmpSecretKey.Substring(0, 8);
                    }
               }
          }

          [XmlIgnore]
          public string SecretKey
          {
               get;

               private set;
          }

          [XmlIgnore]
          public string Password
          {
               get;
               set;
          }

          [XmlIgnore]
          public string PasswordMd5
          {
               get
               {
                    return Md5DigestHelper.Md5Salt(this.Password, this.UserName);
               }
          }

          [XmlElement("Password")]
          public string PasswordStored
          {
               get;
               set;
          }

          private Account()
          {
               //
          }

          private static Account currentAccount;
          private static readonly object locker = new object();

          public static Account CurrentAccount
          {
               get
               {
                    lock (locker)
                    {
                         if (currentAccount == null)
                         {
                              currentAccount = new Account();
                         }
                    }

                    return currentAccount;
               }
          }
     }
}