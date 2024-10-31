import { Directive, ElementRef, HostListener, Output, EventEmitter } from '@angular/core';
import { LogService } from '../../support-services/config-services/log.service';

@Directive({
  selector: '[app-scroller]',
  standalone: true,
  providers: [LogService],
})
export class ScrollerDirective
{
    @Output() scrolledToBottom = new EventEmitter<void>();

    constructor(private el: ElementRef,
                private logService: LogService) {}

    @HostListener('scroll', ['$event'])
    private onScroll(event: Event): void
    {
        this.logService.logInfo('onScroll');
        const element = event.target as HTMLElement;
        const atBottom = element.scrollHeight - element.scrollTop === element.clientHeight;
        if (atBottom)
        {
            this.scrolledToBottom.emit();
        }
    }

    @HostListener('window:scroll', ['$event'])
    private onWindowScroll(): void
    {
        this.logService.logInfo('onWindowScroll');
        if ((window.innerHeight + window.scrollY) === document.body.scrollHeight)
        {
            this.scrolledToBottom.emit();
        }
    }
}