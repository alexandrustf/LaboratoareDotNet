
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/09/2020 17:43:13
-- Generated from EDMX file: C:\Users\Alex Stefan\source\repos\MyPhotos.Database\MyPhotos.Persistence\ModelMyPhotos.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MyPhotos];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Photos'
CREATE TABLE [dbo].[Photos] (
    [Id] uniqueidentifier  NOT NULL,
    [Path] nvarchar(max)  NULL,
    [Name] nvarchar(max)  NULL,
    [Place] nvarchar(max)  NULL,
    [CreatedAt] datetime  NULL,
    [Event] nvarchar(max)  NULL,
    [Deleted] bit  NULL,
    [Video] bit  NULL
);
GO

-- Creating table 'People'
CREATE TABLE [dbo].[People] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Properties'
CREATE TABLE [dbo].[Properties] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Value] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PhotoPerson'
CREATE TABLE [dbo].[PhotoPerson] (
    [PhotoPerson_Person_Id] uniqueidentifier  NOT NULL,
    [People_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'PhotoProperty'
CREATE TABLE [dbo].[PhotoProperty] (
    [PhotoProperty_Property_Id] uniqueidentifier  NOT NULL,
    [Properties_Id] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Photos'
ALTER TABLE [dbo].[Photos]
ADD CONSTRAINT [PK_Photos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'People'
ALTER TABLE [dbo].[People]
ADD CONSTRAINT [PK_People]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Properties'
ALTER TABLE [dbo].[Properties]
ADD CONSTRAINT [PK_Properties]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [PhotoPerson_Person_Id], [People_Id] in table 'PhotoPerson'
ALTER TABLE [dbo].[PhotoPerson]
ADD CONSTRAINT [PK_PhotoPerson]
    PRIMARY KEY CLUSTERED ([PhotoPerson_Person_Id], [People_Id] ASC);
GO

-- Creating primary key on [PhotoProperty_Property_Id], [Properties_Id] in table 'PhotoProperty'
ALTER TABLE [dbo].[PhotoProperty]
ADD CONSTRAINT [PK_PhotoProperty]
    PRIMARY KEY CLUSTERED ([PhotoProperty_Property_Id], [Properties_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PhotoPerson_Person_Id] in table 'PhotoPerson'
ALTER TABLE [dbo].[PhotoPerson]
ADD CONSTRAINT [FK_PhotoPerson_Photo]
    FOREIGN KEY ([PhotoPerson_Person_Id])
    REFERENCES [dbo].[Photos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [People_Id] in table 'PhotoPerson'
ALTER TABLE [dbo].[PhotoPerson]
ADD CONSTRAINT [FK_PhotoPerson_Person]
    FOREIGN KEY ([People_Id])
    REFERENCES [dbo].[People]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PhotoPerson_Person'
CREATE INDEX [IX_FK_PhotoPerson_Person]
ON [dbo].[PhotoPerson]
    ([People_Id]);
GO

-- Creating foreign key on [PhotoProperty_Property_Id] in table 'PhotoProperty'
ALTER TABLE [dbo].[PhotoProperty]
ADD CONSTRAINT [FK_PhotoProperty_Photo]
    FOREIGN KEY ([PhotoProperty_Property_Id])
    REFERENCES [dbo].[Photos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Properties_Id] in table 'PhotoProperty'
ALTER TABLE [dbo].[PhotoProperty]
ADD CONSTRAINT [FK_PhotoProperty_Property]
    FOREIGN KEY ([Properties_Id])
    REFERENCES [dbo].[Properties]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PhotoProperty_Property'
CREATE INDEX [IX_FK_PhotoProperty_Property]
ON [dbo].[PhotoProperty]
    ([Properties_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------