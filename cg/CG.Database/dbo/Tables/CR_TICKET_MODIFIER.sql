CREATE TABLE [dbo].[CR_TICKET_MODIFIER] (
    [ID]                         INT             IDENTITY (1, 1) NOT NULL,
    [ITEM_ID]                    INT             NOT NULL,
    [GROUP_ID]                   INT             NOT NULL,
    [ITEM_COUNT]                 INT             NOT NULL,
    [MODIFIER_NAME]              NCHAR (100)     NOT NULL,
    [MODIFIER_PRICE]             DECIMAL (18, 2) NOT NULL,
    [EXTRA_PRICE]                DECIMAL (18, 2) NULL,
    [MODIFIER_TYPE]              INT             NULL,
    [PRINT_TO_KITCHEN]           SMALLINT        NULL,
    [MODIFIERGROUP_ID]           INT             NULL,
    [TICKETITEMMODIFIERGROUP_ID] INT             NULL,
    [ITEM_ORDER]                 INT             NULL,
    [MODIFIED_TIME]              ROWVERSION      NULL,
    [MODIFIED_BY]                INT             NOT NULL,
    CONSTRAINT [PK_CR_TICKET_MODIFIER] PRIMARY KEY CLUSTERED ([ID] ASC)
);

