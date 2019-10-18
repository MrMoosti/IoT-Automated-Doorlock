import { Component, OnInit } from '@angular/core';
import { CpuTempService } from '../services/cputemp.service';
import { Cpu } from '../models/cpu';

@Component({
  selector: 'app-tab3',
  templateUrl: 'cpu-temp.page.html',
  styleUrls: ['cpu-temp.page.scss']
})
export class CpuTempPage  implements OnInit  {
  cpu: number;

  constructor(private cpuTempService: CpuTempService) {}

  ngOnInit() {
    this.cpuTempService.getCpuTemperature().subscribe((data: Cpu) => {
      this.cpu = data;
    });
  }

  getColor(value) {
    if(value <= 10) {
      return "danger";
    } else if(value > 10 && value <= 20) {
      return "primary";
    } else if(value > 20 && value <= 55) {
      return "success";
    } else if(value > 55 && value <= 65) {
      return "warning";
    } else if(value > 65) {
      return "danger";
    } else {
      return "danger";
    }
  }

}
