import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ApiService } from '../_service/api.service';
import { ContactService } from '../_service/contact.service';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.scss'],
})
export class ContactComponent implements OnInit {
  contact!: FormGroup;
  submitted = false;
  get f() {
    return this.contact.controls;
  }
  constructor(
    private http: HttpClient,
    private fb: FormBuilder,
    private router: Router,
    private contactservice: ContactService,
    private toast: ToastrService
  ) {}
  ngOnInit(): void {
    this.contact = this.fb.group({
      firstName: ['', Validators.required, Validators.name],
      lastName: ['', Validators.required, Validators.name],
      email: ['', [Validators.required, Validators.email]],
      phoneNumber: [
        '',
        [Validators.required, Validators.pattern('[- +()0-9]{10}')],
      ],
      message: ['', Validators.required, Validators.name],
    });
  }

  onSubmit() {
    this.submitted = true;
    if (this.contact.invalid) return;

    this.contactservice.create(this.contact.value).subscribe(
      (response) => {
        this.toast.success(response.message);
        this.contact.reset();
      },
      (error) => {
        this.toast.error(error.error.message);
      }
    );
  }
}
