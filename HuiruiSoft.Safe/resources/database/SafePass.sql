﻿DROP TABLE IF EXISTS safe_account;
DROP TABLE IF EXISTS safe_account_attribute;
DROP TABLE IF EXISTS safe_account_catalog;

CREATE TABLE [safe_account](
  [AccountId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, 
  [AccountGuid] VARCHAR(36) NOT NULL, 
  [CatalogId] INT NOT NULL DEFAULT 0, 
  [Name] VARCHAR(50) NOT NULL, 
  [OrderNo] INT(6) NOT NULL DEFAULT 0, 
  [TopMost] TINYINT(1) NOT NULL DEFAULT 0, 
  [Deleted] TINYINT(1) NOT NULL DEFAULT 0, 
  [SecretRank] TINYINT(2) NOT NULL DEFAULT 0, 
  [LoginName] VARCHAR(100) NOT NULL, 
  [Password] VARCHAR(100) NOT NULL, 
  [Email] VARCHAR(100), 
  [Mobile] VARCHAR(100), 
  [URL] VARCHAR(200), 
  [VersionNo] INT DEFAULT 1, 
  [CreateTime] DATETIME NOT NULL, 
  [UpdateTime] DATETIME NOT NULL, 
  [Comment] VARCHAR(6000), 
  UNIQUE([AccountId] ASC));

CREATE TABLE [safe_account_attribute](
  [AttrId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, 
  [AccountId] INT NOT NULL DEFAULT 0, 
  [OrderNo] SMALLINT(6) NOT NULL DEFAULT 0, 
  [Encrypted] TINYINT(1) NOT NULL DEFAULT 0, 
  [AttrName] VARCHAR(60) NOT NULL DEFAULT '', 
  [AttrValue] VARCHAR(500) DEFAULT NULL);

CREATE TABLE [safe_account_catalog](
  [CatalogId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, 
  [Name] VARCHAR(30) NOT NULL DEFAULT '', 
  [ParentId] INT(10) NOT NULL DEFAULT 0, 
  [Depth] TINYINT(3) NOT NULL DEFAULT 0, 
  [OrderNo] INT(9) NOT NULL DEFAULT 0, 
  [VersionNo] INT DEFAULT 1, 
  [CreateTime] DATETIME NOT NULL, 
  [UpdateTime] DATETIME NOT NULL, 
  [Description] VARCHAR(100) DEFAULT NULL);

CREATE UNIQUE INDEX [Index_AccountGuid]
ON [safe_account]([AccountGuid] ASC);

