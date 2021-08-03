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

CREATE TABLE [Companies] (
    [Id] uniqueidentifier NOT NULL,
    [Name] varchar(100) NOT NULL,
    [CNPJ] varchar(14) NOT NULL,
    CONSTRAINT [PK_Companies] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Passengers] (
    [Id] uniqueidentifier NOT NULL,
    [FirstName] varchar(50) NOT NULL,
    [LastName] varchar(50) NOT NULL,
    [TypePerson] int NOT NULL,
    [Passport] varchar(8) NOT NULL,
    [Document] varchar(14) NOT NULL,
    CONSTRAINT [PK_Passengers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Airplanes] (
    [Id] uniqueidentifier NOT NULL,
    [AirplaneModel] varchar(50) NOT NULL,
    [SerialNumber] varchar(100) NOT NULL,
    [PassengerNumber] int NOT NULL,
    [Capacity] int NOT NULL,
    [CompanyId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Airplanes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Airplanes_Companies_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [Companies] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Addresses] (
    [Id] uniqueidentifier NOT NULL,
    [PassengerId] uniqueidentifier NOT NULL,
    [Street] varchar(50) NOT NULL,
    [District] varchar(50) NOT NULL,
    [City] varchar(50) NOT NULL,
    [Country] varchar(100) NULL,
    [State] varchar(50) NOT NULL,
    [UF] varchar(2) NOT NULL,
    [Number] int NOT NULL,
    [PostalCode] varchar(9) NOT NULL,
    [Complement] varchar(100) NULL,
    CONSTRAINT [PK_Addresses] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Addresses_Passengers_PassengerId] FOREIGN KEY ([PassengerId]) REFERENCES [Passengers] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Flights] (
    [Id] uniqueidentifier NOT NULL,
    [Origin] varchar(42) NOT NULL,
    [Destiny] varchar(42) NOT NULL,
    [DepartureDate] datetime2 NOT NULL,
    [ArrivalDate] datetime2 NOT NULL,
    [AirPlaneId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Flights] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Flights_Airplanes_AirPlaneId] FOREIGN KEY ([AirPlaneId]) REFERENCES [Airplanes] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Seats] (
    [Id] uniqueidentifier NOT NULL,
    [Number] int NOT NULL,
    [TypeClass] varchar(50) NOT NULL,
    [AirplaneId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Seats] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Seats_Airplanes_AirplaneId] FOREIGN KEY ([AirplaneId]) REFERENCES [Airplanes] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Schedules] (
    [Id] uniqueidentifier NOT NULL,
    [HandBaggage] int NOT NULL,
    [CheckedBaggage] int NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    [FlightId] uniqueidentifier NOT NULL,
    [SeatId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Schedules] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Schedules_Flights_FlightId] FOREIGN KEY ([FlightId]) REFERENCES [Flights] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Schedules_Seats_SeatId] FOREIGN KEY ([SeatId]) REFERENCES [Seats] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [SchedulingPassengers] (
    [Id] uniqueidentifier NOT NULL,
    [PassengerId] uniqueidentifier NOT NULL,
    [SchedulingId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_SchedulingPassengers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_SchedulingPassengers_Passengers_PassengerId] FOREIGN KEY ([PassengerId]) REFERENCES [Passengers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_SchedulingPassengers_Schedules_SchedulingId] FOREIGN KEY ([SchedulingId]) REFERENCES [Schedules] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_Addresses_PassengerId] ON [Addresses] ([PassengerId]);
GO

CREATE INDEX [IX_Airplanes_CompanyId] ON [Airplanes] ([CompanyId]);
GO

CREATE INDEX [IX_Flights_AirPlaneId] ON [Flights] ([AirPlaneId]);
GO

CREATE INDEX [IX_Schedules_FlightId] ON [Schedules] ([FlightId]);
GO

CREATE INDEX [IX_Schedules_SeatId] ON [Schedules] ([SeatId]);
GO

CREATE INDEX [IX_SchedulingPassengers_PassengerId] ON [SchedulingPassengers] ([PassengerId]);
GO

CREATE INDEX [IX_SchedulingPassengers_SchedulingId] ON [SchedulingPassengers] ([SchedulingId]);
GO

CREATE INDEX [IX_Seats_AirplaneId] ON [Seats] ([AirplaneId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210725203339_AddInitial', N'5.0.8');
GO

COMMIT;
GO

