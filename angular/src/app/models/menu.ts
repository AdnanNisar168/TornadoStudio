export class Menu {
    MenuID: number;
    MenuName: string;
    PageUrl: string;
    Icon: string;
    IsViewAllowed: boolean;
    IsNewAllowed: boolean;
    IsEditAllowed: boolean;
    IsDeleteAllowed: boolean;
    IsCopyAllowed: boolean;
    IsStatusChangeAllowed: boolean;
    SubMenu: Menu[];
    showSubMenu: boolean;
    ngPageUrl: string;  // temprarily added for the html view, once all screens converted then we can remove it.
}

