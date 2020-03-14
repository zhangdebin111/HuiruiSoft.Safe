
using System.Threading;
using System.Collections.Generic;

namespace HuiruiSoft.Utils
{
     public static class GlobalMutexPool
     {
          private static List<KeyValuePair<string, Mutex>> mutexesPool = new List<KeyValuePair<string, Mutex>>();

          public static bool CreateMutex(string name, bool initiallyOwned)
          {
               bool tmpCreateResult = false;
               try
               {
                    bool tmpCreatedNew;
                    var mutex = new Mutex(initiallyOwned, name, out tmpCreatedNew);
                    if (tmpCreatedNew)
                    {
                         mutexesPool.Add(new KeyValuePair<string, Mutex>(name, mutex));
                         tmpCreateResult = true;
                    }
               }
               catch (System.Exception)
               {
                    System.Diagnostics.Debug.Assert(false);
               }

               return tmpCreateResult;
          }

          public static void ReleaseAll()
          {
               for (int index = mutexesPool.Count - 1; index >= 0; --index)
               {
                    ReleaseMutex(mutexesPool[index].Key);
               }
          }

          public static bool ReleaseMutex(string name)
          {
               for (int index = 0; index < mutexesPool.Count; ++index)
               {
                    if (mutexesPool[index].Key.Equals(name, System.StringComparison.OrdinalIgnoreCase))
                    {
                         try
                         {
                              mutexesPool[index].Value.ReleaseMutex();
                         }
                         catch (System.Exception)
                         {
                              System.Diagnostics.Debug.Assert(false);
                         }

                         try
                         {
                              mutexesPool[index].Value.Close();
                         }
                         catch (System.Exception)
                         {
                              System.Diagnostics.Debug.Assert(false);
                         }

                         mutexesPool.RemoveAt(index);
                         return true;
                    }
               }

               return false;
          }
     }
}