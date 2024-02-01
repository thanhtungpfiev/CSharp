CREATE DATABASE TestEntity
GO

USE TestEntity
GO

CREATE TABLE Lop
(
    ID INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(100) DEFAULT N'Kteam class'
)
GO

CREATE TABLE SinhVien
(
    ID INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(100) DEFAULT N'Kteam name',
    IDLop int NOT NULL
    FOREIGN KEY (IDLop) REFERENCES dbo.Lop(ID)
)
GO

INSERT INTO dbo.Lop
(Name)
VALUES (N'Kteam class 1')

INSERT INTO dbo.Lop
(Name)
VALUES (N'Kteam class 2')

INSERT INTO dbo.Lop
(Name)
VALUES (N'Kteam class 3')

INSERT INTO dbo.Lop
(Name)
VALUES (N'Kteam class 4')

INSERT INTO dbo.SinhVien
(Name, IDLop)
VALUES (N'Kter 1', 1)
INSERT INTO dbo.SinhVien
(Name, IDLop)
VALUES (N'Kter 2', 1)
INSERT INTO dbo.SinhVien
(Name, IDLop)
VALUES (N'Kter 3', 1)
INSERT INTO dbo.SinhVien
(Name, IDLop)
VALUES (N'Kter 4', 1)

INSERT INTO dbo.SinhVien
(Name, IDLop)
VALUES (N'Kter 1', 2)
INSERT INTO dbo.SinhVien
(Name, IDLop)
VALUES (N'Kter 2', 2)
INSERT INTO dbo.SinhVien
(Name, IDLop)
VALUES (N'Kter 3', 2)
INSERT INTO dbo.SinhVien
(Name, IDLop)
VALUES (N'Kter 4', 2)

INSERT INTO dbo.SinhVien
(Name, IDLop)
VALUES (N'Kter 1', 3)
INSERT INTO dbo.SinhVien
(Name, IDLop)
VALUES (N'Kter 2', 3)
INSERT INTO dbo.SinhVien
(Name, IDLop)
VALUES (N'Kter 3', 3)
INSERT INTO dbo.SinhVien
(Name, IDLop)
VALUES (N'Kter 4', 3)

INSERT INTO dbo.SinhVien
(Name, IDLop)
VALUES (N'Kter 1', 4)
INSERT INTO dbo.SinhVien
(Name, IDLop)
VALUES (N'Kter 2', 4)
INSERT INTO dbo.SinhVien
(Name, IDLop)
VALUES (N'Kter 3', 4)
INSERT INTO dbo.SinhVien
(Name, IDLop)
VALUES (N'Kter 4', 4)
