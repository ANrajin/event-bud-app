import {Component, ElementRef, Input, ViewChild} from '@angular/core';
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
  @Input() type: AlertType = AlertType.Success;
  @Input() dismissible: boolean = false;

  @ViewChild("alertElement", {static: false}) alertElement!: ElementRef;

  constructor(private elementRef: ElementRef) {
  }

  protected alertTypeClass(): string {
    let elemClass: string;

    switch (this.type) {
      case AlertType.Success:
        elemClass = "alert-success";
        break;
      case AlertType.Danger:
        elemClass = "alert-danger";
        break;
      case AlertType.Info:
        elemClass = "alert-info";
        break;
      default:
        elemClass = "alert-danger";
    }

    return elemClass;
  }

  protected dismissHandler(): void {
    const component = this.elementRef.nativeElement;
    const elem = this.alertElement.nativeElement;

    if (elem) {
      elem.style.height = 0;
      elem.style.padding = 0;
      elem.style.margin = 0;
      elem.style.opacity = 0;

      setTimeout(() => {
        component.remove();
      }, 300);
    }
  }
}
