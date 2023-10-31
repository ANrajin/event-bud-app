import { Injectable } from '@angular/core';
import { Signin } from './signin/signin.model';

@Injectable({
  providedIn: 'root'
})
export class IamService {

  constructor() { }

  signin(data: Signin) {
    console.log(data);
  }
}
