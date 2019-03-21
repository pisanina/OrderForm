Create Table Product 
(Id int not null Identity(1,1),
[Name] nvarchar(128) not null,
[Availability] int not null,
Price smallmoney not null,
Constraint PK_Product_Id Primary key (Id),
Constraint UC_Product_Name Unique ([Name]),
Constraint CH_Product_Availability CHECK ([Availability] >=0),
Constraint CH_Product_Price CHECK (Price >=0))


Insert INTO Product ([Name], [Availability], Price) Values 
('Monitor 21"', 10, 1000), 
('Monitor 27"', 5, 1500), 
('Monitor 32"', 3, 2000), 
('Monitor 40"', 7, 3000),
('Mysz bezprzewodowa', 50, 19.99)


Create Table Client
(Id int not null Identity(1,1),
FirstName nvarchar(32) not null,
LastName nvarchar(32) not null,
BirthDate Date not null,
Constraint PK_Client_Id Primary key (Id))


Create Table [Order]
(Id int not null Identity(1,1),
ClientId  int not null,
Constraint PK_Order_Id Primary key (Id),
Constraint FK_Order_ClientId_Client_Id Foreign key (ClientId) References Client(Id))


Create Table ProductOrder
( OrderId int not null,
ProductId int not null,
Quantity int not null,
ActualPrice smallmoney not null,
Constraint FK_ProductOrder_ProductId_Product_Id Foreign key (ProductId) References Product(Id),
Constraint CH_ProductOrder_Quantity CHECK (Quantity >=0),
Constraint CH_ProductOrder_ActualPrice CHECK (ActualPrice >=0),
Constraint FK_ProductOrder_OrderId_Order_Id Foreign Key (OrderId) References [Order](Id))

Go
CREATE LOGIN [orderForm] WITH PASSWORD=N'MTyHHRKM5UP2Q6LX+eIUrW+daTSe855TZXmKfjNR0Ds=', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
Go
CREATE USER [orderForm] FOR LOGIN [orderForm] WITH DEFAULT_SCHEMA=[dbo]


Go 
Create Type ProductList As Table
	(ProductId int not null, 
		Quantity int not null)

Go
Grant Execute On Type:: ProductList To orderForm

Go
Create Procedure GetProductList
AS
	Select Id, Name, Price From Product

Go
  Grant EXECUTE ON GetProductList to orderForm  
     


GO
Create Procedure [dbo].[NewOrder] 
  @FirstName nvarchar(32), @LastName nvarchar(32), @BirthDate Date, 
  @ListOfProduct ProductList readonly 
  AS
  begin
	begin try
		BEGIN TRANSACTION 

			Insert Into Client (FirstName, LastName, BirthDate) Values 
									(@FirstName, @LastName, @BirthDate)

			Update Product Set [Availability] -= Lop.Quantity 
				From Product Inner Join @ListOfProduct AS Lop ON Product.Id=Lop.ProductId

			Insert Into [Order] (ClientId) values (Scope_Identity())

			Insert Into [ProductOrder] (OrderId, ProductId, Quantity, ActualPrice) 
				Select SCOPE_IDENTITY(), ProductId, Quantity, Price   From @ListOfProduct 
					Join Product On Product.Id = ProductId

		COMMIT TRANSACTION 
	end try
  begin catch
	  Rollback TRANSACTION 
	  Print'Transaction Rolled Back';
	  throw
  end catch
  end

   Go
  Grant EXECUTE ON NewOrder to orderForm  

 

/*
 Delete  From Client
 Delete from [Order]
  declare @FirstName nvarchar(32)
  declare @LastName nvarchar(32)
  declare @BirthDate Date
  declare @ListOfProduct ProductList

  Set @FirstName = 'Adam'
  SET @LastName = 'Kolodziej'
  SET @BirthDate = '2000-01-01'


  Insert into @ListOfProduct  (ProductId, Quantity) 
  Values (1, 2),(2, 1),(5, 2)

Exec NewOrder @FirstName, @LastName, @BirthDate, @ListOfProduct

Select * From [ProductOrder]
Select * From Client

*/
