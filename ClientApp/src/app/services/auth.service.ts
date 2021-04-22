import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";

const ApiRoutes = {
  login: "users/login",
  signup: "users/signup",
  os: "os",
};

@Injectable({
  providedIn: "root",
})
export class AuthService {
  private ApiUri: string = "https://localhost:5001/v1";
  constructor(private http: HttpClient) {}

  public signup(user: any) {
    let uri = `${this.ApiUri}/${ApiRoutes.signup}`;
    return this.http.post(uri, JSON.stringify(user), this.loadHeaders());
  }

  public login(user: any) {
    let uri = `${this.ApiUri}/${ApiRoutes.login}`;
    return this.http.post(uri, JSON.stringify(user), this.loadHeaders());
  }

  public getOs(token: string = "") {
    let uri = `${this.ApiUri}/${ApiRoutes.os}`;
    return this.http.get<Array<any>>(uri, this.loadHeaders(token));
  }

  public readById(token: string = "", osNumber: string = "") {
    let uri = `${this.ApiUri}/${ApiRoutes.os}/${osNumber}`;
    return this.http.get<any>(uri, this.loadHeaders(token));
  }

  public postOs(token: string = "", os: any) {
    let uri = `${this.ApiUri}/${ApiRoutes.os}`;
    return this.http.post(uri, JSON.stringify(os), this.loadHeaders(token));
  }

  public updateOs(token: string = "", os: any) {
    let uri = `${this.ApiUri}/${ApiRoutes.os}/${os.osNumber}`;
    return this.http.put(uri, JSON.stringify(os), this.loadHeaders(token));
  }

  public deleteOs(token: string = "", osNumber: string = "") {
    let uri = `${this.ApiUri}/${ApiRoutes.os}/${osNumber}`;
    return this.http.delete(uri, this.loadHeaders(token));
  }

  private loadHeaders(token: string = "") {
    let headers = new HttpHeaders({
      "Content-type": "application/json",
      Authorization: `${token}`,
    });
    return { headers };
  }
}
