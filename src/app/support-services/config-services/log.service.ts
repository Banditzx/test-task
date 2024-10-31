import { Injectable } from "@angular/core";
import { environment } from "./../../../environments/environment";

@Injectable()
export class LogService
{
    public logInfo(message?: unknown, optionalParams?: unknown): void
    {
        if (environment.production)
        {
            return;
        }

        if (optionalParams != undefined)
        {
            console.info(message, optionalParams);
            return;
        }

        console.info(message);
    }

    public logError(message?: unknown, optionalParams?: unknown): void
    {
        if (environment.production)
        {
            return;
        }

        if (optionalParams != undefined)
        {
            console.error(message, optionalParams);
            return;
        }

        console.error(message);
    }

    public logWarning(message?: unknown, optionalParams?: unknown): void
    {
        if (environment.production)
        {
            return;
        }

        if (optionalParams != undefined)
        {
            console.warn(message, optionalParams);
            return;
        }

        console.warn(message);
    }
}