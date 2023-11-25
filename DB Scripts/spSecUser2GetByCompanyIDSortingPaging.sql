IF EXISTS (SELECT * FROM sysObjects o WHERE o.[name] = 'spSecUser2GetByCompanyIDSortingPaging')
	DROP PROC spSecUser2GetByCompanyIDSortingPaging
go
-- ==========================================================================================
-- Author:		Imran Amin
-- Create date: 20-May-2019
-- Description:	
-- ==========================================================================================
-- ------------ Modification History --------------------------------------------------------
-- Author: Adnan Nisar
-- Date: 26-Nov-22
--Details: I have added "EmployeeTypeName" from "HREmployeeType" Table
-- ------------------------------------------------------------------------------------------

CREATE PROCEDURE spSecUser2GetByCompanyIDSortingPaging
	(@CompanyID SMALLINT
	, @UserName varchar(50)
	, @Password varchar(50)
	--, @Phone varchar(100)
	--, @City varchar(100)
	--, @DepartmentKey varchar(100)
	--, @IsActive INT
	--, @EmployeeType INT
	, @SortColumn varchar(50)
	, @SortOrder varchar(50)
	, @PageNumber INT
	, @RecordsPerPage INT
	, @TotalRecords INT OUT
	) WITH ENCRYPTION
AS
BEGIN
	
	SELECT
		ROW_NUMBER() OVER (ORDER BY
			--CASE WHEN @SortColumn = 'EmployeeCode' AND @SortOrder = 'asc' THEN RIGHT('0000000000' + e.EmployeeCode, 10) END ASC,
			--CASE WHEN @SortColumn = 'EmployeeCode' AND @SortOrder = 'desc' THEN RIGHT('0000000000' + e.EmployeeCode, 10) END DESC,

			CASE WHEN @SortColumn = 'UserName' AND @SortOrder = 'asc' THEN u.UserName END ASC,
			CASE WHEN @SortColumn = 'UserName' AND @SortOrder = 'desc' THEN u.UserName END DESC,
			
			CASE WHEN @SortColumn = 'Password' AND @SortOrder = 'asc' THEN u.Password END ASC,
			CASE WHEN @SortColumn = 'Password' AND @SortOrder = 'desc' THEN u.Password END DESC

			--CASE WHEN @SortColumn = 'EmployeeDescription' AND @SortOrder = 'asc' THEN EmployeeDescription END ASC,
			--CASE WHEN @SortColumn = 'EmployeeDescription' AND @SortOrder = 'desc' THEN EmployeeDescription END DESC,

			--CASE WHEN @SortColumn = 'Phone' AND @SortOrder = 'asc' THEN Phone END ASC,
			--CASE WHEN @SortColumn = 'Phone' AND @SortOrder = 'desc' THEN Phone END DESC,

			--CASE WHEN @SortColumn = 'City' AND @SortOrder = 'asc' THEN City END ASC,
			--CASE WHEN @SortColumn = 'City' AND @SortOrder = 'desc' THEN City END DESC,

			--CASE WHEN @SortColumn = 'DepartmentName' AND @SortOrder = 'asc' THEN e.DepartmentKey END ASC,
			--CASE WHEN @SortColumn = 'DepartmentName' AND @SortOrder = 'desc' THEN e.DepartmentKey END DESC,

			--CASE WHEN @SortColumn = 'SalesComission' AND @SortOrder = 'asc' THEN e.SalesComission END ASC,
			--CASE WHEN @SortColumn = 'SalesComission' AND @SortOrder = 'desc' THEN e.SalesComission END DESC,

			--CASE WHEN @SortColumn = 'IsActive' AND @SortOrder = 'asc' THEN e.IsActive END ASC,
			--CASE WHEN @SortColumn = 'IsActive' AND @SortOrder = 'desc' THEN e.IsActive END DESC


		) AS RowNumber
		 --, EmployeeID
		 --, EmployeeCode
		 --, EmployeeName
		 --, e.SalesComission
		 --, t.EmployeeTypeName
		 --, EmployeeDescription
		 --, Phone
		 --, City
		 --, IsActive
		 --, EmployeeType
		 --, d.DepartmentKey 
		 --, d.DepartmentName 
   --		 , e.StampDateTime
		 --, e.StampUserID
		  , u.CompanyID
		  , u.Password
		  , u.UserKey
		  , u.UserName

	INTO #Paging

	FROM
		SecUser2 u
	--LEFT JOIN
	--	HRDepartment d ON e.DepartmentKey = d.DepartmentKey
	--LEFT JOIN
	--	HREmployeeType t ON e.EmployeeType = t.EmployeeTypeID 

	WHERE
		u.CompanyID = @CompanyID 
		--AND (RecordStatusID <> 4)
		--AND (UserKey like '%' + @UserKey + '%' OR ISNULL(@UserKey,'') = '')
		AND (UserName like '%' + @UserName + '%' OR ISNULL(@UserName,'') = '')
		AND (Password like '%' + @Password + '%' OR ISNULL(@Password,'') = '')
		--AND (City like '%' + @City + '%' OR ISNULL(@City,'') = '')
		--ANd (e.DepartmentKey = @DepartmentKey OR @DepartmentKey is null)
		--AND (IsActive = @IsActive OR @IsActive IS NULL)
		--AND EmployeeType = @EmployeeType


	SELECT @TotalRecords = COUNT(*) FROM #Paging

	SELECT
		 --  EmployeeID
		 --, EmployeeCode
		 --, EmployeeName
		 --, EmployeeType
		 --, SalesComission
		 --, EmployeeTypeName
		 --, EmployeeDescription
		 --, Phone
		 --, City
		 --, DepartmentKey
		 --, DepartmentName
		 --, IsActive
		  CompanyID
		  , Password
		  , UserKey
		  , UserName
	FROM #Paging p

	WHERE (RowNumber BETWEEN ((@PageNumber - 1) * @RecordsPerPage) + 1 AND ((@PageNumber - 1) * @RecordsPerPage) + @RecordsPerPage 
		OR @PageNumber IS NULL OR @RecordsPerPage IS NULL)

END

GO
/*
DECLARE @TotalPages INT
exec spSecUser2GetByCompanyIDSortingPaging
	@CompanyID=60, @SearchCode=null, @SearchName=null, @Phone=null,@City=null,@EmployeeType=4,
 @DepartmentKey = null, @IsActive=1, @SortColumn='EmployeeName', @SortOrder='asc', @PageNumber=1,
 @RecordsPerPage=100, @TotalRecords = @TotalPages out
PRINT @TotalPages
*/
DECLARE @TotalPages INT
exec spSecUser2GetByCompanyIDSortingPaging
	@CompanyID=1, @UserName = null, @Password=null, @SortColumn='UserName', @SortOrder='asc', @PageNumber=1,
 @RecordsPerPage=100, @TotalRecords = @TotalPages out
PRINT @TotalPages