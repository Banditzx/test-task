import { AccountService } from "./api-services/account.service";
import { AuthService } from "./api-services/auth.service";
import { LocationService } from "./api-services/location.service";
import { ConfigService } from "./config-services/config.service";
import { LogService } from "./config-services/log.service";
import { RequestHelperService } from "./config-services/request-helper.service";
import { LocalStorageService } from "./storage-services/local-storage.service";
import { SessionStorageService } from "./storage-services/session-storage.service";

export const Services = [
    AuthService,
    AccountService,
    LocationService,
    LogService,
    ConfigService,
    RequestHelperService,
    LocalStorageService,
    SessionStorageService
];