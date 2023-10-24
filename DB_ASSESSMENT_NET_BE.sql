/*
 Navicat Premium Data Transfer

 Source Server         : [Local] SQL Server
 Source Server Type    : SQL Server
 Source Server Version : 16001000 (16.00.1000)
 Source Host           : localhost\SQLEXPRESS02:1433
 Source Catalog        : DB_ASSESSMENT_NET_BE
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 16001000 (16.00.1000)
 File Encoding         : 65001

 Date: 24/10/2023 10:56:52
*/


-- ----------------------------
-- Table structure for TB_LECTURER
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[TB_LECTURER]') AND type IN ('U'))
	DROP TABLE [dbo].[TB_LECTURER]
GO

CREATE TABLE [dbo].[TB_LECTURER] (
  [LECTURER_ID] int  IDENTITY(1,1) NOT NULL,
  [LECTURER_NAME] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[TB_LECTURER] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for TB_LECTURER_DETAIL
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[TB_LECTURER_DETAIL]') AND type IN ('U'))
	DROP TABLE [dbo].[TB_LECTURER_DETAIL]
GO

CREATE TABLE [dbo].[TB_LECTURER_DETAIL] (
  [LECTURER_DETAIL_ID] int  IDENTITY(1,1) NOT NULL,
  [LECTURER_ID] int  NOT NULL,
  [LECTURER_ADDRESS] varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [LECTURER_TELP] varchar(14) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [LECTURER_EMAIL] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[TB_LECTURER_DETAIL] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for TB_STUDENT
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[TB_STUDENT]') AND type IN ('U'))
	DROP TABLE [dbo].[TB_STUDENT]
GO

CREATE TABLE [dbo].[TB_STUDENT] (
  [STUDENT_ID] int  IDENTITY(1,1) NOT NULL,
  [STUDENT_NAME] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[TB_STUDENT] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for TB_SUBJECT
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[TB_SUBJECT]') AND type IN ('U'))
	DROP TABLE [dbo].[TB_SUBJECT]
GO

CREATE TABLE [dbo].[TB_SUBJECT] (
  [SUBJECT_ID] int  IDENTITY(1,1) NOT NULL,
  [SUBJECT_NAME] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[TB_SUBJECT] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for TB_SUBJECT_LECTURER
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[TB_SUBJECT_LECTURER]') AND type IN ('U'))
	DROP TABLE [dbo].[TB_SUBJECT_LECTURER]
GO

CREATE TABLE [dbo].[TB_SUBJECT_LECTURER] (
  [SUBJECT_LECTURER_ID] int  IDENTITY(1,1) NOT NULL,
  [SUBJECT_ID] int  NULL,
  [LECTURER_ID] int  NULL
)
GO

ALTER TABLE [dbo].[TB_SUBJECT_LECTURER] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for TB_SUBJECT_LIST
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[TB_SUBJECT_LIST]') AND type IN ('U'))
	DROP TABLE [dbo].[TB_SUBJECT_LIST]
GO

CREATE TABLE [dbo].[TB_SUBJECT_LIST] (
  [SUBJECT_LIST_ID] int  IDENTITY(1,1) NOT NULL,
  [STUDENT_ID] int  NULL,
  [SUBJECT_ID] int  NULL
)
GO

ALTER TABLE [dbo].[TB_SUBJECT_LIST] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Auto increment value for TB_LECTURER
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[TB_LECTURER]', RESEED, 9)
GO


-- ----------------------------
-- Primary Key structure for table TB_LECTURER
-- ----------------------------
ALTER TABLE [dbo].[TB_LECTURER] ADD CONSTRAINT [PK_TB_DOSEN] PRIMARY KEY CLUSTERED ([LECTURER_ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for TB_LECTURER_DETAIL
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[TB_LECTURER_DETAIL]', RESEED, 3)
GO


-- ----------------------------
-- Primary Key structure for table TB_LECTURER_DETAIL
-- ----------------------------
ALTER TABLE [dbo].[TB_LECTURER_DETAIL] ADD CONSTRAINT [PK_TB_DOSEN_DETAIL_1] PRIMARY KEY CLUSTERED ([LECTURER_DETAIL_ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for TB_STUDENT
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[TB_STUDENT]', RESEED, 3)
GO


-- ----------------------------
-- Primary Key structure for table TB_STUDENT
-- ----------------------------
ALTER TABLE [dbo].[TB_STUDENT] ADD CONSTRAINT [PK_TB_STUDENT] PRIMARY KEY CLUSTERED ([STUDENT_ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for TB_SUBJECT
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[TB_SUBJECT]', RESEED, 3)
GO


-- ----------------------------
-- Primary Key structure for table TB_SUBJECT
-- ----------------------------
ALTER TABLE [dbo].[TB_SUBJECT] ADD CONSTRAINT [PK_TB_SUBJECT] PRIMARY KEY CLUSTERED ([SUBJECT_ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for TB_SUBJECT_LECTURER
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[TB_SUBJECT_LECTURER]', RESEED, 6)
GO


-- ----------------------------
-- Primary Key structure for table TB_SUBJECT_LECTURER
-- ----------------------------
ALTER TABLE [dbo].[TB_SUBJECT_LECTURER] ADD CONSTRAINT [PK_TB_SUBJECT_LECTURER] PRIMARY KEY CLUSTERED ([SUBJECT_LECTURER_ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for TB_SUBJECT_LIST
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[TB_SUBJECT_LIST]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table TB_SUBJECT_LIST
-- ----------------------------
ALTER TABLE [dbo].[TB_SUBJECT_LIST] ADD CONSTRAINT [PK_TB_SUBJECT_LIST] PRIMARY KEY CLUSTERED ([SUBJECT_LIST_ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table TB_LECTURER_DETAIL
-- ----------------------------
ALTER TABLE [dbo].[TB_LECTURER_DETAIL] ADD CONSTRAINT [FK_TB_LECTURER_DETAIL_TB_LECTURER] FOREIGN KEY ([LECTURER_ID]) REFERENCES [dbo].[TB_LECTURER] ([LECTURER_ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table TB_SUBJECT_LECTURER
-- ----------------------------
ALTER TABLE [dbo].[TB_SUBJECT_LECTURER] ADD CONSTRAINT [FK_TB_SUBJECT_LECTURER_TB_LECTURER] FOREIGN KEY ([LECTURER_ID]) REFERENCES [dbo].[TB_LECTURER] ([LECTURER_ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[TB_SUBJECT_LECTURER] ADD CONSTRAINT [FK_TB_SUBJECT_LECTURER_TB_SUBJECT] FOREIGN KEY ([SUBJECT_ID]) REFERENCES [dbo].[TB_SUBJECT] ([SUBJECT_ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table TB_SUBJECT_LIST
-- ----------------------------
ALTER TABLE [dbo].[TB_SUBJECT_LIST] ADD CONSTRAINT [FK_TB_SUBJECT_LIST_TB_STUDENT] FOREIGN KEY ([STUDENT_ID]) REFERENCES [dbo].[TB_STUDENT] ([STUDENT_ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[TB_SUBJECT_LIST] ADD CONSTRAINT [FK_TB_SUBJECT_LIST_TB_SUBJECT] FOREIGN KEY ([SUBJECT_ID]) REFERENCES [dbo].[TB_SUBJECT] ([SUBJECT_ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

