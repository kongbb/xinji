﻿CREATE TABLE [dbo].[RC_MENUITEM_MODIFIER_GROUP] (
    [ID]            BIGINT     IDENTITY (1, 1) NOT NULL,
	[ACCOUNT_ID]    BIGINT     NOT NULL,
    [MIN_QUANTITY]  INT        NOT NULL,
    [MAX_QUANTITY]  INT        NOT NULL,
    [MENU_ITEM]     INT        NULL,
    [GROUP_ID]      INT        NULL,
    [MODIFIED_TIME] ROWVERSION NOT NULL,
    [MODIFIED_BY]   INT        NULL,
    CONSTRAINT [PK_CR_MENUITEM_MODIFIER_GROUP] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_RC_MENUITEM_MODIFIER_GROUP_RC_ACCOUNTS] FOREIGN KEY ([ACCOUNT_ID]) REFERENCES [dbo].[RC_ACCOUNTS] ([ACCOUNT_ID]),
);