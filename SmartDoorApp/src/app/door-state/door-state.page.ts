import { Component, OnInit } from '@angular/core';
import { DoorstatusService } from '../services/doorstatus.service';
import { LogService } from '../services/log.service';
import { Log } from '../models/log';

enum DoorState {
  Open,
  Closed
}

@Component({
  selector: 'app-tab2',
  templateUrl: 'door-state.page.html',
  styleUrls: ['door-state.page.scss']
})
export class DoorStatePage implements OnInit {
  doorState: string;
  log: Log;
  doorInterval: any;
  test: any;
  
  constructor(private doorStatusService: DoorstatusService, private logService: LogService) {
    this.log = new Log;
    this.doorState = "";
    this.updateDoorState();
  }

  ngOnInit() {
    var _this = this;
    this.doorInterval = setInterval(function() {
      _this.updateDoorState();
    }, 5000);
  }

  updateDoorState() {
    this.doorStatusService.getDoorState().subscribe((data: DoorState) => {
      this.doorState = DoorState[data].toUpperCase();
    });

    this.logService.getLatestLog().subscribe((data: Log) => {
      this.log = data;
    })
  }

  getColor(value) {
    switch(value) {
      case 0:
        return "success";
      case 1:
        return "danger";
    }
  }

  ngOnDestroy() {
    clearInterval(this.doorInterval);
  }
}
