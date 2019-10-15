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

  constructor(private logService: LogService) {}

  ngOnInit() {
    this.logService.getAllLogs().subscribe((data: Log[]) => {
      this.logs = data;
      console.log(this.logs[0]);
    });
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
