import { Component, Inject } from '@angular/core';
import { DatetimeHelper } from 'src/app/_core/helpers/datetime.helper';
import { CommonService } from 'src/app/_core/services/common.service';
import { pageTransition } from 'src/app/shared/utils/animations';
import { PublicRoutes } from '../../public.routes';
import { FormBuilder, FormControl, Validators } from "@angular/forms";
import { IamService } from '../iam.service';
import { Signin } from './signin.model';
import { Notyf } from 'notyf';
import { NOTYF } from 'src/app/shared/utils/notyf.token';

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
    private iamService: IamService,
    @Inject(NOTYF) private notyf: Notyf) { }

  signinForm = this.formBuilder.group({
    username: [''],
    password: ['']
  });

  onFormSubmitHandler = (event: SubmitEvent) => {
    event.preventDefault();
    this.isLoading = true;

    this.notyf.error("One or more filed under validation is invalid!");

    if (this.signinForm.valid) {
      const formData: Signin = {
        username: this.signinForm.get('username')?.value!,
        password: this.signinForm.get('password')?.value!
      };

      this.iamService.signin(formData).subscribe({
        next(res) {
          console.log(res);
        },
        error(err) {
          console.error(err);
        },
        complete() {
          console.log("complete");
        },
      });
    }
  }
}
