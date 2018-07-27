import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Product } from './product';
import { Observable } from 'rxjs';

@Injectable()
export class ProductService {

    private url = "http://localhost:54302/api/product/";
    constructor(private http: HttpClient) { }

    getForShop(id: number) {
        const urlParams = new HttpParams().set("id", id.toString());
        return this.http.get(this.url, { params: urlParams });
    }
}