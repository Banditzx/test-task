import { Routes } from '@angular/router';
import { MainPagesComponent } from './main-pages/main-pages.component';
import { SignUpFirstStepComponent } from './main-pages/sign-up-first-step/sign-up-first-step.component';
import { SignUpSecondStepComponent } from './main-pages/sign-up-second-step/sign-up-second-step.component';

export const routes: Routes = [
    {
        path: "",
        component: MainPagesComponent,
        children: [
            {
                path: '',
                redirectTo: 'first-step',
                pathMatch: 'full'
            },
            {
                path: 'first-step',
                component: SignUpFirstStepComponent
            },
            {
                path: 'second-step',
                component: SignUpSecondStepComponent,
            },
        ]
    }
];