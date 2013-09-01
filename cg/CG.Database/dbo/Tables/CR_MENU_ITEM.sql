﻿CREATE TABLE [dbo].[CR_MENU_ITEM] (
    [ITEM_ID]       INT             IDENTITY (1, 1) NOT NULL,
    [ACCOUNT_ID]    INT             NOT NULL,
    [GROUP_ID]      INT             NOT NULL,
    [PRICE]         DECIMAL (18, 2) NOT NULL,
    [VISIBLE]       SMALLINT        NOT NULL,
    [MODIFIED_TIME] ROWVERSION      NOT NULL,
    [MODIFIED_BY]   INT             NULL,
    CONSTRAINT [PK_CR_MENU_ITEM] PRIMARY KEY CLUSTERED ([ITEM_ID] ASC)
);

