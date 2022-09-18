/*
import { Component, getNgModuleById, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators} from '@angular/forms';
import { Router } from '@angular/router';
import { NewUserService } from '../NewUserServices/new-user.service';
import { CustomerRegisterDto } from '../Models/CustomerRegisterDto';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

    registerForm!: FormGroup;
    loading = false;
    submitted = false;
    error!: string;
    CRD! : CustomerRegisterDto;
    constructor(
      private formBuilder: FormBuilder,
      private router: Router,
      private newUserService: NewUserService,
      ) {}
    /*
    ngOnInit(): void {
      this.registerForm = this.formBuilder.group({
        userId: [''],
        firstName: [''],
        lastName: [''],
        deliveryAddress: [''],
        phone: [''],
        email: [''],
        previousOrders: [''],
        isAdmin:'no',
        password: ['']
        });
      }
     //convenience getter for easy access to form fields
    get f() { return this.registerForm.controls; }

    onSubmit(): void {
        this.submitted = true;

        // stop here if form is invalid
        if (this.registerForm.invalid) {
            return;
        }

        this.loading = true;
      }

    registerNewUser()
      {console.log(this.registerForm.value);
        this.newUserService.register(this.registerForm.value)
        .subscribe(data => {
              window.alert("You are now registered.");
              console.log("User is registered.")
        },

          error => {
              this.error = error;
              window.alert("You are not registered yet.");
              console.log("There was an error. User is not registered yet."+ this.error);
              this.loading = false;
          });
        }

}
*/
