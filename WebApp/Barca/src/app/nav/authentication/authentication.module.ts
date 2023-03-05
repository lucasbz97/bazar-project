import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { AuthenticationRoutingModule } from "./authentication.route";
import { LoginComponent } from "./login/login.component";
import { RegisterComponent } from "./register/register.component";
import { AuthenticationAppComponent } from "./authentication.app.component";
import { SharedModule } from "../shared/shared.module";

@NgModule({
    declarations: [
        LoginComponent,
        RegisterComponent,
        AuthenticationAppComponent
    ],
    imports: [
        CommonModule,
        AuthenticationRoutingModule,
        SharedModule
    ],
    exports: []
})
export class AuthenticationModule {}