IF EXISTS (SELECT * FROM sysObjects o WHERE o.[name] = 'spTestUserGetByUserKey')
	DROP PROC spTestUserGetByUserKey
go
-- ==========================================================================================
-- Author:		Adnan Nisar
-- Create date: 10-Feb-2023
-- Description:	This stored procedure returns Department by DeparmentID
-- ==========================================================================================
-- ------------ Modification History --------------------------------------------------------
-- Author:		Adnan Nisar
-- Create date: 11-Nov-2023
-- Description:	This stored procedure returns Department by DeparmentID
-- ------------------------------------------------------------------------------------------

CREATE PROCEDURE spTestUserGetByUserKey
	(@CompanyID SMALLINT
	, @UserKey varchar(100)
	) WITH ENCRYPTION
AS
BEGIN

	SELECT 
	t.CompanyID
	,t.Password
	,t.UserKey
	,t.UserName
		--d.DepartmentKey
		--,d.DepartmentCode
		--,d.DepartmentName
		--,d.CreatedOn
		--,d.CreatedBy
		--,d.StampDateTime 'UpdatedOn'
		--,u.UserName 'UpdatedByName'
		
	FROM  TestUser t
	--LEFT JOIN SecUser u on  d.CompanyID = u.CompanyID and d.StampUserID = u.UserID
	WHERE t.CompanyID = @CompanyID
		  and t.UserKey= @UserKey
END
go
/*
EXEC spTestUserGetByUserKey
	@CompanyID=60, @UserKey='5568EA0B-18E0-42F8-BF42-0D1EE13E2AFF'
select * from TestUser
*/
EXEC spTestUserGetByUserKey
	@CompanyID=1, @UserKey='5568EA0B-18E0-42F8-BF42-0D1EE13E2AFF'




