import { Component, Inject } from '@angular/core'
import { HeroModel } from '../../models/hero.model';
import { Input } from '@angular/core/src/metadata/directives';

@Component({
    selector:'hero',
    templateUrl:'hero.component.html',
    styleUrls: ['./hero.component.css']
})
export class HeroComponent{
    @Input() set hero(value: HeroModel){
        this.hero = value;
        this.Str = value.attributes.find(x=>x.name == "Strength");     
        this.Agl = value.attributes.find(x=>x.name == "Agility");   
        this.Int = value.attributes.find(x=>x.name == "Intelligence");  
    }

    private Str:any;
    private Agl:any;
    private Int:any;

    constructor(){

    }

}