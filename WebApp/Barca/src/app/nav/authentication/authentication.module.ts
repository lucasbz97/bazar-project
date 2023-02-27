import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { AuthenticationRoutingModule } from "./authentication.route";
import { LoginComponent } from "./login/login.component";
import { RegisterComponent } from "./register/register.component";
import { AuthenticationAppComponent } from "./authentication.app.component";

@NgModule({
    declarations: [
        LoginComponent,
        RegisterComponent,
        AuthenticationAppComponent
    ],
    imports: [
        CommonModule,
        AuthenticationRoutingModule,
    ],
    exports: []
})
export class AuthenticationModule {}