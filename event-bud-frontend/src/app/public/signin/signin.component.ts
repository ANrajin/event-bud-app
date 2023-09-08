import { Component } from '@angular/core';
import { DatetimeHelper } from 'src/app/_core/helpers/datetime.helper';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css'],
})
export class SigninComponent {
  isLoading: boolean = false;
  readonly currentYear: number = DatetimeHelper.currentYear;

  onFormSubmitHandler = (event: SubmitEvent) => {
    event.preventDefault();

    this.isLoading = true;

    setTimeout(() => {
      this.isLoading = false;
    }, 5000);
  }
}
