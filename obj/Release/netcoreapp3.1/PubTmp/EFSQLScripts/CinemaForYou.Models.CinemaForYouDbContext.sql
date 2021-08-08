IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210701110836_init')
BEGIN
    CREATE TABLE [Implantations] (
        [id] int NOT NULL IDENTITY,
        CONSTRAINT [PK_Implantations] PRIMARY KEY ([id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210701110836_init')
BEGIN
    CREATE TABLE [Members] (
        [id] int NOT NULL IDENTITY,
        CONSTRAINT [PK_Members] PRIMARY KEY ([id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210701110836_init')
BEGIN
    CREATE TABLE [Movies] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NOT NULL,
        [Pegi] int NOT NULL,
        [Duration] int NOT NULL,
        CONSTRAINT [PK_Movies] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210701110836_init')
BEGIN
    CREATE TABLE [Reservations] (
        [Id] int NOT NULL IDENTITY,
        CONSTRAINT [PK_Reservations] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210701110836_init')
BEGIN
    CREATE TABLE [Rooms] (
        [Id] int NOT NULL IDENTITY,
        [Number] int NOT NULL,
        [Seats] int NOT NULL,
        CONSTRAINT [PK_Rooms] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210701110836_init')
BEGIN
    CREATE TABLE [Shows] (
        [Id] int NOT NULL IDENTITY,
        [Date] datetime2 NOT NULL,
        CONSTRAINT [PK_Shows] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210701110836_init')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210701110836_init', N'3.1.16');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Movies]') AND [c].[name] = N'Pegi');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Movies] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Movies] DROP COLUMN [Pegi];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    EXEC sp_rename N'[Members].[id]', N'Id', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    EXEC sp_rename N'[Implantations].[id]', N'Id', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    ALTER TABLE [Shows] ADD [ImplantationId] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    ALTER TABLE [Shows] ADD [MovieId] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    ALTER TABLE [Shows] ADD [RoomId] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    ALTER TABLE [Rooms] ADD [ImplantationId] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    ALTER TABLE [Movies] ADD [MovieTypeId] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    ALTER TABLE [Movies] ADD [PegiId] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    ALTER TABLE [Movies] ADD [ReleaseDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    ALTER TABLE [Members] ADD [Birthdate] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    ALTER TABLE [Members] ADD [Email] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    ALTER TABLE [Members] ADD [Name] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    ALTER TABLE [Members] ADD [Password] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    ALTER TABLE [Members] ADD [Surname] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    ALTER TABLE [Implantations] ADD [Name] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    CREATE TABLE [Images] (
        [Id] int NOT NULL IDENTITY,
        [ImagePath] nvarchar(max) NULL,
        [ImageName] nvarchar(max) NULL,
        [MovieId] int NOT NULL,
        CONSTRAINT [PK_Images] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Images_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    CREATE TABLE [MovieTypes] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_MovieTypes] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    CREATE TABLE [Pegis] (
        [Id] int NOT NULL IDENTITY,
        [Description] nvarchar(max) NULL,
        [IllustrationPath] nvarchar(max) NULL,
        CONSTRAINT [PK_Pegis] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Implantations]'))
        SET IDENTITY_INSERT [Implantations] ON;
    INSERT INTO [Implantations] ([Id], [Name])
    VALUES (1, N'Anvers'),
    (2, N'Namur');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Implantations]'))
        SET IDENTITY_INSERT [Implantations] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[MovieTypes]'))
        SET IDENTITY_INSERT [MovieTypes] ON;
    INSERT INTO [MovieTypes] ([Id], [Name])
    VALUES (1, N'Action'),
    (2, N'Aventure'),
    (3, N'Horreur'),
    (4, N'Science-Fiction'),
    (5, N'Dessin Animé');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[MovieTypes]'))
        SET IDENTITY_INSERT [MovieTypes] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'IllustrationPath') AND [object_id] = OBJECT_ID(N'[Pegis]'))
        SET IDENTITY_INSERT [Pegis] ON;
    INSERT INTO [Pegis] ([Id], [Description], [IllustrationPath])
    VALUES (1, N'Avec cette classification, le contenu du film est considéré comme adapté à toutes les classes d’âge. Le film ne doit pas comporter de sons ou d’images susceptibles d’effrayer ou de faire peur à de jeunes enfants. Les formes de violence très modérées dans un contexte comique ou enfantin sont acceptables. Le film ne doit faire entendre aucun langage grossier.', N'wwwroot/img/pegi/p3.jpg'),
    (2, N'Les contenus présentant des scènes ou sons potentiellement effrayants se retrouvent dans cette classe. Avec une classification PEGI 7 des scènes de violence très modérées (une violence implicite, non détaillée ou non réaliste) peuvent être autorisées.', N'wwwroot/img/pegi/p7.jpg'),
    (3, N'Des films montrant de la violence sous une forme plus graphique par rapport à des personnages imaginaires et/ou une violence non graphique envers des personnages à figure humaine entrent dans cette classe d’âge. Des insinuations à caractère sexuel ou des postures de type sexuelles peuvent être présentes, mais dans cette catégorie les grossièretés doivent rester légères.', N'wwwroot/img/pegi/p12.jpg'),
    (4, N'Cette classification s’applique lorsque la représentation de la violence (ou d’un contact sexuel) atteint un niveau semblable à celui que l’on retrouverait dans la réalité. Les films classés dans la catégorie 16 peuvent contenir un langage grossier plus extrême, des jeux de hasard, ainsi qu’une consommation de tabac, d’alcool ou de drogues.', N'wwwroot/img/pegi/p16.jpg'),
    (5, N'La classification destinée aux adultes s’applique lorsque le degré de violence atteint un niveau où il rejoint une représentation de violence crue, de meurtre apparemment sans motivation ou de violence contre des personnages sans défense. La glorification des drogues illégales et les contacts sexuels explicites entrent également dans cette tranche d’âge. ', N'wwwroot/img/pegi/p18.jpg');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'IllustrationPath') AND [object_id] = OBJECT_ID(N'[Pegis]'))
        SET IDENTITY_INSERT [Pegis] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Duration', N'MovieTypeId', N'PegiId', N'ReleaseDate', N'Title') AND [object_id] = OBJECT_ID(N'[Movies]'))
        SET IDENTITY_INSERT [Movies] ON;
    INSERT INTO [Movies] ([Id], [Duration], [MovieTypeId], [PegiId], [ReleaseDate], [Title])
    VALUES (6, 103, 5, 1, '1985-07-03T00:00:00.0000000', N'L''age de Glace'),
    (7, 110, 1, 4, '1985-07-03T00:00:00.0000000', N'Top Gun'),
    (10, 131, 1, 3, '1985-07-03T00:00:00.0000000', N'Last Action Hero'),
    (5, 128, 3, 3, '1985-07-03T00:00:00.0000000', N'Jurassic Park'),
    (3, 107, 3, 3, '1985-07-03T00:00:00.0000000', N'Gremlins'),
    (8, 162, 4, 2, '1985-07-03T00:00:00.0000000', N'Avatar'),
    (2, 116, 4, 2, '1985-07-03T00:00:00.0000000', N'Retour vers le Futur'),
    (1, 90, 3, 5, '2003-10-17T00:00:00.0000000', N'Massacre à la tronçonneuse'),
    (9, 117, 3, 5, '1985-07-03T00:00:00.0000000', N'Alien, le huitième passager'),
    (4, 100, 5, 1, '1985-07-03T00:00:00.0000000', N'Le Monde de Némo');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Duration', N'MovieTypeId', N'PegiId', N'ReleaseDate', N'Title') AND [object_id] = OBJECT_ID(N'[Movies]'))
        SET IDENTITY_INSERT [Movies] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ImplantationId', N'Number', N'Seats') AND [object_id] = OBJECT_ID(N'[Rooms]'))
        SET IDENTITY_INSERT [Rooms] ON;
    INSERT INTO [Rooms] ([Id], [ImplantationId], [Number], [Seats])
    VALUES (3, 2, 3, 8),
    (2, 2, 2, 12),
    (1, 2, 1, 12),
    (7, 1, 4, 8),
    (6, 1, 3, 12),
    (5, 1, 2, 12),
    (4, 1, 1, 14);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ImplantationId', N'Number', N'Seats') AND [object_id] = OBJECT_ID(N'[Rooms]'))
        SET IDENTITY_INSERT [Rooms] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ImageName', N'ImagePath', N'MovieId') AND [object_id] = OBJECT_ID(N'[Images]'))
        SET IDENTITY_INSERT [Images] ON;
    INSERT INTO [Images] ([Id], [ImageName], [ImagePath], [MovieId])
    VALUES (8, N'nemo.jpg', N'wwwroot/img/movie/nemo.jpg', 4),
    (2, N'alien.jpg', N'wwwroot/img/movie/alien.jpg', 9),
    (5, N'jurassicpark.jpg', N'wwwroot/img/movie/jurassicpark.jpg', 5),
    (3, N'avatar.jpg', N'wwwroot/img/movie/avatar.jpg', 8),
    (6, N'lastactionhero.jpg', N'wwwroot/img/movie/lastactionhero.jpg', 10),
    (4, N'gremlins.jpg', N'wwwroot/img/movie/gremlins.jpg', 3),
    (10, N'topgun.jpg', N'wwwroot/img/movie/topgun.jpg', 7),
    (9, N'retourverslefutur.jpg', N'wwwroot/img/movie/retourverslefutur.jpg', 2),
    (1, N'agedeglace.jpg', N'wwwroot/img/movie/agedeglace.jpg', 6),
    (7, N'massacretronconneuse.jpg', N'wwwroot/img/movie/massacretronconneuse.jpg', 1);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ImageName', N'ImagePath', N'MovieId') AND [object_id] = OBJECT_ID(N'[Images]'))
        SET IDENTITY_INSERT [Images] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Date', N'ImplantationId', N'MovieId', N'RoomId') AND [object_id] = OBJECT_ID(N'[Shows]'))
        SET IDENTITY_INSERT [Shows] ON;
    INSERT INTO [Shows] ([Id], [Date], [ImplantationId], [MovieId], [RoomId])
    VALUES (13, '2021-08-27T20:00:00.0000000', 2, 7, 2),
    (25, '2021-08-26T17:30:00.0000000', 1, 10, 4),
    (24, '2021-08-27T20:00:00.0000000', 1, 10, 4),
    (6, '2021-08-25T17:30:00.0000000', 2, 10, 2),
    (14, '2021-08-25T22:00:00.0000000', 2, 7, 3),
    (2, '2021-08-25T20:00:00.0000000', 2, 5, 3),
    (16, '2021-08-26T22:00:00.0000000', 1, 1, 4),
    (18, '2021-08-27T22:00:00.0000000', 1, 1, 6),
    (5, '2021-08-26T20:00:00.0000000', 2, 7, 1),
    (4, '2021-08-27T20:00:00.0000000', 2, 3, 1),
    (23, '2021-08-27T14:30:00.0000000', 1, 8, 6),
    (22, '2021-08-27T17:30:00.0000000', 1, 8, 6),
    (20, '2021-08-27T17:30:00.0000000', 1, 8, 7),
    (26, '2021-08-26T22:00:00.0000000', 1, 2, 6),
    (17, '2021-08-25T20:00:00.0000000', 1, 2, 6),
    (15, '2021-08-25T17:30:00.0000000', 1, 2, 4),
    (1, '2021-08-25T17:30:00.0000000', 2, 2, 1),
    (10, '2021-08-27T17:30:00.0000000', 2, 6, 3),
    (9, '2021-08-26T14:30:00.0000000', 2, 6, 2),
    (7, '2021-08-25T14:30:00.0000000', 2, 6, 2),
    (27, '2021-08-26T14:30:00.0000000', 1, 4, 4),
    (21, '2021-08-25T14:30:00.0000000', 1, 4, 7),
    (12, '2021-08-27T14:30:00.0000000', 2, 4, 3),
    (11, '2021-08-26T17:30:00.0000000', 2, 4, 3),
    (3, '2021-08-26T22:00:00.0000000', 2, 3, 2),
    (19, '2021-08-25T22:00:00.0000000', 1, 9, 7);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Date', N'ImplantationId', N'MovieId', N'RoomId') AND [object_id] = OBJECT_ID(N'[Shows]'))
        SET IDENTITY_INSERT [Shows] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    CREATE INDEX [IX_Shows_ImplantationId] ON [Shows] ([ImplantationId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    CREATE INDEX [IX_Shows_MovieId] ON [Shows] ([MovieId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    CREATE INDEX [IX_Shows_RoomId] ON [Shows] ([RoomId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    CREATE INDEX [IX_Rooms_ImplantationId] ON [Rooms] ([ImplantationId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    CREATE INDEX [IX_Movies_MovieTypeId] ON [Movies] ([MovieTypeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    CREATE INDEX [IX_Movies_PegiId] ON [Movies] ([PegiId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    CREATE UNIQUE INDEX [IX_Images_MovieId] ON [Images] ([MovieId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    ALTER TABLE [Movies] ADD CONSTRAINT [FK_Movies_MovieTypes_MovieTypeId] FOREIGN KEY ([MovieTypeId]) REFERENCES [MovieTypes] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    ALTER TABLE [Movies] ADD CONSTRAINT [FK_Movies_Pegis_PegiId] FOREIGN KEY ([PegiId]) REFERENCES [Pegis] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    ALTER TABLE [Rooms] ADD CONSTRAINT [FK_Rooms_Implantations_ImplantationId] FOREIGN KEY ([ImplantationId]) REFERENCES [Implantations] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    ALTER TABLE [Shows] ADD CONSTRAINT [FK_Shows_Implantations_ImplantationId] FOREIGN KEY ([ImplantationId]) REFERENCES [Implantations] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    ALTER TABLE [Shows] ADD CONSTRAINT [FK_Shows_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    ALTER TABLE [Shows] ADD CONSTRAINT [FK_Shows_Rooms_RoomId] FOREIGN KEY ([RoomId]) REFERENCES [Rooms] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708094502_model')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210708094502_model', N'3.1.16');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210710154308_PegisUpdated')
BEGIN
    UPDATE [Pegis] SET [IllustrationPath] = N'img/pegi/p3.jpg'
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210710154308_PegisUpdated')
BEGIN
    UPDATE [Pegis] SET [IllustrationPath] = N'img/pegi/p7.jpg'
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210710154308_PegisUpdated')
BEGIN
    UPDATE [Pegis] SET [IllustrationPath] = N'img/pegi/p12.jpg'
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210710154308_PegisUpdated')
BEGIN
    UPDATE [Pegis] SET [IllustrationPath] = N'img/pegi/p16.jpg'
    WHERE [Id] = 4;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210710154308_PegisUpdated')
BEGIN
    UPDATE [Pegis] SET [IllustrationPath] = N'img/pegi/p18.jpg'
    WHERE [Id] = 5;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210710154308_PegisUpdated')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210710154308_PegisUpdated', N'3.1.16');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210711110618_reservation')
BEGIN
    ALTER TABLE [Reservations] ADD [ShowId] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210711110618_reservation')
BEGIN
    CREATE INDEX [IX_Reservations_ShowId] ON [Reservations] ([ShowId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210711110618_reservation')
BEGIN
    ALTER TABLE [Reservations] ADD CONSTRAINT [FK_Reservations_Shows_ShowId] FOREIGN KEY ([ShowId]) REFERENCES [Shows] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210711110618_reservation')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210711110618_reservation', N'3.1.16');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210711113722_pegi-number')
BEGIN
    ALTER TABLE [Pegis] ADD [Number] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210711113722_pegi-number')
BEGIN
    UPDATE [Pegis] SET [Number] = 3
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210711113722_pegi-number')
BEGIN
    UPDATE [Pegis] SET [Number] = 7
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210711113722_pegi-number')
BEGIN
    UPDATE [Pegis] SET [Number] = 12
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210711113722_pegi-number')
BEGIN
    UPDATE [Pegis] SET [Number] = 16
    WHERE [Id] = 4;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210711113722_pegi-number')
BEGIN
    UPDATE [Pegis] SET [Number] = 18
    WHERE [Id] = 5;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210711113722_pegi-number')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210711113722_pegi-number', N'3.1.16');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210714161339_movieDescription')
BEGIN
    ALTER TABLE [Movies] ADD [Description] nvarchar(max) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210714161339_movieDescription')
BEGIN
    ALTER TABLE [Members] ADD [AccessFailedCount] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210714161339_movieDescription')
BEGIN
    ALTER TABLE [Members] ADD [ConcurrencyStamp] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210714161339_movieDescription')
BEGIN
    ALTER TABLE [Members] ADD [EmailConfirmed] bit NOT NULL DEFAULT CAST(0 AS bit);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210714161339_movieDescription')
BEGIN
    ALTER TABLE [Members] ADD [LockoutEnabled] bit NOT NULL DEFAULT CAST(0 AS bit);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210714161339_movieDescription')
BEGIN
    ALTER TABLE [Members] ADD [LockoutEnd] datetimeoffset NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210714161339_movieDescription')
BEGIN
    ALTER TABLE [Members] ADD [NormalizedEmail] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210714161339_movieDescription')
BEGIN
    ALTER TABLE [Members] ADD [NormalizedUserName] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210714161339_movieDescription')
BEGIN
    ALTER TABLE [Members] ADD [PasswordHash] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210714161339_movieDescription')
BEGIN
    ALTER TABLE [Members] ADD [PhoneNumber] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210714161339_movieDescription')
BEGIN
    ALTER TABLE [Members] ADD [PhoneNumberConfirmed] bit NOT NULL DEFAULT CAST(0 AS bit);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210714161339_movieDescription')
BEGIN
    ALTER TABLE [Members] ADD [SecurityStamp] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210714161339_movieDescription')
BEGIN
    ALTER TABLE [Members] ADD [TwoFactorEnabled] bit NOT NULL DEFAULT CAST(0 AS bit);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210714161339_movieDescription')
BEGIN
    ALTER TABLE [Members] ADD [UserName] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210714161339_movieDescription')
BEGIN
    UPDATE [Movies] SET [Description] = N'En 1973, lors d''une perquisition à la ferme de Thomas Hewitt, ancien employé de l''abattoir de Travis County, au Texas, la police découvrait les restes de 33 êtres humains. Cette effroyable trouvaille mit en émoi la population locale. Arborant les grotesques masques de chair de ses victimes et brandissant une tronçonneuse, le tueur fut macabrement surnommé Leatherface. Les autorités locales abattirent un homme portant un masque de cuir, mettant ainsi fin à l''affaire, mais au cours des années suivantes, plusieurs personnes accusèrent la police d''avoir bâclé l''enquête et d''avoir tué un innocent en toute connaissance de cause. Pour la première fois, la seule victime ayant survécu au massacre brise le silence et raconte ce qui est vraiment arrivé cette nuit - là, sur une route déserte du Texas, à cinq personnes qui sans le savoir, roulaient vers leur pire cauchemar.'
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210714161339_movieDescription')
BEGIN
    UPDATE [Movies] SET [Description] = N'1985. Le jeune Marty McFly mène une existence anonyme auprès de sa petite amie Jennifer, seulement troublée par sa famille en crise et un proviseur qui serait ravi de l''expulser du lycée. Ami de l''excentrique professeur Emmett Brown, il l''accompagne un soir tester sa nouvelle expérience : le voyage dans le temps via une DeLorean modifiée. La démonstration tourne mal : des trafiquants d''armes débarquent et assassinent le scientifique. Marty se réfugie dans la voiture et se retrouve transporté en 1955. Là, il empêche malgré lui la rencontre de ses parents, et doit tout faire pour les remettre ensemble, sous peine de ne pouvoir exister.'
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210714161339_movieDescription')
BEGIN
    UPDATE [Movies] SET [Description] = N'Rand Peltzer offre à son fils Billy un étrange animal : un mogwai. Son ancien propriétaire l''a bien mis en garde : il ne faut pas l''exposer à la lumiere, lui éviter tout contact avec l''eau, et surtout, surtout ne jamais le nourrir apres minuit... Sinon...'
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210714161339_movieDescription')
BEGIN
    UPDATE [Movies] SET [Description] = N'Dans les eaux tropicales de la Grande Barrière de corail, un poisson-clown du nom de Marin mène une existence paisible avec son fils unique, Nemo. Redoutant l''océan et ses risques imprévisibles, il fait de son mieux pour protéger son fils. Comme tous les petits poissons de son âge, celui-ci rêve pourtant d''explorer les mystérieux récifs. Lorsque Nemo disparaît, Marin devient malgré lui le héros d''une quête unique et palpitante. Le pauvre papa ignore que son rejeton à écailles a été emmené jusque dans l''aquarium d''un dentiste. Marin ne s''engagera pas seul dans l''aventure : la jolie Dory, un poisson-chirurgien bleu à la mémoire défaillante et au grand coeur, va se révéler d''une aide précieuse.Les deux poissons vont affronter d''innombrables dangers, mais l''optimisme de Dory va pousser Marin à surmonter toutes ses peurs.'
    WHERE [Id] = 4;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210714161339_movieDescription')
BEGIN
    UPDATE [Movies] SET [Description] = N'Ne pas réveiller le chat qui dort... C''est ce que le milliardaire John Hammond aurait dû se rappeler avant de se lancer dans le clonage de dinosaures. C''est à partir d''une goutte de sang absorbée par un moustique fossilisé que John Hammond et son équipe ont réussi à faire renaître une dizaine d''espèces de dinosaures. Il s''apprête maintenant avec la complicité du docteur Alan Grant, paléontologue de renom, et de son amie Ellie, à ouvrir le plus grand parc à thème du monde. Mais c''était sans compter la cupidité et la malveillance de l''informaticien Dennis Nedry, et éventuellement des dinosaures, seuls maîtres sur l''île...'
    WHERE [Id] = 5;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210714161339_movieDescription')
BEGIN
    UPDATE [Movies] SET [Description] = N'L''histoire se déroule au début d''une ère glaciaire. Un trio peu ordinaire, composé d''un mammouth, Manny, d''un paresseux, Sid, et d''un tigre à dents de sabre, Diego, se retrouve avec un bébé humain. Ils décident de le rendre à ses parents mais l''enfant est celui du chef d''une tribu préhistorique chasseuse de tigres. Diego est chargé par son clan d''attirer Manny et Sid dans un piège pour récupérer l''enfant.'
    WHERE [Id] = 6;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210714161339_movieDescription')
BEGIN
    UPDATE [Movies] SET [Description] = N'Jeune as du pilotage et tête brûlée d''une école réservée à l''élite de l''aéronavale US (Top Gun), Pete Mitchell, dit Maverick, tombe sous le charme d''une instructrice alors qu''il est en compétition pour le titre du meilleur pilote...'
    WHERE [Id] = 7;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210714161339_movieDescription')
BEGIN
    UPDATE [Movies] SET [Description] = N'Malgré sa paralysie, Jake Sully, un ancien marine immobilisé dans un fauteuil roulant, est resté un combattant au plus profond de son être. Il est recruté pour se rendre à des années-lumière de la Terre, sur Pandora, où de puissants groupes industriels exploitent un minerai rarissime destiné à résoudre la crise énergétique sur Terre. Parce que l''atmosphère de Pandora est toxique pour les humains, ceux-ci ont créé le Programme Avatar, qui permet à des pilotes humains de lier leur esprit à un avatar, un corps biologique commandé à distance, capable de survivre dans cette atmosphère létale. Ces avatars sont des hybrides créés génétiquement en croisant l''ADN humain avec celui des Na''vi, les autochtones de Pandora. Sous sa forme d''avatar, Jake peut de nouveau marcher. On lui confie une mission d''infiltration auprès des Na''vi, devenus un obstacle trop conséquent à l''exploitation du précieux minerai.Mais tout va changer lorsque Neytiri, une très belle Na''vi, sauve la vie de Jake...'
    WHERE [Id] = 8;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210714161339_movieDescription')
BEGIN
    UPDATE [Movies] SET [Description] = N'Le vaisseau commercial Nostromo et son équipage, sept hommes et femmes, rentrent sur Terre avec une importante cargaison de minerai. Mais lors d''un arrêt forcé sur une planète déserte, l''officier Kane se fait agresser par une forme de vie inconnue, une arachnide qui étouffe son visage. Après que le docteur de bord lui retire le spécimen, l''équipage retrouve le sourire et dîne ensemble. Jusqu''à ce que Kane, pris de convulsions, voit son abdomen perforé par un corps étranger vivant, qui s''échappe dans les couloirs du vaisseau...'
    WHERE [Id] = 9;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210714161339_movieDescription')
BEGIN
    UPDATE [Movies] SET [Description] = N'Grâce a un billet magique, Danny Madigan, un enfant de onze ans, peut vivre les aventures de son policier préferé, Slater, croisé des temps modernes. Ensemble ils affrontent force danger et triomphent toujours. Mais les choses se compliquent lorsque des personnes mal intentionnées s''emparent du billet magique et gagnent New York, ou le crime paie encore plus qu''au cinéma.'
    WHERE [Id] = 10;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210714161339_movieDescription')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210714161339_movieDescription', N'3.1.16');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726111655_MemberRemovedFromContext')
BEGIN
    DROP TABLE [Members];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726111655_MemberRemovedFromContext')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726111655_MemberRemovedFromContext')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726111655_MemberRemovedFromContext')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726111655_MemberRemovedFromContext')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726111655_MemberRemovedFromContext')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726111655_MemberRemovedFromContext')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726111655_MemberRemovedFromContext')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726111655_MemberRemovedFromContext')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726111655_MemberRemovedFromContext')
BEGIN
    CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726111655_MemberRemovedFromContext')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726111655_MemberRemovedFromContext')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726111655_MemberRemovedFromContext')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726111655_MemberRemovedFromContext')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726111655_MemberRemovedFromContext')
BEGIN
    CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726111655_MemberRemovedFromContext')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210726111655_MemberRemovedFromContext', N'3.1.16');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726111725_MemberIdentity')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Birthdate] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726111725_MemberIdentity')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Name] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726111725_MemberIdentity')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Surname] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726111725_MemberIdentity')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Discriminator] nvarchar(max) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210726111725_MemberIdentity')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210726111725_MemberIdentity', N'3.1.16');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807092953_ShowHoursUpdate')
BEGIN
    ALTER TABLE [Shows] ADD [Heure] time NOT NULL DEFAULT '00:00:00';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807092953_ShowHoursUpdate')
BEGIN
    UPDATE [Shows] SET [Date] = '2021-08-25T00:00:00.0000000', [Heure] = '17:30:00'
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807092953_ShowHoursUpdate')
BEGIN
    UPDATE [Shows] SET [Date] = '2021-08-25T00:00:00.0000000', [Heure] = '20:00:00'
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807092953_ShowHoursUpdate')
BEGIN
    UPDATE [Shows] SET [Date] = '2021-08-26T00:00:00.0000000', [Heure] = '22:00:00'
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807092953_ShowHoursUpdate')
BEGIN
    UPDATE [Shows] SET [Date] = '2021-08-27T00:00:00.0000000', [Heure] = '20:00:00'
    WHERE [Id] = 4;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807092953_ShowHoursUpdate')
BEGIN
    UPDATE [Shows] SET [Date] = '2021-08-26T00:00:00.0000000', [Heure] = '20:00:00'
    WHERE [Id] = 5;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807092953_ShowHoursUpdate')
BEGIN
    UPDATE [Shows] SET [Date] = '2021-08-25T00:00:00.0000000', [Heure] = '17:30:00'
    WHERE [Id] = 6;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807092953_ShowHoursUpdate')
BEGIN
    UPDATE [Shows] SET [Date] = '2021-08-25T00:00:00.0000000', [Heure] = '14:30:00'
    WHERE [Id] = 7;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807092953_ShowHoursUpdate')
BEGIN
    UPDATE [Shows] SET [Date] = '2021-08-26T00:00:00.0000000', [Heure] = '14:30:00'
    WHERE [Id] = 9;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807092953_ShowHoursUpdate')
BEGIN
    UPDATE [Shows] SET [Date] = '2021-08-27T00:00:00.0000000', [Heure] = '17:30:00'
    WHERE [Id] = 10;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807092953_ShowHoursUpdate')
BEGIN
    UPDATE [Shows] SET [Date] = '2021-08-26T00:00:00.0000000', [Heure] = '17:30:00'
    WHERE [Id] = 11;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807092953_ShowHoursUpdate')
BEGIN
    UPDATE [Shows] SET [Date] = '2021-08-27T00:00:00.0000000', [Heure] = '14:30:00'
    WHERE [Id] = 12;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807092953_ShowHoursUpdate')
BEGIN
    UPDATE [Shows] SET [Date] = '2021-08-27T00:00:00.0000000', [Heure] = '20:00:00'
    WHERE [Id] = 13;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807092953_ShowHoursUpdate')
BEGIN
    UPDATE [Shows] SET [Date] = '2021-08-25T00:00:00.0000000', [Heure] = '22:00:00'
    WHERE [Id] = 14;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807092953_ShowHoursUpdate')
BEGIN
    UPDATE [Shows] SET [Date] = '2021-08-25T00:00:00.0000000', [Heure] = '17:30:00'
    WHERE [Id] = 15;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807092953_ShowHoursUpdate')
BEGIN
    UPDATE [Shows] SET [Date] = '2021-08-26T00:00:00.0000000', [Heure] = '22:00:00'
    WHERE [Id] = 16;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807092953_ShowHoursUpdate')
BEGIN
    UPDATE [Shows] SET [Date] = '2021-08-25T00:00:00.0000000', [Heure] = '20:00:00'
    WHERE [Id] = 17;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807092953_ShowHoursUpdate')
BEGIN
    UPDATE [Shows] SET [Date] = '2021-08-27T00:00:00.0000000', [Heure] = '22:00:00'
    WHERE [Id] = 18;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807092953_ShowHoursUpdate')
BEGIN
    UPDATE [Shows] SET [Date] = '2021-08-25T00:00:00.0000000', [Heure] = '22:00:00'
    WHERE [Id] = 19;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807092953_ShowHoursUpdate')
BEGIN
    UPDATE [Shows] SET [Date] = '2021-08-27T00:00:00.0000000', [Heure] = '17:30:00'
    WHERE [Id] = 20;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807092953_ShowHoursUpdate')
BEGIN
    UPDATE [Shows] SET [Date] = '2021-08-25T00:00:00.0000000', [Heure] = '14:30:00'
    WHERE [Id] = 21;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807092953_ShowHoursUpdate')
BEGIN
    UPDATE [Shows] SET [Date] = '2021-08-27T00:00:00.0000000', [Heure] = '17:30:00'
    WHERE [Id] = 22;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807092953_ShowHoursUpdate')
BEGIN
    UPDATE [Shows] SET [Date] = '2021-08-27T00:00:00.0000000', [Heure] = '14:30:00'
    WHERE [Id] = 23;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807092953_ShowHoursUpdate')
BEGIN
    UPDATE [Shows] SET [Date] = '2021-08-27T00:00:00.0000000', [Heure] = '20:00:00'
    WHERE [Id] = 24;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807092953_ShowHoursUpdate')
BEGIN
    UPDATE [Shows] SET [Date] = '2021-08-26T00:00:00.0000000', [Heure] = '17:30:00'
    WHERE [Id] = 25;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807092953_ShowHoursUpdate')
BEGIN
    UPDATE [Shows] SET [Date] = '2021-08-26T00:00:00.0000000', [Heure] = '22:00:00'
    WHERE [Id] = 26;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807092953_ShowHoursUpdate')
BEGIN
    UPDATE [Shows] SET [Date] = '2021-08-26T00:00:00.0000000', [Heure] = '14:30:00'
    WHERE [Id] = 27;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807092953_ShowHoursUpdate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210807092953_ShowHoursUpdate', N'3.1.16');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807142243_Spectators')
