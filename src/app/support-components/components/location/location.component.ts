import { Component, EventEmitter, forwardRef, HostListener, Input, Output } from "@angular/core";
import { AbstractControl, ControlValueAccessor, FormsModule, NG_VALIDATORS, NG_VALUE_ACCESSOR, ReactiveFormsModule, ValidationErrors, Validator } from "@angular/forms";
import { LocationModel } from "../../../models/locationModel";
import { CommonModule } from "@angular/common";
import { ScrollerDirective } from "../../directives/scroller.directive";

@Component({
    selector: 'app-location',
    templateUrl: './location.component.html',
    styleUrls: ['./location.component.scss'],
    standalone: true,
    imports: [CommonModule, FormsModule, ReactiveFormsModule, ScrollerDirective],
    providers: [
        {
            provide: NG_VALUE_ACCESSOR,
            useExisting: forwardRef(() => LocationComponent),
            multi: true
        },
        {
            provide: NG_VALIDATORS,
            useExisting: forwardRef(() => LocationComponent),
            multi: true
        }
    ]
})
export class LocationComponent implements ControlValueAccessor, Validator
{
    @Input()
    public placeholder: string = "";
    @Input()
    public items: LocationModel[] = [];
    @Input()
    public submitted: boolean = false;
    @Input()
    public zIndex: number = 1000;

    @Output()
    public locationEvent = new EventEmitter<void>();

    protected name: string = "";
    protected isDisabled: boolean = false;
    protected isDropdownOpen: boolean = false;
    protected locationId: number = 0;

    private onChange: any = () => {};
    private onTouched: any = () => {};

    public loadMore(): void
    {
        this.locationEvent.emit();
    }

    protected toggleDropdown(): void
    {
        this.isDropdownOpen = !this.isDropdownOpen;
    }

    protected selectOption(option: LocationModel): void
    {
        if (option !== undefined)
        {
            this.name = option.name;
            this.locationId = option.id;
            this.onChange(this.locationId);
            this.onTouched();
            this.isDropdownOpen = false;
        }
    }

    public writeValue(value: any): void
    {
        if (value === 0)
        {
            this.reset();
            return;
        }
        
        this.locationId = value;
    }

    public validate(control: AbstractControl): ValidationErrors | null
    {
        return control && control.value ? null : { required: true };
    }
    
    public registerOnChange(fn: any): void
    {
        this.onChange = fn;
    }

    public registerOnTouched(fn: any): void
    {
        this.onTouched = fn;
    }

    public setDisabledState?(isDisabled: boolean): void
    {
        this.isDisabled = isDisabled;
    }

    @HostListener('document:click', ['$event'])
    public onClick(event: MouseEvent): void
    {
        const target = event.target as HTMLElement;
        const clickedInside = target.closest('.autocomplete-container');
        if (!clickedInside)
        {
            this.isDropdownOpen = false;
        }
    }

    private reset(): void
    {
        this.name = '';
        this.locationId = 0;
        this.onChange(this.locationId);
        this.onTouched();
    }
}