CREATE TABLE [dbo].[CR_TICKET_ITEM] (
    [ID]                      INT             IDENTITY (1, 1) NOT NULL,
    [MODIFIED_TIME]           ROWVERSION      NULL,
    [ITEM_ID]                 INT             NOT NULL,
    [ACCOUNT_ID]              NCHAR (10)      NOT NULL,
    [ITEM_COUNT]              INT             NOT NULL,
    [ITEM_NAME]               NCHAR (100)     NULL,
    [GROUP_NAME]              NCHAR (100)     NULL,
    [CATEGORY_NAME]           NCHAR (100)     NULL,
    [ITEM_PRICE]              DECIMAL (18, 2) NULL,
    [DISCOUNT_RATE]           DECIMAL (18, 2) NULL,
    [TAX_RATE]                DECIMAL (18, 2) NULL,
    [SUB_TOTAL]               DECIMAL (18, 2) NULL,
    [SUB_TOTAL_WITH_MODIFIER] DECIMAL (18, 2) NULL,
    [MODIFIER_BY]             INT             NOT NULL,
    CONSTRAINT [PK_CR_TICKET_ITEM] PRIMARY KEY CLUSTERED ([ID] ASC)
);

