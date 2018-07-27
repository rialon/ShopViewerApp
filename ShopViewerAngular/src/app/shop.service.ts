import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Shop } from './shop';
import { Observable } from 'rxjs';

@Injectable()
export class ShopService {

    private url = "http://localhost:54302/api/shop/";
    constructor(private http: HttpClient) { }

    getShops() {
        return this.http.get(this.url);
    }
}