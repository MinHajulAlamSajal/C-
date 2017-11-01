CREATE TABLE [dbo].[Restaurant] (
    [Id]          INT          NOT NULL,
    [Name]        VARCHAR (50) NOT NULL,
    [Price]       INT          NOT NULL,
    [Ingredients] VARCHAR (50) NOT NULL,
    [Image]       IMAGE        NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

