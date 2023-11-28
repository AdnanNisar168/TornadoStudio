using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Configuration;

namespace tornadoStudio.TornadoLibrary
{
    public partial class DapperQuery
    {
        #region "Declaration"

        public enum DBTables
        {
            AccountingAutoVoucherSetting,
            AccountingBudget,
            AccountingBudgetDetail,
            AccountingChartOfAccount,
            AccountingCostCenter,
            AccountingFinancialYear,
            AccountingGLNote,
            AccountingGLNoteDetail,
            AccountingVoucher,
            AccountingVoucherDetail,
            AccountingVoucherType,
            AccountingSubCostCenter,
            BaseBrand,
            BaseCompany,
            BaseCompanyPackage,
            BaseCompanyPackageEntryLimit,
            BaseCompanyProfile,
            BaseCompanyPayment,
            BaseCompanyTypes,
            BaseFile,
            BaseMenu,
            BaseSetting,
            BaseShop,
            CommonGroup,
            CommonJob,
            CommonSession,
            CommonParty,
            CommonPartySummary,
            CommonPartyShopAssociation,
            FinanceHead,
            FinanceHeadType,
            FinancePayment,
            FinancePaymentDetail,
            FinanceReceipt,
            FinanceReceiptDetail,
            FinanceAdjustment,
            FinanceAdjustmentDetail,
            FinanceExpense,
            FinanceHeadShopAssociation,

            //HR
            HRDepartment,
            HREmployee,
            HREmployeeShopAssociation,
            HrSalaryHead,
            TestUser,

            //Inventory
            InvBatch,
            InvBrand,
            InvColor,
            InvDesign,
            InvItem,
            InvItemStock,
            InvItemSummary,
            InvItemVariation,
            InvItemVariationLevel,
            InvItemCategory,
            InvIGP,
            InvIGPDetail,
            InvOGP,
            InvOGPDetail,
            InvWarehouse,
            InvGender,
            InvGoodsReceiptNote,
            InvGoodsReceiptNoteDetail,
            InvGoodsReceiptNoteExtra,
            InvProductGroup,
            InvProductLine,
            InvManufacturerPartyAssociation,
            InvPartyRate,
            InvPurchaseOrderDetail,
            InvPurchaseOrder,
            InvGrnReturn,
            InvGrnReturnDetail,
            InvReceiveProduction,
            InvReceiveProductionDetail,
            InvRepairingInvoice,
            InvRepairingInvoiceDetail,
            InvRepairingInvoiceExtra,
            InvDeliveryChallan,
            InvDeliveryChallanDetail,
            InvManufacturer,
            InvLot,
            InvSale,
            InvSaleDetail,
            InvSaleReturn,
            InvSaleReturnDetail,
            InvSaleExtra,
            InvStoreIssueNoteDetail,
            InvStoreIssueNote,
            InvSinReturnDetail,
            InvSinReturn,
            InvSize,
            InvStyle,
            InvStore,
            InvSeason,
            InvTransferStock,
            InvTransferStockDetail,
            InvStockAdjustment,
            InvStockAdjustmentDetail,
            InvTempInvoice,
            InvTempInvoiceDetail,

            // Messaging
            MessagingAlert,
            MessagingAlertAnswer,
            MessagingMobileMessage,
            MessagingAlertTarget,

            // Production
            ProdAssembly,
            ProdAssemblyDetail,
            ProdConOrder,
            ProdFormula,
            ProdFormulaDetail,
            ProdOrder,
            ProdOrderDetail,
            ProdOrderRawMaterial,
            ProdOrderStatus,
            ProdProcess,
            ProdProcessProduction,
            ProdProcessProductionDetail,
            ProdProcessWorkFlow,

            // Security
            SecRole,
            SecRoleDashboardAssociation,
            SecRoleReportAssociation,
            SecRoleStatusAssociation,
            SecRoleMenuAssociation,
            SecUser,
            SecUser2,
            SecUserRoleAssociation,
            SecUserLoginHistory,

            // Views
            vwItemSummary,
            vwItemSummary2,
            vwItem,
            vwItemLedger,
            vwFinanceHeadTypeSummary,
            vwPartyLedgerSummary,
        }

