
namespace HuiruiSoft.Safe.Service
{
     using System.Linq;
     using System.Data.Common;
     using System.Collections.Generic;
     using HuiruiSoft.Safe.ORM;
     using HuiruiSoft.Safe.Data;
     using HuiruiSoft.Safe.Model;
     using HuiruiSoft.Safe.Convertor;

     public class AccountService
     {
          private static readonly log4net.ILog loger = log4net.LogManager.GetLogger("loger");

          private HuiruiSoft.Data.DALFactory.IAccountDataAccess accountDataAccess;
          private HuiruiSoft.Data.DALFactory.IAccountAttributeDataAccess attributeDataAccess;

          public AccountService( )
          {
               this.accountDataAccess = DataAccessFactoryHelper.CreateAccountDataAccess( );
               this.attributeDataAccess = DataAccessFactoryHelper.CreateAttributeDataAccess( );
          }


          public bool ChangePassword(string password)
          {
               bool tmpChangeResult = false;

               try
               {
                    this.accountDataAccess.ChangePassword(password);
                    tmpChangeResult = true;
               }
               catch (System.SystemException exception)
               {
                    loger.Error(exception);
                    throw exception;
               }

               return tmpChangeResult;
          }

          public bool CreateAccount(AccountModel item, DbTransaction transaction = null)
          {
               bool tmpExecuteResult = false;

               var tmpAccountEntity = AccountConvertor.Convert(Account.CurrentAccount.SecretKey, item);
               tmpAccountEntity.UpdateTime = tmpAccountEntity.CreateTime = System.DateTime.Now;

               var tmpDataBaseAccess = (IDataBase)this.accountDataAccess;
               using(var tmpDataConnection = tmpDataBaseAccess.CreateConnection(tmpDataBaseAccess.ConnectionString))
               {
                    DbTransaction tmpDataTransaction = null;
                    try
                    {
                         tmpDataConnection.Open( );
                         tmpDataTransaction = tmpDataConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

                         tmpExecuteResult = this.accountDataAccess.Create(tmpAccountEntity, tmpDataTransaction);
                         if(tmpExecuteResult)
                         {
                              item.AccountId = tmpAccountEntity.AccountId;

                              var tmpAttributeEntities = new List<AccountAttributeEntity>();
                              if (item.Attributes.Count > 0)
                              {
                                   foreach (var attribute in item.Attributes)
                                   {
                                        var tmpAttributeEntity = AccountConvertor.ConvertAttribute(Account.CurrentAccount.SecretKey, attribute);
                                        tmpAttributeEntity.AccountId = item.AccountId;
                                        tmpAttributeEntities.Add(tmpAttributeEntity);
                                   }
                              }

                              if (tmpAttributeEntities.Count > 0)
                              {
                                   tmpExecuteResult = this.attributeDataAccess.New(tmpAttributeEntities, tmpDataTransaction);
                              }
                         }

                         tmpDataTransaction.Commit( );
                    }
                    catch(System.SystemException exception)
                    {
                         if(tmpDataTransaction != null)
                         {
                              tmpDataTransaction.Rollback( );
                         }

                         loger.Error(exception);

                         throw exception;
                    }
                    finally
                    {
                         if(tmpDataConnection.State == System.Data.ConnectionState.Open)
                         {
                              tmpDataConnection.Close( );
                         }
                    }
               }

               return tmpExecuteResult;
          }

