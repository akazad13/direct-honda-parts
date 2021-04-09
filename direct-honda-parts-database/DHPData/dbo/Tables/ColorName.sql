﻿CREATE TABLE [dbo].[ColorName]
(
	[ID] INT CONSTRAINT PK_ColorName PRIMARY KEY CLUSTERED (ID),
	[Description] VARCHAR(60) NOT NULL,
	[EffectiveDate] DATETIME NOT NULL CONSTRAINT DF_ColorName_EffectiveDate DEFAULT(GETDATE()),
	[DateLastUpdated] DATETIME NOT NULL CONSTRAINT DF_ColorName_DateLastUpdated DEFAULT(GETDATE()),
	[UserIDLastUpdated] BIGINT NOT NULL CONSTRAINT DF_ColorName_UserIDLastUpdated DEFAULT(0)
)