        public enum StoredProcedures
        {
            spAccountingChartOfAccountGetIndentedByCompanyID,
            spAccountingGLNoteGetByCompanyIDGLNoteID,
            spAccountingAutoVoucherSettingGetAll,
            spAccountingBudgetGetByComapnyIDBudgetID,
            spAccountingVoucherGetByCompanyIDSortingPaging,
            spAccountingVoucherGetByCompanyIDVoucherID,
            spAccountingCostCenterGetByCompanyIDSortingPaging,
            spAccountingCostCenterGetByCostCenterID,
            spAccountingSubCostCenterGetByCompanyIDSortingPaging,
            spAccountingFinancialYearGetByCompanyIDSortingPaging,
            spAccountingFinancialYearGetByFinancialYearID,

            spCommonSessionGetCurrent,
            spBaseBrandGetByBrandIDSortingPaging,
            spBaseBrandGetByBrandID,
            spBaseCompanyPaymentGetOverduePayments,
            spBaseCompanySetupForCrystal,
            spBaseCompanyChangeCompanyID,
            spBaseCompanyDeleteAllData,
            spBaseCompanyDeleteAllDataByCompanyKey,
            spBaseCompanyGetBySortingPaging,
            spBaseCompanyGetTopActiveCompanies,
            spBaseCompanyPaymentGetByYear,
            spBaseCompanyPaymentAssert,
            spBaseCompanyTypicalSettingForShop,
            spBaseCompanyGetByCompanyKey,
            spBaseMenuGetAllowedByCoIDApplicationIDParentMenuIDUserID,
            spBaseReportGetActiveByParentIDUserAutoID,
            spBaseReportGetAllowedByUserAutoID,
            spBaseSettingGetByCompany,
            spGetCompanySettingsByCompnayKeyUserKey,
            spBaseReportGetAllowedByParentReportIDRoleAutoID,

            spCommonDashboardGetAllowedByUserAutoID,
            spCommonGroupGetByCompanyIDSortingPaging,
            spCommonJobGetPending,
            spCommonJobInsertVerifyStock,
            spCommonJobGenerateForDocumentUpdate,
            spCommonJobRecalculateStock,
            spCommonJobRecalculateStockForCurrentMonth,
            spCommonPartyShopAssociationWithStatus,
            spCommonPartyGetByCompanyIDPartyKey,
            spCommonRecordStatusGetAllowedByMenuIDUserAutoID,
            spCompanyProfileGetByCompanyIDCompanyProfileID,
            spCompanyProfileGetByCompanyIDSortingPaging,
            spCommonGroupGetByCompanyIDGroupID,
            spDashboardInvWarehouseSale,
            spDashboardCategoryPurchaseToProfit,
            spDashboardShopSale,
            spDashboardCategoryStock,
            spDashboardFinanceHeadClosing,
            spPartyGetByCompanyIDSortingPaging,
            spHREmployeeShopAssociationWithStatus,
            spHrEmployeeGetByEmployeeID,
            spHRDepartmentGetByCompanyIDSortingPaging,
            spHRSalaryHeadGetByCompanyIDSortingPaging,
            spHrSalaryHeadGetBySalaryHeadD,
            spLogGetByCompanyIDSortingPaging,
            spShopGetByCompanyIDShopID,
            spMessagingSmsGetByCompanyIDSortingPaging,
            spNewNumberByCompanyIDFormat,
            spPartyGetClosingBalance,
            // HR
            spHrDepartmentGetByDeparmentID,
            spHREmployeeGetByCompanyIDSortingPaging,
            spSecUser2GetByUserKey,
            spSecUser2GetByCompanyIDSortingPaging,
            spSecUser2GetByUserKey2,
            spTestUserGetByCompanyIDSortingPaging,
            spTestUserGetByUserKey,

