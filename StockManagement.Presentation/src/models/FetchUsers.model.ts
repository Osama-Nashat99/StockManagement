import { User } from "./User.model";

export interface FetchUsers {
  totalUsers: number,
  users: User[]
}
