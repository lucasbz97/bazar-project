import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { AuthenticationModule } from "./authentication/authentication.module";
import { HomeComponent } from "./home/home.component";
import { NotFoundComponent } from "./not-found/not-found.component";
import { ProductModule } from "./product/product.module";
import { SharedModule } from "./shared/shared.module";

@NgModule({
    declarations: [
        HomeComponent,
        NotFoundComponent
    ],
    imports: [
        CommonModule,
        RouterModule,
        ProductModule,
        AuthenticationModule,
        SharedModule
    ],
    exports: []
})
export class NavegacaoModule {}