            // Inventory
            spInvBatchGetByCompanyIDSortingPaging,
            spInvBatchGetByBatchID,
            spInvBrandGetByCompanyIDSortingPaging,
            spInvBrandGetByBrandID,
            spInvColorGetByCompanyIDSortingPaging,
            spInvColorGetByColorID,
            spInvDeliveryChallanGetPending,
            spAccountingBudgetGetByCompanyIDSortingPaging,
            spInvDeliveryChallanGetByCompanyIDSortingPaging,
            spInvDeliveryChallanGetByCompanyIDDeliveryChallanID,
            spInvDeliveryChallanUpdateSaleQty,
            spInvDesignGetByCompanyIDSortingPaging,
            spInvDesignGetByDesignID,
            spInvGoodsReceiptNoteGetByCompanyIDGoodsReceiptNoteID,
            spInvGoodsReceiptNoteGetByCompanyIDSortingPaging,
            spInvGrnReturnGetByCompanyIDSortingPaging,
            spInvGrnReturnGetByCompanyIDGrnReturnID,
            spInvGenderGetByCompanyIDSortingPaging,
            spInvGenderGetByGenderID,
            spInvItemGetByCompanyIDItemVariationKey,
            spInvItemSummaryUpdateByItemVariationKeys,
            spInvItemGetByCompanyIDSortingPaging,
            spInvItemGetForItemRate,
            spInvItemCategoryGetByCompanyIDSortingPaging,
            spInvItemCategoryGetByCompanyIDItemCategoryID,
            spInvItemGetReorderForPurchaseOrder,
            spInvItemDeleteByCompanyIDItemTypeID,
            spInvItemNewCodeGetByCompanyIDItemCategoryKey,
            spInvItemSummaryByItemVariations,
            spInvItemSummaryByItemVariations2,
            spInvItemForDropdown,
            spInvItemListFullDetail,
            spInvItemGetByCompanyIDItemKey,
            spInvItemSummaryRecalculate,
            spInvItemStockUpdate,
            spInvItemVariationUpdateItemFullCodeFormatted,
            spInvItemVariationLevelGetByWarehouseID,
            spInvIGPGetbyCompanyIDSortingPaging,
            spInvRawMaterialGetForItemRate,
            spInvManufacturerPartyAssociationGetAssigned,
            spInvManufacturerGetByManufacturerID,
            spInvOgpGetByCompanyIDSortingPaging,
            spInvIGPGetByCompanyIDIGPKey,
            spInvOGPGetByCompanyIDOGPKey,
            spInvProductGroupGetByCompanyIDSortingPaging,
            spInvPurchaseOrderGetByCompanyIDSortingPaging,
            spInvProductGroupGetByProductGroupID,
            spInvProductLineGetByProductLineID,
            spInvReceiveProductionGetByCompanyIDSortingPaging,
            spInvReceiveProductionGetByCompanyIDReceiveProductionID,
            spInvRepairingInvoiceGetByCompanyIDSortingPaging,
            spInvRepairingInvoiceGetByInvoiceKey,
            spInvSaleGetByCompanyIDSaleID,
            spInvSaleGetByCompanyIDSortingPaging,
            spInvSaleReturnGetByCompanyIDSaleReturnID,
            spInvSaleReturnGetByCompanyIDSortingPaging,
            spInvSizeGetByCompanyIDSortingPaging,
            spInvSinReturnGetByCompanyIDSortingPaging,
            spInvSizeGetByCompanyIDOrderBySizeCode,
            spInvStoreIssueNoteReturnGetByCompanyIDStoreIssueNoteID,
            spInvStoreIssueNoteGetByCompanyIDSortingPaging,
            spInvStockAdjustmentGetByCompanyIDStockAdjustmentID,
            spInvStockAdjustmentGetByCompanyIDSortingPaging,
            spInvStoreGetByStoreID,
            spInvStyleGetByCompanyIDSortingPaging,
            spInvStoreGetByCompanyIDSortingPaging,
            spInvTransferStockDetailByMinimumStockLevel,
            spInvTempInvoiceGetByCompanyIDSortingPaging,
            spInvTempInvoiceGetByCompanyIDTempInvoiceKey,
            spInventoryItemWithoutSizesForDropdown,
            spInventoryWarehouseGetByCompanyIDSortingPaging,
            spInventoryOgpGetByCompanyIDSortingPaging,
            spInventoryShopGetByCompanyIDSortingPaging,
            spInventorySaleOrderGetByCompanyIDSortingPaging,
            spInvLotGetByCompanyIDSortingPaging,
            spInvLotGetByLotID,
            spInvSeasonGetByCompanyIDSortingPaging,
            spInvSeasonGetBySeasonID,
            spInvStyleGetByStyleID,

