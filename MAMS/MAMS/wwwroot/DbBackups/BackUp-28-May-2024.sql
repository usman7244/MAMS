USE [MAMS]
GO
/****** Object:  Table [dbo].[AccountMgt.CashHistory]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountMgt.CashHistory](
	[UID] [int] IDENTITY(1,1) NOT NULL,
	[Details] [nvarchar](max) NULL,
	[CashProfit] [nvarchar](250) NULL,
	[CashLost] [nvarchar](250) NULL,
	[TotalCash] [int] NULL,
	[CreatedDate] [datetimeoffset](5) NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetimeoffset](5) NULL,
	[BranchId] [uniqueidentifier] NOT NULL,
	[DeletedDate] [uniqueidentifier] NULL,
 CONSTRAINT [PK_CashHistory] PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CashMgt.Credit]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CashMgt.Credit](
	[UID] [int] IDENTITY(1,1) NOT NULL,
	[TotalCash] [int] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreatedDate] [datetimeoffset](5) NULL,
	[Fk_Customer] [uniqueidentifier] NULL,
	[Status] [nvarchar](50) NULL,
	[Detail] [nvarchar](max) NULL,
	[DeletedDate] [datetimeoffset](5) NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetimeoffset](5) NULL,
	[BranchId] [uniqueidentifier] NULL,
	[CustomerType] [nvarchar](50) NULL,
	[DiffCash] [int] NULL,
 CONSTRAINT [PK_CashMgt.Credit] PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CashMgt.Deposit]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CashMgt.Deposit](
	[UID] [int] IDENTITY(1,1) NOT NULL,
	[TotalCash] [int] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreatedDate] [datetimeoffset](5) NULL,
	[Fk_Customer] [uniqueidentifier] NULL,
	[Status] [nvarchar](50) NULL,
	[Detail] [nvarchar](max) NULL,
	[DeletedDate] [datetimeoffset](5) NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetimeoffset](5) NULL,
	[BranchId] [uniqueidentifier] NULL,
	[CustomerType] [nvarchar](50) NULL,
	[DiffCash] [int] NULL,
 CONSTRAINT [PK_CashMgt.Deposit] PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerMgt.CustomerInfo]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerMgt.CustomerInfo](
	[UID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Phone] [nvarchar](50) NULL,
	[Email] [nvarchar](max) NULL,
	[CNIC] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[CusType] [nvarchar](50) NULL,
	[ComShopName] [nvarchar](50) NULL,
	[ComAddress] [nvarchar](max) NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetimeoffset](5) NOT NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetimeoffset](5) NULL,
	[BranchId] [uniqueidentifier] NOT NULL,
	[DeletedDate] [datetimeoffset](5) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerMgt.FarmerAccount]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerMgt.FarmerAccount](
	[UID] [uniqueidentifier] NOT NULL,
	[Fk_CusID] [uniqueidentifier] NULL,
	[FK_CropTypeID] [int] NULL,
	[WeightInMaun] [nvarchar](100) NULL,
	[WeightInKG] [nvarchar](100) NULL,
	[PricePerMaun] [nvarchar](100) NULL,
	[Expenses] [nvarchar](100) NULL,
	[CommissionAmmount] [nvarchar](100) NULL,
	[CommissionPercent] [nvarchar](100) NULL,
	[TotalAmount] [nvarchar](100) NULL,
	[AmountStatus] [nvarchar](100) NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetimeoffset](5) NOT NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetimeoffset](5) NULL,
	[BranchId] [uniqueidentifier] NOT NULL,
	[DeletedDate] [datetimeoffset](5) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StockMgt.CropAndBag]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockMgt.CropAndBag](
	[UID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetimeoffset](5) NOT NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetimeoffset](5) NULL,
	[BranchId] [uniqueidentifier] NOT NULL,
	[DeletedDate] [datetimeoffset](5) NULL,
	[Type] [varchar](50) NULL,
 CONSTRAINT [PK_tblCrop] PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StockMgt.Expense]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockMgt.Expense](
	[UID] [int] IDENTITY(1,1) NOT NULL,
	[Fk_Purchase] [int] NULL,
	[ExpDescription] [nvarchar](max) NULL,
	[Amount] [int] NULL,
	[Type] [nvarchar](50) NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetimeoffset](5) NOT NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetimeoffset](5) NULL,
	[BranchId] [uniqueidentifier] NOT NULL,
	[DeletedDate] [datetimeoffset](5) NULL,
	[Fk_Sale] [int] NULL,
	[IsOld] [bit] NULL,
 CONSTRAINT [PK_tblExpense] PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StockMgt.Purchase]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockMgt.Purchase](
	[UID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerType] [nvarchar](50) NULL,
	[Fk_CustomerId] [uniqueidentifier] NULL,
	[Fk_Crop] [int] NULL,
	[WeightInMaun] [int] NULL,
	[WeightInkg] [decimal](18, 4) NULL,
	[TotalCropWeight] [decimal](18, 4) NULL,
	[PriceInMaun] [int] NULL,
	[PriceInKg] [decimal](18, 4) NULL,
	[TotalCropPrice] [int] NULL,
	[TotalExp] [int] NULL,
	[TotalAmountwithExp] [int] NULL,
	[FK_BagType] [int] NULL,
	[BagWeight] [int] NULL,
	[BagTotal] [int] NULL,
	[Status] [nvarchar](50) NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetimeoffset](5) NOT NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetimeoffset](5) NULL,
	[BranchId] [uniqueidentifier] NOT NULL,
	[DeletedDate] [datetimeoffset](5) NULL,
	[DiffCash] [int] NULL,
 CONSTRAINT [PK_tblPurchase] PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StockMgt.Sale]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockMgt.Sale](
	[UID] [int] IDENTITY(1,1) NOT NULL,
	[Fk_Customer] [uniqueidentifier] NULL,
	[Fk_Crop] [int] NULL,
	[WeightInMaun] [int] NULL,
	[WeightInkg] [decimal](18, 4) NULL,
	[TotalCropWeight] [decimal](18, 4) NULL,
	[PriceInMaun] [int] NULL,
	[PriceInKg] [decimal](18, 4) NULL,
	[TotalCropPrice] [int] NULL,
	[TotalExp] [int] NULL,
	[TotalAmountwithExp] [int] NULL,
	[FK_BagType] [int] NULL,
	[BagWeight] [int] NULL,
	[BagTotal] [int] NULL,
	[PurchaseExp] [int] NULL,
	[PurchasePrice] [int] NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetimeoffset](5) NOT NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetimeoffset](5) NULL,
	[BranchId] [uniqueidentifier] NOT NULL,
	[DeletedDate] [datetimeoffset](5) NULL,
	[FK_CustomerType] [nchar](10) NULL,
	[Status] [varchar](50) NULL,
	[DiffCash] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[EditCredit]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditCredit]
    @UID INT,
    @TotalCash DECIMAL(18,2),
    @CreatedBy uniqueidentifier,
    @CreatedDate DATETIME,
    @Fk_Customer uniqueidentifier,
    @Status NVARCHAR(50),
    @Detail NVARCHAR(MAX),
    @DeletedDate DATETIME,
    @ModifiedBy NVARCHAR(50),
    @ModifiedDate DATETIME,
    @BranchId uniqueidentifier
AS
BEGIN
    UPDATE [MAMS].[dbo].[CashMgt.Credit]
    SET 
        [TotalCash] = @TotalCash,
        [CreatedBy] = @CreatedBy,
        [CreatedDate] = @CreatedDate,
        [Fk_Customer] = @Fk_Customer,
        [Status] = @Status,
        [Detail] = @Detail,
        [DeletedDate] = @DeletedDate,
        [ModifiedBy] = @ModifiedBy,
        [ModifiedDate] = @ModifiedDate,
        [BranchId] = @BranchId
    WHERE [UID] = @UID;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetExpenseById]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetExpenseById]
    @UID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT [UID],
           [Fk_Purchase],
           [ExpDescription],
           [Amount],
           [Type],
           [CreatedBy],
           [CreatedDate],
           [ModifiedBy],
           [ModifiedDate],
           [BranchId],
           [DeletedDate],
           [Fk_Sale],
           [IsOld]
    FROM [MAMS].[dbo].[StockMgt.Expense]
    WHERE [UID] = @UID;
END;
GO
/****** Object:  StoredProcedure [dbo].[spAddDeposit]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Create a new stored procedure for adding a deposit
create PROCEDURE [dbo].[spAddDeposit]
            @CustomerType varchar(50),
            @TotalCash decimal(18,2),
            @CreatedBy uniqueidentifier,
            @FKCustomer uniqueidentifier,
            @Status varchar(50),
            @Detail varchar(500),
            @BranchId uniqueidentifier
AS
BEGIN
    DECLARE @CurrentDate DATETIME
    SET @CurrentDate = GETDATE()

    -- Insert into CashMgt.Deposit
    INSERT INTO [MAMS].[dbo].[CashMgt.Deposit] 
    (
        [TotalCash],
        [CreatedBy],
        [CreatedDate],
        [Fk_Customer],
        [Status],
        [Detail],
        [BranchId],
        [CustomerType]
    )
    VALUES 
    (
        @TotalCash,
        @CreatedBy,
        @CurrentDate,
        @FKCustomer,
        @Status,
        @Detail,
        @BranchId,
        @CustomerType
    );

    -- Retrieve the UID of the newly inserted deposit entry
    DECLARE @DepositUID INT
    SET @DepositUID = SCOPE_IDENTITY();

    -- Insert into AccountMgt.CashHistory
    INSERT INTO [MAMS].[dbo].[AccountMgt.CashHistory]
    (
        [Details],
        [CashProfit],
        [CashLost],
        [TotalCash],
        [CreatedDate],
        [CreatedBy],
        [BranchId]
    )
    VALUES 
    (
        'Deposit',
        0,            -- No cash profit in this transaction
        @TotalCash,   -- The total cash deposited is considered as lost
        @TotalCash,
        @CurrentDate,
        @CreatedBy,
        @BranchId
    );

    -- Optionally, you can return the UID of the new deposit entry
    SELECT @DepositUID AS NewDepositUID
END;
GO
/****** Object:  StoredProcedure [dbo].[spCreateBag]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,M Usman>
-- Create date: <9/22/2021>
-- Description:	<GET Customer Info>
-- =============================================

CREATE PROCEDURE [dbo].[spCreateBag] 	
	@BagName nvarchar(50)  ,
	@CreatedBy uniqueidentifier,
	@BranchId uniqueidentifier
AS
BEGIN
INSERT INTO [StockMgt.Bag] (BagName,CreatedBy,CreatedDate,BranchId)
VALUES(@BagName,@CreatedBy,GETUTCDATE(),@BranchId);
END
GO
/****** Object:  StoredProcedure [dbo].[spCreateCredit]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Your Name> 
-- Description:	<Add credit>
-- =============================================

CREATE PROCEDURE [dbo].[spCreateCredit]
    @JsonStringCredit NVARCHAR(MAX)
AS
BEGIN
    BEGIN TRY
        DECLARE @UID INT
        DECLARE @Message NVARCHAR(MAX)
        DECLARE @CurrentTotalCash DECIMAL(18, 2) = ISNULL((SELECT TOP 1 TotalCash FROM [AccountMgt.CashHistory] ORDER BY uid DESC), 0)
        DECLARE @TotalCash DECIMAL(18, 2) = ISNULL((SELECT TOP 1 TotalCash FROM [AccountMgt.CashHistory] ORDER BY uid DESC), 0)
        
        IF (@TotalCash >= @CurrentTotalCash) -- Changed from > to >=
        BEGIN
            -- Insert into CashMgt.Credit
            INSERT INTO [MAMS].[dbo].[CashMgt.Credit] 
            (
                [TotalCash],
                [CreatedBy],
                [CreatedDate],
                [Fk_Customer],
                [Status],
                [Detail],
                [BranchId],
                [CustomerType]
            )
            SELECT 
                TotalCash,
                CreatedBy,
                GETUTCDATE(),
                Fk_Customer,
                [Status],
                Detail,
                BranchId,
                CustomerType
            FROM OPENJSON(@JsonStringCredit)
            WITH (
                TotalCash DECIMAL(18, 2) 'strict $.TotalCash',
                CreatedBy UNIQUEIDENTIFIER 'strict $.CreatedBy',
                Fk_Customer UNIQUEIDENTIFIER 'strict $.FKCustomer',
                [Status] NVARCHAR(50) 'strict $.Status',
                Detail NVARCHAR(500) 'strict $.Detail',
                BranchId UNIQUEIDENTIFIER 'strict $.BranchId',
                CustomerType NVARCHAR(50) 'strict $.CustomerType'
            ) AS Js

            -- Retrieve the UID of the newly inserted credit entry
            SET @UID = SCOPE_IDENTITY()

            -- Insert into AccountMgt.CashHistory
            INSERT INTO [MAMS].[dbo].[AccountMgt.CashHistory]
            (
                [Details],
                [CashProfit],
                [CashLost],
                [TotalCash],
                [CreatedDate],
                [CreatedBy],
                [BranchId]
            )
            SELECT 
                'Credit',
                TotalCash,
                0,
                @CurrentTotalCash + TotalCash,
                GETUTCDATE(),
                CreatedBy,
                BranchId
            FROM OPENJSON(@JsonStringCredit)
            WITH (
                TotalCash DECIMAL(18, 2) 'strict $.TotalCash',
                CreatedBy UNIQUEIDENTIFIER 'strict $.CreatedBy',
                BranchId UNIQUEIDENTIFIER 'strict $.BranchId'
            ) AS RS

            SET @Message = 'Success'
            SELECT @Message AS Message
        END
        ELSE
        BEGIN
            SET @Message = 'Total Cash is less than Credit'
            SELECT @Message AS Message
        END
    END TRY
    BEGIN CATCH
        SET @Message = ERROR_MESSAGE()
        SELECT @Message AS Message
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[spCreateCrop]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,M Usman>
-- Create date: <9/22/2021>
-- Description:	<Insert customer info>
-- =============================================

CREATE PROCEDURE [dbo].[spCreateCrop] 
	-- Add the parameters for the stored procedure here
	@Name nvarchar(max),
	@CreatedBy uniqueidentifier,
	@BranchId uniqueidentifier,
	@Type nvarchar(max)

AS

BEGIN
	INSERT INTO [StockMgt.CropAndBag] (
	[Name],	 
	[CreatedDate],
	[CreatedBy],
	[BranchId],
	[Type]
	)
	VALUES(
	@Name, 
	GETUTCDATE(),
	@CreatedBy,
	@BranchId,
	@Type
	); 

END
GO
/****** Object:  StoredProcedure [dbo].[spCreateCustomer]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,M Usman>
-- Create date: <9/22/2021>
-- Description:	<Insert customer info>
-- =============================================

CREATE PROCEDURE [dbo].[spCreateCustomer] 
	-- Add the parameters for the stored procedure here
	 
	@Name nvarchar(max),
	@Phone nvarchar(max),
	@Email nvarchar(max) = null,
	@CNIC nvarchar(max) = null,
	@City nvarchar(max) = null,
	@Country nvarchar(max) = null,
	@CusType nvarchar(max),
	@ComShopName nvarchar(max) = null,
	@ComAddress nvarchar(max) = null,
	@CreatedBy uniqueidentifier,
	@BranchId uniqueidentifier

AS
BEGIN
	INSERT INTO [CustomerMgt.CustomerInfo] (
	[UID],
	[Name],
	[Phone],
	[Email],
	[CNIC],
	[Country],
	[City],
	[CusType],
	[ComShopName],
	[ComAddress], 
	[CreatedDate],
	[CreatedBy],
	[BranchId])
	VALUES(
	NEWID(),
	@Name,
	@Phone,
	@Email,
	@CNIC,
	@Country,
	@City,	
	@CusType,
	@ComShopName,
	@ComAddress, 
	GETUTCDATE(),
	@CreatedBy,
	@BranchId
	); 

END
GO
/****** Object:  StoredProcedure [dbo].[spCreateDeposit]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Your Name> 
-- Description:	<Add deposit>
-- =============================================

CREATE PROCEDURE [dbo].[spCreateDeposit]
   @JsonStringDeposit NVARCHAR(MAX)
AS
BEGIN
    BEGIN TRY
        DECLARE @UID INT
        DECLARE @Message NVARCHAR(MAX)
        DECLARE @TotalCash DECIMAL(18, 2) = ISNULL((SELECT TOP 1 TotalCash FROM OPENJSON(@JsonStringDeposit) WITH (TotalCash DECIMAL(18, 2) 'strict $.TotalCash')), 0)
        DECLARE @CurrentTotalCash DECIMAL(18, 2) = ISNULL((SELECT TOP 1 TotalCash FROM [AccountMgt.CashHistory] ORDER BY uid DESC), 0)

        PRINT @TotalCash
        PRINT @CurrentTotalCash
        IF (@TotalCash <= @CurrentTotalCash) -- Changed from >= to <=
        BEGIN
            -- Insert into CashMgt.Deposit
            INSERT INTO [MAMS].[dbo].[CashMgt.Deposit] 
            (
                [TotalCash],
                [CreatedBy],
                [CreatedDate],
                [Fk_Customer],
                [Status],
                [Detail],
                [BranchId],
                [CustomerType]
            )
            SELECT 
                TotalCash,
                CreatedBy,
                GETUTCDATE(),
                Fk_Customer,
                [Status],
                Detail,
                BranchId,
                CustomerType
            FROM OPENJSON(@JsonStringDeposit)
            WITH (
                TotalCash DECIMAL(18, 2) 'strict $.TotalCash',
                CreatedBy UNIQUEIDENTIFIER 'strict $.CreatedBy',
                Fk_Customer UNIQUEIDENTIFIER 'strict $.FKCustomer',
                [Status] NVARCHAR(50) 'strict $.Status',
                Detail NVARCHAR(500) 'strict $.Detail',
                BranchId UNIQUEIDENTIFIER 'strict $.BranchId',
                CustomerType NVARCHAR(50) 'strict $.CustomerType'
            ) AS Js

            -- Retrieve the UID of the newly inserted deposit entry
            SET @UID = SCOPE_IDENTITY()
            PRINT @UID

            -- Insert into AccountMgt.CashHistory
            INSERT INTO [MAMS].[dbo].[AccountMgt.CashHistory]
            (
                [Details],
                [CashProfit],
                [CashLost],
                [TotalCash],
                [CreatedDate],
                [CreatedBy],
                [BranchId]
            )
            SELECT 
                'Deposit',
                0,
                TotalCash,
                @CurrentTotalCash + TotalCash, -- Changed to add TotalCash
                GETUTCDATE(),
                CreatedBy,
                BranchId
            FROM OPENJSON(@JsonStringDeposit)
            WITH (
                TotalCash DECIMAL(18, 2) 'strict $.TotalCash',
                CreatedBy UNIQUEIDENTIFIER 'strict $.CreatedBy',
                BranchId UNIQUEIDENTIFIER 'strict $.BranchId'
            ) AS RS

            SET @Message = 'Success'
            SELECT @Message AS Message
        END
        ELSE
        BEGIN
            SET @Message = 'Total Cash is less than Deposit'
            SELECT @Message AS Message
        END
    END TRY
    BEGIN CATCH
        SET @Message = ERROR_MESSAGE()
        SELECT @Message AS Message
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[spCreateExpense]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Your Name> 
-- Description:	<Add expense>
-- =============================================

CREATE PROCEDURE [dbo].[spCreateExpense]
    @JsonStringExpense NVARCHAR(MAX)
AS
BEGIN
    BEGIN TRY
        DECLARE @UID INT
        DECLARE @Message NVARCHAR(MAX)
        DECLARE @Type NVARCHAR(50) = (SELECT Type FROM OPENJSON(@JsonStringExpense) WITH (Type NVARCHAR(50) 'strict $.Type') AS TypeCheck)

        IF (@Type = 'DailyExpense')
        BEGIN
            DECLARE @CurrentTotalCash DECIMAL(18, 2) = ISNULL((SELECT TOP 1 TotalCash FROM [AccountMgt.CashHistory] ORDER BY UID DESC), 0)

            -- Insert into Expense table
            INSERT INTO [MAMS].[dbo].[StockMgt.Expense] 
            (
                      [Fk_Purchase]
					  ,[ExpDescription]
					  ,[Amount]
					  ,[Type]
					  ,[CreatedBy]
					  ,[CreatedDate]
					  ,[ModifiedBy]
					  ,[ModifiedDate]
					  ,[BranchId]
					  ,[DeletedDate]
					  ,[Fk_Sale]
					  ,[IsOld]
            )
            SELECT 
                Fk_Purchase,
                ExpDescription,
                Amount,
                Type,
                CreatedBy,
                GETUTCDATE(),
                NULL,
                NULL,
                BranchId,
                NULL,
                Fk_Sale,
                0
            FROM OPENJSON(@JsonStringExpense)
            WITH (
                Fk_Purchase int 'strict $.Fk_Purchase',
                ExpDescription NVARCHAR(500) 'strict $.ExpDescription',
                Amount DECIMAL(18, 2) 'strict $.Amount',
                Type NVARCHAR(50) 'strict $.Type',
                CreatedBy UNIQUEIDENTIFIER 'strict $.CreatedBy',
                BranchId UNIQUEIDENTIFIER 'strict $.BranchId',
                Fk_Sale int 'strict $.Fk_Sale'
            ) AS Js

            -- Retrieve the UID of the newly inserted expense entry
            SET @UID = SCOPE_IDENTITY()

            -- Insert into AccountMgt.CashHistory
            INSERT INTO [MAMS].[dbo].[AccountMgt.CashHistory]
            (
                [Details],
                [CashProfit],
                [CashLost],
                [TotalCash],
                [CreatedDate],
                [CreatedBy],
                [BranchId]
            )
            SELECT 
                'Expense',
                0,
                Amount,
                @CurrentTotalCash - Amount,
                GETUTCDATE(),
                CreatedBy,
                BranchId
            FROM OPENJSON(@JsonStringExpense)
            WITH (
                Amount DECIMAL(18, 2) 'strict $.Amount',
                CreatedBy UNIQUEIDENTIFIER 'strict $.CreatedBy',
                BranchId UNIQUEIDENTIFIER 'strict $.BranchId'
            ) AS RS

            SET @Message = 'Success'
            SELECT @Message AS Message
        END
        ELSE
        BEGIN
            -- Simple insert into Expense table without additional operations
            INSERT INTO [MAMS].[dbo].[StockMgt.Expense] 
            (
                [Fk_Purchase],
                [ExpDescription],
                [Amount],
                [Type],
                [CreatedBy],
                [CreatedDate],
                [ModifiedBy],
                [ModifiedDate],
                [BranchId],
                [DeletedDate],
                [Fk_Sale],
                [IsOld]
            )
            SELECT 
                Fk_Purchase,
                ExpDescription,
                Amount,
                Type,
                CreatedBy,
                GETUTCDATE(),
                NULL,
                NULL,
                BranchId,
                NULL,
                Fk_Sale,
                0
            FROM OPENJSON(@JsonStringExpense)
            WITH (
                Fk_Purchase int 'strict $.Fk_Purchase',
                ExpDescription NVARCHAR(500) 'strict $.ExpDescription',
                Amount DECIMAL(18, 2) 'strict $.Amount',
                Type NVARCHAR(50) 'strict $.Type',
                CreatedBy UNIQUEIDENTIFIER 'strict $.CreatedBy',
                BranchId UNIQUEIDENTIFIER 'strict $.BranchId',
                Fk_Sale int 'strict $.Fk_Sale'
            ) AS Js

            SET @Message = 'Simple Insert Success'
            SELECT @Message AS Message
        END
    END TRY
    BEGIN CATCH
        SET @Message = ERROR_MESSAGE()
        SELECT @Message AS Message
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[spCreatePurchaseCrop]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<M Usman> 
-- Description:	<Add purchase crop>
-- =============================================

CREATE PROCEDURE [dbo].[spCreatePurchaseCrop]
   @JsonStringPurchase nvarchar(max),
   @JsonStringExpense nvarchar(max)

AS
BEGIN
    BEGIN TRY
        DECLARE @UID int
        DECLARE @Message nvarchar(max)
        DECLARE @TotalAmountwithExp decimal(18, 4) = ISNULL((SELECT TOP 1 TotalAmountwithExp FROM OPENJSON(@JsonStringPurchase) WITH (TotalAmountwithExp decimal(18, 4) 'strict $.TotalAmountwithExp')), 0)
        DECLARE @TotalCash int = ISNULL((SELECT TOP 1 TotalCash FROM [AccountMgt.CashHistory] ORDER BY uid DESC), 0)
        
        PRINT @TotalAmountwithExp
        PRINT @TotalCash

        IF (@TotalCash > @TotalAmountwithExp)
        BEGIN
            INSERT INTO [dbo].[StockMgt.Purchase] (
                [CustomerType],
                [Fk_CustomerId],
                [Fk_Crop],
                [WeightInMaun],
                [WeightInkg],
                [TotalCropWeight],
                [PriceInMaun],
                [PriceInKg],
                [TotalCropPrice],
                [TotalExp],
                [TotalAmountwithExp],
                [FK_BagType],
                [BagWeight],
                [BagTotal], 
                [CreatedBy], 
                [CreatedDate],
                [BranchId],
                [Status]
            )
            SELECT 
                CustomerType,
                Fk_CustomerId,
                Fk_Crop,
                WeightInMaun,
                WeightInkg,
                TotalCropWeight,
                PriceInMaun,
                PriceInKg,
                TotalCropPrice,
                TotalExp,
                TotalAmountwithExp,
                FK_BagType,
                BagWeight,
                BagTotal,
                CreatedBy,
                GETUTCDATE(),
                BranchId,
                [Status]
            FROM OPENJSON(@JsonStringPurchase)
            WITH (
                CustomerType nvarchar(50) 'strict $.CustomerType',
                Fk_CustomerId uniqueidentifier 'strict $.Fk_CustomerId',
                Fk_Crop int 'strict $.Fk_Crop',
                WeightInMaun int 'strict $.WeightInMaun',
                WeightInkg decimal(18, 4) 'strict $.WeightInkg',
                TotalCropWeight decimal(18, 4) 'strict $.TotalCropWeight',
                PriceInMaun int 'strict $.PriceInMaun',
                PriceInKg decimal(18, 4) 'strict $.PriceInKg',
                TotalCropPrice int 'strict $.TotalCropPrice',
                TotalExp int 'strict $.TotalExp',
                TotalAmountwithExp decimal(18, 4) 'strict $.TotalAmountwithExp',
                FK_BagType int 'strict $.FK_BagType',
                BagWeight int 'strict $.BagWeight',
                BagTotal int 'strict $.BagTotal',
                CreatedBy uniqueidentifier 'strict $.CreatedBy',
                BranchId uniqueidentifier 'strict $.BranchId',
                [Status] nvarchar(10) 'strict $.Status'
            ) AS Js
            
            SELECT @UID = SCOPE_IDENTITY()
            PRINT @UID

            INSERT INTO [dbo].[StockMgt.Expense](
                [Fk_Purchase],
                [ExpDescription],
                [Amount],      
                [Type],
                [CreatedDate],
                [CreatedBy],
                [BranchId]
            )
            SELECT 
                @UID,
                ExpDescription,
                Amount,
                [Type],
                GETUTCDATE(),
                CreatedBy,
                BranchId
            FROM OPENJSON(@JsonStringExpense)
            WITH (
                ExpDescription nvarchar(MAX) 'strict $.ExpDescription',
                Amount int 'strict $.Amount',
                [Type] nvarchar(10) 'strict $.Type',
                CreatedBy uniqueidentifier 'strict $.CreatedBy',
                BranchId uniqueidentifier 'strict $.BranchId'
            ) AS Js

            INSERT INTO [MAMS].[dbo].[AccountMgt.CashHistory]
        (
            [Details],
            [CashProfit],
            [CashLost],
            [TotalCash],
            [CreatedDate],
            [CreatedBy],
            [BranchId]
        )
            SELECT 
                'Purchase',
                0,
                @TotalAmountwithExp,
                @TotalCash - @TotalAmountwithExp,
                GETUTCDATE(),
                CreatedBy,
                BranchId
            FROM OPENJSON(@JsonStringExpense)
            WITH (
                CreatedBy uniqueidentifier 'strict $.CreatedBy',
                BranchId uniqueidentifier 'strict $.BranchId'
            ) AS RS

            SET @Message = 'Success'
            SELECT @Message AS Message
        END
        ELSE
        BEGIN
            SET @Message = 'Total Cash is less than Purchase'
            SELECT @Message AS Message
        END
    END TRY
    BEGIN CATCH
        SET @Message = ERROR_MESSAGE()
        SELECT @Message AS Message
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[spCreateSaleCrop]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCreateSaleCrop]
   @JsonStringSale nvarchar(max),
   @JsonStringExpense nvarchar(max)

AS
BEGIN
Begin Try
    -- Variable Declarations
    declare @UID int
    declare @Message nvarchar(max)
    declare @TotalAmountwithExp int = Isnull((Select top 1 TotalAmountwithExp from OPENJSON(@JsonStringSale) WITH( TotalAmountwithExp int 'strict $.TotalAmountwithExp')),0)
    declare @TotalCash int = Isnull((Select top 1 TotalCash from [AccountMgt.CashHistory] order by uid desc),0)
    
    -- Print Statements for Debugging
    print @TotalAmountwithExp
    print @TotalCash

    -- Business Logic Check
    if(@TotalCash > @TotalAmountwithExp)
    begin
        -- Inserting Sale Record
        INSERT INTO [dbo].[StockMgt.Sale] (
            [Fk_Customer],
            [Fk_Crop],
            [WeightInMaun],
            [WeightInkg],
            [TotalCropWeight],
            [PriceInMaun],
            [PriceInKg],
            [TotalCropPrice],
            [TotalExp],
            [TotalAmountwithExp],
            [FK_BagType],
            [BagWeight],
            [BagTotal], 
            [CreatedBy], 
            [CreatedDate],
            [BranchId],
			[PurchaseExp],
			[PurchasePrice],
			[Status]
			)
        Select Fk_Customer,Fk_Crop,WeightInMaun,WeightInkg,TotalCropWeight,PriceInMaun,PriceInKg,TotalCropPrice,TotalExp,TotalAmountwithExp,
               FK_BagType,BagWeight,BagTotal,CreatedBy,GETUTCDATE(),BranchId ,PurchaseExp,PurchasePrice,Status
        from OPENJSON(@JsonStringSale)
        WITH
        (
            
            Fk_Customer uniqueidentifier 'strict $.Fk_Customer',
            Fk_Crop int 'strict $.Fk_Crop',
            WeightInMaun int 'strict $.WeightInMaun',
            WeightInkg decimal(18, 4) 'strict $.WeightInkg',
            TotalCropWeight decimal(18, 4) 'strict $.TotalCropWeight',
            PriceInMaun int 'strict $.PriceInMaun',
            PriceInKg decimal(18, 4) 'strict $.PriceInKg',
            TotalCropPrice int 'strict $.TotalCropPrice',
            TotalExp int 'strict $.TotalExp',
            TotalAmountwithExp int 'strict $.TotalAmountwithExp',
            FK_BagType int 'strict $.FK_BagType',
            BagWeight int 'strict $.BagWeight',
            BagTotal int 'strict $.BagTotal',
            CreatedBy uniqueidentifier 'strict $.CreatedBy',
            BranchId uniqueidentifier 'strict $.BranchId',
			PurchaseExp int 'strict $.PurchaseExp',
			PurchasePrice int 'strict $.PurchasePrice',
			Status varchar(50)  'strict $.Status'
            
        ) as Js

        -- Capture the newly inserted Sale ID
        SELECT @UID = SCOPE_IDENTITY();
        print @UID

        -- Inserting Expense Records
        INSERT INTO [dbo].[StockMgt.Expense](
            [Fk_Sale],
            [ExpDescription],
            [Amount],
            [Type],
            [CreatedDate],
            [CreatedBy],
            [BranchId],
			[IsOld]
			)
        Select @UID,ExpDescription,Amount,[Type],GETUTCDATE(),CreatedBy,BranchId,IsOld
        from OPENJSON(@JsonStringExpense)
        WITH
        (
            ExpDescription nvarchar(MAX) 'strict $.ExpDescription',
            Amount int 'strict $.Amount',
            [Type] nvarchar(10) 'strict $.Type',
            CreatedBy uniqueidentifier 'strict $.CreatedBy',
            BranchId uniqueidentifier 'strict $.BranchId',
			IsOld bit 'strict $.IsOld'
        ) as Js

        -- Updating Cash History
        INSERT INTO [dbo].[AccountMgt.CashHistory](
            [Details],
            [CashProfit],
            [CashLost],
            [TotalCash],
            [CreatedDate],
            [CreatedBy],
            [BranchId])
        Select 'Sale',@TotalAmountwithExp,0,@TotalCash + @TotalAmountwithExp,GETUTCDATE(),CreatedBy,BranchId
        from OPENJSON(@JsonStringExpense)
        WITH 
        ( 
            CreatedBy uniqueidentifier 'strict $.CreatedBy',
            BranchId uniqueidentifier 'strict $.BranchId'
        ) AS RS

        -- Success Message
        set @Message = 'Success'
        select @Message as Message
    end
    else
    begin
        set @Message = 'Total Cash is less then Sale'
        select @Message as Message
    end
End Try
Begin Catch
    set  @Message = ERROR_MESSAGE();
    Select @Message as Message
End Catch
END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteBag]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,M Usman>
-- Create date: <9/22/2021>
-- Description:	<Delete  Info>
-- =============================================

CREATE PROCEDURE [dbo].[spDeleteBag] 
	-- Add the parameters for the stored procedure here
	@UID int,
	@ModifiedBy uniqueidentifier
AS
BEGIN
	UPDATE [StockMgt.Bag] SET	[DeletedDate]=GETUTCDATE(),[ModifiedBy]=@ModifiedBy, [ModifiedDate]=GETUTCDATE()  WHERE [UID]=@UID ;
END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteCredit]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--[dbo].[spDeleteCredit] 32 ,00000000-0000-0000-0000-000000000000
-- =============================================
-- Author: <Author,,M Usman>
-- Create date: <9/22/2021>
-- Description: <Delete Credit Info>
-- =============================================

CREATE PROCEDURE [dbo].[spDeleteCredit] 
    -- Add the parameters for the stored procedure here
    @UID int,
    @ModifiedBy uniqueidentifier
AS
BEGIN
    UPDATE [CashMgt.Credit]
    SET [DeletedDate] = GETUTCDATE(),
        [ModifiedBy] = @ModifiedBy,
        [ModifiedDate] = GETUTCDATE()
    WHERE [UID] = @UID;
END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteCrop]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,M Usman>
-- Create date: <9/22/2021>
-- Description:	<Delete Customer Info>
-- =============================================

CREATE PROCEDURE [dbo].[spDeleteCrop] 
	-- Add the parameters for the stored procedure here
	@UID int , 
	@ModifiedBy uniqueidentifier
AS
BEGIN
	UPDATE [StockMgt.CropAndBag] 
	SET	[DeletedDate]=GETUTCDATE(),[ModifiedBy]=@ModifiedBy, [ModifiedDate]=GETUTCDATE() WHERE [UID]=@UID ;
END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteCustomerInfo]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,M Usman>
-- Create date: <9/22/2021>
-- Description:	<Delete Customer Info>
-- =============================================

CREATE PROCEDURE [dbo].[spDeleteCustomerInfo] 
	-- Add the parameters for the stored procedure here
	@UID uniqueidentifier,
	@ModifiedBy uniqueidentifier
AS
BEGIN
	UPDATE [CustomerMgt.CustomerInfo] 
	SET	[DeletedDate]=GETUTCDATE(),[ModifiedBy]=@ModifiedBy, [ModifiedDate]=GETUTCDATE()  WHERE [UID]=@UID ;
END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteDeposit]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--[dbo].[spDeleteCredit] 32 ,00000000-0000-0000-0000-000000000000
-- =============================================
-- Author: <Author,,M Usman>
-- Create date: <9/22/2021>
-- Description: <Delete Credit Info>
-- =============================================
create PROCEDURE [dbo].[spDeleteDeposit] 
    -- Add the parameters for the stored procedure here
    @UID int,
    @ModifiedBy uniqueidentifier
AS
BEGIN
    UPDATE [CashMgt.Deposit]
    SET [DeletedDate] = GETUTCDATE(),
        [ModifiedBy] = @ModifiedBy,
        [ModifiedDate] = GETUTCDATE()
    WHERE [UID] = @UID;
END
GO
/****** Object:  StoredProcedure [dbo].[spDeletePurchaseCrop]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
-- =============================================
-- Author:		<Author,,M Usman>
-- Create date: <9/22/2021>
-- Description:	<Delete Customer Info>
-- =============================================

CREATE PROCEDURE [dbo].[spDeletePurchaseCrop] 
	-- Add the parameters for the stored procedure here
	@UID int ,
	@ModifiedBy uniqueidentifier 
AS
BEGIN
	UPDATE [StockMgt.Purchase] 
	SET	[DeletedDate]=GETUTCDATE(),[ModifiedBy]=@ModifiedBy, [ModifiedDate]=GETUTCDATE() WHERE [UID]=@UID ;
END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteSaleCrop]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
-- =============================================
-- Author:		<Author,,M Usman>
-- Create date: <9/22/2021>
-- Description:	<Delete Customer Info>
-- =============================================

CREATE PROCEDURE [dbo].[spDeleteSaleCrop] 
	-- Add the parameters for the stored procedure here
	@UID int ,
	@ModifiedBy uniqueidentifier 
AS
BEGIN
	UPDATE [StockMgt.Sale] 
	SET	[DeletedDate]=GETUTCDATE(),[ModifiedBy]=@ModifiedBy, [ModifiedDate]=GETUTCDATE() WHERE [UID]=@UID ;
END
GO
/****** Object:  StoredProcedure [dbo].[spGetAllCashHistory]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetAllCashHistory] 
    @BranchId UNIQUEIDENTIFIER,
    @CreatedBy UNIQUEIDENTIFIER
   
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        UID,
        Details,
        CashProfit,
        CashLost,
        TotalCash,
        CreatedDate,
        CreatedBy,
        ModifiedBy,
        ModifiedDate,
        BranchId,
        DeletedDate
    FROM 
        [MAMS].[dbo].[AccountMgt.CashHistory]
    WHERE 
        DeletedDate IS NULL
        AND (BranchId = @BranchId OR @BranchId = '00000000-0000-0000-0000-000000000000')
        AND (CreatedBy = @CreatedBy OR @CreatedBy = '00000000-0000-0000-0000-000000000000')
        
    ORDER BY 
        UID DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[spGetAllCrop]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,M Usman>
-- Create date: <9/22/2021>
-- Description:	<GET Customer Info>
-- =============================================
--[dbo].[spGetAllCrop] '00000000-0000-0000-0000-000000000000','00000000-0000-0000-0000-000000000000',''

CREATE PROCEDURE [dbo].[spGetAllCrop]  
	 @BranchId uniqueidentifier,
	 @CreatedBy uniqueidentifier,
	 @Type varchar(50)
AS
BEGIN
	SELECT
	UID,
	Name, 
	CreatedBy,
	CreatedDate,
	Type
	FROM [StockMgt.CropAndBag]
	Where DeletedDate IS NULL AND 
	(BranchId = @BranchId OR @BranchId = '00000000-0000-0000-0000-000000000000') AND 
	(CreatedBy = @CreatedBy OR @CreatedBy = '00000000-0000-0000-0000-000000000000')  AND
	 ([Type] = @Type OR @Type = '')
	order by CreatedDate desc
END
GO
/****** Object:  StoredProcedure [dbo].[spGetAllCustomerInfo]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,M Usman>
-- Create date: <9/22/2021>
-- Description:	<GET Customer Info>
-- =============================================

CREATE PROCEDURE [dbo].[spGetAllCustomerInfo]  
	  @BranchId uniqueidentifier,
	 @CreatedBy uniqueidentifier
AS
BEGIN
	SELECT
	UID,
	Name,
	Phone,
	Email,
	CNIC,
	City,
	Country,
	CusType,
	ComShopName,
	ComAddress, 
	CreatedBy,
	CreatedDate
	FROM [CustomerMgt.CustomerInfo]
	Where DeletedDate IS NULL AND 
	(BranchId = @BranchId OR @BranchId = '00000000-0000-0000-0000-000000000000') AND 
	(CreatedBy = @CreatedBy OR @CreatedBy = '00000000-0000-0000-0000-000000000000')
	order by CreatedDate desc
END
GO
/****** Object:  StoredProcedure [dbo].[spGetAllExpenseInfo]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,M Usman>
-- Create date: <5/21/2024>
-- Description:	<GET Expense Info>
-- =============================================

CREATE PROCEDURE [dbo].[spGetAllExpenseInfo]  
	 @BranchId uniqueidentifier,
	 @CreatedBy uniqueidentifier
AS
BEGIN
	SELECT TOP (1000)
		UID,
		Fk_Purchase,
		Fk_Sale,
		ExpDescription,
		Amount,
		Type,
		CreatedBy,
		CreatedDate,
		ModifiedBy,
		ModifiedDate,
		BranchId,
		DeletedDate,
		IsOld

	FROM [StockMgt.Expense]
	Where DeletedDate IS NULL AND 
	(BranchId = @BranchId OR @BranchId = '00000000-0000-0000-0000-000000000000') AND 
	(CreatedBy = @CreatedBy OR @CreatedBy = '00000000-0000-0000-0000-000000000000')   
	order by CreatedDate desc
END
GO
/****** Object:  StoredProcedure [dbo].[spGetBag]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 

-- =============================================
-- Author:		<Author,,M Usman>
-- Create date: <9/22/2021>
-- Description:	<GET  Info>
-- =============================================

CREATE PROCEDURE [dbo].[spGetBag] 
	-- Add the parameters for the stored procedure here
	 @BranchId uniqueidentifier,
	 @CreatedBy uniqueidentifier,
	  @Type varchar(50)
AS
BEGIN
	SELECT
	UID,
	Name,	 
	CreatedBy,
	CreatedDate,
	Type
	FROM [StockMgt.CropAndBag]
	WHERE DeletedDate IS NULL 
	AND (BranchId = @BranchId OR @BranchId = '00000000-0000-0000-0000-000000000000')
	AND (CreatedBy = @CreatedBy OR @CreatedBy = '00000000-0000-0000-0000-000000000000')
	AND [Type] = @Type 
	Order BY CreatedDate DESC ;
END
GO
/****** Object:  StoredProcedure [dbo].[spGetCashHistory]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,M Usman>
-- Create date: <10/12/2021>
-- Description:	<GET Cash History>
-- =============================================

CREATE PROCEDURE [dbo].[spGetCashHistory] 
	@BranchId uniqueidentifier,
	@CreatedBy uniqueidentifier
AS
BEGIN
	Select top 1 UID,Details,CashProfit,CashLost,TotalCash
	from [AccountMgt.CashHistory] WHERE DeletedDate IS NULL  
	AND (BranchId = @BranchId OR @BranchId = '00000000-0000-0000-0000-000000000000')
	AND (CreatedBy = @CreatedBy OR @CreatedBy = '00000000-0000-0000-0000-000000000000')
	order by uid desc
END
GO
/****** Object:  StoredProcedure [dbo].[spGetCreditById]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
-- =============================================
-- Author:		<Author,,M Usman>
-- Create date: <9/22/2021>
-- Description:	<GET Purchase Crop Info by id>
-- =============================================
--[dbo].[spGetPurchaseCropById] 1013
CREATE PROCEDURE [dbo].[spGetCreditById] 
  @UID int 
AS
BEGIN 
		 
		SELECT
		 c.[UID]
		
		,[Fk_Customer] as [FKCustomer]
		,[TotalCash]
        ,c.[CreatedBy]
        ,c.[CreatedDate]
	    ,[Status]
        ,[Detail]
        ,c.[BranchId]
        ,[CustomerType]
         FROM [MAMS].[dbo].[CashMgt.Credit] c
		 Left JOIN [CustomerMgt.CustomerInfo] CF ON CF.[UID]=c.[Fk_Customer]
		 where
		      c.[DeletedDate] IS NULL AND c.[UID]=@UID; 
 
END
GO
/****** Object:  StoredProcedure [dbo].[spGetCreditInfo]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      <Author, M Usman>
-- Create date: <9/22/2021>
-- Description: <GET Credit Info>
-- =============================================

CREATE PROCEDURE [dbo].[spGetCreditInfo]
            @BranchId uniqueidentifier,
            @CreatedBy uniqueidentifier
AS
BEGIN 
        SELECT c.[UID], c.[TotalCash], c.[CreatedBy], c.[CreatedDate], c.[Fk_Customer], c.[Status],
               c.[Detail], c.[DeletedDate], c.[ModifiedBy], c.[ModifiedDate], c.[BranchId],
               cust.Name AS CustomerName -- Adding Customer Name
        FROM [CashMgt.Credit] c
       left JOIN [CustomerMgt.CustomerInfo] cust ON cust.UID = c.Fk_Customer
        WHERE c.DeletedDate IS NULL 
        AND (c.BranchId = @BranchId OR @BranchId = '00000000-0000-0000-0000-000000000000')
        AND (c.CreatedBy = @CreatedBy OR @CreatedBy = '00000000-0000-0000-0000-000000000000')
        ORDER BY c.CreatedDate DESC; 
END
GO
/****** Object:  StoredProcedure [dbo].[spGetCrop]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,M Usman>
-- Create date: <9/22/2021>
-- Description:	<GET Customer Info>
-- =============================================

CREATE PROCEDURE [dbo].[spGetCrop] 
	-- Add the parameters for the stored procedure here
	@UID int  
AS
BEGIN
	SELECT
	UID,
	Name,	 
	CreatedBy,
	CreatedDate,
	Type
    FROM [StockMgt.CropAndBag]
	WHERE [UID]=@UID ;
END
GO
/****** Object:  StoredProcedure [dbo].[spGetCustomerInfo]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,M Usman>
-- Create date: <9/22/2021>
-- Description:	<GET Customer Info>
-- =============================================

CREATE PROCEDURE [dbo].[spGetCustomerInfo] 
	-- Add the parameters for the stored procedure here
	@UID uniqueidentifier  
AS
BEGIN
	SELECT
	UID,
	Name,
	Phone,
	Email,
	CNIC,
	City,
	Country,
	CusType,
	ComShopName,
	ComAddress, 
	CreatedBy,
	CreatedDate
	FROM [CustomerMgt.CustomerInfo]
	WHERE [UID]=@UID ;
END
GO
/****** Object:  StoredProcedure [dbo].[spGetCustType]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetCustType] 
	-- Add the parameters for the stored procedure here
	@CusType nvarchar(50) ,
	@BranchId uniqueidentifier,
	@CreatedBy uniqueidentifier
AS
BEGIN
	SELECT
	UID,
	concat(Name,'-',Phone,'-',City) as Name
	FROM [CustomerMgt.CustomerInfo]
	WHERE CusType = @CusType and DeletedDate IS NULL AND 
	(BranchId = @BranchId OR @BranchId = '00000000-0000-0000-0000-000000000000') AND
	(CreatedBy = @CreatedBy OR @CreatedBy = '00000000-0000-0000-0000-000000000000')
END
GO
/****** Object:  StoredProcedure [dbo].[spGetDepositById]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
-- =============================================
-- Author:		<Author,,M Usman>
-- Create date: <9/22/2021>
-- Description:	<GET Purchase Crop Info by id>
-- =============================================
--[dbo].[spGetPurchaseCropById] 1013
create PROCEDURE [dbo].[spGetDepositById] 
  @UID int 
AS
BEGIN 
		 
		SELECT
		 d.[UID]
		
		,[Fk_Customer] as [FKCustomer]
		,[TotalCash]
        ,d.[CreatedBy]
        ,d.[CreatedDate]
	    ,[Status]
        ,[Detail]
        ,d.[BranchId]
        ,[CustomerType]
         FROM [MAMS].[dbo].[CashMgt.Deposit] d
		 Left JOIN [CustomerMgt.CustomerInfo] CF ON CF.[UID]=d.[Fk_Customer]
		 where
		      d.[DeletedDate] IS NULL AND d.[UID]=@UID; 
 
END
GO
/****** Object:  StoredProcedure [dbo].[spGetDepositInfo]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      <Author, M Usman>
-- Create date: <9/22/2021>
-- Description: <GET Deposit Info>
-- =============================================

create PROCEDURE [dbo].[spGetDepositInfo]
            @BranchId uniqueidentifier,
            @CreatedBy uniqueidentifier
AS
BEGIN 
        SELECT d.[UID], d.[TotalCash], d.[CreatedBy], d.[CreatedDate], d.[Fk_Customer], d.[Status],
               d.[Detail], d.[DeletedDate], d.[ModifiedBy], d.[ModifiedDate], d.[BranchId],
               cust.Name AS CustomerName -- Adding Customer Name
        FROM [CashMgt.Deposit] d
        LEFT JOIN [CustomerMgt.CustomerInfo] cust ON cust.UID = d.Fk_Customer
        WHERE d.DeletedDate IS NULL 
        AND (d.BranchId = @BranchId OR @BranchId = '00000000-0000-0000-0000-000000000000')
        AND (d.CreatedBy = @CreatedBy OR @CreatedBy = '00000000-0000-0000-0000-000000000000')
        ORDER BY d.CreatedDate DESC; 
END
GO
/****** Object:  StoredProcedure [dbo].[spGetExpenseInfoByType]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetExpenseInfoByType]  

     @BranchId uniqueidentifier,
	 @CreatedBy uniqueidentifier,
	 @Type varchar(50)
	  
AS
BEGIN
	SELECT 
		UID,
		Fk_Purchase,
		Fk_Sale,
		ExpDescription,
		Amount,
		Type,
		CreatedBy,
		CreatedDate,
		ModifiedBy,
		ModifiedDate,
		BranchId,
		DeletedDate,
		IsOld

	FROM [StockMgt.Expense]
	WHERE DeletedDate IS NULL AND 
	(BranchId = @BranchId OR @BranchId = '00000000-0000-0000-0000-000000000000') AND 
	(CreatedBy = @CreatedBy OR @CreatedBy = '00000000-0000-0000-0000-000000000000')   AND
	[Type] = @Type  
	ORDER BY CreatedDate DESC
END
GO
/****** Object:  StoredProcedure [dbo].[spGetPurchaseCrop]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,M Usman>
-- Create date: <9/22/2021>
-- Description:	<GET Purchase Crop Info>
-- =============================================

CREATE PROCEDURE [dbo].[spGetPurchaseCrop] --'00000000-0000-0000-0000-000000000000','00000000-0000-0000-0000-000000000000'
			@BranchId uniqueidentifier,
			@CreatedBy uniqueidentifier
AS
BEGIN 
		SELECT p.UID,concat(c.Name,'-',c.Phone,'-',c.City) as CustomerName,cp.Name as CropName,
		p.TotalCropWeight,p.TotalCropPrice,p.TotalExp,p.TotalAmountwithExp,p.CreatedDate,p.CreatedBy,p.[Status]
		FROM [StockMgt.Purchase] p
		join [CustomerMgt.CustomerInfo] c on c.UID= p.Fk_CustomerId
		join [StockMgt.CropAndBag] cp on cp.UID = p.Fk_Crop
		where p.DeletedDate IS NULL 
		
		AND (p.BranchId = @BranchId OR @BranchId = '00000000-0000-0000-0000-000000000000')
		AND (p.CreatedBy = @CreatedBy OR @CreatedBy = '00000000-0000-0000-0000-000000000000')
		order by  p.CreatedDate desc; 
 
END
GO
/****** Object:  StoredProcedure [dbo].[spGetPurchaseCropById]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
-- =============================================
-- Author:		<Author,,M Usman>
-- Create date: <9/22/2021>
-- Description:	<GET Purchase Crop Info by id>
-- =============================================
--[dbo].[spGetPurchaseCropById] 1013
CREATE PROCEDURE [dbo].[spGetPurchaseCropById] 
  @UID int 
AS
BEGIN 
		 
		SELECT
		 P.[UID]
		,[CustomerType] 
		,[Fk_CustomerId] 
		,[Fk_Crop]
		,[WeightInMaun]
		,[WeightInkg]
		,[TotalCropWeight]
		,[PriceInMaun]
		,[PriceInKg]
		,[TotalCropPrice]
		,[TotalExp]
		,[TotalAmountwithExp]
		,[FK_BagType]
		,[BagWeight]
		,[BagTotal]
		,P.[CreatedBy]
		,P.[CreatedDate]
		 		
		FROM [StockMgt.Purchase] P
		Left JOIN [CustomerMgt.CustomerInfo] CF ON CF.[UID]=P.[Fk_CustomerId]
		where  P.[DeletedDate] IS NULL AND P.[UID]=@UID; 
 
END
GO
/****** Object:  StoredProcedure [dbo].[spGetPurchaseExpenseById]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
-- =============================================
-- Author:		<Author,,M Usman>
-- Create date: <9/22/2021>
-- Description:	<GET Purchase Expense By Id>
-- =============================================

CREATE PROCEDURE [dbo].[spGetPurchaseExpenseById] 
@PUID int
AS
BEGIN 
		 
		SELECT
		[UID]
      ,[Fk_Purchase]
      ,[ExpDescription]
      ,[Amount]
      ,CreatedBy
      ,CreatedDate
       
  FROM [MAMS].[dbo].[StockMgt.Expense] WHERE DeletedDate IS NULL AND Fk_Purchase=@PUID;
 
END
GO
/****** Object:  StoredProcedure [dbo].[spGetSaleCrop]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,M Usman>
-- Create date: <9/22/2021>
-- Description:	<GET Purchase Crop Info>
-- =============================================

CREATE PROCEDURE [dbo].[spGetSaleCrop] --'00000000-0000-0000-0000-000000000000','00000000-0000-0000-0000-000000000000'
			@BranchId uniqueidentifier,
			@CreatedBy uniqueidentifier
			

AS
BEGIN 
		SELECT 
		s.UID,
		concat(c.Name,'-',c.Phone,'-',c.City) as CustomerName,
		c.CusType as FK_CustomerType,
		cp.Name as CropName,
		s.TotalCropWeight,
		s.TotalCropPrice,
		s.TotalExp,
		s.TotalAmountwithExp,
		s.CreatedDate,
		s.CreatedBy,
		s.Status
		FROM [StockMgt.Sale] s
		join [CustomerMgt.CustomerInfo] c on c.UID= s.Fk_Customer

		join [StockMgt.CropAndBag] cp on cp.UID = s.Fk_Crop

		where s.DeletedDate IS NULL 
		
		AND (s.BranchId = @BranchId OR @BranchId = '00000000-0000-0000-0000-000000000000')
		AND (s.CreatedBy = @CreatedBy OR @CreatedBy = '00000000-0000-0000-0000-000000000000')
		
		order by  s.CreatedDate desc; 
 
END
GO
/****** Object:  StoredProcedure [dbo].[spGetSaleCropById]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
-- =============================================
-- Author:		<Author,,M Usman>
-- Create date: <9/22/2021>
-- Description:	<GET Purchase Crop Info by id>
-- =============================================
--[dbo].[spGetPurchaseCropById] 1013
CREATE PROCEDURE [dbo].[spGetSaleCropById] 
  @UID int 
AS
BEGIN 
		 
		SELECT
		 S.[UID]
		 ,[Fk_Customer]
		,CF.[CusType] as [FK_CustomerType] 
		,CF.[Name]  as CustomerName
		,[Fk_Crop]
		,[WeightInMaun]
		,[WeightInkg]
		,[TotalCropWeight]
		,[PriceInMaun]
		,[PriceInKg]
		,[TotalCropPrice]
		,[TotalExp]
		,[TotalAmountwithExp]
		,[FK_BagType]
		,[BagWeight]
		,[BagTotal]
		,S.[CreatedBy]
		,S.[CreatedDate]
		,S.[PurchasePrice]
		,S.[PurchaseExp]
		,S.[Status]		
		FROM [StockMgt.Sale] S
		Left JOIN [CustomerMgt.CustomerInfo] CF ON CF.[UID]=S.[Fk_Customer]
		where  S.[DeletedDate] IS NULL AND S.[UID]=@UID; 
 
END
GO
/****** Object:  StoredProcedure [dbo].[spGetSaleExpenseById]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
-- =============================================
-- Author:		<Author,,M Usman>
-- Create date: <9/22/2021>
-- Description:	<GET Purchase Expense By Id>
-- =============================================

CREATE PROCEDURE [dbo].[spGetSaleExpenseById] 
@SUID int
AS
BEGIN 
		 
		SELECT
		[UID]
      ,[Fk_Sale]
      ,[ExpDescription]
      ,[Amount]
      ,CreatedBy
      ,CreatedDate
      ,IsOld
  FROM [MAMS].[dbo].[StockMgt.Expense] WHERE DeletedDate IS NULL AND Fk_Sale=@SUID;
 
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateBag]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 

-- =============================================
-- Author:		<Author,,M Usman>
-- Create date: <9/22/2021>
-- Description:	<GET Customer Info>
-- =============================================

CREATE PROCEDURE [dbo].[spUpdateBag] 
	-- Add the parameters for the stored procedure here
	@UID int,
	@BagName nvarchar(50),
	@ModifiedBy uniqueidentifier
AS
BEGIN
	UPDATE [StockMgt.Bag] 
	SET
	[BagName]=@BagName,
	ModifiedDate = GETUTCDATE(),
	ModifiedBy=@ModifiedBy
	WHERE [UID]=@UID ;
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateCashByLoss]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Your Name>
-- Description:	Update cash by loss
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateCashByLoss]
    @BranchId UNIQUEIDENTIFIER, 
    @CreatedBy UNIQUEIDENTIFIER,
    @CashLost DECIMAL(18, 2),
	@Details nvarchar(max)
AS
BEGIN
    BEGIN TRY
        DECLARE @Message NVARCHAR(MAX)
        DECLARE @TotalCash DECIMAL(18, 2) = ISNULL((SELECT TOP 1 TotalCash FROM [AccountMgt.CashHistory] WHERE BranchId = @BranchId ORDER BY uid DESC), 0)
        DECLARE @CurrentTotalCash DECIMAL(18, 2) = @TotalCash - @CashLost
	
        -- Insert into AccountMgt.CashHistory
        INSERT INTO [MAMS].[dbo].[AccountMgt.CashHistory]
        (
            [Details],
            [CashProfit],
            [CashLost],
            [TotalCash],
            [CreatedDate],
            [CreatedBy],
            [BranchId]
        )
        VALUES
        (
            @Details,
            0,
            @CashLost,
            @CurrentTotalCash,
            GETUTCDATE(),
            @CreatedBy,
            @BranchId
        )

        SET @Message = 'Success'
        SELECT @Message AS Message
    END TRY
    BEGIN CATCH
        SET @Message = ERROR_MESSAGE()
        SELECT @Message AS Message
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateCashByProfit]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Your Name>
-- Description:	Update cash by loss
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateCashByProfit]
    @BranchId UNIQUEIDENTIFIER, 
    @CreatedBy UNIQUEIDENTIFIER,
    @Cashprofit DECIMAL(18, 2),
	@Details nvarchar(max)
	
AS
BEGIN
    BEGIN TRY
        DECLARE @Message NVARCHAR(MAX)
        DECLARE @TotalCash DECIMAL(18, 2) = ISNULL((SELECT TOP 1 TotalCash FROM [AccountMgt.CashHistory] WHERE BranchId = @BranchId ORDER BY uid DESC), 0)
        DECLARE @CurrentTotalCash DECIMAL(18, 2) = @TotalCash + @Cashprofit
	
        -- Insert into AccountMgt.CashHistory
        INSERT INTO [MAMS].[dbo].[AccountMgt.CashHistory]
        (
            [Details],
            [CashProfit],
            [CashLost],
            [TotalCash],
            [CreatedDate],
            [CreatedBy],
            [BranchId]
        )
        VALUES
        (
            @Details,
             @Cashprofit,
           0,
            @CurrentTotalCash,
            GETUTCDATE(),
            @CreatedBy,
            @BranchId
        )

        SET @Message = 'Success'
        SELECT @Message AS Message
    END TRY
    BEGIN CATCH
        SET @Message = ERROR_MESSAGE()
        SELECT @Message AS Message
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateCrop]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,M Usman>
-- Create date: <9/22/2021>
-- Description:	<Update Customer info>
-- =============================================

CREATE PROCEDURE [dbo].[spUpdateCrop] 
	-- Add the parameters for the stored procedure here
	@UID int,
	@Name nvarchar(max),
	@ModifiedBy uniqueidentifier,
	@Type nvarchar(max)

AS
BEGIN
	UPDATE [StockMgt.CropAndBag] 
	SET
	[Name]=@Name,
	ModifiedDate = GETUTCDATE(),
	ModifiedBy=@ModifiedBy,
	Type=@Type
	WHERE [UID]=@UID 
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateCustomerInfo]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,M Usman>
-- Create date: <9/22/2021>
-- Description:	<Update Customer info>
-- =============================================

CREATE PROCEDURE [dbo].[spUpdateCustomerInfo] 
	-- Add the parameters for the stored procedure here
	@UID uniqueidentifier,
	@Name nvarchar(max),
	@Phone nvarchar(max),
	@Email nvarchar(max) = null,
	@CNIC nvarchar(max) = null,
	@City nvarchar(max) = null,
	@Country nvarchar(max) = null,
	@CusType nvarchar(max),
	@ComShopName nvarchar(max) = null,
	@ComAddress nvarchar(max) = null,
	@ModifiedBy uniqueidentifier
AS
BEGIN
	UPDATE [CustomerMgt.CustomerInfo] 
	SET
	[Name]=@Name,
	[Phone]=@Phone,
	[Email]=@Email,
	[CNIC]=@CNIC,
	[Country]=@Country,
	[City]=@City,
	[CusType]=@CusType,
	[ComShopName]=@ComShopName,
	[ComAddress]=@ComAddress,
	ModifiedDate = GETUTCDATE(),
	ModifiedBy=@ModifiedBy
	WHERE [UID]=@UID 
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateSaleCrop]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateSaleCrop]
	 @UID INT,
	 @FKCustomer  uniqueidentifier,
	 @Fk_Crop INT,
	 @WeightInMaun INT,
	 @WeightInkg decimal(18,4),
	 @TotalCropWeight decimal(18,4),
	 @PriceInMaun INT,
	 @PriceInKg decimal(18,4),
	 @TotalCropPrice INT,
	 @TotalExp INT, 
	 @TotalAmountwithExp INT, 
	 @FK_BagType INT,
	 @BagWeight INT,
	 @BagTotal INT,
	 @PurchaseExp INT,
	 @PurchasePrice INT,
	 @ModifiedBy uniqueidentifier 
AS
BEGIN
	 UPDATE [dbo].[StockMgt.Sale]
	 SET 
            [Fk_Customer]=@FKCustomer
           ,[Fk_Crop]=@Fk_Crop
           ,[WeightInMaun]=@WeightInMaun
           ,[WeightInkg]=@WeightInkg
           ,[TotalCropWeight]=@TotalCropWeight
           ,[PriceInMaun]=@PriceInMaun
           ,[PriceInKg]=@PriceInKg
           ,[TotalCropPrice]=@TotalCropPrice
           ,[TotalExp]=@TotalExp
           ,[TotalAmountwithExp]=@TotalAmountwithExp
           ,[FK_BagType]=@FK_BagType
           ,[BagWeight]=@BagWeight
           ,[BagTotal]=@BagTotal
           ,[PurchaseExp]=@PurchaseExp
           ,[PurchasePrice]=@PurchasePrice
           ,[ModifiedBy]=@ModifiedBy
           ,[ModifiedDate]=GETUTCDATE()
           
		WHERE [UID]=@UID
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCredit]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateCredit]
    @UID int ,
    @TotalCash Decimal(18, 4),
    @Status NVARCHAR(50),
    @Detail NVARCHAR(MAX),
    @ModifiedBy uniqueidentifier,
    @BranchId uniqueidentifier
AS
BEGIN
       UPDATE [CashMgt.Credit]
        SET
            [TotalCash] = @TotalCash, 
            [Status] = @Status,
            [Detail] = @Detail,
            [ModifiedBy] = @ModifiedBy,
            [ModifiedDate] = GETUTCDATE(),
            [BranchId] = @BranchId
        WHERE [UID] = @UID;

  
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateDeposit]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[UpdateDeposit]
    @UID int ,
    @TotalCash Decimal(18, 4),
    @Status NVARCHAR(50),
    @Detail NVARCHAR(MAX),
    @ModifiedBy uniqueidentifier,
    @BranchId uniqueidentifier
AS
BEGIN
       UPDATE [CashMgt.Deposit]
        SET
            [TotalCash] = @TotalCash, 
            [Status] = @Status,
            [Detail] = @Detail,
            [ModifiedBy] = @ModifiedBy,
            [ModifiedDate] = GETUTCDATE(),
            [BranchId] = @BranchId
        WHERE [UID] = @UID;

  
END
GO
/****** Object:  StoredProcedure [dbo].[UpdatePurchaseCrop]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
-- Description:Update Purchased Crop record
-- =============================================
CREATE PROCEDURE [dbo].[UpdatePurchaseCrop] 
	-- Add the parameters for the stored procedure here
	 @UID int ,
	 @CustomerType NVARCHAR(50),
	 @Fk_CustomerId uniqueidentifier ,
	 @Fk_Crop int,
	 @WeightInMaun INT,
	 @WeightInkg Decimal(18,4),
	 @TotalCropWeight Decimal(18,4),
	 @PriceInMaun INT,
	 @PriceInKg Decimal(18,4),
	 @TotalCropPrice INT,
	 @TotalExp INT,
	 @TotalAmountwithExp INT,
	 @FK_BagType INT,
	 @BagWeight INT,
	 @BagTotal INT,
	 @ModifiedBy uniqueidentifier
AS
BEGIN
	

		UPDATE [StockMgt.Purchase]
		SET 
			 [CustomerType]=@CustomerType
			,[Fk_CustomerId]=@Fk_CustomerId
			,[Fk_Crop]=@Fk_Crop
			,[WeightInMaun]=@WeightInMaun
			,[WeightInkg]=@WeightInkg
			,[TotalCropWeight]=@TotalCropWeight
			,[PriceInMaun]=@PriceInMaun
			,[PriceInKg]=@PriceInKg
			,[TotalCropPrice]=@TotalCropPrice
			,[TotalExp]=@TotalExp
			,[TotalAmountwithExp]=@TotalAmountwithExp
			,[FK_BagType]=@FK_BagType
			,[BagWeight]=@BagWeight
			,[BagTotal]=@BagTotal
			,[ModifiedBy]=@ModifiedBy
			,[ModifiedDate]=GETUTCDATE()
			WHERE [UID]=@UID;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateSaleCrop]    Script Date: 5/28/2024 6:22:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
-- Description:Update Purchased Crop record
-- =============================================
Create PROCEDURE [dbo].[UpdateSaleCrop] 
	-- Add the parameters for the stored procedure here
	 @UID int ,
	 @FKCustomer NVARCHAR(50),
	 
	 @Fk_Crop int,
	 @WeightInMaun INT,
	 @WeightInkg Decimal(18,4),
	 @TotalCropWeight Decimal(18,4),
	 @PriceInMaun INT,
	 @PriceInKg Decimal(18,4),
	 @TotalCropPrice INT,
	 @TotalExp INT,
	 @TotalAmountwithExp INT,
	 @FK_BagType INT,
	 @BagWeight INT,
	 @BagTotal INT,
	 @ModifiedBy uniqueidentifier
AS
BEGIN
	

		UPDATE [StockMgt.Sale]
		SET 
			 [Fk_Customer]=@FKCustomer
			
			,[Fk_Crop]=@Fk_Crop
			,[WeightInMaun]=@WeightInMaun
			,[WeightInkg]=@WeightInkg
			,[TotalCropWeight]=@TotalCropWeight
			,[PriceInMaun]=@PriceInMaun
			,[PriceInKg]=@PriceInKg
			,[TotalCropPrice]=@TotalCropPrice
			,[TotalExp]=@TotalExp
			,[TotalAmountwithExp]=@TotalAmountwithExp
			,[FK_BagType]=@FK_BagType
			,[BagWeight]=@BagWeight
			,[BagTotal]=@BagTotal
			,[ModifiedBy]=@ModifiedBy
			,[ModifiedDate]=GETUTCDATE()
			WHERE [UID]=@UID;
END
GO
