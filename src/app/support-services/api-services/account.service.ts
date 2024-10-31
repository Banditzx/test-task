import { Injectable } from "@angular/core";
import { RequestHelperService } from "../config-services/request-helper.service";
import { Controller } from "../config-data/controller-type";
import { Method } from "../config-data/controller-methods";
import { catchError, Observable, take } from "rxjs";
import { LogService } from "../config-services/log.service";
import { AccountModel } from "../../models/accountModel";

@Injectable()
export class AccountService
{
    constructor(private request: RequestHelperService,
                private logService: LogService)
    {
    }

    public getMe(): Observable<void | AccountModel>
    {
        return this.request.get<AccountModel>(Controller.ACCOUNT, Method.GET + `/me`).pipe(
            take(1),
            catchError(async (err) => {
                this.logService.logError(err);
            }));
    }
}