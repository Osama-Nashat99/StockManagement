import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpInterceptorFn, HttpRequest } from '@angular/common/http';
import { catchError, Observable, throwError  } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar'; 
import { Injectable } from '@angular/core';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private snackBar: MatSnackBar) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      catchError((error: HttpErrorResponse) => {
        let errorMessage = 'An unknown error occurred!';

        if(error.status === 400 || error.status === 401 || error.status === 403 || error.status === 404 || error.status === 500){
          errorMessage = error.error.exceptionMessage
        }

        this.snackBar.open(errorMessage, 'Close', { duration: 3000 });

        return throwError(() => new Error(error.message));
      })
    )
  }
  
};
