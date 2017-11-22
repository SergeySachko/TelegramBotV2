import {Component,OnInit} from "@angular/core"
import { HeroModel } from "../../models/hero.model";
import { HeroService } from "../../services/heroes-service";

@Component({
    selector:"heroes",
    templateUrl:"all-heroes.component.html"
})
export class AllHeroes  implements OnInit{
    
    private heroes:Array<HeroModel> = new Array();

    constructor(private heroService:HeroService){}

    ngOnInit(){
        this.heroService.getAllHeroes().subscribe(response => 
        {
            this.heroes = response;
        })
    }
}