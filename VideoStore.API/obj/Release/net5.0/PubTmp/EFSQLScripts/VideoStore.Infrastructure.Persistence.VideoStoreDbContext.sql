IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210506022616_initial')
BEGIN
    CREATE TABLE [Genres] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(450) NULL,
        CONSTRAINT [PK_Genres] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210506022616_initial')
BEGIN
    CREATE TABLE [Movies] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(450) NULL,
        [Overview] nvarchar(max) NULL,
        [VoteCount] int NOT NULL DEFAULT 0,
        [VoteAvarage] float NOT NULL DEFAULT 0.0E0,
        [Popularity] float NOT NULL DEFAULT 0.0E0,
        [Active] bit NOT NULL DEFAULT CAST(1 AS bit),
        [CreatedAt] datetime2 NOT NULL DEFAULT (getdate()),
        [DeletedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_Movies] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210506022616_initial')
BEGIN
    CREATE TABLE [Person] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(450) NULL,
        [Biography] nvarchar(max) NULL,
        [Gender] nvarchar(max) NULL,
        [Birthday] datetime2 NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_Person] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210506022616_initial')
BEGIN
    CREATE TABLE [ProductionCompanies] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(450) NULL,
        CONSTRAINT [PK_ProductionCompanies] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210506022616_initial')
