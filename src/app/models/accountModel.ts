import { BaseModel } from "./baseModel";
import { LocationModel } from "./locationModel";

export interface AccountModel extends BaseModel
{
    email: string;
    country: LocationModel;
    province: LocationModel;
    createdAt: Date;
}