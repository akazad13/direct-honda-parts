﻿CREATE TABLE [dbo].[Door]
(
	[ID] INT CONSTRAINT PK_Door PRIMARY KEY CLUSTERED (ID),
	[Description] VARCHAR(10) NOT NULL,
	[EffectiveDate] DATETIME NOT NULL CONSTRAINT DF_Door_EffectiveDate DEFAULT(GETDATE()),
	[DateLastUpdated] DATETIME NOT NULL CONSTRAINT DF_Door_DateLastUpdated DEFAULT(GETDATE()),
	[UserIDLastUpdated] BIGINT NOT NULL CONSTRAINT DF_Door_UserIDLastUpdated DEFAULT(0)
)
