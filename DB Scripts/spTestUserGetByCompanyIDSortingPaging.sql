IF EXISTS (SELECT * FROM sysObjects o WHERE o.[name] = 'spTestUserGetByCompanyIDSortingPaging')
	DROP PROC spTestUserGetByCompanyIDSortingPaging
GO
-- ==========================================================================================
-- Author:		Adnan Nsiar
-- Create date: 24-Nov-2023
-- Description:	
-- ==========================================================================================
-- ------------ Modification History --------------------------------------------------------
-- Author	Date		Details
-- ------   ----        -------
-- ------------------------------------------------------------------------------------------
CREATE PROCEDURE spTestUserGetByCompanyIDSortingPaging
	(@CompanyID SMALLINT
	, @Password varchar(50)
	, @UserName varchar(50)
	, @SortColumn varchar(50)
	, @SortOrder varchar(50)
	, @PageNumber INT
	, @RecordsPerPage INT
	, @TotalRecords INT OUT
	)WITH ENCRYPTION
AS

BEGIN
	
	SELECT
		ROW_NUMBER() OVER (ORDER BY
			CASE WHEN @SortColumn = 'UserName' AND @SortOrder = 'asc' THEN UserName END ASC,
			CASE WHEN @SortColumn = 'UserName' AND @SortOrder = 'desc' THEN UserName END DESC,
			CASE WHEN @SortColumn = 'Password' AND @SortOrder = 'asc' THEN [Password] END ASC,
			CASE WHEN @SortColumn = 'Password' AND @SortOrder = 'desc' THEN [Password] END DESC
		) AS RowNumber
		,	UserKey
		,	CompanyID
		,	UserName
		,	[Password]
		--,	[CreatedOn]
		--,	[CreatedBy]
		--,	[StampDateTime]
		--,	[StampUserID]


	INTO #Paging

	FROM TestUser

	WHERE
		CompanyID = @CompanyID
		AND (UserName like '%' + @UserName + '%' OR ISNULL(@UserName,'') = '')
		AND ([Password] like '%' + @Password + '%' OR ISNULL(@Password,'') = '')

	SELECT @TotalRecords = COUNT(*) FROM #Paging

	SELECT
			UserKey
		,	CompanyID
		,	UserName
		,	[Password]
		--,	[CreatedOn]
		--,	[CreatedBy]
		--,	[StampDateTime]
		--,	[StampUserID]

	FROM #Paging p

	WHERE (RowNumber BETWEEN ((@PageNumber - 1) * @RecordsPerPage) + 1 AND ((@PageNumber - 1) * @RecordsPerPage) + @RecordsPerPage 
		OR @PageNumber IS NULL OR @RecordsPerPage IS NULL)

END
go
/*
DECLARE @TotalPages INT
exec spTestUserGetByCompanyIDSortingPaging
	@CompanyID=1, @SearchCode=null, @UserName=null, @Password=null,
		@SortColumn='SalesComission', @SortOrder='desc', @PageNumber=1,
			@RecordsPerPage=100, @TotalRecords = @TotalPages out
PRINT @TotalPages

select * from hremployee
*/
DECLARE @TotalPages INT
exec spTestUserGetByCompanyIDSortingPaging
	@CompanyID=1, @UserName='', @Password=null,
		@SortColumn='UserName', @SortOrder='asc', @PageNumber=1,
			@RecordsPerPage=100, @TotalRecords = @TotalPages out
PRINT @TotalPages

