import {
    Component,
    EventEmitter,
    Input,
    OnChanges,
    OnDestroy,
    OnInit,
    Output,
    SimpleChanges,
} from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";
import { ToastrService } from "ngx-toastr";
import { RoleService } from "../../../_service/role.service";
import { Roles } from "../../../models/roles.model";
import { ApiService } from "../../../_service/api.service";
import { Staff } from "../../../models/staff.model";

@Component({
    selector: "app-role-assign",
    templateUrl: "./role-assign.component.html",
    styleUrls: ["./role-assign.component.css"],
})
export class RoleAssignComponent implements OnInit, OnChanges, OnDestroy {
    @Input() title!: string;
    @Input() employee!: Staff;
    @Output() emmitSave = new EventEmitter<boolean>();
    frmGroup!: FormGroup;
    lstRole!: Roles[];

    constructor(
        private fb: FormBuilder,
        private toast: ToastrService,
        private role: RoleService,
        private api: ApiService
    ) {}

    ngOnChanges(changes: SimpleChanges): void {
        this.frmGroup = this.fb.group({
            userId: [this.employee?.id],
            roleId: [this.employee?.idRoles[0]],
        });
        this.role.getAllRoles().subscribe((res) => {
            this.lstRole = res;
        });
    }

    ngOnInit() {
        this.frmGroup = this.fb.group({
            userId: [this.employee?.id],
            roleId: [this.employee?.idRoles[0]],
        });
        this.role.getAllRoles().subscribe((res) => {
            this.lstRole = res;
        });
    }

    onSave(): void {
        this.api.saveUserRole(this.frmGroup.value).subscribe(
            (response) => {
                this.toast.success(response.message);
                this.emmitSave?.emit(true);
            },
            (error) => {
                this.toast.error(error.error.message);
            }
        );
    }

    ngOnDestroy(): void {
        this.frmGroup.reset();
    }
}

