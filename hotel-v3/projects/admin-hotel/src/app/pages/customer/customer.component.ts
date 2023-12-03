import {
    Component,
    ComponentRef,
    OnInit,
    ViewChild,
    ViewContainerRef,
} from "@angular/core";
import { ApiService } from "../../_service/api.service";
import { Staff } from "../../models/staff.model";
import { RoleAssignComponent } from "../role/role-assign/role-assign.component";

@Component({
    selector: "app-customer",
    templateUrl: "./customer.component.html",
    styleUrls: ["./customer.component.css"],
})
export class CustomerComponent implements OnInit {
    Accounts: Staff[] = [];
    roomTypeResult: Staff[] = [];
    numAccount!: number;
    numbBookings!: number;
    revenueTotal!: number;
    searchTerm: string = "";
    employee!: Staff;
    _currentRole!: string;
    constructor(private api: ApiService) {}

    ngOnInit(): void {
        this._currentRole = localStorage.getItem("Roletype") ?? "";
        this.onReload();
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

    openModal(item: any) {
        this.employee = item;
    }

    onReload(): void {
        this.api.getallUser().subscribe((res) => {
            this.Accounts = res;
            this.roomTypeResult = this.Accounts;
        });
    }
}
