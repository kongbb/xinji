﻿CREATE TABLE [dbo].[CR_MENU_MODIFER] (
    [MODIFIER_ID]   INT             IDENTITY (1, 1) NOT NULL,
    [ACCOUNT_ID]    INT             NOT NULL,
    [NAME]          NCHAR (100)     NOT NULL,
    [PRICE]         DECIMAL (18, 2) NOT NULL,
    [EXTRA_PRICE]   DECIMAL (18, 2) NOT NULL,
    [ENABLE]        SMALLINT        NOT NULL,
    [GROUP_ID]      INT             NOT NULL,
    [TAX_ID]        INT             NOT NULL,
    [MODIFIED_TIME] ROWVERSION      NOT NULL,
    [MODIFIER_BY]   INT             NULL,
    CONSTRAINT [PK_CR_MENU_MODIFER] PRIMARY KEY CLUSTERED ([MODIFIER_ID] ASC)
);

