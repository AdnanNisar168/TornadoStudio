import { NgbDate } from "@ng-bootstrap/ng-bootstrap/datepicker/ngb-date";

export enum Dashboards {
    ShopSaleChart = 1,
    SaleForDay = 2,
    ProductionForDay = 3,
    CategoryPurchaseToProfit = 4,
    PendingDeliveryChallan = 5,
    ActiveCompanies = 6,
    CategoryStock = 7,
    Receivables = 8,
    StockJobs = 9,
    UnlockedUser = 10,
    Sales = 11
}

export enum RecordStatuses {
    Posted = 2,
    Ready = 3,
    InProgress = 5,
    Completed = 6,
    Canceled = 7,
}

export enum SystemSettings {
    Inv_SI_PrintFooter = 'Inv_SI_PrintFooter',
    Inv_SI_GstNumber = 'Inv_SI_GstNumber',
    Inv_SI_ShowGstNumber = 'Inv_SI_ShowGstNumber',
    Inv_SI_IsPrintHeaderEnabled = 'Inv_SI_IsPrintHeaderEnabled',
    Inv_SI_PrintHeader = 'Inv_SI_PrintHeader',
    General_IsFbrIntegrationEnabled = 'General_IsFbrIntegrationEnabled',
    Inv_SI_ShowNtnNumber = 'Inv_SI_ShowNtnNumber',
    Inv_SI_NtnNumber = 'Inv_SI_NtnNumber',
    Inv_SI_SessionPinCode = 'Inv_SI_SessionPinCode',
    Inv_GrnReturn_IsSalesTaxEnabled = 'Inv_GrnReturn_IsSalesTaxEnabled',
    Inv_GrnReturn_IsDiscountEnabled = 'Inv_GrnReturn_IsDiscountEnabled',
    Inv_GrnReturn_IsItemDescriptionEnabled = 'Inv_GrnReturn_IsItemDescriptionEnabled',

    //Sale Return
    Inv_SR_IsSalesTaxEnabled = 'Inv_SR_IsSalesTaxEnabled',
    Inv_SR_IsDiscountEnabled = 'Inv_SR_IsDiscountEnabled',
    Inv_SR_IsItemDiscountEnabled = 'Inv_SR_IsItemDiscountEnabled',
    Inv_SR_IsAutoNumberEnabled = 'Inv_SR_IsAutoNumberEnabled',
    Inv_SR_IsItemDescriptionEnabled = 'Inv_SR_IsItemDescriptionEnabled',
    Inv_SR_IsShowStock = 'Inv_SR_IsShowStock',
    Inv_SR_IsRateEditable = 'Inv_SR_IsRateEditable',
    Inv_SR_DefaultQty = 'Inv_SR_DefaultQty',
    Inv_SR_PastDaysAllowed = 'Inv_SR_PastDaysAllowed',
    Inv_SR_IsPastDateEntryEnabled = 'Inv_SR_IsPastDateEntryEnabled',
    Inv_SR_FutureDaysAllowed = 'Inv_SR_FutureDaysAllowed',
    Inv_SR_IsFutureDateEntryEnabled = 'Inv_SR_IsFutureDateEntryEnabled',
    Inv_SR_IsAutoPrintEnabled = 'Inv_SR_IsAutoPrintEnabled',
    General_MenuStyle = 'General_MenuStyle',

    //SIN General
    Inv_SIN_IsAutoNumberEnabled = 'Inv_SIN_IsAutoNumberEnabled', 
    Inv_SIN_IsShowStock = 'Inv_SIN_IsShowStock', 
    Inv_SIN_IsPastDateEntryEnabled = 'Inv_SIN_IsPastDateEntryEnabled', 
    Inv_SIN_IsFutureDateEntryEnabled = 'Inv_SIN_IsFutureDateEntryEnabled', 
    Inv_SIN_PastDaysAllowed = 'Inv_SIN_PastDaysAllowed', 
    Inv_SIN_FutureDaysAllowed = 'Inv_SIN_FutureDaysAllowed', 

    //SIN Return
    Inv_SIR_IsAutoNumberEnabled = 'Inv_SIR_IsAutoNumberEnabled', 
    Inv_SIR_IsShowStock = 'Inv_SIR_IsShowStock', 
    Inv_SIR_IsPastDateEntryEnabled = 'Inv_SIR_IsPastDateEntryEnabled', 
    Inv_SIR_IsFutureDateEntryEnabled = 'Inv_SIR_IsFutureDateEntryEnabled', 
    Inv_SIR_PastDaysAllowed = 'Inv_SIR_PastDaysAllowed', 
    Inv_SIR_FutureDaysAllowed = 'Inv_SIR_FutureDaysAllowed', 

}

