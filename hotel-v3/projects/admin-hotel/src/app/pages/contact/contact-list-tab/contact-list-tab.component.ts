import { Component, OnInit } from "@angular/core";
import { ContactService } from "../../../_service/contact.service";
import { Paging } from "../../../models/paging";

@Component({
    selector: "app-contact-list-tab",
    templateUrl: "./contact-list-tab.component.html",
    styleUrls: ["./contact-list-tab.component.css"],
})
export class ContactListTabComponent implements OnInit {
    contacts: any[] = [];
    filter: any = { ...Paging };
    constructor(private contactService: ContactService) {}

    ngOnInit(): void {
        this.search();
    }

    search() {
        this.contactService.getAllContact(this.filter).subscribe((res) => {
            this.contacts = res?.data?.gridData;
            this.filter.totalData = res?.data?.totalData;
        });
    }

    clearSearch() {
        this.filter.keyWord = null;
        this.search();
    }

    onPageChange(e: any) {
        this.filter.pageSize = e.pageSize;
        this.search();
    }
}
