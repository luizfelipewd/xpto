import {
  animate,
  state,
  style,
  transition,
  trigger,
} from "@angular/animations";

export let fade = trigger("fade", [
  state("void", style({ opacity: 0, transform: "translateY(-20%)" })),
  transition(":enter ,:leave", [animate(100)]),
]);
