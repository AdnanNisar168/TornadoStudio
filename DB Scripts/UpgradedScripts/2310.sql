CREATE TABLE BaseCompany(
	CompanyID smallint not null,
	CompanyCode varchar(50) not null,
	CompanyName varchar(400) not null,
	ParentCompanyID smallint not null,
	StampDateTime datetime,
	StampUserID int not null,
	RecordStatusID int ,
	InactiveFrom datetime,
	InactiveTo datetime,
	UploadDateTime datetime,
	Address nvarchar(2000),
	City varchar(500),
	Country varchar(500),
	WebsiteUrl varchar(1000),
	EmailAddress varchar(500),
	LandlineNumber varchar(100),
	MobileNumber varchar(100),
	ContactPersonName varchar(200),
	CompanyLogoRelativePath varchar(1000),
	State varchar(100),
	ZipCode varchar(20),
	ContactPersonMobileNumber varchar(200),
	CompanyLogoFileID int,
	IsTemplate bit,
	SmsBalance int,
	CompanyDescription varchar(500),
	StockQty float,
	StockValue float,
	SoldQty float,
	SoldValue float,
	SoldCost float,
	BrandID int,
	CreatedBy int,
	CreatedOn datetime,
	CompanyTypeID int,
	PaymentFrequency varchar(50),
	CompanyPackageID int,
	ComputerCode varchar(500),
	Notes varchar(5000),
	InitialAmount float,
	PaymentAmount float,
	IsForValuedClientsList bit,
	CompanyKey uniqueidentifier not null,
	--BrandKey uniqueidentifier not null,
	IsActive bit

	CONSTRAINT PK_BaseCompany PRIMARY KEY (CompanyID),
	CONSTRAINT FK_BaseCompany_SecsUser FOREIGN KEY (UserKey)
		REFERENCES BaseCompany (UserKey)
)
go
ALTER TABLE BaseCompany
	ADD UserKey UNIQUEIDENTIFIER NULL
go

ALTER TABLE BaseCompany
	ALTER COLUMN UserKey UNIQUEIDENTIFIER NOT NULL
go

/*
alter table BaseCompany Drop Column BrandKey

Insert Into BaseCompany (CompanyID,CompanyCode,CompanyName,ParentCompanyID,StampDateTime,StampUserID,RecordStatusID,UploadDateTime,CompanyKey)
values (1,'ts','TornadoStudio',0,'2023-10-10 13:12:42.163',1,2,'2023-10-10 13:12:42.163','2FDD5C26-0F3A-4B88-AE3D-56781851B833')
*/



CREATE TABLE SecUser(
	CompanyID smallint not null,
	InactiveFrom datetime,
	InactiveTo datetime,
	Password varchar(500) not null,
	StampDateTime datetime not null,
	StampUserID int not null,
	UserFullName varchar(50),
	UserName varchar(50),
	RecordStatusID int,
	Short_Name varchar(20),
	Upload_DateTime datetime,
	MobileVerificationCode varchar(50),
	EmailVerificationCode varchar(50),
	MaximumSmsPerDay int,
	MaximumEmailPerDay int,
	SmsReceivingTimingStart int,
	SmsReceivingTimingEnd int,
	MobileVerificationDateTime datetime,
	EmailAddress varchar(50),
	DocumentStatus_ID int,
	IsCompanyAdmin bit,
	IsEmailVerified bit,
	PasswordResetCode varchar(50),
	MobileNumber varchar(20),
	UserKey uniqueidentifier not null,
	ShopID int,
	IsMobileVerified bit,
	LockedUntil datetime,
	FailedLoginAttempts int,
	IsSuperAdmin bit,
	IsActive bit,
	SupportLevel int,
	LoginDateTime datetime,

	CONSTRAINT PK_SecUser PRIMARY KEY (UserKey),
	CONSTRAINT FK_SecUser_BaseCompany FOREIGN KEY (CompanyID)
		REFERENCES BaseCompany (CompanyID)
)
go

/*
Insert Into SecUser (CompanyID,Password,StampDateTime,StampUserID,UserName,RecordStatusID,IsCompanyAdmin,UserKey,IsSuperAdmin,IsActive,SupportLevel)
values (1,'123','2023-10-10 13:19:55.167',1,'TS.Adnan',3,1,'9DFADE07-E497-43C7-BB3E-6D93CA49C60D',1,1,0)
*/

go
ALTER TABLE SecUser
	ADD CompanyKey UNIQUEIDENTIFIER NULL
go




select GETDATE()
select newid()
--update SecUser set 
--CompanyKey = '2FDD5C26-0F3A-4B88-AE3D-56781851B833'
--select Companyid , userkey,CompanyKey from BaseCompany
--select CompanyID , userkey ,companykey from SecUser

ALTER TABLE SecUser
	ALTER COLUMN CompanyKey UNIQUEIDENTIFIER NOT NULL
go

CREATE TABLE BaseMenu
(	
	MenuID INT NOT NULL ,
	MenuName varchar(200) NOT NULL ,
	DisplayOrder SMALLINT NOT NULL ,
	ParentMenuID INT NOT NULL ,
	StampUserID INT NOT NULL ,
	StampDateTime DATETIME NOT NULL ,
	RecordStatusID INT NULL ,
	PageUrl varchar(500) NOT NULL ,
	Icon varchar(100) NOT NULL ,
	BetaUrl varchar(1000) NOT NULL ,

	CONSTRAINT PK_BaseMenu PRIMARY KEY (MenuID) ,
);
GO

CREATE TABLE BaseSetting
(	
	CompanyID smallint NOT NULL ,
	SettingDescription varchar(200) NOT NULL ,
	SettingID varchar(100) NOT NULL ,
	SettingValue varchar(8000) NOT NULL ,
	SettingValueDataType varchar(10) NOT NULL ,
	SettingValueMaximumValue varchar(50) NULL ,
	SettingValueMinimumValue varchar(50) NULL ,
	UserID INT NOT NULL ,
	StampUserID INT NOT NULL ,
	StampDateTime DATETIME NOT NULL ,
	UploadDateTime DATETIME NULL ,
	RecordStatusID INT NULL ,
	SettingAutoID INT NOT NULL IDENTITY(1,1),
	ModuleID INT NULL ,
	PageUrl varchar(500) NOT NULL ,
	Icon varchar(100) NOT NULL ,
	BetaUrl varchar(1000) NOT NULL ,

	CONSTRAINT PK_BaseSetting PRIMARY KEY (SettingAutoID) ,
);
GO
CREATE TABLE SecRole
(	
	RoleKey  UNIQUEIDENTIFIER Not NULL,
	CompanyID smallint NOT NULL ,
	RoleName varchar(250) NOT NULL ,
	InactiveFrom DATETIME NOT NULL ,
	InactiveTo DATETIME NOT NULL ,
	RecordStatusID INT NOT NULL ,
	StampUserID INT NOT NULL ,
	StampDateTime DATETIME NOT NULL ,


	CONSTRAINT PK_SecRole PRIMARY KEY (RoleKey) ,
);
GO


select * from BaseSetting