          public bool UpdateAccount(AccountModel item)
          {
               bool tmpExecuteResult = false;

               var tmpDataBaseAccess = (IDataBase)this.accountDataAccess;
               using(var tmpDataConnection = tmpDataBaseAccess.CreateConnection(tmpDataBaseAccess.ConnectionString))
               {
                    DbTransaction tmpDataTransaction = null;

                    tmpDataConnection.Open( );
                    tmpDataTransaction = tmpDataConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                    
                    var tmpOldAccountEntity = this.accountDataAccess.GetAccountEntity(item.AccountId);
                    if(tmpOldAccountEntity != null)
                    {
                         var tmpNewAccountEntity = AccountConvertor.Convert(Account.CurrentAccount.SecretKey, item);
                         tmpNewAccountEntity.CreateTime = tmpOldAccountEntity.CreateTime;
                         tmpOldAccountEntity.UpdateTime = tmpNewAccountEntity.UpdateTime = System.DateTime.Now;
                         
                         try
                         {
                              tmpExecuteResult = true;

                              bool tmpNeedUpdate = !tmpNewAccountEntity.Equals(tmpOldAccountEntity);
                              if(tmpNeedUpdate)
                              {
                                   tmpOldAccountEntity.Name = tmpNewAccountEntity.Name;
                                   tmpOldAccountEntity.URL = tmpNewAccountEntity.URL;
                                   tmpOldAccountEntity.LoginName = tmpNewAccountEntity.LoginName;
                                   tmpOldAccountEntity.Password = tmpNewAccountEntity.Password;
                                   tmpOldAccountEntity.Email = tmpNewAccountEntity.Email;
                                   tmpOldAccountEntity.Mobile = tmpNewAccountEntity.Mobile;
                                   tmpOldAccountEntity.Comment = tmpNewAccountEntity.Comment;

                                   tmpExecuteResult = this.accountDataAccess.Update(tmpOldAccountEntity, tmpDataTransaction);
                              }

                              if(tmpExecuteResult)
                              {
                                   var tmpInsertEntities = new List<AccountAttributeEntity>( );
                                   var tmpUpdateEntities = new List<AccountAttributeEntity>( );
                                   var tmpDeleteEntities = new List<AccountAttributeEntity>( );

                                   var tmpNewAttributeEntities = new List<AccountAttributeEntity>( );
                                   if(item.Attributes.Count > 0)
                                   {
                                        foreach(var attribute in item.Attributes)
                                        {
                                             var tmpAttributeEntity = AccountConvertor.ConvertAttribute(Account.CurrentAccount.SecretKey, attribute);
                                             tmpAttributeEntity.AccountId = item.AccountId;

                                             if(tmpAttributeEntity.AttributeId <= 0)
                                             {
                                                  tmpInsertEntities.Add(tmpAttributeEntity);
                                             }
                                             else
                                             {
                                                  tmpNewAttributeEntities.Add(tmpAttributeEntity);
                                             }
                                        }
                                   }

                                   var tmpOldAttributeEntities = this.attributeDataAccess.GetAccountAttributeEntities(item.AccountId, tmpDataConnection);
                                   if(tmpOldAttributeEntities != null)
                                   {
                                        foreach(var tmpOldAttribute in tmpOldAttributeEntities)
                                        {
                                             bool tmpFoundItem = false;
                                             foreach(var tmpNewAttribute in tmpNewAttributeEntities)
                                             {
                                                  if(tmpOldAttribute.AttributeId == tmpNewAttribute.AttributeId)
                                                  {
                                                       tmpFoundItem = true;
                                                       if(!tmpNewAttribute.Equals(tmpOldAttribute))
                                                       {
                                                            tmpUpdateEntities.Add(tmpNewAttribute);
                                                       }

                                                       break;
                                                  }
                                             }

                                             if(!tmpFoundItem)
                                             {
                                                  tmpDeleteEntities.Add(tmpOldAttribute);
                                             }
                                        }
                                   }

                                   if(tmpDeleteEntities.Count > 0)
                                   {
                                        tmpExecuteResult = this.attributeDataAccess.Delete(tmpDeleteEntities, tmpDataTransaction);
                                   }

                                   if(tmpInsertEntities.Count > 0)
                                   {
                                        tmpExecuteResult = this.attributeDataAccess.New(tmpInsertEntities, tmpDataTransaction);
                                   }

                                   if(tmpUpdateEntities.Count > 0)
                                   {
                                        tmpExecuteResult = this.attributeDataAccess.Update(tmpUpdateEntities, tmpDataTransaction);
                                   }
                              }

                              tmpDataTransaction.Commit( );
                         }
                         catch(System.SystemException exception)
                         {
                              if(tmpDataTransaction != null)
                              {
                                   tmpDataTransaction.Rollback( );
                              }

                              loger.Error(exception);

                              throw exception;
                         }
                         finally
                         {
                              if(tmpDataConnection.State == System.Data.ConnectionState.Open)
                              {
                                   tmpDataConnection.Close( );
                              }
                         }
                    }
               }

               return tmpExecuteResult;
          }

