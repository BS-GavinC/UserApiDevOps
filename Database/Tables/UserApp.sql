CREATE TABLE [dbo].[UserApp]
(
	[User_Id] INT NOT NULL IDENTITY,
	[Firstname] NVARCHAR(50) NOT NULL,
	[Lastname] NVARCHAR(50) NOT NULL,
	[Email] NVARCHAR(200) NOT NULL,
	[Birthdate] DATE NOT NULL,
	[Password_Hash] VARCHAR(100) NOT NULL, 

	CONSTRAINT PK_UserApp PRIMARY KEY ([User_Id]),
	CONSTRAINT UK_UserApp__Email UNIQUE([Email])
);