export enum Menus {
    Dashboard = 10001,
    Inventory = 10002,
    Accounting = 10003,
    ReportViewer = 10004,
    Help = 10005,
    Purchase = 10006,
    PurchaseReturn = 10007,
    ChartOfAccount = 10008,
    Voucher = 10009,
    DefinitionSettings = 10010,
    Messaging = 10011,
    Warehouse = 10012,
    ContactUs = 10013,
    FAQs = 10014,
    Security = 10015,
    Product = 10016,
    SalesReturn = 10017,
    Customer = 10018,
    Role = 10019,
    Company = 10020,
    TransferStock = 10021,
    SalesInvoice = 10022,
    Receipt = 10023,
    Payment = 10024,
    GLNote = 10025,
    ShopUser = 10026,
    StockAdjustment = 10027,
    ItemVariation = 10028,
    Color = 10029,
    Head = 10030,
    User = 10031,
    SalesOrder = 10032,
    AutoVoucherSetting = 10033,
    ApproveVoucher = 10034,
    Pricing = 10035,
    News = 10036,
    FinancialYear = 10037,
    DayBook = 10038,
    AttributeCategory = 10039,
    Attribute = 10040,
    ItemCategory = 10041,
    Sms = 10042,
    Size = 10043,
    ReceiveStock = 10044,
    DailyExpense = 10045,
    Recipe = 10046,
    WorkOrder = 10047,
    Transfer = 10048,
    SINGeneral = 10049,
    AllVouchers = 10050,
    Log = 10051,
    Budget = 10052,
    CostCenter = 10053,
    SubCostCenter = 10054,
    Finance = 10055,
    PurchaseOrder = 10056,
    IGP = 10057,
    OGP = 10058,
    Common = 10059,
    SoftwareBrand = 10064,
    ReportRights = 10065,
    Stock = 10066,
    ProductLine = 10067,
    ProductGroup = 10068,
    Gender = 10069,
    Brand = 10070,
    Design = 10071,
    Style = 10072,
    Season = 10073,
    Batch = 10074,
    Lot = 10075,
    Store = 10076,
    SINRecipe = 10077,
    SINBOM = 10078,
    SinReturnGeneral = 10079,
    SinReturnRecipe = 10080,
    SINReturnBOM = 10081,
    Desktop = 10082,
    Adjustment = 10083,
    RawMaterial = 10084,
    Tax = 10085,
    Discount = 10086,
    ItemRate = 10087,
    PMS = 10088,
    Ticket = 10089,
    ImportProducts = 10090,
    Manufacturer = 10091,
    Packing = 10092,
    ReceiveProduction = 10093,
    ItemLevels = 10094,
    Salesman = 10096,
    empty = 10097,
    MenuRole = 10098,
    SalePOS = 10099,
    OfflineCompany = 10100,
    Order = 10101,
    DeliveryChallan = 10102,
    CompanyPayment = 10103,
    CompanyProfile = 10104,
    Shop = 10105,
    Integration = 10106,
    QTLibrary = 10107,
    ReportGroup = 10108,
    Session = 10109,
    Assembly = 10110,
    TempInvoice = 10111,
    RepairingInvoice = 10112,
    ImportItems = 10113,
    Wholesale = 10114,
    ActiveUser = 10115,
    LoginHistory = 10116,
    Department = 10117,
    QTDrive = 10118,
    SalaryHead = 10119,
    CommonJob = 10120,
    Alert = 10121,
    CompanyData = 10122,
    WholeSalesReturn = 10123,
    DeliveryChallanWholeSale = 10124,
    Supplier = 10125,
    OrderBooker = 10126,
    PartyManager = 10127,
    ProductionDashboard = 11001,
    Process = 11002,
    Workflow = 11003,

    
}
export class Common {

    static agNumberFormatter(params) {
        var result = Math.floor(params.value)
            .toString()
            .replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,");

        result = result === '0' ? '' : result;
        result = params.value < 0 ? '(' + result.replace('-','') + ')' : result;

        return result;
    }

    static agDecimalNumberFormatter(params) {
        var result = (Math.round((params.value + Number.EPSILON) * 100) / 100)
            .toString()
            .replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,");

        result = result === '0' ? '' : result;
        result = params.value < 0 ? '(' + result.replace('-', '') + ')' : result;

        return result;
    }

    static getDateStringFromNgDate(ngDate: NgbDate) {
        var months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
        var result: string;

        if (typeof ngDate == 'object' && ngDate != null) {
            result = ngDate.day + '-' + months[ngDate.month - 1] + '-' + ngDate.year;

        } else if (typeof ngDate == 'string') {
            result = ngDate;

        } else {
            result = null;

        }

        return result;
    }
}
