import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { AuthenticationAppComponent } from "./authentication.app.component";
import { LoginComponent } from "./login/login.component";
import { RegisterComponent } from "./register/register.component";

const authenticationRouterConfig: Routes = [
    {path: 'authentication', component: AuthenticationAppComponent,
        children:[
            { path: 'login', component: LoginComponent},
            { path: 'sign-up', component: RegisterComponent},
            { path: '**', redirectTo: '/404'}
        ]
    }
];

@NgModule({
    imports:[
        RouterModule.forChild(authenticationRouterConfig)
    ],
    exports: [
        RouterModule
    ]
})
export class AuthenticationRoutingModule{}