import { Category } from "./Category.model";

export interface FetchCategories {
  totalEntities: number,
  entities: Category[]
}