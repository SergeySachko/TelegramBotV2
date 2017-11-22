import {HttpClientModule} from "@angular/common/http"
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http/src/client";
import { Observable } from "rxjs/Observable";

@Injectable()
export class HeroService {
    constructor(private http:HttpClient){

    }

    getAllHeroes():Observable<any>{
        return this.http.get('/api/heroes');
    }
}