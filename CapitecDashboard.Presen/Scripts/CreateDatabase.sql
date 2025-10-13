-- Create Database
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'CapitecDashboardDb')
BEGIN
    CREATE DATABASE CapitecDashboardDb;
END
GO

USE CapitecDashboardDb;
GO

-- Create Customers table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Customers](
        [Id] [uniqueidentifier] NOT NULL,
        [Name] [nvarchar](max) NOT NULL,
        [Email] [nvarchar](max) NULL,
        [Phone] [nvarchar](max) NULL,
        [Address] [nvarchar](max) NULL,
        [CreatedAt] [datetime2](7) NOT NULL,
        CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([Id] ASC)
    );
END
GO

-- Create Invoices table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Invoices]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Invoices](
        [Id] [uniqueidentifier] NOT NULL,
        [CustomerId] [uniqueidentifier] NOT NULL,
        [InvoiceNumber] [nvarchar](max) NOT NULL,
        [IssueDate] [datetime2](7) NOT NULL,
        [DueDate] [datetime2](7) NOT NULL,
        [Status] [int] NOT NULL,
        [SubTotal] [decimal](18,2) NOT NULL,
        [TaxAmount] [decimal](18,2) NOT NULL,
        [Total] [decimal](18,2) NOT NULL,
        [AmountPaid] [decimal](18,2) NOT NULL,
        [Notes] [nvarchar](max) NULL,
        [CreatedAt] [datetime2](7) NOT NULL,
        [UpdatedAt] [datetime2](7) NOT NULL,
        CONSTRAINT [PK_Invoices] PRIMARY KEY CLUSTERED ([Id] ASC),
        CONSTRAINT [FK_Invoices_Customers_CustomerId] FOREIGN KEY([CustomerId]) REFERENCES [dbo].[Customers] ([Id]) ON DELETE CASCADE
    );
END
GO

-- Create InvoiceItems table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceItems]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[InvoiceItems](
        [Id] [uniqueidentifier] NOT NULL,
        [InvoiceId] [uniqueidentifier] NOT NULL,
        [Description] [nvarchar](max) NOT NULL,
        [Quantity] [decimal](18,2) NOT NULL,
        [UnitPrice] [decimal](18,2) NOT NULL,
        [LineTotal] [decimal](18,2) NOT NULL,
        CONSTRAINT [PK_InvoiceItems] PRIMARY KEY CLUSTERED ([Id] ASC),
        CONSTRAINT [FK_InvoiceItems_Invoices_InvoiceId] FOREIGN KEY([InvoiceId]) REFERENCES [dbo].[Invoices] ([Id]) ON DELETE CASCADE
    );
END
GO

-- Create Payments table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Payments]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Payments](
        [Id] [uniqueidentifier] NOT NULL,
        [InvoiceId] [uniqueidentifier] NOT NULL,
        [PaidAt] [datetime2](7) NOT NULL,
        [Amount] [decimal](18,2) NOT NULL,
        [Method] [nvarchar](max) NULL,
        [Reference] [nvarchar](max) NULL,
        CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED ([Id] ASC),
        CONSTRAINT [FK_Payments_Invoices_InvoiceId] FOREIGN KEY([InvoiceId]) REFERENCES [dbo].[Invoices] ([Id]) ON DELETE CASCADE
    );
END
GO

-- Create indexes
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Invoices]') AND name = N'IX_Invoices_CustomerId')
BEGIN
    CREATE NONCLUSTERED INDEX [IX_Invoices_CustomerId] ON [dbo].[Invoices]([CustomerId] ASC);
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Invoices]') AND name = N'IX_Invoices_DueDate')
BEGIN
    CREATE NONCLUSTERED INDEX [IX_Invoices_DueDate] ON [dbo].[Invoices]([DueDate] ASC);
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Invoices]') AND name = N'IX_Invoices_Status')
BEGIN
    CREATE NONCLUSTERED INDEX [IX_Invoices_Status] ON [dbo].[Invoices]([Status] ASC);
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Invoices]') AND name = N'IX_Invoices_InvoiceNumber')
BEGIN
    CREATE UNIQUE NONCLUSTERED INDEX [IX_Invoices_InvoiceNumber] ON [dbo].[Invoices]([InvoiceNumber] ASC);
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceItems]') AND name = N'IX_InvoiceItems_InvoiceId')
BEGIN
    CREATE NONCLUSTERED INDEX [IX_InvoiceItems_InvoiceId] ON [dbo].[InvoiceItems]([InvoiceId] ASC);
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Payments]') AND name = N'IX_Payments_InvoiceId')
BEGIN
    CREATE NONCLUSTERED INDEX [IX_Payments_InvoiceId] ON [dbo].[Payments]([InvoiceId] ASC);
END
GO

