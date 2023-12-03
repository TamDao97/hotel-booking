import { Component, OnInit } from "@angular/core";
import { ContactService } from "../../../_service/contact.service";
import { Paging } from "../../../models/paging";

@Component({
    selector: "app-question-list-tab",
    templateUrl: "./question-list-tab.component.html",
    styleUrls: ["./question-list-tab.component.css"],
})
export class QuestionListTabComponent implements OnInit {
    questions: any[] = [];
    filter: any = { ...Paging };
    constructor(private contactService: ContactService) {}

    ngOnInit(): void {
        this.search();
    }

    search() {
        this.contactService.getAllQuestion(this.filter).subscribe((res) => {
            this.questions = res?.data?.gridData;
            this.filter.totalData = res?.data?.totalData;
        });
    }

    clearSearch() {
        this.filter.keyWord = null;
        this.search();
    }
}

