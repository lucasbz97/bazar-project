import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Constants } from "src/constants";
import { User } from "./models/User";

@Injectable()
export class AuthenticationService {

  constructor(private http: HttpClient) {
   }

  protected UrlServiceV1: string = Constants.BARCA_API;
  
  DoLogin(data: User): Observable<User> {
      return this.http.post<User>(this.UrlServiceV1 + "login", data);
  }
}