          public bool SetTopMost(int accountId)
          {
               return this.accountDataAccess.SetTopMost(accountId);
          }

          public bool SetTopMost(IList<int> accountIds)
          {
               return this.accountDataAccess.SetTopMost(accountIds);
          }

          public bool SetTopMost(string accountGuid)
          {
               return this.accountDataAccess.SetTopMost(accountGuid);
          }

          public bool SetTopMost(IList<string> accountGuids)
          {
               return this.accountDataAccess.SetTopMost(accountGuids);
          }

          public bool CancelTopMost(int accountId)
          {
               return this.accountDataAccess.CancelTopMost(accountId);
          }

          public bool CancelTopMost(IList<int> accountIds)
          {
               return this.accountDataAccess.CancelTopMost(accountIds);
          }

          public bool CancelTopMost(string accountGuid)
          {
               return this.accountDataAccess.CancelTopMost(accountGuid);
          }

          public bool CancelTopMost(IList<string> accountGuids)
          {
               return this.accountDataAccess.CancelTopMost(accountGuids);
          }

          public bool MoveToCatalog(IList<int> accountIds, int catalogId)
          {
               return this.accountDataAccess.MoveToCatalog(accountIds, catalogId);
          }

          public bool EmptyRecycleBin( )
          {
               return this.accountDataAccess.EmptyRecycleBin( );
          }

          public bool MoveToRecycleBin(int accountId)
          {
               return this.accountDataAccess.MoveToRecycleBin(accountId);
          }

          public bool MoveToRecycleBin(List<int> accountIds)
          {
               return this.accountDataAccess.MoveToRecycleBin(accountIds);
          }

          public bool MoveToRecycleBin(AccountModel item)
          {
               var tmpAccountEntity = AccountConvertor.Convert(Account.CurrentAccount.SecretKey, item);
               return this.accountDataAccess.MoveToRecycleBin(tmpAccountEntity);
          }

          public bool RestoreFromRecycleBin(int accountId)
          {
               return this.accountDataAccess.RestoreFromRecycleBin(accountId);
          }

          public bool RestoreFromRecycleBin(List<int> accountIds)
          {
               return this.accountDataAccess.RestoreFromRecycleBin(accountIds);
          }

          public bool RestoreFromRecycleBin(AccountModel item)
          {
               return this.accountDataAccess.RestoreFromRecycleBin(item.AccountGuid);
          }

          public bool DeleteOutrightAccounts(List<int> accountIds)
          {
               return this.accountDataAccess.DeleteOutright(accountIds);
          }

          public int GetBelongAccountCount(int catalogId)
          {
               return this.accountDataAccess.GetBelongAccountCount(catalogId);
          }

          public AccountModel GetAccountInfo(int accountId)
          {
               AccountModel tmpAccountInfo = null;

               var tmpAccountEntity = this.accountDataAccess.GetAccountEntity(accountId);
               if(tmpAccountEntity != null)
               {
                    tmpAccountInfo = AccountConvertor.Convert(Account.CurrentAccount.SecretKey, tmpAccountEntity);
                    var tmpAttributeEntities = attributeDataAccess.GetAccountAttributeEntities(accountId);
                    if(tmpAttributeEntities != null)
                    {
                         foreach(var item in tmpAttributeEntities)
                         {
                              tmpAccountInfo.Attributes.Add(AccountConvertor.ConvertAttribute(Account.CurrentAccount.SecretKey, item));
                         }
                    }
               }

               return tmpAccountInfo;
          }

