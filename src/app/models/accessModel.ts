import { HttpStatusCode } from "@angular/common/http";

export interface AccessModel
{
    accessToken: string;
    message: string;
    statusCode: HttpStatusCode;
}