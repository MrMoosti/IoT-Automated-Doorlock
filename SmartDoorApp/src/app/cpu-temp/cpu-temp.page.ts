import { Component, OnInit } from '@angular/core';
import { CpuTempService } from '../services/cputemp.service';
@Component({
  selector: 'app-tab3',
  templateUrl: 'cpu-temp.page.html',
  styleUrls: ['cpu-temp.page.scss']
})
export class CpuTempPage  implements OnInit  {
  cpu: number;
  cpuInterval: any;

  constructor(private cpuTempService: CpuTempService) {
    this.cpuTempService.
    getCpuTemperature().subscribe((data: number) => {
      this.cpu = data;
    });
  }

  ngOnInit() {
    var _this = this;
    this.cpuInterval = setInterval(function() {
      _this.updateCpu();
    }, 5000);
  }

  updateCpu() {
    this.cpuTempService.getCpuTemperature().subscribe((data: number) => {
      this.cpu = data;
      console.log(data);
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

  ngOnDestroy() {
    clearInterval(this.cpuInterval);
  }

}