            spReportInvRepairigSaleSummary,
            spReportInvRepairigSaleItemized,
            spReportRepairingInvoice,
            spReportProdReceiveProductionListSizeWise,
            spReportPurchaseDetail,
            spReportInvPurchaseByItemCategory,
            spReportInvPurchaseByYear,
            spReportInvPurchaseByMonth,
            spReportInvTransferStockItemized,
            spReportInvTransferStockSummary,
            spReportSalesInvoiceCustomerBalance,
            spReportShopSaleDiscountsByMonth,
            spReportTempInvoice,
            spInvStoreIssueNoteGetByCompanyIDStoreIssueNoteID,
            spCommonJobGetListBySortingPaging,
            spReportInvSaleBySalesmanAndItem,

            //PMS
            spPmsTicketGetByCompanyIDSortingPaging,

            //Production
            spProdAssemblyGetByCompanyIDAssemblyKey,
            spProdAssemblyGetByCompanyIDSortingPaging,
            spProdConOrderGetByCompanyIDSortingPaging,
            spProdFormulaGetByCompanyIDFormulaID,
            spProdFormulaGetByCompanyIDSortingPaging,
            spProdProcessStockByCompanyIDOrderIDWorkflowID,
            spProdProcessWorkflowGetByCompanyIDWorkflowID,
            spProdProcessWorkFlowGetByCompanyID,
            spProdProcessStatusRecalculate,
            spProdProcessGetByProcessID,
            spProdOrderGetInCompleteByCompanyID,
            spProdOrderGetByCompanyIDOrderID,
            spProdOrderDetailGetForReceiveProductionByCompanyIDOrderID,
            spProdOrderGetRequiredRawMaterialsByCompanyIDItemVariationKey,
            spProdOrderGetRawMaterialsByOrderID,
            spProdProcessWorkflowGetByCompanyIDSortingPaging,
            spProdProcessGetByCompanyIDSortingPaging,
            spProdProcessProductionGetByCompanyIDSortingPaging,
            spProdProcessProductionByComapnyIDProcessProductionID,
            spReportProdProductionAssembly,
            spReportProdReceiveProductionList,
            spReportProdOrderIssuances,

            //Finance
            spFinanceAdjustmentGetByCompanyIDAdjustmentID,
            spFinanceAdjustmentGetByCompanyIDSortingPaging,
            spFinanceExpenseGetByCompanyIDSortingPaging,
            spFinanceHeadShopAssociationWithStatus,
            spFinanceHeadGetByCompanyIDSortingPaging,
            spFinanceReceiptGetByCompanyIDReceiptID,
            spFinanceReceiptGetByCompanyIDSortingPaging,
            spFinancePaymentGetByCompanyIDSortingPaging,
            spFinancePaymentGetByCompanyIDPaymentID,
            spFinanceHeadShopAssociationGetAll,

            //Base
            spBaseCompanyGetTableRowCount,

            // Messaging
            spMessagingAlertGetPending,
            spMessagingAlertGetByAlertKeySortingPaging,
            spMessagingAlertGetByAlertKey,

