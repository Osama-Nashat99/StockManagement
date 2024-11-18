import { category } from "../enums/category.enum";

export interface Product {
    id: number,
    name: string,
    description: string,
    category: number,
    price: number,
    quantity: number
};