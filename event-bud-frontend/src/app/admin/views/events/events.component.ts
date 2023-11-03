import { Component } from '@angular/core';
import { pageTransition } from 'src/app/shared/utils/animations';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css'],
  animations: [pageTransition]
})
export class EventsComponent {

}
