import { Component, OnInit } from '@angular/core';
import { ApiService } from '../shared/api.service';

@Component({
  selector: 'app-training',
  templateUrl: './training.component.html',
  styleUrls: ['./training.component.css']
})
export class TrainingComponent implements OnInit {
  trainingdata : any;
  constructor(private service: ApiService) { }

  ngOnInit(): void {
    this.refreshList();
  }

  refreshList(){
    this.service.getTrainingPlanDetails()
    .subscribe(response => {
      this.trainingdata = response;
      console.log(response);
      for (var i = 0; i < this.trainingdata.length; i++) {
        console.log(this.trainingdata[i]);
        $('<option/>')
          .val(this.trainingdata[i].id)
          .html(this.trainingdata[i].trainingTopic)
          .appendTo('#trainingtopic');
      }
    });
  }
  onTrainingSelected(){
    var id = $('#trainingtopic').val();
    if(id == 0) { $('textarea#location').val(''); }
    for (var i = 0; i < this.trainingdata.length; i++) {
      if(id == this.trainingdata[i].id){
        $("textarea#location").val("Scheduling is at "+ this.trainingdata[i].trainingLocation);
        break;
      }
    }
  }
}
