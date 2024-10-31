import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';

@Injectable()
export class ConfigService
{
    public apiUrl: string = environment.api.url;
}