import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { ProductDetailComponent } from "./components/product-detail/productDetail.component";
import { ProdutoAppComponent } from "./product.app.component";

const productRouterConfig: Routes = [
    {path: 'product', component: ProdutoAppComponent,
        children:[
            { path: 'edit/:id/:name', component: ProductDetailComponent},
            { path: '**', redirectTo: '/404'}
        ]
    }
];

@NgModule({
    imports:[
        RouterModule.forChild(productRouterConfig)
    ],
    exports: [
        RouterModule
    ]
})
export class ProductRoutingModule{}