BEGIN
    ALTER TABLE [Reservations] ADD [MemberId] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807142243_Spectators')
BEGIN
    ALTER TABLE [Reservations] ADD [MemberId1] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807142243_Spectators')
BEGIN
    CREATE TABLE [Spectator] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Surname] nvarchar(max) NOT NULL,
        [Age] int NOT NULL,
        [ReservationId] int NULL,
        CONSTRAINT [PK_Spectator] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Spectator_Reservations_ReservationId] FOREIGN KEY ([ReservationId]) REFERENCES [Reservations] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807142243_Spectators')
BEGIN
    CREATE INDEX [IX_Reservations_MemberId1] ON [Reservations] ([MemberId1]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807142243_Spectators')
BEGIN
    CREATE INDEX [IX_Spectator_ReservationId] ON [Spectator] ([ReservationId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807142243_Spectators')
BEGIN
    ALTER TABLE [Reservations] ADD CONSTRAINT [FK_Reservations_AspNetUsers_MemberId1] FOREIGN KEY ([MemberId1]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807142243_Spectators')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210807142243_Spectators', N'3.1.16');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807152459_SpectatorsDbSet')
BEGIN
    ALTER TABLE [Spectator] DROP CONSTRAINT [FK_Spectator_Reservations_ReservationId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807152459_SpectatorsDbSet')
BEGIN
    ALTER TABLE [Spectator] DROP CONSTRAINT [PK_Spectator];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807152459_SpectatorsDbSet')
BEGIN
    EXEC sp_rename N'[Spectator]', N'Spectators';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807152459_SpectatorsDbSet')
BEGIN
    EXEC sp_rename N'[Spectators].[IX_Spectator_ReservationId]', N'IX_Spectators_ReservationId', N'INDEX';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807152459_SpectatorsDbSet')
BEGIN
    ALTER TABLE [Spectators] ADD CONSTRAINT [PK_Spectators] PRIMARY KEY ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807152459_SpectatorsDbSet')
BEGIN
    ALTER TABLE [Spectators] ADD CONSTRAINT [FK_Spectators_Reservations_ReservationId] FOREIGN KEY ([ReservationId]) REFERENCES [Reservations] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807152459_SpectatorsDbSet')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210807152459_SpectatorsDbSet', N'3.1.16');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807153331_ReservationUpdate')
BEGIN
    ALTER TABLE [Reservations] DROP CONSTRAINT [FK_Reservations_AspNetUsers_MemberId1];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807153331_ReservationUpdate')
BEGIN
    DROP INDEX [IX_Reservations_MemberId1] ON [Reservations];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807153331_ReservationUpdate')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Reservations]') AND [c].[name] = N'MemberId1');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Reservations] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Reservations] DROP COLUMN [MemberId1];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807153331_ReservationUpdate')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Reservations]') AND [c].[name] = N'MemberId');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Reservations] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Reservations] ALTER COLUMN [MemberId] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807153331_ReservationUpdate')
