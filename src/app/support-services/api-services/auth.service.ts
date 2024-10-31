import { Injectable } from "@angular/core";
import { RequestHelperService } from "../config-services/request-helper.service";
import { Controller } from "../config-data/controller-type";
import { catchError, Observable, take } from "rxjs";
import { LogService } from "../config-services/log.service";
import { AccountModel } from "../../models/accountModel";
import { SignUpModel } from "../../models/signUpModel";

@Injectable()
export class AuthService
{
    constructor(private request: RequestHelperService,
                private logService: LogService)
    {
    }

    public signUp(signUp: SignUpModel): Observable<void | AccountModel>
    {
        return this.request.post<AccountModel>(Controller.AUTH, `sign-up`, signUp).pipe(
            take(1),
            catchError(async (err) => {
                this.logService.logError(err);
            }));
    }
}