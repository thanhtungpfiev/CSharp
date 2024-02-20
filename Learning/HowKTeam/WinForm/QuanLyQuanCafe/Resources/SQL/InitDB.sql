CREATE DATABASE QuanLyQuanCafe
GO

USE QuanLyQuanCafe
GO

-- Food

CREATE TABLE TableFood
(
    id INT IDENTITY PRIMARY KEY,
    name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
    status NVARCHAR(100) NOT NULL DEFAULT N'Trống',
)
GO

CREATE TABLE Account
(
    id INT IDENTITY PRIMARY KEY,
    UserName NVARCHAR(100) NOT NULL UNIQUE,
    DisplayName NVARCHAR(100) NOT NULL DEFAULT N'Kter',
    PassWord NVARCHAR(1000) NOT NULL DEFAULT 0,
    Type INT NOT NULL DEFAULT 0
)
GO

CREATE TABLE FoodCategory
(
    id INT IDENTITY PRIMARY KEY,
    name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
)
GO


CREATE TABLE Food
(
    id INT IDENTITY PRIMARY KEY,
    name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
    idFoodCategory INT NOT NULL,
    price FLOAT NOT NULL DEFAULT 0

        FOREIGN KEY (idFoodCategory) REFERENCES dbo.FoodCategory(id)
)
GO


CREATE TABLE Bill
(
    id INT IDENTITY PRIMARY KEY,
    DateCheckIn DATE NOT NULL DEFAULT GETDATE(),
    DateCheckOut DATE,
    idTable INT NOT NULL,
    status INT NOT NULL DEFAULT 0

        FOREIGN KEY (idTable) REFERENCES dbo.TableFood(id)

)
GO

CREATE TABLE BillInfo
(
    id INT IDENTITY PRIMARY KEY,
    idBill INT NOT NULL,
    idFood INT NOT NULL,
    count INT NOT NULL DEFAULT 0
        FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
        FOREIGN KEY (idFood) REFERENCES dbo.Food(id),

)
GO

USE [QuanLyQuanCafe]
GO

-- START Add Account to test
INSERT INTO [dbo].[Account]
           ([UserName]
           ,[DisplayName]
           ,[PassWord]
           ,[Type])
     VALUES
           (N'K9'
           ,N'RongK9'
           ,N'1'
           ,1)

INSERT INTO [dbo].[Account]
           ([UserName]
           ,[DisplayName]
           ,[PassWord]
           ,[Type])
     VALUES
           (N'staff' 
           ,N'staff'
           ,N'1'
           ,0)
GO
-- END Add Account to test

CREATE PROC USP_GetAccountByUserName
@userName nvarchar(100)
AS 
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName
END
GO

EXEC dbo.USP_GetAccountByUserName @userName = N'k9' -- nvarchar(100)
GO

CREATE PROC USP_Login
@userName nvarchar(100), @passWord nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName AND PassWord = @passWord
END
GO

-- START Add Table to test
DECLARE @i INT = 0

WHILE @i <= 10
BEGIN
	INSERT dbo.TableFood ( name)VALUES  ( N'Bàn ' + CAST(@i AS nvarchar(100)))
	SET @i = @i + 1
END
GO
-- END Add Table to test

CREATE PROC USP_GetTableList
AS
BEGIN
	SELECT * FROM dbo.TableFood
END
GO

UPDATE dbo.TableFood SET STATUS = N'Có người' WHERE id = 9

EXEC dbo.USP_GetTableList
GO

-- START Add Category to test
INSERT dbo.FoodCategory
        ( name )
VALUES  ( N'Hải sản'  -- name - nvarchar(100)
          )
INSERT dbo.FoodCategory
        ( name )
VALUES  ( N'Nông sản' )
INSERT dbo.FoodCategory
        ( name )
VALUES  ( N'Lâm sản' )
INSERT dbo.FoodCategory
        ( name )
VALUES  ( N'Sản sản' )
INSERT dbo.FoodCategory
        ( name )
VALUES  ( N'Nước' )
-- END Add Category to test

-- START Add Food to test
INSERT dbo.Food
        ( name, idFoodCategory, price )
VALUES  ( N'Mực một nắng nước sa tế', -- name - nvarchar(100)
          1, -- idCategory - int
          120000)
INSERT dbo.Food
        ( name, idFoodCategory, price )
VALUES  ( N'Nghêu hấp xả', 1, 50000)
INSERT dbo.Food
        ( name, idFoodCategory, price )
VALUES  ( N'Dú dê nướng sữa', 2, 60000)
INSERT dbo.Food
        ( name, idFoodCategory, price )
VALUES  ( N'Heo rừng nướng muối ớt', 3, 75000)
INSERT dbo.Food
        ( name, idFoodCategory, price )
