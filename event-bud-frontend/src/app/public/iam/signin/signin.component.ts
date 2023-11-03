import { Component } from '@angular/core';
import { DatetimeHelper } from 'src/app/_core/helpers/datetime.helper';
import { CommonService } from 'src/app/_core/services/common.service';
import { pageTransition } from 'src/app/shared/animations';
import { PublicRoutes } from '../../public.routes';
import { FormBuilder, FormControl, Validators } from "@angular/forms";
import { IamService } from '../iam.service';
import { Signin } from './signin.model';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css'],
  animations: [pageTransition]
})
export class SigninComponent {
  isLoading: boolean = false;
  readonly publicRoutes = PublicRoutes;
  readonly currentYear: number = DatetimeHelper.currentYear;

  constructor(
    public commonService: CommonService,
    private formBuilder: FormBuilder,
    private iamService: IamService) { }

  signinForm = this.formBuilder.group({
    username: [''],
    password: ['']
  });

  onFormSubmitHandler = (event: SubmitEvent) => {
    event.preventDefault();
    this.isLoading = true;

    setTimeout(() => {
      this.isLoading = false;
    }, 2000);

    if (this.signinForm.valid) {
      const formData: Signin = {
        username: this.signinForm.get('username')?.value!,
        password: this.signinForm.get('password')?.value!
      };

      // this.iamService.signin(formData).subscribe({
      //   next(res) {
      //     console.log(res);
      //   },
      //   error(err) {
      //     console.error(err);
      //   },
      //   complete() {
      //     console.log("complete");
      //   },
      // });
    }
  }
}
