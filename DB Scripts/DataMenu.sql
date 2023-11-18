SET NOCOUNT ON
go
IF EXISTS (SELECT * FROM sysObjects o WHERE o.[name] = 'spBaseMenuInsertOrUpdate')
	DROP PROC spBaseMenuInsertOrUpdate
go
CREATE PROC spBaseMenuInsertOrUpdate
	@MenuID INT
	, @MenuDescription VARCHAR(500)
	, @DisplayOrder INT
	, @ParentMenuID INT
	, @PageUrl VARCHAR(1000)
	, @BetaUrl VARCHAR(1000)
	, @Icon VARCHAR(100)
	, @RecordStatusID INT
	WITH ENCRYPTION
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM BaseMenu WHERE MenuID = @MenuID)
	BEGIN
		PRINT 'Inserting Menu ' + ISNULL(@MenuDescription, '')

		INSERT INTO [BaseMenu]
			([MenuID], [MenuName], [DisplayOrder], [ParentMenuID]
			, PageUrl, BetaUrl, Icon, [StampUserID], [StampDateTime], [RecordStatusID])
		VALUES
			(@MenuID, @MenuDescription, @DisplayOrder, @ParentMenuID
			, @PageUrl, @BetaUrl, @Icon, 1, GetUtcDate(), @RecordStatusID)
	END
	ELSE
	BEGIN
		PRINT 'Updating Menu ' + ISNULL(@MenuDescription, '')

		UPDATE BaseMenu
		SET 
			MenuID = @MenuID
			, MenuName = @MenuDescription
			, DisplayOrder = @DisplayOrder
			, ParentMenuID = @ParentMenuID
			, PageUrl = @PageUrl
			, BetaUrl = @BetaUrl
			, Icon = @Icon
			, StampUserID = 1
			, StampDateTime = GetUtcDate()
			, RecordStatusID = @RecordStatusID
		WHERE MenuID = @MenuID
	END
END
GO

spBaseMenuInsertOrUpdate
	@RecordStatusID = 1
	, @MenuID = 1000, @ParentMenuID = 0, @DisplayOrder = 1
	, @Icon = 'fa-dashboard', @MenuDescription = 'Dashboard'
	, @PageUrl = '/ng/Dashboard'
	, @BetaUrl = ''
go
spBaseMenuInsertOrUpdate
	@RecordStatusID = 1
	, @MenuID = 2000, @ParentMenuID = 0, @DisplayOrder = 2
	, @Icon = 'fa-cubes', @MenuDescription = 'Inventory'
	, @PageUrl = '#'
	, @BetaUrl = ''
go
spBaseMenuInsertOrUpdate
	@RecordStatusID = 1
	, @MenuID = 3000, @ParentMenuID = 0, @DisplayOrder = 3
	, @Icon = 'fa-briefcase', @MenuDescription = 'Accounting'
	, @PageUrl = '#'
	, @BetaUrl = ''
go
spBaseMenuInsertOrUpdate
	@RecordStatusID = 1
	, @MenuID = 4000, @ParentMenuID = 0, @DisplayOrder = 5
	, @Icon = 'fa-list-alt', @MenuDescription = 'Reports'
	--, @PageUrl = '/reportviewer'
	, @PageUrl = '/ng/reportviewer'
	, @BetaUrl = '/ng/reportviewer'
go
spBaseMenuInsertOrUpdate
	@RecordStatusID = 1
	, @MenuID = 5000, @ParentMenuID = 0, @DisplayOrder = 7
	, @Icon = 'fa-question', @MenuDescription = 'Help'
	, @PageUrl = '#'
	, @BetaUrl = ''
go
spBaseMenuInsertOrUpdate
	@RecordStatusID = 1
	, @MenuID = 6000, @ParentMenuID = 0, @DisplayOrder = 4
	, @Icon = 'fa-industry', @MenuDescription = 'Production'
	, @PageUrl = '#'
	, @BetaUrl = ''
go
spBaseMenuInsertOrUpdate
	@RecordStatusID = 1
	, @MenuID = 7000, @ParentMenuID = 8000, @DisplayOrder = 5
	, @Icon = 'fa-address-card-o', @MenuDescription = 'HR'
	, @PageUrl = '#'
	, @BetaUrl = ''
go
spBaseMenuInsertOrUpdate
	@RecordStatusID = 1
	, @MenuID = 8000, @ParentMenuID = 0, @DisplayOrder = 7
	, @Icon = 'fa-cog', @MenuDescription = 'Definition Settings'
	, @PageUrl = '/Menu/Settings'
	, @BetaUrl = ''
go
select * from BaseMenu
