import { Component } from "@angular/core";
import { RouterOutlet } from "@angular/router";

@Component({
    selector: 'app-main-pages',
    templateUrl: './main-pages.component.html',
    styleUrls: ['./main-pages.component.scss'],
    imports: [RouterOutlet],
    standalone: true,
})
export class MainPagesComponent
{

}