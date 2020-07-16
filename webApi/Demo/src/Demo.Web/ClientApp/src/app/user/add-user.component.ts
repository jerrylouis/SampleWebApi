import { Component, Input, Inject } from "@angular/core";
import { NgForm } from "@angular/forms";
import { HttpClient } from "@angular/common/http";
import { stringify } from "@angular/compiler/src/util";

@Component({
  selector: 'app-add-user',
  template: `
    <h2 class="py-5"> Please enter your details below </h2>
    <form #f="ngForm" (ngSubmit)="onSubmit(f)" novalidate>
      <div class="form-group row">
        <label for="firstName" class="col-sm-2">First name</label>
        <input type="firstName" class="col-sm-4 form-control" id="firstName" placeholder="First name"
         required [(ngModel)]="user.firstName" name="first" #first="ngModel">
      </div>
      <div *ngIf="first.invalid && first.touched" class="alert alert-danger">
        <div *ngIf="first.errors.required">
          First name is required.
        </div>
      </div>
      <div class="form-group row">
        <label for="lastName" class="col-sm-2">Last name</label>
        <input type="lastName" class="col-sm-4 form-control" id="lastName" placeholder="Last name"
         required [(ngModel)]="user.lastName" name="last" #last="ngModel">
      </div>
      <div *ngIf="last.invalid && last.touched" class="alert alert-danger">
        <div *ngIf="last.errors.required">
          Last name is required.
        </div>
      </div>

      <button [disabled]="f.invalid" type="submit" class="btn btn-primary">Submit</button>
      <div *ngIf="submitted && success" class="mt-2 alert alert-success">Details submitted successfully!
        <p class="pt-2"></p>
        <pre>Result:  {{result}}</pre>
      </div>
      <div *ngIf="submitted && !success" class="mt-2 alert alert-danger">Unable to submit details, please try again.</div>
    </form>

  `
})
export class AddUserComponent {

  user: User = {
    firstName: '',
    lastName: '',
  };

  success: boolean = false;
  submitted: boolean = false;
  result: string = '';

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  onSubmit(f: NgForm) {
    if (f.valid) {
      this.http.post<User>(this.baseUrl + 'user', this.user).subscribe(result => {
        if (result) {
          this.success = true;
          this.submitted = true;
          result.createdDate = new Date(result.createdDate).toString();
          this.result = JSON.stringify(result, undefined, 2).trim();
        }
      }, error => console.error(error));
    }
  }
}
