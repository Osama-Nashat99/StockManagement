import { User } from "./User.model";

export interface FetchUsers {
  totalEntities: number,
  entities: User[]
}
