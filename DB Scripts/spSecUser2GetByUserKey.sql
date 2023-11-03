IF EXISTS (SELECT * FROM sysObjects o WHERE o.[name] = 'spSecUser2GetByUserKey')
	DROP PROC spSecUser2GetByUserKey
go
-- ==========================================================================================
-- Author:		Adnan Nisar
-- Create date: 05-Nov-2022
-- Description:	This stored procedure returns company by company key
-- ==========================================================================================
-- ------------ Modification History --------------------------------------------------------
-- Author	Date		Details
-- ------   ----        -------
-- ------------------------------------------------------------------------------------------
CREATE PROCEDURE spSecUser2GetByUserKey
	(@UserKey varchar (50)
	)WITH ENCRYPTION
AS
BEGIN
	SELECT 
		u.UserKey
		,u.CompanyID
		,c.CompanyName
		,u.UserName
		,u.Password
                            
	FROM 
		SecUser2 u 
	
	INNER JOIN
		BaseCompany c on c.CompanyID = u.CompanyID
	

	WHERE 
		u.UserKey = @UserKey 

END
GO
/*
exec spSecUser2GetByUserKey @UserKey = 'DBEB0C00-ACF8-4ADA-BED0-C03A96912BEC'
select * from BaseCompany where companycode = '1047'
select * from BaseCompany where companyname like '%tor%'
select * from secuser where companyid= 1035
select * from secuser where companyid= 1047
select * from secuser where UserID = 5721
*/
