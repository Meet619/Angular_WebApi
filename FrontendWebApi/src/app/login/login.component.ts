import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ApiService } from '../shared/api.service';
import { Router } from '@angular/router';

export class LoginDetails {
  public username!: string;
  public password!: string;
}

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model = new LoginDetails();
  uname : any;
  constructor(private service: ApiService, private toastr: ToastrService,private router: Router) { }

  ngOnInit(): void {
  }

  clearInputFields(){
    this.model.username = "";
    this.model.password = "";
  }

  onSubmit(form: { value: any; }) {
    const loginForm  = { id : 0, username : form.value.username, password : form.value.password}
    this.uname = form.value.username;
    this.service.login(loginForm)
    .subscribe(response => {
      this.toastr.success(response, "Welcome "+this.uname+"!");
      this.router.navigateByUrl('/menu?username='+this.uname);
    },(error)=>{
      this.toastr.error("Invalid Data",error.error);
      this.clearInputFields();
    });
  }

}
