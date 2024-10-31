import { PaginationParametersModel } from "./paginationParametersModel";

export class PaginationResultModel<T>
{
    isFirst: boolean;
    isLast: boolean;
    items: T[];
    paginationParameters: PaginationParametersModel;
    totalItems: number;
    totalPages: number;

    constructor()
    {
        this.isFirst = false;
        this.isLast = false;
        this.items = [];
        this.paginationParameters = {
            page: 0,
            size: 0,
            skip: 0
        };
        this.totalItems = 0;
        this.totalPages = 0;
    }
}