BEGIN
    CREATE TABLE [Users] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Email] nvarchar(450) NULL,
        [Password] nvarchar(max) NULL,
        [Role] nvarchar(max) NULL,
        [Active] bit NOT NULL DEFAULT CAST(1 AS bit),
        [DeletedAt] datetime2 NOT NULL,
        [CreatedAt] datetime2 NOT NULL DEFAULT (getdate()),
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210506022616_initial')
BEGIN
    CREATE TABLE [MovieGenre] (
        [MovieId] int NOT NULL,
        [GenreId] int NOT NULL,
        CONSTRAINT [PK_MovieGenre] PRIMARY KEY ([MovieId], [GenreId]),
        CONSTRAINT [FK_MovieGenre_Genres_GenreId] FOREIGN KEY ([GenreId]) REFERENCES [Genres] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_MovieGenre_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210506022616_initial')
BEGIN
    CREATE TABLE [MovieActor] (
        [MovieId] int NOT NULL,
        [PeopleId] int NOT NULL,
        CONSTRAINT [PK_MovieActor] PRIMARY KEY ([MovieId], [PeopleId]),
        CONSTRAINT [FK_MovieActor_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_MovieActor_Person_PeopleId] FOREIGN KEY ([PeopleId]) REFERENCES [Person] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210506022616_initial')
BEGIN
    CREATE TABLE [MovieDirector] (
        [MovieId] int NOT NULL,
        [PeopleId] int NOT NULL,
        CONSTRAINT [PK_MovieDirector] PRIMARY KEY ([MovieId], [PeopleId]),
        CONSTRAINT [FK_MovieDirector_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_MovieDirector_Person_PeopleId] FOREIGN KEY ([PeopleId]) REFERENCES [Person] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210506022616_initial')
BEGIN
    CREATE TABLE [MovieProductionCompany] (
        [MovieId] int NOT NULL,
        [ProductionCompanyId] int NOT NULL,
        CONSTRAINT [PK_MovieProductionCompany] PRIMARY KEY ([MovieId], [ProductionCompanyId]),
        CONSTRAINT [FK_MovieProductionCompany_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_MovieProductionCompany_ProductionCompanies_ProductionCompanyId] FOREIGN KEY ([ProductionCompanyId]) REFERENCES [ProductionCompanies] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210506022616_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Genres]'))
        SET IDENTITY_INSERT [Genres] ON;
    EXEC(N'INSERT INTO [Genres] ([Id], [Name])
    VALUES (1, N''Romance''),
    (2, N''Terror''),
    (3, N''Comedia''),
    (4, N''Action''),
    (5, N''Fiction''),
    (6, N''Adventure''),
    (7, N''Documentary'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Genres]'))
        SET IDENTITY_INSERT [Genres] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210506022616_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DeletedAt', N'Overview', N'Popularity', N'Title') AND [object_id] = OBJECT_ID(N'[Movies]'))
        SET IDENTITY_INSERT [Movies] ON;
    EXEC(N'INSERT INTO [Movies] ([Id], [DeletedAt], [Overview], [Popularity], [Title])
    VALUES (9, ''0001-01-01T00:00:00.0000000'', N'''', 1.0E0, N''Movie Best 9''),
    (8, ''0001-01-01T00:00:00.0000000'', N'''', 2.0E0, N''Movie Best 8''),
    (7, ''0001-01-01T00:00:00.0000000'', N'''', 5.0E0, N''Movie Best 7''),
    (6, ''0001-01-01T00:00:00.0000000'', N'''', 2.0E0, N''Movie Best 6''),
    (5, ''0001-01-01T00:00:00.0000000'', N'''', 8.0E0, N''Movie Best 5''),
    (4, ''0001-01-01T00:00:00.0000000'', N'''', 2.0E0, N''Movie Best 4''),
    (3, ''0001-01-01T00:00:00.0000000'', N'''', 1.0E0, N''Movie Best 3''),
    (2, ''0001-01-01T00:00:00.0000000'', N'''', 4.0E0, N''Movie Best 2''),
    (1, ''0001-01-01T00:00:00.0000000'', N'''', 3.0E0, N''Movie Best 1'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DeletedAt', N'Overview', N'Popularity', N'Title') AND [object_id] = OBJECT_ID(N'[Movies]'))
        SET IDENTITY_INSERT [Movies] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210506022616_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Biography', N'Birthday', N'CreatedAt', N'Gender', N'Name') AND [object_id] = OBJECT_ID(N'[Person]'))
        SET IDENTITY_INSERT [Person] ON;
    EXEC(N'INSERT INTO [Person] ([Id], [Biography], [Birthday], [CreatedAt], [Gender], [Name])
    VALUES (14, N''Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.'', ''2021-05-05T00:00:00.0000000-03:00'', ''0001-01-01T00:00:00.0000000'', N''male'', N''Emma''),
    (13, N''Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.'', ''2021-05-05T00:00:00.0000000-03:00'', ''0001-01-01T00:00:00.0000000'', N''male'', N''Liam''),
    (12, N''Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.'', ''2021-05-05T00:00:00.0000000-03:00'', ''0001-01-01T00:00:00.0000000'', N''male'', N''Olivia''),
    (11, N''Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.'', ''2021-05-05T00:00:00.0000000-03:00'', ''0001-01-01T00:00:00.0000000'', N''male'', N''Oliver''),
    (10, N''Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.'', ''2021-05-05T00:00:00.0000000-03:00'', ''0001-01-01T00:00:00.0000000'', N''male'', N''Elijah''),
    (9, N''Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.'', ''2021-05-05T00:00:00.0000000-03:00'', ''0001-01-01T00:00:00.0000000'', N''male'', N''Benjamin''),
    (8, N''Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.'', ''2021-05-05T00:00:00.0000000-03:00'', ''0001-01-01T00:00:00.0000000'', N''male'', N''Sophia''),
    (5, N''Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.'', ''2021-05-05T00:00:00.0000000-03:00'', ''0001-01-01T00:00:00.0000000'', N''male'', N''Charlotte''),
    (6, N''Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.'', ''2021-05-05T00:00:00.0000000-03:00'', ''0001-01-01T00:00:00.0000000'', N''male'', N''Harper''),
    (4, N''Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.'', ''2021-05-05T00:00:00.0000000-03:00'', ''0001-01-01T00:00:00.0000000'', N''male'', N''Lucas''),
    (3, N''Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.'', ''2021-05-05T00:00:00.0000000-03:00'', ''0001-01-01T00:00:00.0000000'', N''male'', N''James''),
    (2, N''Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.'', ''2021-05-05T00:00:00.0000000-03:00'', ''0001-01-01T00:00:00.0000000'', N''male'', N''Noah''),
    (1, N''Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.'', ''2021-05-05T00:00:00.0000000-03:00'', ''0001-01-01T00:00:00.0000000'', N''male'', N''Tom Wall''),
    (7, N''Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.'', ''2021-05-05T00:00:00.0000000-03:00'', ''0001-01-01T00:00:00.0000000'', N''male'', N''Ava'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Biography', N'Birthday', N'CreatedAt', N'Gender', N'Name') AND [object_id] = OBJECT_ID(N'[Person]'))
        SET IDENTITY_INSERT [Person] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210506022616_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[ProductionCompanies]'))
        SET IDENTITY_INSERT [ProductionCompanies] ON;
    EXEC(N'INSERT INTO [ProductionCompanies] ([Id], [Name])
    VALUES (9, N''606 Films''),
    (8, N''Three Mills Studios''),
    (7, N''Shepperton Studios''),
    (6, N''Pinewood Studios''),
    (3, N''Paramount''),
    (4, N''Pixar''),
    (2, N''Fox''),
    (1, N''NetFlix''),
    (5, N''Marv Films'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[ProductionCompanies]'))
        SET IDENTITY_INSERT [ProductionCompanies] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210506022616_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Active', N'DeletedAt', N'Email', N'Name', N'Password', N'Role') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] ON;
    EXEC(N'INSERT INTO [Users] ([Id], [Active], [DeletedAt], [Email], [Name], [Password], [Role])
    VALUES (1, CAST(1 AS bit), ''0001-01-01T00:00:00.0000000'', N''admin@admin.com'', N''Admin'', N''6f2cb9dd8f4b65e24e1c3f3fa5bc57982349237f11abceacd45bbcb74d621c25'', N''admin''),
    (2, CAST(1 AS bit), ''0001-01-01T00:00:00.0000000'', N''user@user.com'', N''User'', N''e7f5c00bfc7067a49da98fa9b1eacd8d428a4632197edaa84c9dacd40ca35050'', N''user'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Active', N'DeletedAt', N'Email', N'Name', N'Password', N'Role') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210506022616_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'MovieId', N'PeopleId') AND [object_id] = OBJECT_ID(N'[MovieActor]'))
        SET IDENTITY_INSERT [MovieActor] ON;
    EXEC(N'INSERT INTO [MovieActor] ([MovieId], [PeopleId])
    VALUES (4, 4),
    (6, 2),
    (1, 2),
    (7, 3),
    (6, 1),
    (5, 1),
    (3, 1),
    (1, 1),
    (7, 6),
    (5, 6),
    (3, 8),
    (4, 8),
    (5, 3),
    (1, 5),
    (4, 9),
    (4, 5),
    (2, 10),
    (2, 11),
    (8, 11),
    (2, 12),
    (9, 12),
    (2, 13),
    (8, 13),
    (2, 14),
    (9, 14),
    (3, 9),
    (1, 3)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'MovieId', N'PeopleId') AND [object_id] = OBJECT_ID(N'[MovieActor]'))
        SET IDENTITY_INSERT [MovieActor] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210506022616_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'MovieId', N'PeopleId') AND [object_id] = OBJECT_ID(N'[MovieDirector]'))
        SET IDENTITY_INSERT [MovieDirector] ON;
    EXEC(N'INSERT INTO [MovieDirector] ([MovieId], [PeopleId])
    VALUES (3, 3),
    (6, 6),
    (1, 1),
    (4, 5),
    (7, 7),
    (8, 8),
    (9, 9),
    (2, 2),
    (5, 5)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'MovieId', N'PeopleId') AND [object_id] = OBJECT_ID(N'[MovieDirector]'))
        SET IDENTITY_INSERT [MovieDirector] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210506022616_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'GenreId', N'MovieId') AND [object_id] = OBJECT_ID(N'[MovieGenre]'))
        SET IDENTITY_INSERT [MovieGenre] ON;
    EXEC(N'INSERT INTO [MovieGenre] ([GenreId], [MovieId])
    VALUES (1, 1),
    (7, 9),
    (2, 1),
    (2, 2),
    (3, 2),
    (6, 3)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'GenreId', N'MovieId') AND [object_id] = OBJECT_ID(N'[MovieGenre]'))
        SET IDENTITY_INSERT [MovieGenre] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210506022616_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'GenreId', N'MovieId') AND [object_id] = OBJECT_ID(N'[MovieGenre]'))
        SET IDENTITY_INSERT [MovieGenre] ON;
    EXEC(N'INSERT INTO [MovieGenre] ([GenreId], [MovieId])
    VALUES (1, 4),
    (2, 5),
    (5, 5),
    (7, 6),
    (5, 4),
    (1, 6),
    (6, 7),
    (4, 7),
    (4, 8),
    (3, 8),
    (2, 9),
    (5, 9),
    (2, 6)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'GenreId', N'MovieId') AND [object_id] = OBJECT_ID(N'[MovieGenre]'))
        SET IDENTITY_INSERT [MovieGenre] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210506022616_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'MovieId', N'ProductionCompanyId') AND [object_id] = OBJECT_ID(N'[MovieProductionCompany]'))
        SET IDENTITY_INSERT [MovieProductionCompany] ON;
    EXEC(N'INSERT INTO [MovieProductionCompany] ([MovieId], [ProductionCompanyId])
    VALUES (7, 7),
    (6, 6),
    (5, 5),
    (1, 1),
    (3, 3),
    (2, 2),
    (8, 8),
    (4, 5),
    (9, 9)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'MovieId', N'ProductionCompanyId') AND [object_id] = OBJECT_ID(N'[MovieProductionCompany]'))
        SET IDENTITY_INSERT [MovieProductionCompany] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210506022616_initial')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [IX_Genres_Name] ON [Genres] ([Name]) WHERE [Name] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210506022616_initial')
BEGIN
    CREATE INDEX [IX_MovieActor_PeopleId] ON [MovieActor] ([PeopleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210506022616_initial')
BEGIN
    CREATE INDEX [IX_MovieDirector_PeopleId] ON [MovieDirector] ([PeopleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210506022616_initial')
BEGIN
    CREATE INDEX [IX_MovieGenre_GenreId] ON [MovieGenre] ([GenreId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210506022616_initial')
BEGIN
    CREATE INDEX [IX_MovieProductionCompany_ProductionCompanyId] ON [MovieProductionCompany] ([ProductionCompanyId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210506022616_initial')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [IX_Movies_Title] ON [Movies] ([Title]) WHERE [Title] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210506022616_initial')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [IX_Person_Name] ON [Person] ([Name]) WHERE [Name] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210506022616_initial')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [IX_ProductionCompanies_Name] ON [ProductionCompanies] ([Name]) WHERE [Name] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210506022616_initial')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [IX_Users_Email] ON [Users] ([Email]) WHERE [Email] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210506022616_initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210506022616_initial', N'5.0.1');
END;
GO

COMMIT;
GO

