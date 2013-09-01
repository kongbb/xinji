﻿CREATE TABLE [dbo].[CR_MENUITEM_MODIFIER_GROUP] (
    [ID]            INT        NOT NULL,
    [MIN_QUANTITY]  INT        NOT NULL,
    [MAX_QUANTITY]  INT        NOT NULL,
    [MENU_ITEM]     INT        NULL,
    [GROUP_ID]      INT        NULL,
    [ACCOUNT_ID]    INT        NULL,
    [MODIFIED_TIME] ROWVERSION NULL,
    [MODIFIED_BY]   INT        NOT NULL,
    CONSTRAINT [PK_CR_MENUITEM_MODIFIER_GROUP] PRIMARY KEY CLUSTERED ([ID] ASC)
);

