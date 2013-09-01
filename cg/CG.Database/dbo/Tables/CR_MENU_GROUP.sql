﻿CREATE TABLE [dbo].[CR_MENU_GROUP] (
    [GROUP_ID]      INT         IDENTITY (1, 1) NOT NULL,
    [ACCOUNT_ID]    INT         NOT NULL,
    [CATEGORY_ID]   INT         NOT NULL,
    [NAME]          NCHAR (100) NOT NULL,
    [VISIBLE]       SMALLINT    NOT NULL,
    [MODIFIED_TIME] ROWVERSION  NOT NULL,
    [MODIFIED_BY]   INT         NULL,
    CONSTRAINT [PK_CR_MENU_GROUP] PRIMARY KEY CLUSTERED ([GROUP_ID] ASC)
);

