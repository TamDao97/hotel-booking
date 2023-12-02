import { Component, OnInit } from "@angular/core";
import { Staff } from "../../models/staff.model";
import { ApiService } from "../../_service/api.service";

@Component({
    selector: "app-contact",
    templateUrl: "./contact.component.html",
    styleUrls: ["./contact.component.css"],
})
export class ContactComponent implements OnInit {
    Accounts: Staff[] = [];
    roomTypeResult: Staff[] = [];
    numAccount!: number;
    numbBookings!: number;
    revenueTotal!: number;
    searchTerm: string = "";
    constructor(private api: ApiService) {}
    ngOnInit(): void {
        this.api.getallUser().subscribe((res) => {
            this.Accounts = res;
            this.roomTypeResult = this.Accounts;
            console.log(this.Accounts);
        });
    }

    searchBookings() {
        // Chuyển đổi từ khóa tìm kiếm thành chữ thường
        const searchTerm = this.searchTerm.toLowerCase();
        // Lọc các đặt phòng dựa trên từ khóa tìm kiếm
        this.Accounts = this.Accounts.filter(
            (item) =>
                item.name.toLowerCase().includes(searchTerm) ||
                item.email.includes(searchTerm) ||
                item.phoneNumber.toString().includes(searchTerm)
        );
        this.searchTerm = "";
    }
    clearSearch() {
        this.Accounts = this.roomTypeResult;
    }
}

