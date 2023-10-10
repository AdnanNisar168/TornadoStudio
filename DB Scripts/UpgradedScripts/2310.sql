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
