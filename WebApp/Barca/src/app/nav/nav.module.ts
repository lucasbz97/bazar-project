import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { AuthenticationModule } from "./authentication/authentication.module";
import { FooterComponent } from "./footer/footer.component";
import { HomeComponent } from "./home/home.component";
import { MenuComponent } from "./menu/menu.component";
import { NotFoundComponent } from "./not-found/not-found.component";
import { ProductModule } from "./product/product.module";

@NgModule({
    declarations: [
        MenuComponent,
        FooterComponent,
        HomeComponent,
        NotFoundComponent
    ],
    imports: [
        CommonModule,
        RouterModule,
        ProductModule,
        AuthenticationModule,
    ],
    exports: []
})
export class NavegacaoModule {}