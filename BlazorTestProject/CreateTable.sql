CREATE TABLE [dbo].[User] (
    [Id]     INT          IDENTITY (1, 1) NOT NULL,
    [Name]   VARCHAR (40) NOT NULL,
    [Number] VARCHAR (20) NOT NULL,
    [Email]  VARCHAR (50) NOT NULL
);