          public AccountModel GetAccountInfo(string accountGuid)
          {
               AccountModel tmpAccountInfo = null;

               var tmpAccountEntity = this.accountDataAccess.GetAccountEntityByGuid(accountGuid);
               if(tmpAccountEntity != null)
               {
                    tmpAccountInfo = AccountConvertor.Convert(Account.CurrentAccount.SecretKey, tmpAccountEntity);
               }

               return tmpAccountInfo;
          }

          public List<AccountModel> GetAccountInfos( )
          {
               List<AccountModel> tmpAccountModels = null;

               var tmpAccountEntities = this.accountDataAccess.GetAccountEntities( );
               if(tmpAccountEntities != null && tmpAccountEntities.Count > 0)
               {
                    tmpAccountModels = new List<AccountModel>(tmpAccountEntities.Count);
                    foreach(AccountEntity entity in tmpAccountEntities)
                    {
                         tmpAccountModels.Add(AccountConvertor.Convert(Account.CurrentAccount.SecretKey, entity));
                    }
               }

               return tmpAccountModels;
          }

          public List<AccountModel> GetAccountInfosWithAttributes( )
          {
               List<AccountModel> tmpAccountModels = null;

               var tmpAccountEntities = this.accountDataAccess.GetAccountEntities( );
               if (tmpAccountEntities != null && tmpAccountEntities.Count > 0)
               {
                    tmpAccountModels = new List<AccountModel>(tmpAccountEntities.Count);

                    var tmpAttributeEntities = this.attributeDataAccess.GetAccountAttributeEntities();
                    foreach (AccountEntity entity in tmpAccountEntities)
                    {
                         var tmpAccountModel = AccountConvertor.Convert(Account.CurrentAccount.SecretKey, entity);
                         tmpAccountModels.Add(tmpAccountModel);

                         var tmpAccountId = tmpAccountModel.AccountId;
                         if (tmpAttributeEntities != null)
                         {
                              var tmpAccountAttributes = tmpAttributeEntities.Where(attribute => attribute.AccountId == tmpAccountId).OrderBy(attribute => attribute.Order).ThenBy(attribute => attribute.AttributeId).ToList();
                              if (tmpAccountAttributes != null && tmpAccountAttributes.Count > 0)
                              {
                                   tmpAccountAttributes.ForEach(item =>
                                   {
                                        tmpAccountModel.Attributes.Add(AccountConvertor.ConvertAttribute(Account.CurrentAccount.SecretKey, item));
                                   });
                              }
                         }
                    }
               }

               return tmpAccountModels;
          }

          public IList<AccountModel> GetAccountInfos(AccountCatalog catalog)
          {
               IList<AccountModel> tmpAccountModels = null;
               if(catalog != null)
               {
                    tmpAccountModels = this.GetAccountInfos(catalog.CatalogId);
               }

               return tmpAccountModels;
          }

          public IList<AccountModel> GetAccountInfos(int catalogId)
          {
               IList<AccountModel> tmpAccountModels = null;

               var tmpAccountEntities = this.accountDataAccess.GetAccountEntities(catalogId);
               if(tmpAccountEntities != null && tmpAccountEntities.Count > 0)
               {
                    tmpAccountModels = new List<AccountModel>(tmpAccountEntities.Count);
                    foreach(AccountEntity entity in tmpAccountEntities)
                    {
                         tmpAccountModels.Add(AccountConvertor.Convert(Account.CurrentAccount.SecretKey, entity));
                    }
               }

               return tmpAccountModels;
          }

          public IList<AccountModel> GetDeletedAccounts( )
          {
               IList<AccountModel> tmpAccountModels = null;

               var tmpAccountEntities = this.accountDataAccess.GetRecycleBinEntities( );
               if(tmpAccountEntities != null && tmpAccountEntities.Count > 0)
               {
                    tmpAccountModels = new List<AccountModel>(tmpAccountEntities.Count);
                    foreach(AccountEntity entity in tmpAccountEntities)
                    {
                         tmpAccountModels.Add(AccountConvertor.Convert(Account.CurrentAccount.SecretKey, entity));
                    }
               }

               return tmpAccountModels;
          }
     }
}