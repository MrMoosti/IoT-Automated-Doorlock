import { Component, OnInit } from "@angular/core";
import { Log, AttemptType } from "../models/log";
import { LogService } from "../services/log.service";
import {
  HttpClient,
  HttpHeaders,
  HttpErrorResponse
} from "@angular/common/http";

@Component({
  selector: "app-tab1",
  templateUrl: "logs.page.html",
  styleUrls: ["logs.page.scss"]
})
export class LogsPage implements OnInit {
  logs: Log[] = [];
  attemptType = AttemptType;
  logSelect: any;

  constructor(private logService: LogService) {}

  ngOnInit() {
    this.getLogs();
  }

  getLogs() {
    switch (this.logSelect) {
      case "today":
        this.logService.getTodaysLogs().subscribe((data: Log[]) => {
          this.logs = data;
        });
        break;
      case "week":
        this.logService.getThisWeeksLogs().subscribe((data: Log[]) => {
          this.logs = data;
        });
        break;
      case "month":
        this.logService.getThisMonthsLogs().subscribe((data: Log[]) => {
          this.logs = data;
          console.log(data);
        });
        break;
      case "succeeded":
        this.logService.getAllSucceededLogs().subscribe((data: Log[]) => {
          this.logs = data;
        });
        break;
      case "failed":
        this.logService.getAllFailedLogs().subscribe((data: Log[]) => {
          this.logs = data;
        });
        break;
      case "all":
        this.logService.getAllLogs().subscribe((data: Log[]) => {
          this.logs = data;
        });
        break;
      default:
        this.logService.getTodaysLogs().subscribe((data: Log[]) => {
          this.logs = data;
        });
        this.logSelect = "today";
        break;
    }
  }

  getColor(value) {
    switch (value) {
      case 0:
        return "success";
      case 1:
        return "danger";
      case 2:
        return "warning";
      case 3:
        return "danger";
    }
  }
}
