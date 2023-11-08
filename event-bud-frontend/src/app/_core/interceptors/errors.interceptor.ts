import {HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from "@angular/common/http";
import {Inject, Injectable} from "@angular/core";
import {catchError, Observable, retry, throwError} from "rxjs";
import {NOTYF} from "../../shared/utils/notyf.token";
import {Notyf} from "notyf";

@Injectable()
export class ErrorsInterceptor implements HttpInterceptor {
  constructor(@Inject(NOTYF) private notyf: Notyf) {
  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    this.notyf.dismissAll();

    return next.handle(request).pipe(
      retry({count: 3, delay: 1000}),
      catchError((errors: HttpErrorResponse) => {
        let errorMessage = "The server is not ready to process your request.";

        if (errors.status >= 500)
          errorMessage = errors.error.title;

        if (errors.status == 400)
          return throwError(() => errors.error);

        this.notyf.error({
          message: errorMessage,
          duration: 0
        });

        return throwError(() => new Error(errorMessage));
      })
    );
  }
}