VALUES  ( N'Cơm chiên mushi', 4, 999999)
INSERT dbo.Food
        ( name, idFoodCategory, price )
VALUES  ( N'7Up', 5, 15000)
INSERT dbo.Food
        ( name, idFoodCategory, price )
VALUES  ( N'Cafe', 5, 12000)
-- END Add Food to test

-- START Add Bill to test
INSERT	dbo.Bill
        ( DateCheckIn ,
          DateCheckOut ,
          idTable ,
          status
        )
VALUES  ( GETDATE() , -- DateCheckIn - date
          NULL , -- DateCheckOut - date
          3 , -- idTable - int
          0  -- status - int
        )
        
INSERT	dbo.Bill
        ( DateCheckIn ,
          DateCheckOut ,
          idTable ,
          status
        )
VALUES  ( GETDATE() , -- DateCheckIn - date
          NULL , -- DateCheckOut - date
          4, -- idTable - int
          0  -- status - int
        )
INSERT	dbo.Bill
        ( DateCheckIn ,
          DateCheckOut ,
          idTable ,
          status
        )
VALUES  ( GETDATE() , -- DateCheckIn - date
          GETDATE() , -- DateCheckOut - date
          5 , -- idTable - int
          1  -- status - int
        )
-- END Add Bill to test

-- START ADD Bill Info
INSERT	dbo.BillInfo
        ( idBill, idFood, count )
VALUES  ( 1, -- idBill - int
          1, -- idFood - int
          2  -- count - int
          )
INSERT	dbo.BillInfo
        ( idBill, idFood, count )
VALUES  ( 1, -- idBill - int
          3, -- idFood - int
          4  -- count - int
          )
INSERT	dbo.BillInfo
        ( idBill, idFood, count )
VALUES  ( 1, -- idBill - int
          5, -- idFood - int
          1  -- count - int
          )
INSERT	dbo.BillInfo
        ( idBill, idFood, count )
VALUES  ( 2, -- idBill - int
          1, -- idFood - int
          2  -- count - int
          )
INSERT	dbo.BillInfo
        ( idBill, idFood, count )
VALUES  ( 2, -- idBill - int
          6, -- idFood - int
          2  -- count - int
          )
INSERT	dbo.BillInfo
        ( idBill, idFood, count )
VALUES  ( 3, -- idBill - int
          5, -- idFood - int
          2  -- count - int
          )         
-- END ADD Bill Info
    
GO

CREATE PROC USP_InsertBill
@idTable INT
AS
BEGIN
	INSERT	dbo.Bill
        ( DateCheckIn ,
          DateCheckOut ,
          idTable ,
          status
        )
	VALUES  ( GETDATE() , -- DateCheckIn - date
          NULL , -- DateCheckOut - date
          @idTable, -- idTable - int
          0  -- status - int
        )
END
GO

CREATE PROC USP_InsertBillInfo
@idBill INT, @idFood INT, @count INT
AS
BEGIN
	DECLARE @isExistBillInfo INT
	DECLARE @foodCount INT = 1
	SELECT @isExistBillInfo = id, @foodCount = b.count
	FROM dbo.BillInfo AS b
	WHERE idBill = @idBill AND idFood  = @idFood

	IF (@isExistBillInfo > 0)
	BEGIN
		DECLARE @newCount INT = @foodCount + @count
		IF (@newCount > 0)
			UPDATE dbo.BillInfo SET count = @newCount
			WHERE idFood = @idFood
		ELSE
			DELETE dbo.BillInfo WHERE idBill = @idBill AND idFood = @idFood
	END
	ELSE
	BEGIN
		INSERT	dbo.BillInfo
        ( idBill, idFood, count )
		VALUES  ( @idBill, -- idBill - int
				  @idFood, -- idFood - int
				  @count  -- count - int
				  )         
	END
END
GO

CREATE TRIGGER UTG_UpdateBillInfo
ON dbo.BillInfo FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @idBill INT
	
	SELECT @idBill = idBill FROM Inserted
	
	DECLARE @idTable INT
	
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill AND status = 0
	
	UPDATE dbo.TableFood SET status = N'Có người' WHERE id = @idTable
END
GO

CREATE TRIGGER UTG_UpdateBill
ON dbo.Bill FOR UPDATE
AS
BEGIN
	DECLARE @idBill INT
	
	SELECT @idBill = id FROM Inserted	
	
	DECLARE @idTable INT
	
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill
	
	DECLARE @count int = 0
	
	SELECT @count = COUNT(*) FROM dbo.Bill WHERE idTable = @idTable AND status = 0
	
	IF (@count = 0)
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable
END
GO