import {Component, Input} from '@angular/core';
import {CommonModule} from '@angular/common';
import {slideDown} from "../../utils/animations";
import {AlertType} from "./alert.type";

@Component({
  selector: 'app-alert',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './alert.component.html',
  styleUrls: ['./alert.component.css'],
  animations: [slideDown]
})
export class AlertComponent {
  @Input() messages: string[] = [];
  @Input() type: AlertType = AlertType.Danger;
  @Input() dismissible: boolean = false;
  protected readonly AlertType = AlertType;
}
