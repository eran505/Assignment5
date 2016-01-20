CREATE TABLE [dbo].[RUsers] (
    [Email]    VARCHAR (50) NOT NULL,
    [Name]     VARCHAR (50) NOT NULL,
    [Password] VARCHAR (50) NOT NULL,
    [Age]      INT          NULL,
    PRIMARY KEY CLUSTERED ([Email] ASC)
);

