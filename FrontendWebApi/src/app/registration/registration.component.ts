import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';
import { ToastrService } from 'ngx-toastr';
import { ApiService } from '../shared/api.service';

export class RegistrationDetails {
  public username!: string;
  public password!: string;
}

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  model = new RegistrationDetails();
  constructor(private service: ApiService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.refreshList();
  }
  clearInputFields(){
    // $("#username").val('');
    // $("#password").val('');
    this.model.username = "";
    this.model.password = "";
  }
  onSubmit(form:any) {
    const registerForm  = { id : 0, username : form.value.username, password : form.value.password}
    console.log(registerForm);
    this.service.createUser(registerForm)
    .subscribe(response => {
      console.log(response);
      this.toastr.success("",response);
      this.clearInputFields();
    },(error)=>{
      this.toastr.error("",error.error);
      this.clearInputFields();
    });
  }

  refreshList(){
    this.service.getallUsers()
    .subscribe(response => {
      console.log(response);
    });
  }
 
}
