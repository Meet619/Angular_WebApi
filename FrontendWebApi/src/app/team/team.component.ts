import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';
import { ApiService } from '../shared/api.service';

@Component({
  selector: 'app-team',
  templateUrl: './team.component.html',
  styleUrls: ['./team.component.css']
})
export class TeamComponent implements OnInit {
  teamdata : any;
  constructor(private service: ApiService) { }

  ngOnInit(): void {
    this.refreshList();
  }

  refreshList(){
    this.service.getTeamInfoDetails()
    .subscribe(response => {
      this.teamdata = response;
      console.log(response);
      for (var i = 0; i < this.teamdata.length; i++) {
        console.log(this.teamdata[i]);
        $('<option/>')
          .val(this.teamdata[i].id)
          .html(this.teamdata[i].memberName)
          .appendTo('#teammembers');
      }
    });
  }

  onMemberSelected(){
    var id = $('#teammembers').val();
    if(id == 0) { $('textarea#dateofjoin').val(''); }
    for (var i = 0; i < this.teamdata.length; i++) {
      if(id == this.teamdata[i].id){
        $("textarea#dateofjoin").val(this.teamdata[i].memberName+ ' joined on ' + this.convertDate(new Date(this.teamdata[i].dateOfJoining)));
        break;
      }
    }
  }

  convertDate(date : Date){
    return date.getDate() + ' ' + this.getMonthName(date.getMonth()) + ', '+date.getFullYear();
  }

  getMonthName(monthNumber: any) {
    var months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
    return months[monthNumber];
  }

}
