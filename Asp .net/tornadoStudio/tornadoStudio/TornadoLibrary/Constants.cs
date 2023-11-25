﻿using Dapper;
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
    public class Constants
    {
//        public const string FBR_INTEGRATION_URL_SANDBOX = "https://esp.fbr.gov.pk:8244/FBR/v1/api/Live/PostData";
//        public const string FBR_INTEGRATION_URL_LIVE = "https://gw.fbr.gov.pk/imsp/v1/api/Live/PostData";
//        public const string QT_ADMIN_NOTIFICATION_NUMBERS = "03324815525,03039455050";
//        public const string SESSION_KEY_ReturnUrlAfterLogin = "ReturnUrlAfterLogin";
//        public const string PAGE_SECURITY_LOGIN = "../Security/SignIn.aspx";

//#if (DEBUG == true)
//        //public const string QT_DRIVE_FOLDER = @"D:\temp\";
//        public const string QT_DRIVE_FOLDER = @"C:\qt-drive\";
//#else
//        public const string QT_DRIVE_FOLDER = @"f:\qt-drive\company-{0}\";
//#endif

//        public static string CacheStore
//        {
//            get
//            {
//                return ConfigurationManager.AppSettings["CacheStore"] ?? "local";
//            }
//        }

//        public static string AppName
//        {
//            get
//            {
//                return ConfigurationManager.AppSettings["AppName"] ?? "main";
//            }
//        }

    }

    //public static class AlertEmailSettings
    //{
    //    public static string Host
    //    {
    //        get
    //        {
    //            return ConfigurationManager.AppSettings["AlertEmailHost"];
    //        }
    //    }
    //    public static int Port
    //    {
    //        get
    //        {
    //            return Int32.Parse(ConfigurationManager.AppSettings["AlertEmailPort"]);
    //        }
    //    }
    //    public static string User
    //    {
    //        get
    //        {
    //            return ConfigurationManager.AppSettings["AlertEmailUser"];
    //        }
    //    }
    //    public static string Password
    //    {
    //        get
    //        {
    //            return ConfigurationManager.AppSettings["AlertEmailPassword"];
    //        }
    //    }
    //    public static bool EnableSsl
    //    {
    //        get
    //        {
    //            return Boolean.Parse(ConfigurationManager.AppSettings["AlertEmailEnableSsl"]);
    //        }
    //    }
    //    public static string From
    //    {
    //        get
    //        {
    //            return ConfigurationManager.AppSettings["AlertEmailFrom"];
    //        }
    //    }
    //}

    public enum SmsStatus
    {
        Ready = 1,
        Sent = 2,
        Failed = 3,
        Expired = 4,
        Canceled = 5,
        OutOfBalance = 6,
        InvalidNumber = 7,
        LocalServer = 8,
        InvalidApi = 9
    }

    public enum PaymentMethods : short
    {
        Cash = 1,
        Credit = 2,
        Bank = 3,
        Cheque = 4
    }

    public enum EmployeeTypes
    {
        Salesman = 1,
        OrderBooker = 2,
        PartyManager = 3,
    }

    public enum RecordStatuses
    {
        Unposted = 1,
        Posted = 2,
        Ready = 3,      // New document is created and no other process created
        Deleted = 4,
        InProgress = 5,
        Completed = 6,
        Canceled = 7,
        Approved = 8,
        Rejected = 9,
    }

    public enum VoucherTypes : short
    {
        JournalVoucher = 1,
        PurchaseVoucher = 2,
        SaleVoucher = 3,
        CashPaymentVoucher = 4,
        BankPaymentVoucher = 5,
        CashReceiptVoucher = 6,
        BankReceiptVoucher = 7,
        PurchaseReturnVoucher = 8,
        SaleReturnVoucher = 9,
        ExpenseVoucher = 10
    }

    public enum SystemSettings
    {
        Inventory_ItemCodeSeparator,
        Inventory_RawMaterialCodeSeparator,
        Inventory_DefaultSaleQty,

        Inv_ItemFullCodeFormat,
        Inv_Item_AutoCodeForEachCategory,
        Inv_Item_RawMaterialDecimals,
        Inv_Item_FinishedGoodDecimals,
        Inv_Item_ImageEnabled,
        Inv_Item_AutobDisableOutofStock,

        IsStockValidationEnabled,
        // sale invoice
        IsSalesInvoiceAutoPrint,
        Inv_SI_IsAutoNumberEnabled,
        Inv_SI_IsBarcodeEnabled,
        Inv_SI_IsCashReceivedMandatory,
        Inv_SI_IsCashReceivedEnabled,
        Inv_SI_IsDefaultPaymentModeEnabled,
        Inv_SI_IsDefaultPartyEnabled,
        Inv_SI_DefaultPaymentMode,
        Inv_SI_DefaultParty,
        Inv_SI_FutureDaysAllowed,
        Inv_SI_ShowExtras,
        Inv_SI_ShowPurchaseRate,
        Inv_SI_ShowSalesman,
        Inv_SI_ShowEmail,
        Inv_SI_IsDiscountEnabled,
        Inv_SI_IsRoundOffEnabled,
        Inv_SI_IsEmailMandatory,
        Inv_SI_IsFutureDateEntryEnabled,
        Inv_SI_IsItemCodePrinted,
        Inv_SI_IsItemDescriptionEnabled,
        Inv_SI_IsItemDiscountEnabled,
        Inv_SI_IsMobileMandatory,
        Inv_SI_IsPartyMandatory,
        Inv_SI_IsPastDateEntryEnabled,  // inventory - sales invoice - allow past date entry
        Inv_SI_IsPrintHeaderEnabled,
        Inv_SI_IsPrintFooterEnabled,
        Inv_SI_IsSalesTaxEnabled,
        Inv_SI_IsSalesTaxFixed,
        Inv_SI_IsSalesTaxItemLevel,
        Inv_SI_FixedSalesTax,
        Inv_SI_IsPSTEnabled,
        Inv_SI_IsIncomeTaxEnabled,
        Inv_SI_IsTaxIncludedInRate,
        Inv_SI_ShowNtnNumber,
        Inv_SI_NtnNumber,
        Inv_SI_ShowGstNumber,
        Inv_SI_GstNumber,
        //Inv_SI_IsStockVisible,
        Inv_SI_IsShowCustomerRate,
        Inv_SI_PastDaysAllowed,
        Inv_SI_PrintHeader,
        Inv_SI_PrintFooter,
        Inv_SI_WarrantyText,
        Inv_SI_PrintCopies,
        Inv_SI_PrintCopyName1,
        Inv_SI_PrintCopyName2,
        Inv_SI_PrintCopyName3,
        Inv_SI_PrintCopyName4,
        Inv_SI_PrintCopyName5,
        Inv_SI_PrintKitchenCopy,
        Inv_SI_SaleText,
        Inv_SI_IsShowStock,
        Inv_SI_Printer,
        Inv_SI_PageLength,
        Inv_SI_ShowCustomerName,
        Inv_SI_ShowCustomerAddress,
        Inv_SI_ShowQty2,
        Inv_SI_ShowQty3,
        Inv_SI_Qty2Name,
        Inv_SI_Qty3Name,
        Inv_SI_IsShowRefNumber,
        Inv_SI_ShowCustomerInfoOnPrint,
        Inv_SI_SessionPinCode,
        Inv_SI_ShowGender,
        Inv_SI_InvoiceHeaderStyle,
        Inv_SI_InvoiceHeaderImage,
        Inv_SI_InvoiceSignatureImage,
        Inv_SI_CompanyNameSize,
        Inv_SI_PrintSalesTaxInvoiceHeading,
        Inv_SI_SalesTaxInvoiceHeading,
        Inv_SI_ShowManufacturingDate,
        Inv_SI_ShowExpiryDate,
        Inv_SI_ShowBatchNo,
        SaleCreatedSmsTemplate,
        SaleCreatedSmsTemplate01,
        SaleCreatedSmsTemplate02,
        SaleCreatedSmsTemplate03,

        // grn
        Inv_GRN_PageLength,
        Inv_GRN_FutureDaysAllowed,
        Inv_GRN_IsAutoPrintEnabled,
        Inv_GRN_IsRateEditable,
        Inv_GRN_IsZeroRateAllowed,
        Inv_GRN_IsBarcodeEnabled,
        Inv_GRN_IsPartyMandatory,
        Inv_GRN_IsMobileMandatory,
        Inv_GRN_IsEmailMandatory,
        Inv_GRN_IsItemDescriptionEnabled,
        Inv_GRN_IsItemDiscountEnabled,
        Inv_GRN_IsSalesTaxEnabled,
        Inv_GRN_IsDiscountEnabled,
        Inv_GRN_IsPastDateEntryEnabled,  // inventory - grn - allow past date entry
        Inv_GRN_IsFutureDateEntryEnabled,
        Inv_GRN_IsItemCodePrinted,
        Inv_GRN_IsPrintHeaderEnabled,
        Inv_GRN_IsPrintFooterEnabled,
        Inv_GRN_IsCashPayedMandatory,
        Inv_GRN_IsCashPayedEnabled,
        Inv_GRN_PastDaysAllowed,
        Inv_GRN_PrintCopies,
        Inv_GRN_PrintSize,
        Inv_GRN_PrintHeader,
        Inv_GRN_PrintFooter,
        Inv_GRN_ReportID,
        Inv_GRN_IsShowStock,
        Inv_GRN_ShowExtras,
        Inv_GRN_IsAuto,
        Inv_GRN_IsAutoNumberEnabled,
        Inv_GRN_DefaultQty,

        // sale return
        Inv_SR_PageLength,
        Inv_SR_IsAutoPrintEnabled,
        //Inv_SR_AutoPrint,
        Inv_SR_IsRateEditable,
        Inv_SR_IsBarcodeEnabled,
        Inv_SR_IsPartyMandatory,
        Inv_SR_IsMobileMandatory,
        Inv_SR_IsEmailMandatory,
        Inv_SR_IsItemDescriptionEnabled,
        Inv_SR_IsItemDiscountEnabled,
        Inv_SR_IsSalesTaxEnabled,
        Inv_SR_IsDiscountEnabled,
        Inv_SR_IsPastDateEntryEnabled,
        Inv_SR_IsFutureDateEntryEnabled,
        Inv_SR_PastDaysAllowed,
        Inv_SR_FutureDaysAllowed,
        Inv_SR_IsItemCodePrinted,
        Inv_SR_PrintHeader,
        Inv_SR_PrintFooter,
        Inv_SR_IsPrintHeaderEnabled,
        Inv_SR_IsPrintFooterEnabled,
        Inv_SR_IsCashPayedMandatory,
        Inv_SR_IsCashPayedEnabled,
        Inv_SR_PrintCopies,
        Inv_SR_PrintSize,
        Inv_SR_IsShowStock,
        Inv_SR_IsAutoNumberEnabled,
        Inv_SR_DefaultQty,
        Inv_SR_Printer,
        Inv_SR_PrintCopyName1,
        Inv_SR_PrintCopyName2,
        Inv_SR_PrintCopyName3,
        Inv_SR_PrintCopyName4,
        Inv_SR_PrintCopyName5,
        Inv_SR_IsShowRefNumber,

        // grn return
        Inv_GrnReturn_PageLength,
        Inv_GrnReturn_IsItemDescriptionEnabled,
        Inv_GrnReturn_IsItemDiscountEnabled,
        Inv_GrnReturn_IsSalesTaxEnabled,
        Inv_GrnReturn_IsDiscountEnabled,
        Inv_GrnReturn_IsPastDateEntryEnabled,
        Inv_GrnReturn_IsFutureDateEntryEnabled,
        Inv_GrnReturn_PastDaysAllowed,
        Inv_GrnReturn_FutureDaysAllowed,
        Inv_GrnReturn_ReportID,
        Inv_GrnReturn_IsRateEditable,
        Inv_GrnReturn_IsZeroRateAllowed,
        Inv_GrnReturn_IsShowStock,
        Inv_GrnReturn_IsAutoNumberEnabled,
        Inv_GrnReturn_DefaultQty,

        // store issue note
        Inv_SIN_PageLength,
        Inv_SIN_IsPastDateEntryEnabled,
        Inv_SIN_IsFutureDateEntryEnabled,
        Inv_SIN_PastDaysAllowed,
        Inv_SIN_FutureDaysAllowed,
        Inv_SIN_IsShowStock,
        Inv_SIN_IsAutoNumberEnabled,

        // store issue note Return
        Inv_SIR_PageLength,
        Inv_SIR_IsPastDateEntryEnabled,
        Inv_SIR_IsFutureDateEntryEnabled,
        Inv_SIR_PastDaysAllowed,
        Inv_SIR_FutureDaysAllowed,
        Inv_SIR_IsShowStock,
        Inv_SIR_IsAutoNumberEnabled,

        // stock adjustment
        Inv_ADJ_PageLength,
        Inv_ADJ_IsPastDateEntryEnabled,
        Inv_ADJ_IsFutureDateEntryEnabled,
        Inv_ADJ_PastDaysAllowed,
        Inv_ADJ_FutureDaysAllowed,
        Inv_ADJ_IsShowStock,
        Inv_ADJ_IsAutoNumberEnabled,

        // transfer stock
        Inv_TST_PageLength,
        Inv_TST_IsPastDateEntryEnabled,
        Inv_TST_IsFutureDateEntryEnabled,
        Inv_TST_PastDaysAllowed,
        Inv_TST_FutureDaysAllowed,
        Inv_TST_IsAutoNumberEnabled,
        Inv_TST_IsShowStock,

        // Receive Stock
        Inv_REC_ReceiveStock,

        // Receive Production
        Inv_RPD_PageLength,

        // voucher
        Acc_Vou_PageLength,
        Acc_Vou_IsPastDateEntryEnabled,
        Acc_Vou_IsFutureDateEntryEnabled,
        Acc_Vou_IsAutoPrintEnabled,
        Acc_Vou_PrintSize,
        Acc_Vou_PrintCopies,
        Acc_Vou_PrintCopyName1,
        Acc_Vou_PrintCopyName2,
        Acc_Vou_PrintCopyName3,
        Acc_Vou_PrintCopyName4,
        Acc_Vou_PrintCopyName5,
        Acc_Vou_PastDaysAllowed,
        Acc_Vou_FutureDaysAllowed,
        Acc_IsCostCenterEnabled,
        Acc_IsSubCostCenterEnabled,
        LeafChartOfAccountLevelNo,
        Acc_GLN_PageLength,
        Acc_BGD_PageLength,

        Inv_SO_IsPastDateEntryEnabled,  // inventory - sale order - allow past date entry
        Inv_SO_IsFutureDateEntryEnabled,

        //Prod_SI_IsStockVisible,
        //Prod_SI_IsShowStock,

        // workorder
        Prod_WO_PageLength,
        Prod_WO_IsAutoNumberEnabled,
        Prod_WO_IsPastDateEntryEnabled,
        Prod_WO_IsFutureDateEntryEnabled,
        Prod_WO_PastDaysAllowed,
        Prod_WO_FutureDaysAllowed,
        Prod_WO_IsShowStock,

        // process production
        Prod_PP_PageLength,
        Prod_PP_IsAutoNumberEnabled,
        Prod_PP_IsPastDateEntryEnabled,
        Prod_PP_IsFutureDateEntryEnabled,
        Prod_PP_PastDaysAllowed,
        Prod_PP_FutureDaysAllowed,

        General_IsAccountsIntegrated,
        General_PastDaysEntry,
        General_FutureDaysEntry,
        General_EditingLockedAfterHours,
        General_EditingLockedAfterMinutes,
        General_CostingMethod,
        General_IsUnpostedEnabled,
        General_IsCommonPartyAllShops,
        General_IsShowStock,
        General_IsFbrIntegrationEnabled,
        General_IsFbrIntegrationLive,
        General_IsBetaEnabled,
        General_FbrPosID,
        General_FbrTestPosID,
        General_FbrUSIN,
        General_FbrBuyerNTN,
        General_FbrBuyerCNIC,
        General_FbrBuyerName,
        General_FbrBuyerPhoneNumber,
        General_FbrBearer,
        General_MenuStyle,

        General_smsapi,
        General_smsapiUsername,
        General_smsapiPassword,
        General_smsapiMasking,

        // Finance
        Finance_PageLength,
        Finance_IsHeadAllShops,
        Finance_IsShowStock,
        Finance_Head_IsAdditionalDiscountEnabled,

        Finance_PMT_IsAutoPrintEnabled,

        // HR
        HR_IsHREmployeeAllShops,
        HR_IsShowStock,

        // Delivery Challan
        Inv_DC_IsAutoNumberEnabled,
        Inv_DC_IsSaleRateEditable,

        // Receive Production
        Inv_RP_IsAutoNumberEnabled,

        General_SK,     // Software Key
        General_SSD,    // Software Start Date
        General_SYK,    // Software Year Key
        General_DBP,    // Database Backup Path
    }

    public enum PasswordTypes
    {
        FiveDigitNumericPassword,
        AlphaNumericPassword
    }

    public enum ItemTypes
    {
        FinishedGood = 1,
        RawMaterial = 2,
        Component = 3,
        PackOrBundle = 4,
        Collection = 5,
        NonStock = 6,
        Service = 7,
        Subscription = 8,
        Assembly = 9
    }

    public enum SizeTypes
    {
        Size = 1,
        Packing = 2
    }

    public enum CostingMethods
    {
        standard,
        average,
        salepercentage
    }

    public enum CompanyTypes
    {
        RetailStore = 1,
        GarmentsStore = 2,
        GarmentsFactory = 3,
        Pharmacy = 4,
        Restaurant = 5
    }

    public enum CompanyPackages
    {
        POS = 1,
        Crystal = 2,
        Retail = 3,
        Wholesale = 4,
        SmallManufacturing = 5,
    }

    public enum Reports
    {
        SalesInvoice = 6,
        SalesInvoiceA5 = 62,
        SalesInvoiceA4WithImages = 167,
        SalesInvoice2A5 = 175,

    }

    public enum Menus
    {
        Process = 11002,
        Purchase = 10006,
        PurchaseReturn = 10007,
        ChartOfAccount = 10008,
        Voucher = 10009,
        DeliveryChallan = 10102,
        Product = 10016,
        SaleReturn = 10017,
        //Party = 10018,
        Customer = 10018,
        Role = 10019,
        Company = 10020,
        TransferStock = 10021,
        SaleRetail = 10022,
        SaleWholesale = 10114,
        SalaryHead = 11002,
        Receipt = 10023,
        Payment = 10024,
        StockAdjustment = 10027,
        Color = 10029,
        User = 10031,
        FinancialYear = 10037,
        ItemCategory = 10041,
        ReceiveStock = 10044,
        Recipe = 10046,
        WorkOrder = 10047,
        Transfer = 10048,
        StoreIssueNote = 10049,
        ProductLine = 10067,
        ProductGroup = 10068,
        CostCenter = 10053,
        BaseBrand = 10064,
        Gender = 10069,
        Brand = 10070,
        Design = 10071,
        Style = 10072,
        Season = 10073,
        Batch = 10074,
        Lot = 10075,
        Store = 10076,
        SinRecipe = 10077,
        SinBom = 10078,
        SinReturn = 10079,
        RawMaterial = 10084,
        ReceiveProduction = 10093,
        //Employee = 10096,
        Salesman = 10096,
        SalePos = 10099,
        OfflineCompany = 10100,
        ProductionAssembly = 10110,
        TempInvoice = 10111,
        RepairingInvoice = 10112,
        Manufacturer = 10091,
        Department = 10117,
        MessagingAlert = 10121,
        Adnan = 10122,
        Hammad = 10123,
        Supplier = 10125,
        OrderBooker = 10126,
        PartyManager = 10127,
        Workflow = 11003,
    }

    public enum SaleTypes
    {
        Pos = 1,
        Retail = 2,
        Wholesale = 3
    }

    public enum SoftwareVersions
    {
        Web = 0,
        Retail = 1,
        Restaurant = 2
    }

    public enum HeadTypes
    {
        Receivable = 1,
        Payable = 2,
        Bank = 3,
        Cash = 4,
        Income = 5,
        Expenses = 6,
        Investment = 7,
        Customer = 8,
        Supplier = 9,
        Purchase = 10,
        Assets = 11
    }
}