import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Controller } from './../config-data/controller-type';
import { Method } from './../config-data/controller-methods';
import { Dictionary } from '../../models/helpers/dictionaryModel';
import { ConfigService } from "./config.service";

@Injectable()
export class RequestHelperService
{
    private apiUrl: string;

    constructor(private httpClient: HttpClient,
                private configService: ConfigService)
    {
        this.apiUrl = configService.apiUrl;
    }

    public get<T>(controller: Controller, method: Method | string, params?: unknown) : Observable<T>
    {
        let link = `${this.apiUrl}/api/${controller}/${method}`;

        if (params != undefined)
        {
            const keys = Object.keys(params);
            const dictionary = params as Dictionary<string>;
            let count = 0;
            link += '?';

            keys.forEach(element => {
                link += element + '=' + dictionary[element];
                count++;

                if (keys.length > count)
                {
                    link += '&';
                }
            });
        }

        return this.httpClient.get<T>(link).pipe(map(data=>{
            return data;
        }));
    }

    public post<T>(controller: Controller, method: Method | string, params: unknown) : Observable<T>
    {
        const link = `${this.apiUrl}/api/${controller}/${method}`;

        return this.httpClient.post<T>(link, params).pipe(map(data=>{
            return data;
        }));
    }

    public put<T>(controller: Controller, method: Method | string, params: unknown) : Observable<T>
    {
        const link = `${this.apiUrl}/api/${controller}/${method}`;

        return this.httpClient.put<T>(link, params).pipe(map(data=>{
            return data;
        }));
    }

    public delete<T>(controller: Controller, method: Method | string, params?: unknown) : Observable<T>
    {
        let link = `${this.apiUrl}/api/${controller}/${method}`;

        if (params != undefined)
        {
            const keys = Object.keys(params);
            const dictionary = params as Dictionary<string>;
            let count = 0;
            link += '?';

            keys.forEach(element => {
                link += element + '=' + dictionary[element];
                count++;

                if (keys.length > count)
                {
                    link += '&';
                }
            });
        }

        return this.httpClient.delete<T>(link).pipe(map(data=>{
            return data;
        }));
    }
}