BEGIN
    CREATE INDEX [IX_Reservations_MemberId] ON [Reservations] ([MemberId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807153331_ReservationUpdate')
BEGIN
    ALTER TABLE [Reservations] ADD CONSTRAINT [FK_Reservations_AspNetUsers_MemberId] FOREIGN KEY ([MemberId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807153331_ReservationUpdate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210807153331_ReservationUpdate', N'3.1.16');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807221316_RolesAndSpectatorUpdate')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Spectators]') AND [c].[name] = N'Age');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Spectators] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Spectators] DROP COLUMN [Age];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807221316_RolesAndSpectatorUpdate')
BEGIN
    ALTER TABLE [Spectators] ADD [BirthDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210807221316_RolesAndSpectatorUpdate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210807221316_RolesAndSpectatorUpdate', N'3.1.16');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210808151942_ReservationDeleteOnCascade')
BEGIN
    ALTER TABLE [Reservations] DROP CONSTRAINT [FK_Reservations_Shows_ShowId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210808151942_ReservationDeleteOnCascade')
BEGIN
    ALTER TABLE [Spectators] DROP CONSTRAINT [FK_Spectators_Reservations_ReservationId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210808151942_ReservationDeleteOnCascade')
BEGIN
    ALTER TABLE [Reservations] ADD CONSTRAINT [FK_Reservations_Shows_ShowId] FOREIGN KEY ([ShowId]) REFERENCES [Shows] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210808151942_ReservationDeleteOnCascade')
BEGIN
    ALTER TABLE [Spectators] ADD CONSTRAINT [FK_Spectators_Reservations_ReservationId] FOREIGN KEY ([ReservationId]) REFERENCES [Reservations] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210808151942_ReservationDeleteOnCascade')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210808151942_ReservationDeleteOnCascade', N'3.1.16');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210808152344_RoomOnDeleteCascade')
BEGIN
    ALTER TABLE [Shows] DROP CONSTRAINT [FK_Shows_Rooms_RoomId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210808152344_RoomOnDeleteCascade')
BEGIN
    ALTER TABLE [Shows] ADD CONSTRAINT [FK_Shows_Rooms_RoomId] FOREIGN KEY ([RoomId]) REFERENCES [Rooms] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210808152344_RoomOnDeleteCascade')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210808152344_RoomOnDeleteCascade', N'3.1.16');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210808201256_ProductionEnv')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Implantations]') AND [c].[name] = N'Name');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Implantations] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [Implantations] ALTER COLUMN [Name] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210808201256_ProductionEnv')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210808201256_ProductionEnv', N'3.1.16');
END;

GO

