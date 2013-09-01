﻿CREATE TABLE [dbo].[CR_USERS] (
    [USER_ID]       INT        NOT NULL,
    [LOGIN_NAME]    NCHAR (60) NULL,
    [ACCOUNT_ID]    INT        NULL,
    [SHIFT_ID]      INT        NOT NULL,
    [FIRST_NAME]    NCHAR (30) NOT NULL,
    [LAST_NAME]     NCHAR (30) NOT NULL,
    [PASSWORD]      NCHAR (60) NULL,
    [MODIFIED_TIME] ROWVERSION NOT NULL,
    [MODIFIED_BY]   INT        NOT NULL,
    CONSTRAINT [PK_CR_USERS] PRIMARY KEY CLUSTERED ([USER_ID] ASC)
);

