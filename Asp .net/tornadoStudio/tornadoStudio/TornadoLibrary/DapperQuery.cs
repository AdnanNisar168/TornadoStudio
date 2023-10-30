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
        public static object GetListBySP<T>(StoredProcedures spSecUserGetLocked)
        {
            throw new NotImplementedException();
        }

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
        public static string NewNumber(DBTables table, string numberColumn)
        {
            try
            {
                //log.Debug("Started");

                var tableName = Enum.GetName(typeof(DBTables), table);
                // Had to add length due to the phone numbers in code field, they cause int overflow and also we don't want to auto increment the phone numbers.
                var sql = string.Format("SELECT CONVERT(INT, ISNULL(MAX(CONVERT(INT, {1})),0)) + 1 from {0} where CompanyID={2} and dbo.fnIsNumber({1}) = 1 and LEN({1}) <= 8", tableName, numberColumn, Common.LoginData.ImpersonateCompany.CompanyID);
                int result = 0;

                //using (var cn = new SqlConnection(Common.ConnectionString))
                //{
                //    result = cn.Query<int>(sql).FirstOrDefault();
                //}

                return result.ToString();
            }
            catch (Exception ex)
            {
                //log.Error(ex);
                throw;
            }
        }

        public static int Delete(DBTables table, string idColumn, Guid id)
        {
            try
            {
                log.Debug("Started");

                var tableName = Enum.GetName(typeof(DBTables), table);
                var parms = new DynamicParameters();

                var sql = string.Empty;
                if (Common.LoginData.ImpersonateUser.IsSuperAdmin)
                {
                    sql = string.Format("DELETE FROM {0} WHERE {1}=@{1}", tableName, idColumn);
                    parms.Add("@" + idColumn, id);
                }
                else
                {
                    sql = string.Format("DELETE FROM {0} WHERE CompanyID=@CompanyID AND {2}=@{2}", tableName, Common.LoginData.ImpersonateCompany.CompanyID, idColumn);
                    parms.Add("@CompanyID", Common.LoginData.ImpersonateCompany.CompanyID);
                    parms.Add("@" + idColumn, id);
                }

                int result = 0;

                using (var cn = new SqlConnection(Common.ConnectionString))
                {
                    result = cn.Execute(sql, parms);
                }

                return result;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
        }

        #endregion
    }
}