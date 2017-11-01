CREATE TABLE [dbo].[Person] (
    [UserCode] INT          NOT NULL,
    [Name]     VARCHAR (50) NOT NULL,
    [Mobile]   INT          NOT NULL,
    [Email]    VARCHAR (50) NOT NULL,
    [City]     VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([UserCode] ASC)
);

