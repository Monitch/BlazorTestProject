CREATE PROCEDURE [dbo].[deleteUser]
	@id int
AS
DELETE FROM [User] where id = @id
GO
CREATE PROCEDURE [dbo].[insertUser]
	@name varchar(50),
	@number varchar (20),
	@email varchar(50)

AS
	INSERT INTO [User] (Name, Number, Email)
	VALUES (@name,@number,@email)
GO
	CREATE PROCEDURE [dbo].[updateUser]
	@id int ,
	@name varchar(50),
	@number varchar (20),
	@email varchar(50)
AS
	UPDATE [User] set Name = @name, Number = @number, Email = @email where id = @id