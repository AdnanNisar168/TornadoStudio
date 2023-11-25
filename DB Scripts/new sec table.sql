CREATE TABLE TestUser
(
	UserKey UNIQUEIDENTIFIER NOT NULL,
	CompanyID smallint NOT NULL,
	--UserCode VARCHAR(50) NOT NULL,
	UserName VARCHAR(500) NOT NULL,
	[Password] VARCHAR(500) NOT NULL,
	Constraint PK_TestUser PRIMARY KEY (UserKey), 
	Constraint FK_TestUser_BaseCompany FOREIGN KEY (CompanyID) REFERENCES BaseCompany(CompanyID),
);
GO
--drop TABLE SecUser2
--insert into SecUser2 values (newid(),1,'ts.admin','123')
select * from secuser2 
select * from BaseCompany