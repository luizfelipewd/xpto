import { Component } from "@angular/core";
import { fade } from "src/app/utils/animations";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.css"],
  animations: [fade],
})
export class HomeComponent {}
