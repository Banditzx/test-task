import { Injectable } from "@angular/core";
import { RequestHelperService } from "../config-services/request-helper.service";
import { Controller } from "../config-data/controller-type";
import { Method } from "../config-data/controller-methods";
import { catchError, Observable, take } from "rxjs";
import { LogService } from "../config-services/log.service";
import { LocationModel } from "../../models/locationModel";
import { PaginationResultModel } from "../../models/pagination/paginationResultModel";
import { PaginationModel } from "../../models/pagination/paginationModel";

@Injectable()
export class LocationService
{
    constructor(private request: RequestHelperService,
                private logService: LogService)
    {
    }

    public getCountryList(pagination: PaginationModel): Observable<void | PaginationResultModel<LocationModel>>
    {
        return this.request.post<PaginationResultModel<LocationModel>>(Controller.LOCATION, Method.GET + `/country/list`, pagination).pipe(
            take(1),
            catchError(async (err) => {
                this.logService.logError(err);
            }));
    }

    public getProvinceList(countryId: number, pagination: PaginationModel): Observable<void | PaginationResultModel<LocationModel>>
    {
        return this.request.post<PaginationResultModel<LocationModel>>(Controller.LOCATION, Method.GET + `/province/list?countryId=${countryId}`, pagination).pipe(
            take(1),
            catchError(async (err) => {
                this.logService.logError(err);
            }));
    }
}