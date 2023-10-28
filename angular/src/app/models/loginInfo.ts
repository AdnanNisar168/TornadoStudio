export class LoginInfo {
    OriginalCompany: CompanyInfo;
    OriginalUser: UserInfo;
    ImpersonateCompany: CompanyInfo;
    ImpersonateUser: UserInfo;
    SoftwareVersion: number = 0;
    constructor() {
        this.OriginalCompany = new CompanyInfo();
        this.ImpersonateCompany = new CompanyInfo();
        this.OriginalUser = new UserInfo();
        this.ImpersonateUser = new UserInfo();
    }
}

export class CompanyInfo {
    CompanyID: number;
    CompanyCode: string;
    CompanyName: string;
    WarehouseName: string;
    Address: string;
    LandlineNumber: string;
    MobileNumber: string;
    EmailAddress: string;
    City: string;
    State: string;
    Country: string;
    CompanyLogoPath: string;
    CompanyWebsiteUrl: string;
    CompanyTypeID: number;
}

export class UserInfo {
    UserID: number;
    UserAutoID: number;
    UserName: string;
    UserFullName: string;
    IsSuperAdmin: boolean;
    IsCompanyAdmin: boolean;
    IsEmailVerified: boolean;
    WarehouseID: number;
    SupportLevel: number;
    ShopID: number;
}



