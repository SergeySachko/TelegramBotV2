import { HeroAttribute } from "./hero-attribute.model";

export class HeroModel{

    public id:number;

    public name:string;

    public attributes:Array<HeroAttribute> = new Array();

}