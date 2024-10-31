import { Component } from "@angular/core";
import { AbstractControl, FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from "@angular/forms";
import { environment } from "../../../environments/environment";
import { SignUpModel } from "../../models/signUpModel";
import { CommonModule } from "@angular/common";
import { Services } from "../../support-services";
import { Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { SessionStorageService } from "../../support-services/storage-services/session-storage.service";

@Component({
    selector: 'app-sign-up-first-step',
    templateUrl: './sign-up-first-step.component.html',
    styleUrls: ['./sign-up-first-step.component.scss'],
    standalone: true,
    imports: [CommonModule, FormsModule, ReactiveFormsModule],
    providers: [Services]
})
export class SignUpFirstStepComponent
{
    protected signUpForm: FormGroup;
    protected submitted: boolean = false;

    constructor(private formBuilder: FormBuilder,
                private router: Router,
                private toastrService: ToastrService,
                private sessionStorageService: SessionStorageService)
    {
        this.signUpForm = this.formBuilder.group({
            email: ['', [Validators.required, Validators.email, Validators.pattern(environment.regexExpressions.EMAIL_REGEXP)]],
            password: ['', [Validators.required, Validators.min(3), Validators.pattern(environment.regexExpressions.PASSWORD_REGEXP)]],
            isAgree: [false],
            confirmPassword: ['', [Validators.required, Validators.min(3)]],
        }, {
            validator: this.matchPassword,
        });

        this.signUpForm.reset();
    }

    protected get signUpControls() { return this.signUpForm?.controls; }

    protected goToStepTwo(): void
    {
        this.submitted = true;
  
        if (this.signUpForm.valid)
        {
            if (this.signUpControls['isAgree'].value !== true)
            {
                this.toastrService.warning("Attention! You have not confirmed your consent!");
                return;
            }

            this.sessionStorageService.set("first-data-email", this.signUpControls['email'].value.trim());
            this.sessionStorageService.set("first-data-password", this.signUpControls['password'].value.trim());

            this.router.navigate(['/second-step']);
            this.toastrService.success("Eaaah a little more! Let's go!");
        }
    }

    private matchPassword(abstractControl: AbstractControl): true | null
    {
        const password = abstractControl.get('password');
        const confirmPassword = abstractControl.get('confirmPassword');
        if (password?.value === confirmPassword?.value)
        {
            return null;
        }
    
        abstractControl.get('confirmPassword')?.setErrors({ mustMatch: true });
    
        return true;
    }
}