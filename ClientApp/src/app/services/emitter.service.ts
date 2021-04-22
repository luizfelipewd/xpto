import { Injectable, EventEmitter } from "@angular/core";

@Injectable()
export class EmitterService {
  static osEmitter = new EventEmitter();
}
