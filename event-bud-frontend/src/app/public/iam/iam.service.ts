import { Injectable } from '@angular/core';
import { Signin } from './signin/signin.model';
import { Observable } from 'rxjs';
import { IamResponse } from './iam.response';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class IamService {

  private endpoints: any = {
    signin: "api/v1/Signin"
  };

  constructor(private httpClient: HttpClient) { }

  signin(data: Signin): Observable<IamResponse> {
    return this.httpClient.post<IamResponse>(this.endpoints.signin, data);
  }
}
