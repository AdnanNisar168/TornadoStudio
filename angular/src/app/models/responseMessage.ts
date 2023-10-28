export class ResponseMessage {
    http_code: number;
    menuId: number;
    title: string;
    message: string;
    broken_rules: string[];
    data: any;
    show: boolean = false;
    yesButton: string = "Ok";
    noButton: string = "";
    yesClicked: boolean = false;
    noClicked: boolean = false;
    accessToken: any;

    constructor() {
        this.broken_rules = [];
        //this.show = true;
    }
}
