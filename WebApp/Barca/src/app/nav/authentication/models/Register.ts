import { User } from "./User";

export interface Register extends User {
    Name: string,
    ConfirmPassword: string
}