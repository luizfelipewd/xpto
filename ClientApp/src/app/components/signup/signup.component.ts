import { Component, OnInit } from "@angular/core";
import { FormGroup } from "@angular/forms";
import { Router } from "@angular/router";
import { AuthService } from "../../services/auth.service";

@Component({
  selector: "app-signup",
  templateUrl: "./signup.component.html",
  styleUrls: ["./signup.component.css"],
})
export class SignupComponent implements OnInit {
  private user: any = {};

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit() {
    this.user = {
      name: "",
      email: "",
      password: "",
    };
  }

  async signUp(form: FormGroup) {
    if (form.valid) {
      try {
        const response = await this.authService.signup(this.user).toPromise();

        if (response) {
          const logon = await this.authService.login(this.user).toPromise();
          const token = logon["token"];
          localStorage.setItem("token", token);
          return this.router.navigate(["/dashboard"]);
        }
      } catch (error) {
        console.log(error);
      }
    }
    return alert("Cadastro inválido");
  }
}
