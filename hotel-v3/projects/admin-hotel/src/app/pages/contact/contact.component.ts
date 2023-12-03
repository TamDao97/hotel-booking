import { Component, OnInit } from "@angular/core";

export interface ITabList {
    key: string;
    title: string;
    isActive: boolean;
    onChange: (e: any) => void;
}
@Component({
    selector: "app-contact",
    templateUrl: "./contact.component.html",
    styleUrls: ["./contact.component.css"],
})
export class ContactComponent implements OnInit {
    tabList: ITabList[] = [
        {
            key: "Contact",
            title: "Contact List",
            isActive: true,
            onChange: (e) => this.onChangeTab(e),
        },
        {
            key: "Question",
            title: "Question List",
            isActive: false,
            onChange: (e) => this.onChangeTab(e),
        },
    ];
    constructor() {}

    ngOnInit(): void {}

    onChangeTab(e: any): void {
        this.tabList.forEach((element, idx) => {
            if (idx == e.index) element.isActive = true;
            else element.isActive = false;
        });
    }
}
