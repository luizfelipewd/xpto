import { Component, OnInit } from "@angular/core";
import { FormGroup } from "@angular/forms";
import { Router } from "@angular/router";
import { AuthService } from "../../services/auth.service";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"],
})
export class LoginComponent implements OnInit {
  private user: any = {};

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit() {
    this.user = {
      email: "",
      password: "",
    };
  }

  async signIn(form: FormGroup) {
    if (form.valid) {
      try {
        const response = await this.authService.login(this.user).toPromise();

        if (response["token"]) {
          const token = response["token"];
          localStorage.setItem("token", token);
          return this.router.navigate(["/dashboard"]);
        }
      } catch (error) {
        console.log(error);
      }
    }
    return alert("Login inválido");
  }
}