            //Report
            spReportBudget,
            spReportCommonContacts,
            spReportCompanyStock,
            spReportCompanyOverview,
            spReportFinanceCustomerLedgerSummary,
            spReportFinanceCustomerRecoverySheet,
            spReportSaleSummaryByPartySizeWise,
            spReportSaleSummarySizeWise,
            spReportFinanceHeadLedger,
            spReportFinanceHeadLedgerSummary,
            spReportGeneralLedger,
            spReportItemIncomeStatement,
            spReportInvDeadItems,
            spReportInvPendingDeliveryChallans,
            spReportInvPendingDeliveryChallansItemized,
            spReportInvInventoryActivity,
            spReportInvPurchasesSizeWise,
            spReportInvPurchaseReturnDetailSizeWise,
            spReportSaleSummaryDynamicGroup,
            spReportInvSaleByItem,
            spReportInvBardCode,
            spReportStock,
            spReportStock2,
            spReportInvSeasonStock,
            spReportInvStockByWarehouse,
            spReportStockRegister,
            spReportStockRegisterSize,
            spReportAccTrialBalance,
            spReportAccTrialBalance2,
            spReportAccountingMonthlySummary,
            spReportInvCategoryWiseStock,
            spReportInvDayEnd,
            spReportInvStoreIssnueNoteGeneralList,
            spReportInvStoreIssnueNoteReceipeList,
            spReportInvStockTransfersSizeWise,
            spReportInvSaleByPaymentMode,
            spReportInvSaleByItemCategoryWithProfit,
            spReportInvSaleByItemProductGroup,
            spReportInvRawMaterialStock,
            spReportInvSalesSizeWise,
            spReportInvSaleReturnsSizeWise,
            spReportInvProcessWiseIssuanceAndReturn,
            spReportInvPurchaseReturnsSizeWise,
            spReportInvPurchaseDetailSizeWise,
            spReportInvSalesAndReturnsSizeWise,
            spReportInvSaleItemized,
            spReportInvStockTransfersDetailSizeWise,
            spReportInvStockMovement,

            spReportFinanceReceiptsSummaryByPartyManager,
            spReportFinanceReceiptsMonthSummaryByCustomer,
            spReportFinancePaymentsSummaryByPartyManager,
            spReportFinanceHeadLedgerDetail,
            spReportFinanceReceiptsList,
            spReportYearBudget,
            spReportProdProcessStatusSizeWise,
            spReportSecUserActivity,
            spReportUnbalancedVouchers,
            spReportVouchersBalanceSummary,

            //Security
            spSecStatusAllowed,
            spSecRoleDashboardAssociationWithStatus,
            spSecRoleGetAssignedToMenu,
            spSecRoleGetByCompanyIDSortingPaging,
            spSecRoleGetByRoleID,
            spSecRoleMenuAssociationWithStatusGetbyCompanyIDRoleIDParentMenuID,
            spSecRoleMenuAssociationGetByRoleKey,
            spSecUserGetBySortingPaging,
            spSecUserGetByCompanyIDUserID,
            spSecUserGetShopUsersByCompanyIDSortingPaging,
            spStatusRoleAssociationGetStatus,
            spSecRoleCreateCopy,
            spWarehouseGetByCompanyIDWarehouseID,
            spSecUserGetLoginHistoryList,
            spSecUserGetActiveUserList,
            spSecUserGetLocked,

            // Account
            spReportAccChartOfAccountAging,
            spReportAccountingAccountsPayable,
            spReportFinanceHeadTypeMonthly,
            spReportFinancialActivity,
            spProdConOrderOutGetByCompanyIDSortingPaging,
            spInvProductLineGetByCompanyIDSortingPaging,
        }

        //for checking user is locked or not and giving him access
        //public static object GetListBySP<T>(StoredProcedures spSecUserGetLocked)
        //{
        //    throw new NotImplementedException();
        //}
        //dapper stored
        public static List<T> GetListBySP<T>(StoredProcedures storedProcedure, DynamicParameters spParams)
        {
            return GetListBySP<T>(storedProcedure, spParams, 1 * 60);
        }

        public static List<T> GetListBySP<T>(StoredProcedures storedProcedure, DynamicParameters spParams, int timeout)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ConnectionString;

