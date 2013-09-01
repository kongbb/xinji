CREATE TABLE [dbo].[CR_TRANSACTION] (
    [TRANSACTION_ID]   INT             IDENTITY (1, 1) NOT NULL,
    [ACCOUNT_ID]       INT             NULL,
    [PAYMENT_TYPE]     INT             NULL,
    [MODIFIED_TIME]    BIGINT          NULL,
    [TRANSACTION_TIME] BIGINT          NULL,
    [SUB_TOTAL]        DECIMAL (18, 2) NULL,
    [TOTAL_TAX]        DECIMAL (18, 2) NULL,
    [TOTAL_DISCOUNT]   DECIMAL (18, 2) NULL,
    [TOTAL_PRICE]      DECIMAL (18, 2) NULL,
    [GRATUITY_AMOUNT]  DECIMAL (18, 2) NULL,
    [TERMINAL]         INT             NULL,
    [NOTE]             NCHAR (100)     NULL,
    [REASON_ID]        INT             NULL,
    [MODIFIED_BY]      INT             NULL,
    CONSTRAINT [PK_CR_TRANSACTION] PRIMARY KEY CLUSTERED ([TRANSACTION_ID] ASC)
);

