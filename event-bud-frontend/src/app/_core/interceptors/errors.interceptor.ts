import {HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from "@angular/common/http";
import {Inject, Injectable} from "@angular/core";
import {catchError, Observable, throwError} from "rxjs";
import {NOTYF} from "../../shared/utils/notyf.token";
import {Notyf} from "notyf";

@Injectable()
export class ErrorsInterceptor implements HttpInterceptor {
  constructor(@Inject(NOTYF) private notyf: Notyf) {
  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request)
      .pipe(
        catchError((error) => {
          if (error instanceof HttpErrorResponse) {
            this.notyf.error({
              message: 'Accept the terms before moving forward',
              duration: 0,
              className: "server-error",
            });
          }
          return throwError(new Error('An error occurred'));
        })
      );
  }
}
