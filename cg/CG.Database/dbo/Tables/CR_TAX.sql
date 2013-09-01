CREATE TABLE [dbo].[CR_TAX] (
    [TAX_ID]        INT             NOT NULL,
    [ACCOUNT_ID]    INT             NULL,
    [NAME]          NCHAR (100)     NULL,
    [RATE]          DECIMAL (18, 2) NULL,
    [MODIFIED_TIME] ROWVERSION      NULL,
    [MODIFIED_BY]   INT             NOT NULL,
    CONSTRAINT [PK_CR_TAX] PRIMARY KEY CLUSTERED ([TAX_ID] ASC)
);

