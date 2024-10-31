import { Component, OnInit } from "@angular/core";
import { Services } from "../../support-services";
import { CommonModule } from "@angular/common";
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from "@angular/forms";
import { AuthService } from "../../support-services/api-services/auth.service";
import { LogService } from "../../support-services/config-services/log.service";
import { ToastrService } from "ngx-toastr";
import { SignUpModel } from "../../models/signUpModel";
import { catchError, map, mergeMap } from "rxjs";
import { AccountModel } from "../../models/accountModel";
import { LocationModel } from "../../models/locationModel";
import { LocationService } from "../../support-services/api-services/location.service";
import { PaginationModel } from "../../models/pagination/paginationModel";
import { PaginationResultModel } from "../../models/pagination/paginationResultModel";
import { LocationComponent } from "../../support-components/components/location/location.component";
import { Router } from "@angular/router";
import { SessionStorageService } from "../../support-services/storage-services/session-storage.service";

@Component({
    selector: 'app-sign-up-second-step',
    templateUrl: './sign-up-second-step.component.html',
    styleUrls: ['./sign-up-second-step.component.scss'],
    standalone: true,
    imports: [CommonModule, FormsModule, ReactiveFormsModule, LocationComponent],
    providers: [Services]
})
export class SignUpSecondStepComponent implements OnInit
{
    protected locationForm: FormGroup;
    protected countries: PaginationResultModel<LocationModel> | undefined;
    protected provincies: PaginationResultModel<LocationModel> | undefined;
    protected submitted: boolean = false;
    protected isProcessing: boolean = false;

    private paginationCountry: PaginationModel = { page: 1, size: 20 };
    private paginationProvince: PaginationModel = { page: 1, size: 10 };

    constructor(private locationService: LocationService,
                private authService: AuthService,
                private logService: LogService,
                private formBuilder: FormBuilder,
                private toastrService: ToastrService,
                private sessionStorageService: SessionStorageService,
                private router: Router)
    {
        this.locationForm = this.formBuilder.group({
            email: ['', [Validators.required]],
            password: ['', [Validators.required]],
            countryId: [0, [Validators.required, Validators.min(1)]],
            provinceId: [{ value: 0, disabled: true }, [Validators.required, Validators.min(1)]],
        });
    }

    protected get locationControls() { return this.locationForm?.controls; }

    public ngOnInit(): void
    {
        const email: string | null = this.sessionStorageService.get("first-data-email");
        const password: string | null = this.sessionStorageService.get("first-data-password");
        if (email === undefined || password === undefined)
        {
            this.router.navigate(['first-step']);
        }
        else
        {
            this.locationControls['email'].setValue(email);
            this.locationControls['password'].setValue(password);
        }

        this.locationControls['countryId'].valueChanges.pipe(
            mergeMap((res) => {
                return this.locationService.getProvinceList(res, this.paginationProvince).pipe(
                    map((res: void | PaginationResultModel<LocationModel>) => {
                        if (res)
                        {
                            this.provincies = res;
                            this.locationControls['provinceId'].setValue(0);
                            this.locationControls['provinceId'].enable();
                        }
                    }));
            })).subscribe();

        this.locationService.getCountryList(this.paginationCountry).pipe(
            map((res: void | PaginationResultModel<LocationModel>) => {
                if (res)
                {
                    this.countries = res;
                }
            })).subscribe();
    }

    protected loadMoreCountries(): void
    {
        if (!this.countries?.isLast)
        {
            this.paginationCountry.page++;

            this.locationService.getCountryList(this.paginationCountry).pipe(
                map((res: void | PaginationResultModel<LocationModel>) => {
                    if (res && this.countries)
                    {
                        this.countries.isLast = res.isLast;

                        res.items.forEach((country: LocationModel) => {
                            this.countries?.items.push(country);
                        });
                    }
                })).subscribe();
        }
    }

    protected loadMoreProvincies(): void
    {
        if (!this.provincies?.isLast)
        {
            this.paginationProvince.page++;

            const countryId: number = parseInt(this.locationControls['countryId'].value);

            this.locationService.getProvinceList(countryId, this.paginationProvince).pipe(
                map((res: void | PaginationResultModel<LocationModel>) => {
                    if (res && this.provincies)
                    {
                        this.provincies.isLast = res.isLast;

                        res.items.forEach((country: LocationModel) => {
                            this.provincies?.items.push(country);
                        });
                    }
                })).subscribe();
        }
    }

    protected signUp(): void
    {
        this.submitted = true;
  
        if (this.locationForm.valid && !this.isProcessing)
        {
            this.isProcessing = true;

            const signUpData: SignUpModel = {
                email: this.locationControls['email'].value,
                password: this.locationControls['password'].value,
                provinceId: parseInt(this.locationControls['provinceId'].value)
            };

            this.authService.signUp(signUpData).pipe(
                map((res: AccountModel | void) => {
                    if (res !== undefined)
                    {
                        this.submitted = false;
                        this.toastrService.success("Registration was successful!");
                        this.sessionStorageService.clear();
                        this.router.navigate(['first-step']);
                    }

                    this.isProcessing = false;
                }),
                catchError(async (err) => {
                    this.isProcessing = false;
                    this.logService.logError(err);
                })).subscribe();
        }
    }
}