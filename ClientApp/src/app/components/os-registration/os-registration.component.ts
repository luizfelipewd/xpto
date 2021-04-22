import { Component, OnInit } from "@angular/core";
import { FormGroup } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { AuthService } from "../../services/auth.service";
import { EmitterService } from "../../services/emitter.service";

@Component({
  selector: "app-os-registration",
  templateUrl: "./os-registration.component.html",
  styleUrls: ["./os-registration.component.css"],
})
export class OsRegistrationComponent implements OnInit {
  private os: any = {};
  private token = `Bearer ${localStorage.getItem("token")}`;

  constructor(
    private authService: AuthService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get("id");
    if (id) {
      this.authService.readById(this.token, id).subscribe((os) => {
        this.os = {
          osNumber: os.osNumber,
          customerCNPJ: os.customerCNPJ,
          customerName: os.customerName,
          date: os.date,
          title: os.title,
          workerCPF: os.workerCPF,
          workerName: os.workerName,
          price: os.price,
        };
      });
    } else {
      this.os = {
        customerCNPJ: "",
        customerName: "",
        date: "",
        title: "",
        workerCPF: "",
        workerName: "",
        price: 0,
      };
    }
  }

  onSubmit(form: FormGroup) {
    if (this.os.osNumber) {
      this.edit(form);
    } else {
      this.register(form);
    }
  }

  async register(form: FormGroup) {
    if (form.valid) {
      try {
        const response = await this.authService
          .postOs(this.token, this.os)
          .toPromise();

        if (response) {
          return this.router.navigate(["/dashboard"]);
        }
      } catch (error) {
        console.log(error);
      }
    }
    return alert("Cadastro inválido");
  }

  async edit(form: FormGroup) {
    if (form.valid) {
      try {
        const response = await this.authService
          .updateOs(this.token, this.os)
          .toPromise();

        if (response) {
          return this.router.navigate(["/dashboard"]);
        }
      } catch (error) {
        console.log(error);
      }
    }
    return alert("Formulário inválido");
  }

  async deleteOs(osNumber) {
    try {
      const response = await this.authService
        .deleteOs(this.token, osNumber)
        .toPromise();

      if (response) {
        return this.router.navigate(["/dashboard"]);
      }
    } catch (error) {
      console.log(error);
    }
  }
}
