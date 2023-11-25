IF EXISTS (SELECT * FROM sysObjects o WHERE o.[name] = 'spSecUser2GetByUserKey2')
	DROP PROC spSecUser2GetByUserKey2
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

CREATE PROCEDURE spSecUser2GetByUserKey2
	(@CompanyID SMALLINT
	, @UserKey varchar(100)
	) WITH ENCRYPTION
AS
BEGIN

	SELECT 
		u.CompanyID
		,u.Password
		,u.UserName
		,u.UserKey
		
		
	FROM  SecUser2 u
	--LEFT JOIN SecUser u on  d.CompanyID = u.CompanyID and d.StampUserID = u.UserID
	WHERE u.CompanyID = @CompanyID
		  and u.UserKey = @UserKey
END
go
/*
EXEC spSecUser2GetByUserKey2
	@CompanyID=1, @UserKey='0E15BA9D-A204-47F1-B7CE-64520178BC1C'
*/
select * from SecUser2



