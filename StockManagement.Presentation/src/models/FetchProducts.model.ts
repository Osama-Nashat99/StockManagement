import { Product } from "./Product.model";

export interface FetchProducts {
  totalEntities: number,
  entities: Product[]
}
