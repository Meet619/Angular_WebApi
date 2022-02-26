import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError } from 'rxjs';

@Injectable({
    providedIn: 'root',
  })
export class ApiService {
  constructor(private http: HttpClient) {
   }
  private readonly apiurl = 'https://localhost:44378/api';
  private readonly register = '/registration';
  private readonly teaminfo = '/teaminfo';
  private readonly trainingplan = '/trainingplan';

  // Register APIS
  getallUsers(){
      return this.http.get(this.apiurl+this.register+'/getallusers').pipe(
        catchError((err) => {
          console.error(err);
          throw err;
        }
      ));
  }
  createUser(register:any){
    return this.http.post(this.apiurl+this.register+'/createuser', register, { responseType: 'text' });
  }

  //Login APIS
  login(login:any){
    return this.http.post(this.apiurl+this.register+'/login', login, { responseType: 'text' });
  }

  // TeamInfo APIS
  getTeamInfoDetails(){
    return this.http.get(this.apiurl+this.teaminfo+'/getallteaminfo')
    }

    // TeamInfo APIS
  getTrainingPlanDetails(){
    return this.http.get(this.apiurl+this.trainingplan+'/getalltrainings')
    }
}