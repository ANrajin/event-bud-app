import {Component, Inject} from '@angular/core';
import {DatetimeHelper} from 'src/app/_core/helpers/datetime.helper';
import {CommonService} from 'src/app/_core/services/common.service';
import {pageTransition} from 'src/app/shared/utils/animations';
import {PublicRoutes} from '../../public.routes';
import {FormBuilder} from "@angular/forms";
import {Signin} from './signin.model';
import {Notyf} from 'notyf';
import {NOTYF} from 'src/app/shared/utils/notyf.token';
import {LocalStorageService} from "../../../shared/services/localStorage.service";
import {AuthService} from "../auth.service";

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
    private authService: AuthService,
    private localStorage: LocalStorageService,
    @Inject(NOTYF) private notyf: Notyf) { }

  signInForm = this.formBuilder.group({
    username: [''],
    password: ['']
  });

  onFormSubmitHandler = (event: SubmitEvent) => {
    event.preventDefault();
    this.isLoading = true;

    if (this.signInForm.valid) {
      const formData: Signin = {
        username: this.signInForm.get('username')?.value!,
        password: this.signInForm.get('password')?.value!
      };

      this.authService.signIn(formData).subscribe({
        next: (res) => {
          this.localStorage.put("token", res.token);
        },
        error: (err)=> {
            this.isLoading = false;
        },
        complete: () => {
          window.location.href = "/admin/dashboard";
          this.isLoading = false;
        },
      });
    }
  }
}
