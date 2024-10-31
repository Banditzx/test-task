import { Injectable } from "@angular/core";

@Injectable()
export class SessionStorageService
{
    public get(key: string): string | null
    {
        return sessionStorage.getItem(key);
    }

    public set(key: string, value: string): void
    {
        sessionStorage.setItem(key, value);
    }

    public remove(key: string): void
    {
        sessionStorage.removeItem(key);
    }

    public clear(): void
    {
        sessionStorage.clear();
    }

    public getKey(number: number): string | null
    {
        return sessionStorage.key(number);
    }
}