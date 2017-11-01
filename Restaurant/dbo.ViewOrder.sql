CREATE TABLE [dbo].[ViewOrder] (
    [UserCode]    INT          NOT NULL,
    [Id]          INT          NOT NULL,
    [Price]       INT          NOT NULL,
    [Name]        VARCHAR (50) NOT NULL,
    [Ingredients] VARCHAR (50) NOT NULL,
    [Image]       IMAGE        NOT NULL
);

