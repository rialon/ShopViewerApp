import { TemplateRef, ViewChild } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { Shop } from './shop';
import { ShopService } from './shop.service';
import { ProductService } from './product.service';
import { Observable } from 'rxjs';
import { Product } from './product';

@Component({
    selector: 'shop-app',
    templateUrl: './app.component.html',
    providers: [ShopService, ProductService]
})
export class AppComponent implements OnInit {
    shops: Array<Shop>;
    products: Array<Product>;
    productsLoaded: boolean = false;
    currentShop: Shop;

    constructor(private shopService: ShopService, private productService: ProductService) {
        this.shops = new Array<Shop>();
        this.products = new Array<Product>();
    }

    ngOnInit() {
        this.loadShops();
    }

    private loadShops() {
        this.shopService.getShops().subscribe((data: Shop[]) => {
            this.shops = data;
        });
    }

    private loadProducts(shop: Shop) {
        this.currentShop = shop;
        this.productsLoaded = true;
        this.productService.getForShop(shop.Id).subscribe((data: Product[]) => {
            this.products = data;
        });
    }
}