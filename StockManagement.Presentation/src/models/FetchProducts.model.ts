import { Product } from "./Product.model";

export interface FetchProducts {
  totalProducts: number,
  products: Product[]
}
