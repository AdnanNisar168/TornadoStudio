IF EXISTS (SELECT * FROM sysObjects o WHERE o.[name] = 'spGetAllowedByCoIDParentMenuIDUserID')
	DROP PROC spGetAllowedByCoIDParentMenuIDUserID
go
IF EXISTS (SELECT * FROM sysObjects o WHERE o.[name] = 'spBaseMenu_GetAllowedByCoIDApplicationIDParentMenuIDUserID')
	DROP PROC spBaseMenu_GetAllowedByCoIDApplicationIDParentMenuIDUserID
go
IF EXISTS (SELECT * FROM sysObjects o WHERE o.[name] = 'spBaseMenuGetAllowedByCoIDApplicationIDParentMenuIDUserID')
	DROP PROC spBaseMenuGetAllowedByCoIDApplicationIDParentMenuIDUserID
go
-- ======================================================================
-- Author:		Faisal Saleem
-- Create date: 13-Jun-2010
-- Description:	This procedure returns the child menu entries which are 
--				allowed to the company id, user id for the given parent 
--				menu id.
--				for the role id provided.
-- ======================================================================
-- ------------ Modification History ------------------------------------
-- Author	Date		Details
-- ------   ----        -------
-- ----------------------------------------------------------------------
CREATE PROCEDURE spBaseMenuGetAllowedByCoIDApplicationIDParentMenuIDUserID
	(@CompanyID INT
	, @ParentMenuID INT
	, @UserID INT
	) WITH ENCRYPTION
AS
	DECLARE @IsBetaEnabled VARCHAR(50)

	SELECT @IsBetaEnabled = SettingValue FROM BaseSetting WHERE CompanyID=@CompanyID AND UserID=0 AND SettingID='General_IsBetaEnabled'

	SELECT
		MenuName 'MenuName', MenuID 'MenuID', PageUrl, Icon
		, CONVERT(BIT, MAX(IsViewAllowed+0)) 'IsViewAllowed', CONVERT(BIT, MAX(IsNewAllowed+0)) 'IsNewAllowed'
		, CONVERT(BIT, MAX(IsEditAllowed+0)) 'IsEditAllowed', CONVERT(BIT, MAX(IsDeleteAllowed+0)) 'IsDeleteAllowed'
		, CONVERT(BIT, MAX(IsCopyAllowed+0)) 'IsCopyAllowed', CONVERT(BIT, MAX(IsStatusChangeAllowed+0)) 'IsStatusChangeAllowed'

	FROM
		(SELECT bm.DisplayOrder, bm.MenuName, bm.MenuID
				, bm.ParentMenuID, bm.RecordStatusID, bm.StampDateTime
				, bm.StampUserID, CASE WHEN @IsBetaEnabled = 'true' AND LEN(ISNULL(BetaUrl,'')) > 0 THEN BetaUrl ELSE PageUrl END 'PageUrl', Icon
				, ISNULL(smra.IsViewAllowed, 1) 'IsViewAllowed', ISNULL(smra.IsNewAllowed, 0) 'IsNewAllowed'
				, ISNULL(smra.IsDeleteAllowed, 0) 'IsDeleteAllowed', ISNULL(smra.IsEditAllowed, 0) 'IsEditAllowed'
				, ISNULL(smra.IsCopyAllowed, 0) 'IsCopyAllowed', ISNULL(smra.IsStatusChangeAllowed, 0) 'IsStatusChangeAllowed'

			FROM	SecUser su
			INNER JOIN SecUserRoleAssociation sura
				ON su.CompanyID = sura.CompanyID AND su.UserID = sura.UserID
			INNER JOIN SecRoleMenuAssociation smra
				ON sura.CompanyID = smra.CompanyID AND sura.RoleKey = smra.RoleKey
			INNER JOIN BaseMenu bm
				ON smra.MenuID = bm.MenuID

			WHERE	
				(bm.ParentMenuID = @ParentMenuID)
				AND (su.CompanyID = @CompanyID) 
				AND (su.UserID = @UserID)
				AND smra.RecordStatusID <> 4
				AND bm.RecordStatusID <> 4
				AND ISNULL(smra.IsViewAllowed, 1) = 1

			--UNION

			--SELECT	bm.DisplayOrder, bm.MenuName, bm.MenuID, bm.ParentMenuID, bm.RecordStatusID, bm.StampDateTime
			--		, bm.StampUserID, PageUrl, Icon
			--		, CONVERT(BIT, 1) 'IsViewAllowed', CONVERT(BIT, 1) 'IsNewAllowed'
			--		, CONVERT(BIT, 1) 'IsDeleteAllowed', CONVERT(BIT, 1) 'IsEditAllowed'
			--		, CONVERT(BIT, 1) 'IsCopyAllowed', CONVERT(BIT, 1) 'IsStatusChangeAllowed'

			--FROM	BaseMenu bm
			--WHERE	(bm.ParentMenuID = @ParentMenuID)
			--	AND (@UserID <= 0)
			--	AND bm.RecordStatusID <> 4
		) a
	GROUP BY MenuName, MenuID, PageUrl, Icon, DisplayOrder
	ORDER BY DisplayOrder

/*
RecordStatusID = 4  Deleted
*/
GO
/*
spBaseMenuGetAllowedByCoIDApplicationIDParentMenuIDUserID
	@CompanyID=1, @ParentMenuID=0, @UserID=7
*/