            var result = new List<T>();

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    result = cn.Query<T>(Enum.GetName(typeof(StoredProcedures), storedProcedure), spParams, commandType: CommandType.StoredProcedure, commandTimeout: timeout).ToList();
                }
            }
            catch (Exception ex)
            {
                var paramString = " Parameters=" + string.Join(", ", from pn in spParams.ParameterNames select string.Format("@{0}={1}", pn, (spParams as SqlMapper.IParameterLookup)[pn]));
                var ex1 = new Exception(storedProcedure.ToString() + paramString, ex);
                //log.Error(ex1);
                Console.WriteLine("error is :", ex1);
                throw ex;
            }

            return result;
        }
        //dapper stored

        //dapper save
        //public static List<T> SaveChanges<T>(DBTables table, List<T> modelList)
        //{

        //}

        public T Save<T>(T entity) where T : class
        //public static List<T> SaveChanges<T>(DBTables table, List<T> modelList)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ConnectionString;
            //IDbConnection dbConnection = new SqlConnection(connectionString);
            SqlConnection dbConnection = new SqlConnection(connectionString);
            var type = typeof(T);
            var properties = type.GetProperties();
            var keyProperty = properties.FirstOrDefault(p => p.Name == "Id");
            var keyVal = keyProperty?.GetValue(entity);

            string sql;

            // Assuming 'Id' is the key and is of type 'int'
            if (keyVal == null || (int)keyVal == 0)
            {
                // Insert
                var columnNames = string.Join(", ", properties.Select(p => p.Name));
                var columnValues = string.Join(", ", properties.Select(p => "@" + p.Name));
                sql = $"INSERT INTO {type.Name} ({columnNames}) VALUES ({columnValues})";
            }
            else
            {
                // Update
                var setClause = string.Join(", ", properties.Where(p => p.Name != "Id").Select(p => $"{p.Name} = @{p.Name}"));
                sql = $"UPDATE {type.Name} SET {setClause} WHERE Id = @Id";
            }

            dbConnection.Execute(sql, entity);
            return entity;
        }
        //dapper save

        // dapper select

        // dapper select

        public enum QueryTypes
        {
            Select,
            SelectOne,
            Insert,
            Update,
            Delete
        }

        public string Query { get; set; }
        public DynamicParameters sqlParams { get; set; }
        #endregion

        #region "General"
        //public static string NewNumber(DBTables table, string numberColumn)
        //{
        //    try
        //    {
        //        //log.Debug("Started");

        //        var tableName = Enum.GetName(typeof(DBTables), table);
        //        // Had to add length due to the phone numbers in code field, they cause int overflow and also we don't want to auto increment the phone numbers.
        //        var sql = string.Format("SELECT CONVERT(INT, ISNULL(MAX(CONVERT(INT, {1})),0)) + 1 from {0} where CompanyID={2} and dbo.fnIsNumber({1}) = 1 and LEN({1}) <= 8", tableName, numberColumn, Common.LoginData.ImpersonateCompany.CompanyID);
        //        int result = 0;

        //        //using (var cn = new SqlConnection(Common.ConnectionString))
        //        //{
        //        //    result = cn.Query<int>(sql).FirstOrDefault();
        //        //}

        //        return result.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        //log.Error(ex);
        //        throw;
        //    }
        //}

        //public static int Delete(DBTables table, string idColumn, Guid id)
        //{
        //    try
        //    {
        //        log.Debug("Started");

        //        var tableName = Enum.GetName(typeof(DBTables), table);
        //        var parms = new DynamicParameters();

        //        var sql = string.Empty;
        //        if (Common.LoginData.ImpersonateUser.IsSuperAdmin)
        //        {
        //            sql = string.Format("DELETE FROM {0} WHERE {1}=@{1}", tableName, idColumn);
        //            parms.Add("@" + idColumn, id);
        //        }
        //        else
        //        {
        //            sql = string.Format("DELETE FROM {0} WHERE CompanyID=@CompanyID AND {2}=@{2}", tableName, Common.LoginData.ImpersonateCompany.CompanyID, idColumn);
        //            parms.Add("@CompanyID", Common.LoginData.ImpersonateCompany.CompanyID);
        //            parms.Add("@" + idColumn, id);
        //        }

        //        int result = 0;

        //        using (var cn = new SqlConnection(Common.ConnectionString))
        //        {
        //            result = cn.Execute(sql, parms);
        //        }

        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(ex);
        //        throw;
        //    }
        //}

        #endregion
    }
}