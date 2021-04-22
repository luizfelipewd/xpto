import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { AuthService } from "src/app/services/auth.service";
import { EmitterService } from "src/app/services/emitter.service";

@Component({
  selector: "app-dashboard",
  templateUrl: "./dashboard.component.html",
  styleUrls: ["./dashboard.component.css"],
})
export class DashboardComponent implements OnInit {
  private oslist: Array<any> = [];
  private token = `Bearer ${localStorage.getItem("token")}`;

  constructor(private router: Router, private authService: AuthService) {}

  ngOnInit() {
    this.authService.getOs(this.token).subscribe((data) => {
      this.oslist = data;
    });
  }

  sendOs(os: any): void {
    EmitterService.osEmitter.emit({ os: os });
    console.log(os);
  }

  async deleteOs(osNumber) {
    try {
      const response = await this.authService
        .deleteOs(this.token, osNumber)
        .toPromise();

      if (response) {
        this.ngOnInit();
      }
    } catch (error) {
      console.log(error);
    }
  }

  private logout() {
    localStorage.removeItem("token");
    this.router.navigate(["/"]);
  }
}
